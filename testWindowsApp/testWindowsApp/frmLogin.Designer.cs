namespace testWindowsApp
{
    partial class frmLogin
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
            label2 = new Label();
            label3 = new Label();
            userInput = new TextBox();
            passInput = new TextBox();
            loginBox = new GroupBox();
            loginBox.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(221, 23);
            label1.Name = "label1";
            label1.Size = new Size(124, 46);
            label1.TabIndex = 0;
            label1.Text = "LOGIN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(78, 113);
            label2.Name = "label2";
            label2.Size = new Size(111, 28);
            label2.TabIndex = 1;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(83, 177);
            label3.Name = "label3";
            label3.Size = new Size(106, 28);
            label3.TabIndex = 2;
            label3.Text = "Password:";
            // 
            // userInput
            // 
            userInput.Location = new Point(195, 113);
            userInput.Name = "userInput";
            userInput.Size = new Size(226, 34);
            userInput.TabIndex = 3;
            // 
            // passInput
            // 
            passInput.Location = new Point(195, 171);
            passInput.Name = "passInput";
            passInput.PasswordChar = '*';
            passInput.Size = new Size(226, 34);
            passInput.TabIndex = 4;
            passInput.KeyPress += passInput_KeyPress;
            // 
            // loginBox
            // 
            loginBox.BackColor = Color.Lavender;
            loginBox.Controls.Add(passInput);
            loginBox.Controls.Add(userInput);
            loginBox.Controls.Add(label3);
            loginBox.Controls.Add(label2);
            loginBox.Controls.Add(label1);
            loginBox.Font = new Font("Segoe UI", 12F);
            loginBox.Location = new Point(-1, 1);
            loginBox.Name = "loginBox";
            loginBox.Size = new Size(598, 311);
            loginBox.TabIndex = 0;
            loginBox.TabStop = false;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(596, 312);
            Controls.Add(loginBox);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmLogin";
            loginBox.ResumeLayout(false);
            loginBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox userInput;
        private TextBox passInput;
        private GroupBox loginBox;
    }
}