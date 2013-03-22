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
using System.Reflection;
using System.Windows.Controls;

namespace Paradise5
{
    public partial class CreatAnnouncement : RichEditDemoModule
    {
        IsolatedStorageFile str = IsolatedStorageFile.GetUserStoreForApplication();//Thiet dat thu muc chua file tam neu la WPF thi sua thanh IsolatedStorageFile.GetUserStoreForAssembly();
        Service1Client ws = new Service1Client();
        public bool chidoc = false;
        public static string tieude = "Thông báo 1";
        byte[] filesave;
        string noidungtam;
        public CreatAnnouncement()
        {
            InitializeComponent();
            //Set theme cho Style truoc tien phai add reference DevExpress.Xpf.Themes.Office2007Blue
            ThemeManager.ApplicationThemeName = "Office2007Blue";
            ws.GetThongBaoDonCompleted += ws_GetThongBaoDonCompleted;
            ws.LuuThongBaoCompleted += ws_LuuThongBaoCompleted;
            richEdit.ReadOnly = chidoc;
            biDatabaseSave.Content = "Save to Database";
            biDatabaseSave.ItemClick += biDatabaseSave_ItemClick;
            //Set bieu tuong cho button Save to Database
            biDatabaseSave.Glyph = new BitmapImage(new Uri(@"http://localhost:10511/Images/" + "Save.png", UriKind.RelativeOrAbsolute));
            biDatabaseSave.RibbonStyle = RibbonItemStyles.Large;
            //Load thong bao neu tieu de khac null
            if (tieude != "")
            {
                LoadThongBao();
            }
            
        }

        void LoadThongBao()
        {
            ws.GetThongBaoDonAsync(tieude);
        }

        void ws_GetThongBaoDonCompleted(object sender, GetThongBaoDonCompletedEventArgs e)
        {
            IsolatedStorageFileStream fs = new IsolatedStorageFileStream("Temp.doc", FileMode.OpenOrCreate, FileAccess.ReadWrite, str);
            BinaryWriter br = new BinaryWriter(fs);
            br.Write(Convert.FromBase64String(e.Result));
            richEdit.LoadDocument(fs, DocumentFormat.Doc);
            txtTitle.Text = tieude;
            fs.Close();
            fs.Dispose();
        }
        void biDatabaseSave_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (txtTitle.Text != "" && richEdit.Text != "")//Neu noi dung va tieu do khong trong
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
                ws.LuuThongBaoAsync(txtTitle.Text,noidungtam,false);
                
            }
            else
            {
                Paradise5.ControlEXT.DialogResultCommon dialog = new ControlEXT.DialogResultCommon();
                dialog.lblthongbao.Content = "Lỗi";
                dialog.Show();
            }
        }

        void ws_LuuThongBaoCompleted(object sender, LuuThongBaoCompletedEventArgs e)
        {
            if (e.Result==true)//Neu luu thanh cong
            {
                Paradise5.ControlEXT.DialogResultCommon dialog = new ControlEXT.DialogResultCommon();
                dialog.lblthongbao.Content = "Lưu thông báo thành công";
                dialog.Show();
            }
            else//Neu thong bao bi trung
            {
                Paradise5.ControlEXT.DialogResultCommon dialog = new ControlEXT.DialogResultCommon();
                dialog.lblthongbao.Content = "Thông báo bạn muốn tạo đã có. Bạn có muốn cập nhật";
                dialog.Closed += dialog_Closed;//Lay dialogresult khi dong form
                dialog.Show();
            }
        }

        void dialog_Closed(object sender, EventArgs e)
        {
            ControlEXT.DialogResultCommon dialog = (ControlEXT.DialogResultCommon)sender;
            if(dialog.DialogResult==true)
            {
                ws.LuuThongBaoAsync(txtTitle.Text, noidungtam, true);
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
    }
}
