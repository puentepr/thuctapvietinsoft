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
using DevExpress.Xpf.Grid;
using System.Windows.Data;

namespace HPA.Common
{
    public partial class Find : ChildWindow
    {
        Paradise5.ServiceReference1.Service1Client ws = new Paradise5.ServiceReference1.Service1Client();
        List<Employee_List_Code_WithStatusResult> nv;
        public Find()
        {
            InitializeComponent();
            ws.FindNVCompleted += ws_FindNVCompleted;
            ws.FindNVAsync();
        }

        void ws_FindNVCompleted(object sender, Paradise5.ServiceReference1.FindNVCompletedEventArgs e)
        {
            nv = e.Result.ToList();
            dtgrNV.Columns.Add(new GridColumn
            {
                Header = "EmployeeID",
                FieldName = "EmployeeID"
            });
            dtgrNV.Columns.Add(new GridColumn
            {
                Header = "FullName",
                FieldName = "FullName"
            });
            dtgrNV.ItemsSource = nv;
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            dtgrNV.ItemsSource = from p in nv where p.FullName.Contains(txtName.Text.ToLower()) || p.FullName.Contains(txtName.Text.ToUpper()) select p;
        }
    }
}

