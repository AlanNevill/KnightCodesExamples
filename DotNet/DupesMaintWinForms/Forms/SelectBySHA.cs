using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DupesMaintWinForms
{
    public partial class SelectBySHA : Form
    {
        private static MyDbConnect MyDb;

        public SelectBySHA()
        {
            InitializeComponent();
        }

        private void SelectBySHA_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'popsDataSet.CheckSumDups' table. You can move, or remove it, as needed.
            this.checkSumDupsTableAdapter.Fill(this.popsDataSet.CheckSumDups);

            MyDb = new MyDbConnect(@"Server = (localDB)\MSSQLLocalDB; Integrated Security = true; database = pops");
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            // call DisplayPhotos4SHA passing in the SHA of the selected duplicates
            Form displayPhotos = new DisplayPhotos4SHA("A3-DD-FC-2F-05-CB-77-C7-87-81-05-F8-8D-C7-23-BE-91-6C-76-B8-6F-0F-3F-61-49-A4-72-3F-9E-E3-B8-72");
            displayPhotos.ShowDialog();

            // get the CheckSum rows for a specific SHA value
            //CheckSum4SelectedSHA(@"A3-DD-FC-2F-05-CB-77-C7-87-81-05-F8-8D-C7-23-BE-91-6C-76-B8-6F-0F-3F-61-49-A4-72-3F-9E-E3-B8-72");
        }


        // no longer used
        private void CheckSum4SelectedSHA(string sha)
        {
            popsDataSet _popsDataSet = new popsDataSet();
            var da = new SqlDataAdapter($"select * from CheckSum where SHA = '{sha}'", MyDb.Cn);
            da.Fill(_popsDataSet.CheckSum);

            popsDataSet.CheckSumDataTable dupes = _popsDataSet.CheckSum;

            Form displayPhotos = new DisplayPhotos4SHA(dupes);
            displayPhotos.ShowDialog();
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

            }
        }
    }
}
