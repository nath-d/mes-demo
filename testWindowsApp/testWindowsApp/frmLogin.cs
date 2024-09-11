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
    public partial class frmLogin : Form
    {
        string connStr;

        public frmLogin()
        {
            InitializeComponent();
            connStr = sqlConnectionStrings.FDbString("user");
        }
        bool CheckAuth(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_userLogin", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        conn.Open();
                        int userCount = (int)cmd.ExecuteScalar();
                        return userCount == 1;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        private void passInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

                if (!string.IsNullOrEmpty(userInput.Text) && !string.IsNullOrEmpty(passInput.Text))
                {
                    string username = userInput.Text;
                    string password = passInput.Text;
                    if (CheckAuth(username, password))
                    {
                        MessageBox.Show("Login successful!");
                        frmMaster frmMst = new frmMaster();

                        frmMst.LoggedInUser = username;
                        this.Hide();
                        frmMst.Show();

                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter details.");
                }

            }
        }

    }
}
