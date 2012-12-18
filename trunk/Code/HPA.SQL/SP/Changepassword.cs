using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPA.SQL.SP
{
    public class Changepassword
    {
        DataDaigramDataContext dt = new DataDaigramDataContext();
        public string Changepass(int id,string pass1, string pass2)
        {
            string s="1";
            var i = dt.tblSC_Logins.Single(u => u.LoginID == id);
            if (i.PassWord == pass1)
            {
                i.PassWord = pass2;
                dt.SubmitChanges();
                s = "2";
            }
            else
            {
                s = "1";
            }
            return s;
        }
    }
}
