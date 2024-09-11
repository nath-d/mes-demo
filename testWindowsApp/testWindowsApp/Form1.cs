using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace testWindowsApp
{
    public partial class frmInput : Form
    {
        string connStr;
        public frmInput()
        {
            InitializeComponent();
            connStr = sqlConnectionStrings.FDbString("data");

            fillBrand();
        }
        void fillBrand()
        {
            try
            {
                string query = "select distinct BrandId, BrandName from dbo.Brand order by BrandId ASC";
                SqlConnection conn = new SqlConnection(connStr);
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                conn.Open();

                DataSet ds = new DataSet();
                da.Fill(ds, "BrandName");
                cmbBrand.DisplayMember = "BrandName";
                cmbBrand.ValueMember = "BrandId";
                cmbBrand.DataSource = ds.Tables["BrandName"];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured in Brands!");
            }
            cmbModel.Enabled = (cmbBrand.Items.Count > 0);
        }

        private void fillModel(int brandId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_getModelByBrand", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BrandId", brandId);
                        conn.Open();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "ModelName");

                        cmbModel.DisplayMember = "ModelName";
                        cmbModel.ValueMember = "ModelId";
                        cmbModel.DataSource = ds.Tables["ModelName"];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while loading models: " + ex.Message);
            }

            txtInput.Enabled = (cmbModel.Items.Count > 0);
            txtInput.Focus();
        }


        void UpdateSerialNumber(int brandId, int modelId, string serialNumber)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("sp_insertSerialByModel", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Model", modelId);
                    cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        InsertSerial();
                        MessageBox.Show("Serial number inserted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update the serial number.");
                    }
                }
                FetchAndBindData(modelId);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Serial Number already Exists");
            }
        }



        private void FetchAndBindData(int modelName)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("sp_getSerialByModel", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ModelName", SqlDbType.VarChar, 255).Value = modelName;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGrid.DataSource = dt;

                    dataGrid.AutoResizeColumns();
                    dataGrid.Columns["BrandName"].HeaderText = "Brand";
                    dataGrid.Columns["ModelName"].HeaderText = "Model";
                    dataGrid.Columns["SerialNumber"].HeaderText = "Serial Number";
                    //dataGrid.Columns["createdDate"].Visible = false;
                    dataGrid.Columns["createdDate"].HeaderText = "Created Date";
                    //if (dt.Rows.Count > 0)
                    //{
                    //    MessageBox.Show($"Fetched {dt.Rows.Count} rows.");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("No data found.");
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message);
            }
        }



        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbModel.SelectedItem != null)
            {
                int selectedModelName = Convert.ToInt32(cmbModel.SelectedValue);
                FetchAndBindData(selectedModelName);
                txtInput.Clear();
            }
        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBrand.SelectedValue != null)
            {
                int selectedBrandId = Convert.ToInt32(cmbBrand.SelectedValue);
                fillModel(selectedBrandId);
                txtInput.Clear();
            }
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                FetchAndBindData(Convert.ToInt32(cmbModel.SelectedValue));

                if (cmbBrand.SelectedValue != null && cmbModel.SelectedValue != null && !string.IsNullOrEmpty(txtInput.Text))
                {
                    try
                    {
                        int selectedBrandId = Convert.ToInt32(cmbBrand.SelectedValue);
                        int selectedModelId = Convert.ToInt32(cmbModel.SelectedValue);
                        string serialNumber = txtInput.Text;

                        UpdateSerialNumber(selectedBrandId, selectedModelId, serialNumber);
                    }
                    catch (InvalidCastException ex)
                    {
                        MessageBox.Show("Invalid selection. Please ensure that a valid brand and model are selected.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a serial number.");
                }

            }
        }

        private void mnuQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quit Application?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtInput.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtInput.Copy();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtInput.CanUndo == true)
            {

                txtInput.Undo();
                txtInput.ClearUndo();

            }
        }

        

        private void frmInput_Click(object sender, EventArgs e)
        {
            fillBrand();
        }
        private void InsertSerial()
        {
            frmMaster masterForm = (frmMaster)this.MdiParent;
            masterForm.UpdateStatusLabel("Serial Number Added");
        }
    }
}
