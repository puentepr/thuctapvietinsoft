namespace HPA.TimeAttendance
{
    partial class MachineManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachineManagement));
            this.tabMachineList = new System.Windows.Forms.TabControl();
            this.LiveAttendance = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpToDate = new DevExpress.XtraEditors.DateEdit();
            this.lblTodate = new System.Windows.Forms.Label();
            this.dtpFromDate = new DevExpress.XtraEditors.DateEdit();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.ckbLoadAll = new System.Windows.Forms.CheckBox();
            this.ckbClearAllLogAfterLoadSuccessfully = new System.Windows.Forms.CheckBox();
            this.btnDownloadAttLog = new System.Windows.Forms.Button();
            this.txtLogTime = new DevExpress.XtraEditors.TextEdit();
            this.txtFullName = new DevExpress.XtraEditors.TextEdit();
            this.lblLogTime = new System.Windows.Forms.Label();
            this.txtNameOnMachine = new DevExpress.XtraEditors.TextEdit();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtAcNo = new DevExpress.XtraEditors.TextEdit();
            this.lblNameOnMachine = new System.Windows.Forms.Label();
            this.lblACNo = new System.Windows.Forms.Label();
            this.txtEmployeeID = new DevExpress.XtraEditors.TextEdit();
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.imgEmployeeImage = new DevExpress.XtraEditors.PictureEdit();
            this.grdLogRecord = new DevExpress.XtraGrid.GridControl();
            this.grvLogRecord = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMachineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameOnMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpeDateTimeFormat = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.colVerifyMode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpeVerifyMode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserManagement = new System.Windows.Forms.TabPage();
            this.ckbCheckAll = new System.Windows.Forms.CheckBox();
            this.grbUploadUserInfo = new System.Windows.Forms.GroupBox();
            this.ckbUploadFingerPrint = new System.Windows.Forms.CheckBox();
            this.ckbUpdateCardNo = new System.Windows.Forms.CheckBox();
            this.btnUploadUserInfo = new System.Windows.Forms.Button();
            this.grbSetDeviceTime = new System.Windows.Forms.GroupBox();
            this.btnPowerOffDevice = new System.Windows.Forms.Button();
            this.btnDeleteAllData = new System.Windows.Forms.Button();
            this.btnRestartDevice = new System.Windows.Forms.Button();
            this.cbSecond = new System.Windows.Forms.ComboBox();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.cbMinute = new System.Windows.Forms.ComboBox();
            this.btnSetDeviceTime2 = new System.Windows.Forms.Button();
            this.cbDay = new System.Windows.Forms.ComboBox();
            this.cbHour = new System.Windows.Forms.ComboBox();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.btnGetDeviceTime = new System.Windows.Forms.Button();
            this.txtGetDeviceTime = new System.Windows.Forms.TextBox();
            this.btnSynDeviceTime = new System.Windows.Forms.Button();
            this.grbDownloadUserInfo = new System.Windows.Forms.GroupBox();
            this.btnDownloadUserInfo = new System.Windows.Forms.Button();
            this.ckbOnlyDownNewEmp = new System.Windows.Forms.CheckBox();
            this.grbEditUser = new System.Windows.Forms.GroupBox();
            this.ckbDeleteOnSystem = new System.Windows.Forms.CheckBox();
            this.btnClearAdministrators = new System.Windows.Forms.Button();
            this.btnClearDataTmps = new System.Windows.Forms.Button();
            this.btnDelAllUserOnDatabase = new System.Windows.Forms.Button();
            this.btnClearDataUserInfo = new System.Windows.Forms.Button();
            this.btnDeleteEnrollData = new System.Windows.Forms.Button();
            this.txtSearch = new DevExpress.XtraEditors.TextEdit();
            this.lblSearch = new System.Windows.Forms.Label();
            this.grdUserList = new DevExpress.XtraGrid.GridControl();
            this.grvUserList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTemplateCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCardNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PASSWORD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ImportDataFromUSBFileData = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabUserUSB_BW = new System.Windows.Forms.TabPage();
            this.lblUserUSB_BW_Note = new System.Windows.Forms.Label();
            this.btnUserRead = new System.Windows.Forms.Button();
            this.lvUser = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.tabAttLogsUSB_BW = new System.Windows.Forms.TabPage();
            this.lblAttLogsUSB_BW_note = new System.Windows.Forms.Label();
            this.btnAttLogExtRead = new System.Windows.Forms.Button();
            this.lvAttLog = new System.Windows.Forms.ListView();
            this.columnHeader25 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader26 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader27 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader28 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader29 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader30 = new System.Windows.Forms.ColumnHeader();
            this.tabTmp9USB_BW = new System.Windows.Forms.TabPage();
            this.lblTmp9USB_BW_Note = new System.Windows.Forms.Label();
            this.btnTmpRead = new System.Windows.Forms.Button();
            this.lvTmp = new System.Windows.Forms.ListView();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader21 = new System.Windows.Forms.ColumnHeader();
            this.ImportDataFromUSBFileData_TFT = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabUser_TFT = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSSR_UserRead = new System.Windows.Forms.Button();
            this.lvSSRUser = new System.Windows.Forms.ListView();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.tabAttLogs_TFT = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.lvSSRAttLog = new System.Windows.Forms.ListView();
            this.columnHeader22 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader23 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader24 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader31 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader32 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader33 = new System.Windows.Forms.ColumnHeader();
            this.btnSSRAttLogRead = new System.Windows.Forms.Button();
            this.tabtmp9_TFT = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTemp9_TFT = new System.Windows.Forms.Button();
            this.lvTmp9 = new System.Windows.Forms.ListView();
            this.columnHeader34 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader35 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader36 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader37 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader38 = new System.Windows.Forms.ColumnHeader();
            this.tabTmp10_TFT = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.lvTmp10 = new System.Windows.Forms.ListView();
            this.columnHeader42 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader43 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader44 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader45 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader46 = new System.Windows.Forms.ColumnHeader();
            this.btnTmp10Read = new System.Windows.Forms.Button();
            this.grdMachineList = new DevExpress.XtraGrid.GridControl();
            this.grvMachineList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colImageIcon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colMachineAlias = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineKind = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmanagercount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colusercount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfingercount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSecretCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCDKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnConnect = new DevExpress.XtraEditors.SimpleButton();
            this.btnDisconnect = new DevExpress.XtraEditors.SimpleButton();
            this.lableInfor = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pnlFWCommand.SuspendLayout();
            this.pnlFWClose.SuspendLayout();
            this.tabMachineList.SuspendLayout();
            this.LiveAttendance.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameOnMachine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAcNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgEmployeeImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLogRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpeDateTimeFormat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpeVerifyMode)).BeginInit();
            this.UserManagement.SuspendLayout();
            this.grbUploadUserInfo.SuspendLayout();
            this.grbSetDeviceTime.SuspendLayout();
            this.grbDownloadUserInfo.SuspendLayout();
            this.grbEditUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUserList)).BeginInit();
            this.ImportDataFromUSBFileData.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabUserUSB_BW.SuspendLayout();
            this.tabAttLogsUSB_BW.SuspendLayout();
            this.tabTmp9USB_BW.SuspendLayout();
            this.ImportDataFromUSBFileData_TFT.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabUser_TFT.SuspendLayout();
            this.tabAttLogs_TFT.SuspendLayout();
            this.tabtmp9_TFT.SuspendLayout();
            this.tabTmp10_TFT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMachineList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMachineList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFWCommand
            // 
            this.pnlFWCommand.Controls.Add(this.btnConnect);
            this.pnlFWCommand.Controls.Add(this.btnDisconnect);
            this.pnlFWCommand.Location = new System.Drawing.Point(0, 684);
            this.pnlFWCommand.Size = new System.Drawing.Size(1018, 38);
            this.pnlFWCommand.Controls.SetChildIndex(this.btnFWSave, 0);
            this.pnlFWCommand.Controls.SetChildIndex(this.btnFWDelete, 0);
            this.pnlFWCommand.Controls.SetChildIndex(this.btnFWReset, 0);
            this.pnlFWCommand.Controls.SetChildIndex(this.btnDisconnect, 0);
            this.pnlFWCommand.Controls.SetChildIndex(this.btnFWAdd, 0);
            this.pnlFWCommand.Controls.SetChildIndex(this.btnConnect, 0);
            this.pnlFWCommand.Controls.SetChildIndex(this.pnlFWClose, 0);
            this.pnlFWCommand.Controls.SetChildIndex(this.btnExport, 0);
            // 
            // btnFWDelete
            // 
            this.btnFWDelete.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWDelete.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWDelete.Appearance.Options.UseFont = true;
            this.btnFWDelete.Appearance.Options.UseForeColor = true;
            this.btnFWDelete.Location = new System.Drawing.Point(357, 1);
            this.btnFWDelete.LookAndFeel.SkinName = "Blue";
            this.btnFWDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFWDelete.Visible = false;
            // 
            // btnFWSave
            // 
            this.btnFWSave.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWSave.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWSave.Appearance.Options.UseFont = true;
            this.btnFWSave.Appearance.Options.UseForeColor = true;
            this.btnFWSave.Location = new System.Drawing.Point(221, 4);
            this.btnFWSave.LookAndFeel.SkinName = "Blue";
            this.btnFWSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFWSave.Visible = false;
            // 
            // btnFWAdd
            // 
            this.btnFWAdd.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWAdd.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWAdd.Appearance.Options.UseFont = true;
            this.btnFWAdd.Appearance.Options.UseForeColor = true;
            this.btnFWAdd.Location = new System.Drawing.Point(357, 8);
            this.btnFWAdd.LookAndFeel.SkinName = "Blue";
            this.btnFWAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFWAdd.Visible = false;
            // 
            // pnlFWClose
            // 
            this.pnlFWClose.Location = new System.Drawing.Point(867, 0);
            // 
            // btnFWClose
            // 
            this.btnFWClose.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWClose.Appearance.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btnFWClose.Appearance.Options.UseFont = true;
            this.btnFWClose.Appearance.Options.UseForeColor = true;
            this.btnFWClose.LookAndFeel.SkinName = "Blue";
            this.btnFWClose.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // lblFWDecorateingLine
            // 
            this.lblFWDecorateingLine.Location = new System.Drawing.Point(0, 682);
            this.lblFWDecorateingLine.Size = new System.Drawing.Size(1018, 2);
            // 
            // btnFWReset
            // 
            this.btnFWReset.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWReset.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWReset.Appearance.Options.UseFont = true;
            this.btnFWReset.Appearance.Options.UseForeColor = true;
            this.btnFWReset.Location = new System.Drawing.Point(357, 11);
            this.btnFWReset.LookAndFeel.SkinName = "Blue";
            this.btnFWReset.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFWReset.Visible = false;
            // 
            // btnExport
            // 
            this.btnExport.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnExport.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Appearance.Options.UseForeColor = true;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.LookAndFeel.SkinName = "Blue";
            this.btnExport.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExport.Visible = false;
            // 
            // tabMachineList
            // 
            this.tabMachineList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMachineList.Controls.Add(this.LiveAttendance);
            this.tabMachineList.Controls.Add(this.UserManagement);
            this.tabMachineList.Controls.Add(this.ImportDataFromUSBFileData);
            this.tabMachineList.Controls.Add(this.ImportDataFromUSBFileData_TFT);
            this.tabMachineList.Location = new System.Drawing.Point(0, 181);
            this.tabMachineList.Name = "tabMachineList";
            this.tabMachineList.SelectedIndex = 0;
            this.tabMachineList.Size = new System.Drawing.Size(1018, 541);
            this.tabMachineList.TabIndex = 54;
            this.tabMachineList.SelectedIndexChanged += new System.EventHandler(this.tabMachineList_SelectedIndexChanged);
            // 
            // LiveAttendance
            // 
            this.LiveAttendance.Controls.Add(this.groupBox1);
            this.LiveAttendance.Controls.Add(this.txtLogTime);
            this.LiveAttendance.Controls.Add(this.txtFullName);
            this.LiveAttendance.Controls.Add(this.lblLogTime);
            this.LiveAttendance.Controls.Add(this.txtNameOnMachine);
            this.LiveAttendance.Controls.Add(this.lblFullName);
            this.LiveAttendance.Controls.Add(this.txtAcNo);
            this.LiveAttendance.Controls.Add(this.lblNameOnMachine);
            this.LiveAttendance.Controls.Add(this.lblACNo);
            this.LiveAttendance.Controls.Add(this.txtEmployeeID);
            this.LiveAttendance.Controls.Add(this.lblEmployeeID);
            this.LiveAttendance.Controls.Add(this.imgEmployeeImage);
            this.LiveAttendance.Controls.Add(this.grdLogRecord);
            this.LiveAttendance.Location = new System.Drawing.Point(4, 22);
            this.LiveAttendance.Name = "LiveAttendance";
            this.LiveAttendance.Padding = new System.Windows.Forms.Padding(3);
            this.LiveAttendance.Size = new System.Drawing.Size(1010, 515);
            this.LiveAttendance.TabIndex = 0;
            this.LiveAttendance.Text = "Live Attendance";
            this.LiveAttendance.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.lblTodate);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.lblFromDate);
            this.groupBox1.Controls.Add(this.ckbLoadAll);
            this.groupBox1.Controls.Add(this.ckbClearAllLogAfterLoadSuccessfully);
            this.groupBox1.Controls.Add(this.btnDownloadAttLog);
            this.groupBox1.Location = new System.Drawing.Point(557, 315);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 160);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dtpToDate
            // 
            this.dtpToDate.EditValue = null;
            this.dtpToDate.Location = new System.Drawing.Point(254, 42);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpToDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpToDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpToDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpToDate.Size = new System.Drawing.Size(104, 20);
            this.dtpToDate.TabIndex = 79;
            // 
            // lblTodate
            // 
            this.lblTodate.AutoSize = true;
            this.lblTodate.Location = new System.Drawing.Point(192, 45);
            this.lblTodate.Name = "lblTodate";
            this.lblTodate.Size = new System.Drawing.Size(57, 13);
            this.lblTodate.TabIndex = 81;
            this.lblTodate.Text = "From date:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.EditValue = null;
            this.dtpFromDate.Location = new System.Drawing.Point(80, 42);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFromDate.Properties.LookAndFeel.SkinName = "Blue";
            this.dtpFromDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtpFromDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpFromDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpFromDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpFromDate.Size = new System.Drawing.Size(104, 20);
            this.dtpFromDate.TabIndex = 78;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(6, 45);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(57, 13);
            this.lblFromDate.TabIndex = 80;
            this.lblFromDate.Text = "From date:";
            // 
            // ckbLoadAll
            // 
            this.ckbLoadAll.AutoSize = true;
            this.ckbLoadAll.Location = new System.Drawing.Point(7, 19);
            this.ckbLoadAll.Name = "ckbLoadAll";
            this.ckbLoadAll.Size = new System.Drawing.Size(126, 17);
            this.ckbLoadAll.TabIndex = 77;
            this.ckbLoadAll.Text = "Xóa cả trên hệ thống";
            this.ckbLoadAll.UseVisualStyleBackColor = true;
            this.ckbLoadAll.CheckedChanged += new System.EventHandler(this.ckbLoadAll_CheckedChanged);
            // 
            // ckbClearAllLogAfterLoadSuccessfully
            // 
            this.ckbClearAllLogAfterLoadSuccessfully.AutoSize = true;
            this.ckbClearAllLogAfterLoadSuccessfully.Location = new System.Drawing.Point(130, 135);
            this.ckbClearAllLogAfterLoadSuccessfully.Name = "ckbClearAllLogAfterLoadSuccessfully";
            this.ckbClearAllLogAfterLoadSuccessfully.Size = new System.Drawing.Size(126, 17);
            this.ckbClearAllLogAfterLoadSuccessfully.TabIndex = 77;
            this.ckbClearAllLogAfterLoadSuccessfully.Text = "Xóa cả trên hệ thống";
            this.ckbClearAllLogAfterLoadSuccessfully.UseVisualStyleBackColor = true;
            // 
            // btnDownloadAttLog
            // 
            this.btnDownloadAttLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadAttLog.Location = new System.Drawing.Point(6, 131);
            this.btnDownloadAttLog.Name = "btnDownloadAttLog";
            this.btnDownloadAttLog.Size = new System.Drawing.Size(118, 23);
            this.btnDownloadAttLog.TabIndex = 74;
            this.btnDownloadAttLog.Text = "UplodaUserInfo";
            this.btnDownloadAttLog.UseVisualStyleBackColor = true;
            this.btnDownloadAttLog.Click += new System.EventHandler(this.btnDownloadAttLog_Click);
            // 
            // txtLogTime
            // 
            this.txtLogTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogTime.Location = new System.Drawing.Point(730, 289);
            this.txtLogTime.Name = "txtLogTime";
            this.txtLogTime.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtLogTime.Properties.Appearance.Options.UseBackColor = true;
            this.txtLogTime.Properties.MaxLength = 20;
            this.txtLogTime.Size = new System.Drawing.Size(153, 20);
            this.txtLogTime.TabIndex = 59;
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Location = new System.Drawing.Point(730, 263);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtFullName.Properties.Appearance.Options.UseBackColor = true;
            this.txtFullName.Properties.MaxLength = 20;
            this.txtFullName.Size = new System.Drawing.Size(153, 20);
            this.txtFullName.TabIndex = 59;
            // 
            // lblLogTime
            // 
            this.lblLogTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogTime.AutoSize = true;
            this.lblLogTime.Location = new System.Drawing.Point(620, 292);
            this.lblLogTime.Name = "lblLogTime";
            this.lblLogTime.Size = new System.Drawing.Size(70, 13);
            this.lblLogTime.TabIndex = 58;
            this.lblLogTime.Text = "Employee ID:";
            // 
            // txtNameOnMachine
            // 
            this.txtNameOnMachine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameOnMachine.Location = new System.Drawing.Point(730, 237);
            this.txtNameOnMachine.Name = "txtNameOnMachine";
            this.txtNameOnMachine.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtNameOnMachine.Properties.Appearance.Options.UseBackColor = true;
            this.txtNameOnMachine.Properties.MaxLength = 20;
            this.txtNameOnMachine.Size = new System.Drawing.Size(153, 20);
            this.txtNameOnMachine.TabIndex = 59;
            // 
            // lblFullName
            // 
            this.lblFullName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(620, 266);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(70, 13);
            this.lblFullName.TabIndex = 58;
            this.lblFullName.Text = "Employee ID:";
            // 
            // txtAcNo
            // 
            this.txtAcNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAcNo.Location = new System.Drawing.Point(730, 214);
            this.txtAcNo.Name = "txtAcNo";
            this.txtAcNo.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtAcNo.Properties.Appearance.Options.UseBackColor = true;
            this.txtAcNo.Properties.MaxLength = 20;
            this.txtAcNo.Size = new System.Drawing.Size(153, 20);
            this.txtAcNo.TabIndex = 59;
            // 
            // lblNameOnMachine
            // 
            this.lblNameOnMachine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNameOnMachine.AutoSize = true;
            this.lblNameOnMachine.Location = new System.Drawing.Point(620, 240);
            this.lblNameOnMachine.Name = "lblNameOnMachine";
            this.lblNameOnMachine.Size = new System.Drawing.Size(70, 13);
            this.lblNameOnMachine.TabIndex = 58;
            this.lblNameOnMachine.Text = "Employee ID:";
            // 
            // lblACNo
            // 
            this.lblACNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblACNo.AutoSize = true;
            this.lblACNo.Location = new System.Drawing.Point(620, 217);
            this.lblACNo.Name = "lblACNo";
            this.lblACNo.Size = new System.Drawing.Size(70, 13);
            this.lblACNo.TabIndex = 58;
            this.lblACNo.Text = "Employee ID:";
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmployeeID.Location = new System.Drawing.Point(730, 188);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtEmployeeID.Properties.Appearance.Options.UseBackColor = true;
            this.txtEmployeeID.Properties.MaxLength = 20;
            this.txtEmployeeID.Size = new System.Drawing.Size(153, 20);
            this.txtEmployeeID.TabIndex = 59;
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmployeeID.AutoSize = true;
            this.lblEmployeeID.Location = new System.Drawing.Point(620, 191);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(70, 13);
            this.lblEmployeeID.TabIndex = 58;
            this.lblEmployeeID.Text = "Employee ID:";
            // 
            // imgEmployeeImage
            // 
            this.imgEmployeeImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.imgEmployeeImage.Location = new System.Drawing.Point(889, 152);
            this.imgEmployeeImage.Name = "imgEmployeeImage";
            this.imgEmployeeImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.imgEmployeeImage.Size = new System.Drawing.Size(118, 157);
            this.imgEmployeeImage.TabIndex = 57;
            // 
            // grdLogRecord
            // 
            this.grdLogRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLogRecord.EmbeddedNavigator.Name = "";
            this.grdLogRecord.FormsUseDefaultLookAndFeel = false;
            this.grdLogRecord.Location = new System.Drawing.Point(-4, 3);
            this.grdLogRecord.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdLogRecord.MainView = this.grvLogRecord;
            this.grdLogRecord.Name = "grdLogRecord";
            this.grdLogRecord.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpeVerifyMode,
            this.rpeDateTimeFormat});
            this.grdLogRecord.Size = new System.Drawing.Size(555, 476);
            this.grdLogRecord.TabIndex = 56;
            this.grdLogRecord.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLogRecord});
            // 
            // grvLogRecord
            // 
            this.grvLogRecord.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMachineName,
            this.colNameOnMachine,
            this.colLogTime,
            this.colVerifyMode,
            this.colFullName});
            this.grvLogRecord.GridControl = this.grdLogRecord;
            this.grvLogRecord.Name = "grvLogRecord";
            this.grvLogRecord.OptionsSelection.MultiSelect = true;
            this.grvLogRecord.OptionsView.ShowGroupPanel = false;
            // 
            // colMachineName
            // 
            this.colMachineName.Caption = "MachineAlias";
            this.colMachineName.FieldName = "MachineAlias";
            this.colMachineName.Name = "colMachineName";
            this.colMachineName.OptionsColumn.AllowEdit = false;
            this.colMachineName.Visible = true;
            this.colMachineName.VisibleIndex = 0;
            this.colMachineName.Width = 97;
            // 
            // colNameOnMachine
            // 
            this.colNameOnMachine.Caption = "NameOnMachine";
            this.colNameOnMachine.FieldName = "NameOnMachine";
            this.colNameOnMachine.Name = "colNameOnMachine";
            this.colNameOnMachine.OptionsColumn.AllowEdit = false;
            this.colNameOnMachine.Visible = true;
            this.colNameOnMachine.VisibleIndex = 1;
            this.colNameOnMachine.Width = 77;
            // 
            // colLogTime
            // 
            this.colLogTime.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colLogTime.AppearanceCell.Options.UseFont = true;
            this.colLogTime.Caption = "LogTime";
            this.colLogTime.ColumnEdit = this.rpeDateTimeFormat;
            this.colLogTime.FieldName = "LogTime";
            this.colLogTime.Name = "colLogTime";
            this.colLogTime.OptionsColumn.AllowEdit = false;
            this.colLogTime.Visible = true;
            this.colLogTime.VisibleIndex = 3;
            this.colLogTime.Width = 141;
            // 
            // rpeDateTimeFormat
            // 
            this.rpeDateTimeFormat.AutoHeight = false;
            this.rpeDateTimeFormat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rpeDateTimeFormat.Mask.EditMask = "dd/MM/yyyy HH:mm:ss";
            this.rpeDateTimeFormat.Mask.UseMaskAsDisplayFormat = true;
            this.rpeDateTimeFormat.Name = "rpeDateTimeFormat";
            // 
            // colVerifyMode
            // 
            this.colVerifyMode.Caption = "VerifyMode";
            this.colVerifyMode.ColumnEdit = this.rpeVerifyMode;
            this.colVerifyMode.FieldName = "VerifyMode";
            this.colVerifyMode.Name = "colVerifyMode";
            this.colVerifyMode.OptionsColumn.AllowEdit = false;
            this.colVerifyMode.Visible = true;
            this.colVerifyMode.VisibleIndex = 4;
            this.colVerifyMode.Width = 109;
            // 
            // rpeVerifyMode
            // 
            this.rpeVerifyMode.AutoHeight = false;
            this.rpeVerifyMode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpeVerifyMode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VerifyMode", "VerifyMode", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.rpeVerifyMode.DisplayMember = "VerifyMode";
            this.rpeVerifyMode.Name = "rpeVerifyMode";
            this.rpeVerifyMode.ValueMember = "VerifyModeID";
            // 
            // colFullName
            // 
            this.colFullName.Caption = "FullName";
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.OptionsColumn.AllowEdit = false;
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 2;
            this.colFullName.Width = 132;
            // 
            // UserManagement
            // 
            this.UserManagement.Controls.Add(this.ckbCheckAll);
            this.UserManagement.Controls.Add(this.grbUploadUserInfo);
            this.UserManagement.Controls.Add(this.grbSetDeviceTime);
            this.UserManagement.Controls.Add(this.grbDownloadUserInfo);
            this.UserManagement.Controls.Add(this.grbEditUser);
            this.UserManagement.Controls.Add(this.txtSearch);
            this.UserManagement.Controls.Add(this.lblSearch);
            this.UserManagement.Controls.Add(this.grdUserList);
            this.UserManagement.Location = new System.Drawing.Point(4, 22);
            this.UserManagement.Name = "UserManagement";
            this.UserManagement.Padding = new System.Windows.Forms.Padding(3);
            this.UserManagement.Size = new System.Drawing.Size(1010, 515);
            this.UserManagement.TabIndex = 1;
            this.UserManagement.Text = "User management";
            this.UserManagement.UseVisualStyleBackColor = true;
            // 
            // ckbCheckAll
            // 
            this.ckbCheckAll.AutoSize = true;
            this.ckbCheckAll.Location = new System.Drawing.Point(469, 9);
            this.ckbCheckAll.Name = "ckbCheckAll";
            this.ckbCheckAll.Size = new System.Drawing.Size(70, 17);
            this.ckbCheckAll.TabIndex = 77;
            this.ckbCheckAll.Text = "Check all";
            this.ckbCheckAll.UseVisualStyleBackColor = true;
            this.ckbCheckAll.CheckedChanged += new System.EventHandler(this.ckbCheckAll_CheckedChanged);
            // 
            // grbUploadUserInfo
            // 
            this.grbUploadUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grbUploadUserInfo.Controls.Add(this.ckbUploadFingerPrint);
            this.grbUploadUserInfo.Controls.Add(this.ckbUpdateCardNo);
            this.grbUploadUserInfo.Controls.Add(this.btnUploadUserInfo);
            this.grbUploadUserInfo.Location = new System.Drawing.Point(532, 292);
            this.grbUploadUserInfo.Name = "grbUploadUserInfo";
            this.grbUploadUserInfo.Size = new System.Drawing.Size(470, 56);
            this.grbUploadUserInfo.TabIndex = 64;
            this.grbUploadUserInfo.TabStop = false;
            this.grbUploadUserInfo.Text = "groupBox1";
            // 
            // ckbUploadFingerPrint
            // 
            this.ckbUploadFingerPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ckbUploadFingerPrint.AutoSize = true;
            this.ckbUploadFingerPrint.Location = new System.Drawing.Point(273, 31);
            this.ckbUploadFingerPrint.Name = "ckbUploadFingerPrint";
            this.ckbUploadFingerPrint.Size = new System.Drawing.Size(174, 17);
            this.ckbUploadFingerPrint.TabIndex = 76;
            this.ckbUploadFingerPrint.Text = "Tải vân tay lên máy chấm công";
            this.ckbUploadFingerPrint.UseVisualStyleBackColor = true;
            // 
            // ckbUpdateCardNo
            // 
            this.ckbUpdateCardNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ckbUpdateCardNo.AutoSize = true;
            this.ckbUpdateCardNo.Checked = true;
            this.ckbUpdateCardNo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbUpdateCardNo.Location = new System.Drawing.Point(105, 31);
            this.ckbUpdateCardNo.Name = "ckbUpdateCardNo";
            this.ckbUpdateCardNo.Size = new System.Drawing.Size(76, 17);
            this.ckbUpdateCardNo.TabIndex = 76;
            this.ckbUpdateCardNo.Text = "Tải thẻ lên";
            this.ckbUpdateCardNo.UseVisualStyleBackColor = true;
            // 
            // btnUploadUserInfo
            // 
            this.btnUploadUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUploadUserInfo.Location = new System.Drawing.Point(6, 27);
            this.btnUploadUserInfo.Name = "btnUploadUserInfo";
            this.btnUploadUserInfo.Size = new System.Drawing.Size(93, 23);
            this.btnUploadUserInfo.TabIndex = 74;
            this.btnUploadUserInfo.Text = "UplodaUserInfo";
            this.btnUploadUserInfo.UseVisualStyleBackColor = true;
            this.btnUploadUserInfo.Click += new System.EventHandler(this.btnUploadUserInfo_Click);
            // 
            // grbSetDeviceTime
            // 
            this.grbSetDeviceTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grbSetDeviceTime.Controls.Add(this.btnPowerOffDevice);
            this.grbSetDeviceTime.Controls.Add(this.btnDeleteAllData);
            this.grbSetDeviceTime.Controls.Add(this.btnRestartDevice);
            this.grbSetDeviceTime.Controls.Add(this.cbSecond);
            this.grbSetDeviceTime.Controls.Add(this.cbMonth);
            this.grbSetDeviceTime.Controls.Add(this.cbMinute);
            this.grbSetDeviceTime.Controls.Add(this.btnSetDeviceTime2);
            this.grbSetDeviceTime.Controls.Add(this.cbDay);
            this.grbSetDeviceTime.Controls.Add(this.cbHour);
            this.grbSetDeviceTime.Controls.Add(this.cbYear);
            this.grbSetDeviceTime.Controls.Add(this.btnGetDeviceTime);
            this.grbSetDeviceTime.Controls.Add(this.txtGetDeviceTime);
            this.grbSetDeviceTime.Controls.Add(this.btnSynDeviceTime);
            this.grbSetDeviceTime.Location = new System.Drawing.Point(532, 108);
            this.grbSetDeviceTime.Name = "grbSetDeviceTime";
            this.grbSetDeviceTime.Size = new System.Drawing.Size(470, 119);
            this.grbSetDeviceTime.TabIndex = 64;
            this.grbSetDeviceTime.TabStop = false;
            this.grbSetDeviceTime.Text = "SetDeviceTime";
            // 
            // btnPowerOffDevice
            // 
            this.btnPowerOffDevice.Location = new System.Drawing.Point(331, 83);
            this.btnPowerOffDevice.Name = "btnPowerOffDevice";
            this.btnPowerOffDevice.Size = new System.Drawing.Size(132, 23);
            this.btnPowerOffDevice.TabIndex = 18;
            this.btnPowerOffDevice.Text = "PowerOffDevice";
            this.btnPowerOffDevice.UseVisualStyleBackColor = true;
            this.btnPowerOffDevice.Click += new System.EventHandler(this.btnPowerOffDevice_Click);
            // 
            // btnDeleteAllData
            // 
            this.btnDeleteAllData.BackColor = System.Drawing.Color.LightCoral;
            this.btnDeleteAllData.Location = new System.Drawing.Point(6, 83);
            this.btnDeleteAllData.Name = "btnDeleteAllData";
            this.btnDeleteAllData.Size = new System.Drawing.Size(137, 23);
            this.btnDeleteAllData.TabIndex = 17;
            this.btnDeleteAllData.Text = "RestartDevice";
            this.btnDeleteAllData.UseVisualStyleBackColor = false;
            this.btnDeleteAllData.Click += new System.EventHandler(this.btnDeleteAllData_Click);
            // 
            // btnRestartDevice
            // 
            this.btnRestartDevice.Location = new System.Drawing.Point(179, 83);
            this.btnRestartDevice.Name = "btnRestartDevice";
            this.btnRestartDevice.Size = new System.Drawing.Size(132, 23);
            this.btnRestartDevice.TabIndex = 17;
            this.btnRestartDevice.Text = "RestartDevice";
            this.btnRestartDevice.UseVisualStyleBackColor = true;
            this.btnRestartDevice.Click += new System.EventHandler(this.btnRestartDevice_Click);
            // 
            // cbSecond
            // 
            this.cbSecond.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSecond.FormattingEnabled = true;
            this.cbSecond.Items.AddRange(new object[] {
            "1",
            "..",
            "59"});
            this.cbSecond.Location = new System.Drawing.Point(270, 20);
            this.cbSecond.Name = "cbSecond";
            this.cbSecond.Size = new System.Drawing.Size(41, 21);
            this.cbSecond.TabIndex = 15;
            this.cbSecond.Text = "8";
            // 
            // cbMonth
            // 
            this.cbMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMonth.DisplayMember = "Month";
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbMonth.Location = new System.Drawing.Point(74, 19);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(41, 21);
            this.cbMonth.TabIndex = 11;
            this.cbMonth.Text = "12";
            // 
            // cbMinute
            // 
            this.cbMinute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMinute.FormattingEnabled = true;
            this.cbMinute.Items.AddRange(new object[] {
            "1",
            "..",
            "59"});
            this.cbMinute.Location = new System.Drawing.Point(221, 20);
            this.cbMinute.Name = "cbMinute";
            this.cbMinute.Size = new System.Drawing.Size(41, 21);
            this.cbMinute.TabIndex = 14;
            this.cbMinute.Text = "8";
            // 
            // btnSetDeviceTime2
            // 
            this.btnSetDeviceTime2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetDeviceTime2.Location = new System.Drawing.Point(331, 17);
            this.btnSetDeviceTime2.Name = "btnSetDeviceTime2";
            this.btnSetDeviceTime2.Size = new System.Drawing.Size(132, 23);
            this.btnSetDeviceTime2.TabIndex = 16;
            this.btnSetDeviceTime2.Text = "SetDeviceTime2";
            this.btnSetDeviceTime2.UseVisualStyleBackColor = true;
            this.btnSetDeviceTime2.Click += new System.EventHandler(this.btnSetDeviceTime2_Click);
            // 
            // cbDay
            // 
            this.cbDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDay.FormattingEnabled = true;
            this.cbDay.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "..",
            "30"});
            this.cbDay.Location = new System.Drawing.Point(123, 19);
            this.cbDay.Name = "cbDay";
            this.cbDay.Size = new System.Drawing.Size(41, 21);
            this.cbDay.TabIndex = 12;
            this.cbDay.Text = "31";
            // 
            // cbHour
            // 
            this.cbHour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHour.FormattingEnabled = true;
            this.cbHour.Items.AddRange(new object[] {
            "1",
            "..",
            "59"});
            this.cbHour.Location = new System.Drawing.Point(172, 20);
            this.cbHour.Name = "cbHour";
            this.cbHour.Size = new System.Drawing.Size(41, 21);
            this.cbHour.TabIndex = 13;
            this.cbHour.Text = "8";
            // 
            // cbYear
            // 
            this.cbYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Items.AddRange(new object[] {
            "2009",
            "2010",
            "2011",
            "2012"});
            this.cbYear.Location = new System.Drawing.Point(6, 19);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(60, 21);
            this.cbYear.TabIndex = 10;
            this.cbYear.Text = "2009";
            // 
            // btnGetDeviceTime
            // 
            this.btnGetDeviceTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetDeviceTime.Location = new System.Drawing.Point(6, 50);
            this.btnGetDeviceTime.Name = "btnGetDeviceTime";
            this.btnGetDeviceTime.Size = new System.Drawing.Size(137, 23);
            this.btnGetDeviceTime.TabIndex = 4;
            this.btnGetDeviceTime.Text = "GetDeviceTime";
            this.btnGetDeviceTime.UseVisualStyleBackColor = true;
            this.btnGetDeviceTime.Click += new System.EventHandler(this.btnGetDeviceTime_Click);
            // 
            // txtGetDeviceTime
            // 
            this.txtGetDeviceTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGetDeviceTime.Location = new System.Drawing.Point(160, 52);
            this.txtGetDeviceTime.Name = "txtGetDeviceTime";
            this.txtGetDeviceTime.ReadOnly = true;
            this.txtGetDeviceTime.Size = new System.Drawing.Size(151, 20);
            this.txtGetDeviceTime.TabIndex = 5;
            // 
            // btnSynDeviceTime
            // 
            this.btnSynDeviceTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSynDeviceTime.Location = new System.Drawing.Point(331, 50);
            this.btnSynDeviceTime.Name = "btnSynDeviceTime";
            this.btnSynDeviceTime.Size = new System.Drawing.Size(132, 23);
            this.btnSynDeviceTime.TabIndex = 3;
            this.btnSynDeviceTime.Text = "DownloadFPTmp";
            this.btnSynDeviceTime.UseVisualStyleBackColor = true;
            this.btnSynDeviceTime.Click += new System.EventHandler(this.btnSynDeviceTime_Click);
            // 
            // grbDownloadUserInfo
            // 
            this.grbDownloadUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDownloadUserInfo.Controls.Add(this.btnDownloadUserInfo);
            this.grbDownloadUserInfo.Controls.Add(this.ckbOnlyDownNewEmp);
            this.grbDownloadUserInfo.Location = new System.Drawing.Point(532, 235);
            this.grbDownloadUserInfo.Name = "grbDownloadUserInfo";
            this.grbDownloadUserInfo.Size = new System.Drawing.Size(470, 51);
            this.grbDownloadUserInfo.TabIndex = 64;
            this.grbDownloadUserInfo.TabStop = false;
            this.grbDownloadUserInfo.Text = "groupBox1";
            // 
            // btnDownloadUserInfo
            // 
            this.btnDownloadUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadUserInfo.Location = new System.Drawing.Point(331, 22);
            this.btnDownloadUserInfo.Name = "btnDownloadUserInfo";
            this.btnDownloadUserInfo.Size = new System.Drawing.Size(132, 23);
            this.btnDownloadUserInfo.TabIndex = 3;
            this.btnDownloadUserInfo.Text = "DownloadFPTmp";
            this.btnDownloadUserInfo.UseVisualStyleBackColor = true;
            this.btnDownloadUserInfo.Click += new System.EventHandler(this.btnDownloadUserInfo_Click);
            // 
            // ckbOnlyDownNewEmp
            // 
            this.ckbOnlyDownNewEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ckbOnlyDownNewEmp.AutoSize = true;
            this.ckbOnlyDownNewEmp.Checked = true;
            this.ckbOnlyDownNewEmp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbOnlyDownNewEmp.Location = new System.Drawing.Point(6, 26);
            this.ckbOnlyDownNewEmp.Name = "ckbOnlyDownNewEmp";
            this.ckbOnlyDownNewEmp.Size = new System.Drawing.Size(76, 17);
            this.ckbOnlyDownNewEmp.TabIndex = 76;
            this.ckbOnlyDownNewEmp.Text = "Tải thẻ lên";
            this.ckbOnlyDownNewEmp.UseVisualStyleBackColor = true;
            // 
            // grbEditUser
            // 
            this.grbEditUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grbEditUser.Controls.Add(this.ckbDeleteOnSystem);
            this.grbEditUser.Controls.Add(this.btnClearAdministrators);
            this.grbEditUser.Controls.Add(this.btnClearDataTmps);
            this.grbEditUser.Controls.Add(this.btnDelAllUserOnDatabase);
            this.grbEditUser.Controls.Add(this.btnClearDataUserInfo);
            this.grbEditUser.Controls.Add(this.btnDeleteEnrollData);
            this.grbEditUser.Location = new System.Drawing.Point(532, 354);
            this.grbEditUser.Name = "grbEditUser";
            this.grbEditUser.Size = new System.Drawing.Size(470, 121);
            this.grbEditUser.TabIndex = 63;
            this.grbEditUser.TabStop = false;
            this.grbEditUser.Text = "groupBox1";
            // 
            // ckbDeleteOnSystem
            // 
            this.ckbDeleteOnSystem.AutoSize = true;
            this.ckbDeleteOnSystem.Location = new System.Drawing.Point(99, 23);
            this.ckbDeleteOnSystem.Name = "ckbDeleteOnSystem";
            this.ckbDeleteOnSystem.Size = new System.Drawing.Size(126, 17);
            this.ckbDeleteOnSystem.TabIndex = 76;
            this.ckbDeleteOnSystem.Text = "Xóa cả trên hệ thống";
            this.ckbDeleteOnSystem.UseVisualStyleBackColor = true;
            // 
            // btnClearAdministrators
            // 
            this.btnClearAdministrators.Location = new System.Drawing.Point(322, 54);
            this.btnClearAdministrators.Name = "btnClearAdministrators";
            this.btnClearAdministrators.Size = new System.Drawing.Size(141, 23);
            this.btnClearAdministrators.TabIndex = 75;
            this.btnClearAdministrators.Text = "ClearAdministrators";
            this.btnClearAdministrators.UseVisualStyleBackColor = true;
            this.btnClearAdministrators.Click += new System.EventHandler(this.btnClearAdministrators_Click);
            // 
            // btnClearDataTmps
            // 
            this.btnClearDataTmps.BackColor = System.Drawing.Color.LightCoral;
            this.btnClearDataTmps.Location = new System.Drawing.Point(6, 54);
            this.btnClearDataTmps.Name = "btnClearDataTmps";
            this.btnClearDataTmps.Size = new System.Drawing.Size(141, 23);
            this.btnClearDataTmps.TabIndex = 74;
            this.btnClearDataTmps.Text = "ClearTmpsData";
            this.btnClearDataTmps.UseVisualStyleBackColor = false;
            this.btnClearDataTmps.Visible = false;
            this.btnClearDataTmps.Click += new System.EventHandler(this.btnClearDataTmps_Click);
            // 
            // btnDelAllUserOnDatabase
            // 
            this.btnDelAllUserOnDatabase.BackColor = System.Drawing.Color.LightCoral;
            this.btnDelAllUserOnDatabase.Location = new System.Drawing.Point(322, 17);
            this.btnDelAllUserOnDatabase.Name = "btnDelAllUserOnDatabase";
            this.btnDelAllUserOnDatabase.Size = new System.Drawing.Size(141, 23);
            this.btnDelAllUserOnDatabase.TabIndex = 73;
            this.btnDelAllUserOnDatabase.Text = "Xóa hết NV trên hệ thống";
            this.btnDelAllUserOnDatabase.UseVisualStyleBackColor = false;
            this.btnDelAllUserOnDatabase.Click += new System.EventHandler(this.btnDelAllUserOnDatabase_Click);
            // 
            // btnClearDataUserInfo
            // 
            this.btnClearDataUserInfo.BackColor = System.Drawing.Color.LightCoral;
            this.btnClearDataUserInfo.Location = new System.Drawing.Point(175, 54);
            this.btnClearDataUserInfo.Name = "btnClearDataUserInfo";
            this.btnClearDataUserInfo.Size = new System.Drawing.Size(141, 23);
            this.btnClearDataUserInfo.TabIndex = 73;
            this.btnClearDataUserInfo.Text = "ClearUserInfoData";
            this.btnClearDataUserInfo.UseVisualStyleBackColor = false;
            this.btnClearDataUserInfo.Visible = false;
            this.btnClearDataUserInfo.Click += new System.EventHandler(this.btnClearDataUserInfo_Click);
            // 
            // btnDeleteEnrollData
            // 
            this.btnDeleteEnrollData.BackColor = System.Drawing.Color.LightCoral;
            this.btnDeleteEnrollData.Location = new System.Drawing.Point(6, 19);
            this.btnDeleteEnrollData.Name = "btnDeleteEnrollData";
            this.btnDeleteEnrollData.Size = new System.Drawing.Size(87, 23);
            this.btnDeleteEnrollData.TabIndex = 62;
            this.btnDeleteEnrollData.Text = "Delete User";
            this.btnDeleteEnrollData.UseVisualStyleBackColor = false;
            this.btnDeleteEnrollData.Click += new System.EventHandler(this.btnDeleteEnrollData_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(110, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtSearch.Properties.Appearance.Options.UseBackColor = true;
            this.txtSearch.Properties.MaxLength = 20;
            this.txtSearch.Size = new System.Drawing.Size(294, 20);
            this.txtSearch.TabIndex = 61;
            this.txtSearch.EditValueChanged += new System.EventHandler(this.txtSearch_EditValueChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(0, 9);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(70, 13);
            this.lblSearch.TabIndex = 60;
            this.lblSearch.Text = "Employee ID:";
            // 
            // grdUserList
            // 
            this.grdUserList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdUserList.EmbeddedNavigator.Name = "";
            this.grdUserList.FormsUseDefaultLookAndFeel = false;
            this.grdUserList.Location = new System.Drawing.Point(3, 32);
            this.grdUserList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdUserList.MainView = this.grvUserList;
            this.grdUserList.Name = "grdUserList";
            this.grdUserList.Size = new System.Drawing.Size(523, 447);
            this.grdUserList.TabIndex = 57;
            this.grdUserList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUserList});
            // 
            // grvUserList
            // 
            this.grvUserList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmployeeID,
            this.colEmpFullName,
            this.colACNo,
            this.colName,
            this.colTemplateCount,
            this.colCheck,
            this.colCardNo,
            this.PASSWORD});
            this.grvUserList.GridControl = this.grdUserList;
            this.grvUserList.Name = "grvUserList";
            this.grvUserList.OptionsSelection.MultiSelect = true;
            this.grvUserList.OptionsView.ShowFooter = true;
            this.grvUserList.OptionsView.ShowGroupPanel = false;
            this.grvUserList.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvUserList_CellValueChanged);
            // 
            // colEmployeeID
            // 
            this.colEmployeeID.Caption = "EmployeeID";
            this.colEmployeeID.FieldName = "EmployeeID";
            this.colEmployeeID.Name = "colEmployeeID";
            this.colEmployeeID.OptionsColumn.AllowEdit = false;
            this.colEmployeeID.Visible = true;
            this.colEmployeeID.VisibleIndex = 0;
            this.colEmployeeID.Width = 61;
            // 
            // colEmpFullName
            // 
            this.colEmpFullName.Caption = "FullName";
            this.colEmpFullName.FieldName = "FullName";
            this.colEmpFullName.Name = "colEmpFullName";
            this.colEmpFullName.OptionsColumn.AllowEdit = false;
            this.colEmpFullName.Visible = true;
            this.colEmpFullName.VisibleIndex = 1;
            this.colEmpFullName.Width = 186;
            // 
            // colACNo
            // 
            this.colACNo.Caption = "Badgenumber";
            this.colACNo.FieldName = "Badgenumber";
            this.colACNo.Name = "colACNo";
            this.colACNo.OptionsColumn.AllowEdit = false;
            this.colACNo.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.colACNo.Visible = true;
            this.colACNo.VisibleIndex = 2;
            this.colACNo.Width = 43;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "NAME";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 3;
            this.colName.Width = 77;
            // 
            // colTemplateCount
            // 
            this.colTemplateCount.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTemplateCount.AppearanceCell.Options.UseFont = true;
            this.colTemplateCount.Caption = "FingerCount";
            this.colTemplateCount.FieldName = "FingerCount";
            this.colTemplateCount.Name = "colTemplateCount";
            this.colTemplateCount.OptionsColumn.AllowEdit = false;
            this.colTemplateCount.Visible = true;
            this.colTemplateCount.VisibleIndex = 4;
            this.colTemplateCount.Width = 62;
            // 
            // colCheck
            // 
            this.colCheck.Caption = "Check";
            this.colCheck.FieldName = "Check";
            this.colCheck.Name = "colCheck";
            this.colCheck.Visible = true;
            this.colCheck.VisibleIndex = 5;
            this.colCheck.Width = 58;
            // 
            // colCardNo
            // 
            this.colCardNo.Caption = "CardNo";
            this.colCardNo.FieldName = "CardNo";
            this.colCardNo.Name = "colCardNo";
            this.colCardNo.Visible = true;
            this.colCardNo.VisibleIndex = 6;
            this.colCardNo.Width = 51;
            // 
            // PASSWORD
            // 
            this.PASSWORD.Caption = "PASSWORD";
            this.PASSWORD.FieldName = "PASSWORD";
            this.PASSWORD.Name = "PASSWORD";
            this.PASSWORD.Visible = true;
            this.PASSWORD.VisibleIndex = 7;
            this.PASSWORD.Width = 59;
            // 
            // ImportDataFromUSBFileData
            // 
            this.ImportDataFromUSBFileData.Controls.Add(this.tabControl1);
            this.ImportDataFromUSBFileData.Location = new System.Drawing.Point(4, 22);
            this.ImportDataFromUSBFileData.Name = "ImportDataFromUSBFileData";
            this.ImportDataFromUSBFileData.Size = new System.Drawing.Size(1010, 515);
            this.ImportDataFromUSBFileData.TabIndex = 2;
            this.ImportDataFromUSBFileData.Text = "tabPage1";
            this.ImportDataFromUSBFileData.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabUserUSB_BW);
            this.tabControl1.Controls.Add(this.tabAttLogsUSB_BW);
            this.tabControl1.Controls.Add(this.tabTmp9USB_BW);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 472);
            this.tabControl1.TabIndex = 5;
            // 
            // tabUserUSB_BW
            // 
            this.tabUserUSB_BW.Controls.Add(this.lblUserUSB_BW_Note);
            this.tabUserUSB_BW.Controls.Add(this.btnUserRead);
            this.tabUserUSB_BW.Controls.Add(this.lvUser);
            this.tabUserUSB_BW.Location = new System.Drawing.Point(4, 22);
            this.tabUserUSB_BW.Name = "tabUserUSB_BW";
            this.tabUserUSB_BW.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserUSB_BW.Size = new System.Drawing.Size(1000, 446);
            this.tabUserUSB_BW.TabIndex = 0;
            this.tabUserUSB_BW.Text = "User(B&W)";
            this.tabUserUSB_BW.UseVisualStyleBackColor = true;
            // 
            // lblUserUSB_BW_Note
            // 
            this.lblUserUSB_BW_Note.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUserUSB_BW_Note.AutoSize = true;
            this.lblUserUSB_BW_Note.ForeColor = System.Drawing.Color.Red;
            this.lblUserUSB_BW_Note.Location = new System.Drawing.Point(237, 375);
            this.lblUserUSB_BW_Note.Name = "lblUserUSB_BW_Note";
            this.lblUserUSB_BW_Note.Size = new System.Drawing.Size(403, 13);
            this.lblUserUSB_BW_Note.TabIndex = 10;
            this.lblUserUSB_BW_Note.Text = "It is for user information management(user.dat).(For Black&&White screen device o" +
                "nly)";
            // 
            // btnUserRead
            // 
            this.btnUserRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUserRead.Location = new System.Drawing.Point(295, 402);
            this.btnUserRead.Name = "btnUserRead";
            this.btnUserRead.Size = new System.Drawing.Size(159, 23);
            this.btnUserRead.TabIndex = 8;
            this.btnUserRead.Text = "ReadDataToPC";
            this.btnUserRead.UseVisualStyleBackColor = true;
            this.btnUserRead.Click += new System.EventHandler(this.btnUserRead_Click);
            // 
            // lvUser
            // 
            this.lvUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvUser.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lvUser.GridLines = true;
            this.lvUser.Location = new System.Drawing.Point(6, 6);
            this.lvUser.Name = "lvUser";
            this.lvUser.Size = new System.Drawing.Size(989, 357);
            this.lvUser.TabIndex = 0;
            this.lvUser.UseCompatibleStateImageBehavior = false;
            this.lvUser.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "PIN2";
            this.columnHeader1.Width = 53;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 47;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Card";
            this.columnHeader3.Width = 55;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Privilege";
            this.columnHeader4.Width = 77;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Password";
            this.columnHeader5.Width = 77;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Group";
            this.columnHeader6.Width = 69;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "TimeZones";
            this.columnHeader7.Width = 74;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "PIN";
            this.columnHeader8.Width = 68;
            // 
            // tabAttLogsUSB_BW
            // 
            this.tabAttLogsUSB_BW.Controls.Add(this.lblAttLogsUSB_BW_note);
            this.tabAttLogsUSB_BW.Controls.Add(this.btnAttLogExtRead);
            this.tabAttLogsUSB_BW.Controls.Add(this.lvAttLog);
            this.tabAttLogsUSB_BW.Location = new System.Drawing.Point(4, 22);
            this.tabAttLogsUSB_BW.Name = "tabAttLogsUSB_BW";
            this.tabAttLogsUSB_BW.Size = new System.Drawing.Size(1000, 446);
            this.tabAttLogsUSB_BW.TabIndex = 3;
            this.tabAttLogsUSB_BW.Text = "Attlogs(B&W)";
            this.tabAttLogsUSB_BW.UseVisualStyleBackColor = true;
            // 
            // lblAttLogsUSB_BW_note
            // 
            this.lblAttLogsUSB_BW_note.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAttLogsUSB_BW_note.AutoSize = true;
            this.lblAttLogsUSB_BW_note.ForeColor = System.Drawing.Color.Red;
            this.lblAttLogsUSB_BW_note.Location = new System.Drawing.Point(183, 378);
            this.lblAttLogsUSB_BW_note.Name = "lblAttLogsUSB_BW_note";
            this.lblAttLogsUSB_BW_note.Size = new System.Drawing.Size(249, 13);
            this.lblAttLogsUSB_BW_note.TabIndex = 25;
            this.lblAttLogsUSB_BW_note.Text = "It is for the extended attendence logs management.";
            // 
            // btnAttLogExtRead
            // 
            this.btnAttLogExtRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAttLogExtRead.Location = new System.Drawing.Point(210, 405);
            this.btnAttLogExtRead.Name = "btnAttLogExtRead";
            this.btnAttLogExtRead.Size = new System.Drawing.Size(175, 23);
            this.btnAttLogExtRead.TabIndex = 20;
            this.btnAttLogExtRead.Text = "ReadDataToPC";
            this.btnAttLogExtRead.UseVisualStyleBackColor = true;
            this.btnAttLogExtRead.Click += new System.EventHandler(this.btnAttLogExtRead_Click);
            // 
            // lvAttLog
            // 
            this.lvAttLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvAttLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader25,
            this.columnHeader26,
            this.columnHeader27,
            this.columnHeader28,
            this.columnHeader29,
            this.columnHeader30});
            this.lvAttLog.GridLines = true;
            this.lvAttLog.Location = new System.Drawing.Point(6, 6);
            this.lvAttLog.Name = "lvAttLog";
            this.lvAttLog.Size = new System.Drawing.Size(989, 354);
            this.lvAttLog.TabIndex = 1;
            this.lvAttLog.UseCompatibleStateImageBehavior = false;
            this.lvAttLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "PIN";
            this.columnHeader25.Width = 129;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "Time";
            this.columnHeader26.Width = 182;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "DeviceID";
            this.columnHeader27.Width = 68;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Status";
            this.columnHeader28.Width = 54;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "Verified";
            this.columnHeader29.Width = 65;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "Workcode";
            this.columnHeader30.Width = 69;
            // 
            // tabTmp9USB_BW
            // 
            this.tabTmp9USB_BW.Controls.Add(this.lblTmp9USB_BW_Note);
            this.tabTmp9USB_BW.Controls.Add(this.btnTmpRead);
            this.tabTmp9USB_BW.Controls.Add(this.lvTmp);
            this.tabTmp9USB_BW.Location = new System.Drawing.Point(4, 22);
            this.tabTmp9USB_BW.Name = "tabTmp9USB_BW";
            this.tabTmp9USB_BW.Size = new System.Drawing.Size(1000, 446);
            this.tabTmp9USB_BW.TabIndex = 2;
            this.tabTmp9USB_BW.Text = "Tmp9.0";
            this.tabTmp9USB_BW.UseVisualStyleBackColor = true;
            // 
            // lblTmp9USB_BW_Note
            // 
            this.lblTmp9USB_BW_Note.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTmp9USB_BW_Note.AutoSize = true;
            this.lblTmp9USB_BW_Note.ForeColor = System.Drawing.Color.Red;
            this.lblTmp9USB_BW_Note.Location = new System.Drawing.Point(125, 383);
            this.lblTmp9USB_BW_Note.Name = "lblTmp9USB_BW_Note";
            this.lblTmp9USB_BW_Note.Size = new System.Drawing.Size(368, 13);
            this.lblTmp9USB_BW_Note.TabIndex = 27;
            this.lblTmp9USB_BW_Note.Text = "It is for fingerprint templates management.(For device with 9.0 arithmetic only)";
            // 
            // btnTmpRead
            // 
            this.btnTmpRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTmpRead.Location = new System.Drawing.Point(210, 411);
            this.btnTmpRead.Name = "btnTmpRead";
            this.btnTmpRead.Size = new System.Drawing.Size(153, 23);
            this.btnTmpRead.TabIndex = 14;
            this.btnTmpRead.Text = "ReadDataToPC";
            this.btnTmpRead.UseVisualStyleBackColor = true;
            this.btnTmpRead.Click += new System.EventHandler(this.btnTmpRead_Click);
            // 
            // lvTmp
            // 
            this.lvTmp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTmp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21});
            this.lvTmp.GridLines = true;
            this.lvTmp.Location = new System.Drawing.Point(6, 6);
            this.lvTmp.Name = "lvTmp";
            this.lvTmp.Size = new System.Drawing.Size(989, 357);
            this.lvTmp.TabIndex = 1;
            this.lvTmp.UseCompatibleStateImageBehavior = false;
            this.lvTmp.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Size";
            this.columnHeader17.Width = 53;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "PIN";
            this.columnHeader18.Width = 45;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "FingerID";
            this.columnHeader19.Width = 72;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Valid";
            this.columnHeader20.Width = 87;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Template";
            this.columnHeader21.Width = 111;
            // 
            // ImportDataFromUSBFileData_TFT
            // 
            this.ImportDataFromUSBFileData_TFT.Controls.Add(this.tabControl2);
            this.ImportDataFromUSBFileData_TFT.Location = new System.Drawing.Point(4, 22);
            this.ImportDataFromUSBFileData_TFT.Name = "ImportDataFromUSBFileData_TFT";
            this.ImportDataFromUSBFileData_TFT.Size = new System.Drawing.Size(1010, 515);
            this.ImportDataFromUSBFileData_TFT.TabIndex = 3;
            this.ImportDataFromUSBFileData_TFT.Text = "ImportDataFromUSBFileData_TFT";
            this.ImportDataFromUSBFileData_TFT.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabUser_TFT);
            this.tabControl2.Controls.Add(this.tabAttLogs_TFT);
            this.tabControl2.Controls.Add(this.tabtmp9_TFT);
            this.tabControl2.Controls.Add(this.tabTmp10_TFT);
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1004, 472);
            this.tabControl2.TabIndex = 5;
            // 
            // tabUser_TFT
            // 
            this.tabUser_TFT.Controls.Add(this.label2);
            this.tabUser_TFT.Controls.Add(this.btnSSR_UserRead);
            this.tabUser_TFT.Controls.Add(this.lvSSRUser);
            this.tabUser_TFT.Location = new System.Drawing.Point(4, 22);
            this.tabUser_TFT.Name = "tabUser_TFT";
            this.tabUser_TFT.Padding = new System.Windows.Forms.Padding(3);
            this.tabUser_TFT.Size = new System.Drawing.Size(996, 446);
            this.tabUser_TFT.TabIndex = 1;
            this.tabUser_TFT.Text = "SSR_User(TFT)";
            this.tabUser_TFT.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(194, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "It is for user information management(user.dat).";
            // 
            // btnSSR_UserRead
            // 
            this.btnSSR_UserRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSSR_UserRead.Location = new System.Drawing.Point(210, 405);
            this.btnSSR_UserRead.Name = "btnSSR_UserRead";
            this.btnSSR_UserRead.Size = new System.Drawing.Size(158, 23);
            this.btnSSR_UserRead.TabIndex = 11;
            this.btnSSR_UserRead.Text = "ReadDataToPC";
            this.btnSSR_UserRead.UseVisualStyleBackColor = true;
            this.btnSSR_UserRead.Click += new System.EventHandler(this.btnSSR_UserRead_Click);
            // 
            // lvSSRUser
            // 
            this.lvSSRUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSSRUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16});
            this.lvSSRUser.GridLines = true;
            this.lvSSRUser.Location = new System.Drawing.Point(6, 6);
            this.lvSSRUser.Name = "lvSSRUser";
            this.lvSSRUser.Size = new System.Drawing.Size(984, 357);
            this.lvSSRUser.TabIndex = 1;
            this.lvSSRUser.UseCompatibleStateImageBehavior = false;
            this.lvSSRUser.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "PIN2";
            this.columnHeader9.Width = 53;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Name";
            this.columnHeader10.Width = 47;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Card";
            this.columnHeader11.Width = 55;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Privilege";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Password";
            this.columnHeader13.Width = 77;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Group";
            this.columnHeader14.Width = 69;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "TimeZones";
            this.columnHeader15.Width = 74;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "PIN";
            this.columnHeader16.Width = 68;
            // 
            // tabAttLogs_TFT
            // 
            this.tabAttLogs_TFT.Controls.Add(this.label4);
            this.tabAttLogs_TFT.Controls.Add(this.lvSSRAttLog);
            this.tabAttLogs_TFT.Controls.Add(this.btnSSRAttLogRead);
            this.tabAttLogs_TFT.Location = new System.Drawing.Point(4, 22);
            this.tabAttLogs_TFT.Name = "tabAttLogs_TFT";
            this.tabAttLogs_TFT.Size = new System.Drawing.Size(996, 446);
            this.tabAttLogs_TFT.TabIndex = 4;
            this.tabAttLogs_TFT.Text = "AttLogs(TFT)";
            this.tabAttLogs_TFT.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(186, 381);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "It is for attendance logs management.";
            // 
            // lvSSRAttLog
            // 
            this.lvSSRAttLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSSRAttLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader31,
            this.columnHeader32,
            this.columnHeader33});
            this.lvSSRAttLog.GridLines = true;
            this.lvSSRAttLog.Location = new System.Drawing.Point(6, 6);
            this.lvSSRAttLog.Name = "lvSSRAttLog";
            this.lvSSRAttLog.Size = new System.Drawing.Size(987, 355);
            this.lvSSRAttLog.TabIndex = 24;
            this.lvSSRAttLog.UseCompatibleStateImageBehavior = false;
            this.lvSSRAttLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "PIN";
            this.columnHeader22.Width = 129;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "Time";
            this.columnHeader23.Width = 182;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "DeviceID";
            this.columnHeader24.Width = 68;
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "Status";
            this.columnHeader31.Width = 54;
            // 
            // columnHeader32
            // 
            this.columnHeader32.Text = "Verified";
            this.columnHeader32.Width = 65;
            // 
            // columnHeader33
            // 
            this.columnHeader33.Text = "Workcode";
            this.columnHeader33.Width = 69;
            // 
            // btnSSRAttLogRead
            // 
            this.btnSSRAttLogRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSSRAttLogRead.Location = new System.Drawing.Point(210, 407);
            this.btnSSRAttLogRead.Name = "btnSSRAttLogRead";
            this.btnSSRAttLogRead.Size = new System.Drawing.Size(160, 23);
            this.btnSSRAttLogRead.TabIndex = 21;
            this.btnSSRAttLogRead.Text = "ReadDataToPC";
            this.btnSSRAttLogRead.UseVisualStyleBackColor = true;
            this.btnSSRAttLogRead.Click += new System.EventHandler(this.btnSSRAttLogRead_Click);
            // 
            // tabtmp9_TFT
            // 
            this.tabtmp9_TFT.Controls.Add(this.label5);
            this.tabtmp9_TFT.Controls.Add(this.btnTemp9_TFT);
            this.tabtmp9_TFT.Controls.Add(this.lvTmp9);
            this.tabtmp9_TFT.Location = new System.Drawing.Point(4, 22);
            this.tabtmp9_TFT.Name = "tabtmp9_TFT";
            this.tabtmp9_TFT.Size = new System.Drawing.Size(996, 446);
            this.tabtmp9_TFT.TabIndex = 2;
            this.tabtmp9_TFT.Text = "Tmp9.0";
            this.tabtmp9_TFT.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(98, 379);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(373, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "It is for fingerprint templates management.(For devices with 9.0 arithmetic only)" +
                "";
            // 
            // btnTemp9_TFT
            // 
            this.btnTemp9_TFT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTemp9_TFT.Location = new System.Drawing.Point(210, 407);
            this.btnTemp9_TFT.Name = "btnTemp9_TFT";
            this.btnTemp9_TFT.Size = new System.Drawing.Size(173, 23);
            this.btnTemp9_TFT.TabIndex = 14;
            this.btnTemp9_TFT.Text = "ReadDataToPC";
            this.btnTemp9_TFT.UseVisualStyleBackColor = true;
            this.btnTemp9_TFT.Click += new System.EventHandler(this.btnTemp9_TFT_Click);
            // 
            // lvTmp9
            // 
            this.lvTmp9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTmp9.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader34,
            this.columnHeader35,
            this.columnHeader36,
            this.columnHeader37,
            this.columnHeader38});
            this.lvTmp9.GridLines = true;
            this.lvTmp9.Location = new System.Drawing.Point(6, 6);
            this.lvTmp9.Name = "lvTmp9";
            this.lvTmp9.Size = new System.Drawing.Size(987, 356);
            this.lvTmp9.TabIndex = 1;
            this.lvTmp9.UseCompatibleStateImageBehavior = false;
            this.lvTmp9.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader34
            // 
            this.columnHeader34.Text = "Size";
            this.columnHeader34.Width = 53;
            // 
            // columnHeader35
            // 
            this.columnHeader35.Text = "PIN";
            this.columnHeader35.Width = 45;
            // 
            // columnHeader36
            // 
            this.columnHeader36.Text = "FingerID";
            this.columnHeader36.Width = 72;
            // 
            // columnHeader37
            // 
            this.columnHeader37.Text = "Valid";
            this.columnHeader37.Width = 87;
            // 
            // columnHeader38
            // 
            this.columnHeader38.Text = "Template";
            this.columnHeader38.Width = 111;
            // 
            // tabTmp10_TFT
            // 
            this.tabTmp10_TFT.Controls.Add(this.label6);
            this.tabTmp10_TFT.Controls.Add(this.lvTmp10);
            this.tabTmp10_TFT.Controls.Add(this.btnTmp10Read);
            this.tabTmp10_TFT.Location = new System.Drawing.Point(4, 22);
            this.tabTmp10_TFT.Name = "tabTmp10_TFT";
            this.tabTmp10_TFT.Size = new System.Drawing.Size(996, 446);
            this.tabTmp10_TFT.TabIndex = 6;
            this.tabTmp10_TFT.Text = "Tmp10.0";
            this.tabTmp10_TFT.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(95, 379);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(379, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "It is for fingerprint templates management.(For devices with 10.0 arithmetic only" +
                ")";
            // 
            // lvTmp10
            // 
            this.lvTmp10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTmp10.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader42,
            this.columnHeader43,
            this.columnHeader44,
            this.columnHeader45,
            this.columnHeader46});
            this.lvTmp10.GridLines = true;
            this.lvTmp10.Location = new System.Drawing.Point(6, 6);
            this.lvTmp10.Name = "lvTmp10";
            this.lvTmp10.Size = new System.Drawing.Size(987, 358);
            this.lvTmp10.TabIndex = 13;
            this.lvTmp10.UseCompatibleStateImageBehavior = false;
            this.lvTmp10.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader42
            // 
            this.columnHeader42.Text = "Size";
            this.columnHeader42.Width = 53;
            // 
            // columnHeader43
            // 
            this.columnHeader43.Text = "PIN";
            this.columnHeader43.Width = 45;
            // 
            // columnHeader44
            // 
            this.columnHeader44.Text = "FingerID";
            this.columnHeader44.Width = 72;
            // 
            // columnHeader45
            // 
            this.columnHeader45.Text = "Flag";
            this.columnHeader45.Width = 87;
            // 
            // columnHeader46
            // 
            this.columnHeader46.Text = "Template";
            this.columnHeader46.Width = 320;
            // 
            // btnTmp10Read
            // 
            this.btnTmp10Read.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTmp10Read.Location = new System.Drawing.Point(210, 404);
            this.btnTmp10Read.Name = "btnTmp10Read";
            this.btnTmp10Read.Size = new System.Drawing.Size(185, 23);
            this.btnTmp10Read.TabIndex = 11;
            this.btnTmp10Read.Text = "ReadDataToPC";
            this.btnTmp10Read.UseVisualStyleBackColor = true;
            this.btnTmp10Read.Click += new System.EventHandler(this.btnTmp10Read_Click);
            // 
            // grdMachineList
            // 
            this.grdMachineList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdMachineList.EmbeddedNavigator.Name = "";
            this.grdMachineList.FormsUseDefaultLookAndFeel = false;
            this.grdMachineList.Location = new System.Drawing.Point(-1, 1);
            this.grdMachineList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdMachineList.MainView = this.grvMachineList;
            this.grdMachineList.Name = "grdMachineList";
            this.grdMachineList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1});
            this.grdMachineList.Size = new System.Drawing.Size(1015, 174);
            this.grdMachineList.TabIndex = 56;
            this.grdMachineList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMachineList});
            // 
            // grvMachineList
            // 
            this.grvMachineList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colImageIcon,
            this.colMachineAlias,
            this.colStatus,
            this.colMachineNumber,
            this.colMachineKind,
            this.colIP,
            this.colPort,
            this.colLogCount,
            this.colmanagercount,
            this.colusercount,
            this.colfingercount,
            this.colSecretCount,
            this.colsn,
            this.colCDKey});
            this.grvMachineList.GridControl = this.grdMachineList;
            this.grvMachineList.GroupFormat = "[#image]{1} {2}";
            this.grvMachineList.Name = "grvMachineList";
            this.grvMachineList.OptionsSelection.MultiSelect = true;
            this.grvMachineList.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grvMachineList.OptionsView.ColumnAutoWidth = false;
            this.grvMachineList.OptionsView.ShowGroupPanel = false;
            this.grvMachineList.OptionsView.ShowIndicator = false;
            // 
            // colImageIcon
            // 
            this.colImageIcon.Caption = "ImageIcon";
            this.colImageIcon.ColumnEdit = this.repositoryItemPictureEdit1;
            this.colImageIcon.FieldName = "ImageIcon";
            this.colImageIcon.Name = "colImageIcon";
            this.colImageIcon.OptionsColumn.AllowSize = false;
            this.colImageIcon.Visible = true;
            this.colImageIcon.VisibleIndex = 0;
            this.colImageIcon.Width = 37;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // colMachineAlias
            // 
            this.colMachineAlias.Caption = "MachineAlias";
            this.colMachineAlias.FieldName = "MachineAlias";
            this.colMachineAlias.Name = "colMachineAlias";
            this.colMachineAlias.OptionsColumn.AllowEdit = false;
            this.colMachineAlias.Visible = true;
            this.colMachineAlias.VisibleIndex = 1;
            this.colMachineAlias.Width = 128;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 2;
            this.colStatus.Width = 99;
            // 
            // colMachineNumber
            // 
            this.colMachineNumber.Caption = "MachineNumber";
            this.colMachineNumber.FieldName = "MachineNumber";
            this.colMachineNumber.Name = "colMachineNumber";
            this.colMachineNumber.OptionsColumn.AllowEdit = false;
            this.colMachineNumber.Visible = true;
            this.colMachineNumber.VisibleIndex = 3;
            this.colMachineNumber.Width = 94;
            // 
            // colMachineKind
            // 
            this.colMachineKind.Caption = "MachineKind";
            this.colMachineKind.FieldName = "MachineKind";
            this.colMachineKind.Name = "colMachineKind";
            this.colMachineKind.OptionsColumn.AllowEdit = false;
            // 
            // colIP
            // 
            this.colIP.Caption = "IP";
            this.colIP.FieldName = "IP";
            this.colIP.Name = "colIP";
            this.colIP.OptionsColumn.AllowEdit = false;
            this.colIP.Visible = true;
            this.colIP.VisibleIndex = 4;
            this.colIP.Width = 102;
            // 
            // colPort
            // 
            this.colPort.Caption = "Port";
            this.colPort.FieldName = "Port";
            this.colPort.Name = "colPort";
            this.colPort.OptionsColumn.AllowEdit = false;
            this.colPort.Visible = true;
            this.colPort.VisibleIndex = 5;
            this.colPort.Width = 72;
            // 
            // colLogCount
            // 
            this.colLogCount.Caption = "LogCount";
            this.colLogCount.FieldName = "LogCount";
            this.colLogCount.Name = "colLogCount";
            this.colLogCount.OptionsColumn.AllowEdit = false;
            this.colLogCount.Visible = true;
            this.colLogCount.VisibleIndex = 10;
            // 
            // colmanagercount
            // 
            this.colmanagercount.Caption = "managercount";
            this.colmanagercount.FieldName = "managercount";
            this.colmanagercount.Name = "colmanagercount";
            this.colmanagercount.OptionsColumn.AllowEdit = false;
            this.colmanagercount.Visible = true;
            this.colmanagercount.VisibleIndex = 6;
            this.colmanagercount.Width = 86;
            // 
            // colusercount
            // 
            this.colusercount.Caption = "usercount";
            this.colusercount.FieldName = "usercount";
            this.colusercount.Name = "colusercount";
            this.colusercount.OptionsColumn.AllowEdit = false;
            this.colusercount.Visible = true;
            this.colusercount.VisibleIndex = 7;
            this.colusercount.Width = 81;
            // 
            // colfingercount
            // 
            this.colfingercount.Caption = "fingercount";
            this.colfingercount.FieldName = "fingercount";
            this.colfingercount.Name = "colfingercount";
            this.colfingercount.OptionsColumn.AllowEdit = false;
            this.colfingercount.Visible = true;
            this.colfingercount.VisibleIndex = 8;
            this.colfingercount.Width = 73;
            // 
            // colSecretCount
            // 
            this.colSecretCount.Caption = "SecretCount";
            this.colSecretCount.FieldName = "SecretCount";
            this.colSecretCount.Name = "colSecretCount";
            this.colSecretCount.OptionsColumn.AllowEdit = false;
            this.colSecretCount.Visible = true;
            this.colSecretCount.VisibleIndex = 9;
            this.colSecretCount.Width = 64;
            // 
            // colsn
            // 
            this.colsn.Caption = "sn";
            this.colsn.FieldName = "sn";
            this.colsn.Name = "colsn";
            this.colsn.OptionsColumn.AllowEdit = false;
            this.colsn.Visible = true;
            this.colsn.VisibleIndex = 11;
            this.colsn.Width = 100;
            // 
            // colCDKey
            // 
            this.colCDKey.Caption = "CDKey";
            this.colCDKey.FieldName = "CDKey";
            this.colCDKey.Name = "colCDKey";
            this.colCDKey.OptionsColumn.AllowEdit = false;
            this.colCDKey.Visible = true;
            this.colCDKey.VisibleIndex = 12;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(7, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(101, 30);
            this.btnConnect.TabIndex = 57;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(114, 3);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(101, 30);
            this.btnDisconnect.TabIndex = 57;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // lableInfor
            // 
            this.lableInfor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lableInfor.BackColor = System.Drawing.SystemColors.Info;
            this.lableInfor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lableInfor.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableInfor.Location = new System.Drawing.Point(338, 154);
            this.lableInfor.Name = "lableInfor";
            this.lableInfor.Size = new System.Drawing.Size(341, 49);
            this.lableInfor.TabIndex = 58;
            this.lableInfor.Text = "Employee ID:";
            this.lableInfor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lableInfor.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MachineManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 722);
            this.Controls.Add(this.lableInfor);
            this.Controls.Add(this.tabMachineList);
            this.Controls.Add(this.grdMachineList);
            this.Name = "MachineManagement";
            this.Text = "MachineManagement";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MachineManagement_FormClosing);
            this.Controls.SetChildIndex(this.grdMachineList, 0);
            this.Controls.SetChildIndex(this.tabMachineList, 0);
            this.Controls.SetChildIndex(this.pnlFWCommand, 0);
            this.Controls.SetChildIndex(this.lblFWDecorateingLine, 0);
            this.Controls.SetChildIndex(this.lableInfor, 0);
            this.pnlFWCommand.ResumeLayout(false);
            this.pnlFWClose.ResumeLayout(false);
            this.tabMachineList.ResumeLayout(false);
            this.LiveAttendance.ResumeLayout(false);
            this.LiveAttendance.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameOnMachine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAcNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgEmployeeImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLogRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpeDateTimeFormat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpeVerifyMode)).EndInit();
            this.UserManagement.ResumeLayout(false);
            this.UserManagement.PerformLayout();
            this.grbUploadUserInfo.ResumeLayout(false);
            this.grbUploadUserInfo.PerformLayout();
            this.grbSetDeviceTime.ResumeLayout(false);
            this.grbSetDeviceTime.PerformLayout();
            this.grbDownloadUserInfo.ResumeLayout(false);
            this.grbDownloadUserInfo.PerformLayout();
            this.grbEditUser.ResumeLayout(false);
            this.grbEditUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUserList)).EndInit();
            this.ImportDataFromUSBFileData.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabUserUSB_BW.ResumeLayout(false);
            this.tabUserUSB_BW.PerformLayout();
            this.tabAttLogsUSB_BW.ResumeLayout(false);
            this.tabAttLogsUSB_BW.PerformLayout();
            this.tabTmp9USB_BW.ResumeLayout(false);
            this.tabTmp9USB_BW.PerformLayout();
            this.ImportDataFromUSBFileData_TFT.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabUser_TFT.ResumeLayout(false);
            this.tabUser_TFT.PerformLayout();
            this.tabAttLogs_TFT.ResumeLayout(false);
            this.tabAttLogs_TFT.PerformLayout();
            this.tabtmp9_TFT.ResumeLayout(false);
            this.tabtmp9_TFT.PerformLayout();
            this.tabTmp10_TFT.ResumeLayout(false);
            this.tabTmp10_TFT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMachineList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMachineList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMachineList;
        private System.Windows.Forms.TabPage LiveAttendance;
        private System.Windows.Forms.TabPage UserManagement;
        private DevExpress.XtraGrid.GridControl grdMachineList;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMachineList;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineAlias;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colIP;
        private DevExpress.XtraGrid.Columns.GridColumn colPort;
        private DevExpress.XtraGrid.Columns.GridColumn colmanagercount;
        private DevExpress.XtraGrid.Columns.GridColumn colusercount;
        private DevExpress.XtraGrid.Columns.GridColumn colfingercount;
        private DevExpress.XtraGrid.Columns.GridColumn colSecretCount;
        private DevExpress.XtraGrid.Columns.GridColumn colsn;
        private DevExpress.XtraEditors.SimpleButton btnConnect;
        private DevExpress.XtraEditors.SimpleButton btnDisconnect;
        private DevExpress.XtraGrid.Columns.GridColumn colLogCount;
        private DevExpress.XtraEditors.PictureEdit imgEmployeeImage;
        private DevExpress.XtraEditors.TextEdit txtAcNo;
        private System.Windows.Forms.Label lblACNo;
        private DevExpress.XtraEditors.TextEdit txtEmployeeID;
        private System.Windows.Forms.Label lblEmployeeID;
        private DevExpress.XtraEditors.TextEdit txtLogTime;
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private System.Windows.Forms.Label lblLogTime;
        private DevExpress.XtraEditors.TextEdit txtNameOnMachine;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblNameOnMachine;
        private DevExpress.XtraGrid.GridControl grdLogRecord;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLogRecord;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineName;
        private DevExpress.XtraGrid.Columns.GridColumn colNameOnMachine;
        private DevExpress.XtraGrid.Columns.GridColumn colLogTime;
        private DevExpress.XtraGrid.Columns.GridColumn colVerifyMode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpeVerifyMode;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit rpeDateTimeFormat;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.GridControl grdUserList;
        private DevExpress.XtraGrid.Views.Grid.GridView grvUserList;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colTemplateCount;
        private DevExpress.XtraGrid.Columns.GridColumn colCheck;
        private DevExpress.XtraEditors.TextEdit txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnDeleteEnrollData;
        private System.Windows.Forms.GroupBox grbEditUser;
        private System.Windows.Forms.Button btnClearAdministrators;
        private System.Windows.Forms.Button btnClearDataTmps;
        private System.Windows.Forms.Button btnClearDataUserInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colACNo;
        private System.Windows.Forms.CheckBox ckbDeleteOnSystem;
        private System.Windows.Forms.GroupBox grbUploadUserInfo;
        private System.Windows.Forms.GroupBox grbDownloadUserInfo;
        private System.Windows.Forms.Button btnDownloadUserInfo;
        private System.Windows.Forms.Button btnUploadUserInfo;
        private System.Windows.Forms.CheckBox ckbCheckAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDownloadAttLog;
        private System.Windows.Forms.Label lableInfor;
        private DevExpress.XtraGrid.Columns.GridColumn colCardNo;
        private DevExpress.XtraGrid.Columns.GridColumn PASSWORD;
        private System.Windows.Forms.CheckBox ckbClearAllLogAfterLoadSuccessfully;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private System.Windows.Forms.CheckBox ckbUploadFingerPrint;
        private System.Windows.Forms.CheckBox ckbUpdateCardNo;
        private System.Windows.Forms.GroupBox grbSetDeviceTime;
        private System.Windows.Forms.Button btnSynDeviceTime;
        private System.Windows.Forms.Button btnGetDeviceTime;
        private System.Windows.Forms.TextBox txtGetDeviceTime;
        private System.Windows.Forms.ComboBox cbSecond;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.ComboBox cbMinute;
        private System.Windows.Forms.Button btnSetDeviceTime2;
        private System.Windows.Forms.ComboBox cbDay;
        private System.Windows.Forms.ComboBox cbHour;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.Button btnPowerOffDevice;
        private System.Windows.Forms.Button btnRestartDevice;
        private System.Windows.Forms.TabPage ImportDataFromUSBFileData;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabUserUSB_BW;
        private System.Windows.Forms.Label lblUserUSB_BW_Note;
        private System.Windows.Forms.Button btnUserRead;
        private System.Windows.Forms.ListView lvUser;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.TabPage tabAttLogsUSB_BW;
        private System.Windows.Forms.Label lblAttLogsUSB_BW_note;
        private System.Windows.Forms.Button btnAttLogExtRead;
        private System.Windows.Forms.ListView lvAttLog;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ColumnHeader columnHeader29;
        private System.Windows.Forms.ColumnHeader columnHeader30;
        private System.Windows.Forms.TabPage tabTmp9USB_BW;
        private System.Windows.Forms.Label lblTmp9USB_BW_Note;
        private System.Windows.Forms.Button btnTmpRead;
        private System.Windows.Forms.ListView lvTmp;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage ImportDataFromUSBFileData_TFT;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabUser_TFT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSSR_UserRead;
        private System.Windows.Forms.ListView lvSSRUser;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.TabPage tabAttLogs_TFT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvSSRAttLog;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader31;
        private System.Windows.Forms.ColumnHeader columnHeader32;
        private System.Windows.Forms.ColumnHeader columnHeader33;
        private System.Windows.Forms.Button btnSSRAttLogRead;
        private System.Windows.Forms.TabPage tabtmp9_TFT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTemp9_TFT;
        private System.Windows.Forms.ListView lvTmp9;
        private System.Windows.Forms.ColumnHeader columnHeader34;
        private System.Windows.Forms.ColumnHeader columnHeader35;
        private System.Windows.Forms.ColumnHeader columnHeader36;
        private System.Windows.Forms.ColumnHeader columnHeader37;
        private System.Windows.Forms.ColumnHeader columnHeader38;
        private System.Windows.Forms.TabPage tabTmp10_TFT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lvTmp10;
        private System.Windows.Forms.ColumnHeader columnHeader42;
        private System.Windows.Forms.ColumnHeader columnHeader43;
        private System.Windows.Forms.ColumnHeader columnHeader44;
        private System.Windows.Forms.ColumnHeader columnHeader45;
        private System.Windows.Forms.ColumnHeader columnHeader46;
        private System.Windows.Forms.Button btnTmp10Read;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineKind;
        private System.Windows.Forms.Button btnDeleteAllData;
        private System.Windows.Forms.Button btnDelAllUserOnDatabase;
        private DevExpress.XtraGrid.Columns.GridColumn colCDKey;
        private System.Windows.Forms.CheckBox ckbLoadAll;
        private DevExpress.XtraEditors.DateEdit dtpToDate;
        private System.Windows.Forms.Label lblTodate;
        private DevExpress.XtraEditors.DateEdit dtpFromDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.CheckBox ckbOnlyDownNewEmp;
        private DevExpress.XtraGrid.Columns.GridColumn colImageIcon;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
    }
}