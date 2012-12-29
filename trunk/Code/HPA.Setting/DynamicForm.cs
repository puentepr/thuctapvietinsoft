using DevExpress.XtraGrid.Columns;
using HPA.Common;
using System;
using System.Collections.Generic;
using System.Data;

namespace HPA.Setting
{
    public partial class DynamicForm : HPA.CommonForm.BaseForm
    {
        DataTable tblInfo = null;
        private DataTable m_dtTableData;
        private DataTable m_dtColumnsName_Org;
        private DataTable dt_OldValue;
        private DataTable m_dtColumnsName;
        private DataTable dtParameter;
        private DataTable dtInitValue;
        string strFilter = string.Empty;
        private string tableName = string.Empty;
        private string strViewName = string.Empty;
        private bool isAllowAdd = true;
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

        #region Const
        // Data type
        private const string strBIT = "bit";
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
        private const string LENGTH = "length";
        private const string Query = "Query";
        private const string DATATYPE = "DataType";
        private const string TABLETYPE = "TableType";
        private const string IS_COMBOBOX = "IsCombobox";
        private const string ColumnOrderBy = "ColumnOrderBy";
        private const string ColumnHide = "ColumnHide";
        private const string GroupColumns = "GroupColumns";
        private const string FixedColumns = "FixedColumns";
        private const string ASSEMBLY_NAME = "DynamicForm";

        #endregion

