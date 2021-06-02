using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ITGROUP.ChildForms
{
    public partial class AdminPanel : Form
    {
        SqlDataAdapter dataAdapter;
        
        DataTable dataTable;
        
        public AdminPanel()
        {
            InitializeComponent();
        }

        public void getData()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
            {
                dataAdapter = new SqlDataAdapter("select ID_Employee, Emp_surname, Emp_name, Emp_patronymic " +
                    ", p.Position_name, ed.Edu_name, Phone_number, u.Role_name from Employee e " +
                    " inner join Position p on e.Position_ID = p.ID_Position " +
                    " inner join Education ed on e.Education_ID = ed.ID_Education " +
                    " inner join URole u on e.URole = u.ID_Role"
                    , conn);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView_Users.DataSource = dataTable;
            }
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            getData();
            fillComboboxRole();
            fillComboboxEducation();
            fillComboboxPosition();
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("updateUser", connection);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@surname", surname.Text);
                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@patr", textBox2.Text);
                    cmd.Parameters.AddWithValue("@ph", textBox3.Text);
                    cmd.Parameters.AddWithValue("@pos", position.SelectedIndex + 1);
                    cmd.Parameters.AddWithValue("@edu", education.SelectedIndex + 1);
                    cmd.Parameters.AddWithValue("@role", role.SelectedIndex + 1);
                    cmd.Parameters.AddWithValue(@"id", textBox_ID.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Обновлено", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            getData();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            try 
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString)) 
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("addUser", connection);
                   
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@surname", surname.Text);
                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@patr", textBox2.Text);
                    cmd.Parameters.AddWithValue("@ph", textBox3.Text);
                    cmd.Parameters.AddWithValue("@pos", position.SelectedIndex+1);
                    cmd.Parameters.AddWithValue("@edu", education.SelectedIndex+1);
                    cmd.Parameters.AddWithValue("@role", role.SelectedIndex + 1);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Добавлено", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            getData();
        }

        public void fillComboboxRole()
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select Role_name from URole", connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string name = dataReader["Role_name"].ToString();
                        role.Items.Add(name);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        public void fillComboboxEducation()
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select Edu_name from Education", connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string name = dataReader["Edu_name"].ToString();
                        education.Items.Add(name);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        public void fillComboboxPosition()
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select Position_name from Position", connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string name = dataReader["Position_name"].ToString();
                        position.Items.Add(name);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView_Users_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView_Users.SelectedRows)
            {
                surname.Text = row.Cells[1].Value.ToString();
                textBox1.Text = row.Cells[2].Value.ToString();
                textBox2.Text = row.Cells[3].Value.ToString();
                textBox3.Text = row.Cells[4].Value.ToString();
                position.Text = row.Cells[5].Value.ToString();
                education.Text = row.Cells[6].Value.ToString();
                role.Text = row.Cells[7].Value.ToString();
                textBox_ID.Text = row.Cells[0].Value.ToString();

            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("delete from Employee where ID_Employee = @id", connection);
                    cmd.Parameters.AddWithValue("@id", textBox_ID.Text);

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
