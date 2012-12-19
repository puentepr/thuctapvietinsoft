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
            if (txtEmployeeID.Text != "")
            {
                LoadLoginInfo();
            }
        }

        private void txtEmployeeID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                
            }
        }
        

        private bool LoadLoginInfo()
        {
            try
            {
                var _EmployeeList = from a in dtData.SC_LoginInfor(txtEmployeeID.Text.Trim(), HPA.Common.StaticVars.LoginID)
                                    where a.EmployeeID == txtEmployeeID.Text.Trim()
                                    select new { a.FullName, a.DepartmentName };
                foreach (var temp in _EmployeeList)
                {
                    txtFullName.Text = temp.FullName;
                    txtDepartment.Text = temp.DepartmentName;
                }
                return true;
            }
            catch
            {
                MessageBox.Show("Không tìm thấy");
                return false;
            }
        }

        HPA.SQL.DataDaigramDataContext dtData = new SQL.DataDaigramDataContext();
    }
}