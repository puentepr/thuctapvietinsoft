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

namespace Paradise5
{
    public partial class MainPage : UserControl
    {
        List<string> cha = new List<string>();
        public static int LoginID=-1;
        List<ViewMenu> view;
        Service1Client ws = new Service1Client();
        TimeSpan ts = new TimeSpan(0, 0, 1);
        public MainPage()
        {
            InitializeComponent();
        }
        #region Login
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "")
            {
                txtName.SetValidation("Tên đăng nhập không được để trống");
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
                txtName.RaiseValidationError();
            }
            else if (loginid == -3)
            {
                txtName.SetValidation("Mật khẩu của bạn đã lâu không thay đổi. Vui lòng đổi mật khẩu");
                txtName.RaiseValidationError();
            }
            else
            {
                txtName.ClearValidationError();
                LoginID = loginid;
                paneProperties.Caption = "Options";
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
            LoadMenu("Mnu");
            
        }
        #endregion

        #region LoadMenu
        private void LoadMenu(string ParentName)
        {
            TLYC.HorizontalAlignment = HorizontalAlignment.Center;
            if (ParentName == "Mnu")
            {
                TLYC.Children.Clear();
                var q = from p in view where p.ParentMenuID == "Mnu" select p;
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
                        child.Width = (double)HtmlPage.Window.Eval("screen.availWidth")-100;
                        child.Height = (double)HtmlPage.Window.Eval("screen.availHeight")-100;
                        child.Show();
                    }
                    else { MessageBox.Show("Page not exist"); }//Khong ton tai page thi bao loi
                }
                else { MessageBox.Show("Page not exist"); }//Khong ton tai file dll thi bao loi
            };
            WbClnt.OpenReadAsync(new Uri("http://localhost:10511/Control/" + asb + ".dll", UriKind.Absolute));
       }
        #endregion
        private void TLYC_TileClick(object sender, TileClickEventArgs e)
        {
            cha.Add(e.Tile.Name);
            LoadMenu(e.Tile.Name);
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (cha.Count > 0)
            {
                TLYC.Children.Clear();
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
            paneProperties.Caption = "Login";
            txtName.Visibility = Visibility.Visible;
            txtPass.Visibility = Visibility.Visible;
            btnLogin.Visibility = Visibility.Visible;
            HPL1.Visibility = Visibility.Collapsed;
            HpLogout.Visibility = Visibility.Collapsed;
            TLYC.Children.Clear();
        }
        #endregion

        private void txtName_GotFocus(object sender, RoutedEventArgs e)
        {
            txtName.Text="";
        }

        private void txtPass_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPass.Password = "";
        }
    }
}
