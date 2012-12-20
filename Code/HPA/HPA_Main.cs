using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (HPA.Common.StaticVars.UserName!=null)
            {
                toolStripStatusLabel.Text= string.Format("Login ID: {0}  |  Login Name: {1}  |",HPA.Common.StaticVars.LoginID, HPA.Common.StaticVars.UserName);
                ToolStripStatusLabel svrInfo = new ToolStripStatusLabel(string.Format("Server: {0}   |   Database: {1}", HPA.Common.StaticVars.ServerName,HPA.Common.StaticVars.DatabaseName));
                statusStrip.Items.Add(svrInfo);
                //statusStrip
                //LoadMenu();
      
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
                    where msg.Language == HPA.Common.StaticVars.LanguageID && m.ParentMenuID == "Mnu"
                    orderby m.Priority ascending
                    select new
                    {
                        m.MenuID,
                        msg.Content
                    };
            //Load danh sach menu gốc
            menuStrip.Items.Clear();
            foreach (var goc in i)
            {
                ToolStripMenuItem mnuParent = new ToolStripMenuItem(goc.Content.ToString());
                mnuParent.Name = goc.MenuID;
                menuStrip.Items.Add(mnuParent);
                LoadSubmenu(ref mnuParent,mnuParent.Name);
            }
        }
        private void LoadSubmenu(ref ToolStripMenuItem mnuParent, string s)
        {
            var i = from p in dt.tblSC_Objects
                    join q in dt.tblSC_Rights on p.ObjectID equals q.ObjectID
                    join m in dt.MEN_Menus on p.ObjectName equals m.AssemblyName + "." + m.ClassName
                    join msg in dt.tblMD_Messages on m.MenuID equals msg.MessageID
                    where q.LoginID == HPA.Common.StaticVars.LoginID && msg.Language == HPA.Common.StaticVars.LanguageID && m.ParentMenuID == s
                    orderby m.Priority ascending
                    select new
                    {
                        p.ObjectName,
                        q.FullAccess,
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
            if (i.Count() > 1)
            {
                foreach (var k in i)
                {
                    ToolStripMenuItem mnuSubItem = new ToolStripMenuItem();
                    mnuSubItem.Name = k.MenuID;
                    mnuSubItem.Text = k.Content;
                    //setImage(mnuSubItem);
                    mnuParent.DropDownItems.Add(mnuSubItem);
                    LoadSubmenu(ref mnuParent, mnuParent.Name);
                    if (k.Content.Contains("-------------------"))
                    {
                        //Create new seprator menu
                        ToolStripSeparator SubItem = new ToolStripSeparator();
                        SubItem.Name = k.MenuID;
                        mnuParent.DropDownItems.Add(mnuSubItem);
                    }
                }
            }
            else
            {
                ToolStripMenuItem mnuSubItem = new ToolStripMenuItem();
                mnuSubItem.Name = i.ElementAt(0).MenuID;
                mnuSubItem.Text = i.ElementAt(0).Content; 
            }
        }

        private void form3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HPA.Setting.FormCautrucCongty fct = new Setting.FormCautrucCongty();
            fct.Show();
        }
    }
}
