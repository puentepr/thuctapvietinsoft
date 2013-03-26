using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HPA.Common;
using DevExpress.XtraGrid.Views.Grid;

namespace HPA.TimeAttendance
{
    public partial class ApprovalAttendanceData : HPA.Component.Framework.CCommonForm
    {
        DataTable dtAttendanceList = null;
        private DataTable dtPaintColourProcedureName = null;
        private DataTable dtMonth = null;
        private DataTable dtYear = null;
        int month, year;
        DateTime FromDate, Todate;
        private string ProcedureName_TA = string.Empty;
        private string PaintColourProcedureName_TA = string.Empty;
        private string SaveProdureName_TA = string.Empty;
        private string KeysField_TA = string.Empty;
        private string FormName_TA = string.Empty;
        public ApprovalAttendanceData()
        {
            InitializeComponent();
        }
        public override bool InitializeData()
        {
            try
            {
                // set lable
                
                Control.ControlCollection ctrls = this.Controls;
                UIMessage.LoadLableName(ref ctrls);
                //Load month, Year List
                DataTable dtInitValue;

                dtMonth = DBEngine.execReturnDataTable("sp_MonthList", CommonConst.A_LoginID, UserID);
                cbxMonth.Properties.DataSource = dtMonth;
                dtInitValue = DBEngine.execReturnDataTable("select * from tblCurrentWorkingMonth");
                cbxMonth.EditValue = dtInitValue.Rows[0]["Month"];

                dtYear = DBEngine.execReturnDataTable("sp_YearList", CommonConst.A_LoginID, UserID);
                cbxYear.Properties.DataSource = dtYear;
                cbxYear.EditValue = dtInitValue.Rows[0]["Year"];

                //getMenuID (FormName)
                dtPaintColourProcedureName = DBEngine.execReturnDataTable(string.Format("select MessageID from tblMD_Message where Content = N'{0}' and [Language] = '{1}'", this.Text,UIMessage.languageID));
                if (dtPaintColourProcedureName != null && dtPaintColourProcedureName.Rows.Count>0)
                    FormName_TA = dtPaintColourProcedureName.Rows[0]["MessageID"].ToString();

                dtPaintColourProcedureName = DBEngine.execReturnDataTable(string.Format("Select * from TA_FormSetting where FormName = '{0}'", FormName_TA));
                if (dtPaintColourProcedureName != null && dtPaintColourProcedureName.Rows.Count > 0)
                {
                    ProcedureName_TA = dtPaintColourProcedureName.Rows[0]["ProcedureName"].ToString();
                    PaintColourProcedureName_TA = dtPaintColourProcedureName.Rows[0]["PaintColourProcedureName"].ToString();
                    KeysField_TA = dtPaintColourProcedureName.Rows[0]["KeysField"].ToString();
                    SaveProdureName_TA = dtPaintColourProcedureName.Rows[0]["SaveProdureName"].ToString();
                }
                else
                {
                    UIMessage.ShowMessage("FORM_DOES_NOT_SETTING_COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
                if(!PaintColourProcedureName_TA.Equals(string.Empty))
                    dtPaintColourProcedureName = DBEngine.execReturnDataTable(PaintColourProcedureName_TA);
                dtInitValue = DBEngine.execReturnDataTable("sp_Export_GetParameter", "@ProcedureName", ProcedureName_TA, "@LanguageID", UIMessage.languageID);
                if (dtInitValue.Select("Name = '@DepartmentID'").Length > 0)
                {
                    cbxDepartment.Properties.DataSource = DBEngine.execReturnDataTable("Gen_Department_List", CommonConst.A_LoginID, UserID);
                    cbxDepartment.Visible=true;
                    lblDepartment.Visible = true;
                }


            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".InitializeData()", null);
                return false;
            }

            return true;
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if(cbxDepartment.Visible)
                    dtAttendanceList = DBEngine.execReturnDataTable(ProcedureName_TA, CommonConst.A_LoginID, this.UserID, CommonConst.A_Month, cbxMonth.EditValue, CommonConst.A_Year, cbxYear.EditValue, "@DepartmentID",cbxDepartment.EditValue);
                else
                    dtAttendanceList = DBEngine.execReturnDataTable(ProcedureName_TA, CommonConst.A_LoginID, this.UserID, CommonConst.A_Month, cbxMonth.EditValue, CommonConst.A_Year, cbxYear.EditValue);
                dtAttendanceList.ColumnChanged += new DataColumnChangeEventHandler(dtAttendanceList_ColumnChanged);
                dtAttendanceList.RowChanged += new DataRowChangeEventHandler(dtAttendanceList_RowChanged);
                grdAttendanceList.DataSource = dtAttendanceList;
                grvAttendanceList.BestFitColumns();
                txtEmployeeID_Search.Focus();
                month = Convert.ToInt16(cbxMonth.EditValue);
                year = Convert.ToInt16(cbxYear.EditValue);


                DBEngine.exec("Get_SalaryPeriod", "@Month", month, "@Year", year);
                FromDate = Convert.ToDateTime(DBEngine.getParamValue("@FromDate").ToString());
                Todate = Convert.ToDateTime(DBEngine.getParamValue("@ToDate").ToString());

            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "");
            }
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
        public override bool Commit()
        {
            try
            {
                if (SaveProdureName_TA.Equals(string.Empty))
                    return true;
                if (UIMessage.ShowMessage(2, System.Windows.Forms.MessageBoxButtons.YesNo,
                   System.Windows.Forms.MessageBoxIcon.Question) == DialogResult.No)
                    return false;
                // wait-cursor
                this.Cursor = Cursors.WaitCursor;
                short a;
                try
                {
                    DBEngine.beginTransaction();
                    CRowUtility.updateDataRow(grvAttendanceList);
                    grvAttendanceList.BeginUpdate();
                    if (dtAttendanceList != null)
                    {
                        DataTable dtChanges = dtAttendanceList.GetChanges();
                        foreach (DataRow dr in dtChanges.Rows)
                        {
                            foreach (DataColumn dc in dtChanges.Columns)
                            {
                                if(dr[dc.ColumnName] != dr[dc.ColumnName,DataRowVersion.Original])
                                if (Int16.TryParse(dc.ColumnName, out a))
                                {
                                    DBEngine.exec(SaveProdureName_TA,
                                        CommonConst.A_LoginID,this.UserID,
                                        CommonConst.A_Month, month,
                                        CommonConst.A_Year, year,
                                        CommonConst.A_EmployeeID,dr[CommonConst.EmployeeID],
                                        "@DateName", dc.ColumnName,
                                        "@Value",dr[dc.ColumnName]);
                                }
                            }
                        }

                    }
                    grvAttendanceList.EndUpdate();
                    dtAttendanceList.AcceptChanges();
                    DBEngine.commit();
                }
                catch (Exception ex)
                {
                    grvAttendanceList.EndUpdate();
                    DBEngine.rollback();
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
            txtEmployeeID_Search.Focus();
            txtEmployeeID_Search.SelectAll();
            return true;

        }
        public override bool OnExport()
        {
            try
            {
                ExportData exp = new ExportData(grvAttendanceList);
                exp.ShowDialog();
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".OnExport()", null);
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
                    if (UIMessage.ShowMessage(5, System.Windows.Forms.MessageBoxButtons.OKCancel,
                        System.Windows.Forms.MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        // refresh 						
                        dtAttendanceList.RejectChanges();
                        DirtyData = false;
                    }
                }
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".OnReset()", null);
                return false;
            }

            return true;
        }
        void dtAttendanceList_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            this.DirtyData = true;
        }

