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
        public CheckSum CheckSum1 { get; set; }

        public DisplayPhotos4SHA()
        {
            InitializeComponent();
        }

        // constructor called from form SelectBySHA passing in the CheckSum row for the selected SHA value
        public DisplayPhotos4SHA(CheckSum checkSum)
        {
            InitializeComponent();
            CheckSum1 = checkSum;
            LoadCheckSumPhoto();
        }

        // called from constructor to load the CheckSum photos for the selected SHA into picture boxes ?? how many
        private void LoadCheckSumPhoto()
        {
            // to-do: needs to process a collection of CheckSum rows
            // 
            // CheckSum row passed in constructor 
            // Note the escape character used (@) when specifying the path.  
            pictureBox1.Image = Image.FromFile(@CheckSum1.TheFileName);
        }


    }
}
