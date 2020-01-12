using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DupesMaintWinForms
{
    public partial class SelectBySHA : Form
    {

        public SelectBySHA()
        {
            InitializeComponent();
        }

        private void SelectBySHA_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = true;

            Program.popsModel.CheckSumDups.Load();

            // use ToBindingList() so that the DbContext keeps track of table updates and then datagridview refresh will reflect the deletes made in the form DisplayPhotos4SHA
            this.checkSumDupsBindingSource.DataSource = Program.popsModel.CheckSumDups.Local.ToBindingList();

            // sort the datagridview by SHA
            this.dataGridView1.Sort(this.dataGridView1.Columns[1], ListSortDirection.Ascending);

            // auto column width
            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns["SHA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns["ToDelete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.toolStripStatusLabel1.Text = $"{this.dataGridView1.RowCount} CheckSumDups rows loaded.";
        }



        // 
        private void btnTest_Click(object sender, EventArgs e)
        {

        }




        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                // get the SHA value from the selected grid row
                string SHA = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                // call DisplayPhotos4SHA passing in the SHA of the selected duplicates
                Form displayPhotos4SHA = new DisplayPhotos4SHA(SHA);
                
                if (!displayPhotos4SHA.IsDisposed)
                {
                    displayPhotos4SHA.ShowDialog();
                }

                // refresh the datagrid
                this.dataGridView1.Refresh();
            }
        }


        private void menuFile_Click(object sender, EventArgs e)
        {
            Form frmdDupesAction = new Forms.frmDupesAction();
            frmdDupesAction.ShowDialog();
        }
    }
}