        public DynamicForm()
        {
            InitializeComponent();
            try
            {
                LoadDataAndShow();
                //btnCheckAll.Visible = isShowCheckAllBtn;
                // set lable
                System.Windows.Forms.Control.ControlCollection ctrls = this.Controls;
                HPA.Common.Methods.ChangeLanguage(ref ctrls);
                if (IsProcessForm)
                {
                    //groupBox1.Visible = false;
                    //lblSearch.Visible = false;
                    //txtFilter.Visible = false;
                    //btnReload.Text = UIMessage.Get_Message("btnProcess");
                    //ProcessText.Text = this.Text;
                }
                //Best fit Columns
                //grvDynamic.BestFitColumns();
            }
            catch (Exception e)
            {
                HPA.Common.Methods.ShowError(e);
            }

        }
        private void LoadDataAndShow()
        {
            try
            {
                this.Name = "CurrentCompanySalary";
                tableName = this.Name;
                tblInfo = DBEngine.execReturnDataTable(string.Format("select * from tblDataSetting where TableName = '{0}'", tableName));
                if (tblInfo != null && tblInfo.Rows.Count > 0)
                {
                    //Load Primary keys
                    if (!tblInfo.Rows[0]["TableEditorName"].ToString().Equals(string.Empty))
                        tableName = tblInfo.Rows[0]["TableEditorName"].ToString().Split('|')[0];
                    //m_dtPrimaryKeys = DBEngine.execReturnDataTable("sp_TableEditor_GetPrimaryKeys", "@Tablename", tableName.ToString());
                    strViewName = tblInfo.Rows[0]["ViewName"].ToString();
                    if (tblInfo.Rows[0]["AllowAdd"] != DBNull.Value)
                        isAllowAdd = Convert.ToBoolean(tblInfo.Rows[0]["AllowAdd"]);
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
                    if (strGroupColumns.Length <= 1)
                        grvDynamic.OptionsView.ShowGroupPanel = false;
                    strColumnOrderBy = tblInfo.Rows[0][ColumnOrderBy].ToString().Split(',');
                    strColumnCombobox = tblInfo.Rows[0]["ComboboxColumns"].ToString().Split('|');
                    m_dtColumnsName = DBEngine.execReturnDataTable("sp_TableEditor_Columns", "@Tablename", strViewName);
                    m_dtColumnsName.PrimaryKey = new DataColumn[] { m_dtColumnsName.Columns[NAME] };
                    if (IsProcedure)
                    {
                        tableName = tblInfo.Rows[0]["TableEditorName"].ToString();
                        // đọc các tham số truyền vào
                        dtParameter = DBEngine.execReturnDataTable("sp_Export_GetParameter",
                     "@ProcedureName", strViewName,
                     "@LanguageID", HPA.Common.StaticVars.LanguageID);
                        if (dtParameter != null && dtParameter.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtParameter.Rows)
                            {
                               
                            }
                        }
                        // thực thi câu truy vấn với tham số mặc định
                        if (!IsProcessForm)
                            m_dtTableData = LoadProduceData();
                        
                    }
                    else
                        m_dtTableData = DBEngine.execReturnDataTable(MakeLoadAllDataQuery(strViewName));
                    //m_dtTableData.DefaultView.Sort = tblInfo.Rows[0]["ColumnOrderBy"].ToString();
                    m_dtColumnsName_Org = DBEngine.execReturnDataTable("sp_TableEditor_Columns", "@Tablename", tableName);

                }
                else
                {
                    //Load Primary keys
                    //m_dtPrimaryKeys = DBEngine.execReturnDataTable("sp_TableEditor_GetPrimaryKeys", "@Tablename", tableName.ToString());
                    m_dtColumnsName = DBEngine.execReturnDataTable("sp_TableEditor_Columns", "@Tablename", tableName);
                    m_dtColumnsName_Org = m_dtColumnsName.Copy();
                    m_dtTableData = DBEngine.execReturnDataTable(MakeLoadAllDataQuery(tableName));
                }
                //set primary keys columns
                //m_dtTableData.PrimaryKey = getPrimaryColums();
                //Show data
                //if (!IsProcedure)
                //    BuildVisibleColumns();
                //else
                if (!IsProcessForm)
                {
                    BuildVisibleColumnsProc();
                    grdDynamic.DataSource = m_dtTableData;
                    dt_OldValue = m_dtTableData.Copy();
                    //RegisterEvents();
                    grvDynamic.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (!IsProcessForm)
            {
                m_dtTableData.DefaultView.RowFilter = strFilter;
            }
        }
        private void BuildVisibleColumnsProc()
        {
            bool isContainPic = false;
            int iGroupIndexCount = -1;
            int i = 0;
            DevExpress.XtraGrid.Columns.GridColumn[] grdCol = new DevExpress.XtraGrid.Columns.GridColumn[m_dtTableData.Columns.Count];

            foreach (DataColumn dc in m_dtTableData.Columns)
            {

                DevExpress.XtraGrid.Columns.GridColumn colAdd = new DevExpress.XtraGrid.Columns.GridColumn() { FieldName = dc.Caption, Caption = dc.Caption, Name = dc.Caption };
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
                        DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit colBool = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() { AllowFocused = false, BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder, ValueChecked = true, ValueUnchecked = false };

                        isShowCheckAllBtn = true;
                        if (colAdd.Name.ToLower().Contains("modifed"))
                            isContainModifedColumn = true;
                        colAdd.ColumnEdit = colBool;
                        colAdd.VisibleIndex = i;

                        break;
                    case strDATETIME:
                        if (colAdd.Name.ToLower().Contains("time"))
                        {
                            colAdd.ColumnEdit = rpeDateTimeMask;
                        }
                        else
                        {
                            DevExpress.XtraEditors.Repository.RepositoryItemDateEdit colDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
                            colDate.Mask.EditMask = CommonConst.DATE_FORMAT_PATTEN;
                            colDate.Mask.UseMaskAsDisplayFormat = true;
                            colDate.AllowFocused = false;
                            colDate.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

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
                        DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit colPhoto = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
                        colAdd.ColumnEdit = colPhoto;
                        colAdd.VisibleIndex = i;
                        isContainPic = true;
                        break;
                    default:

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
                                    colAdd.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                                    break;
                                case "i":
                                    colAdd.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
                                    break;
                                case "s":
                                    colAdd.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout);
                                    break;
                                case "u":
                                    colAdd.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
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
                DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repCom = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
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
                                repCom.DisplayMember = dtCom.Columns[1].Caption;
                                repCom.NullText = string.Empty;
                                repCom.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(repCom_CloseUp);
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
            this.grvDynamic.Columns.Clear();
            this.grvDynamic.Columns.AddRange(grdCol);
            
            m_dtTableData.DefaultView.AllowEdit = !isReadOnly;
            //if (!isContainPic)
            //    grvDynamic.BestFitColumns();
            //else
            //    grvDynamic.RowHeight = 100;
            grvDynamic.BestFitColumns();
            if (strGroupColumns != null && strGroupColumns.Length > 0)
            {
                grvDynamic.OptionsView.ShowGroupPanel = false;
                foreach (string com in strGroupColumns)
                {
                    foreach (GridColumn colGroup in grvDynamic.Columns)
                        if (colGroup.Name.ToLower() == com.ToLower())
                        {
                            colGroup.GroupIndex = ++iGroupIndexCount;
                            grvDynamic.OptionsView.ShowGroupPanel = true;
                        }
                }
                grvDynamic.ExpandAllGroups();
            }
        }
        void repCom_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.LookUpEdit repCom = (DevExpress.XtraEditors.LookUpEdit)sender;
                int[] nFocusedRows = grvDynamic.GetSelectedRows();
                if ((nFocusedRows != null) && (nFocusedRows.Length > 0))
                {
                    foreach (int nFocusedRow in nFocusedRows)
                    {
                        DataRow dr = grvDynamic.GetDataRow(nFocusedRow);
                        if (dr == null)
                            continue;
                        dr[repCom.Properties.ValueMember] = e.Value;
                    }
                }
            }
            catch (Exception ex) {
                Methods.ShowError(ex);
            }
        }
        private string MakeLoadAllDataQuery(string tblName)
        {
            return string.Format("Select * from {0}", tblName);
        }
        private DataTable LoadProduceData()
        {
            object[] param = null;
            int countParam = 0;
            DataTable dtRet = null;
            //đọc và gắn giá trị vào tham số để thực thi câu truy vấn
            if (dtParameter != null && dtParameter.Rows.Count > 0)
            {
                param = new object[dtParameter.Rows.Count * 2 + 2];
                foreach (DataRow dr in dtParameter.Rows)
                {
                    
                }

                param[countParam++] = Common.CommonConst.A_LoginID;
                param[countParam++] = Common.StaticVars.LoginID;
            }
            else
            {
                param = new object[2];
                param[0] = Common.CommonConst.A_LoginID;
                param[1] = Common.StaticVars.LoginID;
            }
            if (IsProcessForm)
            {
                
                DBEngine.exec(strViewName, param);
                return null;
            }
            dtRet = DBEngine.execReturnDataTable(strViewName, param);
            grdDynamic.DataSource = dtRet;
            grvDynamic.BestFitColumns();
            return dtRet;
        }
    }
}