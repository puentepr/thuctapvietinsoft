namespace HPA.Report
{
    partial class ExportReport
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
            this.grbExportListFilter = new System.Windows.Forms.GroupBox();
            this.txtLastName = new DevExpress.XtraEditors.TextEdit();
            this.lblSearch = new System.Windows.Forms.Label();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.grdExportList = new DevExpress.XtraGrid.GridControl();
            this.grvExportList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReportName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProcedureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xpbProcecess = new DevExpress.XtraEditors.ProgressBarControl();
            this.txtExcelFileName = new DevExpress.XtraEditors.TextEdit();
            this.txtStartRow = new DevExpress.XtraEditors.TextEdit();
            this.txtStartColumn = new DevExpress.XtraEditors.TextEdit();
            this.txtExportType = new DevExpress.XtraEditors.TextEdit();
            this.grbFilter = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grbExportOption = new System.Windows.Forms.GroupBox();
            this.ckbCSV = new System.Windows.Forms.CheckBox();
            this.radValueOnly = new System.Windows.Forms.RadioButton();
            this.ckbIncludedColumnName = new System.Windows.Forms.CheckBox();
            this.ckbToneMarks = new System.Windows.Forms.CheckBox();
            this.ckbWithoutTemp = new System.Windows.Forms.CheckBox();
            this.radWithLable = new System.Windows.Forms.RadioButton();
            this.grbFileName = new System.Windows.Forms.GroupBox();
            this.xbeFileName = new DevExpress.XtraEditors.ButtonEdit();
            this.pnlInformation = new System.Windows.Forms.Panel();
            this.lblExporting = new System.Windows.Forms.Label();
            this.pnlFWCommand.SuspendLayout();
            this.pnlFWClose.SuspendLayout();
            this.grbExportListFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdExportList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvExportList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpbProcecess.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExcelFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartRow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartColumn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExportType.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grbExportOption.SuspendLayout();
            this.grbFileName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xbeFileName.Properties)).BeginInit();
            this.pnlInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDesignForm
            // 
            this.btnDesignForm.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDesignForm.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnDesignForm.Appearance.Options.UseFont = true;
            this.btnDesignForm.Appearance.Options.UseForeColor = true;
            // 
            // btnFWDelete
            // 
            this.btnFWDelete.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWDelete.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWDelete.Appearance.Options.UseFont = true;
            this.btnFWDelete.Appearance.Options.UseForeColor = true;
            this.btnFWDelete.Location = new System.Drawing.Point(396, 6);
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
            this.btnFWSave.Location = new System.Drawing.Point(481, 6);
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
            this.btnFWAdd.Location = new System.Drawing.Point(319, 6);
            this.btnFWAdd.LookAndFeel.SkinName = "Blue";
            this.btnFWAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFWAdd.Visible = false;
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
            // btnFWReset
            // 
            this.btnFWReset.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWReset.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWReset.Appearance.Options.UseFont = true;
            this.btnFWReset.Appearance.Options.UseForeColor = true;
            this.btnFWReset.Location = new System.Drawing.Point(561, 6);
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
            this.btnExport.Location = new System.Drawing.Point(4, 6);
            this.btnExport.LookAndFeel.SkinName = "Blue";
            this.btnExport.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExport.Size = new System.Drawing.Size(118, 27);
            this.btnExport.Text = "&Export";
            // 
            // grbExportListFilter
            // 
            this.grbExportListFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbExportListFilter.Controls.Add(this.txtLastName);
            this.grbExportListFilter.Controls.Add(this.lblSearch);
            this.grbExportListFilter.Controls.Add(this.radAll);
            this.grbExportListFilter.Location = new System.Drawing.Point(4, 1);
            this.grbExportListFilter.Name = "grbExportListFilter";
            this.grbExportListFilter.Size = new System.Drawing.Size(445, 76);
            this.grbExportListFilter.TabIndex = 54;
            this.grbExportListFilter.TabStop = false;
            this.grbExportListFilter.Text = "Report list option";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(73, 48);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Properties.MaxLength = 50;
            this.txtLastName.Size = new System.Drawing.Size(368, 20);
            this.txtLastName.TabIndex = 2;
            this.txtLastName.EditValueChanged += new System.EventHandler(this.txtLastName_EditValueChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(15, 51);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(35, 13);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "label1";
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Location = new System.Drawing.Point(8, 16);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(36, 17);
            this.radAll.TabIndex = 0;
            this.radAll.Text = "All";
            this.radAll.CheckedChanged += new System.EventHandler(this.radAll_CheckedChanged);
            // 
            // grdExportList
            // 
            this.grdExportList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdExportList.Location = new System.Drawing.Point(0, 83);
            this.grdExportList.MainView = this.grvExportList;
            this.grdExportList.Name = "grdExportList";
            this.grdExportList.Size = new System.Drawing.Size(445, 415);
            this.grdExportList.TabIndex = 55;
            this.grdExportList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvExportList});
            // 
            // grvExportList
            // 
            this.grvExportList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colReportName,
            this.colCategory,
            this.colProcedureName});
            this.grvExportList.GridControl = this.grdExportList;
            this.grvExportList.Name = "grvExportList";
            this.grvExportList.OptionsView.ColumnAutoWidth = false;
            this.grvExportList.OptionsView.ShowGroupPanel = false;
            this.grvExportList.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.grvExportList_SelectionChanged);
            this.grvExportList.Click += new System.EventHandler(this.grvExportList_Click);
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "ExportName";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Width = 91;
            // 
            // colReportName
            // 
            this.colReportName.Caption = "Description";
            this.colReportName.FieldName = "Description";
            this.colReportName.Name = "colReportName";
            this.colReportName.OptionsColumn.AllowEdit = false;
            this.colReportName.Visible = true;
            this.colReportName.VisibleIndex = 0;
            this.colReportName.Width = 356;
            // 
            // colCategory
            // 
            this.colCategory.Caption = "Catalog";
            this.colCategory.FieldName = "Catalog";
            this.colCategory.Name = "colCategory";
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 1;
            // 
            // colProcedureName
            // 
            this.colProcedureName.Caption = "ProcedureName";
            this.colProcedureName.FieldName = "ProcedureName";
            this.colProcedureName.Name = "colProcedureName";
            // 
            // xpbProcecess
            // 
            this.xpbProcecess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xpbProcecess.Location = new System.Drawing.Point(455, 476);
            this.xpbProcecess.Name = "xpbProcecess";
            this.xpbProcecess.Size = new System.Drawing.Size(336, 22);
            this.xpbProcecess.TabIndex = 59;
            // 
            // txtExcelFileName
            // 
            this.txtExcelFileName.Location = new System.Drawing.Point(251, 205);
            this.txtExcelFileName.Name = "txtExcelFileName";
            this.txtExcelFileName.Size = new System.Drawing.Size(75, 20);
            this.txtExcelFileName.TabIndex = 63;
            // 
            // txtStartRow
            // 
            this.txtStartRow.Location = new System.Drawing.Point(347, 205);
            this.txtStartRow.Name = "txtStartRow";
            this.txtStartRow.Size = new System.Drawing.Size(75, 20);
            this.txtStartRow.TabIndex = 64;
            // 
            // txtStartColumn
            // 
            this.txtStartColumn.Location = new System.Drawing.Point(99, 165);
            this.txtStartColumn.Name = "txtStartColumn";
            this.txtStartColumn.Size = new System.Drawing.Size(75, 20);
            this.txtStartColumn.TabIndex = 60;
            // 
            // txtExportType
            // 
            this.txtExportType.Location = new System.Drawing.Point(99, 245);
            this.txtExportType.Name = "txtExportType";
            this.txtExportType.Size = new System.Drawing.Size(75, 20);
            this.txtExportType.TabIndex = 61;
            // 
            // grbFilter
            // 
            this.grbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grbFilter.Location = new System.Drawing.Point(9, 9);
            this.grbFilter.Name = "grbFilter";
            this.grbFilter.Size = new System.Drawing.Size(336, 112);
            this.grbFilter.TabIndex = 65;
            this.grbFilter.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.grbFilter);
            this.groupBox1.Controls.Add(this.grbExportOption);
            this.groupBox1.Location = new System.Drawing.Point(446, -8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 507);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            // 
            // grbExportOption
            // 
            this.grbExportOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grbExportOption.Controls.Add(this.ckbCSV);
            this.grbExportOption.Controls.Add(this.radValueOnly);
            this.grbExportOption.Controls.Add(this.ckbIncludedColumnName);
            this.grbExportOption.Controls.Add(this.ckbToneMarks);
            this.grbExportOption.Controls.Add(this.ckbWithoutTemp);
            this.grbExportOption.Controls.Add(this.radWithLable);
            this.grbExportOption.Location = new System.Drawing.Point(6, 372);
            this.grbExportOption.Name = "grbExportOption";
            this.grbExportOption.Size = new System.Drawing.Size(336, 106);
            this.grbExportOption.TabIndex = 57;
            this.grbExportOption.TabStop = false;
            this.grbExportOption.Text = "Export excel option";
            this.grbExportOption.Visible = false;
            // 
            // ckbCSV
            // 
            this.ckbCSV.AutoSize = true;
            this.ckbCSV.Location = new System.Drawing.Point(8, 40);
            this.ckbCSV.Name = "ckbCSV";
            this.ckbCSV.Size = new System.Drawing.Size(107, 17);
            this.ckbCSV.TabIndex = 1;
            this.ckbCSV.Text = "Export to csv file";
            // 
            // radValueOnly
            // 
            this.radValueOnly.Location = new System.Drawing.Point(8, 134);
            this.radValueOnly.Name = "radValueOnly";
            this.radValueOnly.Size = new System.Drawing.Size(296, 24);
            this.radValueOnly.TabIndex = 0;
            this.radValueOnly.Text = "Export included condition value only";
            this.radValueOnly.Visible = false;
            // 
            // ckbIncludedColumnName
            // 
            this.ckbIncludedColumnName.AutoSize = true;
            this.ckbIncludedColumnName.Location = new System.Drawing.Point(8, 87);
            this.ckbIncludedColumnName.Name = "ckbIncludedColumnName";
            this.ckbIncludedColumnName.Size = new System.Drawing.Size(137, 17);
            this.ckbIncludedColumnName.TabIndex = 1;
            this.ckbIncludedColumnName.Text = "Included columns name";
            // 
            // ckbToneMarks
            // 
            this.ckbToneMarks.AutoSize = true;
            this.ckbToneMarks.Location = new System.Drawing.Point(8, 64);
            this.ckbToneMarks.Name = "ckbToneMarks";
            this.ckbToneMarks.Size = new System.Drawing.Size(121, 17);
            this.ckbToneMarks.TabIndex = 1;
            this.ckbToneMarks.Text = "Remove tone marks";
            // 
            // ckbWithoutTemp
            // 
            this.ckbWithoutTemp.AutoSize = true;
            this.ckbWithoutTemp.Location = new System.Drawing.Point(8, 16);
            this.ckbWithoutTemp.Name = "ckbWithoutTemp";
            this.ckbWithoutTemp.Size = new System.Drawing.Size(142, 17);
            this.ckbWithoutTemp.TabIndex = 54;
            this.ckbWithoutTemp.Text = "Export without template";
            // 
            // radWithLable
            // 
            this.radWithLable.Location = new System.Drawing.Point(8, 115);
            this.radWithLable.Name = "radWithLable";
            this.radWithLable.Size = new System.Drawing.Size(272, 24);
            this.radWithLable.TabIndex = 0;
            this.radWithLable.Text = "Export included condition value and lable";
            this.radWithLable.Visible = false;
            // 
            // grbFileName
            // 
            this.grbFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grbFileName.Controls.Add(this.xbeFileName);
            this.grbFileName.Location = new System.Drawing.Point(68, 271);
            this.grbFileName.Name = "grbFileName";
            this.grbFileName.Size = new System.Drawing.Size(336, 42);
            this.grbFileName.TabIndex = 58;
            this.grbFileName.TabStop = false;
            this.grbFileName.Text = "Save to file";
            this.grbFileName.Visible = false;
            // 
            // xbeFileName
            // 
            this.xbeFileName.EditValue = "gfdgd";
            this.xbeFileName.Location = new System.Drawing.Point(8, 16);
            this.xbeFileName.Name = "xbeFileName";
            this.xbeFileName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.xbeFileName.Size = new System.Drawing.Size(322, 20);
            this.xbeFileName.TabIndex = 59;
            this.xbeFileName.Visible = false;
            this.xbeFileName.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit1_ButtonClick);
            // 
            // pnlInformation
            // 
            this.pnlInformation.BackColor = System.Drawing.SystemColors.Info;
            this.pnlInformation.Controls.Add(this.lblExporting);
            this.pnlInformation.Location = new System.Drawing.Point(240, 208);
            this.pnlInformation.Name = "pnlInformation";
            this.pnlInformation.Size = new System.Drawing.Size(307, 73);
            this.pnlInformation.TabIndex = 67;
            this.pnlInformation.Visible = false;
            this.pnlInformation.MouseEnter += new System.EventHandler(this.pnlInformation_MouseEnter);
            this.pnlInformation.MouseLeave += new System.EventHandler(this.pnlInformation_MouseLeave);
            // 
            // lblExporting
            // 
            this.lblExporting.AutoSize = true;
            this.lblExporting.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExporting.Location = new System.Drawing.Point(3, 20);
            this.lblExporting.Name = "lblExporting";
            this.lblExporting.Size = new System.Drawing.Size(66, 24);
            this.lblExporting.TabIndex = 1;
            this.lblExporting.Text = "label1";
            // 
            // ExportReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 545);
            this.Controls.Add(this.pnlInformation);
            this.Controls.Add(this.grdExportList);
            this.Controls.Add(this.txtExcelFileName);
            this.Controls.Add(this.grbFileName);
            this.Controls.Add(this.txtStartRow);
            this.Controls.Add(this.txtStartColumn);
            this.Controls.Add(this.txtExportType);
            this.Controls.Add(this.xpbProcecess);
            this.Controls.Add(this.grbExportListFilter);
            this.Controls.Add(this.groupBox1);
            this.LookAndFeel.SkinName = "Seven";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "ExportReport";
            this.Text = "ExportReport";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grbExportListFilter, 0);
            this.Controls.SetChildIndex(this.xpbProcecess, 0);
            this.Controls.SetChildIndex(this.txtExportType, 0);
            this.Controls.SetChildIndex(this.txtStartColumn, 0);
            this.Controls.SetChildIndex(this.txtStartRow, 0);
            this.Controls.SetChildIndex(this.grbFileName, 0);
            this.Controls.SetChildIndex(this.txtExcelFileName, 0);
            this.Controls.SetChildIndex(this.grdExportList, 0);
            this.Controls.SetChildIndex(this.pnlInformation, 0);
            this.Controls.SetChildIndex(this.lblFWDecorateingLine, 0);
            this.Controls.SetChildIndex(this.pnlFWCommand, 0);
            this.pnlFWCommand.ResumeLayout(false);
            this.pnlFWClose.ResumeLayout(false);
            this.grbExportListFilter.ResumeLayout(false);
            this.grbExportListFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdExportList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvExportList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpbProcecess.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExcelFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartRow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartColumn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExportType.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.grbExportOption.ResumeLayout(false);
            this.grbExportOption.PerformLayout();
            this.grbFileName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xbeFileName.Properties)).EndInit();
            this.pnlInformation.ResumeLayout(false);
            this.pnlInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbExportListFilter;
        private System.Windows.Forms.RadioButton radAll;
        private DevExpress.XtraGrid.GridControl grdExportList;
        private DevExpress.XtraGrid.Views.Grid.GridView grvExportList;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colReportName;
        private DevExpress.XtraEditors.ProgressBarControl xpbProcecess;
        private DevExpress.XtraEditors.TextEdit txtExcelFileName;
        private DevExpress.XtraEditors.TextEdit txtStartRow;
        private DevExpress.XtraEditors.TextEdit txtStartColumn;
        private DevExpress.XtraEditors.TextEdit txtExportType;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private System.Windows.Forms.GroupBox grbFilter;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.Columns.GridColumn colProcedureName;
        private DevExpress.XtraEditors.TextEdit txtLastName;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.GroupBox grbExportOption;
        private System.Windows.Forms.CheckBox ckbCSV;
        private System.Windows.Forms.RadioButton radValueOnly;
        private System.Windows.Forms.CheckBox ckbIncludedColumnName;
        private System.Windows.Forms.CheckBox ckbToneMarks;
        private System.Windows.Forms.CheckBox ckbWithoutTemp;
        private System.Windows.Forms.RadioButton radWithLable;
        private System.Windows.Forms.GroupBox grbFileName;
        private DevExpress.XtraEditors.ButtonEdit xbeFileName;
        private System.Windows.Forms.Panel pnlInformation;
        private System.Windows.Forms.Label lblExporting;
    }
}