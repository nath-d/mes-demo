using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace testWindowsApp
{
    public partial class frmBrand : Form
    {
        string connStr;

        public frmBrand()
        {
            InitializeComponent();
            connStr = sqlConnectionStrings.FDbString("data");

            getBrand();
            btnSave.Enabled = false; 
            brandInput.TextChanged += brandInput_TextChanged;
            
        }

        private void getBrand()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Brand order by BrandId ASC", conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGrid.DataSource = dt;
                    dataGrid.AutoResizeColumns();
                    dataGrid.Columns["BrandName"].HeaderText = "Brand";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message);
            }
        }

        private void brandInput_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = !string.IsNullOrEmpty(brandInput.Text);

            if (dataGrid.SelectedRows.Count == 1)
            {
                var row = dataGrid.SelectedRows[0];
                row.Cells["BrandName"].Value = brandInput.Text;
            }
        }

        private void dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count > 0)
            {
                
                btnSave.Text = "Update";
                var row = dataGrid.SelectedRows[0];
                brandInput.Text = row.Cells["BrandName"].Value.ToString();
            }
            else
            {
                btnSave.Text = "Save"; 
                brandInput.Clear(); 
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                foreach (var c in this.Controls)
                {
                    MessageBox.Show(c.GetType().ToString());
                }
                createBrand();  
            }
            else if (btnSave.Text == "Update")
            {
                updateBrand();  
            }
            getBrand();  
            dataGrid.Show();
        }

        private void createBrand()
        {
            string brandName = brandInput.Text;

            if (!string.IsNullOrEmpty(brandName))
            {
                try
                {
                    string query = "INSERT INTO Brand(BrandName) VALUES (@BrandName);";
                    using (SqlConnection conn = new SqlConnection(connStr))
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BrandName", brandName);

                        conn.Open();
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            SaveBrand();
                            MessageBox.Show("Brand inserted successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Failed to insert brand.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Brand already Exists!!! ");
                }
            }
            else
            {
                MessageBox.Show("Brand name cannot be empty.");
            }
        }

        private void updateBrand()
        {
            if (dataGrid.SelectedRows.Count == 1)
            {
                var row = dataGrid.SelectedRows[0];
                string brandName = brandInput.Text;
                int brandId = Convert.ToInt32(row.Cells["BrandId"].Value);

                try
                {
                    string query = "UPDATE Brand SET BrandName = @BrandName WHERE BrandId = @BrandId";
                    using (SqlConnection conn = new SqlConnection(connStr))
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BrandName", brandName);
                        cmd.Parameters.AddWithValue("@BrandId", brandId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    UpdateBrand();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Brand already Exists!!! ");
                }
            }
        }

        
        private void btnReset_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Save";  
            brandInput.Clear();     
            dataGrid.ClearSelection();  
            btnSave.Enabled = false; 
        }

        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            getBrand();  
        }
        private void SaveBrand()
        {
            frmMaster masterForm = (frmMaster)this.MdiParent;
            masterForm.UpdateStatusLabel("Brand saved");
        }
        private void UpdateBrand()
        {
            frmMaster masterForm = (frmMaster)this.MdiParent;
            masterForm.UpdateStatusLabel("Brand Updated");
        }
    }
}
