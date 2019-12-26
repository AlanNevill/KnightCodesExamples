using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // TODO: This line of code loads data into the 'popsDataSet.CheckSumDups' table. You can move, or remove it, as needed.
            this.checkSumDupsTableAdapter.Fill(this.popsDataSet.CheckSumDups);

        }
    }
}
