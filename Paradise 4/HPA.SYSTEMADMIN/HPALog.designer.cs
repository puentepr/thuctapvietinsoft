namespace HPA.SystemAdmin
{
    partial class HPALog
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckbAllEmployees = new System.Windows.Forms.CheckBox();
            this.dtpToDate = new DevExpress.XtraEditors.DateEdit();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpFromdate = new DevExpress.XtraEditors.DateEdit();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.txtFullName = new DevExpress.XtraEditors.TextEdit();
            this.txtEmployeeID = new DevExpress.XtraEditors.TextEdit();
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.cbxFunctionName = new DevExpress.XtraEditors.LookUpEdit();
            this.lblFunctionName = new System.Windows.Forms.Label();
            this.grdSCLogList = new DevExpress.XtraGrid.GridControl();
            this.grvSC_log = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLoginID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoginName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.comLogDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFunctionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOldData = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNewData = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKindOfData = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlFWCommand.SuspendLayout();
            this.pnlFWClose.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromdate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromdate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxFunctionName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSCLogList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSC_log)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFWCommand
            // 
            this.pnlFWCommand.Size = new System.Drawing.Size(701, 38);
            // 
            // btnFWDelete
            // 
            this.btnFWDelete.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWDelete.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWDelete.Appearance.Options.UseFont = true;
            this.btnFWDelete.Appearance.Options.UseForeColor = true;
            this.btnFWDelete.LookAndFeel.SkinName = "Blue";
            this.btnFWDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFWDelete.Visible = false;
            // 
            // btnFWSave
            // 
            this.btnFWSave.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWSave.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWSave.Appearance.Options.UseFont = true;
            this.btnFWSave.Appearance.Options.UseForeColor = true;
            this.btnFWSave.LookAndFeel.SkinName = "Blue";
            this.btnFWSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFWSave.Visible = false;
            // 
            // btnFWAdd
            // 
            this.btnFWAdd.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWAdd.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWAdd.Appearance.Options.UseFont = true;
            this.btnFWAdd.Appearance.Options.UseForeColor = true;
            this.btnFWAdd.LookAndFeel.SkinName = "Blue";
            this.btnFWAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFWAdd.Visible = false;
            // 
            // pnlFWClose
            // 
            this.pnlFWClose.Location = new System.Drawing.Point(550, 0);
            // 
            // btnFWClose
            // 
            this.btnFWClose.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWClose.Appearance.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btnFWClose.Appearance.Options.UseFont = true;
            this.btnFWClose.Appearance.Options.UseForeColor = true;
            this.btnFWClose.LookAndFeel.SkinName = "Blue";
            this.btnFWClose.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // lblFWDecorateingLine
            // 
            this.lblFWDecorateingLine.Size = new System.Drawing.Size(701, 2);
            // 
            // btnFWReset
            // 
            this.btnFWReset.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWReset.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWReset.Appearance.Options.UseFont = true;
            this.btnFWReset.Appearance.Options.UseForeColor = true;
            this.btnFWReset.LookAndFeel.SkinName = "Blue";
            this.btnFWReset.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFWReset.Visible = false;
            // 
            // btnExport
            // 
            this.btnExport.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnExport.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Appearance.Options.UseForeColor = true;
            this.btnExport.LookAndFeel.SkinName = "Blue";
            this.btnExport.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExport.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ckbAllEmployees);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.lblToDate);
            this.groupBox1.Controls.Add(this.dtpFromdate);
            this.groupBox1.Controls.Add(this.lblFromDate);
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this.txtFullName);
            this.groupBox1.Controls.Add(this.txtEmployeeID);
            this.groupBox1.Controls.Add(this.lblEmployeeID);
            this.groupBox1.Controls.Add(this.cbxFunctionName);
            this.groupBox1.Controls.Add(this.lblFunctionName);
            this.groupBox1.Location = new System.Drawing.Point(6, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(692, 87);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            // 
            // ckbAllEmployees
            // 
            this.ckbAllEmployees.AutoSize = true;
            this.ckbAllEmployees.Location = new System.Drawing.Point(374, 64);
            this.ckbAllEmployees.Name = "ckbAllEmployees";
            this.ckbAllEmployees.Size = new System.Drawing.Size(90, 17);
            this.ckbAllEmployees.TabIndex = 10;
            this.ckbAllEmployees.Text = "All employees";
            this.ckbAllEmployees.UseVisualStyleBackColor = true;
            this.ckbAllEmployees.CheckedChanged += new System.EventHandler(this.ckbAllEmployees_CheckedChanged);
            // 
            // dtpToDate
            // 
            this.dtpToDate.EditValue = null;
            this.dtpToDate.Location = new System.Drawing.Point(120, 38);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpToDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpToDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpToDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpToDate.Size = new System.Drawing.Size(131, 20);
            this.dtpToDate.TabIndex = 7;
            this.dtpToDate.Tag = "";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(8, 41);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(77, 13);
            this.lblToDate.TabIndex = 6;
            this.lblToDate.Text = "Changed date:";
            // 
            // dtpFromdate
            // 
            this.dtpFromdate.EditValue = null;
            this.dtpFromdate.Location = new System.Drawing.Point(120, 14);
            this.dtpFromdate.Name = "dtpFromdate";
            this.dtpFromdate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFromdate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpFromdate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpFromdate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpFromdate.Size = new System.Drawing.Size(131, 20);
            this.dtpFromdate.TabIndex = 2;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(8, 17);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(77, 13);
            this.lblFromDate.TabIndex = 1;
            this.lblFromDate.Text = "Changed date:";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(614, 58);
            this.btnLoad.LookAndFeel.SkinName = "Blue";
            this.btnLoad.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "&Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtFullName
            // 
            this.txtFullName.Enabled = false;
            this.txtFullName.Location = new System.Drawing.Point(492, 10);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Properties.MaxLength = 100;
            this.txtFullName.Size = new System.Drawing.Size(197, 20);
            this.txtFullName.TabIndex = 5;
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Location = new System.Drawing.Point(374, 10);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.txtEmployeeID.Properties.Appearance.Options.UseBackColor = true;
            this.txtEmployeeID.Properties.MaxLength = 20;
            this.txtEmployeeID.Size = new System.Drawing.Size(112, 20);
            this.txtEmployeeID.TabIndex = 4;
            this.txtEmployeeID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtEmployeeID_KeyUp);
            this.txtEmployeeID.Leave += new System.EventHandler(this.txtEmployeeID_Leave);
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.AutoSize = true;
            this.lblEmployeeID.Location = new System.Drawing.Point(262, 13);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(58, 13);
            this.lblEmployeeID.TabIndex = 3;
            this.lblEmployeeID.Text = "First name:";
            // 
            // cbxFunctionName
            // 
            this.cbxFunctionName.Location = new System.Drawing.Point(374, 34);
            this.cbxFunctionName.Name = "cbxFunctionName";
            this.cbxFunctionName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxFunctionName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", 120, "Function")});
            this.cbxFunctionName.Properties.DisplayMember = "Description";
            this.cbxFunctionName.Properties.MaxLength = 100;
            this.cbxFunctionName.Properties.NullText = "";
            this.cbxFunctionName.Properties.ValueMember = "ObjectName";
            this.cbxFunctionName.Size = new System.Drawing.Size(315, 20);
            this.cbxFunctionName.TabIndex = 9;
            this.cbxFunctionName.Visible = false;
            // 
            // lblFunctionName
            // 
            this.lblFunctionName.AutoSize = true;
            this.lblFunctionName.Location = new System.Drawing.Point(262, 41);
            this.lblFunctionName.Name = "lblFunctionName";
            this.lblFunctionName.Size = new System.Drawing.Size(65, 13);
            this.lblFunctionName.TabIndex = 8;
            this.lblFunctionName.Text = "Department:";
            this.lblFunctionName.Visible = false;
            // 
            // grdSCLogList
            // 
            this.grdSCLogList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSCLogList.Location = new System.Drawing.Point(6, 95);
            this.grdSCLogList.MainView = this.grvSC_log;
            this.grdSCLogList.Name = "grdSCLogList";
            this.grdSCLogList.Size = new System.Drawing.Size(689, 410);
            this.grdSCLogList.TabIndex = 55;
            this.grdSCLogList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSC_log});
            // 
            // grvSC_log
            // 
            this.grvSC_log.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLoginID,
            this.colLoginName,
            this.comLogDate,
            this.colLogTime,
            this.colEmployeeID,
            this.colFullName,
            this.colFunctionName,
            this.colOldData,
            this.colNewData,
            this.colKindOfData});
            this.grvSC_log.GridControl = this.grdSCLogList;
            this.grvSC_log.Name = "grvSC_log";
            this.grvSC_log.OptionsView.ColumnAutoWidth = false;
            this.grvSC_log.OptionsView.ShowGroupPanel = false;
            // 
            // colLoginID
            // 
            this.colLoginID.Caption = "LoginID";
            this.colLoginID.FieldName = "LoginID";
            this.colLoginID.Name = "colLoginID";
            this.colLoginID.OptionsColumn.AllowEdit = false;
            this.colLoginID.Visible = true;
            this.colLoginID.VisibleIndex = 0;
            // 
            // colLoginName
            // 
            this.colLoginName.Caption = "LoginName";
            this.colLoginName.FieldName = "LoginName";
            this.colLoginName.Name = "colLoginName";
            this.colLoginName.OptionsColumn.AllowEdit = false;
            this.colLoginName.Visible = true;
            this.colLoginName.VisibleIndex = 1;
            // 
            // comLogDate
            // 
            this.comLogDate.Caption = "LogDate";
            this.comLogDate.FieldName = "LogDate";
            this.comLogDate.Name = "comLogDate";
            this.comLogDate.OptionsColumn.AllowEdit = false;
            this.comLogDate.Visible = true;
            this.comLogDate.VisibleIndex = 2;
            // 
            // colLogTime
            // 
            this.colLogTime.Caption = "LogTime";
            this.colLogTime.FieldName = "LogTime";
            this.colLogTime.Name = "colLogTime";
            this.colLogTime.OptionsColumn.AllowEdit = false;
            this.colLogTime.Visible = true;
            this.colLogTime.VisibleIndex = 3;
            // 
            // colEmployeeID
            // 
            this.colEmployeeID.Caption = "EmployeeID";
            this.colEmployeeID.FieldName = "EmployeeID";
            this.colEmployeeID.Name = "colEmployeeID";
            this.colEmployeeID.OptionsColumn.AllowEdit = false;
            this.colEmployeeID.Visible = true;
            this.colEmployeeID.VisibleIndex = 4;
            // 
            // colFullName
            // 
            this.colFullName.Caption = "FullName";
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.OptionsColumn.AllowEdit = false;
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 5;
            this.colFullName.Width = 137;
            // 
            // colFunctionName
            // 
            this.colFunctionName.Caption = "FunctionName";
            this.colFunctionName.FieldName = "FunctionName";
            this.colFunctionName.Name = "colFunctionName";
            this.colFunctionName.OptionsColumn.AllowEdit = false;
            this.colFunctionName.Visible = true;
            this.colFunctionName.VisibleIndex = 6;
            this.colFunctionName.Width = 182;
            // 
            // colOldData
            // 
            this.colOldData.Caption = "OldData";
            this.colOldData.FieldName = "OldData";
            this.colOldData.Name = "colOldData";
            this.colOldData.OptionsColumn.AllowEdit = false;
            this.colOldData.Visible = true;
            this.colOldData.VisibleIndex = 7;
            // 
            // colNewData
            // 
            this.colNewData.Caption = "NewData";
            this.colNewData.FieldName = "NewData";
            this.colNewData.Name = "colNewData";
            this.colNewData.OptionsColumn.AllowEdit = false;
            this.colNewData.Visible = true;
            this.colNewData.VisibleIndex = 8;
            // 
            // colKindOfData
            // 
            this.colKindOfData.Caption = "KindOfData";
            this.colKindOfData.FieldName = "KindOfData";
            this.colKindOfData.Name = "colKindOfData";
            this.colKindOfData.OptionsColumn.AllowEdit = false;
            this.colKindOfData.Visible = true;
            this.colKindOfData.VisibleIndex = 9;
            // 
            // HPALog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 545);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grdSCLogList);
            this.Name = "HPALog";
            this.Text = "HPALog";
            this.Load += new System.EventHandler(this.HPALog_Load);
            this.Controls.SetChildIndex(this.grdSCLogList, 0);
            this.Controls.SetChildIndex(this.lblFWDecorateingLine, 0);
            this.Controls.SetChildIndex(this.pnlFWCommand, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.pnlFWCommand.ResumeLayout(false);
            this.pnlFWClose.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromdate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromdate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxFunctionName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSCLogList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSC_log)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LookUpEdit cbxFunctionName;
        private System.Windows.Forms.Label lblFunctionName;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private DevExpress.XtraEditors.TextEdit txtEmployeeID;
        private System.Windows.Forms.Label lblEmployeeID;
        private DevExpress.XtraEditors.DateEdit dtpToDate;
        private System.Windows.Forms.Label lblToDate;
        private DevExpress.XtraEditors.DateEdit dtpFromdate;
        private System.Windows.Forms.Label lblFromDate;
        private DevExpress.XtraGrid.GridControl grdSCLogList;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSC_log;
        private DevExpress.XtraGrid.Columns.GridColumn colLoginID;
        private DevExpress.XtraGrid.Columns.GridColumn colLoginName;
        private DevExpress.XtraGrid.Columns.GridColumn colLogTime;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colFunctionName;
        private DevExpress.XtraGrid.Columns.GridColumn colOldData;
        private DevExpress.XtraGrid.Columns.GridColumn colNewData;
        private DevExpress.XtraGrid.Columns.GridColumn colKindOfData;
        private System.Windows.Forms.CheckBox ckbAllEmployees;
        private DevExpress.XtraGrid.Columns.GridColumn comLogDate;
    }
}