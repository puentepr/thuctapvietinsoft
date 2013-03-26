using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HPA.Common;

namespace HPA.MAINFRAME
{
    public partial class Login : HPA.Component.Framework.CBaseForm
    {
        public Login()
        {
            InitializeComponent();
            //Show background image
            if (UIMessage.LoginWallpaper != null && !UIMessage.LoginWallpaper.Equals(string.Empty))
            {
                splitContainer1.BackgroundImage = System.Drawing.Image.FromFile(UIMessage.LoginWallpaper);
                splitContainer2.BackgroundImage = System.Drawing.Image.FromFile(UIMessage.LoginWallpaper);
            }
            Control.ControlCollection ctrs = this.Controls;
            UIMessage.LoadLableName(ref ctrs);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                //can chinh lai postion cho dep
                splitContainer1.SplitterDistance = (this.Height - 400) / 2;
                splitContainer3.SplitterDistance = (this.Width - 418) / 2;
                object o = Microsoft.Win32.Registry.CurrentUser.GetValue("Paradise-HPA");
                if (o != null)
                {
                    txtUserName.Text = o.ToString();
                    DataTable dtLoginImage = DBEngine.execReturnDataTable("SC_GetLoginImage", "@LoginName", txtUserName.Text.Trim());
                    picLoginPic.DataBindings.Clear();
                    picLoginPic.DataBindings.Add(CommonConst.EDIT_VALUE, dtLoginImage, "PhotoImage");
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
        protected HPA.Common.Framework.CRunableObjectManager m_objManager = new HPA.Common.Framework.CRunableObjectManager();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DBEngine.exec("SC_Login_CheckLogin", "@LoginName", txtUserName.Text, "@PassWord", HPA.Common.Encryption.EncryptText(txtPassword.Text, true));
                UserID = DBEngine.getReturnValue();
                if (Convert.ToInt32(UserID) == -1 || Convert.ToInt32(UserID) == -2)
                {
                    LOGIN_FAILURE.Text = HPA.Common.UIMessage.Get_Message(LOGIN_FAILURE.Name);
                    LOGIN_FAILURE.Visible = true;
                    txtUserName.Focus();
                    return;
                }
                else if (Convert.ToInt32(UserID) == -3)// password was expired
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
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Text, "btnLogin_Click");
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;
            Application.Exit();
        }
    }
}