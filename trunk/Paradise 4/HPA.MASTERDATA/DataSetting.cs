using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HPA.Common;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;

namespace HPA.MasterData
{
    public partial class DataSetting : HPA.Component.Framework.CCommonForm
    {
        int Month = 0;
        int Year = 0;
        DataTable tblInfo = null;
        private DataTable m_dtPrimaryKeys;
        private DataTable m_dtTableData;
        private DataTable m_dtColumnsName_Org;
        private DataTable dt_OldValue;
        private DataTable m_dtColumnsName;
        private DataTable dtParameter;
        private DataTable dtInitValue;
        string strFilter = string.Empty;
        private string tableName = "";
        private string strViewName = "";
        private bool isAllowAdd = true;
        private bool isNoUpdate = true;
        private bool IsShowLayout = false;
        private bool isReadOnly = false;
        private bool isShowCheckAllBtn = false;
        private bool isContainModifedColumn = false;
        private bool IsProcedure = false;
        private bool IsProcessForm = false;
        private string[] strColumnReadOnly = { "" };
        private string[] strColumnCombobox = { "" };
        private string[] strColumnFormatFont;
        private string[] strColumnPaint;
        private string[] strPaintRows;
        private string[] strColumnOrderBy;
        private string[] strColumnHide;
        private string[] strGroupColumns;
        private string[] strColumnFixed;
        private string[,] cellLocation;
        private string[] paramValue;
        private string[] paramName;
        DXValidationProvider dxValidationProvider1;
        #region Const
        private const string P_NAME = "Name";
        private const string LBL_PREFIX = "lbl";
        private const string DTP_PREFIX = "dtp";
        private const string CKB_PREFIX = "ckb";
        private const string TXT_PREFIX = "txt";
        private const string CBX_PREFIX = "cbx";
        private const string CellLocation = "CellLocation";
        private const string DataType = "DataType";
        private const string Message_P = "Message";

        // Data type
        private const string strDATETIME = "datetime";
        private const string strINT = "int";
        private const string strMONEY = "money";
        private const string strBIGINT = "bigint";
        private const string strSMALLMONEY = "smallmoney";
        private const string strIMAGE = "image";

        private const string strSMALLINT = "smallint";
        private const string strTINYINT = "tinyint";
        private const string strDecimal = "decimal";
        private const string strREAL = "real";
        private const string strFLOAT = "float";
        private const string strNUMERIC = "numeric";
        // data columns name
        private const string NAME = "name";
        private const string Query = "Query";
        private const string ColumnOrderBy = "ColumnOrderBy";
        private const string ColumnHide = "ColumnHide";
        private const string GroupColumns = "GroupColumns";
        private const string FixedColumns = "FixedColumns";
        private const string ASSEMBLY_NAME = "DataSetting";

        #endregion

        public DataSetting()
        {
            InitializeComponent();
            //// set lable
            
        }
        public override bool InitializeData()
        {
            try
            {
                // set lable
                Control.ControlCollection ctrls = this.Controls;
                UIMessage.LoadLableName(ref ctrls);
                LoadDataAndShow();
                btnCheckAll.Visible = isShowCheckAllBtn;

                if (IsProcessForm)
                {
                    ChuaTimKiemVaGrid.Visible = false;
                    this.Controls.Add(btnReload);
                    this.Controls.Add(grbFilter);
                    grbFilter.Width += 30;
                    btnReload.Text = UIMessage.Get_Message("btnProcess");
                    btnReload.Size = new Size(128, 64);
                    btnReload.Location = new Point(grbFilter.Location.X + (grbFilter.Size.Width - 128) / 2, grbFilter.Location.Y + grbFilter.Height +25);
                    btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    
                }
                if (IsShowLayout)
                {
                    //Generate control by grid list
                    GenerateLayoutControlByList();
                    //Binding data
                    BindingDataToControl(splitContainer1.Panel1);
                }
                else
                {
                    splitContainer1.Panel1Collapsed = true;
                    btnDesignForm.Visible = false;
                }
                HPA.Common.FocusControlsIndicator fc = new FocusControlsIndicator();
                fc.LoadAddGotFocus(this);
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".InitializeData()", null);
                return false;
            }

            return true;
        }

        private void BindingDataToControl(Control parentControls)
        {
            try
            {
                foreach(Control ctrBind in parentControls.Controls){
                    if (ctrBind.Controls.Count > 0)
                    {
                        BindingDataToControl(ctrBind);
                    }
                    if(!(ctrBind is Label) && !(ctrBind is LabelControl))
                    if (m_dtTableData.Columns.Contains(ctrBind.Name.Substring(3)))
                    {
                        ctrBind.DataBindings.Clear();
                        ctrBind.DataBindings.Add(CommonConst.EDIT_VALUE, m_dtTableData, ctrBind.Name.Substring(3));
                    }
                }
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.LogError(ex, ex.Message, "BindingDataToControl");
            }
        }

        private void GenerateLayoutControlByList()
        {
            try
            {
                LayOutControlHelper.LoadControlsLayOut(ref splitContainer1, this.Name);
                dxValidationProvider1 = LayOutControlHelper.dxValidationProvider1;
                dxValidationProvider1.Validate();
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.LogError(ex, this.Text, ex.Message);
            }
        }

