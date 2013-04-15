using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDesigner
{
    public partial class Form1 : Form
    {
        bool vitridathaydoi = false;
        int rong = 120;//Chieu rong cua 1 CompanyControl
        int cao = 72;//Chieu cao cua 1 CompanyControl
        HPA.SQL.EzSql2 DBEngine = new HPA.SQL.EzSql2();
        //TestDataContext dt = new TestDataContext();
        Graphics g;
        Color cl1 = Color.Brown;//Mau binh thuong
        Color cl2 = Color.Blue;//Mau khi click
        Color cl3 = Color.Green;//Mau khi tim kiem
        Pen p;
        DataTable dstree;
        CompanyControl lbltemp;
        List<CompanyControl> dstemp= new List<CompanyControl>();//List luu danh sach cau truc cong ty dang CompanyControl
        List<CompanyControl> chacon = new List<CompanyControl>();//List luu danh sach chacon luc to mau khi click
        List<CompanyControl> dstimkiem = new List<CompanyControl>();//List luu danh sach cac CompanyControl khi tim kiem
        int caotong;//Luu gia tri do cao 1 level
        int khoangcach = 10;//Khoang cach giua cac CompanyControl cung 1 Level neu no khong co con
        int LevelMax;
        int[] a = new int[10];
        public Form1()
        {
            InitializeComponent();
            DBEngine.Server = Khoidau.Servername;
            DBEngine.User = Khoidau.User;
            DBEngine.Password = Khoidau.Password;
            DBEngine.Database = Khoidau.Dtname;
            DBEngine.open();
            //Set su kien Mousemove
            GlobalMouseHandler gmh = new GlobalMouseHandler();
            gmh.TheMouseMoved += new MouseMovedEvent(gmh_TheMouseMoved);
            Application.AddMessageFilter(gmh);
            //End set su kien Mousemove
        }
        int canhTrai = 0;
        void gmh_TheMouseMoved()
        {
            Point cur_pos = System.Windows.Forms.Cursor.Position;
            if (cur_pos.X <= canhTrai)//Neu la canh trai man hinh
            {
                panelControl1.Visible = true;
                canhTrai = panelControl1.Width;
            }
            else
            {
                panelControl1.Visible = false;
                canhTrai = 1;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            p = new Pen(Color.Black);//Mau cua duong ve ket noi
            p.Width = 2;//Do rong cua duong ve ket noi
            GetData();
            LoadData(1, 0);
            dstemp.Last().Focus();//Set focus ve vi tri cua cong ty
        }
        void GetData()
        {
            dstree = DBEngine.execReturnDataTable("LoadCompanyTree", "@LoginID", 3);
            dstemp.Clear();
            a = new int[10];
            caotong = panel1.Size.Height / ((from DataRow dr in dstree.Rows select Convert.ToInt32(dr["ControlLevel"])).Distinct().ToList()).Count();
            LevelMax = ((from DataRow dr in dstree.Rows select Convert.ToInt32(dr["ControlLevel"])).Distinct().ToList()).Last();
        }
        void LoadData(int ID, int Level)
        {
            //Name CompanyControl cha = Name+ID=tag CompanyControlcon
            //caotong*level ra vi tri y cua CompanyControl
            List<DataRow> dscon = (from DataRow dr in dstree.Rows where Convert.ToInt32(dr["ParentID"]) == ID && Convert.ToInt32(dr["ControlLevel"]) == Level + 1 select dr).ToList();
            //int Level = Convert.ToInt32(((from DataRow dr in dstree.Rows where Convert.ToInt32(dr["ID"]) == ID && Convert.ToInt32(dr["ControlLevel"]) == Level select dr).ToList())[0]["ControlLevel"]);
            if (dscon.Count == 0)
            {
                DataRow dr1= ((from DataRow dr in dstree.Rows where Convert.ToInt32(dr["ID"]) == ID && Convert.ToInt32(dr["ControlLevel"]) == Level select dr).ToList())[0];
                string tenhienthi = Convert.ToString(dr1["Name"]);
                string ten = tenhienthi+ID.ToString();
                string tagname = Convert.ToString(dr1["ParentName"]) + Convert.ToString(dr1["ParentID"]);
                string tablename = Convert.ToString(dr1["tablename"]);
                string codename = Convert.ToString(dr1["Code"]);
                int id = Convert.ToInt32(dr1["ID"]);
                int parentID = Convert.ToInt32(dr1["ParentID"]);
                CompanyControl lbltemp = CreateControl(ten, tagname, tenhienthi,tablename,codename,id,parentID);
                dstemp.Add(lbltemp);
                if (Level == LevelMax)//Neu la cap cao nhat 
                {
                    lbltemp.Location = new Point(a[Level], caotong * Level);
                    panel1.Controls.Add(lbltemp);
                    a[Level] += rong + khoangcach;
                }
                else
                {
                    lbltemp.Location = new Point(a[Level+1], caotong * Level);//vi tri x se bang vi tri cua CompanyControl cuoi cung cap sau no
                    panel1.Controls.Add(lbltemp);
                    a[Level+1] += rong + khoangcach;//Tang vi tri cuoi cung cap sau no
                }
            }
            else
            {
                foreach (DataRow dr in dscon)
                {
                    LoadData(Convert.ToInt32(dr["ID"]), Convert.ToInt32(dr["ControlLevel"]));
                }
                DataRow dr1 = ((from DataRow dr in dstree.Rows where Convert.ToInt32(dr["ID"]) == ID && Convert.ToInt32(dr["ControlLevel"]) == Level select dr).ToList())[0];
                string tenhienthi = Convert.ToString(dr1["Name"]);
                string ten = tenhienthi + ID.ToString();
                string tablename = Convert.ToString(dr1["tablename"]);
                string codename = Convert.ToString(dr1["Code"]);
                int id = Convert.ToInt32(dr1["ID"]);
                int parentID = Convert.ToInt32(dr1["ParentID"]);
                //Add CompanyControl 
                CompanyControl lbltemp;
                string targname;
                if (Level > 0)
                {
                    targname=Convert.ToString(dr1["ParentName"]) + Convert.ToString(dr1["ParentID"]);
                }
                else
                { targname = ""; }
                lbltemp = CreateControl(ten, targname, tenhienthi,tablename,codename,id,parentID);
                List<CompanyControl> lbltemp1 = (from p in dstemp where p.Tag.ToString() == lbltemp.Name.ToString() select p).ToList();
                if (lbltemp1.Count > 0)
                {
                    int x = (lbltemp1[0].Location.X + lbltemp1.Last().Location.X) / 2;
                    lbltemp.Location = new Point(x, caotong * Level);
                    //if (lbltemp1.Count % 2 == 0)
                    //{
                    //    lbltemp.Location = new Point(lbltemp1[(lbltemp1.Count / 2 - 1)].Location.X + rong / 2, caotong * Level);
                    //}
                    //else
                    //{
                    //    lbltemp.Location = new Point(lbltemp1[(lbltemp1.Count / 2)].Location.X, caotong * Level);
                    //}
                }
                panel1.Controls.Add(lbltemp);
                dstemp.Add(lbltemp);//Add CompanyControl vao list
                a[Level] = lbltemp.Location.X+rong+khoangcach;//Dua chieu ngang cua cap len 1 doan bang chieu rong 1 CompanyControl + khoang cach
            }

        }

        CompanyControl CreateControl(string ten,string tagname,string tenhienthi, string tablename,string codename,int id, int parentID)
        {
            //Add CompanyControl 
            CompanyControl lbltemp = new CompanyControl();
            lbltemp.Name = ten;
            lbltemp.Tag = tagname;
            lbltemp.Size = new Size(rong, cao);
            lbltemp.BackColor = cl1;
            lbltemp.Text = tenhienthi;
            lbltemp.tentable = tablename;
            lbltemp.txtcode = codename;
            lbltemp.txtname = tenhienthi;
            lbltemp.ID = id;
            lbltemp.ParentID = parentID;
            lbltemp.txtCode.GotFocus += lbltemp_Click;
            lbltemp.txtName.GotFocus += lbltemp_Click;
            lbltemp.EnabledChanged += lbltemp_EnabledChanged;
            lbltemp.MouseUp += lbltemp_MouseUp;
            lbltemp.LocationChanged+=lbltemp_LocationChanged;
            ControlMover.Init(lbltemp,ControlMover.Direction.Horizontal);
            return lbltemp;
        }

        void lbltemp_MouseUp(object sender, MouseEventArgs e)
        {
            panel1.Refresh();
            if (vitridathaydoi == true)
            {
                
                vitridathaydoi = false;
            }
        }

        void lbltemp_LocationChanged(object sender, EventArgs e)
        {
            vitridathaydoi = true;
        }

        void lbltemp_EnabledChanged(object sender, EventArgs e)
        {
            //Load lai tree
            panel1.Controls.Clear();
            GetData();
            LoadData(1, 0);
            dstemp.Last().Focus();//Set focus ve vi tri cua cong ty
        }

        void lbltemp_Click(object sender, EventArgs e)
        {
            if (lbltemp != null)//Tra lai mau cac Control click lan truoc
            {
                lbltemp.BackColor = cl1;
                foreach (CompanyControl con in chacon)
                {
                    con.BackColor = cl1;
                }
            }
            chacon.Clear();
            CompanyControl cha = (CompanyControl)((Control)sender).Parent;
            cha.BringToFront();
            cha.BackColor=cl2;
            timchacon(cha);
            foreach (CompanyControl con in chacon)//To mau cac Control  Click lan nay
            {
                 con.BackColor = cl2;
            }
            lbltemp = cha;//Gan lai gia tri cho CompanyControltemp
        }
        List<CompanyControl> timchacon(CompanyControl cha)
        {
            foreach (CompanyControl con in dstemp)
            {
                if (con.Tag.ToString() == cha.Name.ToString())
                {
                    chacon.Add(con);
                    timchacon(con);//Tim tiep cac con cua Control con
                }
            }
            return chacon;
        }
        void veketnoi()
        {
            int a=20;
            //g.DrawLine
            foreach (CompanyControl cha in dstemp)
            {
                //Toa do trung diem cua cha theo Ox
                Point tdchax=new Point();
                //Tim toa do x cua trung diem cha theo Ox = locationcha.X+widthcha/2;
                tdchax.X=cha.Location.X+(cha.Size.Width/2);
                //Tim toa do y cua trung diem cha theo Ox = locationcha.Y+heightcha;
                tdchax.Y=cha.Location.Y+cha.Size.Height;
                foreach (CompanyControl con in dstemp)
                {
                    if (con.Tag!=null&&con.Tag.ToString() == cha.Name.ToString())
                    {
                        //Toa do trung diem cua con theo Ox
                        Point tdcon = new Point();
                        //Tim toa do x cua trung diem con theo Ox = locationcon.X+widthcon/2;
                        tdcon.X = con.Location.X + (con.Size.Width / 2);
                        //Tim toa do y cua trung diem cha theo Ox = locationcon.Y;
                        tdcon.Y = con.Location.Y;
                        if (tdchax.X == tdcon.X)//neu 2 CompanyControl thang hang
                        {
                            g.DrawLine(p, tdchax, tdcon);
                        }
                        else
                        {
                            //Toa do diem trung gian
                            Point tg1 = new Point(tdchax.X, tdchax.Y+a);
                            Point tg2 = new Point(tdcon.X, tdchax.Y + a);
                            g.DrawLine(p, tdchax, tg1);
                            g.DrawLine(p, tg1, tg2);
                            g.DrawLine(p, tdcon, tg2);
                        }
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (dstemp != null)
            { veketnoi(); }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Xoa mau cac CompanyControl da tim kiem truoc do
                if (dstimkiem != null)
                {
                    foreach (CompanyControl con in dstimkiem)
                    {
                        con.BackColor = cl1;
                    }
                }
                dstimkiem.Clear();//Xoa danh sach tim kiem truoc do
                foreach (CompanyControl con in dstemp)//Tao danh sach tim kiem moi va to mau cho no
                {
                    if (con.Text.ToLower().Contains(txtSearch.Text.ToLower()))
                    {
                        con.BackColor = cl3;
                        dstimkiem.Add(con);
                    }
                }
                if (dstimkiem.Count > 0)
                { ((CompanyControl)dstimkiem[0]).Focus(); }
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
