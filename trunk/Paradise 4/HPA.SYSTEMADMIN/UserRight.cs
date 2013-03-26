using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using HPA.Common;

namespace HPA.SystemAdmin
{
    public partial class UserRight : HPA.Component.Framework.CCommonForm
    {
        protected DataTable dtLoginInfor = null;
        protected DataTable dtDepartmentList = null;
        protected DataTable dtSectionList = null;
        protected DataView dvSectionList = null;
        protected DataTable dtRightNameList = null;
        protected DataTable dtObjectList = null;

        protected const string LoginName = "LoginName";
        protected const string FullName = "FullName";
        protected const string Password = "Password";
        protected const string DepartmentID = "DepartmentID";
        protected const string LoginID = "LoginID";
        protected const string AdminRight = "AdminRight";
        protected const string DepartmentName = "DepartmentName";
        protected const string DepartmentCode = "DepartmentCode";
        protected const string ViewInfo = "ViewInfo";
        protected const string SectionName = "SectionName";
        protected const string SectionCode = "SectionCode";
        protected const string SectionID = "SectionID";
        protected const string ObjectName = "ObjectName";
        protected const string ObjectID_D = "ObjectID";
        protected const string Description = "Description";
        protected const string Right_D = "Right";

        public UserRight()
        {
            InitializeComponent();
            // set lable
            Control.ControlCollection ctrls = this.Controls;
            UIMessage.LoadLableName(ref ctrls);
        }
        public override bool InitializeData()
        {
            // TODO:  Add InsuranceInfo.InitializeData implementation
            try
            {
                myInitializeData();
            }
            catch (Exception sqlEx)
            {
                HPA.Common.Helper.ShowException(sqlEx, this.Name + ".InitializeData()", "Paradise - vietinsoft");
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
        public override bool OnDelete()
        {
            if (!base.OnDelete())
                return false;
            if (dtLoginInfor.Rows[0][AdminRight] != DBNull.Value && Convert.ToBoolean(dtLoginInfor.Rows[0][AdminRight]) == true)
            {
                UIMessage.ShowMessage("CANNOT_DELETE_ADMIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (UIMessage.ShowMessage(3, System.Windows.Forms.MessageBoxButtons.YesNo,
                        System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return false;
            try
            {
                DBEngine.beginTransaction();
                // Delete user from tblSC_Login
                // Delete from Right table
                // Delete from DevSecView table
                DBEngine.exec("SC_User_Delete",
                    CommonConst.A_LoginID, UserID,
                    "@p_LoginID", dtLoginInfor.Rows[0][LoginID]);
            }
            catch (Exception ex)
            {
                DBEngine.rollback();
                HPA.Common.Helper.ShowException(ex, this.Name, "OnDelete");
            }
            UIMessage.ShowMessage(HPA.Common.CommonConst.DELETE_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadLoginInfo();
            txtEmployeeID.Focus();
            DBEngine.commit();
            return true;
        }
        public override bool Commit()
        {
            const int pCheck = 0;
            try
            {
                // switch to COMMITING state
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    DBEngine.beginTransaction();
                    if(dtLoginInfor.GetChanges()!= null && dtLoginInfor.GetChanges().Rows.Count>0)
                        {
                        if(!dtLoginInfor.Rows[0]["Password",DataRowVersion.Original].ToString().Equals(txtPassword.Text))
                        DBEngine.exec("SC_LoginInfo_Save",
                            CommonConst.A_LoginID, UserID,
                            "@LoginName", txtLoginName.Text,
                            "@Password", Encryption.EncryptText(txtPassword.Text,true),
                            "@EmployeeID", txtEmployeeID.Text,
                            "@DepartmentID", txtDepartmentID.EditValue);
                        }

                if (dtObjectList.GetChanges() != null && dtObjectList.GetChanges().Rows.Count > 0)
                    foreach (DataRow drObject in dtObjectList.GetChanges().Rows)
                    {
                        DBEngine.exec("SC_UserObjects_Save",
                            CommonConst.A_LoginID, UserID,
                            "@p_LoginID", dtLoginInfor.Rows[0][LoginID],
                            "@p_ObjectID", drObject[ObjectID_D],
                            "@p_FullAccess", drObject[Right_D]);
                    }
                if (dtSectionList.GetChanges() != null && dtSectionList.GetChanges().Rows.Count > 0)
                    foreach (DataRow drSec in dtSectionList.GetChanges().Rows)
                    {
                        DBEngine.exec("SC_UserSectViewInfo_Save",
                            CommonConst.A_LoginID, UserID,
                            "@p_LoginID", dtLoginInfor.Rows[0][LoginID],
                            "@p_DepartmentID", drSec[DepartmentID],
                            "@p_SectionID", drSec[SectionID],
                            "@p_ViewInfo",drSec[ViewInfo]);
                    }
                if (dtDepartmentList.GetChanges() != null && dtDepartmentList.GetChanges().Rows.Count > 0)
                    foreach (DataRow drDept in dtDepartmentList.GetChanges().Rows)
                    {
                        DBEngine.exec("SC_UserDeptViewInfo_Save",
                            CommonConst.A_LoginID, UserID,
                            "@p_LoginID", dtLoginInfor.Rows[0][LoginID],
                            "@p_DepartmentID", drDept[DepartmentID],
                            "@p_ViewInfo", drDept[ViewInfo]);
                    }
                    DBEngine.commit();
                }
                catch (Exception ex)
                {
                    // dtEmployeeInformation.RejectChanges();
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

                return false;
            }
            if (pCheck == 0 || pCheck == 1)
                UIMessage.ShowMessage(HPA.Common.CommonConst.DATASAVED_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                UIMessage.ShowMessage(HPA.Common.CommonConst.DELETE_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DirtyData = false;
            LoadLoginInfo();
            // commit successfully
            return true;
        }
        public override bool OnReset()
        {
            // TODO:  Add InsuranceInfo.OnReset implementation
            try
            {
                if (DirtyData == true)
                {
                    if (UIMessage.ShowMessage(5, MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        dtDepartmentList.RejectChanges();
                        dtObjectList.RejectChanges();
                        dtSectionList.RejectChanges();
                        grvDepartment.RefreshData();
                        grvSection.RefreshData();
                        
                        DirtyData = false;
                    }
                }
            }
            catch (Exception)
            {
                //HPA.Common.Helper.ShowException(e, this.Name + ".OnReset()", null);
                MessageBox.Show(this.Name + ".OnReset");
                return false;
            }

            return true;
        }

        private bool myInitializeData()
        {
            try
            {

                //Load Health Insurance data
                if (LoadLoginInfo())
                {
                    //Load contract type

                    //success full
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(String.Format("{0}/{1}.myInitializeData()", e.Message, this.Name));
                return false;
            }
            return true;
        }

        private bool LoadLoginInfo()
        {
            if (txtEmployeeID.Text.Trim().Equals(""))
                return false;
            else
            {
                DataTable dtFullName = DBEngine.execReturnDataTable("sp_hr_get_fullname", CommonConst.A_EmployeeID, txtEmployeeID.Text, CommonConst.A_LoginID,UserID);
                if (dtFullName != null && dtFullName.Rows.Count > 0)
                {
                    txtFullName.Text = dtFullName.Rows[0][0].ToString();
                }
                dtLoginInfor = DBEngine.execReturnDataTable("SC_LoginInfor",
                    CommonConst.A_EmployeeID,txtEmployeeID.Text, CommonConst.A_LoginID,UserID);
                if (dtLoginInfor.Rows.Count <= 0)
                {
                    UIMessage.ShowMessage("EmployeeNotExists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmployeeID.Focus();
                    return false;
                }
                BindingData();
                //if (dtLoginInfor.Rows[0][LoginID] != DBNull.Value)
                //{
                    //Load Department, section right management
                DataSet ds = new DataSet();
                ds = DBEngine.execReturnDataSet("SC_DeptSectView_List", CommonConst.A_LoginID, dtLoginInfor.Rows[0][LoginID]);
                dtDepartmentList = ds.Tables[0];
                dtDepartmentList.Columns[DepartmentCode].ReadOnly = true;
                dtDepartmentList.Columns[DepartmentName].ReadOnly = true;
                grdDepartment.DataSource = dtDepartmentList;
                dtSectionList = ds.Tables[1];
                dtSectionList.Columns[SectionCode].ReadOnly = true;
                dtSectionList.Columns[SectionName].ReadOnly = true;
                dvSectionList = dtSectionList.DefaultView;
                grdSection.DataSource = dvSectionList;

                //Load object right management

                dtObjectList = DBEngine.execReturnDataTable("SC_ObjectRightList", CommonConst.A_LoginID, dtLoginInfor.Rows[0][LoginID],
                    "@LanguageID", UIMessage.languageID);
                dtObjectList.Columns[Description].ReadOnly = true;
                dtObjectList.PrimaryKey = new DataColumn[]{dtObjectList.Columns[ObjectID_D]};
                trlObjectList.DataSource = dtObjectList;
                dtRightNameList = DBEngine.execReturnDataTable("SC_RightNameList","@LanguageID",UIMessage.languageID);
                rpeRight.DataSource = dtRightNameList;
                dtLoginInfor.RowChanged -= new DataRowChangeEventHandler(dtLoginInfor_RowChanged);
                dtLoginInfor.ColumnChanged -= new DataColumnChangeEventHandler(dtLoginInfor_ColumnChanged);
                dtObjectList.RowChanged -= new DataRowChangeEventHandler(dtObjectList_RowChanged);
                dtObjectList.ColumnChanged -= new DataColumnChangeEventHandler(dtObjectList_ColumnChanged);
                dtDepartmentList.RowChanged -= new DataRowChangeEventHandler(dtDepartmentList_RowChanged);
                dtDepartmentList.ColumnChanged -= new DataColumnChangeEventHandler(dtDepartmentList_ColumnChanged);
                dtSectionList.RowChanged -= new DataRowChangeEventHandler(dtSectionList_RowChanged);
                dtSectionList.ColumnChanged -= new DataColumnChangeEventHandler(dtSectionList_ColumnChanged);

                dtLoginInfor.RowChanged += new DataRowChangeEventHandler(dtLoginInfor_RowChanged);
                dtLoginInfor.ColumnChanged += new DataColumnChangeEventHandler(dtLoginInfor_ColumnChanged);
                dtObjectList.RowChanged += new DataRowChangeEventHandler(dtObjectList_RowChanged);
                dtObjectList.ColumnChanged += new DataColumnChangeEventHandler(dtObjectList_ColumnChanged);
                dtDepartmentList.RowChanged += new DataRowChangeEventHandler(dtDepartmentList_RowChanged);
                dtDepartmentList.ColumnChanged += new DataColumnChangeEventHandler(dtDepartmentList_ColumnChanged);
                dtSectionList.RowChanged += new DataRowChangeEventHandler(dtSectionList_RowChanged);
                dtSectionList.ColumnChanged += new DataColumnChangeEventHandler(dtSectionList_ColumnChanged);
                txtLoginName.Focus();
            }
            return true;
        }

        void dtSectionList_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            DirtyData = true;
        }

        void dtSectionList_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DirtyData = true;
        }

        void dtDepartmentList_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            DirtyData = true;
        }

        void dtDepartmentList_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DirtyData = true;
        }

        void dtObjectList_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            DirtyData = true;
        }

        void dtLoginInfor_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            DirtyData = true;
        }

        void dtObjectList_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            try
            {
                DirtyData = true;
                string strID = e.Row[ObjectID_D].ToString();
                // get all child row
                DataRow [] drChild = dtObjectList.Select(string.Format("ParentObjectID = '{0}'",strID));
                foreach (DataRow dr in drChild)
                {
                    dr[Right_D] = e.Row[Right_D];
                }
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "dtObjectList_RowChanged");
            }
        }

        void dtLoginInfor_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DirtyData = true;
        }

        private void BindingData()
        {
            dtLoginInfor.Rows[0].BeginEdit();
            txtDepartment.DataBindings.Clear();
            txtDepartmentID.DataBindings.Clear();
            txtLoginName.DataBindings.Clear();
            txtPassword.DataBindings.Clear();

            txtDepartment.DataBindings.Add(CommonConst.EDIT_VALUE, dtLoginInfor, DepartmentName);
            txtDepartmentID.DataBindings.Add(CommonConst.EDIT_VALUE, dtLoginInfor, DepartmentID);
            txtLoginName.DataBindings.Add(CommonConst.EDIT_VALUE, dtLoginInfor, LoginName);
            txtPassword.DataBindings.Add(CommonConst.EDIT_VALUE, dtLoginInfor, Password);
            dtLoginInfor.Rows[0].EndEdit();

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
                    LoadLoginInfo();
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
                LoadLoginInfo();
            }
        }

        
        private void ckbAllDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (dtDepartmentList == null || dtDepartmentList.Rows.Count <= 0)
                return;
            if (ckbAllDepartment.Checked)
            {
                //select all department
                foreach (DataRow drDept in dtDepartmentList.Rows)
                {
                    drDept[ViewInfo] = true;
                }
                grvDepartment.RefreshData();
            }
            else
            {
                //disselect all department
                foreach (DataRow drDept in dtDepartmentList.Rows)
                {
                    drDept[ViewInfo] = false;
                }
                grvDepartment.RefreshData();
            }
        }

