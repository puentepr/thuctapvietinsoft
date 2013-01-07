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
        //public int Checklogin(string Name, string Pass)
        //{
        //    int loginid = 0;
        //    var i = dt.tblSC_Logins.Where(u => u.LoginName == Name && u.PassWord == Pass);
        //    if (i.Count() > 0)
        //    {
        //        loginid = i.First().LoginID;
        //    }
        //    else { loginid = 0; }
        //    return loginid;
        //}
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
        public DataTable GetMenu()
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
        }
        public List<ViewMenu> ViewMN(string Langgue)
        {
            var i = from p in dt.ViewMenus where p.Language==Langgue && p.IsVisible==true orderby p.Priority ascending select p;
            return i.ToList();
        }
        
    }
}
