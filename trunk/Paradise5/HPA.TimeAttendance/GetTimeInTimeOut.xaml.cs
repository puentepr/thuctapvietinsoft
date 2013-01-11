using Paradise5.ServiceReference1;
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

namespace HPA.TimeAttendance
{
    public partial class GetTimeInTimeOut : ChildWindow
    {
        List<tblDepartment> dp;
        Paradise5.ServiceReference1.Service1Client sv = new Paradise5.ServiceReference1.Service1Client();
        public GetTimeInTimeOut()
        {
            InitializeComponent();   
            sv.danhsachtheocagiolamCompleted+=sv_danhsachtheocagiolamCompleted;
            sv.danhsachtheocagiolamAsync();
            
            
            //sv.selectdanhsachAsync(1);
           
        }

        void sv_danhsachtheocagiolamCompleted(object sender, Paradise5.ServiceReference1.danhsachtheocagiolamCompletedEventArgs e)
        {
            lookup1.ItemsSource = e.Result;
            sv.selectdanhsachCompleted += sv_selectdanhsach;
            object i = lookup1.SelectedItem;
            var x = (tblDepartment)i;
            sv.selectdanhsachAsync(x.DepartmentID);
            
        }
        void sv_selectdanhsach(object sender, Paradise5.ServiceReference1.selectdanhsachCompletedEventArgs e)
        {
            lookup2.ItemsSource = e.Result;   
        }
        private void btnProcess_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnFWClose_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void checked_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void checked_TextInputStart_1(object sender, TextCompositionEventArgs e)
        {

        }

        private void GridColumn_TextInput_1(object sender, TextCompositionEventArgs e)
        {

        }

        private void control1_CustomColumnDisplayText_1(object sender, DevExpress.Xpf.Grid.CustomColumnDisplayTextEventArgs e)
        {

        }

        private void cb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lookup1_SelectedIndexChanged_1(object sender, RoutedEventArgs e)
        {
            sv.selectdanhsachCompleted += sv_selectdanhsach;
            object i = lookup1.SelectedItem;
            var x = (tblDepartment)i;
            sv.selectdanhsachAsync(x.DepartmentID);
        }

        private void lookup2_SelectedIndexChanged_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void txt1_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt1.Tag.ToString();
        }

        private void txt1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            txt1.Tag.ToString();
        }

        
    }
}

