using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace DupesMaintWinForms
{
    public partial class SelectBySHA : Form
    {
        private static MyDbConnect MyDb;
        private const string targetRootFolder = @"F:\OneDriveDupes";
        public DupesAction[] dupesAction { get; set; }

        public SelectBySHA()
        {
            InitializeComponent();
        }

        private void SelectBySHA_Load(object sender, EventArgs e)
        {
            LoadCheckSumDups();
            MyDb = new MyDbConnect(@"Server = (localDB)\ProjectsV13; Integrated Security = true; database = pops");
        }

        private void LoadCheckSumDups()
        {
            // TODO: This line of code loads data into the 'popsDataSet.CheckSumDups' table. You can move, or remove it, as needed.
            this.checkSumDupsTableAdapter.ClearBeforeFill = true;
            this.checkSumDupsTableAdapter.Fill(this.popsDataSet.CheckSumDups);
        }


        // move files in table DupesAction from SourceDir to TargetDir and update DupesAction row
        private void btnTest_Click(object sender, EventArgs e)
        {
            // populate dupesAction array with rows where OneDriveRemoved = N
            GetDupesAction();

            this.toolStripStatusLabel1.Text = $"INFO - Starting processing {dupesAction.Length} DupesAction rows with OneDriveRemoved=N.";

            // process the dupesAction rows
            foreach (var dupesActionRow in dupesAction)
            {
                // check if target folder exists, if not create it
                string targetPath = TargetFolderCheck(dupesActionRow);
                Console.WriteLine($"INFO - Target folder {dupesActionRow.Folder} exists under {targetRootFolder}.");

                // now move the file from source to target and update the DupesAction row in the db
                string destPath = DupesActionMove(dupesActionRow, targetPath);
                if (string.IsNullOrEmpty(destPath))
                {
                    Console.WriteLine($"ERROR - File {dupesActionRow.TheFileName} was NOT moved. See console.");
                }
                else
                {
                    Console.WriteLine($"INFO - File {dupesActionRow.TheFileName} was moved to {destPath}.");
                }

            } // end of foreach dupesActionRow

            this.toolStripStatusLabel1.Text = $"INFO - Finished processing {dupesAction.Length} DupesAction rows with OneDriveRemoved=N.";

        }


        private string DupesActionMove(DupesAction dupesActionRow, string targetPath)
        {
            // construct the destPath including the file name
            string[] sourceFolderParts = dupesActionRow.TheFileName.Split('\\');
            string fileName = sourceFolderParts[sourceFolderParts.Length - 1];
            string destPath = targetPath + "\\" + fileName;

            // instaniate a FileInfo object for the source file
            FileInfo sourcePath = new FileInfo(dupesActionRow.TheFileName);
            try
            {
                // move the file from sourcePath to destPath
                sourcePath.MoveTo(destPath);

                // update the dupesActionRow.OneDriveRemoved to 'Y'es
                dupesActionRow.OneDriveRemoved = "Y";
                _ = Program.popsModel.SaveChanges();

                return destPath;
            }
            catch (Exception Ex)
            {
                DisplayException(Ex);
                return null;
            }
        }


        // populate dupesAction with rows where OneDriveRemoved = N
        private void GetDupesAction()
        {
            IQueryable<DupesAction> query = Program.popsModel.DupesActions.Where(dupesAction => dupesAction.OneDriveRemoved == "N")
                                                                            .OrderBy(x => x.TheFileName);
            // cast the query to an array of DupesAction rows
            dupesAction = query.ToArray();

            Console.WriteLine($"INFO - dupesAction[] populated with {dupesAction.Length} rows with OneDriveRemoved == 'N'");
        }


        private string TargetFolderCheck(DupesAction dupesActionRow)
        {
            string targetFolder = targetRootFolder;

            // make sure the targetRootFolder exists
            DirectoryInfo diRoot = new DirectoryInfo(targetRootFolder);
            if (!diRoot.Exists)
            {
                diRoot.Create();
            }

            // construct the targetFolder for this dupesActionRow
            string[] sourceFolderParts = dupesActionRow.Folder.Split('\\');
            for (int i = 1 ; i < sourceFolderParts.Length - 1; i++)
            {
                targetFolder += "\\" + sourceFolderParts[i];
            }

            // if target folder does not exist then create it
            DirectoryInfo diTarget = new DirectoryInfo(targetFolder);
            if (!diTarget.Exists)
            {
                diTarget.Create();
            }

            return targetFolder;
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                //int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                string SHA = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                // call DisplayPhotos4SHA passing in the SHA of the selected duplicates
                Form displayPhotos = new DisplayPhotos4SHA(SHA);
                displayPhotos.ShowDialog();

                // reload the datagrid to display updates to ToDelete column
                LoadCheckSumDups();
            }
        }



        private static void DisplayException(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("An exception of type \"");
            sb.Append(ex.GetType().FullName);
            sb.Append("\" has occurred.\r\n");
            sb.Append(ex.Message);
            sb.Append("\r\nStack trace information:\r\n");
            MatchCollection matchCol = Regex.Matches(ex.StackTrace,@"(at\s)(.+)(\.)([^\.]*)(\()([^\)]*)(\))((\sin\s)(.+)(:line )([\d]*))?");
            int L = matchCol.Count;
            string[] argList;
            Match matchObj;
            int y, K;
            for (int x = 0; x < L; x++)
            {
                matchObj = matchCol[x];
                sb.Append(matchObj.Result("\r\n\r\n$1 $2$3$4$5"));
                argList = matchObj.Groups[6].Value.Split(new char[] { ',' });
                K = argList.Length;
                for (y = 0; y < K; y++)
                {
                    sb.Append("\r\n    ");
                    sb.Append(argList[y].Trim().Replace(" ", "        "));
                    sb.Append(',');
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("\r\n)");
                if (0 < matchObj.Groups[8].Length)
                {
                    sb.Append(matchObj.Result("\r\n$10\r\nline $12"));
                }
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
