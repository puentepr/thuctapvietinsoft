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

namespace HPA.Setting
{
    public partial class UserRight : DevExpress.XtraEditors.XtraForm
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
            if (e.KeyCode == Keys.F3)
            {
                
            }
        }


        private void LoadLoginInfo()
        {
            // tìm nhân viên có EmployeeID nhập vào
            var _EmployeeList = from a in dtData.tblEmployees
                                from b in dtData.tblDepartments
                                where ((a.DepartmentID == b.DepartmentID) && a.EmployeeID == txtEmployeeID.Text.Trim())
                                select new { a.FullName, b.DepartmentName };
            
            // đưa EmployeeID vào các textbox
            foreach (var temp in _EmployeeList)
            {
                txtFullName.Text = temp.FullName;
                txtDepartment.Text = temp.DepartmentName;
            }

            DataTable dt = null;
            EzSqlCollection.EzSql2 ex = new EzSqlCollection.EzSql2();
            DataSet ds = ex.execReturnDataSet("SC_DeptSectView_List", null);
            dt = ds.Tables[0];
            grdDepartment.DataSource = dt;

        }

        HPA.SQL.DataDaigramDataContext dtData = new SQL.DataDaigramDataContext();

        private void OnAdd()
        {

        }
    }
}