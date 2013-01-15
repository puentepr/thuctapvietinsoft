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
namespace HPA.TimeAttendance
{
    public partial class ModifyTAData : ChildWindow
    {
        Service1Client websv = null;
        public ModifyTAData()
        {
            InitializeComponent();
            websv = new Service1Client();
            websv.CheckTimeListCompleted += websv_CheckTimeListCompleted;
            websv.ColDepartmentCodelistCompleted += websv_ColDepartmentCodelistCompleted;
            websv.ColDepartmentCodelistAsync();
            //websv.CheckTimeListAsync(DateTime.Now, DateTime.Now, 1, 1, 1, "", false, false, false, false, false, false, false, 3);
            //colFromDate.DateTime= 
        }

        void websv_ColDepartmentCodelistCompleted(object sender, ColDepartmentCodelistCompletedEventArgs e)
        {
            lupeditDep.ItemsSource = e.Result;
        }

        void websv_CheckTimeListCompleted(object sender, CheckTimeListCompletedEventArgs e)
        {
            gridCheckTimeList.ItemsSource = e.Result;
        }
        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object rowDep = lupeditDep.SelectedItem;
                tblDepartment iDep = (tblDepartment)rowDep;
                object rowSec = lupeditSec.SelectedItem;
                tblSection iSec = (tblSection)rowSec;
                object rowGro = lupeditGroup.SelectedItem;
                tblGroup iGro = (tblGroup)rowGro;
                if (colFromDate.DateTime != null && colToDate.DateTime != null)
                {
                    int depID = -1;
                    if (iDep != null)
                        depID = iDep.DepartmentID;
                    int secID = -1;
                    if (iSec != null)
                        secID = iSec.SectionID;
                    int groID = -1;
                    if (iGro != null)
                        groID = iGro.GroupID;
                    string empID = "-1";
                    if (txtEmpId.GetID().EmployeeID != null)
                        empID = txtEmpId.GetID().EmployeeID;
                    websv.CheckTimeListAsync(colFromDate.DateTime, colToDate.DateTime, depID, secID, groID, empID, ckbNormal.IsChecked.Value, ckbNoTimeInHasTimeOut.IsChecked.Value, ckbHasTimeInNoTimeOut.IsChecked.Value, ckbNoTimeInNoTimeOut.IsChecked.Value, ckbWorkOnHoliday.IsChecked.Value, ckbLeave.IsChecked.Value, ckbHoliday.IsChecked.Value, 3);       
                    panelThietLap.Closed = true;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        private void lupeditDep_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            websv.ColSectionCodelistCompleted += websv_ColSectionCodelistCompleted;
            websv.ColSectionCodelistAsync();
            lupeditDep.DisplayMember = "DepartmentName";
        }

        void websv_ColSectionCodelistCompleted(object sender, ColSectionCodelistCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            object rowDep = lupeditDep.SelectedItem;
            var iDep = (tblDepartment)rowDep;
            var i = from x in e.Result where x.DepartmentID == iDep.DepartmentID select x;
            lupeditSec.ItemsSource = i;
            //lupeditSec.ItemsSource = e.Result;
        }

        private void lupeditSec_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            websv.ColGroupCodelistCompleted += websv_ColGroupCodelistCompleted;
            websv.ColGroupCodelistAsync();
            lupeditSec.DisplayMember = "SectionName";
        }

        void websv_ColGroupCodelistCompleted(object sender, ColGroupCodelistCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            object rowSec = lupeditSec.SelectedItem;
            var iSec = (tblSection)rowSec;
            var i = from x in e.Result where x.SectionID == iSec.SectionID select x;
            lupeditGroup.ItemsSource = i;
            //lupeditGroup.ItemsSource = e.Result;
        }
        private void lupeditGroup_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            lupeditGroup.DisplayMember = "GroupName";
        }
      
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnrefresh_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void txtEmpId_GotFocus(object sender, RoutedEventArgs e)
        {
            txtEmpName.Text = txtEmpId.GetID().FullName;
        }

    }
}

