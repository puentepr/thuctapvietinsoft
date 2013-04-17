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
        //CompanyControl temp =
        int caomotcap;//Luu gia tri do cao 1 level
        int khoangcach = 10;//Khoang cach giua cac CompanyControl cung 1 Level neu no khong co con
        int LevelMax;
        int caopanel;
        int[] a = new int[10];
        Point vitri;
        Point vitritam;
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
            ControlMover.Init(companyControl1);
            vitri = companyControl1.Location;
            //Set kich thuoc Form(Neu ko co 2 dong nay bieu do se mat net)
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height-50;
        }

        void companyControl1_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.Cursor = Cursors.NoMove2D;
            CompanyControl nv = (CompanyControl)sender;
            nv.BackColor = cl1;
            nv.txtCode.Text="Code";
            nv.txtName.Text = "Name";
            panel1.Controls.Add(nv);
            nv.BringToFront();
        }

        void companyControl1_MouseUp(object sender, MouseEventArgs e)
        {
            panel1.Cursor = Cursors.Default;
            CompanyControl nv = new CompanyControl();
            nv.Location = vitri;
            panelControl1.Controls.Add(nv);
            ControlMover.Init(nv);
            nv.MouseUp += companyControl1_MouseUp;
            nv.MouseDown += companyControl1_MouseDown;
            TimChaConMoi((CompanyControl)sender);
        }

        void TimChaConMoi(CompanyControl tempchacon)
        {
            if (tempchacon.Location.Y < caomotcap * LevelMax)
            {
                CompanyControl cha = new CompanyControl();
                CompanyControl cungcap = new CompanyControl();
                int kcchacony = 10000;
                int kchaconx = 10000;
                //Tim cha
                foreach (CompanyControl controlcu in dstemp)
                {
                    if (controlcu.Location.Y < tempchacon.Location.Y)
                    {
                        int khoangcachchacony = Math.Abs(controlcu.Location.Y - tempchacon.Location.Y);
                        int khoangcachchaconx = Math.Abs(controlcu.Location.X - tempchacon.Location.X);
                        if (khoangcachchacony <= kcchacony && khoangcachchaconx <= kchaconx)
                        {
                            cha = controlcu;
                            kcchacony = khoangcachchacony;
                            kchaconx = khoangcachchaconx;
                        }
                    }
                }
                //Tim cung cap
                foreach (CompanyControl controlcu in dstemp)
                {
                    if (controlcu.Tag.ToString() == cha.Name.ToString())
                    {
                        cungcap = controlcu;
                        break;
                    }
                }
                DialogResult r;
                r = MessageBox.Show(String.Format("'{0}' sẽ thuộc '{1}'.Bạn có muốn cập nhật?", tempchacon.txtName.Text, cha.txtName.Text), "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    string tentable = cungcap.tentable;
                    string matable = tentable.Substring(3);
                    string matablecha = cha.tentable.Substring(3);
                    if (matablecha != "Company")
                    { DBEngine.exec(String.Format("Insert into {0} ({1}ID,{2}Code,{3}Name) values({4},'{5}','{6}')", tentable, matablecha, matable, matable, cha.ID, tempchacon.txtCode.Text, tempchacon.txtName.Text)); }
                    else
                    { DBEngine.exec(String.Format("Insert into {0} ({1}Code,{2}Name) values('{3}','{4}')", tentable,matable, matable, tempchacon.txtCode.Text, tempchacon.txtName.Text)); }
                    LoadTree();
                }
                
            }
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
            LoadTree();
        }

        void GetData()
        {
            caopanel = Screen.PrimaryScreen.Bounds.Height - 80;//Caopanel = chieu cao cua man hinh-80
            dstree = DBEngine.execReturnDataTable("LoadCompanyTree", "@LoginID", 3);
            //Dem so cap cong ty
            int levelcount = ((from DataRow dr in dstree.Rows select Convert.ToInt32(dr["ControlLevel"])).Distinct().ToList()).Count();
            if (120 * levelcount > caopanel)//Neu do phan giai man hinh qua thap se lay chieu cao 1 cap bang 120
            {
                caomotcap = 120;
            }
            else//nguoc lai lay chieu cao mot cap bang caopanel/so cap
            {
                caomotcap = caopanel / levelcount;
            }
            LevelMax = ((from DataRow dr in dstree.Rows select Convert.ToInt32(dr["ControlLevel"])).Distinct().ToList()).Last();
        }
        void LoadData(int ID, int Level)
        {
            //Name CompanyControl cha = Name+ID=tag CompanyControlcon
            //caomotcap*level ra vi tri y cua CompanyControl
            List<DataRow> dscon = (from DataRow dr in dstree.Rows where Convert.ToInt32(dr["ParentID"]) == ID && Convert.ToInt32(dr["ControlLevel"]) == Level + 1 select dr).ToList();
            if (dscon.Count == 0)//Neu khong co con
            {
                DataRow dr1 = ((from DataRow dr in dstree.Rows where Convert.ToInt32(dr["ID"]) == ID && Convert.ToInt32(dr["ControlLevel"]) == Level select dr).ToList())[0];
                string tenhienthi = Convert.ToString(dr1["Name"]);
                string ten = tenhienthi + ID.ToString();
                string tagname = Convert.ToString(dr1["ParentName"]) + Convert.ToString(dr1["ParentID"]);
                string tablename = Convert.ToString(dr1["tablename"]);
                string codename = Convert.ToString(dr1["Code"]);
                int id = Convert.ToInt32(dr1["ID"]);
                int parentID = Convert.ToInt32(dr1["ParentID"]);
                CompanyControl lbltemp = CreateControl(ten, tagname, tenhienthi, tablename, codename, id, parentID);
                dstemp.Add(lbltemp);
                if (Level == LevelMax)//Neu la cap cao nhat 
                {
                    lbltemp.Location = new Point(a.Max(), caomotcap * Level);
                    panel1.Controls.Add(lbltemp);
                    a[Level] += rong + khoangcach;
                }
                else
                {
                    lbltemp.Location = new Point(a.Max(), caomotcap * Level);//vi tri x se bang vi tri cua CompanyControl cuoi cung cap sau no
                    panel1.Controls.Add(lbltemp);
                    a[Level] += rong + khoangcach;
                }
            }
            else//Neu co con
            {
                foreach (DataRow dr in dscon)
                {
                    LoadData(Convert.ToInt32(dr["ID"]), Convert.ToInt32(dr["ControlLevel"]));//Load danh sach con
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
                    targname = Convert.ToString(dr1["ParentName"]) + Convert.ToString(dr1["ParentID"]);
                }
                else
                { targname = ""; }
                lbltemp = CreateControl(ten, targname, tenhienthi, tablename, codename, id, parentID);
                List<CompanyControl> lbltemp1 = (from p in dstemp where p.Tag.ToString() == lbltemp.Name.ToString() select p).ToList();
                if (lbltemp1.Count > 0)
                {
                    int x = (lbltemp1[0].Location.X + lbltemp1.Last().Location.X) / 2;
                    lbltemp.Location = new Point(x, caomotcap * Level);
                }
                panel1.Controls.Add(lbltemp);
                dstemp.Add(lbltemp);//Add CompanyControl vao list
                if (lbltemp.Location.X <= lbltemp1.Last().Location.X)
                { a[Level] = lbltemp1.Last().Location.X + rong + khoangcach; }

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
            lbltemp.MouseDown += lbltemp_MouseDown;
            lbltemp.MouseMove += lbltemp_MouseMove;
            ControlMover.Init(lbltemp,ControlMover.Direction.Horizontal);
            return lbltemp;
        }

        void lbltemp_MouseMove(object sender, MouseEventArgs e)
        {
            CompanyControl tempchacon = (CompanyControl)sender;
            CompanyControl trai = new CompanyControl();
            CompanyControl phai = new CompanyControl();
            CompanyControl kq = new CompanyControl();
            //Tim cha gan nhat ben phai
            for (int i = tempchacon.Location.X + rong; i < tempchacon.Location.X + rong * 2; i++)//khoang cach tim kiem tinh theo ben phai
            {
                Control tk = panel1.GetChildAtPoint(new Point(i, tempchacon.Location.Y - caomotcap));
                if (tk is CompanyControl)
                {
                    phai = (CompanyControl)tk;
                    break;
                }
            }
            //Tim cha gan nhat ben trai
            for (int i = tempchacon.Location.X; i > tempchacon.Location.X - rong; i--)//Khoang cach tim kiem theo ben trai
            {
                Control tk = panel1.GetChildAtPoint(new Point(i, tempchacon.Location.Y - caomotcap));
                if (tk is CompanyControl)
                {
                    trai = (CompanyControl)tk;
                    break;
                }
            }
            //So sanh 2 cha xem cha nao gan hon
            if (Math.Abs(tempchacon.Location.X - trai.Location.X) < Math.Abs(tempchacon.Location.X - phai.Location.X))//Neu cha trai gan hon cha phai
            {
                kq = trai;
            }
            else
            {
                kq = phai;
            }
            if (kq.txtName.Text != "" && tempchacon.Tag.ToString() != kq.Name)
            {
                panel1.Cursor = Cursors.Cross;
            }
            else
            {
                panel1.Cursor = Cursors.NoMove2D;
            }
        }

        void lbltemp_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.Paint -= panel1_Paint;//Tam ngung su kien Paint
            
        }

        void lbltemp_MouseUp(object sender, MouseEventArgs e)
        {
            panel1.Cursor = Cursors.Default;   
            panel1.Paint += panel1_Paint;//Kich hoat lai su kien paint
            panel1.Refresh();
            CompanyControl tempchacon = (CompanyControl)sender;
            CompanyControl trai = new CompanyControl();
            CompanyControl phai = new CompanyControl();
            CompanyControl kq = new CompanyControl();
            //Tim cha gan nhat ben phai
            for (int i = tempchacon.Location.X+rong; i < tempchacon.Location.X + rong*2; i++)//khoang cach tim kiem tinh theo ben phai
            {
                Control tk = panel1.GetChildAtPoint(new Point(i, tempchacon.Location.Y - caomotcap));
                if (tk is CompanyControl)
                {
                    phai = (CompanyControl)tk;
                    break;
                }
            }
            //Tim cha gan nhat ben trai
            for (int i = tempchacon.Location.X; i > tempchacon.Location.X - rong; i--)//Khoang cach tim kiem theo ben trai
            {
                Control tk = panel1.GetChildAtPoint(new Point(i, tempchacon.Location.Y - caomotcap));
                if (tk is CompanyControl)
                {
                    trai = (CompanyControl)tk;
                    break;
                }
            }
            //So sanh 2 cha xem cha nao gan hon
            if (Math.Abs(tempchacon.Location.X-trai.Location.X) < Math.Abs(tempchacon.Location.X-phai.Location.X))//Neu cha trai gan hon cha phai
            {
                kq = trai;
            }
            else
            {
                kq = phai;
            }
            if (kq.txtName.Text!= ""&&tempchacon.Tag.ToString()!=kq.Name)
            {
                DialogResult r;
                r = MessageBox.Show(String.Format("'{0}' sẽ thuộc '{1}'.Bạn có muốn thay đổi?", tempchacon.txtName.Text, kq.txtName.Text), "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)//Neu dong y thi luu xuong CSDL
                {
                    string tentablecon = tempchacon.tentable;
                    string macha = kq.tentable.Substring(3);
                    string macon = tempchacon.tentable.Substring(3);
                    DBEngine.exec(String.Format("Update {0} set {1}ID ={2} where {3}ID= {4}", tentablecon, macha, kq.ID, macon, tempchacon.ID));
                    LoadTree();
                }
            
            }
            
        }

        void lbltemp_EnabledChanged(object sender, EventArgs e)
        {
            LoadTree();
        }

        void LoadTree()
        { 
            //Clear cac gia tri cua lan load truoc do
            panel1.Controls.Clear();
            dstemp.Clear();
            a = new int[10];
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
