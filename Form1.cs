using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace MakelYemekhanePlanYukleyici
{
    public partial class Form1 : Form
    {
        //private readonly string BASE_URL = "http://192.168.223.1:8090/";
        //private readonly string BASE_URL = "http://10.0.0.101:8188/"; 
        private readonly string BASE_URL = "http://85.105.238.124:8188/";

        List<FoodPlan> listFoodPlan = new List<FoodPlan>();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonExcelRead_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                label_excelReadReport.Visible = true;
                filePath = file.FileName;
                fileExt = Path.GetExtension(filePath);
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        label_excelReadReport.Text = "Dosya okunuyor...";
                        Thread myNewThread = new Thread(() => ReadExcel(file, filePath, fileExt));
                        myNewThread.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    label_excelReadReport.Text = "Geçerli bir Excel dosyası değil. Yalnızca .xls ve .xlsx dosyalarını yükleyin.";
                    return;
                }
            }
        }

        private void buttonPostFoodPlan_Click(object sender, EventArgs e)
        {
            if (listFoodPlan.Count == 0)
            {
                label_excelReadReport.Visible = true;
                label_excelReadReport.Text = "Listeden yemek planı çekilemedi";
                return;
            }

            var jsonArray = JsonConvert.SerializeObject(listFoodPlan);       
            Thread myNewThread = new Thread(() => PostFoodPlanAsync(jsonArray));
            myNewThread.Start();
        }

        private async void GetFoodPlanAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.223.1:8090/");
            HttpResponseMessage response = await client.GetAsync("foodplan");
            string result = await response.Content.ReadAsStringAsync();
        }

        private async void PostFoodPlanAsync(string json)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
                     
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var result = client.PostAsync("foodplan/addupdatemultiple", content).Result;

            label_excelReadReport.Invoke((MethodInvoker)delegate
            {
                label_excelReadReport.Text = listFoodPlan.Count + " günlük program sunucuya yüklendi.";
                label_excelReadReport.Visible = true;
            });
        }

        private void ReadExcel(OpenFileDialog file, string filePath, string fileExt)
        {
            listFoodPlan.Clear();

            Excel.Application xlApp = null;
            Excel.Workbook xlWorkbook = null;
            Excel._Worksheet xlWorksheet = null;
            Excel.Range xlRange = null;

            try
            {
                xlApp = new Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(filePath);
                xlWorksheet = xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            string user = String.Empty;
            DateTime bday = DateTime.Now;

            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    {
                        var dateString = xlRange.Cells[i, j].Value;

                        if (dateString is DateTime)
                            CreateAFoodPlan(dateString, xlRange, i, j);
                    }
                }
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            label_excelReadReport.Invoke((MethodInvoker)delegate
            {
                label_excelReadReport.Text = listFoodPlan.Count + " günlük program okundu.";
                label_excelReadReport.Visible = true;
            });
        }

        private void CreateAFoodPlan(DateTime mealDate, Excel.Range xlRange, int i, int j)
        {
            try
            {
                FoodPlan foodPlan = new FoodPlan();
                foodPlan.date = mealDate;

                if (xlRange[i + 1, j].Value != null) foodPlan.food1 = xlRange[i + 1, j].Value.ToString();
                if (xlRange[i + 2, j].Value != null) foodPlan.food2 = xlRange[i + 2, j].Value.ToString();
                if (xlRange[i + 3, j].Value != null) foodPlan.food3 = xlRange[i + 3, j].Value.ToString();
                if (xlRange[i + 4, j].Value != null) foodPlan.food4 = xlRange[i + 4, j].Value.ToString();
                if (xlRange[i + 5, j].Value != null) foodPlan.food5 = xlRange[i + 5, j].Value.ToString();

                listFoodPlan.Add(foodPlan);
            }
            catch (Exception ex)
            {
                string sss = ex.Message;
            }
        }

    }
}
