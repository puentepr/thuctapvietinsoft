using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Paradise5.ServiceReference1;
using DevExpress.Xpf.LayoutControl;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Reflection;
using System.Windows.Browser;
using System.Windows.Controls.Primitives;

namespace Paradise5
{
    public partial class MainPage : UserControl
    {
        int xacnhan=0;
        List<string> cha = new List<string>();
        public static int LoginID=-1;
        List<ViewMenu> view;
        Service1Client ws = new Service1Client();
        TimeSpan ts = new TimeSpan(0, 0, 5);
        public MainPage()
        {
            InitializeComponent();
            GridStack.Visibility = Visibility.Collapsed;
            LoadInfo();

        }
        void LoadInfo()
        {
            TLYC.Children.Clear();
            TLYC.Padding = new Thickness(0, 0, 0, 0);
            Home hm = new Home();
            TLYC.Children.Add(hm);
            
        }
        #region Login
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (xacnhan == 0)
            { xacnhan = 1; }
            if (txtName.Text == "")
            {
                txtName.SetValidation("Tên đăng nhập không được để trống");
                txtName.Focus();//neu bo dong nay thi khi focus vao textbox moi hien thi validation
                txtName.RaiseValidationError();
            }
            else
            {
                txtName.ClearValidationError();
                ws.CheckloginCompleted -= ws_CheckloginCompleted;
                ws.CheckloginCompleted += ws_CheckloginCompleted;
                ws.CheckloginAsync(txtName.Text, txtPass.Password);
            }
            
        }
        void ws_CheckloginCompleted(object sender, CheckloginCompletedEventArgs e)
        {
            int loginid = e.Result;
            if (loginid == -2 || loginid == -1)
            {
                txtName.SetValidation("Tên đăng nhập hoặc mật khẩu không đúng");
                txtName.Focus();
                txtName.RaiseValidationError();
            }
            else if (loginid == -3)
            {
                txtName.SetValidation("Mật khẩu của bạn đã lâu không thay đổi. Vui lòng đổi mật khẩu");
                txtName.Focus();
                txtName.RaiseValidationError();
            }
            else
            {
                txtName.ClearValidationError();
                LoginID = loginid;
                HPL1.Content = "Chào mừng " + txtName.Text;
                txtName.Visibility = Visibility.Collapsed;
                txtPass.Visibility = Visibility.Collapsed;
                btnLogin.Visibility = Visibility.Collapsed;
                HPL1.Visibility = Visibility.Visible;
                HpLogout.Visibility = Visibility.Visible;
                ws.SetSessionCompleted += ws_SetSessionCompleted;
                ws.SetSessionAsync(txtName.Text, loginid);
                //Cookie cookie = new Cookie ("UserName", txtName.Text);
                //cookie.Expires = DateTime.Now.AddYears(1);
            }
        }

        void ws_SetSessionCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {

            ws.ViewMNCompleted += ws_ViewMNCompleted;
            ws.ViewMNAsync("VN");
        }
        void ws_ViewMNCompleted(object sender, ViewMNCompletedEventArgs e)
        {
            view = e.Result.ToList();
            PageSmoothScroller.delaytime.Stop();
            LoadMenu("Mnu");
            
        }
        #endregion

