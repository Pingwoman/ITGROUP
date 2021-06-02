using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Configuration;
using NLog;
using System.Security.Cryptography;

namespace ITGROUP
{
    public partial class Authorization : Form
    {
        public static string lang;
        public Authorization()
        {
            InitializeComponent();
            if (!String.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);

            }
        }

        public static string Ulogin = "";
        public static int URole;
        Logger logger = LogManager.GetCurrentClassLogger();
        #region Drag&Drop
        //Drag
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    connection.Open();
                    string loginUser = textBoxUsername.Text;
                    string passUser = textBoxPassword.Text;
                    Ulogin = textBoxUsername.Text;
                    DataTable table = new DataTable();

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    SqlCommand command = new SqlCommand("select * from Employee where Ulogin = @ul", connection);
                    command.Parameters.Add("@ul", SqlDbType.VarChar).Value = loginUser;
                    //command.Parameters.Add("@up", SqlDbType.VarChar).Value = passUser;

                    adapter.SelectCommand = command;
                    adapter.Fill(table);

                    URole = table.Rows[0].Field<int>("URole");

                    HashSalt hashSalt = HashSalt.GenerateSaltedHash(64, textBoxPassword.Text);
                    bool isPasswordMatched = VerifyPassword(passUser, hashSalt.Hash, hashSalt.Salt);

                    if((table.Rows.Count > 0)&& (isPasswordMatched==true))
                    {
                        Form form = new MainForm();
                        form.Show();
                        this.Hide();
                        logger.Info($"Вход в систему - {Ulogin}");
                        //getRole();
                    }
                    else
                    {
                        MessageBox.Show("Попробуйте еще раз", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        logger.Warn($"Неудачная попытка входа в систему {Ulogin}");
                        
                        SqlCommand c = new SqlCommand( );
                        c.Connection = connection;
                        c.CommandType = CommandType.Text;
                        c.CommandText = $"insert into Log values ('Неудачная попытка входа в систему {Ulogin}');";
                        //c.Parameters.Add("@mess", SqlDbType.VarChar).Value = Ulogin;
                        c.ExecuteNonQuery();
                    }
                    //getRole();
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
                logger.Error(ex);
                
            }
            
        }

        public void getRole()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ITGroup"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select URole from Employee where Ulogin = @ul", connection);
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@ul", Ulogin);
                    //DataTable dt = new DataTable();
                    //SqlDataAdapter adapter = new SqlDataAdapter();

                    //adapter.SelectCommand = command;
                    //adapter.Fill(dt);
                    //URole = dt.Rows[0][0].ToString();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        //int a  = reader.GetOrdinal("URole");
                        URole = reader.GetInt32(0);
                        
                    }
                    reader.Close();
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == storedHash;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = comboBox1.SelectedValue.ToString();
            Properties.Settings.Default.Save();
            lang = Properties.Settings.Default.Language;
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = new System.Globalization.CultureInfo[] {
                System.Globalization.CultureInfo.GetCultureInfo("ru"),
                 System.Globalization.CultureInfo.GetCultureInfo("kk"),
                 System.Globalization.CultureInfo.GetCultureInfo("en"),
            };
            comboBox1.DisplayMember = "NativeName";
            comboBox1.ValueMember = "Name";

            if (!String.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                comboBox1.SelectedValue = Properties.Settings.Default.Language;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = comboBox1.SelectedValue.ToString();
            Properties.Settings.Default.Save();
            lang = Properties.Settings.Default.Language;
        }
    }
}
