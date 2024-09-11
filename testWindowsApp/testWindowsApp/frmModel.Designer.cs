namespace testWindowsApp
{
    partial class frmModel
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
            label1 = new Label();
            modelInput = new TextBox();
            cmbBrand = new ComboBox();
            label2 = new Label();
            btnSave = new Button();
            btnReset = new Button();
            dataGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(42, 22);
            label1.Name = "label1";
            label1.Size = new Size(112, 37);
            label1.TabIndex = 0;
            label1.Text = "Models";
            // 
            // modelInput
            // 
            modelInput.Location = new Point(42, 128);
            modelInput.Name = "modelInput";
            modelInput.PlaceholderText = "Enter Model";
            modelInput.Size = new Size(317, 27);
            modelInput.TabIndex = 1;
            // 
            // cmbBrand
            // 
            cmbBrand.FormattingEnabled = true;
            cmbBrand.Location = new Point(42, 94);
            cmbBrand.Name = "cmbBrand";
            cmbBrand.Size = new Size(317, 28);
            cmbBrand.TabIndex = 2;
            cmbBrand.SelectedIndexChanged += cmbBrand_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(42, 68);
            label2.Name = "label2";
            label2.Size = new Size(111, 23);
            label2.TabIndex = 3;
            label2.Text = "Select Brand";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(42, 161);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.Orange;
            btnReset.Location = new Point(142, 161);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 5;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click_1;
            // 
            // dataGrid
            // 
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.Location = new Point(42, 215);
            dataGrid.Name = "dataGrid";
            dataGrid.RowHeadersWidth = 51;
            dataGrid.Size = new Size(317, 354);
            dataGrid.TabIndex = 6;
            dataGrid.SelectionChanged += dataGrid_SelectionChanged;
            // 
            // frmModel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 598);
            Controls.Add(btnReset);
            Controls.Add(dataGrid);
            Controls.Add(btnSave);
            Controls.Add(label2);
            Controls.Add(cmbBrand);
            Controls.Add(modelInput);
            Controls.Add(label1);
            Name = "frmModel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Model Master";
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox modelInput;
        private ComboBox cmbBrand;
        private Label label2;
        private Button btnSave;
        private Button btnReset;
        private DataGridView dataGrid;
    }
}