        private void ckbAllModule_CheckedChanged(object sender, EventArgs e)
        {
            if (dtObjectList == null || dtObjectList.Rows.Count <= 0)
                return;
            if (ckbAllModule.Checked)
            {
                //select all department
                foreach (DataRow drModule in dtObjectList.Rows)
                {
                    drModule[Right_D] = 32;
                }
                trlObjectList.RefreshDataSource();
            }
            else
            {
                //disselect all department
                foreach (DataRow drModule in dtObjectList.Rows)
                {
                    drModule[Right_D] = 0;
                }
                trlObjectList.RefreshDataSource();
            }
        }

        private void grvDepartment_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (dtSectionList == null)
                return;
            string selectedDept = "";
            try
            {
                if (grvDepartment.GetSelectedRows().Length > 0)
                {
                    selectedDept = grvDepartment.GetDataRow(grvDepartment.GetSelectedRows()[0])[DepartmentID].ToString();
                    selectedDept = string.Format("{0} = {1}", DepartmentID, selectedDept);
                    dvSectionList.RowFilter = selectedDept;
                }

            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "grdDepartment_Click()");
            }
        }

        private void rpckbSectionManage_CheckedChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit ckb = (DevExpress.XtraEditors.CheckEdit)sender;
            if (ckb.CheckState == CheckState.Unchecked)
                ckbSectionAll.Checked = false;
            else
            {
                for (int i = 0; i < dtSectionList.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dtSectionList.Rows[i][ViewInfo]) == false)
                    {
                        ckbSectionAll.Checked = false;
                        return;
                    }
                    ckbSectionAll.Checked = true;
                }
            }
        }

        private void ckbSectionAll_Click(object sender, EventArgs e)
        {
            // get department ID list
            string strDeptList = getDepartmentIDList();
            if (strDeptList.Equals(""))
                return;
            DataRow[] drList = dtSectionList.Select(String.Format("{0} in ({1})", DepartmentID, strDeptList));
            if (grvSection.RowCount <= 0)
                return;
            if (ckbSectionAll.Checked)
            {
                foreach (DataRow dr in drList)
                {
                    dr[ViewInfo] = true;
                }
                //for (int i = 0; i < dtSectionList.Rows.Count; i++)
                //{
                //    dtSectionList.Rows[i][ViewInfo] = true;
                //}
            }
            else
            {
                foreach (DataRow dr in drList)
                {
                    dr[ViewInfo] = false;
                }
                //for (int i = 0; i < dtSectionList.Rows.Count; i++)
                //{
                //    dtSectionList.Rows[i][ViewInfo] = false;
                //}
            }
        }

        private string getDepartmentIDList()
        {
            string retValue = "";
            DataRow[] dtID = dtDepartmentList.Select(ViewInfo + "=1");
            if (dtID.Length <= 0)
                return retValue;
            foreach (DataRow dr in dtID)
            {
                retValue += string.Format("'{0}',", dr[DepartmentID]);
            }
            return retValue.Substring(0,retValue.Length-1);
        }

    }
}