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
    public partial class FormCautrucCongty : HPA.CommonForm.BaseForm
    {
        HPA.SQL.DataDaigramDataContext dt = new SQL.DataDaigramDataContext();
        string id, cap;
        bool b;
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
            treeView1.ExpandAll();
            treeView1.SelectedNode = goc;
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void Loaddata()
        {
            if (cap == "0")
            {
                dtgrCautruc.DataSource = dt.tblDivisions.Select(n => n);
                dtgrCautruc.Columns[0].ReadOnly = true;
            }
            if (cap == "1")
            {
                dtgrCautruc.DataSource = from p in dt.tblDepartments where p.DivisionID.ToString() == id select p;
                dtgrCautruc.Columns.RemoveAt(dtgrCautruc.ColumnCount - 1);
                dtgrCautruc.Columns[0].ReadOnly = true;
                dtgrCautruc.Columns[1].ReadOnly = false;
            }
            else if (cap == "2")
            {
                dtgrCautruc.DataSource = from p in dt.tblSections where p.DepartmentID.ToString() == id select p;
                dtgrCautruc.Columns.RemoveAt(dtgrCautruc.ColumnCount - 1);
                dtgrCautruc.Columns[0].ReadOnly = true;
                dtgrCautruc.Columns[1].ReadOnly = false;

            }
            else if (cap == "3")
            {
                dtgrCautruc.DataSource = from p in dt.tblGroups where p.SectionID.ToString() == id select p;
                dtgrCautruc.Columns.RemoveAt(dtgrCautruc.ColumnCount - 1);
                dtgrCautruc.Columns[0].ReadOnly = true;
                dtgrCautruc.Columns[1].ReadOnly = false;

            }
            else if (cap == "4")
            {
                dtgrCautruc.DataSource = from p in dt.tblGroups where p.GroupID.ToString() == id select p;
                dtgrCautruc.Columns.RemoveAt(dtgrCautruc.ColumnCount - 1);
                dtgrCautruc.Columns[0].ReadOnly = true;
                dtgrCautruc.Columns[1].ReadOnly = false;

            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            cap = treeView1.SelectedNode.Tag.ToString();
            id = treeView1.SelectedNode.Name.ToString();
            Loaddata();
        }

        private void dtgrCautruc_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int count=0;
            for (int k = 0; k < dtgrCautruc.ColumnCount; k++)
            {
                if (dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[k].Value == null)
                {
                    count++;
                    dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[k].Style.BackColor = Color.LightBlue;
                }
                else
                {
                    dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[k].Style.BackColor = Color.White;
                }
            }
            int hang = int.Parse(dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[0].Value.ToString());
            if (count == 0)
            {
                if (cap == "0")
                {
                    if (hang == 0)
                    {
                        if (dt.tblDivisions.Where(u => u.DivisionCode == dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[1].Value.ToString()).Count() > 0)
                        {
                            MessageBox.Show("Code đã tồn tại", "Lỗi");
                        }
                        else
                        {
                            HPA.SQL.tblDivision update = new SQL.tblDivision();
                            update.DivisionCode = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[1].Value.ToString();
                            update.DivisionName = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[2].Value.ToString();
                            update.BranchID = int.Parse(dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[3].Value.ToString());
                            dt.tblDivisions.InsertOnSubmit(update);
                            dt.SubmitChanges();
                            dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[0].Value = dt.tblDivisions.Max(u => u.DivisionID);
                        }
                    }
                    else
                    {
                        var update = dt.tblDivisions.Single(u => u.DivisionID == hang);
                        update.DivisionCode = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[1].Value.ToString();
                        update.DivisionName = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[2].Value.ToString();
                        update.BranchID = int.Parse(dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[3].Value.ToString());
                        dt.SubmitChanges();
                    }
                }
                //Neu la dp
                else if (cap == "1")
                {
                    if (hang == 0)
                    {
                        if (dt.tblDepartments.Where(u => u.DepartmentCode == dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[2].Value.ToString()).Count() > 0)
                        {
                            MessageBox.Show("Code đã tồn tại", "Lỗi");
                        }
                        else
                        {
                            HPA.SQL.tblDepartment update = new SQL.tblDepartment();
                            update.DivisionID = int.Parse(dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[1].Value.ToString());
                            update.DepartmentCode = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[2].Value.ToString();
                            update.DepartmentName = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[3].Value.ToString();
                            update.Foreigner = int.Parse(dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[4].Value.ToString());
                            update.JapaneseName = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[5].Value.ToString();
                            update.VietnameseName = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[6].Value.ToString();
                            dt.tblDepartments.InsertOnSubmit(update);
                            dt.SubmitChanges();
                            dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[0].Value = dt.tblDepartments.Max(u => u.DepartmentID);
                        }
                    }
                    else
                    {
                        var update = dt.tblDepartments.Single(u => u.DepartmentID == hang);
                        update.DivisionID = int.Parse(dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[1].Value.ToString());
                        update.DepartmentCode = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[2].Value.ToString();
                        update.DepartmentName = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[3].Value.ToString();
                        update.Foreigner = int.Parse(dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[4].Value.ToString());
                        update.JapaneseName = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[5].Value.ToString();
                        update.VietnameseName = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[6].Value.ToString();
                        dt.SubmitChanges();
                    }
                }
                //Neu la sc
                else if (cap == "2")
                {
                    if (hang == 0)
                    {
                        if (dt.tblSections.Where(u => u.SectionCode == dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[2].Value.ToString()).Count() > 0)
                        {
                            MessageBox.Show("Code đã tồn tại", "Lỗi");
                        }
                        else
                        {
                            HPA.SQL.tblSection update = new SQL.tblSection();
                            update.DepartmentID = int.Parse(dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[1].Value.ToString());
                            update.SectionCode = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[2].Value.ToString();
                            update.SectionName = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[3].Value.ToString();
                            update.JapaneseName = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[4].Value.ToString();
                            update.VietnameseName = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[5].Value.ToString();
                            update.Foreigner = int.Parse(dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[6].Value.ToString());
                            dt.tblSections.InsertOnSubmit(update);
                            dt.SubmitChanges();
                            dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[0].Value = dt.tblSections.Max(u => u.SectionID);
                        }

                    }
                    else
                    {
                        var update = dt.tblSections.Single(u => u.DepartmentID == hang);
                        update.DepartmentID = int.Parse(dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[1].Value.ToString());
                        update.SectionCode = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[2].Value.ToString();
                        update.SectionName = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[3].Value.ToString();
                        update.JapaneseName = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[4].Value.ToString();
                        update.VietnameseName = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[5].Value.ToString();
                        update.Foreigner = int.Parse(dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[6].Value.ToString());
                        dt.tblSections.InsertOnSubmit(update);
                        dt.SubmitChanges();
                    }
                }
                //Neu la Gr
                else if (cap == "3" || cap == "4")
                {
                    if (hang == 0)
                    {
                        if (dt.tblGroups.Where(u => u.GroupCode == dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[2].Value.ToString()).Count() > 0)
                        {
                            MessageBox.Show("Code đã tồn tại", "Lỗi");
                        }
                        else
                        {
                            HPA.SQL.tblGroup update = new SQL.tblGroup();
                            update.SectionID = int.Parse(dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[1].Value.ToString());
                            update.GroupCode = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[2].Value.ToString();
                            update.GroupName = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[3].Value.ToString();
                            update.JapaneseName = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[4].Value.ToString();
                            update.VietnameseName = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[5].Value.ToString();
                            update.Foreigner = int.Parse(dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[6].Value.ToString());
                            dt.tblGroups.InsertOnSubmit(update);
                            dt.SubmitChanges();
                            dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[0].Value = dt.tblGroups.Max(u => u.GroupID);
                        }
                    }
                    else
                    {
                        var update = dt.tblGroups.Single(u => u.GroupID == hang);
                        update.SectionID = int.Parse(dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[1].Value.ToString());
                        update.GroupCode = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[2].Value.ToString();
                        update.GroupName = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[3].Value.ToString();
                        update.JapaneseName = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[4].Value.ToString();
                        update.VietnameseName = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[5].Value.ToString();
                        update.Foreigner = int.Parse(dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[6].Value.ToString());
                        dt.tblGroups.InsertOnSubmit(update);
                        dt.SubmitChanges();
                    }
                }
            }
           
      }
        
    }
}
