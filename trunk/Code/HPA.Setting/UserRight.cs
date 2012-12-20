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
            // tìm tên nhân viên có EmployeeID nhập vào
            var _EmployeeInfo = from e in dtData.tblEmployees
                                from d in dtData.tblDepartments
                                where ((e.DepartmentID == d.DepartmentID) && (e.EmployeeID == txtEmployeeID.Text))
                                select new { e.FullName, d.DepartmentName };
            // đưa Fullname vào txtFullName
            foreach (var temp in _EmployeeInfo)
            {
                txtFullName.Text = temp.FullName;
                txtDepartment.Text = temp.DepartmentName;
            }

            

            if (txtFullName.Text == "")
            {
                txtEmployeeID.Focus();
                MessageBox.Show("EmployeeNotExists","Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            var a = from b in dtData.tblSC_DepartmentViews
                    from c in dtData.tblDepartments
                    where (b.LoginID == 3 && b.DepartmentID == c.DepartmentID)
                    select new {c.DepartmentCode,c.DepartmentName,b.ViewInfo};

            
            grdDepartment.DataSource = a;
        }

        HPA.SQL.DataDaigramDataContext dtData = new SQL.DataDaigramDataContext();

        private void OnAdd()
        {

        }
    }
}