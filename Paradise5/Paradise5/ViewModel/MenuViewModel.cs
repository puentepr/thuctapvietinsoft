using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Paradise5.ServiceReference1;
using System.Linq;

namespace Paradise5.ViewModel
{
    public class MenuViewModel : Navigation
    {
        Service1Client ws = new Service1Client();
        List<ViewMenu> vmn;
        public void Loaddata()
        {
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
            vmn = e.Result.ToList();
        }
        public MenuViewModel(object parent, string menuparentID)
        {
            MenuparentID = menuparentID;
            Parent = parent;
            ClickCommand = new ClickCommand(this);
            BackCommand= new BackCommand(parent);
            if (parent == "Mnu")
            {
                MainView = (from p in vmn where p.ParentMenuID == "Mnu" select p).ToList();
            }
            else
            {
                MainView = (from p in vmn where p.ParentMenuID == menuparentID && p.LoginID == LoginID && p.ClassName != "OK" select p).ToList();
            }
        }
        // Fields...
        public ICommand ClickCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public string MenuparentID { get; set; }
        public object Parent { get; set; }
        public List<ViewMenu> MainView;
        public int LoginID;
    }
}
