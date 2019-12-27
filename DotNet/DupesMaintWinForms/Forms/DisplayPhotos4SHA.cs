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
            var db = new PopsModel();

            // query the model for the CheckSum rows with the selected SHA string
            IQueryable<CheckSum> query = db.CheckSums.Where(checkSum => checkSum.SHA == SHA);

            // cast the query to an array of CheckSum rows
            var dupes = query.ToArray();

            this.toolStripStatusLabel.Text = $"{dupes.Length} duplicate photos - {SHA}";

            // Note the escape character used (@) when specifying the path.  
            pictureBox1.Image = Image.FromFile(@dupes[0].TheFileName);
            pictureBox2.Image = Image.FromFile(@dupes[1].TheFileName);

            tbPhoto1.Text = dupes[0].TheFileName;
            tbPhoto2.Text = dupes[1].TheFileName;

            dateTimePhoto1.Format = DateTimePickerFormat.Custom;
            dateTimePhoto2.Format = DateTimePickerFormat.Custom;
            dateTimePhoto1.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            dateTimePhoto2.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            dateTimePhoto1.Value = dupes[0].FileCreateDt;
            dateTimePhoto2.Value = dupes[1].FileCreateDt;

            this.cbPhoto1.Text = $"Delete {dupes[0].Id.ToString()}";
            this.cbPhoto2.Text = $"Delete {dupes[1].Id.ToString()}";
        }

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

    }
}
