using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITGROUP.ChildForms
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        public void getName()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT CONCAT(Emp_surname, ' ', Emp_name, ' ', Emp_patronymic) from  Employee where Ulogin = @ulogin", connection);
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@ulogin", SqlDbType.VarChar).Value = Authorization.Ulogin;

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable t = new DataTable();
                    da.Fill(t);
                    textBox_Name.Text = "";
                    textBox_Name.Text = t.Rows[0][0].ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void getContacts()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "select CONCAT(Emp_surname, ' ', Emp_name, ' ', Emp_patronymic) Имя, Phone_number 'Номер телефона'" +
                                          ", p.Position_name Должность from Employee e inner join Position p on e.Position_ID=p.ID_Position"+
                                          " where Ulogin!=@ulogin";
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@ulogin", SqlDbType.VarChar).Value = Authorization.Ulogin;

                    DataTable dataTable = new DataTable();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                    dataAdapter.Fill(dataTable);

                    dataGridView_Contacts.DataSource = dataTable;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void getPosition()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT p.Position_name from Employee e inner join Position p on e.Position_ID=p.ID_Position where Ulogin = @ulogin", connection);
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@ulogin", SqlDbType.VarChar).Value = Authorization.Ulogin;

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable t = new DataTable();
                    da.Fill(t);
                    //textBox_Position.Text = "";
                    label5.Text = t.Rows[0][0].ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void getEducation()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT ed.Edu_name from Employee e inner join Education ed on e.Education_ID=ed.ID_Education where Ulogin = @ulogin", connection);
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@ulogin", SqlDbType.VarChar).Value = Authorization.Ulogin;

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable t = new DataTable();
                    da.Fill(t);
                    textBox_Education.Text = "";
                    textBox_Education.Text = t.Rows[0][0].ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void getPhone()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT Phone_number from  Employee where Ulogin = @ulogin", connection);
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@ulogin", SqlDbType.VarChar).Value = Authorization.Ulogin;

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable t = new DataTable();
                    da.Fill(t);
                    textBox_Position.Text = "";
                    textBox_Position.Text = t.Rows[0][0].ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            //getName();
            //getPosition();
           // getEducation();
            //getPhone();
            getContacts();
        }
    }
}
