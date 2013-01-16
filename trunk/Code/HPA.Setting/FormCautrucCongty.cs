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
        DataTable dtDivision = null;
        DataTable dtDepartment = null;
        DataTable dtSection = null;
        DataTable dtGroup = null;
        DataView dvDivision = null;
        DataView dvDepartment = null;
        DataView dvSection = null;
        DataView dvGroup = null;

        string id, cap;
        bool b;
        public FormCautrucCongty()
        {
            InitializeComponent();
        }
        private void FormCautrucCongty_Load(object sender, EventArgs e)
        {
            dtDivision = DBEngine.execReturnDataTable("select * from tblDivision");
            dvDivision = dtDivision.DefaultView;
            dtDepartment = DBEngine.execReturnDataTable("select * from tblDepartment");
            dvDepartment = dtDepartment.DefaultView;
            dtSection = DBEngine.execReturnDataTable("select * from tblSection");
            dvSection = dtSection.DefaultView;
            dtGroup = DBEngine.execReturnDataTable("select * from tblGroup");
            dvGroup = dtGroup.DefaultView;
            CapnhatTree();
            
            contextMenuStrip1.Items.Add(HPA.Common.Methods.GetMessage(HPA.Common.CommonConst.UPDATETREE));
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
            if (e.ClickedItem.Text == HPA.Common.Methods.GetMessage(HPA.Common.CommonConst.UPDATETREE))
            {
                CapnhatTree();
            }
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
            }
            else if (cap == "2")
            {
                dtgrCautruc.DataSource = from p in dt.tblSections where p.DepartmentID.ToString() == id select p;
                dtgrCautruc.Columns.RemoveAt(dtgrCautruc.ColumnCount - 1);
                dtgrCautruc.Columns[0].ReadOnly = true;

            }
            else if (cap == "3")
            {
                dtgrCautruc.DataSource = from p in dt.tblGroups where p.SectionID.ToString() == id select p;
                dtgrCautruc.Columns.RemoveAt(dtgrCautruc.ColumnCount - 1);
                dtgrCautruc.Columns[0].ReadOnly = true;

            }
            else if (cap == "4")
            {
                dtgrCautruc.DataSource = from p in dt.tblGroups where p.GroupID.ToString() == id select p;
                dtgrCautruc.Columns.RemoveAt(dtgrCautruc.ColumnCount - 1);
                dtgrCautruc.Columns[0].ReadOnly = true;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            cap = treeView1.SelectedNode.Tag.ToString();
            id = treeView1.SelectedNode.Name.ToString();
            switch (cap)
            {
                case "0":
                    dtgrCautruc.DataSource = dvDivision;
                    break;
                case "1":
                    dtgrCautruc.DataSource = dvDepartment;
                    dvDepartment.RowFilter = string.Format("DivisionID = {0}", id);
                    
                    break;
                case "2":
                    dtSection.DefaultView.RowFilter = string.Format("DepartmentID = {0}", id);
                    dtgrCautruc.DataSource = dtSection;
                    break;
                case "3":
                    dtGroup.DefaultView.RowFilter = string.Format("SectionID = {0}", id);
                    dtgrCautruc.DataSource = dtGroup;
                    break;
            }
            //Loaddata();
        }
       
        private void dtgrCautruc_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index].Cells[1].Value = dtgrCautruc.Rows[dtgrCautruc.CurrentRow.Index - 1].Cells[1].Value;
        }

        private void dtgrCautruc_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
           DialogResult r = HPA.Common.Methods.ShowMessage(HPA.Common.Methods.GetMessage(HPA.Common.CommonConst.DELETE_CONFIRM), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           if (r == DialogResult.Yes)
           {
               for (int i = 0; i < dtgrCautruc.Rows.Count-1; i++)
               {
                   if (dtgrCautruc.Rows[i].Selected == true)
                   {
                       int cid = int.Parse(dtgrCautruc.Rows[i].Cells[0].Value.ToString());
                       if (cap == "0")
                       {
                           var del = dt.tblDivisions.Single(u => u.DivisionID == cid);
                           dt.tblDivisions.DeleteOnSubmit(del);
                           dtgrCautruc.Rows.RemoveAt(i);
                       }
                       else if (cap == "1")
                       {
                           var del = dt.tblDepartments.Single(u => u.DepartmentID == cid);
                           dt.tblDepartments.DeleteOnSubmit(del);
                           dtgrCautruc.Rows.RemoveAt(i);
                       }
                       else if (cap == "2")
                       {
                           var del = dt.tblSections.Single(u => u.SectionID == cid);
                           dt.tblSections.DeleteOnSubmit(del);
                           dtgrCautruc.Rows.RemoveAt(i);
                       }
                       else if (cap == "3" || cap == "4")
                       {
                           var del = dt.tblGroups.Single(u => u.GroupID == cid);
                           dt.tblGroups.DeleteOnSubmit(del);
                           dtgrCautruc.Rows.RemoveAt(i);
                       }

                   }
                   else
                   { 

                   }
               }
               
           }
           
        }

        private void dtgrCautruc_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            dt.SubmitChanges();
        }

        private void FormCautrucCongty_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyCode.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //luu department
            foreach (DataRow drchange in dtDepartment.GetChanges().Rows)
            {
                switch (drchange.RowState)
                {
                    case DataRowState.Added:
                        HPA.SQL.tblDepartment dpe = new SQL.tblDepartment();
                        if (drchange["DepartmentCode"] == null || dt.tblDepartments.Where(u => u.DepartmentCode.ToString() == drchange["DepartmentCode"]).Count() > 0)
                        {
                            
                            drchange.SetColumnError("DepartmentCode", "ERROR");
                            
                            //errorProvider1.SetError(drchange, "ERROR");
                        }
                        else
                        {
                            dpe.DepartmentCode = drchange["DepartmentCode"].ToString();
                            dt.tblDepartments.InsertOnSubmit(dpe);
                            dt.SubmitChanges();
                        
                        }
                        break;
                    case DataRowState.Modified:
                        var dv1 = dt.tblDepartments.Single(u => u.DepartmentID == int.Parse(drchange["DepartmentID"].ToString()));
                        dv1.DepartmentCode = drchange["DepartmentCode"].ToString();
                        dt.SubmitChanges();
                        break;
                    case DataRowState.Deleted:
                        break;
                }
            }
            //Luu sec
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dtDepartment.RejectChanges();
        }
        
    }
}
