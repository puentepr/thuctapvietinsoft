using System;
using System.Windows.Forms;

using HPA.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace HPA.SystemAdmin
{
	public class SetConnection : HPA.Component.Framework.CCommonForm
	{
        bool isNewConnection = false;
        private Button btnTest;
		private Label lblServerName;
		private Label lblDatabaseName;
		private Label lblUserName;
		private Label lblPassword;
		private Label lblConncSetDesc;
		private CheckBox chkEncrypt;
        private TextBox txeServer;
        private TextBox txeDatabase;
        private TextBox txeUsername;
        private TextBox txePassword;
		private System.ComponentModel.IContainer components = null;

		public SetConnection()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
            
		}
        public override void SetData(object objParam)
        {
            try
            {
                if(objParam !=null)
                    this.Text = objParam.ToString();
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".SetData()", null);
                return;
            }
        }
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetConnection));
            this.btnTest = new System.Windows.Forms.Button();
            this.lblServerName = new System.Windows.Forms.Label();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblConncSetDesc = new System.Windows.Forms.Label();
            this.chkEncrypt = new System.Windows.Forms.CheckBox();
            this.txeServer = new System.Windows.Forms.TextBox();
            this.txeDatabase = new System.Windows.Forms.TextBox();
            this.txeUsername = new System.Windows.Forms.TextBox();
            this.txePassword = new System.Windows.Forms.TextBox();
            this.pnlFWCommand.SuspendLayout();
            this.pnlFWClose.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFWCommand
            // 
            resources.ApplyResources(this.pnlFWCommand, "pnlFWCommand");
            // 
            // btnFWDelete
            // 
            this.btnFWDelete.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnFWDelete.Appearance.Font")));
            this.btnFWDelete.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnFWDelete.Appearance.ForeColor")));
            this.btnFWDelete.Appearance.Options.UseFont = true;
            this.btnFWDelete.Appearance.Options.UseForeColor = true;
            this.btnFWDelete.LookAndFeel.SkinName = "Blue";
            this.btnFWDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            resources.ApplyResources(this.btnFWDelete, "btnFWDelete");
            // 
            // btnFWSave
            // 
            this.btnFWSave.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnFWSave.Appearance.Font")));
            this.btnFWSave.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnFWSave.Appearance.ForeColor")));
            this.btnFWSave.Appearance.Options.UseFont = true;
            this.btnFWSave.Appearance.Options.UseForeColor = true;
            resources.ApplyResources(this.btnFWSave, "btnFWSave");
            this.btnFWSave.LookAndFeel.SkinName = "Blue";
            this.btnFWSave.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnFWAdd
            // 
            this.btnFWAdd.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnFWAdd.Appearance.Font")));
            this.btnFWAdd.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnFWAdd.Appearance.ForeColor")));
            this.btnFWAdd.Appearance.Options.UseFont = true;
            this.btnFWAdd.Appearance.Options.UseForeColor = true;
            this.btnFWAdd.LookAndFeel.SkinName = "Blue";
            this.btnFWAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            resources.ApplyResources(this.btnFWAdd, "btnFWAdd");
            // 
            // pnlFWClose
            // 
            resources.ApplyResources(this.pnlFWClose, "pnlFWClose");
            // 
            // btnFWClose
            // 
            this.btnFWClose.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnFWClose.Appearance.Font")));
            this.btnFWClose.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnFWClose.Appearance.ForeColor")));
            this.btnFWClose.Appearance.Options.UseFont = true;
            this.btnFWClose.Appearance.Options.UseForeColor = true;
            this.btnFWClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnFWClose, "btnFWClose");
            this.btnFWClose.LookAndFeel.SkinName = "Blue";
            this.btnFWClose.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFWClose.Click += new System.EventHandler(this.btnFWClose_Click);
            // 
            // lblFWDecorateingLine
            // 
            resources.ApplyResources(this.lblFWDecorateingLine, "lblFWDecorateingLine");
            // 
            // btnFWReset
            // 
            this.btnFWReset.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnFWReset.Appearance.Font")));
            this.btnFWReset.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnFWReset.Appearance.ForeColor")));
            this.btnFWReset.Appearance.Options.UseFont = true;
            this.btnFWReset.Appearance.Options.UseForeColor = true;
            resources.ApplyResources(this.btnFWReset, "btnFWReset");
            this.btnFWReset.LookAndFeel.SkinName = "Blue";
            this.btnFWReset.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnExport
            // 
            this.btnExport.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnExport.Appearance.Font")));
            this.btnExport.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnExport.Appearance.ForeColor")));
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Appearance.Options.UseForeColor = true;
            this.btnExport.LookAndFeel.SkinName = "Blue";
            this.btnExport.LookAndFeel.UseDefaultLookAndFeel = false;
            resources.ApplyResources(this.btnExport, "btnExport");
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.AliceBlue;
            resources.ApplyResources(this.btnTest, "btnTest");
            this.btnTest.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnTest.Name = "btnTest";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblServerName
            // 
            resources.ApplyResources(this.lblServerName, "lblServerName");
            this.lblServerName.Name = "lblServerName";
            // 
            // lblDatabaseName
            // 
            resources.ApplyResources(this.lblDatabaseName, "lblDatabaseName");
            this.lblDatabaseName.Name = "lblDatabaseName";
            // 
            // lblUserName
            // 
            resources.ApplyResources(this.lblUserName, "lblUserName");
            this.lblUserName.Name = "lblUserName";
            // 
            // lblPassword
            // 
            resources.ApplyResources(this.lblPassword, "lblPassword");
            this.lblPassword.Name = "lblPassword";
            // 
            // lblConncSetDesc
            // 
            resources.ApplyResources(this.lblConncSetDesc, "lblConncSetDesc");
            this.lblConncSetDesc.Name = "lblConncSetDesc";
            // 
            // chkEncrypt
            // 
            resources.ApplyResources(this.chkEncrypt, "chkEncrypt");
            this.chkEncrypt.Name = "chkEncrypt";
            // 
            // txeServer
            // 
            resources.ApplyResources(this.txeServer, "txeServer");
            this.txeServer.Name = "txeServer";
            // 
            // txeDatabase
            // 
            resources.ApplyResources(this.txeDatabase, "txeDatabase");
            this.txeDatabase.Name = "txeDatabase";
            // 
            // txeUsername
            // 
            resources.ApplyResources(this.txeUsername, "txeUsername");
            this.txeUsername.Name = "txeUsername";
            // 
            // txePassword
            // 
            resources.ApplyResources(this.txePassword, "txePassword");
            this.txePassword.Name = "txePassword";
            this.txePassword.UseSystemPasswordChar = true;
            // 
            // SetConnection
            // 
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.btnFWClose;
            this.Controls.Add(this.txePassword);
            this.Controls.Add(this.txeUsername);
            this.Controls.Add(this.txeDatabase);
            this.Controls.Add(this.txeServer);
            this.Controls.Add(this.chkEncrypt);
            this.Controls.Add(this.lblServerName);
            this.Controls.Add(this.lblDatabaseName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblConncSetDesc);
            this.Controls.Add(this.btnTest);
            this.LookAndFeel.SkinName = "Seven";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.Name = "SetConnection";
            this.Load += new System.EventHandler(this.SetConnection_Load);
            this.Controls.SetChildIndex(this.btnTest, 0);
            this.Controls.SetChildIndex(this.lblConncSetDesc, 0);
            this.Controls.SetChildIndex(this.lblPassword, 0);
            this.Controls.SetChildIndex(this.lblUserName, 0);
            this.Controls.SetChildIndex(this.lblDatabaseName, 0);
            this.Controls.SetChildIndex(this.pnlFWCommand, 0);
            this.Controls.SetChildIndex(this.lblFWDecorateingLine, 0);
            this.Controls.SetChildIndex(this.lblServerName, 0);
            this.Controls.SetChildIndex(this.chkEncrypt, 0);
            this.Controls.SetChildIndex(this.txeServer, 0);
            this.Controls.SetChildIndex(this.txeDatabase, 0);
            this.Controls.SetChildIndex(this.txeUsername, 0);
            this.Controls.SetChildIndex(this.txePassword, 0);
            this.pnlFWCommand.ResumeLayout(false);
            this.pnlFWClose.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region VARIABLES & CONSTS
		private bool m_bTestStatus = false;
				
		#endregion

		#region PRIVATE METHODS
		public override bool OnSave()
		{
			DBConnection dbCon = null;
			try
			{
				// make new connection object:
				dbCon = new DBConnection();
                if (dbCon.saveConnectionInfo(txeServer.Text, txeDatabase.Text, txeUsername.Text, txePassword.Text, DBConnection.ENCRYPTED))
                {
                    MessageBox.Show(this, "Connection setting has saved successfully. Changes will be applied for the next log on.", "Paradise", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isNewConnection = true;
                }
                else
                    MessageBox.Show(this, "Connection setting can not saved. Please re-install Paradise if you can.", "Paradise", MessageBoxButtons.OK, MessageBoxIcon.Error);

				btnFWSave.Enabled = false;
				dbCon = null;

				// return Good:
				return true;

			}
			catch(Exception exc)
			{
				MessageBox.Show(exc.Message,"Paradise",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
		}

		#endregion

		#region EVENTS
        private void SetConnection_Load(object sender, EventArgs e)
        {

            string strConnection = "";
            SqlConnection connection;
            SqlCommand cmd;
            string strCreateUser = "";
            string strAttachDB = "";

            string strServer, strDatabase, strUser, strPassword, strEncrypted;
            DBConnection dbCon = null;
            try
            {
                //Connect to Master Database
                //strConnection = @"Data Source=.\SQLExpress;Initial Catalog=master;User Id=sa;Password=123;";
                // register dll for zk SDK
                if (!System.IO.File.Exists("Paradise.ini"))
                {
                    Process.Start(@"C:\windows\system32\RegiszkDll.bat");
                    strConnection = @"Data Source=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
                    connection = new SqlConnection(strConnection);
                    connection.Open();
                    //Attach Database file
                    cmd = new SqlCommand("if exists (select 1 from sys.databases where Name = 'Att_VTS') EXEC master.dbo.sp_detach_db N'Att_VTS','true'", connection);
                    cmd.ExecuteNonQuery();

                    strAttachDB = @"if not exists (select 1 from sys.databases  where name = 'Att_VTS') CREATE DATABASE [Att_VTS] ON ( FILENAME = N'C:\Windows\Att_VTS.mdf' ),( FILENAME = N'C:\Windows\Att_VTS_log.ldf' ) FOR ATTACH ";
                    cmd = new SqlCommand(strAttachDB, connection);
                    cmd.ExecuteNonQuery();
                    //Create new login name saFree, Pass:LuaThiengFree
                    //Retry to connect new SQL String again
                    strCreateUser = @"if not exists (select 1 from master.dbo.syslogins where name = 'SaFree') CREATE LOGIN saFree WITH PASSWORD=N'LuaThiengFree', DEFAULT_DATABASE=[Att_VTS], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF;";
                    cmd = new SqlCommand(strCreateUser, connection);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("EXEC master..sp_addsrvrolemember @loginame = N'saFree', @rolename = N'sysadmin'", connection);
                    cmd.ExecuteNonQuery();
                    try
                    {
                        cmd = new SqlCommand(@"xp_regwrite N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\Microsoft SQL Server\MSSQL.1\MSSQLServer', N'LoginMode', REG_DWORD, 2", connection);
                        cmd.ExecuteNonQuery();
                    }
                    catch { }
                    try
                    {
                        cmd = new SqlCommand(@"xp_regwrite N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\Microsoft SQL Server\MSSQL.2\MSSQLServer', N'LoginMode', REG_DWORD, 2", connection);
                        cmd.ExecuteNonQuery();
                    }
                    catch { }
                    try
                    {
                        cmd = new SqlCommand(@"xp_regwrite N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\Microsoft SQL Server\MSSQL.3\MSSQLServer', N'LoginMode', REG_DWORD, 2", connection);
                        cmd.ExecuteNonQuery();
                    }
                    catch { }
                    connection.Close();
                    strServer = @".\SQLEXPRESS";
                    strDatabase = "Att_VTS";
                    strUser = "saFree";
                    strPassword = "LuaThiengFree";
                    strEncrypted = DBConnection.NO_ENCRYPTED;
                    dbCon = new DBConnection();
                    dbCon.saveConnectionInfo(strServer, strDatabase, strUser, strPassword, DBConnection.ENCRYPTED);
                    //Reset computer
                    if (MessageBox.Show("Need restart compurter to complete the First configuration. Do you want to restart your computer?", "Vietinsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        Process.Start("ShutDown", "/r /t 000");
                    else
                        Application.Exit();
                }
                dbCon = new DBConnection();
                dbCon.getDBConnectionInfo(out strServer, out strDatabase, out strUser, out strPassword, out strEncrypted);
            }
            catch 
            {
                strServer = @".\SQLEXPRESS";
                strDatabase = "Att_VTS";
                strUser = "saFree";
                strPassword = "LuaThiengFree";
                strEncrypted = DBConnection.NO_ENCRYPTED;
                dbCon = new DBConnection();
                dbCon.saveConnectionInfo(strServer, strDatabase, strUser, strPassword, DBConnection.ENCRYPTED);
            }

            //			ConnectionString cs = new ConnectionString();
            //			cs.GetConnectParam();
            //			cs.GetParam(out strServer, out strDatabase, out strUser, out strPassword, out strEncrypted);
            //			
            txeServer.Text = strServer;
            txeDatabase.Text = strDatabase;
            txeUsername.Text = strUser;
            txePassword.Text = strPassword;
            if (strEncrypted.Trim() == DBConnection.ENCRYPTED)
                chkEncrypt.Checked = true;
            else
                chkEncrypt.Checked = false;

            dbCon = null;
            // load language interface
            if ((strServer != null) && (!string.Empty.Equals(strServer)))
            {
                Control.ControlCollection ctrls = this.Controls;
                UIMessage.LoadLableName(ref ctrls);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            // ConnectionString cs = new ConnectionString(txeServer.Text, txeDatabase.Text, txeUsername.Text, txePassword.Text);
            DBConnection dbCon = new DBConnection(txeServer.Text, txeDatabase.Text, txeUsername.Text, txePassword.Text);
            //m_bTestStatus = cs.TestConnection();
            m_bTestStatus = dbCon.checkConnectionInfo();
            if (m_bTestStatus == true)
            {
                MessageBox.Show(this, "Test Connection string successfully!", "Paradise", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnFWSave.Enabled = true;
            }
            else
                MessageBox.Show(this, "Test Connection string failed!", "Paradise", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //btnFWSave.Focus();
        }

		#endregion

        private void btnFWClose_Click(object sender, EventArgs e)
        {
            if(isNewConnection)
                Application.Restart();
        }


    }
}

