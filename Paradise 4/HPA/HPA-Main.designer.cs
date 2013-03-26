namespace HPA
{
    partial class HPA_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HPA_Main));
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.MnuMain = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHome = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuCloseAllWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuLock = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuAppSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckIdleTimer = new System.Windows.Forms.Timer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblToolUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtToolUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtToolServerInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtDatabaseName = new System.Windows.Forms.ToolStripStatusLabel();
            this.xtraTabbedMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager();
            this.MnuMain.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager)).BeginInit();
            this.SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.AutoScroll = true;
            this.ContentPanel.Size = new System.Drawing.Size(991, 734);
            // 
            // MnuMain
            // 
            this.MnuMain.BackColor = System.Drawing.SystemColors.Control;
            this.MnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem});
            this.MnuMain.Location = new System.Drawing.Point(0, 0);
            this.MnuMain.Name = "MnuMain";
            this.MnuMain.Size = new System.Drawing.Size(1016, 29);
            this.MnuMain.TabIndex = 6;
            this.MnuMain.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHome,
            this.MnuCloseAllWindows,
            this.MnuLock,
            this.MnuAppSetting,
            this.toolStripMenuItem2,
            this.MnuExit});
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(64, 25);
            this.homeToolStripMenuItem.Text = "Home";
            // 
            // mnuHome
            // 
            this.mnuHome.Image = ((System.Drawing.Image)(resources.GetObject("mnuHome.Image")));
            this.mnuHome.Name = "mnuHome";
            this.mnuHome.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.G)));
            this.mnuHome.Size = new System.Drawing.Size(295, 26);
            this.mnuHome.Text = "Home";
            this.mnuHome.Click += new System.EventHandler(this.mnuHome_Click);
            // 
            // MnuCloseAllWindows
            // 
            this.MnuCloseAllWindows.Name = "MnuCloseAllWindows";
            this.MnuCloseAllWindows.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.MnuCloseAllWindows.Size = new System.Drawing.Size(295, 26);
            this.MnuCloseAllWindows.Text = "Close all windows";
            this.MnuCloseAllWindows.Click += new System.EventHandler(this.MnuCloseAllWindows_Click);
            // 
            // MnuLock
            // 
            this.MnuLock.Image = ((System.Drawing.Image)(resources.GetObject("MnuLock.Image")));
            this.MnuLock.Name = "MnuLock";
            this.MnuLock.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.L)));
            this.MnuLock.Size = new System.Drawing.Size(295, 26);
            this.MnuLock.Text = "Lock system";
            this.MnuLock.Click += new System.EventHandler(this.MnuLock_Click);
            // 
            // MnuAppSetting
            // 
            this.MnuAppSetting.Name = "MnuAppSetting";
            this.MnuAppSetting.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.O)));
            this.MnuAppSetting.Size = new System.Drawing.Size(295, 26);
            this.MnuAppSetting.Text = "Application option";
            this.MnuAppSetting.Click += new System.EventHandler(this.applicationOptionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(292, 6);
            // 
            // MnuExit
            // 
            this.MnuExit.Image = ((System.Drawing.Image)(resources.GetObject("MnuExit.Image")));
            this.MnuExit.Name = "MnuExit";
            this.MnuExit.Size = new System.Drawing.Size(295, 26);
            this.MnuExit.Text = "Exit";
            this.MnuExit.Click += new System.EventHandler(this.MnuExit_Click);
            // 
            // CheckIdleTimer
            // 
            this.CheckIdleTimer.Interval = 9000;
            this.CheckIdleTimer.Tick += new System.EventHandler(this.CheckIdleTimer_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblToolUserName,
            this.txtToolUserName,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1,
            this.txtToolServerInfo,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel3,
            this.txtDatabaseName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 667);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1016, 26);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblToolUserName
            // 
            this.lblToolUserName.Name = "lblToolUserName";
            this.lblToolUserName.Size = new System.Drawing.Size(88, 21);
            this.lblToolUserName.Text = "User name:";
            // 
            // txtToolUserName
            // 
            this.txtToolUserName.Name = "txtToolUserName";
            this.txtToolUserName.Size = new System.Drawing.Size(159, 21);
            this.txtToolUserName.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(14, 21);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(89, 21);
            this.toolStripStatusLabel1.Text = "Server info:";
            // 
            // txtToolServerInfo
            // 
            this.txtToolServerInfo.Name = "txtToolServerInfo";
            this.txtToolServerInfo.Size = new System.Drawing.Size(159, 21);
            this.txtToolServerInfo.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(14, 21);
            this.toolStripStatusLabel4.Text = "|";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(120, 21);
            this.toolStripStatusLabel3.Text = "Database name:";
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(159, 21);
            this.txtDatabaseName.Text = "toolStripStatusLabel4";
            // 
            // xtraTabbedMdiManager
            // 
            this.xtraTabbedMdiManager.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.xtraTabbedMdiManager.MdiParent = this;
            // 
            // HPA_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Center;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(1016, 693);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MnuMain;
            this.Name = "HPA_Main";
            this.Text = "Time attendance - Vietinsoft";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HPA_Main_Load);
            this.MnuMain.ResumeLayout(false);
            this.MnuMain.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.MenuStrip MnuMain;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuHome;
        private System.Windows.Forms.ToolStripMenuItem MnuLock;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem MnuExit;
        private System.Windows.Forms.ToolStripMenuItem MnuCloseAllWindows;
        private System.Windows.Forms.ToolStripMenuItem MnuAppSetting;
        private System.Windows.Forms.Timer CheckIdleTimer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblToolUserName;
        private System.Windows.Forms.ToolStripStatusLabel txtToolUserName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel txtToolServerInfo;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel txtDatabaseName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;


    }
}