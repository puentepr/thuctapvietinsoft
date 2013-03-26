namespace HPA.MasterData
{
    partial class DataSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataSetting));
            this.txtFilter = new DevExpress.XtraEditors.TextEdit();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnCheckAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveLayout = new DevExpress.XtraEditors.SimpleButton();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerLeft = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dckFilter = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.grbFilter = new System.Windows.Forms.GroupBox();
            this.ChuaTimKiemVaGrid = new System.Windows.Forms.SplitContainer();
            this.btnReload = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdTableEditor = new DevExpress.XtraGrid.GridControl();
            this.grvTableEditor = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rpeNumberMask = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.rpeDateTimeMask = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.pnlFWCommand.SuspendLayout();
            this.pnlFWClose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.hideContainerLeft.SuspendLayout();
            this.dckFilter.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChuaTimKiemVaGrid)).BeginInit();
            this.ChuaTimKiemVaGrid.Panel1.SuspendLayout();
            this.ChuaTimKiemVaGrid.Panel2.SuspendLayout();
            this.ChuaTimKiemVaGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTableEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTableEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpeNumberMask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpeDateTimeMask)).BeginInit();
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
            this.btnFWDelete.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWDelete.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWDelete.Appearance.Options.UseFont = true;
            this.btnFWDelete.Appearance.Options.UseForeColor = true;
            this.btnFWDelete.Click += new System.EventHandler(this.btnFWDelete_Click);
            // 
            // btnFWSave
            // 
            this.btnFWSave.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWSave.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWSave.Appearance.Options.UseFont = true;
            this.btnFWSave.Appearance.Options.UseForeColor = true;
            this.btnFWSave.Click += new System.EventHandler(this.btnFWSave_Click);
            // 
            // btnFWAdd
            // 
            this.btnFWAdd.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWAdd.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWAdd.Appearance.Options.UseFont = true;
            this.btnFWAdd.Appearance.Options.UseForeColor = true;
            // 
            // btnFWClose
            // 
            this.btnFWClose.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWClose.Appearance.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btnFWClose.Appearance.Options.UseFont = true;
            this.btnFWClose.Appearance.Options.UseForeColor = true;
            this.btnFWClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            // 
            // btnFWReset
            // 
            this.btnFWReset.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWReset.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWReset.Appearance.Options.UseFont = true;
            this.btnFWReset.Appearance.Options.UseForeColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnExport.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Appearance.Options.UseForeColor = true;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(77, 8);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Properties.MaxLength = 20;
            this.txtFilter.Size = new System.Drawing.Size(279, 20);
            this.txtFilter.TabIndex = 161;
            this.txtFilter.EditValueChanged += new System.EventHandler(this.txtFilter_EditValueChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(10, 11);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(61, 13);
            this.lblSearch.TabIndex = 160;
            this.lblSearch.Text = "First name:";
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckAll.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCheckAll.Appearance.Options.UseFont = true;
            this.btnCheckAll.Location = new System.Drawing.Point(698, 6);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(110, 27);
            this.btnCheckAll.TabIndex = 110;
            this.btnCheckAll.Text = "simpleButton1";
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnSaveLayout
            // 
            this.btnSaveLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveLayout.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSaveLayout.Appearance.Options.UseFont = true;
            this.btnSaveLayout.Location = new System.Drawing.Point(582, 6);
            this.btnSaveLayout.Name = "btnSaveLayout";
            this.btnSaveLayout.Size = new System.Drawing.Size(110, 27);
            this.btnSaveLayout.TabIndex = 110;
            this.btnSaveLayout.Text = "simpleButton1";
            this.btnSaveLayout.Click += new System.EventHandler(this.btnSaveLayout_Click);
            // 
            // dockManager1
            // 
            this.dockManager1.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerLeft});
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // hideContainerLeft
            // 
            this.hideContainerLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.hideContainerLeft.Controls.Add(this.dckFilter);
            this.hideContainerLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.hideContainerLeft.Location = new System.Drawing.Point(0, 0);
            this.hideContainerLeft.Name = "hideContainerLeft";
            this.hideContainerLeft.Size = new System.Drawing.Size(19, 502);
            // 
            // dckFilter
            // 
            this.dckFilter.Controls.Add(this.dockPanel1_Container);
            this.dckFilter.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dckFilter.ID = new System.Guid("6e503ba9-cffd-42b1-beb9-a87ebe849814");
            this.dckFilter.Location = new System.Drawing.Point(0, 0);
            this.dckFilter.Name = "dckFilter";
            this.dckFilter.Options.ShowCloseButton = false;
            this.dckFilter.OriginalSize = new System.Drawing.Size(336, 545);
            this.dckFilter.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dckFilter.SavedIndex = 0;
            this.dckFilter.Size = new System.Drawing.Size(336, 545);
            this.dckFilter.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            this.dckFilter.VisibilityChanged += new DevExpress.XtraBars.Docking.VisibilityChangedEventHandler(this.dckFilter_VisibilityChanged);
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.grbFilter);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(328, 518);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // grbFilter
            // 
            this.grbFilter.Location = new System.Drawing.Point(3, -5);
            this.grbFilter.Name = "grbFilter";
            this.grbFilter.Size = new System.Drawing.Size(322, 100);
            this.grbFilter.TabIndex = 0;
            this.grbFilter.TabStop = false;
            // 
            // ChuaTimKiemVaGrid
            // 
            this.ChuaTimKiemVaGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChuaTimKiemVaGrid.Location = new System.Drawing.Point(19, 0);
            this.ChuaTimKiemVaGrid.Name = "ChuaTimKiemVaGrid";
            this.ChuaTimKiemVaGrid.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ChuaTimKiemVaGrid.Panel1
            // 
            this.ChuaTimKiemVaGrid.Panel1.Controls.Add(this.btnReload);
            this.ChuaTimKiemVaGrid.Panel1.Controls.Add(this.lblSearch);
            this.ChuaTimKiemVaGrid.Panel1.Controls.Add(this.txtFilter);
            this.ChuaTimKiemVaGrid.Panel1Collapsed = true;
            this.ChuaTimKiemVaGrid.Panel1MinSize = 0;
            // 
            // ChuaTimKiemVaGrid.Panel2
            // 
            this.ChuaTimKiemVaGrid.Panel2.Controls.Add(this.splitContainer1);
            this.ChuaTimKiemVaGrid.Panel2MinSize = 0;
            this.ChuaTimKiemVaGrid.Size = new System.Drawing.Size(965, 502);
            this.ChuaTimKiemVaGrid.SplitterDistance = 33;
            this.ChuaTimKiemVaGrid.TabIndex = 165;
            // 
            // btnReload
            // 
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReload.Location = new System.Drawing.Point(362, 6);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 111;
            this.btnReload.Text = "button1";
            this.btnReload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdTableEditor);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(965, 502);
            this.splitContainer1.SplitterDistance = 247;
            this.splitContainer1.TabIndex = 60;
            // 
            // grdTableEditor
            // 
            this.grdTableEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTableEditor.Location = new System.Drawing.Point(0, 0);
            this.grdTableEditor.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdTableEditor.MainView = this.grvTableEditor;
            this.grdTableEditor.Name = "grdTableEditor";
            this.grdTableEditor.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpeNumberMask,
            this.rpeDateTimeMask});
            this.grdTableEditor.Size = new System.Drawing.Size(965, 251);
            this.grdTableEditor.TabIndex = 58;
            this.grdTableEditor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTableEditor});
            // 
            // grvTableEditor
            // 
            this.grvTableEditor.GridControl = this.grdTableEditor;
            this.grvTableEditor.Name = "grvTableEditor";
            this.grvTableEditor.OptionsNavigation.AutoFocusNewRow = true;
            this.grvTableEditor.OptionsSelection.MultiSelect = true;
            this.grvTableEditor.OptionsView.ColumnAutoWidth = false;
            this.grvTableEditor.OptionsView.ShowFooter = true;
            this.grvTableEditor.OptionsView.ShowGroupPanel = false;
            // 
            // rpeNumberMask
            // 
            this.rpeNumberMask.AutoHeight = false;
            this.rpeNumberMask.Mask.EditMask = "###,###,###,##0";
            this.rpeNumberMask.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rpeNumberMask.Name = "rpeNumberMask";
            // 
            // rpeDateTimeMask
            // 
            this.rpeDateTimeMask.AutoHeight = false;
            this.rpeDateTimeMask.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rpeDateTimeMask.Mask.EditMask = "HH:mm:ss";
            this.rpeDateTimeMask.Mask.UseMaskAsDisplayFormat = true;
            this.rpeDateTimeMask.Name = "rpeDateTimeMask";
            // 
            // DataSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnFWClose;
            this.ClientSize = new System.Drawing.Size(984, 545);
            this.Controls.Add(this.ChuaTimKiemVaGrid);
            this.Controls.Add(this.hideContainerLeft);
            this.KeyPreview = true;
            this.LookAndFeel.SkinName = "Seven";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "DataSetting";
            this.Text = "DataSetting";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataSetting_KeyDown);
            this.Controls.SetChildIndex(this.lblFWDecorateingLine, 0);
            this.Controls.SetChildIndex(this.pnlFWCommand, 0);
            this.Controls.SetChildIndex(this.hideContainerLeft, 0);
            this.Controls.SetChildIndex(this.ChuaTimKiemVaGrid, 0);
            this.pnlFWCommand.ResumeLayout(false);
            this.pnlFWClose.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.hideContainerLeft.ResumeLayout(false);
            this.dckFilter.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.ChuaTimKiemVaGrid.Panel1.ResumeLayout(false);
            this.ChuaTimKiemVaGrid.Panel1.PerformLayout();
            this.ChuaTimKiemVaGrid.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChuaTimKiemVaGrid)).EndInit();
            this.ChuaTimKiemVaGrid.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTableEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTableEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpeNumberMask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpeDateTimeMask)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtFilter;
        private System.Windows.Forms.Label lblSearch;
        private DevExpress.XtraEditors.SimpleButton btnCheckAll;
        private DevExpress.XtraEditors.SimpleButton btnSaveLayout;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dckFilter;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerLeft;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.SplitContainer ChuaTimKiemVaGrid;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl grdTableEditor;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTableEditor;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rpeNumberMask;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit rpeDateTimeMask;
        private System.Windows.Forms.GroupBox grbFilter;
        

    }
}