using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using HPA.Common;

namespace HPA.SystemAdmin
{
    public partial class HPALog : HPA.Component.Framework.CCommonForm
    {
        protected DataTable dtFunctionList = null;
        protected DataTable dtSC_LogList = null;
        public HPALog()
        {
            InitializeComponent();
            // set lable
            Control.ControlCollection ctrls = this.Controls;
            UIMessage.LoadLableName(ref ctrls);
        }
        public override bool InitializeData()
        {
            try
            {
                //Load FunctionList
                dtFunctionList = DBEngine.execReturnDataTable("SC_FunctionList","@LanguageID", UIMessage.languageID);
                cbxFunctionName.Properties.DataSource = dtFunctionList;
                cbxFunctionName.EditValue = "-1";
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".InitializeData()", null);
                return false;
            }

            return true;
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
        private void txtEmployeeID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                try
                {
                    // show employeeID list
                    object obj;
                    OpenObject("HPA.CommonForm", "EmployeeIDList", true, null, out obj);
                    txtEmployeeID.Text = ((string[])obj)[0];
                    txtFullName.Text = ((string[])obj)[1];
                    //Show infomation
                    ckbAllEmployees.Checked = false;
                }
                catch (Exception ex)
                {
                    HPA.Common.Helper.ShowException(ex, this.Name, "txtEmployeeID_KeyUp");
                    return;
                }
            }
        }

        private void txtEmployeeID_Leave(object sender, EventArgs e)
        {
            if (!txtEmployeeID.Text.Trim().Equals(""))
            {
                DataTable dtFullName = DBEngine.execReturnDataTable("sp_hr_get_fullname", CommonConst.A_EmployeeID, txtEmployeeID.Text, CommonConst.A_LoginID,UserID);
                if (dtFullName != null && dtFullName.Rows.Count > 0)
                {
                    txtFullName.Text = dtFullName.Rows[0][0].ToString();
                    ckbAllEmployees.Checked = false;
                }
                else
                {
                    txtFullName.Text = "";
                    txtEmployeeID.SelectAll();
                    txtEmployeeID.Focus();
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string employeeID = "";
            if (ckbAllEmployees.Checked)
                employeeID = "-1";
            else
                employeeID = txtEmployeeID.Text;
            // show Log record
            try
            {
                dtSC_LogList = DBEngine.execReturnDataTable("SC_EZLog_List",
                    "@FromDate",dtpFromdate.EditValue,
                    "@ToDate", dtpToDate.EditValue,
                    "@EmployeeID",employeeID,
                    "@FunctionClassName",cbxFunctionName.EditValue
                    );
                grdSCLogList.DataSource = dtSC_LogList;
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "btnLoad_Click");
            }
        }

        private void ckbAllEmployees_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbAllEmployees.Checked)
            {
                txtEmployeeID.Text = string.Empty;
                txtFullName.Text = string.Empty;
            }
            else
                txtEmployeeID.Focus();
        }

        private void HPALog_Load(object sender, EventArgs e)
        {
            dtpFromdate.DateTime = DateTime.Now;
            dtpToDate.EditValue = DateTime.Now;
            ckbAllEmployees.Checked = true;
            dtpFromdate.Focus();
        }
    }
}