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

namespace Paradise5
{
    public partial class MainPage : UserControl
    {
        List<string> cha = new List<string>();
        int LoginID;
        List<ViewMenu> view;
        Service1Client ws = new Service1Client();
        TimeSpan ts = new TimeSpan(0, 0, 1);
        public MainPage()
        {
            InitializeComponent();
            ws.GetSessionCompleted += ws_GetSessionCompleted;
            ws.GetSessionAsync();
        }

        void ws_GetSessionCompleted(object sender, GetSessionCompletedEventArgs e)
        {
            HPL1.Content = "Chào mừng "+ e.Result;
            ws.GetIDCompleted += ws_GetIDCompleted;
            ws.GetIDAsync();
        }

        void ws_GetIDCompleted(object sender, GetIDCompletedEventArgs e)
        {
            LoginID = e.Result;
            ws.ViewMNCompleted += ws_ViewMNCompleted;
            ws.ViewMNAsync("VN");
        }
        void ws_ViewMNCompleted(object sender, ViewMNCompletedEventArgs e)
        {
            view = e.Result.ToList();
            LoadMenu("Mnu");
        }
        #region LoadMenu
        private void LoadMenu(string ParentName)
        {
            if (ParentName == "Mnu")
            {
                TLYC.Children.Clear();
                var q = from p in view where p.ParentMenuID == "Mnu" select p;
                foreach (var i in q)
                {
                    CreatTile(i.MenuID, i.Name,"");
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
                        { CreatTile(i.MenuID, i.Name, i.AssemblyName + "." + i.ClassName); }
                        else if (i.SupperAdmin == false || i.SupperAdmin == null)
                        {
                            CreatTile(i.MenuID, i.Name,i.AssemblyName+"."+i.ClassName);
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
        private void CreatTile(string MenuID, string MenuName, string Pagename)
        {
            Tile til = new Tile();
            til.Header = MenuName;
            til.AnimateContentChange = true;
            var k = from p in view where p.ParentMenuID == MenuID && p.LoginID == LoginID && p.ClassName != "OK" select p.Name;
            til.ContentSource = k.ToList();
            til.ContentChangeInterval = ts;
            til.VerticalAlignment = VerticalAlignment.Center;
            til.HorizontalAlignment = HorizontalAlignment.Center;
            til.Name = MenuID;
            til.Tag = Pagename;
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
            var WbClnt = new WebClient();
            WbClnt.OpenReadCompleted += (a, b) =>
            {
                if (b.Error == null)
                {
                    AssemblyPart assmbpart = new AssemblyPart();
                    Assembly assembly = assmbpart.Load(b.Result);
                    Object Obj = assembly.CreateInstance(asb + "." + cls);
                    if (Obj != null)
                    {
                        ChildWindow child = (ChildWindow)assembly.CreateInstance(asb + "." + cls);
                        TLYC.Children.Clear();
                        TLYC.Children.Add(child);
                    }
                    else { MessageBox.Show("Page not exist"); }
                }
                else { MessageBox.Show("Page not exist"); }
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
                LoadMenu("Mnu");
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            ws.RemoveSessionCompleted += ws_RemoveSessionCompleted;
            ws.RemoveSessionAsync();
        }

        void ws_RemoveSessionCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            this.Content = new Test();
        }
        private Visibility HideBack()
        {
            Visibility hide;
            if (cha.Count > 0)
            {
                hide= Visibility.Visible;
            }
            else hide= Visibility.Collapsed;
            return hide;
        }
    }
}
