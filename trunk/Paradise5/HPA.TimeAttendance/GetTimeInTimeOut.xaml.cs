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
        Paradise5.ServiceReference1.Service1Client sv = new Paradise5.ServiceReference1.Service1Client();
        public GetTimeInTimeOut()
        {
            InitializeComponent();         
           
        }

        //void sv_nhandangcavagiolamviecCompleted(object sender, ServiceReference1.nhandangcavagiolamviecCompletedEventArgs e)
        //{
        //  //.ItemsSource = e.Result;
        //}
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

        
    }
}

