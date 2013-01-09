using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Paradise5.ControlEXT
{
    public partial class TextBoxEX : UserControl
    {
        public TextBoxEX()
        {
            InitializeComponent();
        }
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            var WbClnt = new WebClient();//Tao WebClient
            WbClnt.OpenReadCompleted += (a, b) =>
            {
                if (b.Error == null)
                {
                    AssemblyPart assmbpart = new AssemblyPart();
                    Assembly assembly = assmbpart.Load(b.Result);
                    Object Obj = assembly.CreateInstance("HPA.Common" + "." + "Find");//Truy xuat file dll
                    if (Obj != null)//Neu co file dll thi tao ChildWindow
                    {
                        ChildWindow child = (ChildWindow)assembly.CreateInstance("HPA.Common" + "." + "Find");
                        child.Show();
                    }
                    else { MessageBox.Show("Page not exist"); }//Khong ton tai page thi bao loi
                }
                else { MessageBox.Show("Page not exist"); }//Khong ton tai file dll thi bao loi
            };
            WbClnt.OpenReadAsync(new Uri("http://localhost:10511/Control/" + "HPA.Common" + ".dll", UriKind.Absolute));
        }
    }
}
