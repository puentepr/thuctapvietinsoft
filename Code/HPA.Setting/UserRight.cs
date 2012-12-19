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
            var _EmployeeList = from a in dtData.SC_LoginInfor("90003",3)
                                where a.EmployeeID == txtEmployeeID.Text.Trim()
                                select new { a.FullName };
            gridControl1.DataSource = _EmployeeList;
        }

        HPA.SQL.DataDaigramDataContext dtData = new SQL.DataDaigramDataContext();
    }
}