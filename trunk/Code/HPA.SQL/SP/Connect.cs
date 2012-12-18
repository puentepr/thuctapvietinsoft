using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPA.SQL.SP
{
    public class Connect
    {
        DataDaigramDataContext dt = new DataDaigramDataContext();
        public static void SetConnect(string s)
        {
            DataDaigramDataContext dt = new DataDaigramDataContext();
            dt.Connection.ConnectionString = s;
        }
        //public static void LoadMenu()
        //{ 
        //    int so = 
        //    ToolStripMenuItem[] goc = new ToolStripMenuItem[so.Count()+1];
        //    var i = from k in te.tbl_Nhatkies orderby k.STT descending select k;
        //    var dem = (from p in te.ViewMenus where p.GroupID == i.First().GroupID.Value && p.PM == 1 orderby p.Parent select p.Parent).Distinct().ToArray();
        //    for (int k = 0; k < dem.Count(); k++)
        //    {
        //        var cap1 = (from p in te.ViewMenus where p.GroupID == i.First().GroupID.Value && p.PM == 1 && p.Parent == dem.ElementAt(k) select p).ToArray();
        //        for (int q = 0; q < cap1.Count(); q++)
        //        {
        //            if (cap1.ElementAt(q).Parent == 0)
        //            {
        //                goc[cap1.ElementAt(q).MenuID] = new ToolStripMenuItem(cap1.ElementAt(q).MenuName);
        //                goc[cap1.ElementAt(q).MenuID].Name = cap1.ElementAt(q).MenuID.ToString();
        //                menuStrip1.Items.Add(goc[cap1.ElementAt(q).MenuID]);
        //            }
        //            else
        //            {
        //                goc[cap1.ElementAt(q).MenuID] = new ToolStripMenuItem(cap1.ElementAt(q).MenuName);
        //                goc[cap1.ElementAt(q).MenuID].Name = cap1.ElementAt(q).MenuID.ToString();
        //                goc[cap1.ElementAt(q).MenuID].AccessibleName = cap1.ElementAt(q).AssemblyName;
        //                goc[cap1.ElementAt(q).MenuID].Tag = cap1.ElementAt(q).ClassName;
        //                if (cap1.ElementAt(q).IsModal != null)
        //                {
        //                    goc[cap1.ElementAt(q).MenuID].AutoToolTip = bool.Parse(cap1.ElementAt(q).IsModal.ToString()); 
        //                }
        //                goc[cap1.ElementAt(q).MenuID].Click += new EventHandler(SubMenuClick);
        //                string tam = cap1.ElementAt(q).Parent.ToString();
        //                if (cap1.ElementAt(q).SK != null)
        //                {
        //                    string[]sk = cap1.ElementAt(q).SK.ToString().Split(new char[] { '|' });
        //                    switch (sk.Length)
        //                    {
        //                        case 2:
        //                            goc[cap1.ElementAt(q).MenuID].ShortcutKeys = ((System.Windows.Forms.Keys)(Convert.ToInt32(sk[0]) | Convert.ToInt32(sk[1])));
        //                            break;
        //                        case 3:
        //                            goc[cap1.ElementAt(q).MenuID].ShortcutKeys = ((System.Windows.Forms.Keys)(Convert.ToInt32(sk[0]) | Convert.ToInt32(sk[1]) | Convert.ToInt32(sk[2])));
        //                            break;
        //                        case 4:
        //                            goc[cap1.ElementAt(q).MenuID].ShortcutKeys = ((System.Windows.Forms.Keys)(Convert.ToInt32(sk[0]) | Convert.ToInt32(sk[1]) | Convert.ToInt32(sk[2]) | Convert.ToInt32(sk[3])));
        //                            break;

        //                    }
        //                }
        //                //Add menu con vào menu cha
        //                if (goc[cap1.ElementAt(q).MenuID] != null && tam == goc[cap1.ElementAt(q).Parent.Value].Name)
        //                {
        //                    goc[cap1.ElementAt(q).Parent.Value].DropDownItems.Add(goc[cap1.ElementAt(q).MenuID]);
        //                }
        //            }

        //        }
        //}

    }
}
