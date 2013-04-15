using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDesigner
{
    class Khoidau
    {
        public static string Dtname = "TestP4";
        public static string Servername = "ANHTUAN";
        public static string User = "sa";
        public static string Password = "LuaThiengFree";
        //void LoadData2()
        //{
        //    int ngang = 0;
        //    for (int i = LevelMax; i >= 0; i--)
        //    {
        //        foreach (DataRow dr in dstree.Rows)
        //        {
        //            if (Convert.ToInt32(dr["ControlLevel"]) == i)
        //            {
        //                Label lblTemp = CreateControl(dr);
        //                int timNgang = TimNgangHopLe(dr);
        //                if (timNgang == 0)
        //                {
        //                    dstemp.Add(lblTemp);
        //                }
        //                else
        //                {
        //                    ngang = timNgang;
        //                    lblTemp.Location = new Point(ngang, caotong * i);
        //                    ngang += rong + khoangcach;
        //                }
        //                panel1.Controls.Add(lblTemp);
        //            }
        //        }
        //        foreach (Label lbl in dstemp)
        //        {
        //            lbl.Location = new Point(ngang, caotong * i);
        //            ngang += rong + khoangcach;
        //        }
        //        dstemp.Clear();
        //    }

        //}

        //private int TimNgangHopLe(DataRow dr)
        //{
        //    int minngang=10240;
        //    int maxngang=0;
        //    if (dr.Table.Select(string.Format("ParentID = {0} and ParentName = '{1}'", dr["ID"], dr["Name"])).Length <= 0)
        //        return 0;
        //    foreach(DataRow drchild in dr.Table.Select(string.Format("ParentID = {0} and ParentName = '{1}'", dr["ID"], dr["Name"]))){
        //        if(minngang>panel1.Controls.Find(drchild["ID"].ToString() + drchild["ParentID"].ToString(),true)[0].Location.X)
        //        {minngang=panel1.Controls.Find(drchild["ID"].ToString() + drchild["ParentID"].ToString(),true)[0].Location.X;}
        //        if (maxngang < panel1.Controls.Find(drchild["ID"].ToString() + drchild["ParentID"].ToString(), true)[0].Location.X)
        //        { maxngang = panel1.Controls.Find(drchild["ID"].ToString() + drchild["ParentID"].ToString(), true)[0].Location.X; }
        //    }
        //    return (minngang+maxngang)/2;
        //}
        //Label CreateControl( DataRow dr)
        //{
        //    //Add label 
        //    Label lbltemp = new Label();
        //    lbltemp.Name = dr["ID"].ToString() + dr["ParentID"].ToString();
        //    lbltemp.Tag = dr["ParentName"].ToString();
        //    lbltemp.Size = new Size(rong, cao);
        //    lbltemp.BackColor = Color.Brown;
        //    lbltemp.Text = dr["Name"].ToString();
        //    lbltemp.TextAlign = ContentAlignment.MiddleCenter;
        //    return lbltemp;
        //}
    }
}
