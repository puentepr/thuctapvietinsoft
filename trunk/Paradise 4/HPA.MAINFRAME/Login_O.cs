using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using HPA.Common;

namespace HPA.MainFrame
{
	/// <summary>
	/// Summary description for Login.
	/// </summary>
	public class Login_O : HPA.Component.Framework.CBaseForm
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lblUserName;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        public Button btnLogin;
        protected System.Windows.Forms.Button btnCancel;
        private Label lblApplicationName;
        private IContainer components;

		public Login_O()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            Control.ControlCollection ctrs = this.Controls;
            UIMessage.LoadLableName(ref ctrs);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
            if(UIMessage.LoginWallpaper != null&& !UIMessage.LoginWallpaper.Equals(string.Empty))
                this.BackgroundImage = System.Drawing.Image.FromFile(UIMessage.LoginWallpaper);
		}
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    if ((int)m.Result == HTCLIENT)
                        m.Result = (IntPtr)HTCAPTION;
                    return;
            }
            base.WndProc(ref m);
        } 
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_O));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblApplicationName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(82, 131);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Snow;
            this.lblUserName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.Black;
            this.lblUserName.Location = new System.Drawing.Point(69, 190);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(67, 13);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "User name";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Snow;
            this.lblPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.Black;
            this.lblPassword.Location = new System.Drawing.Point(69, 219);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(151, 186);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(126, 21);
            this.txtUserName.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(151, 215);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(126, 21);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.AutoSize = true;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLogin.Location = new System.Drawing.Point(72, 243);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(117, 31);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(190, 243);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 29);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblApplicationName
            // 
            this.lblApplicationName.AutoSize = true;
            this.lblApplicationName.BackColor = System.Drawing.Color.Snow;
            this.lblApplicationName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblApplicationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationName.ForeColor = System.Drawing.Color.Black;
            this.lblApplicationName.Location = new System.Drawing.Point(383, 67);
            this.lblApplicationName.Name = "lblApplicationName";
            this.lblApplicationName.Size = new System.Drawing.Size(67, 13);
            this.lblApplicationName.TabIndex = 1;
            this.lblApplicationName.Text = "User name";
            this.lblApplicationName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Login_O
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(672, 554);
            this.ControlBox = false;
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblApplicationName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.btnCancel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Seven";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "Login_O";
            this.Opacity = 0.8D;
            this.Text = "";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
        protected HPA.Common.Framework.CRunableObjectManager m_objManager = new HPA.Common.Framework.CRunableObjectManager();
		private void btnLogin_Click(object sender, System.EventArgs e)
		{
            // For free data base
            // DBEngine.exec("delete tblEmployee where EmployeeID not in (select top 50 employeeID from tblEmployee)");
            //end
			DBEngine.exec("SC_Login_CheckLogin", "@LoginName", txtUserName.Text, "@PassWord", HPA.Common.Encryption.EncryptText(txtPassword.Text,true));
			UserID = DBEngine.getReturnValue();
			if (Convert.ToInt32(DBEngine.getReturnValue()) == -1)
			{
				UIMessage.Alert(54);
				txtUserName.Focus();
				return;
			}
			else if (Convert.ToInt32(DBEngine.getReturnValue()) == -2)
			{
				UIMessage.Alert(55);
				txtPassword.Focus();
				return;
			}
            else if (Convert.ToInt32(DBEngine.getReturnValue()) == -3)// password was expired
            {
                UIMessage.Alert(99);
                object o;
                HPA.SystemAdmin.ChangePassword changePass = new HPA.SystemAdmin.ChangePassword();
                changePass.AccessibleName = "HPA.Component.SystemAdmin";
                changePass.ClassName = "frmChangesPassword";
                m_objManager.OpenObject(changePass, true, null, out o);
                return;
            }
			UserName = txtUserName.Text;			
			DialogResult = DialogResult.OK;
			Microsoft.Win32.Registry.CurrentUser.SetValue("Paradise-HPA", UserName);
            UIMessage.userID = UserID;
            //UIMessage.languageID = Application.CurrentCulture.TwoLetterISOLanguageName.ToUpper();
			this.Close();
		}

        private const byte DELTA_KEY = 71;
        private string EncodeString(string data)
        {
            string strRet = string.Empty;
            try
            {
                for (int i = 0; i < data.Length; i++)
                {
                    strRet += (char)(((byte)data[i] + DELTA_KEY) % 256);
                }
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.LogError(ex, ex.Message, this.Text);

            }
            return strRet;
        }
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			
		}

		private void Login_Load(object sender, System.EventArgs e)
		{
            try
            {
                object o = Microsoft.Win32.Registry.CurrentUser.GetValue("Paradise-HPA");
                if (o != null)
                {
                    txtUserName.Text = o.ToString();
                    txtPassword.Focus();
                }
                else
                {
                    txtUserName.Text = string.Empty;
                    txtUserName.Focus();
                }
                lblApplicationName.Text = UIMessage.Get_Message(lblApplicationName.Name);
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Text, "Login_Load");
            }
		}

      

	}
}
