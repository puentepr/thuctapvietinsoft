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
using Paradise5;
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
            // websv.CheckTimeListAsync(DateTime.Today,DateTime.Today, 1, 1, 1, "", true, true, true, true, true, true, true,3);
            websv.ColDepartmentCodelistCompleted += websv_ColDepartmentCodelistCompleted;
            websv.ColDepartmentCodelistAsync();
        }

        void websv_ColDepartmentCodelistCompleted(object sender, ColDepartmentCodelistCompletedEventArgs e)
        {
            lupeditDep.ItemsSource = e.Result;
        }

        void websv_CheckTimeListCompleted(object sender,CheckTimeListCompletedEventArgs e)
        {
            gridCheckTimeList.ItemsSource = e.Result;
        }
        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object rowDep = lupeditDep.GetItemByKeyValue(lupeditDep.SelectedItemValue);
               tblDepartment iDep = (tblDepartment)rowDep;
                object rowSec = lupeditSec.GetItemByKeyValue(lupeditSec.SelectedItemValue);
                tblSection iSec = (tblSection)rowSec;
                object rowGro = lupeditGroup.GetItemByKeyValue(lupeditGroup.SelectedItemValue);
                tblGroup iGro = (tblGroup)rowGro;
                if (rowDep !=null && rowSec !=null && rowGro !=null)
                    websv.CheckTimeListAsync(colFromDate.DateTime, colToDate.DateTime, iDep.DepartmentID, iSec.SectionID, iGro.GroupID, txtEmpId.Text, ckbNormal.IsChecked.Value, ckbNoTimeInHasTimeOut.IsChecked.Value, ckbHasTimeInNoTimeOut.IsChecked.Value, ckbNoTimeInNoTimeOut.IsChecked.Value, ckbWorkOnHoliday.IsChecked.Value, ckbLeave.IsChecked.Value, ckbHoliday.IsChecked.Value, 3);
            }
            catch (Exception)
            {
                throw new Exception("Loi Nhap lieu or .....");
            }
            //tham so dep +sec

        }

        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lupeditDep_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            websv.ColSectionCodelistCompleted += websv_ColSectionCodelistCompleted;
            websv.ColSectionCodelistAsync();
        }

        void websv_ColSectionCodelistCompleted(object sender, ColSectionCodelistCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            object rowDep = lupeditDep.GetItemByKeyValue(lupeditDep.SelectedItemValue);
            var iDep = (tblDepartment)rowDep;
            var i = from x in e.Result where x.DepartmentID == iDep.DepartmentID select x;
            lupeditSec.ItemsSource = i;
            //lupeditSec.ItemsSource = e.Result;
        }

        private void lupeditSec_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            websv.ColGroupCodelistCompleted += websv_ColGroupCodelistCompleted;
            websv.ColGroupCodelistAsync();
        }

        void websv_ColGroupCodelistCompleted(object sender, ColGroupCodelistCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            object rowSec = lupeditSec.GetItemByKeyValue(lupeditSec.SelectedItemValue);
            var iSec = (tblSection)rowSec;
            var i = from x in e.Result where x.SectionID == iSec.SectionID select x;
            lupeditGroup.ItemsSource = i;
            //lupeditGroup.ItemsSource = e.Result;
        }
    }
}

