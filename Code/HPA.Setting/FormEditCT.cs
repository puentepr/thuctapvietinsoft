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
    public partial class FormEditCT : Form
    {
        HPA.SQL.DataDaigramDataContext dt = new SQL.DataDaigramDataContext();
        string id;
        string cap;
        public FormEditCT()
        {
            InitializeComponent();
        }

        private void FormEditCT_Load(object sender, EventArgs e)
        {
            Loaddata();
        }
        public void fundata(string ida, string capm)
        {
            id = ida;
            cap = capm;
        }
        private void Loaddata()
        {
            //if (cap == 0)
            //{
            //    //dataGridView1.DataSource = dt.tblCompanies.Skip(0).Take(1);
            //    //dataGridView1.Columns[11].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm:ss:tt";
            //}
            if (cap == "1")
            {
                dataGridView1.DataSource = (from p in dt.tblDivisions orderby p.DivisionID descending select p).Skip(0).Take(1);
                if (id == "-1")
                {

                    NewRows(4);
                }
            }
            else if (cap == "2")
            {
                dataGridView1.DataSource = (from p in dt.tblDepartments orderby p.DepartmentID descending select p).Skip(0).Take(1);
                if (id == "-1")
                {

                    NewRows(7);
                }
            }
            else if (cap == "3")
            {
                dataGridView1.DataSource = (from p in dt.tblSections orderby p.SectionID descending select p).Skip(0).Take(1);
                if (id == "-1")
                {

                    NewRows(7);
                }
            }
            else if (cap == "4")
            {
                dataGridView1.DataSource = (from p in dt.tblGroups orderby p.GroupID descending select p).Skip(0).Take(1);
                if (id == "-1")
                {

                    NewRows(7);
                }
            }
            dataGridView1.Columns[0].Visible = false;
        }
        private void NewRows(int so)
        {
            for (int i = 1; i < so; i++)
            {
                dataGridView1.Rows[0].Cells[i].Value = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Neu la cong ty
            //if (cap == 0)
            //{
            //    var update = dt.tblCompanies.First();
            //    update.CompanyFullName = dataGridView1.Rows[0].Cells[1].Value.ToString();
            //    update.CompanyFullNameEN = dataGridView1.Rows[0].Cells[2].Value.ToString();
            //    update.ComAcronymName = dataGridView1.Rows[0].Cells[3].Value.ToString();
            //    update.DirectorName = dataGridView1.Rows[0].Cells[4].Value.ToString();
            //    update.PhoneNumber = dataGridView1.Rows[0].Cells[5].Value.ToString();
            //    update.FaxNumber = dataGridView1.Rows[0].Cells[6].Value.ToString();
            //    update.BankAccount = dataGridView1.Rows[0].Cells[7].Value.ToString();
            //    update.Address = dataGridView1.Rows[0].Cells[8].Value.ToString();
            //    update.AddressEN = dataGridView1.Rows[0].Cells[9].Value.ToString();
            //    update.TaxRegNo = dataGridView1.Rows[0].Cells[10].Value.ToString();
            //    update.TaxRegDate = DateTime.Parse(dataGridView1.Rows[0].Cells[11].Value.ToString());
            //    update.Logo = dataGridView1.Rows[0].Cells[12].Value;
            //    dt.SubmitChanges();
            //}
            if (cap == "1")
            {
                Regex r = new Regex(@"d\+$");
                if (!HPA.Common.Methods.Kiemtrchuoi(dataGridView1.Rows[0].Cells[3].Value.ToString(), r))
                {
                    MessageBox.Show("ID phải là số", "Lỗi");

                }
                else if (dt.tblDivisions.Where(u => u.DivisionCode == dataGridView1.Rows[0].Cells[1].Value.ToString()).Count() > 0)
                {
                    MessageBox.Show("Code đã tồn tại", "Lỗi");
                }
                else if (id == "-1")
                {
                    HPA.SQL.tblDivision update = new SQL.tblDivision();
                    update.DivisionCode = dataGridView1.Rows[0].Cells[1].Value.ToString();
                    update.DivisionName = dataGridView1.Rows[0].Cells[2].Value.ToString();
                    update.BranchID = int.Parse(dataGridView1.Rows[0].Cells[3].Value.ToString());
                    dt.tblDivisions.InsertOnSubmit(update);
                    dt.SubmitChanges();
                    MessageBox.Show("Thêm dữ liệu mới thành công", "Thông báo");
                    NewRows(4);
                }
                else
                {
                    var update = dt.tblDivisions.Single(u => u.DivisionID.ToString() == id);
                    update.DivisionCode = dataGridView1.Rows[0].Cells[1].Value.ToString();
                    update.DivisionName = dataGridView1.Rows[0].Cells[2].Value.ToString();
                    update.BranchID = int.Parse(dataGridView1.Rows[0].Cells[3].Value.ToString());
                    dt.SubmitChanges();
                    MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
                }
            }
            //Neu la dp
            else if (cap == "2")
            {
                Regex r = new Regex(@"d\+$");
                if (!HPA.Common.Methods.Kiemtrchuoi(dataGridView1.Rows[0].Cells[1].Value.ToString(), r) || !HPA.Common.Methods.Kiemtrchuoi(dataGridView1.Rows[0].Cells[4].Value.ToString(), r))
                {
                    MessageBox.Show("ID phải là số", "Lỗi");

                }
                else if (dt.tblDepartments.Where(u => u.DepartmentCode == dataGridView1.Rows[0].Cells[2].Value.ToString()).Count() > 0)
                {
                    MessageBox.Show("Code đã tồn tại", "Lỗi");
                }
                else if (id == "-1")
                {
                    HPA.SQL.tblDepartment update = new SQL.tblDepartment();
                    update.DivisionID = int.Parse(dataGridView1.Rows[0].Cells[1].Value.ToString());
                    update.DepartmentCode = dataGridView1.Rows[0].Cells[2].Value.ToString();
                    update.DepartmentName = dataGridView1.Rows[0].Cells[3].Value.ToString();
                    update.Foreigner = int.Parse(dataGridView1.Rows[0].Cells[4].Value.ToString());
                    update.JapaneseName = dataGridView1.Rows[0].Cells[5].Value.ToString();
                    update.VietnameseName = dataGridView1.Rows[0].Cells[6].Value.ToString();
                    dt.tblDepartments.InsertOnSubmit(update);
                    dt.SubmitChanges();
                    MessageBox.Show("Thêm dữ liệu mới thành công", "Thông báo");
                    NewRows(7);
                }
                else
                {
                    var update = dt.tblDepartments.Single(u => u.DepartmentID.ToString() == id);
                    update.DivisionID = int.Parse(dataGridView1.Rows[0].Cells[1].Value.ToString());
                    update.DepartmentCode = dataGridView1.Rows[0].Cells[2].Value.ToString();
                    update.DepartmentName = dataGridView1.Rows[0].Cells[3].Value.ToString();
                    update.Foreigner = int.Parse(dataGridView1.Rows[0].Cells[4].Value.ToString());
                    update.JapaneseName = dataGridView1.Rows[0].Cells[5].Value.ToString();
                    update.VietnameseName = dataGridView1.Rows[0].Cells[6].Value.ToString();
                    dt.SubmitChanges();
                    MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
                }
            }
            //Neu la sc
            else if (cap == "3")
            {
                Regex r = new Regex(@"d\+$");
                if (!HPA.Common.Methods.Kiemtrchuoi(dataGridView1.Rows[0].Cells[1].Value.ToString(), r) || !HPA.Common.Methods.Kiemtrchuoi(dataGridView1.Rows[0].Cells[6].Value.ToString(), r))
                {
                    MessageBox.Show("ID phải là số", "Lỗi");

                }
                else if (dt.tblSections.Where(u => u.SectionCode == dataGridView1.Rows[0].Cells[2].Value.ToString()).Count() > 0)
                {
                    MessageBox.Show("Code đã tồn tại", "Lỗi");
                }
                else if (id == "-1")
                {
                    HPA.SQL.tblSection update = new SQL.tblSection();
                    update.DepartmentID = int.Parse(dataGridView1.Rows[0].Cells[1].Value.ToString());
                    update.SectionCode = dataGridView1.Rows[0].Cells[2].Value.ToString();
                    update.SectionName = dataGridView1.Rows[0].Cells[3].Value.ToString();
                    update.JapaneseName = dataGridView1.Rows[0].Cells[4].Value.ToString();
                    update.VietnameseName = dataGridView1.Rows[0].Cells[5].Value.ToString();
                    update.Foreigner = int.Parse(dataGridView1.Rows[0].Cells[6].Value.ToString());
                    dt.tblSections.InsertOnSubmit(update);
                    dt.SubmitChanges();
                    MessageBox.Show("Thêm dữ liệu mới thành công", "Thông báo");
                    NewRows(7);
                }
                else
                {
                    var update = dt.tblSections.Single(u => u.DepartmentID.ToString() == id);
                    update.DepartmentID = int.Parse(dataGridView1.Rows[0].Cells[1].Value.ToString());
                    update.SectionCode = dataGridView1.Rows[0].Cells[2].Value.ToString();
                    update.SectionName = dataGridView1.Rows[0].Cells[3].Value.ToString();
                    update.JapaneseName = dataGridView1.Rows[0].Cells[4].Value.ToString();
                    update.VietnameseName = dataGridView1.Rows[0].Cells[5].Value.ToString();
                    update.Foreigner = int.Parse(dataGridView1.Rows[0].Cells[6].Value.ToString());
                    dt.tblSections.InsertOnSubmit(update);
                    dt.SubmitChanges();
                    MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
                }
            }
            //Neu la Gr
            else if (cap == "4")
            {
                Regex r = new Regex(@"d\+$");
                if (!HPA.Common.Methods.Kiemtrchuoi(dataGridView1.Rows[0].Cells[1].Value.ToString(), r) || !HPA.Common.Methods.Kiemtrchuoi(dataGridView1.Rows[0].Cells[6].Value.ToString(), r))
                {
                    MessageBox.Show("ID phải là số", "Lỗi");

                }
                else if (dt.tblGroups.Where(u => u.GroupCode == dataGridView1.Rows[0].Cells[2].Value.ToString()).Count() > 0)
                {
                    MessageBox.Show("Code đã tồn tại", "Lỗi");
                }
                else if (id == "-1")
                {
                    HPA.SQL.tblGroup update = new SQL.tblGroup();
                    update.SectionID = int.Parse(dataGridView1.Rows[0].Cells[1].Value.ToString());
                    update.GroupCode = dataGridView1.Rows[0].Cells[2].Value.ToString();
                    update.GroupName = dataGridView1.Rows[0].Cells[3].Value.ToString();
                    update.JapaneseName = dataGridView1.Rows[0].Cells[4].Value.ToString();
                    update.VietnameseName = dataGridView1.Rows[0].Cells[5].Value.ToString();
                    update.Foreigner = int.Parse(dataGridView1.Rows[0].Cells[6].Value.ToString());
                    dt.tblGroups.InsertOnSubmit(update);
                    dt.SubmitChanges();
                    MessageBox.Show("Thêm dữ liệu mới thành công", "Thông báo");
                    NewRows(7);
                }
                else
                {
                    var update = dt.tblGroups.Single(u => u.GroupID.ToString() == id);
                    update.SectionID = int.Parse(dataGridView1.Rows[0].Cells[1].Value.ToString());
                    update.GroupCode = dataGridView1.Rows[0].Cells[2].Value.ToString();
                    update.GroupName = dataGridView1.Rows[0].Cells[3].Value.ToString();
                    update.JapaneseName = dataGridView1.Rows[0].Cells[4].Value.ToString();
                    update.VietnameseName = dataGridView1.Rows[0].Cells[5].Value.ToString();
                    update.Foreigner = int.Parse(dataGridView1.Rows[0].Cells[6].Value.ToString());
                    dt.tblGroups.InsertOnSubmit(update);
                    dt.SubmitChanges();
                    MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            FormCautrucCongty ct = new FormCautrucCongty();
            ct.Show();
        }
            
    }
}
