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
                MessageBox.Show("Thiếu thông tin");
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
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Test Connection string failed!", "Paradise", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StaticVars.ConnectionString = "Server = " + txtServerName.Text.Trim() + SEMICOLON_CHAR +
                                           "Database = " + txtDatabaseName.Text.Trim() + SEMICOLON_CHAR +
                                            "UID = " + txtUserName.Text.Trim() + SEMICOLON_CHAR +
                                             "PWD = " + txtPassword.Text.Trim();
            Methods.WriteFile(Encryption.EncryptText(StaticVars.ConnectionString,true));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private string strServer, strDatabase, strUser, strPassword;
        private string SEMICOLON_CHAR = HPA.Common.CommonConst.SEMICOLON_CHAR;
        private bool isNewConnection = false;

        private void SetConnection_Load(object sender, EventArgs e)
        {
            Control.ControlCollection ctrls = this.Controls;
            HPA.Common.Methods.ChangeLanguage(ref ctrls);
        }

    }
}