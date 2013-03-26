using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Export;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraExport;

namespace HPA.Common
{
    public partial class ExportData : Form
    {
        GridView grdExport;
        public ExportData(GridView grdExp)
        {
            InitializeComponent();
            grdExport = grdExp;
        }
        #region Export to excel by CuongVD
        private void OpenFile(string fileName)
        {
            if (UIMessage.ShowMessage(CommonConst.OPEN_FILE_QUES, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    process.Start();
                }
                catch
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(this, "Cannot find an application on your system suitable for openning the file with exported data.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private string ShowSaveFileDialog(string title, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            string name = Application.ProductName;
            int n = name.LastIndexOf(".") + 1;
            if (n > 0) name = name.Substring(n, name.Length - n);
            dlg.Title = "Export To " + title;
            dlg.FileName = name;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }
        
        #endregion

        private void ExportData_Load(object sender, EventArgs e)
        {
            //Performce export to excel
            string fileName = ShowSaveFileDialog("Microsoft Excel Document", "Microsoft Excel|*.xls");
            if (fileName != "")
            {
                grdExport.ExportToXls(fileName);
                OpenFile(fileName);
            }
                this.Close();
        }
    }
}