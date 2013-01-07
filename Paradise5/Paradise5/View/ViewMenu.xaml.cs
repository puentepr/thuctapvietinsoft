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
using System.Windows.Navigation;
using DevExpress.Xpf.LayoutControl;

namespace Paradise5.View
{
    public partial class ViewMenu : Page
    {
        List<ViewMenu> view;
        TimeSpan ts = new TimeSpan(0, 0, 1);
        public ViewMenu()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        private void CreatTile(string MenuID, string MenuName)
        {
            Tile til = new Tile();
            til.Header = MenuName;
            til.AnimateContentChange = true;
            //var k = from p in view where p.ParentMenuID == MenuID && p.LoginID == LoginID && p.ClassName != "OK" select p.Name;
            //til.ContentSource = k.ToList();
            til.ContentChangeInterval = ts;
            til.VerticalAlignment = VerticalAlignment.Center;
            til.HorizontalAlignment = HorizontalAlignment.Center;
            til.Name = MenuID;
            TLYC.Children.Add(til);
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void TLYC_TileClick(object sender, TileClickEventArgs e)
        {
            //LoadMenu(e.Tile.Name);
            //cha.Add(e.Tile.Name);
        }

    }
}
