namespace HPA.Setting
{
    partial class UserRight
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
            this.components = new System.ComponentModel.Container();
            this.grbUserInfo = new System.Windows.Forms.GroupBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.lblPassword = new DevExpress.XtraEditors.LabelControl();
            this.lblDepartment = new DevExpress.XtraEditors.LabelControl();
            this.lblLoginAccount = new DevExpress.XtraEditors.LabelControl();
            this.lblEmployeeID = new DevExpress.XtraEditors.LabelControl();
            this.grbDepartment = new System.Windows.Forms.GroupBox();
            this.ckbAllDepartment = new DevExpress.XtraEditors.CheckEdit();
            this.grdDepartment = new DevExpress.XtraGrid.GridControl();
            this.grvDepartment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grbSection = new System.Windows.Forms.GroupBox();
            this.grdSection = new DevExpress.XtraGrid.GridControl();
            this.grvSection = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSectionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSectionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSectViewInfo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ckbSectionAll = new DevExpress.XtraEditors.CheckEdit();
            this.grbModule = new System.Windows.Forms.GroupBox();
            this.trlObjectList = new DevExpress.XtraTreeList.TreeList();
            this.tclDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcRight = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ckbAllModule = new DevExpress.XtraEditors.CheckEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnFWReset = new DevExpress.XtraEditors.SimpleButton();
            this.btnFWSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnFWDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnFWAdd = new DevExpress.XtraEditors.SimpleButton();
            this.Repository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grbUserInfo.SuspendLayout();
            this.grbDepartment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckbAllDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDepartment)).BeginInit();
            this.grbSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbSectionAll.Properties)).BeginInit();
            this.grbModule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trlObjectList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbAllModule.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbUserInfo
            // 
            this.grbUserInfo.Controls.Add(this.txtDepartment);
            this.grbUserInfo.Controls.Add(this.txtPassword);
            this.grbUserInfo.Controls.Add(this.txtLoginName);
            this.grbUserInfo.Controls.Add(this.txtFullName);
            this.grbUserInfo.Controls.Add(this.txtEmployeeID);
            this.grbUserInfo.Controls.Add(this.lblPassword);
            this.grbUserInfo.Controls.Add(this.lblDepartment);
            this.grbUserInfo.Controls.Add(this.lblLoginAccount);
            this.grbUserInfo.Controls.Add(this.lblEmployeeID);
            this.grbUserInfo.Location = new System.Drawing.Point(13, 22);
            this.grbUserInfo.Name = "grbUserInfo";
            this.grbUserInfo.Size = new System.Drawing.Size(470, 128);
            this.grbUserInfo.TabIndex = 0;
            this.grbUserInfo.TabStop = false;
            this.grbUserInfo.Text = "Information";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(141, 92);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(317, 21);
            this.txtDepartment.TabIndex = 8;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(141, 68);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 21);
            this.txtPassword.TabIndex = 7;
            // 
            // txtLoginName
            // 
            this.txtLoginName.Location = new System.Drawing.Point(141, 43);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(100, 21);
            this.txtLoginName.TabIndex = 6;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(249, 19);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(209, 21);
            this.txtFullName.TabIndex = 5;
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtEmployeeID.Location = new System.Drawing.Point(141, 19);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(100, 21);
            this.txtEmployeeID.TabIndex = 4;
            this.txtEmployeeID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtEmployeeID_KeyUp);
            this.txtEmployeeID.Leave += new System.EventHandler(this.txtEmployeeID_Leave);
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(15, 71);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(63, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "labelControl1";
            // 
            // lblDepartment
            // 
            this.lblDepartment.Location = new System.Drawing.Point(15, 95);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(63, 13);
            this.lblDepartment.TabIndex = 2;
            this.lblDepartment.Text = "labelControl1";
            // 
            // lblLoginAccount
            // 
            this.lblLoginAccount.Location = new System.Drawing.Point(15, 46);
            this.lblLoginAccount.Name = "lblLoginAccount";
            this.lblLoginAccount.Size = new System.Drawing.Size(63, 13);
            this.lblLoginAccount.TabIndex = 1;
            this.lblLoginAccount.Text = "labelControl1";
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.Location = new System.Drawing.Point(15, 22);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(63, 13);
            this.lblEmployeeID.TabIndex = 0;
            this.lblEmployeeID.Text = "labelControl1";
            // 
            // grbDepartment
            // 
            this.grbDepartment.Controls.Add(this.ckbAllDepartment);
            this.grbDepartment.Controls.Add(this.grdDepartment);
            this.grbDepartment.Location = new System.Drawing.Point(13, 157);
            this.grbDepartment.Name = "grbDepartment";
            this.grbDepartment.Size = new System.Drawing.Size(319, 229);
            this.grbDepartment.TabIndex = 1;
            this.grbDepartment.TabStop = false;
            this.grbDepartment.Text = "Department";
            // 
            // ckbAllDepartment
            // 
            this.ckbAllDepartment.Location = new System.Drawing.Point(238, 12);
            this.ckbAllDepartment.Name = "ckbAllDepartment";
            this.ckbAllDepartment.Properties.Caption = "All";
            this.ckbAllDepartment.Size = new System.Drawing.Size(75, 19);
            this.ckbAllDepartment.TabIndex = 1;
            // 
            // grdDepartment
            // 
            this.grdDepartment.Location = new System.Drawing.Point(6, 37);
            this.grdDepartment.MainView = this.grvDepartment;
            this.grdDepartment.Name = "grdDepartment";
            this.grdDepartment.Size = new System.Drawing.Size(307, 186);
            this.grdDepartment.TabIndex = 0;
            this.grdDepartment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDepartment});
            // 
            // grvDepartment
            // 
            this.grvDepartment.GridControl = this.grdDepartment;
            this.grvDepartment.Name = "grvDepartment";
            // 
            // grbSection
            // 
            this.grbSection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grbSection.Controls.Add(this.grdSection);
            this.grbSection.Controls.Add(this.ckbSectionAll);
            this.grbSection.Location = new System.Drawing.Point(13, 392);
            this.grbSection.Name = "grbSection";
            this.grbSection.Size = new System.Drawing.Size(319, 186);
            this.grbSection.TabIndex = 2;
            this.grbSection.TabStop = false;
            this.grbSection.Text = "Section";
            // 
            // grdSection
            // 
            this.grdSection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdSection.Location = new System.Drawing.Point(7, 31);
            this.grdSection.MainView = this.grvSection;
            this.grdSection.Name = "grdSection";
            this.grdSection.Size = new System.Drawing.Size(306, 149);
            this.grdSection.TabIndex = 0;
            this.grdSection.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSection});
            // 
            // grvSection
            // 
            this.grvSection.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.grvSection.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvSection.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSectionCode,
            this.colSectionName,
            this.colSectViewInfo});
            this.grvSection.GridControl = this.grdSection;
            this.grvSection.Name = "grvSection";
            // 
            // colSectionCode
            // 
            this.colSectionCode.Caption = "Section code";
            this.colSectionCode.Name = "colSectionCode";
            this.colSectionCode.Visible = true;
            this.colSectionCode.VisibleIndex = 0;
            // 
            // colSectionName
            // 
            this.colSectionName.Caption = "Section";
            this.colSectionName.Name = "colSectionName";
            this.colSectionName.Visible = true;
            this.colSectionName.VisibleIndex = 1;
            // 
            // colSectViewInfo
            // 
            this.colSectViewInfo.Caption = "Section view info";
            this.colSectViewInfo.Name = "colSectViewInfo";
            this.colSectViewInfo.Visible = true;
            this.colSectViewInfo.VisibleIndex = 2;
            // 
            // ckbSectionAll
            // 
            this.ckbSectionAll.Location = new System.Drawing.Point(238, 12);
            this.ckbSectionAll.Name = "ckbSectionAll";
            this.ckbSectionAll.Properties.Caption = "All";
            this.ckbSectionAll.Size = new System.Drawing.Size(75, 19);
            this.ckbSectionAll.TabIndex = 1;
            // 
            // grbModule
            // 
            this.grbModule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbModule.Controls.Add(this.trlObjectList);
            this.grbModule.Controls.Add(this.ckbAllModule);
            this.grbModule.Location = new System.Drawing.Point(338, 156);
            this.grbModule.Name = "grbModule";
            this.grbModule.Size = new System.Drawing.Size(532, 422);
            this.grbModule.TabIndex = 3;
            this.grbModule.TabStop = false;
            this.grbModule.Text = "Module";
            // 
            // trlObjectList
            // 
            this.trlObjectList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tclDescription,
            this.tlcRight});
            this.trlObjectList.Location = new System.Drawing.Point(6, 38);
            this.trlObjectList.Name = "trlObjectList";
            this.trlObjectList.OptionsPrint.UsePrintStyles = true;
            this.trlObjectList.Size = new System.Drawing.Size(520, 378);
            this.trlObjectList.TabIndex = 3;
            // 
            // tclDescription
            // 
            this.tclDescription.Caption = "Description";
            this.tclDescription.FieldName = "Description";
            this.tclDescription.Name = "tclDescription";
            this.tclDescription.Visible = true;
            this.tclDescription.VisibleIndex = 0;
            this.tclDescription.Width = 287;
            // 
            // tlcRight
            // 
            this.tlcRight.Caption = "Right";
            this.tlcRight.FieldName = "treeListColumn1";
            this.tlcRight.Name = "tlcRight";
            this.tlcRight.Visible = true;
            this.tlcRight.VisibleIndex = 1;
            this.tlcRight.Width = 215;
            // 
            // ckbAllModule
            // 
            this.ckbAllModule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbAllModule.Location = new System.Drawing.Point(415, 13);
            this.ckbAllModule.Name = "ckbAllModule";
            this.ckbAllModule.Properties.Caption = "All";
            this.ckbAllModule.Size = new System.Drawing.Size(111, 19);
            this.ckbAllModule.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.btnFWReset);
            this.groupBox1.Controls.Add(this.btnFWSave);
            this.groupBox1.Controls.Add(this.btnFWDelete);
            this.groupBox1.Controls.Add(this.btnFWAdd);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 578);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(880, 49);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(389, 11);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(107, 32);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "simpleButton5";
            // 
            // btnFWReset
            // 
            this.btnFWReset.Enabled = false;
            this.btnFWReset.Location = new System.Drawing.Point(308, 12);
            this.btnFWReset.Name = "btnFWReset";
            this.btnFWReset.Size = new System.Drawing.Size(75, 32);
            this.btnFWReset.TabIndex = 3;
            this.btnFWReset.Text = "simpleButton4";
            // 
            // btnFWSave
            // 
            this.btnFWSave.Enabled = false;
            this.btnFWSave.Location = new System.Drawing.Point(227, 12);
            this.btnFWSave.Name = "btnFWSave";
            this.btnFWSave.Size = new System.Drawing.Size(75, 32);
            this.btnFWSave.TabIndex = 2;
            this.btnFWSave.Text = "simpleButton3";
            // 
            // btnFWDelete
            // 
            this.btnFWDelete.Location = new System.Drawing.Point(146, 12);
            this.btnFWDelete.Name = "btnFWDelete";
            this.btnFWDelete.Size = new System.Drawing.Size(75, 32);
            this.btnFWDelete.TabIndex = 1;
            this.btnFWDelete.Text = "simpleButton2";
            // 
            // btnFWAdd
            // 
            this.btnFWAdd.Location = new System.Drawing.Point(65, 12);
            this.btnFWAdd.Name = "btnFWAdd";
            this.btnFWAdd.Size = new System.Drawing.Size(75, 32);
            this.btnFWAdd.TabIndex = 0;
            this.btnFWAdd.Text = "simpleButton1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(502, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(362, 128);
            this.dataGridView1.TabIndex = 5;
            // 
            // UserRight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 627);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbModule);
            this.Controls.Add(this.grbSection);
            this.Controls.Add(this.grbDepartment);
            this.Controls.Add(this.grbUserInfo);
            this.Name = "UserRight";
            this.Text = "UserRight";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UserRight_Load);
            this.grbUserInfo.ResumeLayout(false);
            this.grbUserInfo.PerformLayout();
            this.grbDepartment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ckbAllDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDepartment)).EndInit();
            this.grbSection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbSectionAll.Properties)).EndInit();
            this.grbModule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trlObjectList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbAllModule.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbUserInfo;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtLoginName;
        private System.Windows.Forms.TextBox txtEmployeeID;
        private DevExpress.XtraEditors.LabelControl lblPassword;
        private DevExpress.XtraEditors.LabelControl lblDepartment;
        private DevExpress.XtraEditors.LabelControl lblLoginAccount;
        private DevExpress.XtraEditors.LabelControl lblEmployeeID;
        private System.Windows.Forms.GroupBox grbDepartment;
        private DevExpress.XtraEditors.CheckEdit ckbAllDepartment;
        private DevExpress.XtraGrid.GridControl grdDepartment;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDepartment;
        private System.Windows.Forms.GroupBox grbSection;
        private DevExpress.XtraEditors.CheckEdit ckbSectionAll;
        private System.Windows.Forms.GroupBox grbModule;
        private DevExpress.XtraEditors.CheckEdit ckbAllModule;
        private DevExpress.XtraGrid.GridControl grdSection;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSection;
        private DevExpress.XtraGrid.Columns.GridColumn colSectionCode;
        private DevExpress.XtraGrid.Columns.GridColumn colSectionName;
        private DevExpress.XtraGrid.Columns.GridColumn colSectViewInfo;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnFWReset;
        private DevExpress.XtraEditors.SimpleButton btnFWSave;
        private DevExpress.XtraEditors.SimpleButton btnFWDelete;
        private DevExpress.XtraEditors.SimpleButton btnFWAdd;
        private DevExpress.XtraTreeList.TreeList trlObjectList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tclDescription;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcRight;
        private DevExpress.XtraEditors.Repository.PersistentRepository Repository;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}