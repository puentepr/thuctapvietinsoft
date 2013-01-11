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
        List<sp_EmployeeIDListResult> nv;
        int Loginid=Paradise5.MainPage.LoginID;
        public Find()
        {
            InitializeComponent();
            ws.FindNVCompleted+=ws_FindNVCompleted;
            ws.FindNVAsync(3);//Tam the de test
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
            dtgrNV.ItemsSource = from p in nv where p.LastNameEN.ToUpper().Contains(txtName.Text.ToUpper())|| p.FullName.ToUpper().Contains(txtName.Text.ToUpper()) ||p.EmployeeID.Contains(txtName.Text) select p;
        }

        private void GridNV_RowDoubleClick(object sender, RowDoubleClickEventArgs e)
        {
            Paradise5.ControlEXT.TextBoxEX.emp=(sp_EmployeeIDListResult) dtgrNV.GetRow(GridNV.FocusedRowHandle);
            this.Close();
        }
    }
}

