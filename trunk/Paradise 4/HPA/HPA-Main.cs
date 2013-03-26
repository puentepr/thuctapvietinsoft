using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using HPA.MAINFRAME;
using HPA.SystemAdmin;
using System.Diagnostics;
using HPA.Common;
using HPA.SQL;


namespace HPA
{
    public partial class HPA_Main : DevExpress.XtraEditors.XtraForm//HPA.Component.Framework.CBaseForm
    {
        private const string EXECUTE = "execute";
        int interval = 9000;
        protected static HPA.Common.Framework.CRunableObjectManager m_objManager = new HPA.Common.Framework.CRunableObjectManager();

        public HPA_Main()
        {
            InitializeComponent();
            ReadSettingValue();
            xtraTabbedMdiManager.MdiParent = this;
        }

        private void ReadSettingValue()
        {

            try
            {
                //read option values
                UIMessage.languageID = HPA.Properties.Settings.Default.LanguageID;
                interval = HPA.Properties.Settings.Default.LockProgramInterval * 1000;
                m_objManager.Parent = this;
                m_objManager.DBEngine = UIMessage.DBEngine;
                //Load Application Message
                ApplicationMessage();
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.LogError(ex, "ReadSettingValue", this.Text);
            }
        }

        private void ApplicationMessage()
        {
            DataSet dsLang = new DataSet();
            dsLang.ReadXml(Application.StartupPath + @"\langMessage.xml");
            ShowLangMessage( dsLang.Tables[0],mnuHome, UIMessage.languageID);
            ShowLangMessage(dsLang.Tables[0],MnuLock,  UIMessage.languageID);
            ShowLangMessage( dsLang.Tables[0],MnuExit, UIMessage.languageID);
            ShowLangMessage(dsLang.Tables[0], MnuAppSetting, UIMessage.languageID);
            ShowLangMessage(dsLang.Tables[0], MnuCloseAllWindows, UIMessage.languageID);


            //nviHome.Caption = mnuHome.Text;
            //nvgHome.Caption = mnuHome.Text;
            //nviExit.Caption = MnuExit.Text;
            //nviLockSystem.Caption = MnuLock.Text;

            this.Text = UIMessage.Get_Message("ProgrammeName");
            homeToolStripMenuItem.Text = UIMessage.Get_Message("homeToolStripMenuItem");
        }
        void ShowLangMessage(DataTable dt, ToolStripMenuItem ctr, object langID)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                ctr.Text =dt.Select(string.Format("ID = '{0}' and LanguageID = '{1}'", ctr.Name, langID)).Length >0? dt.Select(string.Format("ID = '{0}' and LanguageID = '{1}'", ctr.Name, langID))[0]["MessageInfo"].ToString():"";
            }
        }
        

        private void LoadMenu()
        {
            DataTable dt;
            try {
                dt = m_objManager.DBEngine.execReturnDataTable("sp_Menu_Load",
                    "@LanguageID", UIMessage.languageID, CommonConst.A_LoginID, UIMessage.userID);
                BuildMenu(dt);
            }
            catch (Exception ex)
            {
                UIMessage.Alert("MENU_LOAD_ERROR");
                UIMessage.Alert(ex.Message);
            }
        }

        private void BuildMenu(DataTable dt)
        {
            const string MnuName = "Name";
            const string MnuID = "MenuID";
            const string strMainMenu = "Mnu";
            DataRow[] drMain = dt.Select(string.Format("ParentMenuID = '{0}'", strMainMenu));
            //Build Menu strip here
            MnuMain.Items.Clear();
            MnuMain.Items.Add(this.homeToolStripMenuItem);
            foreach (DataRow drMnu in drMain)
            {
                ToolStripMenuItem mnuParent = new ToolStripMenuItem(drMnu[MnuName].ToString()) { Name = drMnu[MnuID].ToString() };
                MnuMain.Items.Add(mnuParent);
                LoadSubMenuItem(dt, ref mnuParent);
            }
        }

        

        private void LoadSubMenuItem(DataTable dt, ref ToolStripMenuItem mnuParent)
        {
            const string MnuName = "Name";
            const string MnuID = "MenuID";
            const string strShrtKeys = "ShortcutKeys";
            string strSubMenu = mnuParent.Name;
            string[]shrtKeys;
            DataRow[] drSub = dt.Select(string.Format("ParentMenuID = '{0}'", strSubMenu));
            foreach (DataRow drSubMnu in drSub)
            {
                DataRow[] drCountChild = dt.Select(string.Format("ParentMenuID = '{0}'", drSubMnu[MnuID]));
                if (drCountChild.Length > 0)
                {
                    ToolStripMenuItem mnuSubItem = new ToolStripMenuItem() { Name = drSubMnu[MnuID].ToString(), Text = drSubMnu[MnuName].ToString() };
                    setImage(mnuSubItem);
                    mnuParent.DropDownItems.Add(mnuSubItem);
                    LoadSubMenuItem(dt, ref mnuSubItem);
                }
                else if (drSubMnu[MnuName].ToString().Contains("-------------------"))
                {
                    //Create new seprator menu
                    ToolStripSeparator mnuSubItem = new ToolStripSeparator() { Name = drSubMnu[MnuID].ToString() };
                    mnuParent.DropDownItems.Add(mnuSubItem);
                }
                else
                {
                    //Create new menu Item
                    ToolStripMenuItem mnuSubItem = new ToolStripMenuItem() { Name = drSubMnu[MnuID].ToString(), Text = drSubMnu[MnuName].ToString() };
                    //register shortcutKeys
                    if (drSubMnu[strShrtKeys] != DBNull.Value)
                    {
                        shrtKeys = drSubMnu[strShrtKeys].ToString().Split(new char[] { '|' });
                        switch (shrtKeys.Length)
                        {
                            case 2:
                                mnuSubItem.ShortcutKeys = ((System.Windows.Forms.Keys)(Convert.ToInt32(shrtKeys[0]) | Convert.ToInt32(shrtKeys[1])));
                                break;
                            case 3:
                                mnuSubItem.ShortcutKeys = ((System.Windows.Forms.Keys)(Convert.ToInt32(shrtKeys[0]) | Convert.ToInt32(shrtKeys[1]) | Convert.ToInt32(shrtKeys[2])));
                                break;
                            case 4:
                                mnuSubItem.ShortcutKeys = ((System.Windows.Forms.Keys)(Convert.ToInt32(shrtKeys[0]) | Convert.ToInt32(shrtKeys[1]) | Convert.ToInt32(shrtKeys[2]) | Convert.ToInt32(shrtKeys[3])));
                                break;
                        }
                    }
                    //Set Image
                    setImage(mnuSubItem);
                    //register click event
                    mnuSubItem.AccessibleName = drSubMnu["AssemblyName"].ToString();
                    if (drSubMnu["IsModal"] != DBNull.Value)
                        mnuSubItem.AutoToolTip = Convert.ToBoolean(drSubMnu["IsModal"].ToString());
                    else
                        mnuSubItem.AutoToolTip = false;
                    mnuSubItem.Tag = drSubMnu["ClassName"].ToString();
                    mnuSubItem.Click += new EventHandler(mnuSubItem_Click);

                    //Add to Menu
                    mnuParent.DropDownItems.Add(mnuSubItem);
                }
            }
        }

        void mnuSubItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Close Clock screen first
                foreach (Form frm in MdiChildren)
                    if (frm.Name == "clock")
                    {
                        frm.Close();
                        break;
                    }
                ToolStripMenuItem tsk = (ToolStripMenuItem)sender;

                string strAssembly = tsk.AccessibleName;
                string strClass = tsk.Tag.ToString();
                bool isModal = tsk.AutoToolTip;
                if (tsk.AccessibleName.ToLower().Equals(EXECUTE))
                {
                    //Open execute program
                    OpenExeProgram(strClass, isModal);
                    return;
                }
                foreach (Form frm in this.MdiChildren)
                {
                    if (frm.Text == tsk.Text)
                    {
                        frm.Select();
                        return;
                    }
                }
                object o;
                m_objManager.OpenObject(strAssembly, strClass, isModal, tsk.Text, out o);
                
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "mnuSubItem_Click");
            }
        }

        private void OpenExeProgram(string strClass, bool isModal)
        {
            string path = String.Format(@"{0}\{1}", Application.StartupPath, strClass);
            Process p = new Process();
            p.StartInfo.FileName = path;
            p.StartInfo.CreateNoWindow = isModal;
            p.Start();
        }

        
        private void setImage(ToolStripMenuItem  tskItm)
        {
            switch (tskItm.Name.Substring(0, 6).ToLower())
            {
                case "mnuhrs":
                    tskItm.Image = global::HPA.Properties.Resources.user;
                    break;
                case "mnutad":
                    tskItm.Image = global::HPA.Properties.Resources.icon_clock;
                    break;
                case "mnuprl":
                    tskItm.Image = global::HPA.Properties.Resources.money;
                    break;
                case "mnurpt":
                    tskItm.Image = global::HPA.Properties.Resources.report;
                    break;
                case "mnuscr":
                    tskItm.Image = global::HPA.Properties.Resources.security;
                    break;
                case "mnuext":
                    tskItm.Image = global::HPA.Properties.Resources.update16x16;
                    break;
                case "mnumdt":
                    tskItm.Image = global::HPA.Properties.Resources.masterdata;
                    break;
                case "mnusid":
                    tskItm.Image = global::HPA.Properties.Resources.insurance;
                    break;
                case "mnuhep":
                    tskItm.Image = global::HPA.Properties.Resources.help_icon;
                    break;
                default:
                    tskItm.Image = global::HPA.Properties.Resources.user;
                    break;
            }
        }

        private void LoadLanguage()
        {
            Control.ControlCollection ctrls = this.Controls;
            UIMessage.LoadLableName(ref ctrls);
        }

        

        

        private void HPA_Main_Load(object sender, EventArgs e)
        {
            
            LoadLanguage();
            this.BackgroundImage = System.Drawing.Image.FromFile(HPA.Properties.Settings.Default.WallpaperPath);
            UIMessage.WallpaperPath = HPA.Properties.Settings.Default.WallpaperPath;
            MnuLock_Click(null, null);
            CheckIdleTimer.Start();
        }


        private void mnuHome_Click(object sender, EventArgs e)
        {
            //Show login form
            object o;
            m_objManager.OpenObject("HPA.Component.MainFrame", "clock", false, null, out o);
        }

       
        public void ShowA()
        {
            object o;
            m_objManager.OpenObject("HPA.TimeAttendance", "MachineManagement", false, UIMessage.Get_Message("MnuTAD117"), out o);
        }
        public void ShowB()
        {
            object o;
            Login frm = new Login() { AssemblyName = "HPA.Component.MainFrame", ClassName = "Login" };
            m_objManager.OpenObject(frm, true, null, out o);
            if (frm.DialogResult != DialogResult.OK)
            {
                this.Dispose();
                this.Close();
                return;
            }
            else
            {
                CheckIdleTimer.Start();
            }
            m_objManager.UserID = frm.UserID;
            m_objManager.UserName = frm.UserName;
            //Set status

            txtToolUserName.Text = frm.UserName.ToString();
            txtToolServerInfo.Text = m_objManager.DBEngine.Server;
            txtDatabaseName.Text = m_objManager.DBEngine.Database;
            //Load main buttons
            LoadMenu();
            //...
            //Load menu strip
            //LoadMenuStrip();
        }
        

        private void MnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
     

        private void MnuLock_Click(object sender, EventArgs e)
        {
            object o;
            //m_objManager.OpenObject("HPA.TimeAttendance", "MachineManagement", false, UIMessage.Get_Message("MnuTAD117"), out o);
            Login frm = new Login() { AssemblyName = "HPA.Component.MainFrame", ClassName = "Login" };
            m_objManager.OpenObject(frm, true, null, out o);
            if (frm.DialogResult != DialogResult.OK)
            {
                this.Dispose();
                this.Close();
                return;
            }
            else
            {
                CheckIdleTimer.Start();
            }
            m_objManager.UserID = frm.UserID;
            m_objManager.UserName = frm.UserName;
            //Set status

            txtToolUserName.Text = frm.UserName.ToString();
            txtToolServerInfo.Text = m_objManager.DBEngine.Server;
            txtDatabaseName.Text = m_objManager.DBEngine.Database;
            //Load main buttons
            LoadMenu();
        }

        private void applicationOptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem option = (ToolStripMenuItem)sender;

            ApplicationOption frmOption = new ApplicationOption(option.Text);
            frmOption.ShowDialog();
        }



        private void CheckIdleTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                //if (Win32_API.Win32.GetIdleTime() > 9000)
                //{
                //    if (isShowAdv == false)
                //    {   
                //        this.isShowAdv = true;
                //        Object o;
                //        HPA.Update.Adv adv = new HPA.Update.Adv();
                //        adv.AssemblyName = "HPA.Update";
                //        adv.ClassName = "Adv";
                //        m_objManager.OpenObject(adv, true, null, out o);
                        
                      
                //    }
                //}
                if (Win32_API.Win32.GetIdleTime() > interval)
                {
                    CheckIdleTimer.Stop();
                    //Lock program
                    MnuLock_Click(null, null);

                }
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.LogError(ex, ex.Message, this.Text);
            }
        }

        private void MnuCloseAllWindows_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
        }

    }
}