using HPA.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;


namespace HPA.CommonForm
{
    public partial class EmployeeIDList : HPA.Component.Framework.CCommonForm
    {
        DataTable dtEmployeeIDList = null;
        DataTable dtEmployeeStatus = null;
        DataView dvEmployeeIDList = null;
        string strScreenID = null;
        string [] strRetVal = new string[2];

        public EmployeeIDList()
        {
            InitializeComponent();
        }
        public override bool InitializeData()
        {
            try
            {
                //Load title
                Control.ControlCollection ctrls = this.Controls;
                UIMessage.LoadLableName(ref ctrls);
                if (!initFomrsData())
                    return false;
                txtSearch.Focus();
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".InitializeData()", null);
                return false;
            }

            return true;
        }

        private bool initFomrsData()
        {
            //Load employee status list
            try
            {
                dtEmployeeIDList = DBEngine.execReturnDataTable("sp_EmployeeIDList", CommonConst.A_LoginID, UIMessage.userID,
                    "@ScreenID", strScreenID);
                // bound data
                dvEmployeeIDList = dtEmployeeIDList.DefaultView;
                grdEmployeeIDList.DataSource = dvEmployeeIDList;
                //Load Stataus List
                dtEmployeeStatus = DBEngine.execReturnDataTable("Gen_EmpStatus_List");
                cbxEmployeeStatus.Properties.DataSource = dtEmployeeStatus;
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, ex.Message, "initFomrsData");
            }
            return true;
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
        public override void SetData(object objParam)
        {
            try
            {
                if (objParam == null)
                    strScreenID = "-1";// list all
                else
                    strScreenID = objParam.ToString();
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".SetData()", null);
                return;
            }
        }
        private void grdEmployeeIDList_DoubleClick(object sender, EventArgs e)
        {
            ReturnValue();
        }

        private void ReturnValue()
        {
            int[] selectedRow = grvEmployeeID.GetSelectedRows();
            strRetVal[1] = string.Format("{0} {1}", grvEmployeeID.GetDataRow(selectedRow[0])["LastName"].ToString().Trim(), grvEmployeeID.GetDataRow(selectedRow[0])["FirstName"].ToString().Trim());
            strRetVal[0] = grvEmployeeID.GetDataRow(selectedRow[0])[Common.CommonConst.EmployeeID].ToString();
            this.Close();
        }

        private void cbxEmployeeStatus_EditValueChanged(object sender, EventArgs e)
        {
            dvEmployeeIDList.RowFilter = string.Format("EmployeeStatusID = {0}", cbxEmployeeStatus.EditValue);
        }

        private void grdEmployeeIDList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ReturnValue();
            }
        }

        private void txtFullName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string strFilter = string.Format("LastNameEN like '%{0}%' or EmployeeID like '%{1}%'", StandardName.TitleCase(Common.Methods.RemoveToneMarks(txtSearch.Text.Trim())),txtSearch.Text.Trim());
                dtEmployeeIDList.DefaultView.RowFilter = strFilter;
                grdEmployeeIDList.Refresh();
                grvEmployeeID.RefreshData();
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, ex.Message, "");
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '\'') || (e.KeyChar == '[') || (e.KeyChar == ']'))
                e.Handled = true;
        }
        
    }
}