        void dtAttendanceList_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            this.DirtyData = true;
        }

        private void txtEmployeeID_Search_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtAttendanceList.DefaultView.RowFilter = string.Format("EmployeeID like '%{0}%'", txtEmployeeID_Search.Text);
                grvAttendanceList.ClearSelection();
            }
            catch(Exception ex) {
                HPA.Common.Helper.LogError(ex, ex.Message, this.Text);
            }
        }

        private void txtFullNameSearch_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                dtAttendanceList.DefaultView.RowFilter = string.Format("FullName like '%{0}%'", txtFullNameSearch.Text);
                grvAttendanceList.ClearSelection();
            }
            catch (Exception ex) 
            {
                HPA.Common.Helper.LogError(ex, ex.Message, this.Text);
            }
        }

        private void grvAttendanceList_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                // tô màu ngày thứ 7, chủ nhật
                GridView View = sender as GridView;
                short a;
                float b;
                DateTime columnDate = GetColumnDate(e.Column.FieldName);
                if (e.Column.FieldName != null && Int16.TryParse(e.Column.FieldName, out a))
                {

                    string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]);
                    if (IsSundayColumn(e.Column.FieldName))
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml("#FCD5B4");
                    }
                    else if (IsSaturdayColumn(e.Column.FieldName))
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml("#CCFFCC");
                    }
                    else
                    {
                        if (columnDate >= DateTime.Now.Date)
                            return;
                        if (category.Length > 0)
                        {
                            // hien thị màu nghỉ
                            if (KeysField_TA == null || KeysField_TA.Equals(string.Empty))
                                return;
                            DataRow[] drLeave = dtPaintColourProcedureName.Select(string.Format("{0} = '{1}'", KeysField_TA, category.Substring(0, 1)));
                            if (drLeave != null && drLeave.Length > 0)
                            {
                                if (drLeave[0]["HilightColorCode"] != DBNull.Value && drLeave[0]["HilightColorCode"].ToString() != "")
                                    e.Appearance.BackColor = ColorTranslator.FromHtml("#" + drLeave[0]["HilightColorCode"]);
                            }

                        }
                        else { if (!cbxDepartment.Visible) e.Appearance.BackColor = Color.Red; }
                    }
                    //to mau neu ngay cong <1
                    if (float.TryParse(category, out b))
                    {
                        if (b < 1 && !cbxDepartment.Visible)
                            e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, ex.Message, this.Text);
            }
        }

        private DateTime GetColumnDate(string p)
        {
            DateTime dateCount = FromDate;
            try
            {
                if (year == 0) return dateCount;
                
                while (dateCount <= Todate)
                {
                    if (dateCount.Day.ToString().Equals(p))
                    {
                        return dateCount;
                    }
                    dateCount = dateCount.AddDays(1);
                }
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, ex.Message, this.Text);
            }
            return dateCount;
        }

        private bool IsSaturdayColumn(string p)
        {
            try
            {
                if (year == 0) return false;
                DateTime dateCount = FromDate;
                while (dateCount <= Todate)
                {
                    if (dateCount.Day.ToString().Equals(p))
                    {
                        if (dateCount.DayOfWeek == DayOfWeek.Saturday)
                            return true;
                        else
                            return false;
                    }
                    dateCount = dateCount.AddDays(1);
                }
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, ex.Message, this.Text);
            }
            return false;
        }

        private bool IsSundayColumn(string p)
        {
            try
            {
                if (year == 0) return false;
                DateTime dateCount = FromDate;
                while (dateCount <= Todate)
                {
                    if (dateCount.Day.ToString().Equals(p))
                    {
                        if (dateCount.DayOfWeek == DayOfWeek.Sunday)
                            return true;
                        else
                            return false;
                    }
                    dateCount = dateCount.AddDays(1);
                }
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, ex.Message, this.Text);
            }
            return false;
        }
    }
}