        #region LoadMenu
        private void LoadMenu(string ParentName)
        {
            int count=0;
            TLYC.HorizontalAlignment = HorizontalAlignment.Center;
            if (ParentName == "Mnu")
            {
                TLYC.Children.Clear();
                var q = from p in view where p.ParentMenuID == "Mnu" select p;
                count = q.Count();
                foreach (var i in q)
                {
                    CreatTile(i.MenuID, i.Name,"",q.Count());
                }
            }
            else
            {
                var q = from p in view where p.ParentMenuID == ParentName && p.LoginID == LoginID && p.ClassName != "OK" select p;
                if (q.Count() > 0)
                {
                    count = q.Count();
                    TLYC.Children.Clear();
                    foreach (var i in q)
                    {
                        if (i.SupperAdmin == true && LoginID == 3)
                        { CreatTile(i.MenuID, i.Name, i.AssemblyName + "." + i.ClassName, q.Count()); }
                        else if (i.SupperAdmin == false || i.SupperAdmin == null)
                        {
                            CreatTile(i.MenuID, i.Name, i.AssemblyName + "." + i.ClassName, q.Count());
                        }
                    }
                }
                else
                {
                    var t = view.Single(u => u.MenuID == ParentName && u.LoginID == LoginID && u.ClassName != "OK");
                    this.CreateChildPage(t.AssemblyName,t.ClassName);
                    cha.RemoveAt(cha.Count - 1);
                }
            }
            //Start Set so luong hien thi cac Tile cho phu hop
            if (count < 10&&count!=0)
            {
                TLYC.Padding = new Thickness(200, 80, 110, 10);
            }
            else
            { TLYC.Padding = new Thickness(50, 0, 20, 10); }
            TLYCScroll.Focus();//Neu bo dong nay thi phai focus vao Tile Layout Control moi Scroll bang ban phim duoc
        }
        private void CreatTile(string MenuID, string MenuName, string Pagename,int dem)
        {
            Tile til = new Tile();
            til.Header = MenuName;
            til.AnimateContentChange = true;
            var k = from p in view where p.ParentMenuID == MenuID && p.LoginID == LoginID && p.ClassName != "OK" select p.Name;
            til.ContentSource = k.ToList();
            til.ContentChangeInterval = ts;
            til.Name = MenuID;
            til.Tag = Pagename;
            //TLYC.Width = ((double)HtmlPage.Window.Eval("screen.availWidth"));
            //TLYC.Height = ((double)HtmlPage.Window.Eval("screen.availHeight"))-100;
            //til.Width=((double)HtmlPage.Window.Eval("screen.availWidth"))/dem;
            //til.Height = (((double)HtmlPage.Window.Eval("screen.availHeight")) - 100) / dem;
            ////Set image
            //Image img = new Image();
            //BitmapImage bmp = new BitmapImage(new Uri("Image/Back.png", UriKind.Relative));
            //img.Stretch = 0;
            //img.Source = bmp;
            ////End set image
            //til.Content = img;
            TLYC.Children.Add(til);
        }
        private void CreateChildPage(string asb, string cls)
        {
            if (cls != "CreatAnnouncement")//Nếu khác form tạo thông báo
            {
                var WbClnt = new WebClient();//Tao WebClient
                WbClnt.OpenReadCompleted += (a, b) =>
                {
                    if (b.Error == null)
                    {
                        AssemblyPart assmbpart = new AssemblyPart();
                        Assembly assembly = assmbpart.Load(b.Result);
                        Object Obj = assembly.CreateInstance(asb + "." + cls);//Truy xuat file dll
                        if (Obj != null)//Neu co file dll thi tao ChildWindow
                        {
                            ChildWindow child = (ChildWindow)assembly.CreateInstance(asb + "." + cls);
                            child.Width = (double)HtmlPage.Window.Eval("screen.availWidth") - 100;
                            child.Height = (double)HtmlPage.Window.Eval("screen.availHeight") - 100;
                            child.Show();
                        }
                        else { MessageBox.Show("Page not exist"); }//Khong ton tai page thi bao loi
                    }
                    else { MessageBox.Show("Page not exist"); }//Khong ton tai file dll thi bao loi
                };
                WbClnt.OpenReadAsync(new Uri("http://localhost:10511/Control/" + asb + ".dll", UriKind.Absolute));
            }
            else if (cls == "CreatAnnouncement")
            {
                CreatAnnouncement tb = new CreatAnnouncement();
                tb.Width = (double)HtmlPage.Window.Eval("screen.availWidth") - 100;
                tb.Height = (double)HtmlPage.Window.Eval("screen.availHeight")-100;
                TLYC.Children.Clear();
                TLYC.Children.Add(tb);
            }
       }
        #endregion
        private void TLYC_TileClick(object sender, TileClickEventArgs e)
        {
            cha.Add(e.Tile.Name);
            LoadMenu(e.Tile.Name);
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            GBack();
        }
        private void Home_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                GBack();
            }
        }
        #region GOBACK
        private void GBack()
        {
            if (cha.Count > 0)
            {
                LoadMenu(cha.ElementAt(cha.Count - 1));
                cha.RemoveAt(cha.Count - 1);
            }
            else
            {
                if (LoginID != -1)
                { LoadMenu("Mnu"); }
                else { }
            }
        }
        #endregion
        #region Logout
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginID = -1;
            ws.RemoveSessionCompleted += ws_RemoveSessionCompleted;
            ws.RemoveSessionAsync();
        }

        void ws_RemoveSessionCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            //this.Content = new Test();
            txtName.Visibility = Visibility.Visible;
            txtPass.Password = "Viettinsoft";
            txtPass.Visibility = Visibility.Visible;
            btnLogin.Visibility = Visibility.Visible;
            HPL1.Visibility = Visibility.Collapsed;
            HpLogout.Visibility = Visibility.Collapsed;
            TLYC.Children.Clear();
        }
        #endregion
        #region FocusTextBox
        private void txtName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (xacnhan == 0)
            { txtName.Text = ""; }
        }

        private void txtPass_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPass.Password = "";
        }
        #endregion
        #region ChangeSize when Show-Hide AppBar
        private void appBar_MouseLeave(object sender, MouseEventArgs e)
        {
            TLYC.Margin = new Thickness(0, 50, 0, 0);
            GridStack.Visibility = Visibility.Collapsed;
        }

        private void appBar_MouseEnter(object sender, MouseEventArgs e)
        {
            TLYC.Margin = new Thickness(0, 70, 0, 0);
            GridStack.Visibility = Visibility.Visible;
        }
        #endregion

        private void Home_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            TLYC.Width = e.NewSize.Width;
            TLYC.Height = e.NewSize.Height;
            foreach (Control ctr in TLYC.Children)
            {
                if (ctr is Paradise5.Home)
                {
                    ctr.Width = TLYC.Width;
                    ctr.Height = TLYC.Height-70;
                }
            }
        }

    }
}
