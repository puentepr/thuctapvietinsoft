using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HPA.Common;

namespace HPA.MAINFRAME
{
    public partial class Login : HPA.CommonForm.BaseUserControl
    {
        public bool LoginSuccess = false;
        public Login()
        {
            InitializeComponent();
            //Show last user name
            txtUserName.Text = StaticVars.UserName;
            if (!txtUserName.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    DataTable dtLoginImage = DBEngine.execReturnDataTable("SC_GetLoginImage", "@LoginName", txtUserName.Text.Trim());
                    picLoginPic.DataBindings.Clear();
                    picLoginPic.DataBindings.Add(CommonConst.EDIT_VALUE, dtLoginImage, "PhotoImage");
                }
                catch (Exception ex)
                {
                    Methods.ShowError(ex);
                }
            }
            txtPassword.Focus();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            HPA.SQL.DataDaigramDataContext dt = new SQL.DataDaigramDataContext();
            string pa = HPA.Common.Encryption.EncryptText(txtPassword.Text, true);
            if (!HPA.Common.StaticVars.UserName.Trim().Equals(string.Empty))
            {
                if (!txtUserName.Text.Trim().Equals(HPA.Common.StaticVars.UserName.Trim()))
                {
                    LOGIN_FAILURE.Text = string.Format(Methods.GetMessage("SESSION_CONFLICT"), HPA.Common.StaticVars.UserName); ;
                }
            }
            int Loginid = dt.SC_Login_CheckLogin(txtUserName.Text.Trim(), pa);
            if (Loginid == -1 || Loginid == -2)
            {
                LOGIN_FAILURE.Text = Methods.GetMessage(LOGIN_FAILURE.Name);
                LOGIN_FAILURE.Visible = true;
                txtUserName.Focus();
                LoginSuccess = false;
            }
            else
            {
                LOGIN_FAILURE.Visible = false;
                HPA.Common.StaticVars.LoginID = Loginid;
                HPA.Common.StaticVars.UserName = txtUserName.Text;
                LoginSuccess = true;
                this.Visible = false;
            }
        }
    }
}
