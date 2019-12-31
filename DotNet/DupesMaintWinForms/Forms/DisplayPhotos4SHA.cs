using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace DupesMaintWinForms
{
    public partial class DisplayPhotos4SHA : Form
    {
        public popsDataSet.CheckSumDataTable _dupes { get; set; }

        public PopsModel popsModel { get; set; }
        public CheckSum[] checkSums { get; set; }
        public CheckSum Photo1 { get; set; }
        public CheckSum Photo2 { get; set; }
        public CheckSumDup[] checkSumDups { get; set; }
        public CheckSumDup checkSumDup1 { get; set; }
        public CheckSumDup checkSumDup2 { get; set; }

        public DisplayPhotos4SHA()
        {
            InitializeComponent();
        }

        // constructor called from form SelectBySHA passing in the CheckSum rows for the selected SHA value
        public DisplayPhotos4SHA(popsDataSet.CheckSumDataTable dupes)
        {
            InitializeComponent();
            _dupes = dupes;
            LoadCheckSumPhoto();
        }


        // constructor called by form SelectbySHA passing in the SHA string of the selected duplicates
        public DisplayPhotos4SHA(string SHA)
        {
            InitializeComponent();

            // instantiate the EF model PopsModel
            popsModel = new PopsModel();

            // query the model for the CheckSum rows with the selected SHA string
            IQueryable<CheckSum> query = popsModel.CheckSums.Where(checkSum => checkSum.SHA == SHA)
                                                            .OrderBy(x => x.Id);

            // cast the query to an array of CheckSum rows
            checkSums = query.ToArray();
            Photo1 = checkSums[0];
            Photo2 = checkSums[1];

            // get the CheckSumDup rows from the db for the 2 photos
            IQueryable<CheckSumDup> query2 = popsModel.CheckSumDups.Where(a => a.Id == Photo1.Id || a.Id == Photo2.Id)
                                                                   .OrderBy(b => b.Id);
            this.checkSumDups = query2.ToArray();
            this.checkSumDup1 = checkSumDups[0];
            this.checkSumDup2 = checkSumDups[1];

            this.toolStripStatusLabel.Text = $"{checkSums.Length} duplicate photos - {SHA}";

            // Note the escape character used (@) when specifying the path.  
            pictureBox1.Image = Image.FromFile(Photo1.TheFileName);
            pictureBox2.Image = Image.FromFile(Photo2.TheFileName);

            tbPhoto1.Text = Photo1.TheFileName;
            tbPhoto2.Text = Photo2.TheFileName;

            dateTimePhoto1.Format = DateTimePickerFormat.Custom;
            dateTimePhoto2.Format = DateTimePickerFormat.Custom;
            dateTimePhoto1.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            dateTimePhoto2.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            dateTimePhoto1.Value = Photo1.FileCreateDt;
            dateTimePhoto2.Value = Photo2.FileCreateDt;

            this.cbPhoto1.Text = $"Delete Id {Photo1.Id.ToString()}";
            this.cbPhoto2.Text = $"Delete Id {Photo2.Id.ToString()}";

            if (checkSumDup1.ToDelete.Equals("Y")) this.cbPhoto1.Checked = true;
            if (checkSumDup2.ToDelete.Equals("Y")) this.cbPhoto2.Checked = true;

        }

        // no longer used
        // called from constructor to load the CheckSum photos for the selected SHA into picture boxes ?? how many
        private void LoadCheckSumPhoto()
        {
            popsDataSet.CheckSumRow photo1 = (popsDataSet.CheckSumRow)_dupes.Rows[0];
            popsDataSet.CheckSumRow photo2 = (popsDataSet.CheckSumRow)_dupes.Rows[1];

            // Note the escape character used (@) when specifying the path.  
            pictureBox1.Image = Image.FromFile(@photo1.TheFileName);
            pictureBox2.Image = Image.FromFile(@photo2.TheFileName);

            tbPhoto1.Text = photo1.TheFileName;
            tbPhoto2.Text = photo2.TheFileName;

            dateTimePhoto1.Format = DateTimePickerFormat.Custom;
            dateTimePhoto2.Format = DateTimePickerFormat.Custom;
            dateTimePhoto1.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            dateTimePhoto2.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            dateTimePhoto1.Value = photo1.FileCreateDt;
            dateTimePhoto2.Value = photo2.FileCreateDt;



        }

        private void cbPhoto1_CheckedChanged(object sender, EventArgs e)
        {
            if (PreventBothChecked())
            {
                this.cbPhoto1.Checked = false;
                this.toolStripStatusLabel.Text = "Photo2 is already checked. Uncheck Photo2 in order to check Photo1";
                return;
            }

            if (!this.cbPhoto1.Checked && checkSumDup1.ToDelete.Equals("Y")) 
            {
                this.toolStripStatusLabel.Text = $"{checkSumDup1.Id} ToDelete=N.";

                checkSumDup1.ToDelete = "N";
                popsModel.SaveChanges();

                return;
            }

            if (this.cbPhoto1.Checked && checkSumDup1.ToDelete.Equals("N"))
            {
                this.toolStripStatusLabel.Text = $"{checkSumDup1.Id} ToDelete=Y.";

                checkSumDup1.ToDelete = "Y";
                popsModel.SaveChanges();

                return;
            }

        }

        private void cbPhoto2_CheckedChanged(object sender, EventArgs e)
        {
            if (PreventBothChecked())
            {
                this.cbPhoto2.Checked = false;
                this.toolStripStatusLabel.Text = "Photo1 is already checked. Uncheck Photo1 in order to check Photo2";
                return;
            }

            if (!this.cbPhoto2.Checked && checkSumDup2.ToDelete.Equals("Y"))
            {
                this.toolStripStatusLabel.Text = $"{checkSumDup2.Id} ToDelete=N.";

                checkSumDup2.ToDelete = "N";
                popsModel.SaveChanges();

                return;
            }

            if (this.cbPhoto2.Checked && checkSumDup2.ToDelete.Equals("N"))
            {
                this.toolStripStatusLabel.Text = $"{checkSumDup2.Id} ToDelete=Y.";

                checkSumDup2.ToDelete = "Y";
                popsModel.SaveChanges();

                return;
            }
        }

        private bool PreventBothChecked()
        {
            if (this.cbPhoto1.Checked && this.cbPhoto2.Checked)
            {
                return true;
            }
            return false;
        }
    }
}
