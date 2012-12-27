using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Linq;
using System.Linq;
using System.Data.SqlClient;
using HPA.Common;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace HPA.Setting
{
    public partial class UserRight : HPA.CommonForm.BaseForm
    {
        public UserRight()
        {
            InitializeComponent();
        }

        private void UserRight_Load(object sender, EventArgs e)
        {
            Control.ControlCollection ctrs = this.Controls;
            HPA.Common.Methods.ChangeLanguage(ref ctrs);
            txtEmployeeID.Focus();
        }

        private void txtEmployeeID_Leave(object sender, EventArgs e)
        {
            LoadLoginInfo();
        }


        private void txtEmployeeID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadLoginInfo();
            }
        }

        private bool LoadLoginInfo()
        {
            // tìm tên nhân viên có EmployeeID nhập vào

            dtLoginInfo = DBEngine.execReturnDataTable(@"SC_LoginInfor",Common.CommonConst.A_EmployeeID,txtEmployeeID.Text,Common.CommonConst.A_LoginID,Common.StaticVars.LoginID);
            if (dtLoginInfo.Rows.Count <= 0 || txtEmployeeID.Text == "")
            {
                Methods.ShowMessage("EmployeeNotExists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmployeeID.Focus();
                return false;
            }
            
            // Đọc dữ liệu vào các control
            txtFullName.Text = dtLoginInfo.Rows[0][CommonConst.FullName].ToString();
            txtDepartment.Text = dtLoginInfo.Rows[0][CommonConst.DepartmentName].ToString();

            if (String.IsNullOrEmpty(dtLoginInfo.Rows[0][strLoginID].ToString()))
            {
                txtLoginName.ResetText();
                txtPassword.ResetText();
                grdDepartment.DataSource = null;
                grdSection.DataSource = null;
                trlObjectList.DataSource = null;
                grdDepartment.RefreshDataSource();
                grdSection.RefreshDataSource();
                trlObjectList.RefreshDataSource();
            }
            else
            {
                txtLoginName.Text = dtLoginInfo.Rows[0][strLoginName].ToString();
                txtPassword.Text = Encryption.EncryptText(dtLoginInfo.Rows[0][CommonConst.Password].ToString(), true);
                // Đọc dữ liệu vào gridcontrol Department
                dsDepartment = DBEngine.execReturnDataSet(@"SC_DeptSectView_List", CommonConst.A_LoginID, dtLoginInfo.Rows[0][strLoginID]);
                dtDepartment = dsDepartment.Tables[0];
                grdDepartment.DataSource = dtDepartment.DefaultView;

                // Đọc dữ liệu vào gridcontrol Section
                dtSection = dsDepartment.Tables[1];
                grdSection.DataSource = dtSection.DefaultView;

                // Đọc dữ liệu vào treelist UserRight
                dtObjectList = DBEngine.execReturnDataTable(@"SC_ObjectRightList", CommonConst.A_LoginID, dtLoginInfo.Rows[0][strLoginID],
                                        strLanguageID, StaticVars.LanguageID);

                dtObjectList.PrimaryKey = new DataColumn[] { dtObjectList.Columns[strObjectID] };
                trlObjectList.DataSource = dtObjectList;

                dtObjectList.RowChanged += new DataRowChangeEventHandler(dtObjectList_RowChanged);

                dtRightName = DBEngine.execReturnDataTable(@"SC_RightNameList", strLanguageID, StaticVars.LanguageID);
                rpeRightNames.DataSource = dtRightName;

                // Enable các control
                if (txtFullName.Text == "admin")
                {
                    btnFWAdd.Enabled = false;
                    btnFWDelete.Enabled = false;
                    btnFWSave.Enabled = true;
                    btnFWReset.Enabled = true;
                }
                
                if (txtLoginName.Text == "")
                {
                    btnFWAdd.Enabled = true;
                    btnFWDelete.Enabled = false;
                    btnFWSave.Enabled = true;
                    btnFWReset.Enabled = true;
                }

                if (txtLoginName.Text != "" && txtFullName.Text != "admin")
                {
                    btnFWAdd.Enabled = false;
                    btnFWDelete.Enabled = true;
                    btnFWSave.Enabled = true;
                    btnFWReset.Enabled = true;
                }
            }
            return true;
        }

        private void dtObjectList_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            string strObjID = e.Row[strObjectID].ToString();
            // tìm các datarow con của row có ID strObjID
            DataRow[] drChild = dtObjectList.Select(string.Format("ParentObjectID = '{0}'", strObjID));
            foreach (DataRow dtRow in drChild)
            {
                dtRow["Right"] = e.Row["Right"];
            }
            trlObjectList.Refresh();
        }



        #region VARIABLES
        DataSet dsDepartment = null;

        DataTable dtLoginInfo = null;
        DataTable dtDepartment = null;
        DataTable dtSection = null;
        DataTable dtObjectList = null;
        DataTable dtRightName = null;

        const string strObjectID = "ObjectID";
        const string strLanguageID = "@LanguageID";
        const string strLoginName = "LoginName";
        const string strLoginID = "LoginID";
        const string strViewInfo = "ViewInfo";
        const string strDepartmentID = "DepartmentID";
        const string strSectionID = "SectionID";
        const string AdminRight = @"AdminRight";
        #endregion

        private void ckbAllDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckbAllDepartment.Checked)
            {
                foreach (DataRow dtRow in dtDepartment.Rows)
                {
                    dtRow[strViewInfo] = 0;
                }
            }
            else
            {
                foreach (DataRow dtRow in dtDepartment.Rows)
                {
                    dtRow[strViewInfo] = 1;
                }
            }
            grdDepartment.RefreshDataSource();
        }

        public void CreateNode(TreeList tl, DataTable dt)
        {
            tl.BeginUnboundLoad();
            // Create root
            TreeListNode parentNode = null;
            foreach (DataRow dtRowParent in dt.Rows)
            {
                TreeListNode rootNode = null;
                if (dtRowParent["ParentObjectID"].ToString() == "0")
                {
                    rootNode = tl.AppendNode(new object[] { dtRowParent["Description"], dtRowParent["Right"] }, parentNode);
                    CreateNodeChild(tl, rootNode, dt, dtRowParent);
                }
            }
            tl.EndUnboundLoad();
        }

        public void CreateNodeChild(TreeList tl, TreeListNode tlParentNode, DataTable dt, DataRow dtRow)
        {
            foreach (DataRow dtRowChild in dt.Rows)
            {
                if (String.Compare(dtRowChild["ParentObjectID"].ToString(), dtRow["ObjectID"].ToString()) == 0)
                {
                    TreeListNode childNode = tl.AppendNode(new object[] { dtRowChild["Description"], dtRowChild["Right"] }, tlParentNode);
                    CreateNodeChild(tl, childNode, dt, dtRowChild);
                }
            }
        }

        private void ckbSectionAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckbSectionAll.Checked)
            {
                foreach (DataRow dtRow in dtSection.Rows)
                {
                    dtRow[strViewInfo] = 0;
                }
            }
            else
            {
                foreach (DataRow dtRow in dtSection.Rows)
                {
                    dtRow[strViewInfo] = 1;
                }
            }
            grdSection.RefreshDataSource();
        }

        private void ckbAllModule_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckbAllModule.Checked)
            {
                foreach (DataRow dtRow in dtObjectList.Rows)
                {
                    dtRow["Right"] = 0;
                }
            }
            else
            {
                foreach (DataRow dtRow in dtObjectList.Rows)
                {
                    dtRow["Right"] = 32;
                }
            }
            trlObjectList.RefreshDataSource();
        }

        private void grvDepartment_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            
        }

        public void Save()
        {
            bool success = false;
            try
            {
                DBEngine.beginTransaction();
                //if (dtLoginInfo.GetChanges() != null && dtLoginInfo.GetChanges().Rows.Count > 0)
                {
                    DBEngine.exec("SC_LoginInfo_Save", CommonConst.A_LoginID, StaticVars.LoginID,
                                    "@LoginName", txtLoginName.Text,
                                    "@Password", Encryption.EncryptText(txtPassword.Text, true),
                                    "@EmployeeID", txtEmployeeID.Text,
                                    "@DepartmentID", dtLoginInfo.Rows[0][strDepartmentID].ToString());
                }
                if (dtObjectList.GetChanges() != null && dtObjectList.GetChanges().Rows.Count > 0)
                {
                    foreach(DataRow dtRow in dtObjectList.Rows)
                    {
                        DBEngine.exec("SC_UserObjects_Save",
                                        CommonConst.A_LoginID, StaticVars.LoginID,
                                        "@p_LoginID",dtLoginInfo.Rows[0][strLoginID],
                                        "@p_ObjectID",dtRow[strObjectID],
                                        "@p_FullAccess",dtRow["Right"]);
                    }
                }
                if (dtDepartment.GetChanges() != null && dtDepartment.GetChanges().Rows.Count > 0)
                {
                    foreach (DataRow dtRow in dtDepartment.Rows)
                    {
                        DBEngine.exec("SC_UserDeptViewInfo_Save",
                                        CommonConst.A_LoginID, StaticVars.LoginID,
                                        "@p_LoginID", dtLoginInfo.Rows[0][strLoginID],
                                        "@p_DepartmentID", dtRow[strDepartmentID],
                                        "@p_ViewInfo", dtRow[strViewInfo]);
                    }
                }
                if (dtSection.GetChanges() != null && dtSection.GetChanges().Rows.Count > 0)
                {
                    foreach (DataRow dtRow in dtSection.Rows)
                    {
                        DBEngine.exec("SC_UserSectViewInfo_Save",
                                        CommonConst.A_LoginID, StaticVars.LoginID,
                                        "@p_LoginID", dtLoginInfo.Rows[0][strLoginID],
                                        "@p_DepartmentID",dtRow[strDepartmentID],
                                        "@p_SectionID", dtRow[strSectionID],
                                        "@p_ViewInfo", dtRow[strViewInfo]);
                    }
                }
                DBEngine.commit();
                LoadLoginInfo();
                success = true;
            }
            catch
            {
                DBEngine.rollback();
                success = false;
            }

            if (success)
            {
                Methods.ShowMessage(Common.CommonConst.DATASAVED_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Methods.ShowMessage(Common.CommonConst.DELETE_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }
        }

        public void Reset()
        {
            LoadLoginInfo();
        }

        private void btnFWReset_Click(object sender, EventArgs e)
        {
            if (Methods.ShowMessage("5", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Reset();
            }
        }

        private void btnFWSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        public void Delete()
        {
            if (dtLoginInfo.Rows[0][AdminRight] != DBNull.Value && Convert.ToBoolean(dtLoginInfo.Rows[0][AdminRight]) == true)
            {
                Methods.ShowMessage("CANNOT_DELETE_ADMIN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Methods.ShowMessage("3", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                DBEngine.beginTransaction();
                DBEngine.exec("SC_User_Delete", CommonConst.A_LoginID, StaticVars.LoginID, "@p_LoginID", dtLoginInfo.Rows[0][strLoginID]);
                DBEngine.commit();
                Methods.ShowMessage(Common.CommonConst.DELETE_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                DBEngine.rollback();
                Methods.ShowError(ex);
            }
        }

        private void btnFWDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

    }
}