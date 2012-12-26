using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MN
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string str = HPA.Common.Methods.ReadFile(HPA.Common.StaticVars.App_path + HPA.Common.CommonConst.PARADISE_INI);
            HPA.Common.StaticVars.ConnectionString = HPA.Common.Encryption.DecryptText(str, true);
            HPA.Common.StaticVars.UserID_sql = HPA.Common.StaticVars.ConnectionString.Split(HPA.Common.CommonConst.SEMICOLON_CHAR.ToCharArray())[2].Split('=')[1].Trim();
            HPA.Common.StaticVars.Password = HPA.Common.StaticVars.ConnectionString.Split(HPA.Common.CommonConst.SEMICOLON_CHAR.ToCharArray())[3].Split('=')[1].Trim();
            HPA.Common.StaticVars.DatabaseName = HPA.Common.StaticVars.ConnectionString.Split(HPA.Common.CommonConst.SEMICOLON_CHAR.ToCharArray())[1].Split('=')[1].Trim();
            HPA.Common.StaticVars.ServerName = HPA.Common.StaticVars.ConnectionString.Split(HPA.Common.CommonConst.SEMICOLON_CHAR.ToCharArray())[0].Split('=')[1].Trim();
            
            Application.Run(new Form1());
        }
    }
}

