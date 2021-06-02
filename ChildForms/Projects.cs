using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace ITGROUP.ChildForms
{
    public partial class Projects : Form
    {
        ArrayList ttype = new ArrayList();
        ArrayList amount = new ArrayList();
        public Projects()
        {
            InitializeComponent();
        }

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

        public void ClearChart(System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            chart.Series[0].Points.Clear();
            //chart.Series[0].Points.RemoveAt(0);

            foreach (var series in chart.Series)
            {
                series.Points.Clear();
            }
        }

        public void clearArraylist(ArrayList arrayList)
        {
            arrayList.Clear();
        }

        public void getProjectInfo(int a)
        {
            try 
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("tasksCharts", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@id_project", SqlDbType.Int).Value = a;

                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        ttype.Add(dataReader.GetString(0));
                        amount.Add(dataReader.GetInt32(1));
                    }
                    chart2.Series[0].Points.DataBindXY(ttype, amount);
                    dataReader.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void getProjectInfoByUser(int a)
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

        public void getProjectName (int a)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT Project_name from Project where ID_Project = @id", connection);
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@id", SqlDbType.Int).Value = a;

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

        public void getProjectDesc(int a)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT Project_desc from Project where ID_Project = @id", connection);
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@id", SqlDbType.Int).Value = a;

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable t1 = new DataTable();
                    da.Fill(t1);
                    textBox1.Text = "";
                    textBox1.Text = t1.Rows[0][0].ToString();

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void getStatus(int a, string s, CircularButton circular)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand("statusLabel", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@status", SqlDbType.VarChar, 20).Value = s; 
                    command.Parameters.Add("@id_project", SqlDbType.Int).Value = a;

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable t = new DataTable();
                    da.Fill(t);
                    circular.Text = t.Rows[0][1].ToString();
                    
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void getPriority(int a, string s, CircularButton circular)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand("priorityLabel", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@priority", SqlDbType.VarChar, 20).Value = s;
                    command.Parameters.Add("@id_project", SqlDbType.Int).Value = a;

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable t = new DataTable();
                    da.Fill(t);
                    circular.Text = t.Rows[0][1].ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_P1_Click(object sender, EventArgs e)
        {
            ActivatePanel(panel6);
            clearArraylist(ttype);
            clearArraylist(amount);
            ClearChart(chart2);
           
            getProjectInfo(1);

            getProjectInfoByUser(1);

            getProjectName(1);
            getProjectDesc(1);

            getStatus(1, "Принято", circularButton1);
            getStatus(1, "В процессе", circularButton2);
            getStatus(1, "Выполнено", circularButton3);

            getPriority(1, "Высокий", circularButton4);
            getPriority(1, "Средний", circularButton5);
            getPriority(1, "Низкий", circularButton6);
        }

        private void button_P2_Click(object sender, EventArgs e)
        {
            ActivatePanel(panel7);
            clearArraylist(ttype);
            clearArraylist(amount);
            ClearChart(chart2);
            ClearChart(chart1);
            getProjectInfo(2);

            getProjectInfoByUser(2);

            getProjectName(2);
            getProjectDesc(2);

            getStatus(2, "Принято", circularButton1);
            getStatus(2, "В процессе", circularButton2);
            getStatus(2, "Выполнено", circularButton3);

            getPriority(2, "Высокий", circularButton4);
            getPriority(2, "Средний", circularButton5);
            getPriority(2, "Низкий", circularButton6);
        }

        private void button_P3_Click(object sender, EventArgs e)
        {
            ActivatePanel(panel8);
            clearArraylist(ttype);
            clearArraylist(amount);
            ClearChart(chart1);
            ClearChart(chart2);
            getProjectInfo(3);


            getProjectInfoByUser(3);

            getProjectName(3);
            getProjectDesc(3);

            getStatus(3, "Принято", circularButton1);
            getStatus(3, "В процессе", circularButton2);
            getStatus(3, "Выполнено", circularButton3);

            getPriority(3, "Высокий", circularButton4);
            getPriority(3, "Средний", circularButton5);
            getPriority(3, "Низкий", circularButton6);
        }

        private void button_P4_Click(object sender, EventArgs e)
        {
            ActivatePanel(panel9);
            clearArraylist(ttype);
            clearArraylist(amount);
            ClearChart(chart1);
            ClearChart(chart2);
            getProjectInfo(4);


            getProjectInfoByUser(4);

            getProjectName(4);
            getProjectDesc(4);

            getStatus(4, "Принято", circularButton1);
            getStatus(4, "В процессе", circularButton2);
            getStatus(4, "Выполнено", circularButton3);

            getPriority(4, "Высокий", circularButton4);
            getPriority(4, "Средний", circularButton5);
            getPriority(4, "Низкий", circularButton6);
        }
    }
}
