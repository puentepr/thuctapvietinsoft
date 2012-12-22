using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace HPA
{
    public partial class HPA_Main : Form
    {
        HPA.SQL.DataDaigramDataContext dt = new SQL.DataDaigramDataContext();
        public HPA_Main()
        {
            InitializeComponent();
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach (Form childForm in MdiChildren)
            //{
            //    childForm.Close();
            //}
            HPA.Setting.DynamicForm df = new Setting.DynamicForm();
            df.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            Application.Exit();
        }

        private void HPA_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void HPA_Main_Load(object sender, EventArgs e)
        {
            FormLogin lg = new FormLogin();
            lg.ShowDialog();
            if (HPA.Common.StaticVars.UserName != null)
            {
                toolStripStatusLabel.Text = string.Format("Login ID: {0}  |  Login Name: {1}  |", HPA.Common.StaticVars.LoginID, HPA.Common.StaticVars.UserName);
                ToolStripStatusLabel svrInfo = new ToolStripStatusLabel(string.Format("Server: {0}   |   Database: {1}", HPA.Common.StaticVars.ServerName, HPA.Common.StaticVars.DatabaseName));
                statusStrip.Items.Add(svrInfo);
                //statusStrip
                LoadMenu();

            }
            else
            {
                Application.Exit();
            }
        }
        private void LoadMenu()
        {
            //Lay danh sach menu gốc
            var i = from m in dt.MEN_Menus
                    join msg in dt.tblMD_Messages on m.MenuID equals msg.MessageID
                    where msg.Language == "VN" && m.ParentMenuID == "Mnu"
                    orderby m.Priority ascending
                    select new
                    {
                        m.MenuID,
                        m.ParentMenuID,
                        m.AssemblyName,
                        m.IsModal,
                        m.IsCollapsed,
                        m.ShortcutKeys,
                        m.IsVisible,
                        m.SupperAdmin,
                        msg.Content
                    };
            //Load danh sach menu gốc
            foreach (var goc in i)
            {
                ToolStripMenuItem mnuParent = new ToolStripMenuItem(goc.Content.ToString());
                mnuParent.Name = goc.MenuID;
                menuStrip.Items.Add(mnuParent);
                LoadSubmenu(ref mnuParent, mnuParent.Name);
            }
        }
        private void LoadSubmenu(ref ToolStripMenuItem mnuParent, string s)
        {
            string id = mnuParent.Name;
            string ten = s;
            var k1 = from p in dt.tblSC_Objects
                     join q in dt.tblSC_Rights on p.ObjectID equals q.ObjectID
                     where q.LoginID == HPA.Common.StaticVars.LoginID && q.FullAccess!=0 && q.FullAccess!=null
                     select new
                     {
                         p.ObjectName,
                         q.FullAccess,
                     };
            var k2 = from t in dt.MEN_Menus
                     join u in dt.tblMD_Messages on t.MenuID equals u.MessageID
                     where u.Language == HPA.Common.StaticVars.LanguageID && t.IsVisible == true && t.ParentMenuID == s
                     orderby t.Priority ascending
                     select new
                     {
                         t.IsCollapsed,
                         t.IsModal,
                         t.ShortcutKeys,
                         t.SupperAdmin,
                         t.ClassName,
                         t.AssemblyName,
                         t.MenuID,
                         u.Content,
                         t.ParentMenuID,
                         mnName = t.AssemblyName + "." + t.ClassName
                     };
            var i = from p in k2
                    join q in k1 on p.mnName equals q.ObjectName into temp
                    from u in temp.DefaultIfEmpty()
                    select new
                    {
                        Name = u == null ? "null" : u.ObjectName,
                        p.MenuID,
                        p.IsCollapsed,
                        p.IsModal,
                        p.ShortcutKeys,
                        p.SupperAdmin,
                        p.ClassName,
                        p.AssemblyName,
                        p.Content,
                        quyen = u == null ? 0 : u.FullAccess,
                        p.mnName
                    };
            if (i.Count() > 0)
            {
                foreach (var k in i)
                {
                    if (k.mnName!=null)
                    {
                        if (k.quyen != 0)
                        {
                            ToolStripMenuItem mnuSubItem = new ToolStripMenuItem();
                            mnuSubItem.Name = k.MenuID;
                            mnuSubItem.Text = k.Content;
                            mnuSubItem.AccessibleName = k.AssemblyName;
                            mnuSubItem.Tag = k.ClassName;
                            if (k.IsModal != null)
                            {
                                mnuSubItem.AutoToolTip = bool.Parse(k.IsModal.ToString());
                            }
                            if (k.ShortcutKeys != null)
                            {
                                string[] sk = k.ShortcutKeys.ToString().Split(new char[] { '|' });
                                switch (sk.Length)
                                {
                                    case 2:
                                        mnuSubItem.ShortcutKeys = ((System.Windows.Forms.Keys)(Convert.ToInt32(sk[0]) | Convert.ToInt32(sk[1])));
                                        break;
                                    case 3:
                                        mnuSubItem.ShortcutKeys = ((System.Windows.Forms.Keys)(Convert.ToInt32(sk[0]) | Convert.ToInt32(sk[1]) | Convert.ToInt32(sk[2])));
                                        break;
                                    case 4:
                                        mnuSubItem.ShortcutKeys = ((System.Windows.Forms.Keys)(Convert.ToInt32(sk[0]) | Convert.ToInt32(sk[1]) | Convert.ToInt32(sk[2]) | Convert.ToInt32(sk[3])));
                                        break;

                                }
                            }
                            mnuSubItem.Click += new EventHandler(SubMenuClick);
                            setImage(mnuSubItem);
                            mnuParent.DropDownItems.Add(mnuSubItem);
                            LoadSubmenu(ref mnuSubItem, mnuSubItem.Name);
                            if (k.Content.Contains("-------------------"))
                            {
                                //Create new seprator menu
                                ToolStripSeparator SubItem = new ToolStripSeparator();
                                SubItem.Name = k.MenuID;
                                mnuParent.DropDownItems.Add(mnuSubItem);
                            }
                        }
                    }
                    else if (k.mnName == null)
                    {
                        ToolStripMenuItem mnuSubItem = new ToolStripMenuItem();
                        mnuSubItem.Name = k.MenuID;
                        mnuSubItem.Text = k.Content;
                        mnuSubItem.AccessibleName = k.AssemblyName;
                        mnuSubItem.Tag = k.ClassName;
                        if (k.IsModal != null)
                        {
                            mnuSubItem.AutoToolTip = bool.Parse(k.IsModal.ToString());
                        }
                        if (k.ShortcutKeys != null)
                        {
                            string[] sk = k.ShortcutKeys.ToString().Split(new char[] { '|' });
                            switch (sk.Length)
                            {
                                case 2:
                                    mnuSubItem.ShortcutKeys = ((System.Windows.Forms.Keys)(Convert.ToInt32(sk[0]) | Convert.ToInt32(sk[1])));
                                    break;
                                case 3:
                                    mnuSubItem.ShortcutKeys = ((System.Windows.Forms.Keys)(Convert.ToInt32(sk[0]) | Convert.ToInt32(sk[1]) | Convert.ToInt32(sk[2])));
                                    break;
                                case 4:
                                    mnuSubItem.ShortcutKeys = ((System.Windows.Forms.Keys)(Convert.ToInt32(sk[0]) | Convert.ToInt32(sk[1]) | Convert.ToInt32(sk[2]) | Convert.ToInt32(sk[3])));
                                    break;

                            }
                        }
                        mnuSubItem.Click += new EventHandler(SubMenuClick);
                        setImage(mnuSubItem);
                        mnuParent.DropDownItems.Add(mnuSubItem);
                        LoadSubmenu(ref mnuSubItem, mnuSubItem.Name);
                    }
                }
            }
            else
            {
                ToolStripMenuItem mnuSubItem = new ToolStripMenuItem();
                mnuSubItem.Name = id;
                mnuSubItem.Text = ten;
            }
        }
        //Thuc thi chuong trinh
        private void OpenExeProgram(string strClass, bool isModal)
        {
            string path = Application.StartupPath + @"\" + strClass;
            Process p = new Process();
            p.StartInfo.FileName = path;
            p.StartInfo.CreateNoWindow = isModal;
            p.Start();
        }
        public void OpenForm(string AssemblyName, string ClassName)
        {
            System.Runtime.Remoting.ObjectHandle handle = System.Activator.CreateInstance(AssemblyName, AssemblyName + "." + ClassName);
            System.Windows.Forms.Form frm = (System.Windows.Forms.Form)(handle.Unwrap());
            frm.Show();
        }
        void SubMenuClick(object sender, EventArgs e)
        {
            ToolStripMenuItem sub = (ToolStripMenuItem)sender;
            string Assembly = sub.AccessibleName;
            string Class = sub.Tag.ToString();
            bool IsModal = sub.AutoToolTip;
            if (sub.AccessibleName == "Excute")
            {
                OpenExeProgram(Class, IsModal);
            }
            else if (sub.AccessibleName == "Data")
            {

                //Assembly = "ThucTap";
                //OpenForm(Assembly, Class);
            }
            else
            {
                OpenForm(Assembly, Class);
            }
        }

        private void form3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HPA.Setting.FormCautrucCongty fct = new Setting.FormCautrucCongty();
            fct.Show();
        }
        private void setImage(ToolStripMenuItem tskItm)
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
                    tskItm.Image = global::HPA.Properties.Resources.insIcon;
                    break;
                case "mnuhep":
                    tskItm.Image = global::HPA.Properties.Resources.help_icon;
                    break;
                default:
                    tskItm.Image = global::HPA.Properties.Resources.user;
                    break;
            }
        }
    }
}
