using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HPA.Setting
{
    public partial class FormCautrucCongty : Form
    {
        HPA.SQL.DataDaigramDataContext dt = new SQL.DataDaigramDataContext();
        //public delegate void passdata(int id,int cap);
        public delegate void passdata(string id, string cap);
        public FormCautrucCongty()
        {
            InitializeComponent();
        }
        private void FormCautrucCongty_Load(object sender, EventArgs e)
        {
            CapnhatTree();
        }
        private void CapnhatTree()
        {
            treeView1.Nodes.Clear();
            //Lay ten menugoc
            var cp = dt.tblCompanies.First();
            TreeNode goc, cap1, cap2, cap3, cap4;
            goc = treeView1.Nodes.Add(cp.CompanyFullName);
            goc.Tag = 0;
            goc.Name = cp.CompanyID.ToString();
            //Load danh sach Division
            var dv = dt.tblDivisions.Select(n => n);
            foreach (var i in dv)
            {
                cap1 = goc.Nodes.Add(i.DivisionName);
                cap1.Tag = 1;
                cap1.Name = i.DivisionID.ToString();
                var node2 = from q in dt.tblDepartments where q.DivisionID == i.DivisionID select q;
                foreach (var k in node2)
                {
                    cap2 = cap1.Nodes.Add(k.DepartmentName);
                    cap2.Tag = 2;
                    cap2.Name = k.DepartmentID.ToString();
                    var node3 = from q in dt.tblSections where q.DepartmentID == k.DepartmentID select q;
                    foreach (var t in node3)
                    {
                        cap3 = cap2.Nodes.Add(t.SectionName);
                        cap3.Tag = 3;
                        cap3.Name = t.SectionID.ToString();
                        var node4 = from q in dt.tblGroups where q.SectionID == t.SectionID select q;
                        foreach (var r in node4)
                        {
                            cap4 = cap3.Nodes.Add(r.GroupName);
                            cap4.Tag = 4;
                            cap4.Name = r.GroupID.ToString();
                        }
                    }
                }

            }
            treeView1.SelectedNode = goc;
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            if (e.ClickedItem.Text == "Add Division")
            {
                this.Close();
                FormDivision dv = new FormDivision();
                dv.Show();
            }
            else if (e.ClickedItem.Text == "Edit Division")
            {
                //int id = int.Parse(treeView1.SelectedNode.Name);
                //int cap = int.Parse(treeView1.Tag.ToString());
                string id = treeView1.SelectedNode.Name;
                string cap = treeView1.SelectedNode.Tag.ToString();
                this.Close();
                FormEditCT fed = new FormEditCT();
                passdata pa = new passdata(fed.fundata);
                pa(id,cap);
                fed.Show();
            }
            else if (e.ClickedItem.Text == "Delete Division")
            {
                DialogResult r = MessageBox.Show("Sau khi xóa không thể hồi phục, bạn chắc chắn muốn xóa", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    var delete = dt.tblDivisions.Single(u => u.DivisionID.ToString() == treeView1.SelectedNode.Name);
                    dt.tblDivisions.DeleteOnSubmit(delete);
                    dt.SubmitChanges();
                    MessageBox.Show("Xóa dữ liệu thành công", "Thông báo");
                    CapnhatTree();
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            contextMenuStrip1.Items.Clear();
            if (treeView1.SelectedNode.Tag.ToString() == "0")
            {
                
                contextMenuStrip1.Items.Add("Add Division");
            }
            else if (treeView1.SelectedNode.Tag.ToString() == "1")
            {
                contextMenuStrip1.Items.Add("Edit Division");
                contextMenuStrip1.Items.Add("Delete Division");
                contextMenuStrip1.Items.Add("Add Department");
                //dataGridView2.DataSource = from u in dt.tblDivisions where u.DivisionID.ToString() == ten select u;
            }
            else if (treeView1.SelectedNode.Tag.ToString() == "2")
            {
                contextMenuStrip1.Items.Add("Edit Department");
                contextMenuStrip1.Items.Add("Delete Department");
                contextMenuStrip1.Items.Add("Add Section");
                //dataGridView3.DataSource = from u in dt.tblDepartments where u.DepartmentID.ToString() == ten select u;
            }
            else if (treeView1.SelectedNode.Tag.ToString() == "3")
            {
                contextMenuStrip1.Items.Add("Edit Section");
                contextMenuStrip1.Items.Add("Delete Section");
                contextMenuStrip1.Items.Add("Add Group");
                //dataGridView4.DataSource = from u in dt.tblSections where u.SectionID.ToString() == ten select u;
            }
            else if (treeView1.SelectedNode.Tag.ToString() == "4")
            {
                contextMenuStrip1.Items.Add("Edit Group");
                contextMenuStrip1.Items.Add("Delete Group");
                //dataGridView5.DataSource = from u in dt.tblGroups where u.GroupID.ToString() == ten select u;
            }
        }
    }
}
