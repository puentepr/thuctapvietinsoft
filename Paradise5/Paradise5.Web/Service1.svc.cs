using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using System.Web;
using System.Data;

namespace Paradise5.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)] 
    public class Service1 : IService1
    {
        TestDataContext dt = new TestDataContext();
        public List<tblSC_Login> Login()
        {
            var i = dt.tblSC_Logins.Select(n => n);
            return i.ToList();
        }
        public int Checklogin(string Name, string Pass)
        {
            return dt.SC_Login_CheckLogin(Name, Pass);
                
        }
        public void SetSession(string UserName)
        {
            HttpContext.Current.Session["UserName"] = UserName;
        }
        public string GetSession()
        {
            string username = HttpContext.Current.Session["UserName"].ToString();
            return username;
        }
        public void RemoveSession()
        {
            HttpContext.Current.Session["UserName"] = "";
        }
        public int GetID()
        {
            var n = dt.tblSC_Logins.Single(u => u.LoginName == HttpContext.Current.Session["UserName"].ToString());
            return n.LoginID;
        }
        /*public DataTable GetMenu()
        {
            var k1 = from p in dt.tblSC_Objects
                     join q in dt.tblSC_Rights on p.ObjectID equals q.ObjectID
                     where q.LoginID == 3
                     select new
                     {
                         p.ObjectName,
                         q.FullAccess,
                     };
            var k2 = from t in dt.MEN_Menus
                     join u in dt.tblMD_Messages on t.MenuID equals u.MessageID
                     where u.Language == "VN" && t.IsVisible == true
                     orderby t.Priority ascending
                     select new
                     {
                         t.IsCollapsed,
                         t.IsModal,
                         t.ShortcutKeys,
                         t.SupperAdmin,
                         t.ClassName,
                         t.AssemblyName,
                         t.MenuID,
                         u.Content,
                         t.ParentMenuID,
                         mnName = t.AssemblyName + "." + t.ClassName
                     };
            var i = from p in k2
                    join q in k1 on p.mnName equals q.ObjectName into temp
                    from u in temp.DefaultIfEmpty()
                    select new
                    {
                        Name = u == null ? "null" : u.ObjectName,
                        p.MenuID,
                        p.IsCollapsed,
                        p.IsModal,
                        p.ShortcutKeys,
                        p.SupperAdmin,
                        p.ClassName,
                        p.AssemblyName,
                        p.Content,
                        p.ParentMenuID
                    };
            return Linq2Datatable.LinqToDataTable(i);
        }*/
        public List<ViewMenu> ViewMN(string Langgue)
        {
            var i = from p in dt.ViewMenus where p.Language==Langgue && p.IsVisible==true orderby p.Priority ascending select p;
            return i.ToList();
        }
        public List<sp_EmployeeIDListResult> FindNV(int id)
        {
            return dt.sp_EmployeeIDList("-1",id).ToList();
        }
        public List<tblDepartment> danhsachtheocagiolam()
        {
            var dep = from p1 in dt.tblDepartments
                      select p1;
            return dep.ToList();
        }
        public List<tmpCheckTimeList> CheckTimeList(DateTime from, DateTime to, int depID, int secID, int groupId, string empID, bool nomal, bool noIn, bool noOut, bool noInNoOut, bool wordOnHolyday, bool leave, bool holyday, int logID)
        {
            dt.TA_CheckTime_List(from, to, depID, secID, groupId, empID, nomal, noIn, noOut, noInNoOut, wordOnHolyday, leave, holyday, logID);
            var i = from ct in dt.tmpCheckTimeLists select ct;
            return i.ToList();
        }
        public List<tblDepartment> ColDepartmentCodelist()
        {
            var i = from dep in dt.tblDepartments select dep;
            return i.ToList();
        }
        public List<tblSection> ColSectionCodelist()
        {
            var i = from sec in dt.tblSections select sec;
            return i.ToList();
        }
        public List<tblGroup> ColGroupCodelist()
        {
            var i = from gro in dt.tblGroups select gro;
            return i.ToList();
        }
        public List<tblSection> selectdanhsach(int depID)
        {
            var dep = from i in dt.tblSections
                      where i.DepartmentID == depID
                      select i;
            return dep.ToList();
        }
        public List<ChartView> ChartData()
        {
            var i = from p in dt.ChartViews select p;
            return i.ToList();
        }
        public List<tblAnnouncement> GetThongbao()
        {
            var i = from p in dt.tblAnnouncements orderby p.Priority ascending select p;
            return i.ToList();
        }

        public bool LuuThongBao(string tieude, string noidungtam, bool update)
        {
            bool kq = false;
            byte[] noidung = null;
            //Kiem tra su ton tai cua thong bao
            var i = from p in dt.tblAnnouncements where p.Title == tieude select p;
            if (i.Count() > 0)//Nếu có tiêu đề trùng khớp
            {
                if (update == false)//Neu la them moi
                {
                    kq = false;
                }
                else if (update == true)//Neu la cap nhat
                {
                    noidung = Convert.FromBase64String(noidungtam);//Giai ma ra dang binary
                    var capnhat = dt.tblAnnouncements.Single(u => u.Title == tieude);
                    capnhat.Content = noidung;
                    capnhat.Lastchanged = DateTime.Now;
                    dt.SubmitChanges();
                    kq = true;
                }
            }
            else//Neu khong co tieu de trung khop
            {
                noidung = Convert.FromBase64String(noidungtam);//Giai ma ra dang binary
                tblAnnouncement tb = new tblAnnouncement();
                tb.Title = tieude;
                tb.Content = noidung;
                tb.Priority = 0;
                tb.TimeStart = DateTime.Now;
                dt.tblAnnouncements.InsertOnSubmit(tb);
                dt.SubmitChanges();
                kq = true;
            }
            return kq;
        }
        public string GetThongBaoDon(string tieude)
        {
            string noidung = "";
            var tb = dt.tblAnnouncements.Single(u => u.Title == tieude);
            noidung = Convert.ToBase64String(tb.Content.ToArray());
            return noidung;
        }
    }
}
