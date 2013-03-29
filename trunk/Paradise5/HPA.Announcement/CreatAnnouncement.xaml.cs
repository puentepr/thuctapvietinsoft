using System;
using DevExpress.XtraRichEdit;
using DevExpress.XtraSpellChecker;
using DevExpress.Xpf.Ribbon;
using DevExpress.Xpf.SpellChecker;
using DevExpress.Xpf.Core;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using DevExpress.Xpf.Bars;
using Paradise5.ServiceReference1;
using System.IO.IsolatedStorage;
using System.Windows.Controls;
using Paradise5.ControlEXT;

namespace HPA.Announcement
{
    public partial class CreatAnnouncement : ChildWindow
    {
        int mathongbao = -1;//Quy dinh them moi hay cap nhat
        IsolatedStorageFile str = IsolatedStorageFile.GetUserStoreForApplication();//Thiet dat thu muc chua file tam neu la WPF thi sua thanh IsolatedStorageFile.GetUserStoreForAssembly();
        Service1Client ws = new Service1Client();
        byte[] filesave;
        string noidungtam;
        public CreatAnnouncement()
        {
            InitializeComponent();
            //Set theme cho Style truoc tien phai add reference DevExpress.Xpf.Themes.Office2007Blue
            ThemeManager.ApplicationThemeName = "Office2007Blue";
            ws.GetThongBaoDonCompleted += ws_GetThongBaoDonCompleted;
            ws.LuuThongBaoCompleted += ws_LuuThongBaoCompleted;
            //richEdit.ReadOnly = chidoc;
            biDatabaseSave.Content = "Save to Database";
            biDatabaseSave.ItemClick += biDatabaseSave_ItemClick;
            biFileNew.ItemClick += biFileNew_ItemClick;
            //Set bieu tuong cho button Save to Database
            biDatabaseSave.Glyph = new BitmapImage(new Uri(@"http://localhost:10511/Images/" + "Save.png", UriKind.RelativeOrAbsolute));
            biDatabaseSave.RibbonStyle = RibbonItemStyles.Large;
        }

        void biFileNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Set trạng thái thành thêm mới
            mathongbao = -1;
            txtTitle.Text = "";
        }

        void ws_GetThongBaoDonCompleted(object sender, GetThongBaoDonCompletedEventArgs e)
        {
            IsolatedStorageFileStream fs = new IsolatedStorageFileStream("Temp.doc", FileMode.OpenOrCreate, FileAccess.ReadWrite, str);
            BinaryWriter br = new BinaryWriter(fs);
            br.Write(Convert.FromBase64String(e.Result));
            richEdit.LoadDocument(fs, DocumentFormat.Doc);
            fs.Close();
            fs.Dispose();
        }
        void biDatabaseSave_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (txtTitle.Text != "" && richEdit.Text != "")//Neu noi dung va tieu de khong trong
            {
                //Tao file stream
                IsolatedStorageFileStream fs = new IsolatedStorageFileStream("Temp.doc", FileMode.OpenOrCreate, FileAccess.ReadWrite, str);
                //Save noi dung vao filestream
                richEdit.SaveDocument(fs, DocumentFormat.Doc);
                fs.Close();
                fs.Dispose();
                //Chuyen noi dung thanh dang binary
                filesave = ReadFile();
                //Dua dang binary ve dang base64string
                noidungtam = Convert.ToBase64String(filesave);
                //Gui lenh luu xuong CSDL
                if (mathongbao == -1)//Nếu là thêm mới
                {
                    ws.LuuThongBaoAsync(txtTitle.Text, noidungtam, Paradise5.MainPage.LoginID,mathongbao);
                }
                else//Nếu là cập nhật
                {
                    Paradise5.ControlEXT.DialogResultCommon dialog = new Paradise5.ControlEXT.DialogResultCommon();
                    dialog.setthongdiep("Thông báo bạn muốn tạo đã có. Bạn có muốn cập nhật");
                    dialog.Closed += dialog_Closed;//Lay dialogresult khi dong form
                    dialog.Show();
                }
            }
            else
            {
                Paradise5.ControlEXT.DialogResultCommon dialog = new Paradise5.ControlEXT.DialogResultCommon();
                dialog.setthongdiep("Lỗi");
                dialog.Show();
            }
        }

        void ws_LuuThongBaoCompleted(object sender, LuuThongBaoCompletedEventArgs e)
        {
            if (e.Result != -1)//Neu luu thanh cong
            {
                mathongbao = e.Result;
                Paradise5.ControlEXT.DialogResultCommon dialog = new Paradise5.ControlEXT.DialogResultCommon();
                dialog.setthongdiep("Lưu thông báo thành công");
                dialog.Show();
            }
            else//Neu luu khong thanh cong
            {
                Paradise5.ControlEXT.DialogResultCommon dialog = new Paradise5.ControlEXT.DialogResultCommon();
                dialog.setthongdiep("Có lỗi xảy ra khi lưu thông báo");
                dialog.Show();
            }
        }

        void dialog_Closed(object sender, EventArgs e)
        {
            Paradise5.ControlEXT.DialogResultCommon dialog = (Paradise5.ControlEXT.DialogResultCommon)sender;
            if (dialog.DialogResult == true)
            {
                ws.LuuThongBaoAsync(txtTitle.Text, noidungtam, Paradise5.MainPage.LoginID,mathongbao);
            }
        }

        byte[] ReadFile()
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.

            //Open FileStream to read file
            IsolatedStorageFileStream fStream = new IsolatedStorageFileStream("Temp.doc", FileMode.Open, FileAccess.Read, str);
            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);
            //When you use BinaryReader, you need to 

            //supply number of bytes to read from file.
            //In this case we want to read entire file. 

            //So supplying total number of bytes.
            //data = br.ReadBytes((int)numBytes);
            data = br.ReadBytes((int)fStream.Length);
            fStream.Close();
            fStream.Dispose();
            return data;
        }

        void richEdit_SelectionChanged(object sender, EventArgs e)
        {
            bool isSelectionInFloatingObject = richEdit.IsFloatingObjectSelected;
            if (catPictureTools.IsVisible != isSelectionInFloatingObject)
            {
                catPictureTools.IsVisible = isSelectionInFloatingObject;
                if (isSelectionInFloatingObject)
                    ribbonControl.SelectedPage = pagePictureToolsFormat;
            }
        }
        //Ham Load thong bao voi tieu de tu form khac truyen vao
        public void SetTieuDeThongBao(string s,int matb)
        {
            txtTitle.Text = s;
            mathongbao = matb;
            ws.GetThongBaoDonAsync(mathongbao.ToString());
            
        }
    }
}
