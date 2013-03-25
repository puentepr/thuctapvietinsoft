using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPA.Common
{
   public class StaticVars
    {
        public static int LoginID;
        public static string UserName;
        public static string UserID_sql;
        public static string ServerName;
        public static string Password;
        public static string DatabaseName;
        public static string ConnectionString;
        public static string DataSetting_ProcName;
        public static string App_path=string.Empty;
        public static string LanguageID=string.Empty;
        public static string FullClassName = string.Empty;
        public static bool ENTER_TO_TAB = false;
        public static EzSqlCollection.EzSql2 DBEngine = null;

       
    }
}
