namespace DupesMaintWinForms
{
    partial class DisplayPhotos4SHA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tbPhoto1 = new System.Windows.Forms.TextBox();
            this.tbPhoto2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePhoto1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePhoto2 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(98, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(267, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(388, 54);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(267, 250);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // tbPhoto1
            // 
            this.tbPhoto1.Font = new System.Drawing.Font("Source Code Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPhoto1.Location = new System.Drawing.Point(98, 325);
            this.tbPhoto1.Multiline = true;
            this.tbPhoto1.Name = "tbPhoto1";
            this.tbPhoto1.Size = new System.Drawing.Size(267, 31);
            this.tbPhoto1.TabIndex = 2;
            // 
            // tbPhoto2
            // 
            this.tbPhoto2.Font = new System.Drawing.Font("Source Code Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPhoto2.Location = new System.Drawing.Point(388, 325);
            this.tbPhoto2.Multiline = true;
            this.tbPhoto2.Name = "tbPhoto2";
            this.tbPhoto2.Size = new System.Drawing.Size(267, 31);
            this.tbPhoto2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Full file name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 384);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Creation date";
            // 
            // dateTimePhoto1
            // 
            this.dateTimePhoto1.Enabled = false;
            this.dateTimePhoto1.Location = new System.Drawing.Point(98, 378);
            this.dateTimePhoto1.Name = "dateTimePhoto1";
            this.dateTimePhoto1.Size = new System.Drawing.Size(267, 20);
            this.dateTimePhoto1.TabIndex = 6;
            // 
            // dateTimePhoto2
            // 
            this.dateTimePhoto2.Enabled = false;
            this.dateTimePhoto2.Location = new System.Drawing.Point(388, 378);
            this.dateTimePhoto2.Name = "dateTimePhoto2";
            this.dateTimePhoto2.Size = new System.Drawing.Size(267, 20);
            this.dateTimePhoto2.TabIndex = 7;
            // 
            // DisplayPhotos4SHA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 450);
            this.Controls.Add(this.dateTimePhoto2);
            this.Controls.Add(this.dateTimePhoto1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPhoto2);
            this.Controls.Add(this.tbPhoto1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "DisplayPhotos4SHA";
            this.Text = "DisplayPhotos4SHA";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox tbPhoto1;
        private System.Windows.Forms.TextBox tbPhoto2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePhoto1;
        private System.Windows.Forms.DateTimePicker dateTimePhoto2;
    }
}