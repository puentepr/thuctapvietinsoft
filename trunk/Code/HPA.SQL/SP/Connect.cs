using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPA.SQL.SP
{
    public class Connect
    {
        public static void SetConnect(string s)
        {
            HPA.SQL.Properties.Settings.Default["phanmemtinhluon_P4ConnectionString"] = s;
            HPA.SQL.Properties.Settings.Default.Save();
        }
    }
}
