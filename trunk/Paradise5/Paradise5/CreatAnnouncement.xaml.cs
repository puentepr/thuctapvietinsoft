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

namespace Paradise5
{
    public partial class CreatAnnouncement : RichEditDemoModule
    {
        public bool chidoc = false;
        public string tieude = "";
        public CreatAnnouncement()
        {
            InitializeComponent();
            //Set theme cho Style truoc tien phai add reference DevExpress.Xpf.Themes.Office2007Blue
            ThemeManager.ApplicationThemeName = "Office2007Blue";
            richEdit.ReadOnly = chidoc;
            biDatabaseSave.Content = "Save to Database";
            biDatabaseSave.ItemClick += biDatabaseSave_ItemClick;
            //Set bieu tuong cho button Save to Database
            biDatabaseSave.Glyph = new BitmapImage(new Uri(@"http://localhost:10511/Images/" + "Save.png", UriKind.RelativeOrAbsolute));
            biDatabaseSave.RibbonStyle = RibbonItemStyles.Large;
            
        }

        void biDatabaseSave_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (txtTitle.Text != "" && richEdit.Text != "")
            {
                FileStream fs = new FileStream("Temp.doc", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                richEdit.SaveDocument(fs, DocumentFormat.Doc);
                //BinaryReader br = new BinaryReader(fs);
                //FileInfo fInfo = new FileInfo("Temp.doc");
                //long numBytes = fInfo.Length;
                //byte[] filesave = null;
                //filesave = br.ReadBytes((int)numBytes);
                fs.Close();
                fs.Dispose();
                byte[] filesave = ReadFile("Temp.doc");
                //tblAnnouncement tbnew = new tblAnnouncement();
                //tbnew.Content = filesave;
                //tbnew.TimeStart = DateTime.Now;
                //tbnew.Title = txtTitle.Text;
                //dt.tblAnnouncements.InsertOnSubmit(tbnew);
                //dt.SubmitChanges();
                File.Delete("Temp.doc");
                MessageBox.Show("Lưu thành công");

            }
            else
            {
                MessageBox.Show("Lỗi");
            }
        }

        byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open,
                                                    FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);
            //When you use BinaryReader, you need to 

            //supply number of bytes to read from file.
            //In this case we want to read entire file. 

            //So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
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
