namespace testWindowsApp
{
    partial class frmInput
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGrid = new DataGridView();
            groupBox2 = new GroupBox();
            txtInput = new TextBox();
            label3 = new Label();
            cmbModel = new ComboBox();
            label2 = new Label();
            cmbBrand = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGrid
            // 
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.Location = new Point(0, 160);
            dataGrid.Name = "dataGrid";
            dataGrid.RowHeadersWidth = 51;
            dataGrid.Size = new Size(687, 360);
            dataGrid.TabIndex = 11;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.AntiqueWhite;
            groupBox2.Controls.Add(txtInput);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(cmbModel);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(cmbBrand);
            groupBox2.Controls.Add(label1);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(0, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(687, 152);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Input";
            // 
            // txtInput
            // 
            txtInput.Location = new Point(124, 91);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(536, 27);
            txtInput.TabIndex = 15;
            txtInput.KeyPress += txtInput_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 98);
            label3.Name = "label3";
            label3.Size = new Size(114, 20);
            label3.TabIndex = 14;
            label3.Text = "Serial Number:";
            // 
            // cmbModel
            // 
            cmbModel.FormattingEnabled = true;
            cmbModel.Location = new Point(453, 42);
            cmbModel.Name = "cmbModel";
            cmbModel.Size = new Size(207, 28);
            cmbModel.TabIndex = 11;
            cmbModel.SelectedIndexChanged += cmbModel_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(345, 45);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 13;
            label2.Text = "Select Model:";
            // 
            // cmbBrand
            // 
            cmbBrand.Cursor = Cursors.Hand;
            cmbBrand.FormattingEnabled = true;
            cmbBrand.Location = new Point(124, 42);
            cmbBrand.Name = "cmbBrand";
            cmbBrand.Size = new Size(209, 28);
            cmbBrand.TabIndex = 10;
            cmbBrand.SelectedIndexChanged += cmbBrand_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 45);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 12;
            label1.Text = "Select Brand: ";
            // 
            // frmInput
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(687, 521);
            Controls.Add(dataGrid);
            Controls.Add(groupBox2);
            Name = "frmInput";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Input form";
            Click += frmInput_Click;
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox2;
        private ComboBox cmbModel;
        private Label label2;
        private ComboBox cmbBrand;
        private Label label1;
        private DataGridView dataGrid;
        private TextBox txtInput;
        private Label label3;
    }
}
