namespace DupesMaintWinForms
{
    partial class SelectBySHA
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.popsDataSet = new DupesMaintWinForms.popsDataSet();
            this.checkSumDupsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkSumDupsTableAdapter = new DupesMaintWinForms.popsDataSetTableAdapters.CheckSumDupsTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sHADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toDeleteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkSumDupsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.sHADataGridViewTextBoxColumn,
            this.toDeleteDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.checkSumDupsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(943, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // popsDataSet
            // 
            this.popsDataSet.DataSetName = "popsDataSet";
            this.popsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // checkSumDupsBindingSource
            // 
            this.checkSumDupsBindingSource.DataMember = "CheckSumDups";
            this.checkSumDupsBindingSource.DataSource = this.popsDataSet;
            // 
            // checkSumDupsTableAdapter
            // 
            this.checkSumDupsTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // sHADataGridViewTextBoxColumn
            // 
            this.sHADataGridViewTextBoxColumn.DataPropertyName = "SHA";
            this.sHADataGridViewTextBoxColumn.HeaderText = "SHA";
            this.sHADataGridViewTextBoxColumn.Name = "sHADataGridViewTextBoxColumn";
            // 
            // toDeleteDataGridViewTextBoxColumn
            // 
            this.toDeleteDataGridViewTextBoxColumn.DataPropertyName = "ToDelete";
            this.toDeleteDataGridViewTextBoxColumn.HeaderText = "ToDelete";
            this.toDeleteDataGridViewTextBoxColumn.Name = "toDeleteDataGridViewTextBoxColumn";
            // 
            // SelectBySHA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SelectBySHA";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SelectBySHA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkSumDupsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private popsDataSet popsDataSet;
        private System.Windows.Forms.BindingSource checkSumDupsBindingSource;
        private popsDataSetTableAdapters.CheckSumDupsTableAdapter checkSumDupsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sHADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toDeleteDataGridViewTextBoxColumn;
    }
}

