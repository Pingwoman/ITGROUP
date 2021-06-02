using System;
using System.Data;
using NLog;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;

namespace ITGROUP.ChildForms
{
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
        }
        Regex regex = new Regex(@"\d{3}\-\d{3}-\d{4}");
        Logger logger = LogManager.GetCurrentClassLogger(); 
        public void displayClientData()
        {
            try 
            { 
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "select ID_Client as 'Номер клиента' , Client_name as 'Наименование' , Clinet_address as 'Адрес'" +
                                          ", ct.Client_type_name as 'Тип клиента', CONCAT(CP_surname, ' ', CP_name, ' ', CP_patronymic) as 'Представитель'" +
                                          ", CP_phone_number as 'Номер телефона' , CP_email as 'Электронная почта' from Client "+
                                          "left join Client_type ct on Client_type_ID = ct.ID_Client_type";


                    DataTable dataTable = new DataTable();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                    dataAdapter.Fill(dataTable);

                    dataGridView_Clients.DataSource = dataTable;

                    dataGridView_Clients.Visible = true;

                    
                    dataGridView_Clients.Columns[3].Width = 100;
                    dataGridView_Clients.Columns[6].Width = 150;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        //Загрузка страницы
        private void Clients_Load(object sender, EventArgs e)
        {
            displayClientData();
            if ((Convert.ToInt32(Authorization.URole) == 1) || (Convert.ToInt32(Authorization.URole) == 2))
            {
                button_AddClient.Visible = true;
            }
            else
            {
                button_AddClient.Visible = false;
            }
        }

        public  void closePanel(object sender, EventArgs e)
        {
            panel_AddClients.Visible = false;
            dataGridView_Clients.Visible = true;
            this.button_AddClient.Text = "Добавить клиента";
            displayClientData();
        }

        private void button_AddClient_Click(object sender, EventArgs e)
        {
            fillComboboxClientType();
            dataGridView_Clients.Visible = false;
            panel_AddClients.Visible = true;
            this.button_AddClient.Text = "Закрыть";
            this.button_AddClient.Click += new EventHandler(this.closePanel);
        }

        //Заполнение комбобокса
        public void fillComboboxClientType()
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select Client_type_name from Client_type", connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string Client_type_name = dataReader["Client_type_name"].ToString();
                        clientType.Items.Add(Client_type_name);
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                       

            
           
        }
        //Добавить клиента
        private void button_Add_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    connection.Open();
                    int a = clientType.SelectedIndex + 1;

                    SqlCommand command = new SqlCommand("addClient", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    if ((string.IsNullOrWhiteSpace(bin.Text) == false) && (string.IsNullOrWhiteSpace(company_name.Text) == false) &&
                (string.IsNullOrWhiteSpace(address.Text) == false) && (string.IsNullOrWhiteSpace(surname.Text) == false) && (string.IsNullOrWhiteSpace(name.Text) == false))
                    {
                        if (regex.IsMatch(phone.Text))
                        {
                            try
                            {
                                command.Parameters.AddWithValue("@bin", SqlDbType.BigInt).Value = bin.Text;
                                command.Parameters.AddWithValue("@company_name", SqlDbType.VarChar).Value = company_name.Text;
                                command.Parameters.AddWithValue("@address", SqlDbType.VarChar).Value = address.Text;
                                command.Parameters.AddWithValue("@clientType", SqlDbType.VarChar).Value = a;
                                command.Parameters.AddWithValue("@surname", SqlDbType.VarChar).Value = surname.Text;
                                command.Parameters.AddWithValue("@name", SqlDbType.VarChar).Value = name.Text;
                                command.Parameters.AddWithValue("@patronymic", SqlDbType.Int).Value = patronymic.Text;
                                command.Parameters.AddWithValue("@phone", SqlDbType.Int).Value = phone.Text;
                                command.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = email.Text;
                                command.Parameters.AddWithValue("@contract", SqlDbType.Int).Value = textBox_ContractNumber.Text;
                                command.Parameters.AddWithValue("@p_desc", SqlDbType.VarChar).Value = textBox_ProjectDesc.Text;
                                command.Parameters.Add("@ds", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                                command.Parameters.Add("@df", SqlDbType.Date).Value = dateTimePicker2.Value.Date;
                                command.ExecuteNonQuery();
                                MessageBox.Show("Добавлено", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                logger.Error(ex);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Некорректный формат номера телефона!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Error(ex);
            }
        }

        //Нажатие цифр на поле с БИН
        private void bin_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
                    
        }
    }
}