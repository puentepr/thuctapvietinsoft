using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPA.SQL.SP
{
    public class Connect
    {
        public static void SetConnect(string s)
        {
            DataDaigramDataContext dt = new DataDaigramDataContext();
            dt.Connection.ConnectionString = s;
        }
    }
}
