using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testWindowsApp
{
    public partial class frmMaster : Form
    {
        string connStr;
        Form inputForm = new frmInput();
        Form brandForm = new frmBrand();
        private ToolStripMenuItem brandsToolStripMenuItem;
        private ToolStripMenuItem modelsToolStripMenuItem;
        private ToolStripMenuItem serialNumberToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;
        Form modelForm = new frmModel();
        public string LoggedInUser { get; set; }

        public frmMaster()
        {
            InitializeComponent();
            connStr = sqlConnectionStrings.FDbString("data");
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.White;


        }

        private MenuStrip menuStrip1;

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            brandsToolStripMenuItem = new ToolStripMenuItem();
            modelsToolStripMenuItem = new ToolStripMenuItem();
            serialNumberToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1112, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { brandsToolStripMenuItem, modelsToolStripMenuItem, serialNumberToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "&File";
            // 
            // brandsToolStripMenuItem
            // 
            brandsToolStripMenuItem.Name = "brandsToolStripMenuItem";
            brandsToolStripMenuItem.Size = new Size(187, 26);
            brandsToolStripMenuItem.Text = "&Brands";
            brandsToolStripMenuItem.Click += brandsToolStripMenuItem_Click;
            // 
            // modelsToolStripMenuItem
            // 
            modelsToolStripMenuItem.Name = "modelsToolStripMenuItem";
            modelsToolStripMenuItem.Size = new Size(187, 26);
            modelsToolStripMenuItem.Text = "&Models";
            modelsToolStripMenuItem.Click += modelsToolStripMenuItem_Click;
            // 
            // serialNumberToolStripMenuItem
            // 
            serialNumberToolStripMenuItem.Name = "serialNumberToolStripMenuItem";
            serialNumberToolStripMenuItem.Size = new Size(187, 26);
            serialNumberToolStripMenuItem.Text = "&Serial Number";
            serialNumberToolStripMenuItem.Click += serialNumberToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(49, 24);
            editToolStripMenuItem.Text = "Edit";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip1.Location = new Point(0, 611);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1112, 26);
            statusStrip1.TabIndex = 9;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(49, 20);
            statusLabel.Text = "Status";
            // 
            // frmMaster
            // 
            ClientSize = new Size(1112, 637);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "frmMaster";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Master Form";
            WindowState = FormWindowState.Maximized;
            FormClosing += frmMaster_FormClosing;
            Load += frmMaster_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputForm.Close();
        }


        private void frmMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }

            Application.Exit();
        }

        private void brandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (brandForm == null || brandForm.IsDisposed)
            {
                brandForm = new frmBrand();

            }
            brandForm.MdiParent = this;
            brandForm.Show();
        }

        private void modelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modelForm == null || modelForm.IsDisposed)
            {
                modelForm = new frmModel();

            }
            modelForm.MdiParent = this;
            modelForm.Show();
        }

        private void serialNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputForm == null || inputForm.IsDisposed)
            {
                inputForm = new frmInput();
            }
            inputForm.MdiParent = this;

            inputForm.Show();
        }

        public void UpdateStatusLabel(string message)
        {
            statusLabel.Text = message;
        }

        private void frmMaster_Load(object sender, EventArgs e)
        {
            statusLabel.Text = $"Logged in as: {LoggedInUser}";

        }
    }
}