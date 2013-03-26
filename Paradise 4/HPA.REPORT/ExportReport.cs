using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HPA.Common;
using HPA.Component;
using Word = Microsoft.Office.Interop.Word;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using HPA.CommonForm;

namespace HPA.Report
{
    public partial class ExportReport : HPA.Component.Framework.CCommonForm
    {
        private string strFileName;
        string strSPName = "";
        private const string P_NAME = "Name";
        private const string LBL_PREFIX = "lbl";
        private const string DTP_PREFIX = "dtp";
        private const string TXT_PREFIX = "txt";
        private const string CBX_PREFIX = "cbx";
        private const string XLS = "xls";
        private const string DOC = "doc";
        private const string ParamName = "ParamName";
        private const string Message_P = "Message";
        private const string CellLocation = "CellLocation";
        private const string DataType = "DataType";
        private const string Query = "Query";
        private const string TEMPLATES = "TEMPLATES";
        private const string MergerData = "MergerData.xls";
        private string strExtend;

        private const string SUNDAY = "Sunday";
        private const string DAY_IN_MONTH = "10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31";

        private string[,] cellLocation;
        private string[] paramValue;
        private string[] paramName;

        private const string EXPORT_TYPE = "crystalreport";
        private DataTable dtInitValue;

        private System.Data.DataTable dtReportList;
        public ExportReport()
        {
            InitializeComponent();
            //Load title
            Control.ControlCollection ctrls = this.Controls;
            HPA.Common.UIMessage.LoadLableName(ref ctrls);
            btnExport.Text = UIMessage.Get_Message("btnShowData");
            txtLastName.Focus();
        }
        public override void SetData(object objParam)
        {
            try
            {
                this.Text = objParam.ToString();
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".SetData()", null);
                return;
            }
        }
        public override bool InitializeData()
        {
            try
            {
                 GetReportList();
                MyInitialize();
                

            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".InitializeData()", null);
                return false;
            }
            return true;
        }
        protected void GetReportList()
        {
            try
            {
                dtReportList = DBEngine.execReturnDataTable("sp_Export_List","@LanguageID", UIMessage.languageID, CommonConst.A_LoginID, UserID);
                // show on grid control
                grdExportList.DataSource = dtReportList;

            }
            catch (Exception ex)
            {
                UIMessage.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void MyInitialize()
        {
            radAll.Checked = true;
            
           // radValueOnly.Checked = true;
            //Binding data
            //txtSpName.DataBindings.Add("EditValue", dtReportList, "ProcedureName");
            txtExcelFileName.DataBindings.Clear();
            txtStartRow.DataBindings.Clear();
            txtStartColumn.DataBindings.Clear();
            txtExportType.DataBindings.Clear();
            //Binding data
            //txtSpName.DataBindings.Add("EditValue", dtReportList, "ProcedureName");
            txtExcelFileName.DataBindings.Add("EditValue", dtReportList, "TemplateFileName");
            txtStartRow.DataBindings.Add("EditValue", dtReportList, "StartRow");
            txtStartColumn.DataBindings.Add("EditValue", dtReportList, "StartColumn");
            txtExportType.DataBindings.Add("EditValue", dtReportList, "ExportType");
            ShowCatalogFilter();
        }
        protected void ShowCatalogFilter()
        {
            string strAddedCtrlName = "";
            const int radWidth = 128;
            const int radHeight = 25;
            int intX = radWidth;// 16 + 40;
            const int intY = 16;
            foreach (DataRow dr in dtReportList.Rows)
            {
                if (!strAddedCtrlName.Equals(dr["CataLog"].ToString().Trim().ToUpper()))
                {
                    Point p = new Point(intX, intY);
                    RadioButton radCtrl = new RadioButton();
                    grbExportListFilter.Controls.Add(radCtrl);
                    radCtrl.Name = "rad" + dr["CataLog"].ToString().Substring(0, 3);
                    radCtrl.Text = dr["CataLog"].ToString();
                    radCtrl.Location = p;
                    radCtrl.Width = radWidth;
                    radCtrl.Height = radHeight;
                    intX = intX + radWidth;
                    // add checked change event
                    radCtrl.CheckedChanged += new EventHandler(radCtrl_CheckedChanged);
                    strAddedCtrlName = radCtrl.Text.ToUpper();
                }
            }
        }
        private void radCtrl_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rad = (RadioButton)sender;
            string filter = string.Format("CataLog = '{0}'", rad.Text);
            if (rad.Text.Equals("All"))
            {
                filter = "";
            }
            dtReportList.DefaultView.RowFilter = filter;
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = UIMessage.Get_Message("CHOOSE_FILE_SAVE");
            if (!ckbCSV.Checked)
                sfd.Filter = "Excel file (*.xls)|*.xls";
            else
                sfd.Filter = "CSV (Comma delimited) (*.csv)|*.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
                btnExport.Focus();
            else
                xbeFileName.Focus();
            xbeFileName.Text = sfd.FileName;
            strFileName = sfd.FileName;
        }
        private System.Data.DataTable GetParameter(string procName)
        {
            DataTable dtRet = null;
            try
            {
                dtRet = DBEngine.execReturnDataTable("sp_Export_GetParameter", 
                    "@ProcedureName", strSPName.Trim(),
                    "@LanguageID",UIMessage.languageID);
            }
            catch (Exception ex)
            {
                UIMessage.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return dtRet;
        }
        Excel.Application app;
        private void AddDataSource(ref DevExpress.XtraEditors.LookUpEdit le, System.Data.DataTable dt)
        {
            le.Properties.Columns.Clear();
            le.Properties.DataSource = dt;
            Int32 width = 125;
            int i = 0;
            foreach (DataColumn dc in dt.Columns)
            {
                if (++i > 2)
                    break;
                LookUpColumnInfo luColumnInfo = new LookUpColumnInfo(dc.Caption, width);
                le.Properties.Columns.Add(luColumnInfo);
            }
            if (dt.Columns.Count >= 2)
            {
                le.Properties.ValueMember = dt.Columns[0].Caption;
                le.Properties.DisplayMember = dt.Columns[1].Caption;
                // get the first rows
                le.EditValue = dt.Rows[0][0].ToString();
            }
            else
            {
                le.Properties.ValueMember = dt.Columns[0].Caption;
                le.Properties.DisplayMember= dt.Columns[0].Caption;
                // get the first rows
                le.EditValue = dt.Rows[0][0].ToString();//DataBindings.Add("EditValue", dt,dt.Columns[0].Caption);
            }
            
        }
        private bool ValidateInput()
        {
            bool blnVal = true;
          
           

            if ((dtReportList == null) || (dtReportList.Rows.Count <= 0))
            {
                return false;
            }
           
            //Validate inputed parameter
            foreach (Control ctr in grbFilter.Controls)
            {
                if (ctr is Label)
                {
                    // do nothing
                }
                else
                {
                    try
                    {
                        //get values
                        switch (ctr.Name.Substring(0, 3))
                        {
                            case TXT_PREFIX:
                                {
                                    TextBox txt = ctr as TextBox;
                                    if (txt.Name.ToLower().Contains(CommonConst.A_EmployeeID.ToLower()))
                                        break;
                                    if ("".Equals(txt.Text.Trim()))
                                        blnVal = false;
                                    break;
                                }
                            case CBX_PREFIX:
                                {
                                    DevExpress.XtraEditors.LookUpEdit cbx = (DevExpress.XtraEditors.LookUpEdit)ctr;
                                    if (cbx.EditValue == null)
                                        blnVal = false;
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                    }
                    catch (Exception ex)
                    {
                        UIMessage.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            if (!blnVal)
            {
                UIMessage.ShowMessage("INPUT_CONDITION_VALUE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return blnVal;
            }
            //if ((grbFileName.Visible == true) && (xbeFileName.Text.Trim().Equals("")))
            //{
            //    //try
            //    //{
            //    //    UIMessage.ShowMessage("EXPORT_FILE_PATH_ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //    blnVal = false;
            //    //}
            //    //catch (Exception ex)
            //    //{
            //    //    UIMessage.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //}
            //}
            //if (!System.IO.File.Exists(Application.StartupPath + @"\TEMPLATES\" + txtExcelFileName.Text))
            //{
            //    UIMessage.ShowMessage("RP_002", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            //if (this.FileOpened(xbeFileName.Text))
            //{
            //    UIMessage.ShowMessage("RP_003", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            return blnVal;
        }
        private void InputConditionValue()
        {
            for (int i = 0; i < paramValue.Length; i++)
            {
                for (int j = 0; j < paramName.Length; j++)
                {
                    if (paramName[j].Equals(cellLocation[2, i]))
                    {
                        cellLocation[2, i] = paramValue[j];
                    }
                }
            }
        }
        private void OpenWorddocument(string m_strFileName, object fileName)
        {
            // get template of word
            Word.Application application = new Word.Application();
            object missingValue = Type.Missing;
            Word._Document document;

            String datasourell = m_strFileName;
            Word.MailMerge wrdMailMerge;
            object ab = false;



            document =
            application.Documents.Open(ref fileName, ref missingValue,
            ref missingValue, ref missingValue, ref missingValue,
            ref missingValue, ref missingValue, ref missingValue,
            ref missingValue, ref missingValue, ref missingValue,
            ref missingValue, ref missingValue, ref missingValue,
            ref missingValue, ref missingValue);




            wrdMailMerge = document.MailMerge;
            object typea = Word.WdMergeSubType.wdMergeSubTypeOther;
            object sqlquery = "SELECT * FROM [Sheet1$]";

            wrdMailMerge.OpenDataSource(datasourell,
                ref missingValue,
                ref missingValue,
                ref missingValue,
                ref missingValue,
                ref missingValue,
                ref missingValue,
                ref missingValue,
                ref missingValue,
                ref missingValue,
                ref missingValue,
                ref missingValue,
                ref sqlquery,
                ref missingValue,
                ref missingValue,
                ref typea);

            wrdMailMerge.Destination = Word.WdMailMergeDestination.wdSendToNewDocument;

            wrdMailMerge.Execute(ref missingValue);



            object wSaveOptions = Word.WdSaveOptions.wdDoNotSaveChanges;
            object wOriginalFormat = Word.WdOriginalFormat.wdPromptUser;
            object wRouteDocument = false;
            document.Close(ref wSaveOptions, ref wOriginalFormat, ref wRouteDocument);

            application.Visible = true;
        }
        public override bool OnExport()
        {
            // validate data
            if (!ValidateInput())
            {
                return false;
            }
            pnlInformation.Visible = true;
            // get parameter values
            paramValue = new string[grbFilter.Controls.Count / 2];
            paramName = new string[grbFilter.Controls.Count / 2];
            int count = 0;
            foreach (Control ctr in grbFilter.Controls)
            {
                if (ctr is Label)
                {
                    // do nothing
                }
                else
                {
                    try
                    {
                        //get values
                        switch (ctr.Name.Substring(0, 3))
                        {
                            case TXT_PREFIX:
                                {
                                    TextBox txt = ctr as TextBox;
                                    if (txt.Name.ToLower().Contains(CommonConst.A_EmployeeID.ToLower()) && txt.Text.Equals(""))
                                    {
                                        paramName[count] = txt.Name.Substring(3);
                                        paramValue[count] = "-1";
                                    }
                                    else
                                    {
                                        paramName[count] = txt.Name.Substring(3);
                                        paramValue[count] = txt.Text;
                                    }
                                    break;
                                }
                            case CBX_PREFIX:
                                {
                                    DevExpress.XtraEditors.LookUpEdit cbx = (DevExpress.XtraEditors.LookUpEdit)ctr;
                                    paramName[count] = cbx.Name.Substring(3);
                                    paramValue[count] = cbx.EditValue.ToString();
                                    break;
                                }
                            case DTP_PREFIX:
                                {
                                    DateEdit dtp = ctr as DateEdit;
                                    paramName[count] = dtp.Name.Substring(3);
                                    paramValue[count] = dtp.EditValue.ToString();
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }

                        count++;
                    }
                    catch (Exception ex)
                    {
                        pnlInformation.Visible = false;
                        UIMessage.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            InputConditionValue();
            //Export data
            // match Parameter name and value
            try
            {
                byte index = 0;
                object[] param = new object[(grbFilter.Controls.Count / 2) * 2 + 2];
                for (byte i = 0; i < paramName.Length; i++)
                {
                    param[index++] = paramName[i];
                    param[index++] = paramValue[i];
                }
                //add loginID parameter
                param[index++] = CommonConst.A_LoginID;
                param[index++] = UserID;
                if (!txtExportType.Text.Trim().ToLower().Equals(EXPORT_TYPE))
                {
                    // get data from SQL and export to excell
                    DataSet dsExport = DBEngine.execReturnDataSet(strSPName, param);//DBEngine.execReturnDataTable(strSPName, param);
                    if ((dsExport == null) || (dsExport.Tables.Count <= 0))
                        return false;
                    // Export data
                    if (ckbCSV.Checked)
                        ExportToCSV(dsExport.Tables[0]);
                    else
                        if (strExtend.Equals(DOC))
                            ExportToWord(dsExport.Tables[0], txtExcelFileName.Text);
                        else
                        {
                            app = new Excel.Application();
                            app.UserControl = true;
                            //System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
                            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                            ExportToExcel(dsExport);
                        }
                }// view crystal report
                else
                {
                    // report noneed LoginID
                    string strReportName = txtExcelFileName.Text.Trim();
                    HPA.Common.SReport sRpt = new HPA.Common.SReport();
                    sRpt.ReportName = strReportName;
                    sRpt.Parameters = param;
                    object o = null;
                    OpenObject("HPA.Report", "CReportView", true, sRpt, out o);
                }
            }
            catch (Exception ex)
            {
                pnlInformation.Visible = false;
                UIMessage.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            pnlInformation.Visible = false;
            return true;

        }

        private void ExportToExcelWithoutTemp(string m_strFileName, System.Data.DataTable dt)
        {
            if (dt == null || dt.Rows.Count <= 0)
                return;
            xpbProcecess.Properties.Step = 1;
            xpbProcecess.Properties.Minimum = 0;
            xpbProcecess.Properties.Maximum = dt.Rows.Count;
            xpbProcecess.Position = 0;
            xpbProcecess.Properties.PercentView = true;

            //Excel.Application app;
            object MISS = Type.Missing;
            app = new Excel.Application();
            Excel.Workbooks workbooks;
            Excel._Workbook wb;
            try
            {
                workbooks = app.Workbooks;
                wb = workbooks.Add(true);
                Excel.Sheets exSheets = wb.Worksheets;
                Excel._Worksheet ws = (Excel._Worksheet)exSheets.get_Item(1);
                //Start Exporting data to Excel file, row by row
                int countRow = 1;
                // export Header
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ((Excel.Range)ws.Cells[countRow, i + 1]).Value2 = dt.Columns[i].Caption;
                    ((Excel.Range)ws.Cells[countRow, i + 1]).Interior.ColorIndex = 15;
                    ((Excel.Range)ws.Cells[countRow, i + 1]).Font.Bold = true;
                }
                countRow++;
                // insert excel row
                object[,] arrData = new object[dt.Rows.Count, dt.Columns.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Rows[i][j] != DBNull.Value)
                            if (!ckbToneMarks.Checked)
                                arrData[i, j] = dt.Rows[i][j].ToString();
                            else
                            {
                                arrData[i, j] = Methods.RemoveToneMarks(dt.Rows[i][j].ToString());
                            }
                    }
                    xpbProcecess.Increment(1);
                    xpbProcecess.Update();
                }
                Excel.Range rg = ((Excel.Range)ws.get_Range(ws.Cells[2, 1], ws.Cells[dt.Rows.Count + 1, dt.Columns.Count]));
                rg.Select();
                rg.Value2 = arrData;
                //End of Exporting76
                this.Cursor = Cursors.Default;
                if (!strExtend.Equals(XLS))
                {
                    app.Visible = false;
                    wb.SaveCopyAs(xbeFileName.Text);
                    wb.Close(false, false, false);
                    app.Quit();
                    //Open word merge mail document
                    OpenWorddocument(xbeFileName.Text,txtExcelFileName.Text);

                }
                else

                    app.Visible = true;

                //release Object Excel

                releaseObject(exSheets);
                releaseObject(wb);
                releaseObject(rg);
                releaseObject(workbooks);

                releaseObject(ws);
                releaseObject(app);


                btnFWClose.Focus();
                btnExport.Enabled = true;
            }
            catch (Exception ex)
            {
                app.Workbooks.Close();
                app = null;

                this.Cursor = Cursors.Default;
                HPA.Common.Helper.ShowException(ex, this.Name + ".ExportToExcelWithoutTemp()", null);
                return;
            }
        }
        public void ExportToWord( System.Data.DataTable dt,string WordTemplateName)
        {
            if (dt == null || dt.Rows.Count <= 0)
                return;
            string MergerFilePath = string.Format(@"{0}\{1}\{2}", Application.StartupPath, TEMPLATES, MergerData);
            xpbProcecess.Properties.Step = 1;
            xpbProcecess.Properties.Minimum = 0;
            xpbProcecess.Properties.Maximum = dt.Rows.Count;
            xpbProcecess.Position = 0;
            xpbProcecess.Properties.PercentView = true;

            Excel.Application app;
            object MISS = Type.Missing;
            app = new Excel.Application();
            Excel.Workbooks workbooks;
            Excel._Workbook wb;
            try
            {
                workbooks = app.Workbooks;
                wb = workbooks.Add(true);
                Excel.Sheets exSheets = wb.Worksheets;
                Excel._Worksheet ws = (Excel._Worksheet)exSheets.get_Item(1);
                //Start Exporting data to Excel file, row by row
                int countRow = 1;
                // export Header
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ((Excel.Range)ws.Cells[countRow, i + 1]).Value2 = dt.Columns[i].Caption;
                    ((Excel.Range)ws.Cells[countRow, i + 1]).Interior.ColorIndex = 15;
                    ((Excel.Range)ws.Cells[countRow, i + 1]).Font.Bold = true;
                }
                countRow++;
                // insert excel row
                object[,] arrData = new object[dt.Rows.Count, dt.Columns.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Rows[i][j] != DBNull.Value)
                            if (!ckbToneMarks.Checked)
                                arrData[i, j] = dt.Rows[i][j].ToString();
                            else
                            {
                                arrData[i, j] = Methods.RemoveToneMarks(dt.Rows[i][j].ToString());
                            }
                    }
                    xpbProcecess.Increment(1);
                    xpbProcecess.Update();
                }
                Excel.Range rg = ((Excel.Range)ws.get_Range(ws.Cells[2, 1], ws.Cells[dt.Rows.Count + 1, dt.Columns.Count]));
                rg.Select();
                rg.Value2 = arrData;
                //End of Exporting76
                app.Visible = false;
                wb.SaveCopyAs(MergerFilePath);
                wb.Close(false, false, false);
                app.Quit();
                OpenWorddocument(MergerFilePath,string.Format(@"{0}\{1}\{2}", Application.StartupPath, TEMPLATES, WordTemplateName));

                releaseObject(exSheets);
                releaseObject(wb);
                releaseObject(rg);
                releaseObject(workbooks);

                releaseObject(ws);
                releaseObject(app);
                btnFWClose.Focus();
                btnExport.Enabled = true;
                this.Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                app.Workbooks.Close();
                app = null;

                this.Cursor = Cursors.Default;
                HPA.Common.Helper.ShowException(ex, this.Name + ".ExportToExcelWithoutTemp()", null);
                return;
            }
        }
        public static void ExportToExcel(DataRow[] dr, string TemplateFileName, string SaveFileName)
        {
            string m_strTemplateFile = String.Format(@"{0}\TEMPLATES\{1}", Application.StartupPath, TemplateFileName);
            //excelapp.Application.Workbooks.Add(true);
            string m_strFileName = SaveFileName;
            //initialize for controls

           
           Excel.Application app = new Excel.Application();
            try
            {
                Excel.Workbooks workbooks;
                Excel._Workbook wb;
                workbooks = app.Workbooks;
                wb = workbooks.Add(m_strTemplateFile);
                wb.SaveCopyAs(m_strFileName);
                wb.Close(false, Type.Missing, Type.Missing);
                wb = workbooks.Open(m_strFileName
                    , Type.Missing
                    , Type.Missing
                    , Type.Missing
                    , Type.Missing
                    , Type.Missing
                    , Type.Missing
                    , Type.Missing
                    , Type.Missing
                    , Type.Missing
                    , Type.Missing
                    , Type.Missing
                    , Type.Missing);
               // wb = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Sheets exSheets = wb.Worksheets;

                Excel._Worksheet ws;
                Excel.Range rg;

                ws = (Excel._Worksheet)exSheets.get_Item(1);
                ws.Select(1);

                //Start Exporting data to Excel file, row by row
                const int ROW_START = 1;
                const int COLUMN_START = 1;
                int countRow = 0;
                // insert excel row
                object[,] arrData = new object[dr.Length, dr[0].ItemArray.Length];
                for (int i = 0; i < dr.Length; i++)
                {
                    for (int j = 0; j < dr[0].ItemArray.Length; j++)
                    {
                        if (dr[i][j] != DBNull.Value)
                            arrData[i, j] = dr[i][j].ToString();
                    }
                    if (dr.Length > countRow + 2)
                    {
                        rg = ws.get_Range("A" + Convert.ToString(++countRow + ROW_START), "A" + Convert.ToString(countRow + ROW_START));
                        rg.EntireRow.Select();
                        rg.EntireRow.Insert(Excel.XlDirection.xlDown);
                        rg = ws.get_Range("A" + Convert.ToString(countRow + ROW_START - 1), "A" + Convert.ToString(countRow + ROW_START - 1));
                        //rg.EntireRow.Select();
                        //rg.EntireRow.Copy(Type.Missing);
                        //rg.EntireRow.PasteSpecial(Excel.XlPasteType.xlPasteAll,Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone,Type.Missing,Type.Missing);
                    }
                }
                rg = ((Excel.Range)ws.get_Range(ws.Cells[ROW_START, COLUMN_START], ws.Cells[dr.Length + ROW_START - 1, dr[0].ItemArray.Length + COLUMN_START - 1]));
                rg.Select();
                rg.Value2 = arrData;
                //End of Exporting
                app.Visible = true;
            }
            catch (Exception ex)
            {
                app.Workbooks.Close();
                app = null;
                HPA.Common.Helper.ShowException(ex, "ExportToExcel()", null);
                return;
            }
        }
        private void ExportToExcel(System.Data.DataSet ds)
        {
            string m_strTemplateFile = "";
            //string docTemplate;
            //if export to word document then get fix templates name and path
            if (strExtend.Equals(XLS))
                m_strTemplateFile = string.Format(@"{0}\{1}\{2}",Application.StartupPath ,TEMPLATES, txtExcelFileName.Text);
            else
            {
                //docTemplate = Application.StartupPath + @"\TEMPLATES\" + txtExcelFileName.Text;
                m_strTemplateFile = string.Format(@"{0}\{1}\{2}",Application.StartupPath,TEMPLATES,MergerData);
                xbeFileName.EditValue = m_strTemplateFile;
                ckbWithoutTemp.Checked = true;
                if (System.IO.File.Exists(m_strTemplateFile))
                {
                    System.IO.File.Delete(m_strTemplateFile);
                }
            }
            if (txtExcelFileName.Text.Equals("CompanyWorkSheet.xls"))
            {
                ExportSummaryAttdanceData(ds.Tables[0]);
                return;
            }else
                //if (txtExcelFileName.Text.Contains("SalaryToBank")) 
                {
                    ExportSalaryToBank(ds);
                    return;
                }
            //excelapp.Application.Workbooks.Add(true);
            string m_strFileName = "da";
            //initialize for controls
            this.Cursor = Cursors.WaitCursor;
            btnExport.Enabled = false;
            xpbProcecess.Properties.Step = 1;
            xpbProcecess.Properties.Minimum = 0;
            xpbProcecess.Properties.Maximum = ds.Tables[0].Rows.Count;
            xpbProcecess.Position = 0;
            xpbProcecess.Properties.ShowTitle = true;


                //app = new Excel.Application();
                try
                {
                    //Create file result
                    
                    if (ckbWithoutTemp.Checked)
                    {
                        ExportToExcelWithoutTemp(m_strFileName, ds.Tables[0]);
                    }
                    else
                    {

                        Excel.Workbooks workbooks;
                        Excel._Workbook wb;
                        workbooks = app.Workbooks;
                        wb = workbooks.Add(m_strTemplateFile);
                        Excel.Sheets exSheets = wb.Worksheets;
                        Excel._Worksheet ws;
                        Excel.Range rg;

                        ws = (Excel._Worksheet)exSheets.get_Item(1);
                        ws.Select(1);

                        //Start Exporting data to Excel file, row by row
                        int ROW_START = Convert.ToInt32(txtStartRow.Text);
                        int COLUMN_START = Convert.ToInt32(txtStartColumn.Text);
                        if (ckbIncludedColumnName.Checked)
                        {
                            // export Header
                            for (int i = COLUMN_START; i < ds.Tables[0].Columns.Count + COLUMN_START; i++)
                            {
                                ((Excel.Range)ws.Cells[ROW_START, i]).Value2 = ds.Tables[0].Columns[i - COLUMN_START].Caption;
                                ((Excel.Range)ws.Cells[ROW_START, i]).Interior.ColorIndex = 15;
                                ((Excel.Range)ws.Cells[ROW_START, i]).Font.Bold = true;
                            }
                            ROW_START++;
                        }
                        int countRow = 0;
                        // export condition
                        if ((cellLocation != null) && (cellLocation.Length > 0))
                        {
                            int ic = 0;
                            foreach (System.Windows.Forms.Control ctrl in grbFilter.Controls)
                            {
                                if (ctrl is Label) { }
                                else if (ctrl is DevExpress.XtraEditors.DateEdit)
                                {
                                    ((Excel.Range)ws.Cells[1, ++ic]).Value2 = ((DevExpress.XtraEditors.DateEdit)ctrl).EditValue;
                                }
                                else
                                {
                                    ((Excel.Range)ws.Cells[1, ++ic]).Value2 = ctrl.Text;
                                }
                            }
                            //						for(int i = 0; i< grbFilter.Controls.Count/2; i++)
                            //						{
                            //							if((cellLocation[1,i]==null) || (cellLocation[1,i].Equals("")))
                            //								continue;
                            //							else
                            //							{
                            //								int row = Convert.ToInt32(cellLocation[1,i].Split(',')[0]);
                            //								int column = Convert.ToInt32(cellLocation[1,i].Split(',')[1]);
                            //								if(radWithLable.Checked)
                            //								{
                            //									// write lable
                            //									((Excel.Range)ws.Cells[row,column]).Value2 = cellLocation[0,i];
                            //									// Write value
                            //									((Excel.Range)ws.Cells[row,column+1]).Value2 = cellLocation[2,i];
                            //								}
                            //								else
                            //								{
                            //									((Excel.Range)ws.Cells[row,column]).Value2 = cellLocation[2,i];
                            //								}
                            //								
                            //							}
                            //						}
                        }
                        // insert excel row
                        DataTable dt = ds.Tables[0];
                        //THIENLONG BAO LOI KHI KHONG CO DU LIEU NAO


                        //if (dt.Rows.Count > 0)
                        //{
                        object[,] arrData = new object[dt.Rows.Count, dt.Columns.Count];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                if (dt.Rows[i][j] != DBNull.Value)
                                    if (!ckbToneMarks.Checked)
                                        arrData[i, j] = dt.Rows[i][j].ToString();
                                    else
                                    {
                                        arrData[i, j] =  Methods.RemoveToneMarks(dt.Rows[i][j].ToString());
                                    }
                            }
                            if (dt.Rows.Count > countRow + 2)
                            {
                                rg = ws.get_Range("A" + Convert.ToString(++countRow + ROW_START), "A" + Convert.ToString(countRow + ROW_START));
                                rg.EntireRow.Select();
                                rg.EntireRow.Insert(Excel.XlDirection.xlDown);
                                rg = ws.get_Range("A" + Convert.ToString(countRow + ROW_START - 1), "A" + Convert.ToString(countRow + ROW_START - 1));
                                //rg.EntireRow.Select();
                                //rg.EntireRow.Copy(Type.Missing);
                                //rg.EntireRow.PasteSpecial(Excel.XlPasteType.xlPasteAll,Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone,Type.Missing,Type.Missing);
                            }
                            xpbProcecess.Increment(1);
                            xpbProcecess.Update();
                        }
                        rg = ((Excel.Range)ws.get_Range(ws.Cells[ROW_START, COLUMN_START], ws.Cells[dt.Rows.Count + ROW_START - 1, dt.Columns.Count + COLUMN_START - 1]));
                        rg.Select();
                        rg.Value2 = arrData;
                        if (ds.Tables.Count > 1)
                        {
                            ROW_START = ROW_START + dt.Rows.Count;
                            DataTable dt2 = ds.Tables[1];
                            arrData = new object[dt2.Rows.Count, dt2.Columns.Count];
                            for (int i = 0; i < dt2.Rows.Count; i++)
                            {
                                for (int j = 0; j < dt2.Columns.Count; j++)
                                {
                                    if (dt2.Rows[i][j] != DBNull.Value)
                                        if (!ckbToneMarks.Checked)
                                            arrData[i, j] = dt2.Rows[i][j].ToString();
                                        else
                                        {
                                            arrData[i, j] = Methods.RemoveToneMarks(dt2.Rows[i][j].ToString());
                                        }
                                }
                                if (dt2.Rows.Count > countRow + 2)
                                {
                                    rg = ws.get_Range("A" + Convert.ToString(++countRow + ROW_START), "A" + Convert.ToString(countRow + ROW_START));
                                    rg.EntireRow.Select();
                                    rg.EntireRow.Insert(Excel.XlDirection.xlDown);
                                    rg = ws.get_Range("A" + Convert.ToString(countRow + ROW_START - 1), "A" + Convert.ToString(countRow + ROW_START - 1));
                                    //rg.EntireRow.Select();
                                    //rg.EntireRow.Copy(Type.Missing);
                                    //rg.EntireRow.PasteSpecial(Excel.XlPasteType.xlPasteAll,Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone,Type.Missing,Type.Missing);
                                }
                                xpbProcecess.Increment(1);
                                xpbProcecess.Update();
                            }
                            rg = ((Excel.Range)ws.get_Range(ws.Cells[ROW_START, COLUMN_START], ws.Cells[dt2.Rows.Count + ROW_START - 1, dt2.Columns.Count + COLUMN_START - 1]));
                            rg.Select();
                            rg.Value2 = arrData;
                            rg.Rows.Hidden = true;
                        }
                        //End of Exporting
                        this.Cursor = Cursors.Default;
                        app.Visible = true;
                        btnFWClose.Focus();
                        btnExport.Enabled = true;
                        //  }
                        releaseObject(exSheets);
                        releaseObject(wb);
                        releaseObject(rg);
                        releaseObject(workbooks);
                        releaseObject(ws);
                        releaseObject(app);

                    }
                }
                catch (Exception ex)
                {
                    app.Workbooks.Close();
                    app = null;
                    this.Cursor = Cursors.Default;
                    HPA.Common.Helper.ShowException(ex, this.Name + ".btnProcess_Click()", null);
                    return;
                }
            
        }

        private void ExportSalaryToBank(DataSet ds)
        {
            byte sheetCount = 0;
            string m_strTemplateFile = Application.StartupPath + @"\TEMPLATES\" + txtExcelFileName.Text;
            //excelapp.Application.Workbooks.Add(true);
            string m_strFileName = xbeFileName.Text;
            Excel.Application app = new Excel.Application();
            Excel.Workbooks workbooks;
            Excel._Workbook wb;
            workbooks = app.Workbooks;
            wb = workbooks.Add(m_strTemplateFile);
            Excel.Sheets exSheets = wb.Worksheets;
            Excel._Worksheet ws;
            Excel.Range rg;
            ws = (Excel._Worksheet)exSheets.get_Item(1);
            rg = ws.get_Range("A1","B1");
            //initialize for controls
            int totalRowDatCount = 0;
            foreach (DataTable dtData in ds.Tables)
            {
                totalRowDatCount += dtData.Rows.Count;
            }
            xpbProcecess.Properties.Minimum = 0;
            xpbProcecess.Properties.Maximum = totalRowDatCount;
            xpbProcecess.Position = 0;
            xpbProcecess.Reset();
            xpbProcecess.ResetText();
            xpbProcecess.Update();
            foreach (DataTable dtData in ds.Tables)
            {
                sheetCount++;
                try
                {
                    ws = (Excel._Worksheet)wb.Sheets[sheetCount];
                    ws = (Excel._Worksheet)exSheets.get_Item(sheetCount);
                    ws.Select(Type.Missing);
                    //Start Exporting data to Excel file, row by row
                    int ROW_START = Convert.ToInt32(txtStartRow.Text);
                    int COLUMN_START = Convert.ToInt32(txtStartColumn.Text);
                    int countRow = 0;
                    if ((cellLocation != null) && (cellLocation.Length > 0))
                    {
                        int ic = 0;
                        foreach (System.Windows.Forms.Control ctrl in grbFilter.Controls)
                        {
                            if (ctrl is Label) { }
                            else if (ctrl is DevExpress.XtraEditors.DateEdit)
                            {
                                ((Excel.Range)ws.Cells[1, ++ic]).Value2 = ((DevExpress.XtraEditors.DateEdit)ctrl).EditValue;
                            }
                            else
                            {
                                ((Excel.Range)ws.Cells[1, ++ic]).Value2 = ctrl.Text;
                            }
                        }
                    }
                    
                    
                    // insert excel row
                    object[,] arrData = new object[dtData.Rows.Count, dtData.Columns.Count];
                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        for (int j = 0; j < dtData.Columns.Count; j++)
                        {
                            if (dtData.Rows[i][j] != DBNull.Value)
                                arrData[i, j] = dtData.Rows[i][j].ToString();
                        }
                        if (dtData.Rows.Count > countRow + 2)
                        {
                            rg = ws.get_Range("A" + Convert.ToString(++countRow + ROW_START), "A" + Convert.ToString(countRow + ROW_START));
                            rg.EntireRow.Select();
                            rg.EntireRow.Insert(Excel.XlDirection.xlDown);
                            rg = ws.get_Range("A" + Convert.ToString(countRow + ROW_START - 1), "A" + Convert.ToString(countRow + ROW_START - 1));
                            rg.EntireRow.Select();
                            rg.EntireRow.Copy(Type.Missing);
                            rg = ws.get_Range("A" + Convert.ToString(countRow + ROW_START), "A" + Convert.ToString(countRow + ROW_START));
                            rg.EntireRow.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, Type.Missing, Type.Missing);
                        }
                        xpbProcecess.Increment(1);
                        xpbProcecess.Update();
                    }
                    rg = ((Excel.Range)ws.get_Range(ws.Cells[ROW_START, COLUMN_START], ws.Cells[dtData.Rows.Count + ROW_START - 1, dtData.Columns.Count + COLUMN_START - 1]));
                    rg.Select();
                    rg.Value2 = arrData;
                }
                catch (Exception ex)
                {
                    app.Workbooks.Close();
                    app = null;
                    HPA.Common.Helper.ShowException(ex, "ExportToExcel()", null);
                    return;
                }
                //End of Exporting
            }

            app.Visible = true;
            ws = (Excel._Worksheet)wb.Sheets[1];
            ws = (Excel._Worksheet)exSheets.get_Item(1);
            ws.Select(Type.Missing);
            // Release Object
            releaseObject(exSheets);
            releaseObject(wb);
            releaseObject(rg);
            releaseObject(workbooks);
            releaseObject(ws);
            releaseObject(app);
        }
        /// <summary>
        /// Export to excel as Kobelco requested
        /// </summary>
        private void ExportSummaryAttdanceData(DataTable dtData)
        {
            string m_strTemplateFile = String.Format(@"{0}\TEMPLATES\{1}", Application.StartupPath, txtExcelFileName.Text);
            //excelapp.Application.Workbooks.Add(true);
            string m_strFileName = xbeFileName.Text;
            //initialize for controls
           
            Excel.Application app = new Excel.Application();
            try
            {
                Excel.Workbooks workbooks;
                Excel._Workbook wb;
                workbooks = app.Workbooks;
                wb = workbooks.Add(m_strTemplateFile);         
                Excel.Sheets exSheets = wb.Worksheets;

                Excel._Worksheet ws;
                Excel.Range rg;

                ws = (Excel._Worksheet)exSheets.get_Item(1);
                ws.Select(1);
                //Start Exporting data to Excel file, row by row
                int ROW_START = Convert.ToInt32(txtStartRow.Text);
                int COLUMN_START = Convert.ToInt32(txtStartColumn.Text);
                int countRow = 0;
                int countColumns = 0;
                if ((cellLocation != null) && (cellLocation.Length > 0))
                {
                    int ic = 0;
                    foreach (System.Windows.Forms.Control ctrl in grbFilter.Controls)
                    {
                        if (ctrl is Label) { }
                        else if (ctrl is DevExpress.XtraEditors.DateEdit)
                        {
                            ((Excel.Range)ws.Cells[1, ++ic]).Value2 = ((DevExpress.XtraEditors.DateEdit)ctrl).EditValue;
                        }
                        else
                        {
                            ((Excel.Range)ws.Cells[1, ++ic]).Value2 = ctrl.Text;
                        }
                    }
                }
                // export Header
                for (int i = COLUMN_START; i < dtData.Columns.Count + COLUMN_START; i++)
                {
                    ((Excel.Range)ws.Cells[ROW_START, i]).Value2 = dtData.Columns[i - COLUMN_START].Caption;
                    ((Excel.Range)ws.Cells[ROW_START, i]).Interior.ColorIndex = 28;
                    ((Excel.Range)ws.Cells[ROW_START, i]).Font.Bold = true;
                    xpbProcecess.Increment(1);
                    xpbProcecess.Update();
                }
                ROW_START++;
                xpbProcecess.Reset();
                // insert excel row
                object[,] arrData = new object[dtData.Rows.Count, dtData.Columns.Count];
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    for (int j = 0; j < dtData.Columns.Count; j++)
                    {
                        if (dtData.Rows[i][j] != DBNull.Value)
                            arrData[i, j] = dtData.Rows[i][j].ToString();
                    }
                    if (dtData.Rows.Count> countRow + 2)
                    {
                        rg = ws.get_Range("A" + Convert.ToString(++countRow + ROW_START), "A" + Convert.ToString(countRow + ROW_START));
                        rg.EntireRow.Select();
                        rg.EntireRow.Insert(Excel.XlDirection.xlDown);
                        rg = ws.get_Range("A" + Convert.ToString(countRow + ROW_START - 1), "A" + Convert.ToString(countRow + ROW_START - 1));
                        //rg.EntireRow.Select();
                        //rg.EntireRow.Copy(Type.Missing);
                        //rg.EntireRow.PasteSpecial(Excel.XlPasteType.xlPasteAll,Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone,Type.Missing,Type.Missing);
                    }
                    xpbProcecess.Increment(1);
                    xpbProcecess.Update();
                }
                rg = ((Excel.Range)ws.get_Range(ws.Cells[ROW_START, COLUMN_START], ws.Cells[dtData.Rows.Count + ROW_START - 1, dtData.Columns.Count + COLUMN_START - 1]));
                rg.Select();
                rg.Value2 = arrData;
                //To mau cot
                // Tim ngay chu nhat de to mau
                //Duyet tung cot trong data table de tim cot ngay chu nhat
                foreach (DataColumn dcSun in dtData.Columns)
                {
                    countColumns++;
                    DateTime dtSunday;
                    string a = paramValue[0].ToString();
                    if (DAY_IN_MONTH.Contains(dcSun.Caption))
                    {
                        dtSunday = Convert.ToDateTime(string.Format("{0} - {1} - {2}", paramValue[0].ToString(), paramValue[1].ToString(), dcSun.Caption));
                        //Kiem tra xem co phai ngay chu nhat ko
                        if(SUNDAY.Equals(dtSunday.DayOfWeek.ToString()))
                        {
                            //To mau ngay chu nhat
                            rg = ((Excel.Range)ws.get_Range(ws.Cells[ROW_START, COLUMN_START - 1 + countColumns], ws.Cells[dtData.Rows.Count + ROW_START - 1, COLUMN_START - 1 + countColumns]));
                            rg.Select();
                            rg.Interior.ColorIndex = 4;
                        }
                    }
                }
                //Xoa STT cuoi cung
                rg = ((Excel.Range)ws.get_Range(ws.Cells[dtData.Rows.Count + ROW_START - 1, COLUMN_START], ws.Cells[dtData.Rows.Count + ROW_START - 1, COLUMN_START]));
                rg.Value2 = null;
                //rg.Delete(Type.Missing);
                //Merge total summary row
                rg = ((Excel.Range)ws.get_Range(ws.Cells[dtData.Rows.Count + ROW_START - 1, COLUMN_START], ws.Cells[dtData.Rows.Count + ROW_START - 1, COLUMN_START - 13 + countColumns]));
                rg.Select();
                rg.Merge(Type.Missing);
                //End of Exporting
                
                app.Visible = true;

                // Release Object
                releaseObject(exSheets);
                releaseObject(wb);
                releaseObject(rg);
                releaseObject(workbooks);
                releaseObject(ws);
                releaseObject(app);
            }
            catch (Exception ex)
            {
                app.Workbooks.Close();
                app = null;
                HPA.Common.Helper.ShowException(ex, "ExportToExcel()", null);
                return;
            }
        }
        private void ExportToCSV(System.Data.DataTable dt)
        {
            string fileName = xbeFileName.Text;
            this.Cursor = Cursors.WaitCursor;
            btnExport.Enabled = false;
            xpbProcecess.Properties.Step = 1;
            xpbProcecess.Properties.Minimum = 0;
            xpbProcecess.Properties.Maximum = dt.Rows.Count;
            xpbProcecess.Position = 0;
            xpbProcecess.Properties.ShowTitle = true;

            string csvLine = "";
            string csvData = string.Empty;
            const string NewLine = "\r\n";
            foreach (DataRow drExport in dt.Rows)
            {
                csvLine = string.Empty;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    csvLine += "," + drExport[i].ToString().Replace(',', '_');
                }
                csvData += csvLine.Substring(1) + NewLine;
                // update progress
                xpbProcecess.Increment(1);
                xpbProcecess.Update();
            }
            // write to file
            if (ckbToneMarks.Checked)
            {
                csvData = Methods.RemoveToneMarks(csvData);
            }
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName);
            sw.Write(csvData);
            sw.Close();
            UIMessage.ShowMessage(string.Format("DATA_EXPORTED_FILE", fileName), MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Cursor = Cursors.Default;
            btnExport.Enabled = true;
        }
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        //private void btnAdvanceView_Click(object sender, EventArgs e)
        //{
        //     validate data
        //    if (!ValidateInput())
        //    {
        //        return;
        //    }
        //     get parameter values
        //    paramValue = new string[grbFilter.Controls.Count / 2];
        //    paramName = new string[grbFilter.Controls.Count / 2];
        //    int count = 0;
        //    foreach (Control ctr in grbFilter.Controls)
        //    {
        //        if (ctr is Label)
        //        {
        //             do nothing
        //        }
        //        else
        //        {
        //            try
        //            {
        //                get values
        //                switch (ctr.Name.Substring(0, 3))
        //                {
        //                    case TXT_PREFIX:
        //                        {
        //                            TextBox txt = ctr as TextBox;
        //                            paramName[count] = txt.Name.Substring(3);
        //                            paramValue[count] = txt.Text;
        //                            break;
        //                        }
        //                    case CBX_PREFIX:
        //                        {
        //                            DevExpress.XtraEditors.LookUpEdit cbx = (DevExpress.XtraEditors.LookUpEdit)ctr;
        //                            paramName[count] = cbx.Name.Substring(3);
        //                            paramValue[count] = cbx.EditValue.ToString();
        //                            break;
        //                        }
        //                    case DTP_PREFIX:
        //                        {
        //                            DateEdit dtp = ctr as DateEdit;
        //                            paramName[count] = dtp.Name.Substring(3);
        //                            paramValue[count] = dtp.EditValue.ToString();
        //                            break;
        //                        }
        //                    default:
        //                        {
        //                            break;
        //                        }
        //                }

        //                count++;
        //            }
        //            catch (Exception ex)
        //            {
        //                UIMessage.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //        }
        //    }
        //    InputConditionValue();
        //    byte index = 0;
        //    if (!txtExportType.Text.Trim().ToLower().Equals(EXPORT_TYPE))
        //    {
        //        object[] param = new object[grbFilter.Controls.Count + 2];
        //        for (byte i = 0; i < paramName.Length; i++)
        //        {
        //            param[index++] = paramName[i];
        //            param[index++] = paramValue[i];
        //        }
        //        add loginID parameter
        //        param[index++] = CommonConst.A_LoginID;
        //        param[index++] = UserID;
        //         get data from SQL and export to excell
        //        DataTable dtExport = DBEngine.execReturnDataTable(strSPName, param);
        //        MessageBox.Show(dtExport.Rows.Count.ToString());
        //        AdvangeView advView = new AdvangeView(dtExport, ckbToneMarks, xbeFileName.Text, ckbCSV.Checked);
        //        advView.ShowDialog();
        //    }
        //}

        private void radAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radAll.Checked)
            {
                dtReportList.DefaultView.RowFilter = null;
            }
        }

        private void grvExportList_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            
        }

        private void grvExportList_Click(object sender, EventArgs e)
        {
            xbeFileName.Text = "";
            this.xpbProcecess.Position = 0;
            try
            {
                
                int height = 0;
                strSPName = grvExportList.GetDataRow(grvExportList.GetSelectedRows()[0])["ProcedureName"].ToString();
                //Generalte Filter Condition 
                grbFilter.Controls.Clear();
                DataTable dtParameter = GetParameter(strSPName);
                if ((dtParameter != null) && (dtParameter.Rows.Count <= 0))
                    grbFilter.Visible = false;
                else
                {
                    cellLocation = new string[3, dtParameter.Rows.Count];// frist used for Name, second used for Location and third used for Value
                    int index = 0;
                    grbFilter.Visible = true;
                    grbFilter.Height = 30;
                    //generate filter condition
                    foreach (DataRow dr in dtParameter.Rows)
                    {
                        //cut lose @LoginID
                        if (dr[P_NAME].ToString().ToLower().Equals(CommonConst.A_LoginID.ToLower()))
                            continue;
                        height += 25;
                        grbFilter.Height += 25;
                        // set lable
                        Label lbl = new Label();
                        lbl.Name = LBL_PREFIX + dr[P_NAME].ToString();
                        lbl.Text = dr[Message_P].ToString();
                        cellLocation[0, index] = lbl.Text;
                        cellLocation[1, index] = dr[CellLocation].ToString();
                        cellLocation[2, index++] = dr[P_NAME].ToString();
                        grbFilter.Controls.Add(lbl);
                        lbl.Location = new System.Drawing.Point(10, height);
                        // set input control
                        switch (dr[DataType].ToString().ToLower())
                        {
                            case "dropdownlist":
                                {
                                    if (dr[P_NAME].ToString().ToLower() == CommonConst.A_EmployeeID.ToLower())
                                    {
                                        ShowEmployeeList(new System.Drawing.Point(130, height), dr[P_NAME].ToString());
                                        break;
                                    }
                                    // create combobox for this once
                                    DevExpress.XtraEditors.LookUpEdit cbx = new DevExpress.XtraEditors.LookUpEdit();
                                    cbx.Name = CBX_PREFIX + dr[P_NAME].ToString();
                                    // set data source
                                    AddDataSource(ref cbx, DBEngine.execReturnDataTable(dr[Query].ToString(), CommonConst.A_LoginID, UserID));
                                    // if the control is month or year list, so set theo current month and year
                                    if (cbx.Name.ToLower().Contains("month"))
                                    {
                                        dtInitValue = DBEngine.execReturnDataTable("select * from tblCurrentWorkingMonth");
                                        cbx.EditValue = dtInitValue.Rows[0]["Month"];
                                    }
                                    if (cbx.Name.ToLower().Contains("year"))
                                    {
                                        dtInitValue = DBEngine.execReturnDataTable("select * from tblCurrentWorkingMonth");
                                        cbx.EditValue = dtInitValue.Rows[0]["Year"];
                                    }
                                    if (cbx.Name.ToLower().Contains("currency"))
                                    {
                                        cbx.EditValue = "VND";
                                    }
                                    grbFilter.Controls.Add(cbx);
                                    cbx.Location = new System.Drawing.Point(130, height);
                                    cbx.Width = 200;
                                    cbx.BringToFront();
                                    break;
                                }
                            case "number":
                            case "int":
                            case "smallint":
                            case "tinyint":
                            case "money":
                                {
                                    // Create textbox and set read number only
                                    TextBox txt = new TextBox();
                                    txt.Name = TXT_PREFIX + dr[P_NAME].ToString();
                                    txt.Location = new System.Drawing.Point(130, height);
                                    txt.Width = 200;
                                    txt.BringToFront();
                                    //set read number only
                                    txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
                                    grbFilter.Controls.Add(txt);
                                    break;
                                }
                            case "datetime":
                            case "smalldatetime":
                                {
                                    // Create datetimepicker
                                    DevExpress.XtraEditors.DateEdit dtp = new DateEdit();
                                    dtp.Name = DTP_PREFIX + dr[P_NAME].ToString();
                                    dtp.Location = new System.Drawing.Point(130, height);
                                    dtp.Width = 200;
                                    dtp.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
                                    dtp.Properties.LookAndFeel.SkinName = "Blue";
                                    dtp.Properties.Mask.EditMask = "dd/MM/yyyy";
                                    dtp.Properties.Mask.UseMaskAsDisplayFormat = true;
                                    grbFilter.Controls.Add(dtp);
                                    break;
                                }
                            default:
                                {
                                    // Create textbox and set read number only
                                    TextBox txt = new TextBox();
                                    txt.Name = TXT_PREFIX + dr[P_NAME].ToString();
                                    txt.Location = new System.Drawing.Point(130, height);
                                    txt.Width = 200;
                                    txt.BringToFront();
                                    grbFilter.Controls.Add(txt);
                                    // textbox here
                                    break;
                                }
                        }
                    }

                }
                // enable export button
                btnExport.Enabled = true;
                if (txtExportType.Text.Trim().ToLower().Equals(EXPORT_TYPE))
                {
                    ShowHideControl(false);
                }
                else
                {
                    strExtend = txtExcelFileName.Text.Substring(txtExcelFileName.Text.Length - 3, 3);
                    if (strExtend.ToLower().Equals(XLS))
                        ShowHideControl(true);
                    else
                        ShowHideControl(false);
                }
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "grvExportList_Click");
            }
        }
        private void ShowHideControl(bool isShow)
        {
            if (!isShow)
            {
                grbFileName.Visible = false;
                grbExportOption.Visible = false;
            }
            else
            {
                grbExportOption.Visible = true;
                grbFileName.Visible = true;
            }
        }
        private void ShowEmployeeList(Point point, string ctrName)
        {
            TextBox txt = new TextBox();
            txt.Name = TXT_PREFIX + ctrName;
            txt.Location = point;
            txt.Width = 60;
            txt.BackColor = SystemColors.Info;
            txt.Leave += new EventHandler(txt_Leave);
            txt.KeyUp += new KeyEventHandler(txt_KeyUp);
            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Name = LBL_PREFIX + txt.Name;
            lbl.Location = new Point(txt.Location.X + 65, txt.Location.Y + 4);
            grbFilter.Controls.Add(txt);
            grbFilter.Controls.Add(lbl);
        }

        void txt_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            Control[] lblctr = grbFilter.Controls.Find(LBL_PREFIX + txt.Name, true);
            Label lbl = (Label)lblctr[0];
            if (e.KeyCode == Keys.F3)
            {
                try
                {
                    // show employeeID list
                    object obj;

                    EmployeeIDList employeeList = new EmployeeIDList();
                    OpenObject("HPA.CommonForm", "EmployeeIDList", true, null, out obj);
                    txt.Text = ((string[])obj)[0];
                    lbl.Text = ((string[])obj)[1];
                }
                catch (Exception ex)
                {
                    HPA.Common.Helper.ShowException(ex, this.Name, "txtEmployeeID_KeyUp");
                    return;
                }
            }
        }

        void txt_Leave(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            Control []lblctr = grbFilter.Controls.Find(LBL_PREFIX + txt.Name,true);
            Label lbl = (Label)lblctr[0];
            if (!txt.Text.Trim().Equals(""))
            {
                DataTable dtFullName = DBEngine.execReturnDataTable("sp_hr_get_fullname", CommonConst.A_EmployeeID, txt.Text, CommonConst.A_LoginID, UserID);
                if (dtFullName != null && dtFullName.Rows.Count > 0)
                {
                    lbl.Text = dtFullName.Rows[0][0].ToString();
                }
                else
                {
                    UIMessage.ShowMessage(CommonConst.EmployeeNotExists, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt.SelectAll();
                    txt.Focus();
                }
            }
        }
        public Boolean FileOpened(String duongdan)
        {
            try
            {
                if (duongdan != "")
                {
                    System.IO.File.Delete(duongdan);
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return true;
            }

        }

     

        private void txtLastName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string strFilter = string.Format("DescriptionEN like '%{0}%'", StandardName.TitleCase(Common.Methods.RemoveToneMarks(txtLastName.Text.Trim())));
                dtReportList.DefaultView.RowFilter = strFilter;
                grdExportList.Refresh();
                grvExportList.RefreshData();
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.LogError(ex, ex.Message, "txtLastName_EditValueChanged");
            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally { GC.Collect(); }


        }

        
        private void pnlInformation_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
        }

        private void pnlInformation_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}