using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace HPA
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
            Application.SetCompatibleTextRenderingDefault(true);
            try
            {
                if (!File.Exists(HPA.Common.StaticVars.App_path  + HPA.Common.CommonConst.PARADISE_INI))
                {
                    Application.Run(new HPA.Setting.SetConnection());
                }
                else
                {
                    string str = HPA.Common.Methods.ReadFile(HPA.Common.StaticVars.App_path + HPA.Common.CommonConst.PARADISE_INI);
                    HPA.Common.StaticVars.ConnectionString = HPA.Common.Encryption.DecryptText(str, true);
                    if (HPA.Common.StaticVars.ConnectionString != string.Empty)
                    {
                        try
                        {
                            SqlConnection sqlConn = new SqlConnection(HPA.Common.StaticVars.ConnectionString);
                            sqlConn.Open();
                            HPA.Common.StaticVars.UserID_sql = HPA.Common.StaticVars.ConnectionString.Split(HPA.Common.CommonConst.SEMICOLON_CHAR.ToCharArray())[2].Split('=')[1].Trim();
                            HPA.Common.StaticVars.Password = HPA.Common.StaticVars.ConnectionString.Split(HPA.Common.CommonConst.SEMICOLON_CHAR.ToCharArray())[3].Split('=')[1].Trim();
                            HPA.Common.StaticVars.DatabaseName = sqlConn.Database;
                            HPA.Common.StaticVars.ServerName = sqlConn.DataSource;
                            sqlConn.Close();
                            //string contact = "Data Source=" + HPA.Common.StaticVars.ServerName + ";" + "Initial Catalog=" + HPA.Common.StaticVars.DatabaseName + ";" + "User ID=" + HPA.Common.StaticVars.UserID_sql + ";" + "Password=" + HPA.Common.StaticVars.Password;
                            //HPA.SQL.SP.Connect.SetConnect(contact);
                            Application.Run(new HPA_Main());
                        }
                        catch
                        {
                            Application.Run(new HPA.Setting.SetConnection());
                        }
                    }
                }
                //Application.Run(new HPA_Main());
            }
            catch
            {
                //
            }

        }
    }
}
