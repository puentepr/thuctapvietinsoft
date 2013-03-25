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


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        EzSqlCollection.EzSql2 con = new EzSqlCollection.EzSql2(@"ANHTUAN\SQLEXPRESS", "TestP4", "saFree", "LuaThiengFree");
        DataTable tblMenu;
        List<TileGroup> lstGroup= new List<TileGroup>();
        public Form1()
        {
            GlobalMouseHandler gmh = new GlobalMouseHandler();
            gmh.TheMouseMoved += new MouseMovedEvent(gmh_TheMouseMoved);
            Application.AddMessageFilter(gmh);
            InitializeComponent();
            panelTop.BackColor = Color.FromArgb(100,88,44,55);
            LoadMenu();
            tileControl1.ItemClick += ti_ItemClick;
            
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
            con.open();

            DataTable pram = con.execReturnDataTable("SELECT m.MenuID,t.Content FROM MEN_Menu m left join tblMD_Message t on t.MessageID= m.MenuID  WHERE m.IsVisible= 'True' and ParentMenuID='Mnu' and t.Language='VN' order by m.Priority");
            tblMenu = con.execReturnDataTable("SELECT m.MenuID,t.Content as Text, LOWER(dbo.fn_RemoveToneMark(t.Content)) as Content, m.ParentMenuID FROM MEN_Menu m left join tblMD_Message t on t.MessageID= m.MenuID WHERE m.IsVisible= 'True'  and t.Language='VN'");
            con.close();
            foreach (DataRow item in pram.Rows)
            {
                TileGroup t = new TileGroup { Name = item["MenuID"].ToString(), Text = item["Content"].ToString() };
                DataRow[] rows = tblMenu.Select("ParentMenuID = '" + t.Name + "'");
                foreach (DataRow i in rows)
                {
                    TileItem ti = new TileItem { Name = i["MenuID"].ToString(), Text = i["Text"].ToString() };
                   // ti.ItemClick += ti_ItemClick;
                    t.Items.Add(ti);


                }
                lstGroup.Add(t);
                tileControl1.Groups.Add(t);
            }
            

        }
        void ti_ItemClick(object sender, TileItemEventArgs e)
        {
            MessageBox.Show(e.Item.Text);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    panelLeft.Visible = false;
                    tileControl1.Focus();

                }
                else
                {
                    panelLeft.Visible = true;
                    textSearch.Focus();
                }
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void tileControl1_Click(object sender, EventArgs e)
        {
            panelLeft.Visible = false;
        }
        DataRow[] SearchMenu(string name)
        {
            return tblMenu.Select("Content like '%"+Mothods.RemoveToneMarks(name).ToLower()+"%'");
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
                    TileItem ti = new TileItem { Name = i["MenuID"].ToString(), Text = i["Text"].ToString() };
                   // ti.ItemClick += ti_ItemClick;
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

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
           
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
