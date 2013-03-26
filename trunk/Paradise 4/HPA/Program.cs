using HPA.Common;
using HPA.SQL;
using HPA.SystemAdmin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {

                Application.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                //Connection
                LoadMainData();
                // Skin
                DevExpress.UserSkins.BonusSkins.Register();
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(UIMessage.SKIN);
                ////Check for update new files
                //DataTable dtUpdatelist = m_objManager.DBEngine.execReturnDataTable("sp_Sys_UpdateFileList", CommonConst.A_LoginID, 3);
                //if (dtUpdatelist != null && dtUpdatelist.Rows.Count > 0)
                //{
                //    foreach (DataRow dr in dtUpdatelist.Select("NeedUpdate = 1"))
                //    {
                //        if (dr["Folder"] == DBNull.Value || dr["Folder"].ToString().Trim().Equals(string.Empty))
                //        {
                //            UIMessage.SaveDocuments(dr["FileName"].ToString(), Application.StartupPath);
                //        }
                //        else
                //        {
                //            UIMessage.SaveDocuments(dr["FileName"].ToString(), string.Format(@"{0}\{1}", Application.StartupPath, dr["Folder"]));
                //        }
                //    }
                //}

                if (HPA.Properties.Settings.Default.UsedModenMenu)
                    //Application.Run(new HPA_Main());
                    Application.Run(new TileMenuApplication.TileMenuForm());
                else
                    Application.Run(new HPA_Main());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }
        private static HPA.Common.Framework.CRunableObjectManager m_objManager = new HPA.Common.Framework.CRunableObjectManager();
        private static void LoadMainData()
        {
            string strServer, strDatabase, strUser, strPassword;
            bool nReturn = false;
            try
            {
                DBConnection dbCon = new DBConnection();
                dbCon.getDBConnectionInfo(out strServer, out strDatabase, out strUser, out strPassword);
                m_objManager.Parent = null;
                m_objManager.DBEngine = new EzSql2(strServer, strDatabase, strUser, strPassword);
                m_objManager.DBEngine.open();
                nReturn = true;
                UIMessage.ENTER_TO_TAB = HPA.Properties.Settings.Default.EnterToTab;
                UIMessage.DBEngine = m_objManager.DBEngine;
                UIMessage.StoreProcName = "MST_Message_Get";
                UIMessage.StoreProcParamMessageID = "@MessageID";
                UIMessage.StoreProcParamLanguage = "@Language";
                UIMessage.StoreProcParamOutName = "@Content";
                UIMessage.MessageBoxTitle = "Paradise-HPA";
                //UIMessage.TA_LoadLogTimeWhenOpen = true;
                UIMessage.LoginWallpaper = HPA.Properties.Settings.Default.LoginWallpaper;
                m_objManager.UserID = 3;


                return;
            }
            catch
            {
                if (nReturn == false)
                {
                    object obj;
                    SetConnection frmCn = new SetConnection() { AssemblyName = "HPA.Component.SystemAdmin", ClassName = "SetConnection" };
                    m_objManager.OpenObject(frmCn, true, null, out obj);
                }
                return;
            }
        }
    }
}
