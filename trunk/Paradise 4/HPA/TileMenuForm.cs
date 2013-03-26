using DevExpress.XtraEditors;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HPA.Common;
using System.Reflection;
using System.Diagnostics;
using HPA.SQL;
using HPA.MAINFRAME;


namespace TileMenuApplication
{
    public partial class TileMenuForm : DevExpress.XtraEditors.XtraForm
    {
        int interval = 9000;

        DataTable tblMenu;
        List<TileGroup> lstGroup= new List<TileGroup>();
        public TileMenuForm()
        {
            GlobalMouseHandler gmh = new GlobalMouseHandler();
            gmh.TheMouseMoved += new MouseMovedEvent(gmh_TheMouseMoved);
            Application.AddMessageFilter(gmh);
            InitializeComponent();
            ReadSettingValue();
            panelTop.BackColor = Color.FromArgb(100,88,44,55);
            tilLock_ItemClick(null, null);
            
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
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.LogError(ex, "ReadSettingValue", this.Text);
            }
        }
        void gmh_TheMouseMoved()
        {
            Point cur_pos = System.Windows.Forms.Cursor.Position;
            int y = cur_pos.Y - this.Top;
            if (y < 35) panelTop.Visible = true;
            if (y > 35 + panelTop.Height) panelTop.Visible = false;
            
        }
        
        void LoadMenu()
        {
            
            tblMenu = UIMessage.DBEngine.execReturnDataTable("sp_Menu_Load",
                    "@LanguageID", UIMessage.languageID, CommonConst.A_LoginID, UIMessage.userID);
            foreach (DataRow item in tblMenu.Select("ParentMenuID = 'Mnu'"))
            {
                TileGroup t = new TileGroup { Name = item["MenuID"].ToString(), Text = item["Name"].ToString() };
                DataRow[] rows = tblMenu.Select("ParentMenuID = '" + t.Name + "'");
                foreach (DataRow i in rows)
                {
                    if (i["ClassName"] == DBNull.Value || i["ClassName"].ToString().Equals("OK"))
                        continue;
                    TileItem ti = new TileItem { Name = i["MenuID"].ToString(), Text = i["Name"].ToString() };
                    ti.Tag = i;
                    ti.ItemClick += ti_ItemClick;
                    t.Items.Add(ti);
                }
                lstGroup.Add(t);
                tileControl1.Groups.Add(t);
            }
            

        }
        private void OpenExeProgram(string strClass, bool isModal)
        {
            string path = Application.StartupPath + @"\" + strClass;
            Process p = new Process();
            p.StartInfo.FileName = path;
            p.StartInfo.CreateNoWindow = isModal;
            p.Start();
        }



        private const string EXECUTE = "execute";
        protected static HPA.Common.Framework.CRunableObjectManager m_objManager = new HPA.Common.Framework.CRunableObjectManager();
        void ti_ItemClick(object sender, TileItemEventArgs e)
        {
            DataRow dt = e.Item.Tag as DataRow;

            string strAssembly = dt["AssemblyName"].ToString();
            string strClass = dt["ClassName"].ToString();
            if (strAssembly.Equals(EXECUTE))
            {
                //Open execute program
                OpenExeProgram(strClass, false);
                return;
            }
            
            object o;
            m_objManager.OpenObject(strAssembly, strClass, true, "abc", out o);
                

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Tab && e.KeyCode != Keys.ShiftKey && e.KeyCode != Keys.ControlKey)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    panelLeft.Visible = false;
                    tileControl1.Focus();
                    this.KeyPreview = true;
                }
                else
                {
                    panelLeft.Visible = true;
                    textSearch.EditValue = char.ConvertFromUtf32(e.KeyValue);
                    textSearch.Focus();
                    textSearch.Select(1, 0);
                    this.KeyPreview = false;
                }
            }
        }

        private void tileControl1_Click(object sender, EventArgs e)
        {
            panelLeft.Visible = false;
        }
        DataRow[] SearchMenu(string name)
        {

            return tblMenu.Select("Content like '%" + HPA.Common.Methods.RemoveToneMarks(name).ToLower() + "%' and (ClassName is not null or ClassName <> 'OK')");
        }
        private void textSearch_EditValueChanged(object sender, EventArgs e)
        {
            if (textSearch.Text == "")
            {
                tileControl1.Groups.Clear();
                foreach (var item in lstGroup)
                {
                    tileControl1.Groups.Add(item);
                    
                }
            }
            else
            {
                DataRow[] x = SearchMenu(textSearch.Text);
                RefreshMenu(x);

            }

        }
        void RefreshMenu(DataRow[] rows)
        {
            tileControl1.Groups.Clear();
            TileGroup g = new TileGroup();
            if (rows != null && rows.Count()!=0)
            {
                tileControl1.Groups.Add(g);
                foreach (DataRow i in rows)
                {
                    TileItem ti = new TileItem { Name = i["MenuID"].ToString(), Text = i["Name"].ToString() };
                   ti.ItemClick += ti_ItemClick;
                   ti.Tag = i;
                    g.Items.Add(ti);
                    
                }
                tileControl1.SelectedItem = g.Items[0];
                g.Items[0].AppearanceItem.Selected.BackColor = Color.Red;
                g.Items[0].AppearanceItem.Selected.BackColor2 = Color.Orange;
                g.Items[0].AppearanceItem.Selected.BorderColor = Color.White;
            }

          


        }


     
        private void textSearch_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter)
            {
                if (tileControl1.SelectedItem != null)
                {
                    TileItemEventArgs a = new TileItemEventArgs();
                    a.Item = tileControl1.SelectedItem;
                    ti_ItemClick(sender, a);
                }

            }
            else if(e.KeyCode== Keys.Down||e.KeyCode== Keys.Up||e.KeyCode== Keys.Left||e.KeyCode== Keys.Right)
            { 
                panelLeft.Visible = false;
                tileControl1.Focus();
            }
           else if (e.KeyCode == Keys.Escape)
           {
               panelLeft.Visible = false;
               tileControl1.Focus();
               this.KeyPreview = true;
           }
        }

        private void tileControl1_SelectedItemChanged(object sender, TileItemEventArgs e)
        {
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Y <= 10)
            {
                panelTop.Visible = true;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y <= 10)
            {
                panelTop.Visible = true;
            }
        }

       

        private void tilLock_ItemClick(object sender, TileItemEventArgs e)
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
            //Load main buttons
            LoadMenu();
        }
        private void CheckIdleTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Win32_API.Win32.GetIdleTime() > interval)
                {
                    CheckIdleTimer.Stop();
                    //Lock program
                    tilLock_ItemClick(null, null);

                }
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.LogError(ex, ex.Message, this.Text);
            }
        }
    }
    
    public delegate void MouseMovedEvent();

    public class GlobalMouseHandler : IMessageFilter
    {
        private const int WM_MOUSEMOVE = 0x0200;

        public event MouseMovedEvent TheMouseMoved;

        #region IMessageFilter Members

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_MOUSEMOVE)
            {
                if (TheMouseMoved != null)
                {
                    TheMouseMoved();
                }
            }
            // Always allow message to continue to the next filter control
            return false;
        }

        #endregion
    }
}
