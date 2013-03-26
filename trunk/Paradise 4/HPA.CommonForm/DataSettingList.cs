using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HPA.Component;
using HPA.Common;
using HPA.SQL;

namespace HPA.CommonForm
{
    public partial class DataSettingList : HPA.Component.Framework.CCommonForm
    {
       

        private const int VISIBLE_COL_NUM = 3;

        string strRetVal = string.Empty;

        DataView dvData = null;
        private DataTable m_dtTableData;
        private DataTable m_dtColumnsName;
        string tableName = string.Empty;
        string filterValue = string.Empty;
        private DataTable m_dtPrimaryKeys;
        protected HPA.Common.Framework.CRunableObjectManager m_objManager = new HPA.Common.Framework.CRunableObjectManager();
        #region Const
        // Data type
        private const string strBIT = "bit";
        private const string strDATETIME = "datetime";
        private const string strINT = "int";
        private const string strMONEY = "money";
        private const string strBIGINT = "bigint";
        private const string strSMALLMONEY = "smallmoney";
        private const string strSMALLINT = "smallint";
        private const string strTINYINT = "tinyint";
        private const string strREAL = "real";
        private const string strFLOAT = "float";
        private const string strNUMERIC = "numeric";
        // data columns name
        private const string NAME = "name";
        private const string LENGTH = "length";
        private const string DATATYPE = "DataType";
        private const string TABLETYPE = "TableType";

        private const string ASSEMBLY_NAME = "DataSetting";

        #endregion

        
        public DataSettingList(string ctrName, string filterVal)
        {
            InitializeComponent();
            
            tableName = ctrName;
            filterValue = filterVal;
            string strServer, strDatabase, strUser, strPassword;
            DBConnection dbCon = new DBConnection();
            dbCon.getDBConnectionInfo(out strServer, out strDatabase, out strUser, out strPassword);
            m_objManager.Parent = this;
            m_objManager.DBEngine = new EzSql2(strServer, strDatabase, strUser, strPassword);
            m_objManager.DBEngine.open();

        }
        public DataSettingList(string ctrName)
        {
            InitializeComponent();

            tableName = ctrName;
            string strServer, strDatabase, strUser, strPassword;
            DBConnection dbCon = new DBConnection();
            dbCon.getDBConnectionInfo(out strServer, out strDatabase, out strUser, out strPassword);
            m_objManager.Parent = this;
            m_objManager.DBEngine = new EzSql2(strServer, strDatabase, strUser, strPassword);
            m_objManager.DBEngine.open();

        }
        public override bool InitializeData()
        {
            try
            {
                LoadDataAndShow();
                // set lable
                Control.ControlCollection ctrls = this.Controls;
                UIMessage.LoadLableName(ref ctrls);
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".InitializeData()", null);
                return false;
            }

