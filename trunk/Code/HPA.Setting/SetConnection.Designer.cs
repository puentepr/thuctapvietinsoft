namespace HPA.Setting
{
    partial class SetConnection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblServerName = new DevExpress.XtraEditors.LabelControl();
            this.lblDatabaseName = new DevExpress.XtraEditors.LabelControl();
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            this.lblPassword = new DevExpress.XtraEditors.LabelControl();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnTestConnection = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.lblConnectionText = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // lblServerName
            // 
            this.lblServerName.Location = new System.Drawing.Point(35, 73);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(69, 13);
            this.lblServerName.TabIndex = 0;
            this.lblServerName.Text = "lblServerName";
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.Location = new System.Drawing.Point(35, 98);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(83, 13);
            this.lblDatabaseName.TabIndex = 1;
            this.lblDatabaseName.Text = "lblDatabaseName";
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(35, 122);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(59, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "lblUserName";
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(35, 146);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "lblPassword";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(132, 70);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(150, 21);
            this.txtServerName.TabIndex = 4;
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Location = new System.Drawing.Point(132, 95);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(150, 21);
            this.txtDatabaseName.TabIndex = 5;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(132, 119);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(150, 21);
            this.txtUserName.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(132, 143);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(150, 21);
            this.txtPassword.TabIndex = 7;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(174, 171);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(108, 27);
            this.btnTestConnection.TabIndex = 8;
            this.btnTestConnection.Text = "simpleButton1";
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(35, 214);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 27);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "simpleButton1";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(174, 214);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 27);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "simpleButton1";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblConnectionText
            // 
            this.lblConnectionText.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionText.Location = new System.Drawing.Point(35, 25);
            this.lblConnectionText.Name = "lblConnectionText";
            this.lblConnectionText.Size = new System.Drawing.Size(64, 13);
            this.lblConnectionText.TabIndex = 11;
            this.lblConnectionText.Text = "labelControl1";
            // 
            // SetConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 259);
            this.Controls.Add(this.lblConnectionText);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtDatabaseName);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblDatabaseName);
            this.Controls.Add(this.lblServerName);
            this.Name = "SetConnection";
            this.Text = "Set Connection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblServerName;
        private DevExpress.XtraEditors.LabelControl lblDatabaseName;
        private DevExpress.XtraEditors.LabelControl lblUserName;
        private DevExpress.XtraEditors.LabelControl lblPassword;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private DevExpress.XtraEditors.SimpleButton btnTestConnection;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl lblConnectionText;

    }
}