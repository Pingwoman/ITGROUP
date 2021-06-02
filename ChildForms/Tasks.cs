using System;
using System.Data;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Collections;
using DGVPrinterHelper;

namespace ITGROUP.ChildForms
{
    public partial class Tasks : Form
    {
        public Tasks()
        {
            InitializeComponent();
        }
        ArrayList ttype1 = new ArrayList();
        ArrayList amount1 = new ArrayList();


        public void clearArraylist(ArrayList arrayList)
        {
            arrayList.Clear();
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

        public void getCurrentTasksAmount()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select count(Task_ID) from Employee_Task et " +
                                          "inner join Employee e on et.Employee_ID = e.ID_Employee " +
                                          "inner join Task t on et.Task_ID = t.ID_Task " +
                                          "where et.Employee_ID = (select ID_Employee from Employee where Ulogin = @ulogin ) " +
                                          "and t.Task_status_ID in (1,2);";

                    command.Parameters.Add("@ulogin", SqlDbType.VarChar).Value = Authorization.Ulogin;

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable t = new DataTable();
                    da.Fill(t);
                    label8.Text = "";
                    label8.Text = t.Rows[0][0].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public void getDoneTasksAmount()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    command.CommandText = "select count(Task_ID) from Employee_Task et " +
                                          "inner join Employee e on et.Employee_ID = e.ID_Employee " +
                                          "inner join Task t on et.Task_ID = t.ID_Task " +
                                          "where et.Employee_ID = (select ID_Employee from Employee where Ulogin = @ulogin ) " +
                                          "and t.Task_status_ID=3;";

                    command.Parameters.Add("@ulogin", SqlDbType.VarChar).Value = Authorization.Ulogin;

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable t = new DataTable();
                    da.Fill(t);
                    label1.Text = "";
                    label1.Text = t.Rows[0][0].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void getProjectsAmount()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    command.CommandText = "select count(Project_ID) from Employee_Task et " +
                                          "inner join Employee e on et.Employee_ID = e.ID_Employee " +
                                          "where et.Employee_ID = (select ID_Employee from Employee where Ulogin = @ulogin ) ";


                    command.Parameters.Add("@ulogin", SqlDbType.VarChar).Value = Authorization.Ulogin;

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable t = new DataTable();
                    da.Fill(t);
                    label5.Text = "";
                    label5.Text = t.Rows[0][0].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void getTasksAmountByUser()
        {

            try
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("getTasksAmountByUser", connection);
                    command.CommandType = CommandType.StoredProcedure;
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

        public void taskTable()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand("taskTable", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@ulogin", SqlDbType.VarChar).Value = Authorization.Ulogin;

                    DataTable dataTable = new DataTable();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                    dataAdapter.Fill(dataTable);

                    dataGridView_Tasks.DataSource = dataTable;
                }

                for (int i = 0; i < dataGridView_Tasks.Columns.Count; i++)
                {
                    dataGridView_Tasks.Columns[i].Width = 60;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void fillComboboxProject()
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select Project_name from Project", connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string project = dataReader["Project_name"].ToString();
                        projectID.Items.Add(project);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void fillComboboxPiority()
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select Priority_name from TaskPriority", connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string priority = dataReader["Priority_name"].ToString();
                        priorityID.Items.Add(priority);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public void fillComboboxStatus(ComboBox comboBox)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select Status_name from TaskStatus", connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string status = dataReader["Status_name"].ToString();
                        comboBox.Items.Add(status);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void fillComboboxTask()
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select ID_Task from Task", connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string task = dataReader["ID_Task"].ToString();
                        comboBox_Task.Items.Add(task);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void closePanel(object sender, EventArgs e)
        {
            panel_AddTask.Visible = false;
            this.button_addTask.Text = "Добавить задачу";
            this.button_deleteTask.Text = "Удалить задачу";
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = true;
            panel6.Visible = true;
            panel7.Visible = true;
            panel8.Visible = true;
            dataGridView_Tasks.Visible = true;
            chart1.Visible = true;
            taskTable();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelCurrentTime.Text = DateTime.Now.ToLongTimeString();
            labelDate.Text = DateTime.Now.ToShortDateString();
            labelDayofWeek.Text = DateTime.Today.ToString("dddd");
        }

        private void Tasks_Load(object sender, EventArgs e)
        {
            taskTable();
            clearArraylist(ttype1);
            clearArraylist(amount1);
            ClearChart(chart1);
            getCurrentTasksAmount();
            getDoneTasksAmount();
            getProjectsAmount();
            getTasksAmountByUser();
            fillComboboxPiority();
            fillComboboxProject();
            fillComboboxStatus(comboBox_Status);
            fillComboboxStatus(cmbStatus);
            fillComboboxTask();

            if ((Convert.ToInt32(Authorization.URole) == 1) || (Convert.ToInt32(Authorization.URole) == 2))
            {
                button_addTask.Visible = true;
                button_deleteTask.Visible = true;
            }
        }

        private void button_AddClient_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Отчет по задачам ";
            printer.SubTitle = $"Автор: {Authorization.Ulogin}. {string.Format("Дата: {0}", DateTime.Now.Date.ToString("MM/dd/yyyy"))}";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "ITGroup";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView_Tasks);
        }//Print

        private void button1_Click(object sender, EventArgs e)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//Print

        private void button_addTask_Click(object sender, EventArgs e)
        {
            this.button_addTask.Click += new EventHandler(this.closePanel);
            button_addTask.Text = "Закрыть";
            button_Print.Visible = false;
            button_printExcel.Visible = false;
            panel_AddTask.Visible = true;
            fillComboboxPiority();
            fillComboboxProject();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            dataGridView_Tasks.Visible = false;
            chart1.Visible = false;
            textBox_ID.Visible = false;
            textBox1.Visible = false;
            cmbStatus.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            button_updTask.Visible = false;
            button_delete.Visible = false;
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            int a = projectID.SelectedIndex + 1;
            int b = priorityID.SelectedIndex + 1;
            int c = comboBox_Status.SelectedIndex + 1;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {

                    connection.Open();
                    SqlCommand command = new SqlCommand("addTask", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        command.Parameters.AddWithValue("@projID", SqlDbType.Int).Value = a;
                        command.Parameters.AddWithValue("@prior", SqlDbType.Int).Value = b;
                        command.Parameters.AddWithValue("@ds", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                        command.Parameters.AddWithValue("@df", SqlDbType.Date).Value = dateTimePicker2.Value.Date;
                        command.Parameters.AddWithValue("@desc", SqlDbType.VarChar).Value = task_desc.Text;
                        command.Parameters.AddWithValue("s", SqlDbType.Int).Value = c;
                        command.ExecuteNonQuery();
                        MessageBox.Show("Добавлено", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void deleteTask()
        {
            int t = comboBox_Task.SelectedIndex + 1;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("delete from Task where ID_Task = @t", connection);
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@t", t);

                    command.ExecuteNonQuery();

                    //MessageBox.Show("Удалено", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        private void button_deleteTask_Click(object sender, EventArgs e)
        {
            panel_AddTask.Visible = true;
            panel9.Visible = true;
            button_Print.Visible = false;
            button_printExcel.Visible = false;
            this.button_deleteTask.Click += new EventHandler(this.closePanel);
            button_Add.Visible = false;
            this.button_deleteTask.Text = "Закрыть";
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            dataGridView_Tasks.Visible = false;
            chart1.Visible = false;
            label13.Text = "Удаление задачи";
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            textBox_ID.Visible = false;
            cmbStatus.Visible = false;
            textBox1.Visible = false;
            button_updTask.Visible = false;
        }

        private void comboBox_Task_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int t = comboBox_Task.SelectedIndex + 1;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select Task_desc, Task_start, Task_end, Task_status_ID, Task_Priority from Task where ID_Task = @t", connection);
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@t", SqlDbType.Int).Value = t;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        task_desc.Text = reader.GetValue(0).ToString();
                        textBox_DateStart.Text = reader.GetValue(1).ToString();
                        textBox_DateEnd.Text = reader.GetValue(2).ToString();
                        comboBox_Status.SelectedIndex = Convert.ToInt32(reader.GetValue(3))-1;
                        priorityID.SelectedIndex = Convert.ToInt32(reader.GetValue(4))-1;
                    }
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            deleteTask();
            task_desc.Clear();
            textBox_DateEnd.Clear();
            textBox_DateStart.Clear();
            comboBox_Task.Visible = true;
            priorityID.SelectedIndex = -1;
            comboBox_Status.SelectedIndex = -1;
            comboBox_Task.SelectedIndex = -1;
        }

        private void comboBox_Task_SelectedIndexChanged(object sender, EventArgs e)
        {
            int t = comboBox_Task.SelectedIndex + 1;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select Task_desc, Task_start, Task_end, Task_status_ID, Task_Priority from Task where ID_Task = @t", connection);
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@t", SqlDbType.Int).Value = t;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        task_desc.Text = reader.GetValue(0).ToString();
                        textBox_DateStart.Text = reader.GetValue(1).ToString();
                        textBox_DateEnd.Text = reader.GetValue(2).ToString();
                        comboBox_Status.SelectedIndex = Convert.ToInt32(reader.GetValue(3)) - 1;
                        priorityID.SelectedIndex = Convert.ToInt32(reader.GetValue(4)) - 1;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_Tasks_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView_Tasks.SelectedRows)
            {
                textBox_ID.Text = row.Cells[0].Value.ToString();
                cmbStatus.Text = row.Cells[4].Value.ToString();

            }
        }

        private void button_updTask_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand("updTask", connection);
                    command.Connection = connection;

                    command.Parameters.AddWithValue("@id", textBox_ID.Text);
                    command.Parameters.AddWithValue("@status", cmbStatus.SelectedIndex + 1);
                    command.Parameters.AddWithValue("@comm", textBox1.Text);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Обновлено", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

