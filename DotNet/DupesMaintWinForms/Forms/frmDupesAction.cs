using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DupesMaintWinForms.Forms
{
    public partial class frmDupesAction : Form
    {
        private DupesAction[] dupesActions { get; set; }
        private string theFileName;

        public frmDupesAction()
        {
            InitializeComponent();
        }


        private void frmDupesAction_Load(object sender, EventArgs e)
        {
            this.dataGridView.AutoGenerateColumns = true;
            this.dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Program.popsModel.DupesActions.Load();
            this.popsDataSetBindingSource.DataSource = Program.popsModel.DupesActions.Local.ToBindingList();

            // hide some columns
            this.dataGridView.Columns[1].Visible = false;
            this.dataGridView.Columns[2].Visible = false;
            this.dataGridView.Columns["FileExt"].Visible = false;

            // auto column width
            this.dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView.Columns["GooglePhotosRemoved"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }


        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView.SelectedRows.Count > 0)
            {
                // get the TheFilename from the selected grid row
                theFileName = dataGridView.SelectedRows[0].Cells[0].Value.ToString();

                string dupesPhotoPath = theFileName.Replace("C:\\", Program.targetRootFolder);

                FileInfo fileInfo = new FileInfo(dupesPhotoPath);
                if (fileInfo.Exists)
                {
                    this.pictureBox.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(dupesPhotoPath)));
                } else
                {
                    this.statusStrip1.Text = $"ERROR - File not found {dupesPhotoPath}";
                }

            }

        }

        private void btnBinned_Click(object sender, EventArgs e)
        {
            if (this.dataGridView.SelectedRows.Count > 0)
            {
                IQueryable<DupesAction> query = Program.popsModel.DupesActions.Where(dupesAction => dupesAction.TheFileName == theFileName);

                dupesActions = query.ToArray();

                if (dupesActions.Length == 1)
                {
                    DupesAction adupesAction = dupesActions[0];
                    adupesAction.GooglePhotosRemoved = "Y";
                    Program.popsModel.SaveChanges();

                    // refresh the view
                    this.dataGridView.Refresh();
                }
                else
                {
                    this.statusStrip1.Text = $"ERROR - DupesAction row {theFileName} was not updated. dupesActions.Length == {dupesActions.Length}";
                }

            }
        }

    }
}
