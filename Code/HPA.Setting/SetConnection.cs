using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using HPA.SQL;
using HPA.Common;

namespace HPA.Setting
{
    public partial class SetConnection : DevExpress.XtraEditors.XtraForm
    {
        public SetConnection()
        {
            InitializeComponent();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            strServer = txtServerName.Text.Trim();
            strDatabase = txtDatabaseName.Text.Trim();
            strUser = txtUserName.Text.Trim();
            strPassword = txtPassword.Text.Trim();
            if (strServer == "" || strDatabase == "" || strUser == "")
            {
                MessageBox.Show(this, "Test Connection string failed!", "Paradise", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    EzSqlCollection.EzSql2 ezsql2 = new EzSqlCollection.EzSql2(strServer, strDatabase, strUser, strPassword);
                    ezsql2.open();
                    ezsql2.close();
                    MessageBox.Show(this, "Test Connection string successfully!", "Paradise", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show(this, "Test Connection string failed!", "Paradise", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StaticVars.ConnectionString = String.Format("Server = {0}{1}Database = {2}{1}UID = {3}{1}PWD = {4}", txtServerName.Text.Trim(), SEMICOLON_CHAR, txtDatabaseName.Text.Trim(), txtUserName.Text.Trim(), txtPassword.Text.Trim());

            try
            {
                EzSqlCollection.EzSql2 ezsql2 = new EzSqlCollection.EzSql2(txtServerName.Text.Trim(),
                                                                            txtDatabaseName.Text.Trim(),
                                                                            txtUserName.Text.Trim(),
                                                                            txtPassword.Text.Trim());
                ezsql2.open();
                ezsql2.close();
                Methods.WriteFile(Encryption.EncryptText(StaticVars.ConnectionString, true));
                MessageBox.Show(this, "Connection setting has saved successfully. Changes will be applied for the next log on.", "Paradise", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(this, "Connection setting can not saved. Please re-install Paradise if you can.", "Paradise", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            isNewConnection = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!isNewConnection)
            {
                try
                {
                    EzSqlCollection.EzSql2 ezsql2 = new EzSqlCollection.EzSql2(txtServerName.Text.Trim(),
                                                                                txtDatabaseName.Text.Trim(),
                                                                                txtUserName.Text.Trim(),
                                                                                txtPassword.Text.Trim());
                    ezsql2.open();
                    ezsql2.close();
                    Application.Restart();
                }
                catch
                {
                    MessageBox.Show(this, "Connection setting is not available.", "Paradise", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                Application.Exit();
        }

        private string strServer, strDatabase, strUser, strPassword;
        private string SEMICOLON_CHAR = HPA.Common.CommonConst.SEMICOLON_CHAR;
        private bool isNewConnection = true;

        private void SetConnection_Load(object sender, EventArgs e)
        {
            txtServerName.Focus();
            Control.ControlCollection ctrls = this.Controls;
            HPA.Common.Methods.ChangeLanguage(ref ctrls);
            
        }

    }
}