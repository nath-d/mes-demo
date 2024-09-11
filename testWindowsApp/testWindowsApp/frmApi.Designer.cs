namespace testWindowsApp
{
    partial class frmApi
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
            btnFetch = new Button();
            txtData = new RichTextBox();
            dataGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            SuspendLayout();
            // 
            // btnFetch
            // 
            btnFetch.Location = new Point(334, 59);
            btnFetch.Name = "btnFetch";
            btnFetch.Size = new Size(94, 29);
            btnFetch.TabIndex = 0;
            btnFetch.Text = "Fetch";
            btnFetch.UseVisualStyleBackColor = true;
            btnFetch.Click += btnFetch_Click;
            // 
            // txtData
            // 
            txtData.Location = new Point(678, 20);
            txtData.Name = "txtData";
            txtData.Size = new Size(110, 92);
            txtData.TabIndex = 1;
            txtData.Text = "";
            // 
            // dataGrid
            // 
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.Location = new Point(128, 125);
            dataGrid.Name = "dataGrid";
            dataGrid.RowHeadersWidth = 51;
            dataGrid.Size = new Size(517, 278);
            dataGrid.TabIndex = 2;
            // 
            // frmApi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGrid);
            Controls.Add(txtData);
            Controls.Add(btnFetch);
            Name = "frmApi";
            Text = "frmApi";
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnFetch;
        private RichTextBox txtData;
        private DataGridView dataGrid;
    }
}