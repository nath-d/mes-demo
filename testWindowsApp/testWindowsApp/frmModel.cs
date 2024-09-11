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
    public partial class frmModel : Form
    {
        string connStr;

        public frmModel()
        {
            InitializeComponent();
            connStr = sqlConnectionStrings.FDbString("data");

            fillBrand();
            btnSave.Enabled = false;
            modelInput.TextChanged += modelInput_TextChanged;


        }
        void fillBrand()
        {
            try
            {
                string query = "select distinct BrandId, BrandName from dbo.Brand";
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
        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBrand.SelectedValue != null)
            {
                int selectedBrandId = Convert.ToInt32(cmbBrand.SelectedValue);
                getModel(selectedBrandId);
            }
        }

        void createModel(int brandId, string model)
        {
            try
            {
                string query = "insert into Model(BrandId, ModelName) values (@BrandId, @ModelName);";
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BrandId", brandId);
                    cmd.Parameters.AddWithValue("@ModelName", model);


                    conn.Open();
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Model inserted successfully!");
                        getModel(brandId);
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert Model.");
                    }
                }
                fillBrand();
                InsertModel();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Model already Exists!!! ");

            }
        }

        private void updateModel()
        {
            if (dataGrid.SelectedRows.Count == 1)
            {
                var row = dataGrid.SelectedRows[0];

                if (row.Cells["ModelId"].Value != null && int.TryParse(row.Cells["ModelId"].Value.ToString(), out int modelId))
                {
                    string modelName = modelInput.Text;
                    int selectedBrandId = Convert.ToInt32(cmbBrand.SelectedValue);

                    try
                    {
                        string query = "UPDATE Model SET ModelName = @ModelName WHERE ModelId = @ModelId";
                        using (SqlConnection conn = new SqlConnection(connStr))
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ModelName", modelName);
                            cmd.Parameters.AddWithValue("@ModelId", modelId);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                        UpdateModel();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Model already Exists!!! ");

                    }
                }
                else
                {
                    MessageBox.Show("Invalid or missing ModelId.");
                }
            }
        }


        private void modelInput_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = !string.IsNullOrEmpty(modelInput.Text);

            if (dataGrid.SelectedRows.Count == 1)
            {
                var row = dataGrid.SelectedRows[0];
                row.Cells["ModelName"].Value = modelInput.Text;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (cmbBrand.SelectedValue != null)
            {
                if (int.TryParse(cmbBrand.SelectedValue.ToString(), out int selectedBrandId))
                {
                    if (btnSave.Text == "Save")
                    {
                        createModel(selectedBrandId, modelInput.Text);
                    }
                    else if (btnSave.Text == "Update")
                    {
                        updateModel();
                    }
                    cmbBrand.SelectedValue = selectedBrandId;
                    getModel(selectedBrandId);
                    dataGrid.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Brand selected. Please select a valid brand.");
                }
            }
            else
            {
                MessageBox.Show("Please select a brand.");
            }
        }
        private void getModel(int brandid)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("SELECT Model.ModelId, Model.ModelName FROM Model WHERE BrandId = @BrandId", conn))
                {
                    cmd.Parameters.AddWithValue("@BrandId", brandid);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGrid.DataSource = dt;
                    dataGrid.AutoResizeColumns();
                    dataGrid.Columns["ModelId"].HeaderText = "ModelId";
                    dataGrid.Columns["ModelName"].HeaderText = "ModelName";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message);
            }
        }

        private void dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count > 0)
            {

                btnSave.Text = "Update";
                var row = dataGrid.SelectedRows[0];
                modelInput.Text = row.Cells["ModelName"].Value.ToString();

            }
            else
            {
                btnSave.Text = "Save";
                modelInput.Clear();
            }
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            cmbBrand.SelectedIndex = 0;
            btnSave.Text = "Save";
            modelInput.Clear();
            dataGrid.ClearSelection();
            btnSave.Enabled = false;
        }

        private void InsertModel()
        {
            frmMaster masterForm = (frmMaster)this.MdiParent;
            masterForm.UpdateStatusLabel("Model Added");
        }
        private void UpdateModel()
        {
            frmMaster masterForm = (frmMaster)this.MdiParent;
            masterForm.UpdateStatusLabel("Model Updated");
        }
    }
}
