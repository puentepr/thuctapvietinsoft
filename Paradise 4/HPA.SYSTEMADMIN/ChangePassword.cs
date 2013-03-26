using HPA.Common;
using HPA.SQL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HPA.SystemAdmin
{
    public partial class ChangePassword : HPA.Component.Framework.CCommonForm
    {
        public ChangePassword()
        {
            InitializeComponent();
            // set lable
            Control.ControlCollection ctrls = this.Controls;
            UIMessage.LoadLableName(ref ctrls);
        }
        public override bool InitializeData()
        {
            try
            {
                xteUserID.Text = "";
                xteOldPass.Text = "";
                xteNewPass.Text = "";
                xteRetypePass.Text = "";
                myInitialize();
                // events
                myEvents();

                xteUserID.Focus();
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".InitializeData()", null);
                return false;
            }

            return true;
        }
        public override void SetData(object objParam)
        {
            if (objParam != null)
            {
                try
                {
                    this.Text = objParam.ToString();
                }
                catch (Exception e)
                {
                    HPA.Common.Helper.ShowException(e, this.Name + ".SetData()", null);
                    return;
                }
            }
        }
        public override bool Commit()
        {
            // remember current Action State
            HPA.Component.Framework.Base.EActionState eOldActionState = ActionState;
            try
            {
                // switch to COMMITING state
                ActionState = HPA.Component.Framework.Base.EActionState.BUSY;

                // wait-cursor
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    if (DBEngine == null)
                    {
                        string strServer, strDatabase, strUser, strPassword;
                        try
                        {
                            DBConnection dbCon = new DBConnection();
                            dbCon.getDBConnectionInfo(out strServer, out strDatabase, out strUser, out strPassword);
                            DBEngine = new EzSql2(strServer, strDatabase, strUser, strPassword);
                            DBEngine.open();
                        }
                        catch(Exception ex)
                        {
                            HPA.Common.Helper.ShowException(ex, ex.Message, "Commit");
                        }
                    }
                    object objRetVal = DBEngine.execReturnValue("SC_UserPassword_Update",
                                                            "@p_UserName", xteUserID.Text,
                                                            "@p_OldPassword", Encryption.EncryptText(xteOldPass.Text,true),
                                                            "@p_NewPassword", Encryption.EncryptText(xteNewPass.Text,true));
                    int iRetVal = Convert.ToInt32(objRetVal);
                    switch (iRetVal)
                    {
                        case 0:
                            UIMessage.ShowMessage("PASS_CHANGED_SUCCESSFULL",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case 1:
                            UIMessage.ShowMessage("USER_NOT_EXISTS",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            xteUserID.Focus();
                            break;
                        case 2:
                            UIMessage.ShowMessage("PASS_WRONG",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            xteOldPass.Focus();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    throw (ex);
                }

                // restore cursor
                this.Cursor = Cursors.Default;

                // restore action state
                ActionState = eOldActionState;
            }
            catch (Exception e)
            {
                // restore cursor
                this.Cursor = Cursors.Default;

                // show error
                HPA.Common.Helper.ShowException(e, this.Name + ".Commit()", null);

                // restore action state
                ActionState = eOldActionState;

                // unable to commit
                return false;
            }

            // commit successfully
            return true;
        }
        
        private void myEvents()
        {
            xteUserID.TextChanged += new EventHandler(xte_EditValueChanged);
            xteOldPass.TextChanged += new EventHandler(xte_EditValueChanged);
            xteNewPass.TextChanged += new EventHandler(xte_EditValueChanged);
            xteRetypePass.TextChanged += new EventHandler(xte_EditValueChanged);
        }
        private void xte_EditValueChanged(object sender, EventArgs e)
        {
            DirtyData = true;
            btnFWSave.Enabled = true;
        }
        private void myInitialize()
        {
            xteUserID.Text = Microsoft.Win32.Registry.CurrentUser.GetValue("Paradise-HPA").ToString();
            //xteUserID.Properties.ReadOnly = true;
            xteUserID.Enabled = false;
        }
        public override bool OnValidate()
        {
            try
            {

                if (xteNewPass.Text.Trim() != xteRetypePass.Text.Trim())
                {
                    UIMessage.ShowMessage("The new password is not confirm. Please re-enter new password !",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    xteNewPass.Focus();
                    return false;
                }
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".OnValidate()", null);
                return false;
            }

            // validate ok
            return true;
        }
    }
}