            return true;
        }
        private string MakeLoadAllDataQuery(string tblName)
        {
            if(filterValue.Equals(string.Empty))
                return string.Format("Select * from {0}", tblName);
            else
                return string.Format("Select * from {0} where {1}", tblName,filterValue);
        }
        private void BuildVisibleColumns()
        {
            int colCount = m_dtColumnsName.Rows.Count > VISIBLE_COL_NUM? 3: m_dtColumnsName.Rows.Count;
            int i = 0;
            DevExpress.XtraGrid.Columns.GridColumn[] grdCol = new DevExpress.XtraGrid.Columns.GridColumn[colCount];
            foreach (DataRow dr in m_dtColumnsName.Rows)
            {
                DevExpress.XtraGrid.Columns.GridColumn colAdd = new DevExpress.XtraGrid.Columns.GridColumn();
                colAdd.FieldName = dr[NAME].ToString();
                colAdd.Caption = dr[NAME].ToString();
                colAdd.Name = dr[NAME].ToString();
                switch (dr[DATATYPE].ToString().ToLower())
                {
                    case strBIT:
                        DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit colBool = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                        colBool.AllowFocused = false;
                        colBool.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                        colBool.ValueChecked = true;
                        colBool.ValueUnchecked = false;


                        colAdd.ColumnEdit = colBool;
                        colAdd.VisibleIndex = i;

                        break;
                    case strDATETIME:
                        DevExpress.XtraEditors.Repository.RepositoryItemDateEdit colDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
                        colDate.Mask.EditMask = UIMessage.DATE_FORMAT_PATTEN;
                        colDate.Mask.UseMaskAsDisplayFormat = true;
                        colDate.AllowFocused = false;
                        colDate.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

                        colAdd.ColumnEdit = colDate;
                        //colAdd.FormatString = "dd/MM/yyyy";
                        //colAdd.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.DateTime;
                        colAdd.VisibleIndex = i;
                        break;
                    case strFLOAT:
                    case strREAL:
                        colAdd.DisplayFormat.FormatString = "f";
                        colAdd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        colAdd.VisibleIndex = i;
                        break;
                    case strBIGINT:
                    case strINT:
                    case strMONEY:
                    case strNUMERIC:
                    case strSMALLINT:
                    case strSMALLMONEY:
                    case strTINYINT:
                        colAdd.DisplayFormat.FormatString = "n0";
                        colAdd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        colAdd.VisibleIndex = i;
                        break;
                    default:

                        colAdd.VisibleIndex = i;
                        break;
                }
                int intWidth = Convert.ToInt16(dr[LENGTH]) * 4;
                colAdd.Width = (intWidth > 100 ? intWidth : 100);
                colAdd.OptionsColumn.AllowIncrementalSearch = true;
                colAdd.OptionsColumn.AllowEdit = false;
                grdCol[i++] = colAdd;
                if (i >= VISIBLE_COL_NUM)
                    break;
            }
            this.grvTableEditor.Columns.Clear();
            this.grvTableEditor.Columns.AddRange(grdCol);
        }
        private void LoadDataAndShow()
        {
            try
            {

                //Load Primary keys
                m_dtPrimaryKeys = m_objManager.DBEngine.execReturnDataTable("sp_TableEditor_GetPrimaryKeys", "@Tablename", tableName);

                m_dtColumnsName = m_objManager.DBEngine.execReturnDataTable("sp_TableEditor_Columns", "@Tablename", tableName);
                m_dtTableData = m_objManager.DBEngine.execReturnDataTable(MakeLoadAllDataQuery(tableName));
                //Show data
                BuildVisibleColumns();
                dvData = m_dtTableData.DefaultView;
                grdTableEditor.DataSource = dvData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void grdTableEditor_DoubleClick(object sender, EventArgs e)
        {
            ReturnValue();
        }

        private void grdTableEditor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ReturnValue();
            }
        }
        private void ReturnValue()
        {
            if (m_dtPrimaryKeys == null || m_dtPrimaryKeys.Rows.Count <= 0)
            {
                strRetVal = "";
            }
            else
            {
                int[] selectedRow = grvTableEditor.GetSelectedRows();
                strRetVal = grvTableEditor.GetDataRow(selectedRow[0])[m_dtPrimaryKeys.Rows[0][0].ToString()].ToString().Trim();
                //strRetVal[1] = dtEmployeeIDList.Rows[selectedRow[0]][].ToString().Trim() + " " + dtEmployeeIDList.Rows[selectedRow[0]]["FirstName"].ToString();
            }
            this.Close();
        }
        public override object GetData()
        {
            try
            {
                return strRetVal;
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".GetData()", null);
                return null;
            }
        }

        private void txtFilter_EditValueChanged(object sender, EventArgs e)
        {
            string strFilter = string.Empty;
            for (int i = 0; i < VISIBLE_COL_NUM; i++)
            {
                strFilter = strFilter + m_dtColumnsName.Rows[i][0].ToString() + string.Format(" like '%{0}%' or ", txtFilter.Text);
            }
            strFilter = strFilter.Substring(0,strFilter.Length - 3);
            dvData.RowFilter = strFilter;
            grdTableEditor.Refresh();
        }

        private void grvTableEditor_GotFocus(object sender, EventArgs e)
        {
            grvTableEditor.SelectRow(0);
        }
    }
}