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

        // constructor called from form SelectBySHA passing in the CheckSum row for the selected SHA value
        public DisplayPhotos4SHA(popsDataSet.CheckSumDataTable dupes)
        {
            InitializeComponent();
            _dupes = dupes;
            LoadCheckSumPhoto();
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
