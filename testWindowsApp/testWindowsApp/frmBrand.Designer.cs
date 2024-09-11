namespace testWindowsApp
{
    partial class frmBrand
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
            dataGrid = new DataGridView();
            label1 = new Label();
            brandInput = new TextBox();
            btnSave = new Button();
            btnReset = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            SuspendLayout();
            // 
            // dataGrid
            // 
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.Location = new Point(22, 135);
            dataGrid.Name = "dataGrid";
            dataGrid.RowHeadersWidth = 51;
            dataGrid.Size = new Size(341, 358);
            dataGrid.TabIndex = 0;
            dataGrid.SelectionChanged += dataGrid_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(22, 21);
            label1.Name = "label1";
            label1.Size = new Size(105, 37);
            label1.TabIndex = 1;
            label1.Text = "Brands";
            // 
            // brandInput
            // 
            brandInput.Location = new Point(22, 64);
            brandInput.Name = "brandInput";
            brandInput.PlaceholderText = "Enter Brand";
            brandInput.Size = new Size(341, 27);
            brandInput.TabIndex = 2;
            brandInput.TextChanged += brandInput_TextChanged;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(22, 97);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.Orange;
            btnReset.Location = new Point(122, 97);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 4;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // frmBrand
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(386, 517);
            Controls.Add(btnReset);
            Controls.Add(btnSave);
            Controls.Add(brandInput);
            Controls.Add(label1);
            Controls.Add(dataGrid);
            Name = "frmBrand";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Brand Master";
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGrid;
        private Label label1;
        private TextBox brandInput;
        private Button btnSave;
        private Button btnReset;
    }
}