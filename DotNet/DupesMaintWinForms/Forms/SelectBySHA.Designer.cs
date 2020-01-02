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
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sHADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toDeleteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkSumDupsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.popsDataSet = new DupesMaintWinForms.popsDataSet();
            this.checkSumDupsTableAdapter = new DupesMaintWinForms.popsDataSetTableAdapters.CheckSumDupsTableAdapter();
            this.btnTest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkSumDupsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popsDataSet)).BeginInit();
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
            this.dataGridView1.Size = new System.Drawing.Size(943, 345);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sHADataGridViewTextBoxColumn
            // 
            this.sHADataGridViewTextBoxColumn.DataPropertyName = "SHA";
            this.sHADataGridViewTextBoxColumn.HeaderText = "SHA";
            this.sHADataGridViewTextBoxColumn.MinimumWidth = 600;
            this.sHADataGridViewTextBoxColumn.Name = "sHADataGridViewTextBoxColumn";
            this.sHADataGridViewTextBoxColumn.ReadOnly = true;
            this.sHADataGridViewTextBoxColumn.Width = 600;
            // 
            // toDeleteDataGridViewTextBoxColumn
            // 
            this.toDeleteDataGridViewTextBoxColumn.DataPropertyName = "ToDelete";
            this.toDeleteDataGridViewTextBoxColumn.HeaderText = "To Delete";
            this.toDeleteDataGridViewTextBoxColumn.Name = "toDeleteDataGridViewTextBoxColumn";
            // 
            // checkSumDupsBindingSource
            // 
            this.checkSumDupsBindingSource.DataMember = "CheckSumDups";
            this.checkSumDupsBindingSource.DataSource = this.popsDataSet;
            // 
            // popsDataSet
            // 
            this.popsDataSet.DataSetName = "popsDataSet";
            this.popsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // checkSumDupsTableAdapter
            // 
            this.checkSumDupsTableAdapter.ClearBeforeFill = true;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(13, 31);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "btnTest";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // SelectBySHA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 450);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SelectBySHA";
            this.Text = "SelectBySHA";
            this.Load += new System.EventHandler(this.SelectBySHA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkSumDupsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popsDataSet)).EndInit();
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
        private System.Windows.Forms.Button btnTest;
    }
}

