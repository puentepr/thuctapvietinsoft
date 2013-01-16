using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;


namespace HPA.Setting
{
    public partial class FormCompany : HPA.CommonForm.BaseForm
    {
        HPA.SQL.DataDaigramDataContext dt = new SQL.DataDaigramDataContext();
        TreeListNode cha = null;
        TreeListNode goc, cap1, cap2, cap3, cap4 = null;
        DataSet ds = null;
        DataTable dtDivision = null;
        DataTable dtCompany = null;
        DataTable dtDepartment = null;
        DataTable dtSection = null;
        DataTable dtGroup = null;
        string cap, id = "";
        public FormCompany()
        {
            InitializeComponent();
        }
        public void fundata(string s)
        {
            //label1.Text
        }
        private void FormCompany_Load(object sender, EventArgs e)
        {
            ds = DBEngine.execReturnDataSet("spViewCompanyST");
            dtCompany = ds.Tables[0];
            dtDivision = ds.Tables[1];
            dtDepartment = ds.Tables[2];
            dtSection = ds.Tables[3];
            dtGroup = ds.Tables[4];
            Capnhattree();
            LoadData();
        }

        public void Capnhattree()
        {
            treeView1.BeginUnboundLoad();
            //cha.Tag = "Root";
            //Lay ten menugoc
            goc = treeView1.AppendNode(new object[] { dtCompany.Rows[0]["CompanyID"],dtCompany.Rows[0]["CompanyFullName"] }, cha);
            //Load danh sach Division
            foreach (DataRow dvi in dtDivision.Rows)
            {
                cap1 = treeView1.AppendNode(new object[] { dvi["DivisionID"], dvi["DivisionName"] }, goc);
                foreach (DataRow dpe in dtDepartment.Select(string.Format("DivisionID ={0}",dvi["DivisionID"])))
                {
                    cap2 = treeView1.AppendNode(new object[] { dpe["DepartmentID"], dpe["DepartmentName"] },cap1);
                    foreach (DataRow sec in dtSection.Select(string.Format("DepartmentID ={0}", dpe["DepartmentID"])))
                    {
                        cap3 = treeView1.AppendNode(new object[] { sec["SectionID"], sec["SectionName"] }, cap2);
                        foreach (DataRow gro in dtGroup.Select(string.Format("SectionID ={0}", sec["SectionID"])))
                        {
                            cap4 = treeView1.AppendNode(new object[] { gro["GroupID"], gro["GroupName"] }, cap3);
                        }
                    }
                }

            }
            treeView1.ExpandAll();
            treeView1.FocusedNode = goc;
            treeView1.EndUnboundLoad();
        }
        private void LoadData()
        {
            //gridView1
            if (cap == "0")
            {
                dtgrCautruc.DataSource = null;
                dtgrCautruc.Views[0].PopulateColumns();
                dtgrCautruc.DataSource = dtDivision;
                //Create a repository item for a combo box editor
                RepositoryItemComboBox riCombo = new RepositoryItemComboBox();
                riCombo.Items.AddRange(new string[] {"London", "Berlin", "Paris"});
                //Add the item to the internal repository 
                dtgrCautruc.RepositoryItems.Add(riCombo);
                //Now you can define the repository item as an in-place column editor 
                gridView1.Columns["DivisionID"].ColumnEdit = riCombo;
                //Set Readonly
                gridView1.Columns["DivisionID"].OptionsColumn.AllowEdit = false;
            }
            else if (cap == "1")
            {
                //Xoa datasource cu cho Grid
                dtgrCautruc.DataSource = null;
                dtgrCautruc.Views[0].PopulateColumns();
                //Gan datasource moi
                DataView dvDepartment=dtDepartment.DefaultView;
                dvDepartment.RowFilter = string.Format("DivisionID = {0}", id);
                dtgrCautruc.DataSource = dvDepartment;
            }
            else if (cap == "2")
            {
                //Xoa datasource cu cho Grid
                dtgrCautruc.DataSource = null;
                dtgrCautruc.Views[0].PopulateColumns();
                //Gan datasource moi
                DataView dvSection = dtSection.DefaultView;
                dvSection.RowFilter = string.Format("DepartmentID = {0}", id);
                dtgrCautruc.DataSource = dvSection;
            }
            else if (cap == "3"||cap=="4")
            {
                //Xoa datasource cu cho Grid
                dtgrCautruc.DataSource = null;
                dtgrCautruc.Views[0].PopulateColumns();
                //Gan datasource moi
                DataView dvGroup = dtGroup.DefaultView;
                dvGroup.RowFilter = string.Format("SectionID = {0}", id);
                dtgrCautruc.DataSource = dvGroup;
            }
        }

        private void treeView1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            cap = e.Node.Level.ToString();
            id = e.Node.GetValue(0).ToString();
            label1.Text = e.Node.GetValue(0).ToString();
            LoadData();
            //label1.Text = e.Node.Level.ToString();
        }
        
    }
}
