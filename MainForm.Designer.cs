
namespace ITGROUP
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.buttonUsers = new System.Windows.Forms.Button();
            this.panelUser = new System.Windows.Forms.Panel();
            this.ulogin = new System.Windows.Forms.Label();
            this.buttonExitUser = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buttonReports = new System.Windows.Forms.Button();
            this.buttonTasks = new System.Windows.Forms.Button();
            this.buttonClients = new System.Windows.Forms.Button();
            this.buttonProjects = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.labelPageName = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.button_Maximize = new System.Windows.Forms.Button();
            this.button_Minimize = new System.Windows.Forms.Button();
            this.buttonMaximize = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.buttonCloseApp = new System.Windows.Forms.Button();
            this.panelSideMenu.SuspendLayout();
            this.panelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelChildForm.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            resources.ApplyResources(this.panelSideMenu, "panelSideMenu");
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelSideMenu.Controls.Add(this.buttonUsers);
            this.panelSideMenu.Controls.Add(this.panelUser);
            this.panelSideMenu.Controls.Add(this.buttonReports);
            this.panelSideMenu.Controls.Add(this.buttonTasks);
            this.panelSideMenu.Controls.Add(this.buttonClients);
            this.panelSideMenu.Controls.Add(this.buttonProjects);
            this.panelSideMenu.Controls.Add(this.buttonHome);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Name = "panelSideMenu";
            // 
            // buttonUsers
            // 
            resources.ApplyResources(this.buttonUsers, "buttonUsers");
            this.buttonUsers.FlatAppearance.BorderSize = 0;
            this.buttonUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(111)))));
            this.buttonUsers.ForeColor = System.Drawing.Color.White;
            this.buttonUsers.Image = global::ITGROUP.Properties.Resources.account_multiple;
            this.buttonUsers.Name = "buttonUsers";
            this.buttonUsers.UseVisualStyleBackColor = true;
            this.buttonUsers.Click += new System.EventHandler(this.buttonUsers_Click);
            // 
            // panelUser
            // 
            this.panelUser.Controls.Add(this.ulogin);
            this.panelUser.Controls.Add(this.buttonExitUser);
            this.panelUser.Controls.Add(this.pictureBox2);
            resources.ApplyResources(this.panelUser, "panelUser");
            this.panelUser.Name = "panelUser";
            // 
            // ulogin
            // 
            resources.ApplyResources(this.ulogin, "ulogin");
            this.ulogin.ForeColor = System.Drawing.Color.White;
            this.ulogin.Name = "ulogin";
            // 
            // buttonExitUser
            // 
            resources.ApplyResources(this.buttonExitUser, "buttonExitUser");
            this.buttonExitUser.BackColor = System.Drawing.Color.Transparent;
            this.buttonExitUser.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExitUser.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.buttonExitUser.FlatAppearance.BorderSize = 0;
            this.buttonExitUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.buttonExitUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonExitUser.ForeColor = System.Drawing.Color.White;
            this.buttonExitUser.Image = global::ITGROUP.Properties.Resources.exit_to_app;
            this.buttonExitUser.Name = "buttonExitUser";
            this.buttonExitUser.UseVisualStyleBackColor = false;
            this.buttonExitUser.Click += new System.EventHandler(this.buttonExitUser_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ITGROUP.Properties.Resources.account;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // buttonReports
            // 
            resources.ApplyResources(this.buttonReports, "buttonReports");
            this.buttonReports.FlatAppearance.BorderSize = 0;
            this.buttonReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(111)))));
            this.buttonReports.ForeColor = System.Drawing.Color.White;
            this.buttonReports.Name = "buttonReports";
            this.buttonReports.UseVisualStyleBackColor = true;
            this.buttonReports.Click += new System.EventHandler(this.buttonReports_Click);
            // 
            // buttonTasks
            // 
            resources.ApplyResources(this.buttonTasks, "buttonTasks");
            this.buttonTasks.FlatAppearance.BorderSize = 0;
            this.buttonTasks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(111)))));
            this.buttonTasks.ForeColor = System.Drawing.Color.White;
            this.buttonTasks.Image = global::ITGROUP.Properties.Resources.format_list_bulleted_square;
            this.buttonTasks.Name = "buttonTasks";
            this.buttonTasks.UseVisualStyleBackColor = true;
            this.buttonTasks.Click += new System.EventHandler(this.buttonTasks_Click);
            // 
            // buttonClients
            // 
            resources.ApplyResources(this.buttonClients, "buttonClients");
            this.buttonClients.FlatAppearance.BorderSize = 0;
            this.buttonClients.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(111)))));
            this.buttonClients.ForeColor = System.Drawing.Color.White;
            this.buttonClients.Image = global::ITGROUP.Properties.Resources.handshake;
            this.buttonClients.Name = "buttonClients";
            this.buttonClients.UseVisualStyleBackColor = true;
            this.buttonClients.Click += new System.EventHandler(this.buttonClients_Click);
            // 
            // buttonProjects
            // 
            resources.ApplyResources(this.buttonProjects, "buttonProjects");
            this.buttonProjects.FlatAppearance.BorderSize = 0;
            this.buttonProjects.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(111)))));
            this.buttonProjects.ForeColor = System.Drawing.Color.White;
            this.buttonProjects.Image = global::ITGROUP.Properties.Resources.folder_multiple;
            this.buttonProjects.Name = "buttonProjects";
            this.buttonProjects.UseVisualStyleBackColor = true;
            this.buttonProjects.Click += new System.EventHandler(this.buttonProjects_Click);
            // 
            // buttonHome
            // 
            resources.ApplyResources(this.buttonHome, "buttonHome");
            this.buttonHome.FlatAppearance.BorderSize = 0;
            this.buttonHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(111)))));
            this.buttonHome.ForeColor = System.Drawing.Color.White;
            this.buttonHome.Image = global::ITGROUP.Properties.Resources.home;
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Controls.Add(this.label1);
            resources.ApplyResources(this.panelLogo, "panelLogo");
            this.panelLogo.Name = "panelLogo";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panelChildForm.Controls.Add(this.panelBottom);
            this.panelChildForm.Controls.Add(this.pictureBox3);
            resources.ApplyResources(this.panelChildForm, "panelChildForm");
            this.panelChildForm.Name = "panelChildForm";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(58)))));
            this.panelBottom.Controls.Add(this.label3);
            this.panelBottom.Controls.Add(this.labelPageName);
            resources.ApplyResources(this.panelBottom, "panelBottom");
            this.panelBottom.Name = "panelBottom";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // labelPageName
            // 
            resources.ApplyResources(this.labelPageName, "labelPageName");
            this.labelPageName.ForeColor = System.Drawing.Color.White;
            this.labelPageName.Name = "labelPageName";
            // 
            // pictureBox3
            // 
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Image = global::ITGROUP.Properties.Resources._58aff217829958a978a4a6d2;
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.panelTop.Controls.Add(this.button_Maximize);
            this.panelTop.Controls.Add(this.button_Minimize);
            this.panelTop.Controls.Add(this.buttonMaximize);
            this.panelTop.Controls.Add(this.button_Close);
            this.panelTop.Controls.Add(this.buttonMinimize);
            this.panelTop.Controls.Add(this.buttonCloseApp);
            resources.ApplyResources(this.panelTop, "panelTop");
            this.panelTop.Name = "panelTop";
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMouseDown);
            // 
            // button_Maximize
            // 
            resources.ApplyResources(this.button_Maximize, "button_Maximize");
            this.button_Maximize.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Maximize.FlatAppearance.BorderSize = 0;
            this.button_Maximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.button_Maximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.button_Maximize.Image = global::ITGROUP.Properties.Resources.window_maximize;
            this.button_Maximize.Name = "button_Maximize";
            this.button_Maximize.UseVisualStyleBackColor = true;
            this.button_Maximize.Click += new System.EventHandler(this.button_Maximize_Click);
            // 
            // button_Minimize
            // 
            resources.ApplyResources(this.button_Minimize, "button_Minimize");
            this.button_Minimize.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Minimize.FlatAppearance.BorderSize = 0;
            this.button_Minimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.button_Minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.button_Minimize.Image = global::ITGROUP.Properties.Resources.window_minimize;
            this.button_Minimize.Name = "button_Minimize";
            this.button_Minimize.UseVisualStyleBackColor = true;
            this.button_Minimize.Click += new System.EventHandler(this.button_Minimize_Click);
            // 
            // buttonMaximize
            // 
            resources.ApplyResources(this.buttonMaximize, "buttonMaximize");
            this.buttonMaximize.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonMaximize.FlatAppearance.BorderSize = 0;
            this.buttonMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.buttonMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonMaximize.Name = "buttonMaximize";
            this.buttonMaximize.UseVisualStyleBackColor = true;
            // 
            // button_Close
            // 
            resources.ApplyResources(this.button_Close, "button_Close");
            this.button_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Close.FlatAppearance.BorderSize = 0;
            this.button_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.button_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button_Close.Image = global::ITGROUP.Properties.Resources.close_white;
            this.button_Close.Name = "button_Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // buttonMinimize
            // 
            resources.ApplyResources(this.buttonMinimize, "buttonMinimize");
            this.buttonMinimize.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonMinimize.FlatAppearance.BorderSize = 0;
            this.buttonMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.buttonMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.UseVisualStyleBackColor = true;
            // 
            // buttonCloseApp
            // 
            resources.ApplyResources(this.buttonCloseApp, "buttonCloseApp");
            this.buttonCloseApp.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCloseApp.FlatAppearance.BorderSize = 0;
            this.buttonCloseApp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.buttonCloseApp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonCloseApp.Name = "buttonCloseApp";
            this.buttonCloseApp.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelSideMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelSideMenu.ResumeLayout(false);
            this.panelUser.ResumeLayout(false);
            this.panelUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelChildForm.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelUser;
        private System.Windows.Forms.Label ulogin;
        private System.Windows.Forms.Button buttonExitUser;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button buttonReports;
        private System.Windows.Forms.Button buttonTasks;
        private System.Windows.Forms.Button buttonClients;
        private System.Windows.Forms.Button buttonProjects;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label labelPageName;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button buttonMaximize;
        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.Button buttonCloseApp;
        private System.Windows.Forms.Button button_Maximize;
        private System.Windows.Forms.Button button_Minimize;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonUsers;
    }
}

