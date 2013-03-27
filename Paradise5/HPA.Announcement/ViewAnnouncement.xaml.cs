using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
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
using DevExpress.XtraRichEdit;
using Paradise5.ServiceReference1;
using Paradise5;

namespace HPA.Announcement
{
    public partial class ViewAnnouncement : ChildWindow
    {
        IsolatedStorageFile str = IsolatedStorageFile.GetUserStoreForApplication();//Thiet dat thu muc chua file tam neu la WPF thi sua thanh IsolatedStorageFile.GetUserStoreForAssembly();
        Service1Client ws = new Service1Client();
        public string tieude = "Thông báo 16";
        public ViewAnnouncement()
        {
            InitializeComponent();
            tieude = Home.tentile;
            ThemeManager.ApplicationThemeName = "Office2007Blue";
            ws.GetThongBaoDonCompleted += ws_GetThongBaoDonCompleted;
            LoadThongBao();
        }

        void LoadThongBao()
        {
            ws.GetThongBaoDonAsync(tieude);
        }

        void ws_GetThongBaoDonCompleted(object sender, GetThongBaoDonCompletedEventArgs e)
        {
            if (e.Result != "")
            {
                IsolatedStorageFileStream fs = new IsolatedStorageFileStream("Temp.doc", FileMode.OpenOrCreate, FileAccess.ReadWrite, str);
                BinaryWriter br = new BinaryWriter(fs);
                br.Write(Convert.FromBase64String(e.Result));
                richEdit.LoadDocument(fs, DocumentFormat.Doc);
                this.Title = tieude;
                fs.Close();
                fs.Dispose();
            }
            else
            {
                richEdit.Text = "Nội dung thông báo trống";
            }
        }
    }
}

