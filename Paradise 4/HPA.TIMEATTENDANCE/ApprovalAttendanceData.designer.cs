namespace HPA.TimeAttendance
{
    partial class ApprovalAttendanceData
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
            this.grdAttendanceList = new DevExpress.XtraGrid.GridControl();
            this.grvAttendanceList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rpeNumberFormat = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cbxDepartment = new DevExpress.XtraEditors.LookUpEdit();
            this.lblYear = new System.Windows.Forms.Label();
            this.cbxYear = new DevExpress.XtraEditors.LookUpEdit();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cbxMonth = new DevExpress.XtraEditors.LookUpEdit();
            this.txtEmployeeID_Search = new DevExpress.XtraEditors.TextEdit();
            this.txtFullNameSearch = new DevExpress.XtraEditors.TextEdit();
            this.lblEmpID = new System.Windows.Forms.Label();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.pnlFWCommand.SuspendLayout();
            this.pnlFWClose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAttendanceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAttendanceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpeNumberFormat)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeID_Search.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullNameSearch.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFWCommand
            // 
            this.pnlFWCommand.Location = new System.Drawing.Point(0, 582);
            this.pnlFWCommand.Size = new System.Drawing.Size(1018, 38);
            // 
            // btnFWDelete
            // 
            this.btnFWDelete.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWDelete.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWDelete.Appearance.Options.UseFont = true;
            this.btnFWDelete.Appearance.Options.UseForeColor = true;
            this.btnFWDelete.LookAndFeel.SkinName = "Blue";
            this.btnFWDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnFWSave
            // 
            this.btnFWSave.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWSave.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWSave.Appearance.Options.UseFont = true;
            this.btnFWSave.Appearance.Options.UseForeColor = true;
            this.btnFWSave.LookAndFeel.SkinName = "Blue";
            this.btnFWSave.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnFWAdd
            // 
            this.btnFWAdd.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWAdd.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWAdd.Appearance.Options.UseFont = true;
            this.btnFWAdd.Appearance.Options.UseForeColor = true;
            this.btnFWAdd.LookAndFeel.SkinName = "Blue";
            this.btnFWAdd.LookAndFeel.UseDefaultLookAndFeel = false;
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
            this.lblFWDecorateingLine.Location = new System.Drawing.Point(0, 620);
            this.lblFWDecorateingLine.Size = new System.Drawing.Size(1018, 2);
            // 
            // btnFWReset
            // 
            this.btnFWReset.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWReset.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWReset.Appearance.Options.UseFont = true;
            this.btnFWReset.Appearance.Options.UseForeColor = true;
            this.btnFWReset.LookAndFeel.SkinName = "Blue";
            this.btnFWReset.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnExport
            // 
            this.btnExport.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnExport.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Appearance.Options.UseForeColor = true;
            this.btnExport.LookAndFeel.SkinName = "Blue";
            this.btnExport.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // grdAttendanceList
            // 
            this.grdAttendanceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAttendanceList.EmbeddedNavigator.Name = "";
            this.grdAttendanceList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdAttendanceList.FormsUseDefaultLookAndFeel = false;
            this.grdAttendanceList.Location = new System.Drawing.Point(-3, 48);
            this.grdAttendanceList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdAttendanceList.MainView = this.grvAttendanceList;
            this.grdAttendanceList.Name = "grdAttendanceList";
            this.grdAttendanceList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpeNumberFormat});
            this.grdAttendanceList.Size = new System.Drawing.Size(1024, 528);
            this.grdAttendanceList.TabIndex = 67;
            this.grdAttendanceList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAttendanceList});
            // 
            // grvAttendanceList
            // 
            this.grvAttendanceList.GridControl = this.grdAttendanceList;
            this.grvAttendanceList.Name = "grvAttendanceList";
            this.grvAttendanceList.OptionsBehavior.AllowIncrementalSearch = true;
            this.grvAttendanceList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvAttendanceList.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvAttendanceList.OptionsSelection.UseIndicatorForSelection = false;
            this.grvAttendanceList.OptionsView.ColumnAutoWidth = false;
            this.grvAttendanceList.OptionsView.ShowFooter = true;
            this.grvAttendanceList.OptionsView.ShowGroupPanel = false;
            this.grvAttendanceList.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvAttendanceList_RowCellStyle);
            // 
            // rpeNumberFormat
            // 
            this.rpeNumberFormat.AutoHeight = false;
            this.rpeNumberFormat.Mask.EditMask = "##0.#0";
            this.rpeNumberFormat.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rpeNumberFormat.Mask.UseMaskAsDisplayFormat = true;
            this.rpeNumberFormat.Name = "rpeNumberFormat";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDepartment);
            this.groupBox2.Controls.Add(this.cbxDepartment);
            this.groupBox2.Controls.Add(this.lblYear);
            this.groupBox2.Controls.Add(this.cbxYear);
            this.groupBox2.Controls.Add(this.lblMonth);
            this.groupBox2.Controls.Add(this.cbxMonth);
            this.groupBox2.Location = new System.Drawing.Point(3, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(517, 41);
            this.groupBox2.TabIndex = 68;
            this.groupBox2.TabStop = false;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(255, 16);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(35, 13);
            this.lblDepartment.TabIndex = 71;
            this.lblDepartment.Text = "label1";
            this.lblDepartment.Visible = false;
            // 
            // cbxDepartment
            // 
            this.cbxDepartment.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbxDepartment.Location = new System.Drawing.Point(335, 13);
            this.cbxDepartment.Name = "cbxDepartment";
            this.cbxDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxDepartment.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentCode", "Code", 50),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentName", "Department", 120)});
            this.cbxDepartment.Properties.DisplayMember = "DepartmentName";
            this.cbxDepartment.Properties.NullText = " ";
            this.cbxDepartment.Properties.ValueMember = "DepartmentID";
            this.cbxDepartment.Size = new System.Drawing.Size(176, 20);
            this.cbxDepartment.TabIndex = 72;
            this.cbxDepartment.Visible = false;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(117, 16);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(35, 13);
            this.lblYear.TabIndex = 69;
            this.lblYear.Text = "label1";
            // 
            // cbxYear
            // 
            this.cbxYear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbxYear.Location = new System.Drawing.Point(176, 13);
            this.cbxYear.Name = "cbxYear";
            this.cbxYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxYear.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YearList", "Year", 50)});
            this.cbxYear.Properties.DisplayMember = "YearList";
            this.cbxYear.Properties.NullText = " ";
            this.cbxYear.Properties.ValueMember = "YearList";
            this.cbxYear.Size = new System.Drawing.Size(73, 20);
            this.cbxYear.TabIndex = 68;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(6, 16);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(35, 13);
            this.lblMonth.TabIndex = 70;
            this.lblMonth.Text = "label1";
            // 
            // cbxMonth
            // 
            this.cbxMonth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbxMonth.Location = new System.Drawing.Point(47, 13);
            this.cbxMonth.Name = "cbxMonth";
            this.cbxMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxMonth.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Month", "Month", 50)});
            this.cbxMonth.Properties.DisplayMember = "Month";
            this.cbxMonth.Properties.NullText = " ";
            this.cbxMonth.Properties.ValueMember = "Month";
            this.cbxMonth.Size = new System.Drawing.Size(67, 20);
            this.cbxMonth.TabIndex = 67;
            // 
            // txtEmployeeID_Search
            // 
            this.txtEmployeeID_Search.EditValue = "";
            this.txtEmployeeID_Search.Location = new System.Drawing.Point(689, 14);
            this.txtEmployeeID_Search.Name = "txtEmployeeID_Search";
            this.txtEmployeeID_Search.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmployeeID_Search.Properties.Appearance.Options.UseBackColor = true;
            this.txtEmployeeID_Search.Properties.MaxLength = 20;
            this.txtEmployeeID_Search.Size = new System.Drawing.Size(73, 20);
            this.txtEmployeeID_Search.TabIndex = 70;
            this.txtEmployeeID_Search.EditValueChanged += new System.EventHandler(this.txtEmployeeID_Search_EditValueChanged);
            // 
            // txtFullNameSearch
            // 
            this.txtFullNameSearch.Location = new System.Drawing.Point(768, 14);
            this.txtFullNameSearch.Name = "txtFullNameSearch";
            this.txtFullNameSearch.Properties.MaxLength = 50;
            this.txtFullNameSearch.Size = new System.Drawing.Size(129, 20);
            this.txtFullNameSearch.TabIndex = 71;
            this.txtFullNameSearch.EditValueChanged += new System.EventHandler(this.txtFullNameSearch_EditValueChanged);
            // 
            // lblEmpID
            // 
            this.lblEmpID.AutoSize = true;
            this.lblEmpID.Location = new System.Drawing.Point(648, 17);
            this.lblEmpID.Name = "lblEmpID";
            this.lblEmpID.Size = new System.Drawing.Size(35, 13);
            this.lblEmpID.TabIndex = 69;
            this.lblEmpID.Text = "label1";
            // 
            // btnLoad
            // 
            this.btnLoad.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLoad.Appearance.Options.UseFont = true;
            this.btnLoad.Location = new System.Drawing.Point(526, 7);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(97, 27);
            this.btnLoad.TabIndex = 72;
            this.btnLoad.Text = "simpleButton1";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // ApprovalAttendanceData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 622);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtEmployeeID_Search);
            this.Controls.Add(this.txtFullNameSearch);
            this.Controls.Add(this.lblEmpID);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grdAttendanceList);
            this.Name = "ApprovalAttendanceData";
            this.Text = "ApprovalAttendanceData";
            this.Controls.SetChildIndex(this.lblFWDecorateingLine, 0);
            this.Controls.SetChildIndex(this.pnlFWCommand, 0);
            this.Controls.SetChildIndex(this.grdAttendanceList, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.lblEmpID, 0);
            this.Controls.SetChildIndex(this.txtFullNameSearch, 0);
            this.Controls.SetChildIndex(this.txtEmployeeID_Search, 0);
            this.Controls.SetChildIndex(this.btnLoad, 0);
            this.pnlFWCommand.ResumeLayout(false);
            this.pnlFWClose.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAttendanceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAttendanceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpeNumberFormat)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeID_Search.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullNameSearch.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdAttendanceList;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAttendanceList;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rpeNumberFormat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblYear;
        private DevExpress.XtraEditors.LookUpEdit cbxYear;
        private System.Windows.Forms.Label lblMonth;
        private DevExpress.XtraEditors.LookUpEdit cbxMonth;
        private DevExpress.XtraEditors.TextEdit txtEmployeeID_Search;
        private DevExpress.XtraEditors.TextEdit txtFullNameSearch;
        private System.Windows.Forms.Label lblEmpID;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
        private System.Windows.Forms.Label lblDepartment;
        private DevExpress.XtraEditors.LookUpEdit cbxDepartment;
    }
}