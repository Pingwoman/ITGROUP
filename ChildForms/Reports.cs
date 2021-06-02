using System;
using NLog;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using DGVPrinterHelper;
using System.Collections;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace ITGROUP.ChildForms
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private Panel activepanel = null;
        private void ActivatePanel(Panel newPan)
        {
            if (activepanel != null)
            {
                activepanel.Visible = false;
            }
            activepanel = newPan;
            activepanel.Visible = true;
        }

        public void getUserName()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select CONCAT(Emp_surname,' ', Emp_name, ' ', Emp_patronymic) from Employee where Ulogin = @ulogin ";
                    command.Parameters.AddWithValue("@ulogin", Authorization.Ulogin);

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable t = new DataTable();
                    da.Fill(t);
                    label_Emp.Text = "";
                    label_Emp.Text = t.Rows[0][0].ToString();

                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void displayProjectDataByUser(int a)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("forUserReportByProject", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@id_project", SqlDbType.Int).Value = a;
                    command.Parameters.Add("@ulogin", SqlDbType.VarChar).Value = Authorization.Ulogin;

                    DataTable dataTable = new DataTable();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                    dataAdapter.Fill(dataTable);


                    dataGridView_Tasks.DataSource = dataTable;

                    

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            ClearChart(chart1);
            label_Date.Text = DateTime.Now.ToShortDateString();
            //getUserName();
            
        }

        private void button_P1_Click(object sender, EventArgs e)
        {
            displayProjectDataByUser(1);
            ActivatePanel(panel6);
            getDataForChart(1);
        }

        private void button_P4_Click(object sender, EventArgs e)
        {
            displayProjectDataByUser(4);
            ActivatePanel(panel9);
            getDataForChart(4);
        }

        private void button_P3_Click(object sender, EventArgs e)
        {
            displayProjectDataByUser(3);
            ActivatePanel(panel8);
            getDataForChart(3);
        }

        private void button_P2_Click(object sender, EventArgs e)
        {
            displayProjectDataByUser(2);
            ActivatePanel(panel7);
            getDataForChart(2);
        }

        private void button_AddClient_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Отчет по проекту ";
            printer.SubTitle = $"Автор: {label_Emp.Text}. {string.Format("Дата: {0}", DateTime.Now.Date.ToString("MM/dd/yyyy"))}";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "ITGroup";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView_Tasks);
            logger.Info("Печать таблицы");
        }
        
        public void getDataForChart(int a)
        {
           ArrayList ttype1 = new ArrayList();
           ArrayList amount1 = new ArrayList();

           try
           {

               using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
               {
                   connection.Open();
                   SqlCommand command = new SqlCommand("taskChartsByUser", connection);
                   command.CommandType = CommandType.StoredProcedure;

                   command.Parameters.Add("@id_project", SqlDbType.Int).Value = a;
                   command.Parameters.Add("@ulogin", SqlDbType.VarChar).Value = Authorization.Ulogin;

                   SqlDataReader dataReader = command.ExecuteReader();

                   while (dataReader.Read())
                   {
                      ttype1.Add(dataReader.GetString(0));
                      amount1.Add(dataReader.GetInt32(1));
                   }
                   chart1.Series[0].Points.DataBindXY(ttype1, amount1);
                   dataReader.Close();
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
           
        }

        public void printExcel()
        {
            try
            {
                if (dataGridView_Tasks.Rows.Count > 0)
                {
                    Excel.Application app = new Excel.Application();
                    Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
                    Excel.Worksheet worksheet = null;

                    worksheet = workbook.Sheets["Лист1"];
                    worksheet = workbook.ActiveSheet;
                    worksheet.Name = "Table";

                    for (int i = 1; i < dataGridView_Tasks.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i] = dataGridView_Tasks.Columns[i - 1].HeaderText;
                    }


                    for (int i = 0; i < dataGridView_Tasks.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView_Tasks.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1] = dataGridView_Tasks.Rows[i].Cells[j].Value.ToString();
                        }
                    }

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = $"report";
                    saveFileDialog.DefaultExt = ".xlsx";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                    }
                    app.Quit();
                    

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void printChart()
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JPEG (*.jpeg)|*.jpeg|BMP (*.bmp)|*.bmp|PNG (*.png)|*.png|All files (*.*)|*.*";

                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (Path.GetExtension(saveFileDialog.FileName).ToLower() == ".png")
                        this.chart1.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                    else if (Path.GetExtension(saveFileDialog.FileName).ToLower() == ".bmp")
                        this.chart1.SaveImage(saveFileDialog.FileName, ChartImageFormat.Bmp);
                    else if (Path.GetExtension(saveFileDialog.FileName).ToLower() == ".jpeg")
                        this.chart1.SaveImage(saveFileDialog.FileName, ChartImageFormat.Jpeg);
                    saveFileDialog.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ClearChart(System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            chart.Series[0].Points.Clear();
            //chart.Series[0].Points.RemoveAt(0);

            foreach (var series in chart.Series)
            {
                series.Points.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printExcel();
            logger.Info("Печать таблицы в Excel");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printChart();
            logger.Info("Печать диаграммы");
        }
    }
}
