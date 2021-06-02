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

namespace ITGROUP
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private Form activeForm = null;
        //Открыть дочернюю форму
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }



        #region Drag&Drop
        //Drag
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelMouseDown(object sender, MouseEventArgs e) //Нажатие и удержание мыши на панели
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        #endregion

        #region WindowNavigate
        private void button_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button_Maximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                button_Maximize.Image = Properties.Resources.window_restore;

            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }
        #endregion

        private void buttonHome_Click(object sender, EventArgs e)
        {
            openChildForm(new ChildForms.HomePage());
            label3.Text = buttonHome.Text;
        }

        private void buttonProjects_Click(object sender, EventArgs e)
        {
            openChildForm(new ChildForms.Projects());
            label3.Text = buttonProjects.Text;
        }

        private void buttonClients_Click(object sender, EventArgs e)
        {
            label3.Text = buttonClients.Text;
            openChildForm(new ChildForms.Clients());
        }

        private void buttonTasks_Click(object sender, EventArgs e)
        {
            label3.Text = buttonTasks.Text;
            openChildForm(new ChildForms.Tasks());
        }

        private void buttonReports_Click(object sender, EventArgs e)
        {
            label3.Text=buttonReports.Text;
            openChildForm(new ChildForms.Reports());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Authorization.URole) != 1)
            {
                buttonUsers.Visible = false;
                //button_NewUsers.Enabled = true;
            }
            
            ulogin.Text = Authorization.Ulogin;
        }

        private void buttonExitUser_Click(object sender, EventArgs e)
        {
            this.Close();
            Authorization authorization = new Authorization();
            authorization.Show();
        }

        

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            label3.Text = buttonUsers.Text;
            openChildForm(new ChildForms.AdminPanel());
        }
    }
}
