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
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Editors.Settings;
using Paradise5.ServiceReference1;

namespace HPA.Announcement
{
    public partial class ConfigAnnouncement : ChildWindow
    {
        int k = 0;
        List<int> changedrows = new List<int>();//List lưu giá trị các dòng chỉnh sửa
        List<ViewThongBao> dsthongbao;
        Service1Client ws = new Service1Client();
        public ConfigAnnouncement()
        {
            ThemeManager.ApplicationThemeName = "Office2007Blue";
            InitializeComponent();
            ws.GetAllThongbaoCompleted += ws_GetAllThongbaoCompleted;
            ws.XoaThongbaoCompleted += ws_XoaThongbaoCompleted;
            ws.LuuThietLapThongBaoCompleted += ws_LuuThietLapThongBaoCompleted;
            LoadDanhSachThongBao();
        }

        void ws_LuuThietLapThongBaoCompleted(object sender, LuuThietLapThongBaoCompletedEventArgs e)
        {
            if (e.Result == true)//Neu luu thanh cong
            {
                changedrows.RemoveAt(k);//Xoa dong da luu thanh cong trong list
                k--;//Giam k xuong 1
                if (k < changedrows.Count() - 1)//Neu so lan luu chua bang so dong da sua
                {
                    k++;//Tang k len 1
                    luutb(changedrows.ElementAt(k));//Goi luu dong ke tiep
                }
                else
                {
                    Paradise5.ControlEXT.DialogResultCommon dialog = new Paradise5.ControlEXT.DialogResultCommon();
                    dialog.setthongdiep("Lưu thông báo hoàn tất");
                    dialog.Show();
                }
            }
            else if(e.Result==false)//Neu luu khong thanh cong
            {
                Paradise5.ControlEXT.DialogResultCommon dialog = new Paradise5.ControlEXT.DialogResultCommon();
                dialog.setthongdiep("Có lỗi xảy ra khi lưu thông báo từ dòng thứ "+changedrows.ElementAt(k).ToString());
                dialog.Show();
            }
        }

        void ws_XoaThongbaoCompleted(object sender, XoaThongbaoCompletedEventArgs e)
        {
            if (e.Result == true)
            {
                Paradise5.ControlEXT.DialogResultCommon dialog = new Paradise5.ControlEXT.DialogResultCommon();
                dialog.setthongdiep("Xóa thông báo thành công");
                dialog.Show();
            }
            else
            {
                Paradise5.ControlEXT.DialogResultCommon dialog = new Paradise5.ControlEXT.DialogResultCommon();
                dialog.setthongdiep("Có lỗi xảy ra");
                dialog.Show();
            }
            grViewTB.DeleteRow(grViewTB.FocusedRowHandle);
        }

        void ws_GetAllThongbaoCompleted(object sender, GetAllThongbaoCompletedEventArgs e)
        {
            //Load danh sach thong bao len Gridview
            Grid1.Columns.Clear();
            dsthongbao = e.Result.ToList();
            Grid1.ItemsSource = dsthongbao;
            Grid1.Columns["ID"].Visible = false;
            Grid1.Columns["TimeStart"].ReadOnly= true;
            Grid1.Columns["Lastchanged"].ReadOnly = true;
            Grid1.Columns["LoginName"].ReadOnly = true;
            //Add checkbox vao Grid
            //DevExpress.Xpf.Grid.GridColumn temp1 = new DevExpress.Xpf.Grid.GridColumn();
            //temp1.FieldName = "Changed";
            //temp1.EditSettings = new CheckEditSettings();
            //Grid1.Columns.Add(temp1);
        }

        void LoadDanhSachThongBao()
        {
            ws.GetAllThongbaoAsync(Paradise5.MainPage.LoginID);
        }
        
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            ViewThongBao tb = (ViewThongBao)Grid1.GetRow(grViewTB.FocusedRowHandle);
            ws.XoaThongbaoAsync(tb.ID);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            CreatAnnouncement edittb = new CreatAnnouncement();
            ViewThongBao tb = (ViewThongBao)Grid1.GetRow(grViewTB.FocusedRowHandle);
            edittb.SetTieuDeThongBao(tb.Title,tb.ID);
            edittb.Closed += edittb_Closed;
            edittb.Show();
        }

        void edittb_Closed(object sender, EventArgs e)
        {
            LoadDanhSachThongBao();
        }

        private void grViewTB_CellValueChanged(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {
            changedrows.Add(e.RowHandle);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            k = 0;
            if (changedrows.Count() > 0)
            {
                luutb(changedrows.ElementAt(k));
            }
        }
        void luutb(int i)
        {
            ViewThongBao tb = (ViewThongBao)Grid1.GetRow(i);
            ws.LuuThietLapThongBaoAsync((int)tb.ID, (bool)tb.Visible, (int)tb.Priority, tb.Title);
        }
    }
}