        private string MakeLoadAllDataQuery(string tblName)
        {
            return string.Format("Select * from {0}", tblName);
        }
        private void ShowEmployeeList(Point point, string ctrName)
        {
            TextBox txt = new TextBox() { Name = TXT_PREFIX + ctrName, Location = point, Width = 60, BackColor = SystemColors.Info };
            txt.Leave += new EventHandler(txt_Leave);
            txt.KeyUp += new KeyEventHandler(txt_KeyUp);
            Label lbl = new Label() { AutoSize = true, Name = LBL_PREFIX + txt.Name, Location = new Point(txt.Location.X + 65, txt.Location.Y + 4) };
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
            Control[] lblctr = grbFilter.Controls.Find(LBL_PREFIX + txt.Name, true);
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
        private void AddDataSource(ref LookUpEdit le, DataTable dt)
        {
            le.Properties.Columns.Clear();
            le.Properties.DataSource = dt;
            const Int32 width = 125;
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
                le.Properties.DisplayMember = dt.Columns[0].Caption;
                // get the first rows
                le.EditValue = dt.Rows[0][0].ToString();//DataBindings.Add("EditValue", dt,dt.Columns[0].Caption);
            }

        }
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        private void LoadDataAndShow()
        {
            try
            {
                tableName = this.UserName.ToString();
                tblInfo = DBEngine.execReturnDataTable(string.Format("select * from tblDataSetting where TableName = '{0}'", this.UserName));
                if (tblInfo != null && tblInfo.Rows.Count > 0)
                {
                    //Load Primary keys
                    if (!tblInfo.Rows[0]["TableEditorName"].ToString().Equals(string.Empty))
                        this.UserName = tblInfo.Rows[0]["TableEditorName"].ToString().Split('|')[0];
                    //m_dtPrimaryKeys = DBEngine.execReturnDataTable("sp_TableEditor_GetPrimaryKeys", "@Tablename", this.UserName.ToString());
                    strViewName = tblInfo.Rows[0]["ViewName"].ToString();
                    if (tblInfo.Rows[0]["IsShowLayout"] != DBNull.Value)
                        IsShowLayout = Convert.ToBoolean(tblInfo.Rows[0]["IsShowLayout"]);
                    else
                        IsShowLayout = false;
                    
                    if (tblInfo.Rows[0]["AllowAdd"] != DBNull.Value)
                        isAllowAdd = Convert.ToBoolean(tblInfo.Rows[0]["AllowAdd"]);
                    else
                        IsAdded = false;
                    if (tblInfo.Rows[0]["ReadOnly"] != DBNull.Value)
                        isReadOnly = Convert.ToBoolean(tblInfo.Rows[0]["ReadOnly"]);
                    if (tblInfo.Rows[0]["IsProcedure"] != DBNull.Value)
                        IsProcedure = Convert.ToBoolean(tblInfo.Rows[0]["IsProcedure"]);
                    if (tblInfo.Rows[0]["IsProcessForm"] != DBNull.Value)
                        IsProcessForm = Convert.ToBoolean(tblInfo.Rows[0]["IsProcessForm"]);
                    strColumnReadOnly = tblInfo.Rows[0]["ReadOnlyColumns"].ToString().Split(',');
                    strColumnFormatFont = tblInfo.Rows[0]["FormatFontColumns"].ToString().Split(',');
                    strColumnPaint = tblInfo.Rows[0]["PaintColumns"].ToString().Split(',');
                    strPaintRows = tblInfo.Rows[0]["PaintRows"].ToString().Split(',');
                    strColumnHide = tblInfo.Rows[0][ColumnHide].ToString().Split(',');
                    strColumnFixed = tblInfo.Rows[0][FixedColumns].ToString().Split(',');
                    strGroupColumns = tblInfo.Rows[0][GroupColumns].ToString().Split(',');
                    strColumnOrderBy = tblInfo.Rows[0][ColumnOrderBy].ToString().Split(',');
                    strColumnCombobox = tblInfo.Rows[0]["ComboboxColumns"].ToString().Split('|');
                    m_dtColumnsName = DBEngine.execReturnDataTable("sp_TableEditor_Columns", "@Tablename", strViewName);
                    m_dtColumnsName.PrimaryKey = new DataColumn[] { m_dtColumnsName.Columns[NAME] };
                    if (IsProcedure)
                    {
                        int height = 0;
                        tableName = tblInfo.Rows[0]["TableEditorName"].ToString();
                        // đọc các tham số truyền vào
                        dtParameter = DBEngine.execReturnDataTable("sp_Export_GetParameter",
                     "@ProcedureName", strViewName,
                     "@LanguageID", UIMessage.languageID);
                        grbFilter.Controls.Clear();
                        if ((dtParameter != null) && (dtParameter.Rows.Count > 0))
                        {
                            hideContainerLeft.Visible = true;
                            cellLocation = new string[3, dtParameter.Rows.Count];// frist used for Name, second used for Location and third used for Value
                            int index = 0;
                            //generate filter condition
                            foreach (DataRow dr in dtParameter.Rows)
                            {
                                //cut lose @LoginID
                                if (dr[P_NAME].ToString().ToLower().Equals(CommonConst.A_LoginID.ToLower()))
                                    continue;
                                height += 25;
                                // set lable
                                Label lbl = new Label() { Name = LBL_PREFIX + dr[P_NAME], Text = dr[Message_P].ToString() };
                                cellLocation[0, index] = lbl.Text;
                                cellLocation[1, index] = dr[CellLocation].ToString();
                                cellLocation[2, index++] = dr[P_NAME].ToString();
                                grbFilter.Controls.Add(lbl);
                                lbl.Location = new Point(10, height);
                                // set input control
                                switch (dr[DataType].ToString().ToLower())
                                {
                                    case "dropdownlist":
                                        {
                                            if (dr[P_NAME].ToString().ToLower() == CommonConst.A_EmployeeID.ToLower())
                                            {
                                                ShowEmployeeList(new Point(110, height), dr[P_NAME].ToString());
                                                break;
                                            }
                                            // create combobox for this once
                                            LookUpEdit cbx = new LookUpEdit() { Name = CBX_PREFIX + dr[P_NAME] };
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
                                            cbx.Location = new Point(110, height);
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
                                            TextBox txt = new TextBox() { Name = TXT_PREFIX + dr[P_NAME], Location = new Point(110, height), Width = 200 };
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
                                            DateEdit dtp = new DateEdit() { Name = DTP_PREFIX + dr[P_NAME], Location = new Point(110, height), Width = 200 };
                                            dtp.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
                                            dtp.Properties.LookAndFeel.SkinName = "Blue";
                                            dtp.Properties.Mask.EditMask = "dd/MM/yyyy";
                                            dtp.Properties.Mask.UseMaskAsDisplayFormat = true;
                                            grbFilter.Controls.Add(dtp);
                                            break;
                                        }
                                    case "boolean":
                                    case "bit":
                                        {
                                            // Create datetimepicker
                                            CheckEdit ckb = new CheckEdit() { Name = CKB_PREFIX + dr[P_NAME], Location = new Point(110, height) };
                                            ckb.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
                                            ckb.Properties.LookAndFeel.SkinName = "Blue";
                                            grbFilter.Controls.Add(ckb);
                                            break;
                                        }
                                    default:
                                        {
                                            // Create textbox and set read number only
                                            TextBox txt = new TextBox() { Name = TXT_PREFIX + dr[P_NAME], Location = new Point(110, height), Width = 200 };
                                            txt.BringToFront();
                                            grbFilter.Controls.Add(txt);
                                            // textbox here
                                            break;
                                        }
                                }
                               
                            }
                            grbFilter.Height = 25+ height;
                        }
                        else
                            hideContainerLeft.Visible = false;
                        // thực thi câu truy vấn với tham số mặc định
                        if (!IsProcessForm)
                            m_dtTableData = LoadProduceData();
                        else
                        {
                            pnlFWCommand.Visible = false;

                        }
                    }
                    else
                    {
                        hideContainerLeft.Visible = false;
                        m_dtTableData = DBEngine.execReturnDataTable(MakeLoadAllDataQuery(strViewName));
                    }
                    m_dtColumnsName_Org = DBEngine.execReturnDataTable("sp_TableEditor_Columns", "@Tablename", this.UserName.ToString());

                }
                else
                {
                    hideContainerLeft.Visible = false;
                    //Load Primary keys
                    m_dtColumnsName = DBEngine.execReturnDataTable("sp_TableEditor_Columns", "@Tablename", this.UserName.ToString());
                    m_dtColumnsName_Org = m_dtColumnsName.Copy();
                    m_dtTableData = DBEngine.execReturnDataTable(MakeLoadAllDataQuery(this.UserName.ToString()));
                }
                if (!IsProcessForm)
                {
                    BuildVisibleColumnsProc();
                    grdTableEditor.DataSource = m_dtTableData;
                    dt_OldValue = m_dtTableData.Copy();
                    RegisterEvents();
                    grvTableEditor.BestFitColumns();
                }
                Control.ControlCollection ctrls = splitContainer1.Panel2.Controls;
                UIMessage.LoadLableName(ref ctrls);
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, ex.Message, "Load and show data");
            }
            if (!IsProcessForm)
            {
                m_dtTableData.DefaultView.RowFilter = strFilter;
            }
        }
        private DataTable LoadProduceData()
        {
            DataTable dtRet = null;
            //đọc và gắn giá trị vào tham số để thực thi câu truy vấn
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
                else if(ctr.Name.Length >3)
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
                                    LookUpEdit cbx = (LookUpEdit)ctr;
                                    paramName[count] = cbx.Name.Substring(3);
                                    paramValue[count] = cbx.EditValue.ToString();
                                    break;
                                }
                            case CKB_PREFIX:
                                {
                                    CheckEdit cbx = (CheckEdit)ctr;
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
                        UIMessage.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            InputConditionValue();
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

            if (IsProcessForm)
            {
                pnlFWCommand.Visible = false;
                DBEngine.exec(strViewName, param);
                return null;
            }
            dtRet = DBEngine.execReturnDataTable(strViewName, param);

            grdTableEditor.DataSource = dtRet;
            grvTableEditor.BestFitColumns();

            return dtRet;
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
                    if (paramName[j].ToLower().Equals(CommonConst.A_Month))
                    {
                        Month = int.Parse(paramValue[j]);
                    }
                    if (paramName[j].ToLower().Equals(CommonConst.A_Year))
                    {
                        Year = int.Parse(paramValue[j]);
                    }
                }
            }
        }
        private void RegisterEvents()
        {
            m_dtTableData.ColumnChanged -= new DataColumnChangeEventHandler(m_dtTableData_ColumnChanged);
            //m_dtTableData.RowChanged -= new DataRowChangeEventHandler(m_dtTableData_RowChanged);
            m_dtTableData.ColumnChanged += new DataColumnChangeEventHandler(m_dtTableData_ColumnChanged);
            //m_dtTableData.RowChanged += new DataRowChangeEventHandler(m_dtTableData_RowChanged);
        }
        private void m_dtTableData_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            DirtyData = true;
        }
        private void BuildVisibleColumnsProc()
        {
            int iGroupIndexCount = -1;
            int i = 0;
            GridColumn[] grdCol = new GridColumn[m_dtTableData.Columns.Count];

            RepositoryItemTextEdit txtEdit = new RepositoryItemTextEdit();
            txtEdit.MouseWheel -= txtEdit_MouseWheel;
            txtEdit.MouseWheel += txtEdit_MouseWheel;
            rpeNumberMask.MouseWheel -= txtEdit_MouseWheel;
            rpeNumberMask.MouseWheel += txtEdit_MouseWheel;
            foreach (DataColumn dc in m_dtTableData.Columns)
            {

                GridColumn colAdd = new GridColumn() { FieldName = dc.Caption, Caption = dc.Caption, Name = dc.Caption };
                foreach (string readOnl in strColumnReadOnly)
                {
                    if (readOnl.ToLower().Equals(dc.Caption.ToLower()))
                    {
                        m_dtTableData.Columns[readOnl].ReadOnly = true;
                        break;
                    }
                }
                switch (dc.DataType.Name.ToLower())
                {
                    case "boolean":
                        RepositoryItemCheckEdit colBool = new RepositoryItemCheckEdit() { AllowFocused = false, BorderStyle = BorderStyles.NoBorder, ValueChecked = true, ValueUnchecked = false };

                        isShowCheckAllBtn = true;
                        if (colAdd.Name.ToLower().Contains("modifed"))
                            isContainModifedColumn = true;
                        colAdd.ColumnEdit = colBool;
                        colAdd.VisibleIndex = i;
                        colBool.MouseWheel -= txtEdit_MouseWheel;
                        colBool.MouseWheel += txtEdit_MouseWheel;
                        break;
                    case strDATETIME:
                        if (colAdd.Name.ToLower().Contains("time"))
                        {
                            colAdd.ColumnEdit = rpeDateTimeMask;
                        }
                        else
                        {
                            RepositoryItemDateEdit colDate = new RepositoryItemDateEdit(){
                                EditMask = UIMessage.DATE_FORMAT_PATTEN,
                                AllowFocused = false,
                                BorderStyle = BorderStyles.NoBorder};
                            colDate.Mask.UseMaskAsDisplayFormat = true;
                            colDate.MouseWheel -= txtEdit_MouseWheel;
                            colDate.MouseWheel += txtEdit_MouseWheel;
                            colAdd.ColumnEdit = colDate;
                        }
                        colAdd.VisibleIndex = i;
                        break;
                    case strFLOAT:
                    case strREAL:
                        colAdd.DisplayFormat.FormatString = "f";
                        colAdd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        colAdd.SummaryItem.DisplayFormat = "{0:#,##0;(#,##0);Zero}";
                        colAdd.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        colAdd.ColumnEdit = txtEdit;
                        colAdd.VisibleIndex = i;
                        break;
                    case strBIGINT:
                    case strINT:
                    case strNUMERIC:
                    case strSMALLINT:
                    case strTINYINT:
                    case strDecimal:
                        colAdd.DisplayFormat.FormatString = "n0";
                        colAdd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        colAdd.ColumnEdit = this.rpeNumberMask;
                        colAdd.SummaryItem.DisplayFormat = "{0:#,##0;(#,##0);Zero}";
                        colAdd.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        colAdd.VisibleIndex = i;
                        break;
                    case strMONEY:
                    case strSMALLMONEY:
                        colAdd.DisplayFormat.FormatString = "n0";
                        colAdd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        colAdd.ColumnEdit = this.rpeNumberMask;
                        colAdd.SummaryItem.DisplayFormat = "{0:#,##0;(#,##0);Zero}";
                        colAdd.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        colAdd.VisibleIndex = i;
                        break;
                    case strIMAGE:
                    case "byte[]":
                        RepositoryItemPictureEdit colPhoto = new RepositoryItemPictureEdit();
                        colAdd.ColumnEdit = colPhoto;
                        colAdd.VisibleIndex = i;
                        break;
                    default:
                        colAdd.ColumnEdit = txtEdit;
                        colAdd.VisibleIndex = i;
                        break;
                }
                if (colAdd.Name.ToLower().Equals(CommonConst.EmployeeID.ToLower()))
                {
                    //colAdd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    colAdd.ColumnEdit = null;//this.rpeNumberMask;
                    colAdd.SummaryItem.DisplayFormat = "{0:#,##0;(#,##0);Zero}";
                    colAdd.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    colAdd.Fixed = FixedStyle.Left;

                }
                if (colAdd.Name.ToLower().Equals(CommonConst.FullName.ToLower()))
                {
                    //colAdd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    colAdd.Fixed = FixedStyle.Left;
                }
                if (strColumnFormatFont != null && strColumnFormatFont.Length > 0 && strColumnFormatFont[0] != "")
                {
                    foreach (string strPairs in strColumnFormatFont)
                    {
                        if (colAdd.FieldName.Equals(strPairs.Split('#')[0]))
                        {
                            switch (strPairs.Split('#')[1].ToLower())
                            {
                                case "b":
                                    colAdd.AppearanceCell.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                                    break;
                                case "i":
                                    colAdd.AppearanceCell.Font = new Font("Tahoma", 8.25F, FontStyle.Italic);
                                    break;
                                case "s":
                                    colAdd.AppearanceCell.Font = new Font("Tahoma", 8.25F, FontStyle.Strikeout);
                                    break;
                                case "u":
                                    colAdd.AppearanceCell.Font = new Font("Tahoma", 8.25F, FontStyle.Underline);
                                    break;
                            }
                        }
                    }
                }
                if (colAdd.Name.ToLower().Equals("month") || colAdd.Name.ToLower().Equals("year"))
                {
                    colAdd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
                    colAdd.ColumnEdit = null;
                    colAdd.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.None;
                }
                //Set list box columns
                RepositoryItemLookUpEdit repCom = new RepositoryItemLookUpEdit();
                //set combobox value data
                if (strColumnCombobox.Length > 0)
                {
                    foreach (string com in strColumnCombobox)
                    {
                        string[] comboCol = com.Split('&');
                        if (comboCol.Length < 2)
                            continue;
                        if (dc.Caption == comboCol[0])
                        {
                            DataTable dtCom = DBEngine.execReturnDataTable(comboCol[1]);
                            if (dtCom != null && dtCom.Rows.Count > 0)
                            {
                                repCom.DataSource = dtCom;
                                repCom.ValueMember = dtCom.Columns[0].Caption;
                                if(dtCom.Columns.Count>1)
                                    repCom.DisplayMember = dtCom.Columns[1].Caption;
                                else
                                    repCom.DisplayMember = dtCom.Columns[0].Caption;
                                repCom.NullText = string.Empty;
                                repCom.CloseUp += new CloseUpEventHandler(repCom_CloseUp);
                                colAdd.ColumnEdit = repCom;
                                break;
                            }
                        }
                    }
                }
                if (strColumnHide != null && strColumnHide.Length > 0)
                {
                    foreach (string com in strColumnHide)
                    {
                        if (colAdd.Name.ToLower() == com.ToLower())
                        {
                            colAdd.VisibleIndex = -1;
                        }
                    }
                }
                if (strColumnFixed != null && strColumnFixed.Length > 0)
                {
                    foreach (string com in strColumnFixed)
                    {
                        if (colAdd.Name.ToLower() == com.ToLower())
                        {
                            colAdd.Fixed = FixedStyle.Left;
                        }
                    }
                }
                if (strColumnOrderBy != null && strColumnOrderBy.Length > 0)
                {
                    foreach (string com in strColumnOrderBy)
                    {
                        string[] comboCol = com.Split('&');
                        if (comboCol.Length < 2)
                            continue;
                        if (colAdd.Name.ToLower() == comboCol[0].ToLower())
                        {
                            colAdd.VisibleIndex = Convert.ToInt32(comboCol[1]);
                            break;
                        }
                    }
                }
                //int intWidth = Convert.ToInt16(dc.MaxLength) * 4;
                //colAdd.Width = (intWidth > 100 ? intWidth : 100);
                //colAdd.OptionsColumn.AllowEdit = !isReadOnly;
                grdCol[i++] = colAdd;
            }
            this.grvTableEditor.Columns.Clear();
            this.grvTableEditor.Columns.AddRange(grdCol);
            if (!isAllowAdd)
            {
                btnFWAdd.Enabled = false;
                btnFWDelete.Enabled = false;
            }
            m_dtTableData.DefaultView.AllowEdit = !isReadOnly;
            btnFWDelete.Visible = btnFWAdd.Visible = btnFWSave.Visible = btnFWReset.Visible = !isReadOnly;
            grvTableEditor.BestFitColumns();
            if (strGroupColumns != null && strGroupColumns.Length > 0)
            {
                grvTableEditor.OptionsView.ShowGroupPanel = true;
                foreach (string com in strGroupColumns)
                {
                    foreach (GridColumn colGroup in grvTableEditor.Columns)
                        if (colGroup.Name.ToLower() == com.ToLower())
                        {
                            colGroup.GroupIndex = ++iGroupIndexCount;
                        }
                }
                grvTableEditor.ExpandAllGroups();
            }
            if(grvTableEditor.GroupCount<=0)
                grvTableEditor.OptionsView.ShowGroupPanel = false;

        }

        void txtEdit_MouseWheel(object sender, MouseEventArgs e)
        {
            if((e as DevExpress.Utils.DXMouseEventArgs) != null)
                (e as DevExpress.Utils.DXMouseEventArgs).Handled = true;
            else
                (e as HandledMouseEventArgs).Handled = true;
        }

        void repCom_CloseUp(object sender, CloseUpEventArgs e)
        {
            try
            {
                LookUpEdit repCom = (LookUpEdit)sender;
                int[] nFocusedRows = grvTableEditor.GetSelectedRows();
                if ((nFocusedRows != null) && (nFocusedRows.Length > 0))
                {
                    foreach (int nFocusedRow in nFocusedRows)
                    {
                        DataRow dr = grvTableEditor.GetDataRow(nFocusedRow);
                        if (dr == null)
                            continue;
                        dr[repCom.Properties.ValueMember] = e.Value;
                    }
                }
            }
            catch (Exception ex) {
                HPA.Common.Helper.ShowException(ex, ex.Message, "repCom_CloseUp");
            }
        }
        public override bool OnExport()
        {
            try
            {
                ExportData exp = new ExportData(grvTableEditor);
                exp.ShowDialog();
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".OnExport()", null);
                return false;
            }
            return true;


        }
        public override bool OnAdd()
        {
            if (!base.OnAdd())
                return false;
            try
            {
                grvTableEditor.ClearSorting();
                grvTableEditor.CloseEditor();
                grvTableEditor.UpdateCurrentRow();
                
                grvTableEditor.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                m_dtTableData.DefaultView.RowFilter = strFilter;
                
                DirtyData = true;
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".OnAdd()", null);
                return false;
            }
            return true;
        }
        public override bool OnDesignForm()
        {
            try
            {
                HPA.Common.LayOutControlHelper.SaveDesignForm(splitContainer1.Panel1);
                HPA.Common.LayOutControlHelper.SaveDesignForm(splitContainer1.Panel1.Controls);
                //Open design form
                object o;
                m_fOpenObject("HPA.FORMDESIGNER", "FormDesigner", false, this.Name, out o);
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".OnDesignForm()", null);
                return false;
            }
            return true;


        }
        public override bool OnReset()
        {
            try
            {
                if (DirtyData == true)
                {
                    if (UIMessage.ShowMessage(CommonConst.DISCARD_CONFIRM, System.Windows.Forms.MessageBoxButtons.OKCancel,
                        System.Windows.Forms.MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        // refresh
                        grvTableEditor.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                        m_dtTableData.RejectChanges();
                        DirtyData = false;
                    }
                }
                if (!isReadOnly){
                   btnFWAdd.Enabled = btnFWSave.Enabled = isReadOnly;
                }
               if (isAllowAdd)
                   btnFWDelete.Enabled = btnFWAdd.Enabled = isAllowAdd;
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".OnReset()", null);
                return false;
            }

            return true;
        }
        private bool IsEmptyRow(DataRow dr,string TableName)
        {
            m_dtPrimaryKeys = DBEngine.execReturnDataTable("sp_TableEditor_GetPrimaryKeys", "@Tablename", TableName);
            foreach (DataRow drKey in m_dtPrimaryKeys.Rows)
            {
                if (dr[drKey[0].ToString()].ToString().Equals("") && drKey[1].ToString().Equals("0"))
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsDupplication(DataRow dr,string TableName)
        {
            string strFilter = "";
            m_dtPrimaryKeys = DBEngine.execReturnDataTable("sp_TableEditor_GetPrimaryKeys", "@Tablename", TableName);
            foreach (DataRow drKeys in m_dtPrimaryKeys.Rows)
            {
                if (drKeys[0].ToString().Equals("1"))
                    strFilter += String.Format("[{0}] = '{1}' and", drKeys[0], dr[drKeys[0].ToString()]);
                else
                    return false;
            }
            grvTableEditor.UpdateCurrentRow();
            strFilter = strFilter.Substring(0, strFilter.Length - 4);
            if (m_dtTableData.Select(strFilter).Length > 1)
                return true;
            else
                return false;
        }
        private void MakeInsertNewQuery(DataRow dr, string TableName)
        {
            string strRetVal = string.Empty;
            bool isIdentity = false;
            m_dtPrimaryKeys = DBEngine.execReturnDataTable("sp_TableEditor_GetPrimaryKeys", "@Tablename", TableName);
            SqlConnection CN = new SqlConnection(DBEngine.ConnectionString);
            foreach (DataRow drKey in m_dtPrimaryKeys.Rows)
            {
                if (dr[drKey[0].ToString()].ToString().Equals("") && drKey[1].ToString().Equals("0"))
                    return;
            }
            //I am here right now
            string query = string.Format("Insert into {0} (", TableName);
            string strColumnsName = "";
            string strValues = " Values (";
            for (int i = 0; i < m_dtTableData.Columns.Count; i++)
            {
                //Loai bo keys
                foreach (DataRow drPri in m_dtPrimaryKeys.Rows)
                {
                    if (drPri[0].ToString().Equals(m_dtTableData.Columns[i].Caption)&& drPri[1].ToString().Equals("1"))
                    {
                        isIdentity = true;
                        break;
                    }
                }
                if (isIdentity)
                {
                    isIdentity = false;
                    continue;
                }
                if (isColumnOfTable(m_dtTableData.Columns[i].Caption, TableName))
                {
                    strColumnsName += String.Format("[{0}],", m_dtTableData.Columns[i].Caption);
                    strValues += String.Format("@{0},", m_dtTableData.Columns[i].Caption);
                    //strValues += "N'" + getValidValue(dr, i) + "',";//;dr[i].ToString()
                }
            }
            strColumnsName = strColumnsName.Substring(0, strColumnsName.Length - 1) + ") ";
            strValues = strValues.Substring(0, strValues.Length - 1) + ")";
            strRetVal = query + strColumnsName + strValues;
            // add parameters
            SqlCommand SqlCom = new SqlCommand(strRetVal, CN);
            string strParamName = string.Empty;
            for (int i = 0; i < m_dtTableData.Columns.Count; i++)
            {
                if (isColumnOfTable(m_dtTableData.Columns[i].Caption, TableName))
                {
                    strParamName = "@" + m_dtTableData.Columns[i].Caption;

                    SqlParameter paramAdd = new SqlParameter(strParamName, dr[i]);
                    switch (m_dtTableData.Columns[i].DataType.Name.ToLower())
                    {
                        case "byte[]":
                            paramAdd.DbType = DbType.Binary;
                            break;
                        default:
                            break;

                    }
                    //strValues += "N'" + getValidValue(dr, i) + "',";//;dr[i].ToString()
                    SqlCom.Parameters.Add(paramAdd);
                }
            }
            CN.Open();
            SqlCom.ExecuteNonQuery();
            CN.Close();
        }
        
        private string GetKeyValue(DataRow drOld,string TableName)
        {
            m_dtPrimaryKeys = DBEngine.execReturnDataTable("sp_TableEditor_GetPrimaryKeys", "@Tablename", TableName);
            string retVal = "[";
            foreach (DataRow dr in m_dtPrimaryKeys.Rows)
            {
                retVal += drOld[dr[0].ToString()] + " , ";
            }
            return retVal.Substring(0, retVal.Length - 3) + "]";
        }
        private string GetKeyName(string TableName)
        {
            m_dtPrimaryKeys = DBEngine.execReturnDataTable("sp_TableEditor_GetPrimaryKeys", "@Tablename", TableName);
            string retVal = string.Empty;
            foreach (DataRow dr in m_dtPrimaryKeys.Rows)
            {
                retVal += dr[0] + " ; ";
            }
            return retVal.Substring(0, retVal.Length - 3);
        }
       
        private void MakeUpdateQuery(DataRow dr,string TableName)
        {
            m_dtPrimaryKeys = DBEngine.execReturnDataTable("sp_TableEditor_GetPrimaryKeys", "@Tablename", TableName);
            SqlConnection CN = new SqlConnection(DBEngine.ConnectionString);
            string strRetVal = "";
            string query = string.Format("Update {0} set ", TableName);
            string strSet = "";
            string strWhere = " where ";
            bool isKeys = false;
            for (int i = 0; i < m_dtTableData.Columns.Count; i++)
            {
                //Loai bo keys
                foreach (DataRow drPri in m_dtPrimaryKeys.Rows)
                {
                    if (drPri[0].ToString().Equals(m_dtTableData.Columns[i].Caption))
                    {
                        isKeys = true;
                        break;
                    }
                }
                if (isKeys)
                {
                    isKeys = false;
                    continue;
                }
                //update only column belong to original table not belong to view
                if (isColumnOfTable(m_dtTableData.Columns[i].Caption, TableName))
                {
                    if(dr[m_dtTableData.Columns[i].Caption,DataRowVersion.Original] != dr[m_dtTableData.Columns[i].Caption])
                        strSet += String.Format("[{0}] = @{0},", m_dtTableData.Columns[i].Caption);
                }
            }
            if (strSet.Length > 1)
            {
                isNoUpdate = false;
                strSet = strSet.Substring(0, strSet.Length - 1) + " ";
            }
            else
            {
                isNoUpdate = true;
                return;
            }
            // Where statement
            foreach (DataRow drPri in m_dtPrimaryKeys.Rows)
            {
                strWhere += String.Format("[{0}] = @{0} and ", drPri[0]);
            }
            strWhere = strWhere.Substring(0, strWhere.Length - 4);
            strRetVal = query + strSet + strWhere;
            SqlCommand SqlCom = new SqlCommand(strRetVal, CN);
            for (int i = 0; i < m_dtTableData.Columns.Count; i++)
            {
                if (isColumnOfTable(m_dtTableData.Columns[i].Caption, TableName))
                {

                    if (dr[m_dtTableData.Columns[i].Caption, DataRowVersion.Original] != dr[m_dtTableData.Columns[i].Caption] || m_dtPrimaryKeys.Select(string.Format("Name = '{0}'", m_dtTableData.Columns[i].Caption)).Length > 0)
                    {
                        SqlParameter paramAdd = new SqlParameter("@" + m_dtTableData.Columns[i].Caption, dr[i]);
                        switch (m_dtTableData.Columns[i].DataType.Name.ToLower())
                        {
                            case "image":
                            case "byte[]":
                                paramAdd.DbType = DbType.Binary;
                                break;
                            default:
                                break;

                        }
                        //strValues += "N'" + getValidValue(dr, i) + "',";//;dr[i].ToString()
                        SqlCom.Parameters.Add(paramAdd);
                    }
                }
            }
            CN.Open();
            SqlCom.ExecuteNonQuery();
            CN.Close();
        }

        private bool isColumnOfTable(string p,string tblN)
        {
            m_dtColumnsName_Org = DBEngine.execReturnDataTable("sp_TableEditor_Columns", "@Tablename", tblN);
            foreach (DataRow dr in m_dtColumnsName_Org.Rows)
            {
                if (dr[0].ToString().ToLower().Equals(p.ToLower()))
                    return true;
            }
            return false;
        }
        public override bool Commit()
        {
            bool isDuplicate = false;
            try
            {
                foreach (DataRow drEndInit in m_dtTableData.Rows)
                    drEndInit.EndEdit();
                // wait-cursor
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    if ((m_dtTableData != null) && m_dtTableData.Rows.Count > 0 && m_dtTableData.GetChanges() != null)
                    {

                        foreach(DataRow dr in m_dtTableData.GetChanges().Rows)
                        //for (int i = 0; i < m_dtTableData.Rows.Count; i++)
                        {
                            foreach (string tblN in tableName.Split('|'))
                            {
                                if (IsEmptyRow(dr, tblN))
                                    continue;
                                if (dr.RowState == DataRowState.Added)
                                {

                                    //Check duplicate
                                    isDuplicate = IsDupplication(dr,tableName);
                                    if (isDuplicate)
                                    {
                                        UIMessage.ShowMessage(CommonConst.DuplicatedRecord, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    }
                                    //Insert new record
                                    MakeInsertNewQuery(dr,tblN);
                                    UIMessage.EZLog(dr, tblN, this.AssemblyName, this.Name, this.UserID);
                                }
                                else if (dr.RowState == DataRowState.Modified)
                                {
                                    // Update existing record
                                    MakeUpdateQuery(dr,tblN);
                                    if (!isNoUpdate)
                                    {
                                        UIMessage.EZLog(dr, tblN, this.AssemblyName, this.Name, this.UserID);
                                    }
                                }
                            }

                        }
                        if (!isDuplicate)
                        {
                            m_dtTableData.AcceptChanges();
                            UIMessage.ShowMessage(CommonConst.DATASAVED_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        if (IsShowLayout)
                            BindingDataToControl(splitContainer1.Panel1);
                    }
                }
                catch (Exception ex)
                {
                    // m_dtTableData.RejectChanges();
                    throw (ex);
                }

                // restore cursor
                this.Cursor = Cursors.Default;

            }
            catch (Exception e)
            {
                // restore cursor
                this.Cursor = Cursors.Default;

                // show error
                HPA.Common.Helper.ShowException(e, this.Name + ".Commit()", null);

                // unable to commit
                return false;
            }
            
            grvTableEditor.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            return true;
        }
        public override bool OnSave()
        {
            try
            {
                if (dxValidationProvider1!= null && !dxValidationProvider1.Validate())
                    return false;
                if (UIMessage.ShowMessage(CommonConst.SAVE_DATA_QUES, System.Windows.Forms.MessageBoxButtons.YesNo,
                    System.Windows.Forms.MessageBoxIcon.Question) == DialogResult.No)
                    return false;
                // commit data to database
                if (!Commit())
                    return false;

                // save successfully, so no dirty data
                DirtyData = false;
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.GetType().AssemblyQualifiedName + ".OnSave()", null);
                return false;
            }
            if (!isAllowAdd)
            {
                btnFWAdd.Enabled = false;
                btnFWDelete.Enabled = false;
            }
            return true;
        }
        
        public override void SetData(object objParam)
        {
            try
            {
                this.Name = UserName.ToString();
                this.Text = objParam.ToString();
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".SetData()", null);
                return;
            }
        }
        public override bool OnDelete()
        {
            if ((m_dtTableData == null) || (m_dtTableData.Rows.Count <= 0))
                return true;
            // can we delete
            int[] i = grvTableEditor.GetSelectedRows();
            if (i.Length == 0) // haven't selected any rows
            {
                UIMessage.ShowMessage(1992, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                return false;
            }
            try
            {
                if (UIMessage.ShowMessage(CommonConst.DELETE_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (int del in i)
                    {

                        grvTableEditor.GetDataRow(del).RejectChanges();
                        //string deleteQuery = MakeDeleteQuery(grvTableEditor.GetDataRow(del));
                        //DBEngine.exec(deleteQuery);
                        foreach (string tblN in tableName.Split('|'))
                        {
                            ExecuteDeleteData(grvTableEditor.GetDataRow(del),tblN);
                            UIMessage.EZLog(grvTableEditor.GetDataRow(del),tblN, this.AssemblyName, this.Name, this.UserID);
                        }
                        //grvTableEditor.GetDataRow(del).Delete();
                    }
                }
                btnReload_Click(null,null);
                if (IsShowLayout)
                    BindingDataToControl(splitContainer1.Panel1);
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "OnDelete");
            }
            Control.ControlCollection ctrls = splitContainer1.Panel2.Controls;
            UIMessage.LoadLableName(ref ctrls);
            grvTableEditor.BestFitColumns();
            return true;
        }
        private void ExecuteDeleteData(DataRow dr,string TableName)
        {
            m_dtPrimaryKeys = DBEngine.execReturnDataTable("sp_TableEditor_GetPrimaryKeys", "@Tablename", TableName);
            SqlConnection CN = new SqlConnection(DBEngine.ConnectionString);
            string strRetVal = "";
            string query = string.Format("delete {0} ", this.UserName);
            string strWhere = " where ";
            // Where statement
            foreach (DataRow drPri in m_dtPrimaryKeys.Rows)
            {
                strWhere += String.Format("[{0}] = @{0} and ", drPri[0]);
            }
            strWhere = strWhere.Substring(0, strWhere.Length - 4);
            strRetVal = query + strWhere;
            SqlCommand SqlCom = new SqlCommand(strRetVal, CN);
            for (int i = 0; i < m_dtTableData.Columns.Count; i++)
            {
                SqlParameter paramAdd = new SqlParameter("@" + m_dtTableData.Columns[i].Caption, dr[i]);
                switch (m_dtTableData.Columns[i].DataType.Name.ToLower())
                {
                    case "datetime":
                        paramAdd.DbType = DbType.DateTime;
                        break;
                    case "image":
                    case "byte[]":
                        paramAdd.DbType = DbType.Binary;
                        break;
                    default:
                        break;

                }
                //strValues += "N'" + getValidValue(dr, i) + "',";//;dr[i].ToString()
                SqlCom.Parameters.Add(paramAdd);
            }
            CN.Open();
            SqlCom.ExecuteNonQuery();
            CN.Close();
        }
        private void txtFilter_EditValueChanged(object sender, EventArgs e)
        {
            strFilter = string.Empty;
            if (txtFilter.Text.Trim().Equals(string.Empty))
            {
                m_dtTableData.DefaultView.RowFilter = null;
                grdTableEditor.Refresh();
                return;
            }
            for (int i = 0; i < m_dtTableData.Columns.Count; i++)
            {
                switch (m_dtTableData.Columns[i].DataType.Name.ToLower())
                {
                    case "string":
                    case "varchar":
                    case "nvarchar":
                    case "text":
                        strFilter = String.Format("{0}[{1}{2}", strFilter, m_dtTableData.Columns[i].Caption, string.Format("] like '%{0}%' or ", txtFilter.Text));
                        
                        break;
                    default:
                        break;

                }
            }
            m_dtPrimaryKeys = DBEngine.execReturnDataTable("sp_TableEditor_GetPrimaryKeys", "@Tablename", tableName.Split('|')[0]);
            for(int i = 0; i<m_dtPrimaryKeys.Rows.Count;i++)
            {
                if(FindColumnsIntable(m_dtPrimaryKeys.Rows[i][0].ToString()))
                switch (m_dtTableData.Columns[i].DataType.Name.ToLower())
                {
                    case "string":
                    case "varchar":
                    case "nvarchar":
                    case "text":
                        strFilter = String.Format("{0}[{1}] is null or ", strFilter, m_dtPrimaryKeys.Rows[i][0]);
                        break;
                    default:
                        break;

                }
            }
            if (txtFilter.Text.Trim().Equals(string.Empty))
            {
                if (this.Name.ToLower() == "sp_HealthInsurance".ToLower())
                {
                    ((DataTable)((RepositoryItemLookUpEdit)grvTableEditor.Columns["HospitalID"].ColumnEdit).DataSource).DefaultView.RowFilter = "1=1";
                    m_dtTableData.DefaultView.RowFilter = "1=1";
                    grdTableEditor.Refresh();
                    }
                return;
            }
            strFilter = strFilter.Substring(0, strFilter.Length - 3);
            m_dtTableData.DefaultView.RowFilter = strFilter;
            grdTableEditor.Refresh();
        }

        private bool FindColumnsIntable(string p)
        {
            try
            {
                foreach (DataColumn dc in m_dtTableData.Columns)
                {
                    if (dc.Caption == p)
                        return true;
                }
            }
            catch {
                return false;
            }
            return false;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                if(!strViewName.Trim().Equals(string.Empty))
                this.UserName = tableName;
            if (!IsProcedure)
                InitializeData();
            else if (IsProcessForm)
            {
                if (UIMessage.ShowMessage(CommonConst.PROCESS_DATA_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    LoadProduceData();
                    UIMessage.ShowMessage(CommonConst.DATA_PROCESSED_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;
                }
                return;
            }
            else
            {
                m_dtTableData = LoadProduceData();
                RegisterEvents();
                BuildVisibleColumnsProc();
                Control.ControlCollection ctrls = splitContainer1.Panel2.Controls;
                UIMessage.LoadLableName(ref ctrls);
                grvTableEditor.BestFitColumns();
            }

            dt_OldValue = m_dtTableData.Copy();
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "btnReload_Click");
            }
            
        }
        // danh cho bao hiem
        int lastMaCheDo = 1;
        bool isUserInputed = false;
        private void grvTableEditor_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (!isUserInputed)
            {
                isUserInputed = true;
                return;
            }
            try
            {
                ColumnView View = sender as ColumnView;
                if (e.Column.FieldName.ToLower().Equals("ismodifed"))
                {
                    return;
                }
                if (isContainModifedColumn)
                {
                    View.SetRowCellValue(e.RowHandle, View.Columns["IsModifed"], true);
                }
                if (e.Column.FieldName == CommonConst.EmployeeID)
                {
                    //get full Name and display
                    DataTable dtFullName = DBEngine.execReturnDataTable("sp_hr_get_fullname", CommonConst.A_EmployeeID, e.Value, CommonConst.A_LoginID, UserID);
                    if (dtFullName != null && dtFullName.Rows.Count > 0)
                    {
                        //isUserInputed = false;
                        View.SetRowCellValue(e.RowHandle, View.Columns[CommonConst.FullName], dtFullName.Rows[0][CommonConst.FullName].ToString());
                    }
                    grvTableEditor.BestFitColumns();
                }
                // sử dụng riêng cho bảo hiểm
                if (this.Name.ToLower() == "tblSI_SummaryHeader_BHXH".ToLower())
                {
                    if (e.Column.FieldName == "HIIncAdj" || e.Column.FieldName == "HIDecAdj")
                    {
                        View.SetRowCellValue(e.RowHandle, View.Columns["HIAdjTotal"], Convert.ToInt64(View.GetRowCellValue(e.RowHandle, "HIIncAdj")) - Convert.ToInt64(View.GetRowCellValue(e.RowHandle, "HIDecAdj")));
                    }
                }
                if (this.Name.ToLower() == "sp_HuongCheDoOmDau_BHXH".ToLower())
                {
                    if (e.Column.FieldName == CommonConst.FullName)
                    {
                        View.SetRowCellValue(e.RowHandle, View.Columns["Ma_CheDo"], lastMaCheDo);
                        return;
                    }

                    DataTable dtInfo = null;
                    if (e.Column.FieldName == "Ma_CheDo")
                    {
                        lastMaCheDo = Convert.ToInt32(e.Value);

                        if (View.GetRowCellValue(e.RowHandle, CommonConst.EmployeeID) != DBNull.Value)
                        {
                            // get and display insurance info
                            dtInfo = DBEngine.execReturnDataTable("sp_getInsuranceInfo_BHXH", CommonConst.A_Month, View.GetRowCellValue(e.RowHandle, "Month"),
                                CommonConst.A_Year, View.GetRowCellValue(e.RowHandle, "Year"),
                                CommonConst.A_EmployeeID, View.GetRowCellValue(e.RowHandle, CommonConst.EmployeeID),
                                CommonConst.A_LoginID, this.UserID);
                            if (dtInfo.Rows.Count > 0)
                            {
                                isUserInputed = false;
                                View.SetRowCellValue(e.RowHandle, View.Columns["SocialNo"], dtInfo.Rows[0]["SocialNo"]);
                                isUserInputed = false;
                                View.SetRowCellValue(e.RowHandle, View.Columns["StartDate"], dtInfo.Rows[0]["StartDate"]);
                                isUserInputed = false;
                                View.SetRowCellValue(e.RowHandle, View.Columns["Salary"], dtInfo.Rows[0]["Salary"]);
                                View.FocusedColumn = View.Columns["Amount"];
                            }

                        }

                    }
                    if (e.Column.FieldName == "TrongKy")
                    {
                        if (this.Name.ToLower() == "sp_HuongCheDoOmDau_BHXH".ToLower())
                        {
                            View.SetRowCellValue(e.RowHandle, View.Columns["Amount"], Convert.ToInt64(View.GetRowCellValue(e.RowHandle, "TrongKy")) * Convert.ToInt64(View.GetRowCellValue(e.RowHandle, "Salary")) / 26 * 0.75);
                        }
                        else
                            if (View.GetRowCellValue(e.RowHandle, "Ma_CheDo").ToString() != "3")
                            {
                                View.SetRowCellValue(e.RowHandle, View.Columns["Amount"], Convert.ToInt64(View.GetRowCellValue(e.RowHandle, "TrongKy")) * Convert.ToInt64(View.GetRowCellValue(e.RowHandle, "Salary")) / 26);
                            }
                        View.FocusedColumn = View.Columns["ToDate"];
                    }
                    if (e.Column.FieldName == "FromDate" || e.Column.FieldName == "ToDate")
                    {
                        // lay lai thong tin luong
                        dtInfo = DBEngine.execReturnDataTable("sp_Get_LastSISalary_BHXH", CommonConst.A_FromDate, View.GetRowCellValue(e.RowHandle, "FromDate"),
                                CommonConst.A_EmployeeID, View.GetRowCellValue(e.RowHandle, CommonConst.EmployeeID),
                                CommonConst.A_LoginID, this.UserID);
                        if (dtInfo.Rows.Count > 0)
                            View.SetRowCellValue(e.RowHandle, View.Columns["Salary"], dtInfo.Rows[0]["LastSalary"]);
                        // tinh lai so ngay trong ky
                        if (View.GetRowCellValue(e.RowHandle, "FromDate") != DBNull.Value && View.GetRowCellValue(e.RowHandle, "ToDate") != DBNull.Value)
                        {
                            View.SetRowCellValue(e.RowHandle, View.Columns["TrongKy"], CountDayForOmDau(Convert.ToDateTime(View.GetRowCellValue(e.RowHandle, "FromDate")), Convert.ToDateTime(View.GetRowCellValue(e.RowHandle, "ToDate"))));
                            View.FocusedColumn = View.Columns["ToDate"];
                        }

                    }

                    grvTableEditor.BestFitColumns();
                }
                if (this.Name.ToLower() == "sp_HuongCheDoThaiSan_BHXH".ToLower())
                {
                    if (e.Column.FieldName == CommonConst.FullName)
                    {
                        View.SetRowCellValue(e.RowHandle, View.Columns["Ma_CheDo"], lastMaCheDo);
                        return;
                    }
                    DataTable dtInfo = null;
                    if (e.Column.FieldName == "Ma_CheDo")
                    {
                        if (View.GetRowCellValue(e.RowHandle, CommonConst.EmployeeID) != DBNull.Value)
                        {
                            // get and display insurance info
                            dtInfo = DBEngine.execReturnDataTable("sp_getInsuranceInfo_BHXH", CommonConst.A_Month, View.GetRowCellValue(e.RowHandle, "Month"),
                                CommonConst.A_Year, View.GetRowCellValue(e.RowHandle, "Year"),
                                CommonConst.A_EmployeeID, View.GetRowCellValue(e.RowHandle, CommonConst.EmployeeID),
                                CommonConst.A_LoginID, this.UserID);
                            if (dtInfo.Rows.Count > 0)
                            {
                                isUserInputed = false;
                                View.SetRowCellValue(e.RowHandle, View.Columns["SocialNo"], dtInfo.Rows[0]["SocialNo"]);
                                isUserInputed = false;
                                View.SetRowCellValue(e.RowHandle, View.Columns["StartDate"], dtInfo.Rows[0]["StartDate"]);
                                isUserInputed = false;
                                View.SetRowCellValue(e.RowHandle, View.Columns["Salary"], dtInfo.Rows[0]["Salary"]);
                                View.FocusedColumn = View.Columns["Amount"];
                            }

                        }

                    }
                    if (e.Column.FieldName == "TrongKy")
                    {
                        if (View.GetRowCellValue(e.RowHandle, "Ma_CheDo").ToString() != "3")
                        {
                            View.SetRowCellValue(e.RowHandle, View.Columns["Amount"], Convert.ToInt64(View.GetRowCellValue(e.RowHandle, "TrongKy")) * Convert.ToInt64(View.GetRowCellValue(e.RowHandle, "Salary")) / 26);
                        }
                        View.FocusedColumn = View.Columns["Amount"];
                    }
                    if (e.Column.FieldName == "FromDate" || e.Column.FieldName == "ToDate")
                    {
                        // lay lai thong tin luong
                        dtInfo = DBEngine.execReturnDataTable("sp_Get_LastSISalary_BHXH", CommonConst.A_FromDate, View.GetRowCellValue(e.RowHandle, "FromDate"),
                                CommonConst.A_EmployeeID, View.GetRowCellValue(e.RowHandle, CommonConst.EmployeeID),
                                CommonConst.A_LoginID, this.UserID);
                        if (dtInfo.Rows.Count > 0)
                            View.SetRowCellValue(e.RowHandle, View.Columns["Salary"], dtInfo.Rows[0]["AvgSal"]);
                        // tinh lai so ngay trong ky
                        if (View.GetRowCellValue(e.RowHandle, "FromDate") != DBNull.Value && View.GetRowCellValue(e.RowHandle, "ToDate") != DBNull.Value)
                        {
                            View.SetRowCellValue(e.RowHandle, View.Columns["TrongKy"], CountDayForOmDau(Convert.ToDateTime(View.GetRowCellValue(e.RowHandle, "FromDate")), Convert.ToDateTime(View.GetRowCellValue(e.RowHandle, "ToDate"))));

                            View.FocusedColumn = View.Columns["ToDate"];
                        }
                        // neu la sinh con
                        if (View.GetRowCellValue(e.RowHandle, "Ma_CheDo").ToString().Equals("3") && this.Name.ToLower() == "sp_HuongCheDoThaiSan_BHXH".ToLower())
                        {
                            View.SetRowCellValue(e.RowHandle, View.Columns["Amount"], 4 * Convert.ToInt64(View.GetRowCellValue(e.RowHandle, "Salary")) + Convert.ToDouble(dtInfo.Rows[0]["MinimumSal"]) * 2);
                            isUserInputed = false;
                            View.SetRowCellValue(e.RowHandle, View.Columns["TrongKy"], 120);
                            View.FocusedColumn = View.Columns["ToDate"];
                        }
                    }

                    grvTableEditor.BestFitColumns();
                }
                if (this.Name.ToLower() == "sp_HuongNghiDSPHSK_BHXH".ToLower())
                {
                    if (e.Column.FieldName == CommonConst.FullName)
                    {
                        View.SetRowCellValue(e.RowHandle, View.Columns["Ma_CheDo"], lastMaCheDo);
                        return;
                    }
                    DataTable dtInfo = null;
                    if (e.Column.FieldName == "Ma_CheDo")
                    {
                        if (View.GetRowCellValue(e.RowHandle, CommonConst.EmployeeID) != DBNull.Value)
                        {
                            lastMaCheDo = Convert.ToInt32(e.Value);

                            // get and display insurance info
                            dtInfo = DBEngine.execReturnDataTable("sp_getInsuranceInfo_BHXH", CommonConst.A_Month, View.GetRowCellValue(e.RowHandle, "Month"),
                                CommonConst.A_Year, View.GetRowCellValue(e.RowHandle, "Year"),
                                CommonConst.A_EmployeeID, View.GetRowCellValue(e.RowHandle, CommonConst.EmployeeID),
                                CommonConst.A_LoginID, this.UserID);
                            if (dtInfo.Rows.Count > 0)
                            {
                                isUserInputed = false;
                                View.SetRowCellValue(e.RowHandle, View.Columns["SocialNo"], dtInfo.Rows[0]["SocialNo"]);
                                isUserInputed = false;
                                View.SetRowCellValue(e.RowHandle, View.Columns["Salary"], dtInfo.Rows[0]["MinimumSal"]);
                                View.FocusedColumn = View.Columns["Amount"];
                            }
                        }

                        if (e.Value.ToString() == "1")
                            View.SetRowCellValue(e.RowHandle, View.Columns["TrongKy"], 5);
                        else
                            View.SetRowCellValue(e.RowHandle, View.Columns["TrongKy"], 7);

                    }
                    if (e.Column.FieldName == "FromDate")
                    {
                        // lay lai thong tin luong
                        dtInfo = DBEngine.execReturnDataTable("sp_Get_LastSISalary_BHXH", CommonConst.A_FromDate, View.GetRowCellValue(e.RowHandle, "FromDate"),
                                CommonConst.A_EmployeeID, View.GetRowCellValue(e.RowHandle, CommonConst.EmployeeID),
                                CommonConst.A_LoginID, this.UserID);
                        if (dtInfo.Rows.Count > 0)
                            View.SetRowCellValue(e.RowHandle, View.Columns["Salary"], dtInfo.Rows[0]["MinimumSal"]);
                        isUserInputed = false;
                        View.SetRowCellValue(e.RowHandle, View.Columns["Amount"], Convert.ToInt64(View.GetRowCellValue(e.RowHandle, "TrongKy")) * Convert.ToInt64(View.GetRowCellValue(e.RowHandle, "Salary")) / 4);
                        View.FocusedColumn = View.Columns["FromDate"];
                    }
                    grvTableEditor.BestFitColumns();

                }

            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "grvTableEditor_CellValueChanged");
            }
        }

        private int CountDayForOmDau(DateTime dateTime1, DateTime dateTime2)
        {
            int retval = 0;
            while (dateTime1.Date <= dateTime2.Date) {
                if(dateTime1.DayOfWeek != DayOfWeek.Sunday)
                    retval++;
                dateTime1 = dateTime1.AddDays(1);
            }
            return retval;
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            try
            {
                //DevExpress.XtraGrid.Columns.GridColumn colIsSelect = null;
                // File check box column
                foreach (GridColumn colIsSelect in grvTableEditor.Columns)
                {
                    if ((colIsSelect.ColumnType.Name == "Boolean") && (colIsSelect.OptionsColumn.AllowEdit))
                    {
                        if (!btnCheckAll.Text.Equals("Uncheck"))
                        {
                            for (int i = 0; i < grvTableEditor.RowCount; i++)
                            {
                                if (grvTableEditor.GetRowCellValue(i, colIsSelect).GetType().Name.Equals("DBNull") || !Convert.ToBoolean(grvTableEditor.GetRowCellValue(i, colIsSelect)) == true)
                                {
                                    grvTableEditor.SetRowCellValue(i, colIsSelect, true);
                                }
                            }
                            btnCheckAll.Text = "Uncheck";
                        }
                        else
                        {
                            for (int i = 0; i < grvTableEditor.RowCount; i++)
                            {
                                if (Convert.ToBoolean(grvTableEditor.GetRowCellValue(i, colIsSelect)) == true)
                                    grvTableEditor.SetRowCellValue(i, colIsSelect, false);
                            }
                            btnCheckAll.Text = UIMessage.Get_Message(btnCheckAll.Name);
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name + ".OnExport()", null);
            }
        }

        private void grvTableEditor_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            string PaintCoulumnName = string.Empty;
            string PaintColor = string.Empty;
            string PaintValue = string.Empty;
            try
            {
                if (strColumnPaint != null && strColumnPaint.Length > 0 && strColumnPaint[0] != "")
                {
                    foreach (string strPairs in strColumnPaint)
                    {
                        PaintCoulumnName = strPairs.Split('#')[0];
                        PaintColor = "#" + strPairs.Split('#')[1];
                        if (e.Column.FieldName.Equals(PaintCoulumnName))
                        {
                            e.Appearance.BackColor = ColorTranslator.FromHtml(PaintColor);
                        }
                    }
                }
                //Paint rows
                if (strPaintRows != null && strPaintRows.Length > 0 && strPaintRows[0] != "")
                {
                    foreach (string strPairs in strPaintRows)
                    {
                        PaintCoulumnName = strPairs.Split('#')[0];
                        PaintValue = strPairs.Split('#')[1];
                        PaintColor = "#" + strPairs.Split('#')[2];
                        DataRow dr = grvTableEditor.GetDataRow(e.RowHandle);
                        if (dr == null) return;
                        if (dr[PaintCoulumnName].ToString().Equals(PaintValue))
                        {
                            e.Appearance.BackColor = ColorTranslator.FromHtml(PaintColor);
                        }
                    }
                }

            }
            catch (Exception ex)
            { Common.Helper.LogError(ex, this.Name, "grvTableEditor_RowCellStyle()"); }
        }

        private void btnSaveLayout_Click(object sender, EventArgs e)
        {
            string strVisibleVal = string.Empty;
            string strHideVal = string.Empty;
            //Luu danh sach Hide columns
            try
            {
                foreach (GridColumn col in grvTableEditor.Columns) {
                    if (col.VisibleIndex >= 0)
                        strVisibleVal += string.Format("{0}&{1},", col.Name, col.VisibleIndex);
                    else
                        strHideVal += string.Format("{0},", col.Name);

                }
                if (strVisibleVal.Length > 0)
                    DBEngine.exec(string.Format("Update tblDataSetting set ColumnOrderBy = '{0}' where TableName = '{1}'", strVisibleVal.Substring(0, strVisibleVal.Length - 1), tblInfo.Rows[0]["TableName"]));
                if (strHideVal.Length > 0)
                    DBEngine.exec(string.Format("Update tblDataSetting set ColumnHide = '{0}' where TableName = '{1}'", strHideVal.Substring(0, strHideVal.Length - 1), tblInfo.Rows[0]["TableName"]));
                UIMessage.ShowMessage(CommonConst.DATASAVED_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                HPA.Common.Helper.LogError(ex, ex.Message, this.Text);

            }
            //Luu thu sắp xếp columns
        }

        private void grvTableEditor_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdTableEditor.DataSource == null)
                    return;
                if (grvTableEditor.Columns["HospitalID"].ColumnEdit == null)
                    return;
                // sử dụng riêng cho bảo hiểm
                // tự động filter khi chọn mã tỉnh
                if (this.Name.ToLower() == "sp_HealthInsurance".ToLower())
                {
                    ((DataTable)((RepositoryItemLookUpEdit)grvTableEditor.Columns["HospitalID"].ColumnEdit).DataSource).DefaultView.RowFilter = string.Format("ProvinceSICode = '{0}'", grvTableEditor.GetDataRow(grvTableEditor.GetSelectedRows()[0])["ProvinceSICode"]);
                    if (txtFilter.Text.Trim().Equals(string.Empty))
                    {
                        txtFilter.Text = grvTableEditor.GetDataRow(grvTableEditor.GetSelectedRows()[0])["ProvinceSICode"].ToString();
                        ((DataTable)grdTableEditor.DataSource).DefaultView.RowFilter = string.Format("ProvinceSICode = '{0}'", grvTableEditor.GetDataRow(grvTableEditor.GetSelectedRows()[0])["ProvinceSICode"]);
                    }
                }
            }catch(Exception ex){
                HPA.Common.Helper.LogError(ex, ex.Message, this.Text);
            }
        }

        private void grvTableEditor_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            grvTableEditor_Click(null, null);
        }

        private void grvTableEditor_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            ColumnView View = sender as ColumnView;
            m_dtPrimaryKeys = DBEngine.execReturnDataTable("sp_TableEditor_GetPrimaryKeys", "@Tablename", this.UserName.ToString());
            //kiem tra trong table co ton tai thang, nam ko, va cbxMonth co visible ko
            for (int i = 0; i < m_dtPrimaryKeys.Rows.Count; i++)
            {
                if (m_dtPrimaryKeys.Rows[i][NAME].ToString().ToLower().Equals("month") )
                    View.SetRowCellValue(e.RowHandle, m_dtPrimaryKeys.Rows[i][NAME].ToString(),Month);
                if (m_dtPrimaryKeys.Rows[i][NAME].ToString().ToLower().Equals("year"))
                    View.SetRowCellValue(e.RowHandle,m_dtPrimaryKeys.Rows[i][NAME].ToString(),Year);
            }
        }
        private void dckFilter_VisibilityChanged(object sender, DevExpress.XtraBars.Docking.VisibilityChangedEventArgs e)
        {
            dockPanel1_Container.BringToFront();
            dckFilter.BringToFront();
        }

        private void DataSetting_KeyDown(object sender, KeyEventArgs e)
        {
            if (UIMessage.ENTER_TO_TAB) {
                if (e.KeyCode == Keys.Enter)
                {
                    if (this.ActiveControl is System.Windows.Forms.SplitContainer)
                    {
                        splitContainer1.SelectNextControl(splitContainer1.ActiveControl, true, true, true, true);
                    }
                }
            }
            if(e.KeyData == (Keys.Control | Keys.F)){
                if(ChuaTimKiemVaGrid.Panel1Collapsed){
                    ChuaTimKiemVaGrid.Panel1Collapsed = false;
                    txtFilter.Focus();
                }
                else{
                    ChuaTimKiemVaGrid.Panel1Collapsed = true;
                    splitContainer1.SelectNextControl(splitContainer1.ActiveControl, true, true, true, true);
                }


            }
        }

        private void btnFWDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnFWSave_Click(object sender, EventArgs e)
        {

        }
    }
}