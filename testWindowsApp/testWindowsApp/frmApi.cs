using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace testWindowsApp
{
    public partial class frmApi : Form
    {
        public frmApi()
        {
            InitializeComponent();
        }

        public async Task<string> GetDataFromApi(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage res = await client.GetAsync(url);
                    res.EnsureSuccessStatusCode();
                    string resData = await res.Content.ReadAsStringAsync();
                    return resData;
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Req Err: {ex.Message}");
                    return null;
                }
            }

        }

        public class ApiData
        {
            public string Fact { get; set; }
            public int Length { get; set; }
        }
        private async void btnFetch_Click(object sender, EventArgs e)
        {
            string apiUrl = "https://catfact.ninja/fact"; 
            string result = await GetDataFromApi(apiUrl);

            if (result != null)
            {
                var apiData = JsonConvert.DeserializeObject<ApiData>(result);

                if (apiData != null)
                {
                    List<ApiData> dataList = new List<ApiData> { apiData };
                    dataGrid.DataSource = dataList;
                }
            }
        }


    }
}
