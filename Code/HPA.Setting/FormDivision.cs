using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace HPA.Setting
{
    public partial class FormDivision : Form
    {
        HPA.SQL.DataDaigramDataContext dt = new SQL.DataDaigramDataContext();
        int id=0;
        public FormDivision()
        {
            InitializeComponent();
        }
        public void Fundata(int a)
        {
            id = a;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Regex t = new Regex(@"^\d+$");
            bool b = HPA.Common.Methods.Kiemtrchuoi(txtBrachID.Text, t);
            if (txtCode.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("Thông tin không đầy đủ", "Lỗi");
            }
            else if (!b)
            {
                MessageBox.Show("BranchID phải là số", "Lỗi");
            }
            else if (dt.tblDivisions.Where(u => u.DivisionCode == txtCode.Text).Count() > 0)
            {
                DialogResult r = MessageBox.Show("Chi nhánh này đã tồn tại.Bạn có muốn cập nhật", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.OK)
                {
                    var update = dt.tblDivisions.Single(u => u.DivisionCode == txtCode.Text);
                    update.DivisionName = txtName.Text;
                    update.BranchID = int.Parse(txtBrachID.Text);
                    dt.SubmitChanges();
                    MessageBox.Show("Cập nhật chi nhánh mới thành công", "Thông báo");
                }
            }
            else
            {
                HPA.SQL.tblDivision dv = new SQL.tblDivision();
                dv.DivisionName = txtName.Text;
                dv.DivisionCode = txtCode.Text;
                if (txtBrachID.Text != "")
                { dv.BranchID = int.Parse(txtBrachID.Text); }
                dt.tblDivisions.InsertOnSubmit(dv);
                dt.SubmitChanges();
                MessageBox.Show("Thêm chi nhánh mới thành công", "Thông báo");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            FormCautrucCongty fct = new FormCautrucCongty();
            fct.Show();
        }

        private void FormDivision_Load(object sender, EventArgs e)
        {
            if (id != 0)
            {
                var i = dt.tblDivisions.Single(u => u.DivisionID == id);
                txtCode.Text = i.DivisionCode;
                txtName.Text = i.DivisionName;
                txtBrachID.Text = i.BranchID.ToString();
            }
        }
    }
}
