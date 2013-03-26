using System;
using System.Data;
using System.IO;

namespace HPA.Common
{
	/// <summary>
	/// </summary>
	public class UIMessage
	{
		#region Method
        public static void SaveDocuments(string fileName,string path )
        {
            try
            {
                DataTable a = new DataTable();
                if (File.Exists(string.Format(@"{0}\{1}", path, fileName)))
                    File.Delete(string.Format(@"{0}\{1}", path, fileName));
                FileStream file = new FileStream(string.Format(@"{0}\{1}",path,fileName), FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                
                BinaryWriter w = new BinaryWriter(file);
                a = DBEngine.execReturnDataTable("sp_DocumentsStorage_getFile",
                                         "@id", DBNull.Value,
                                         "@DocumentName", fileName
                                       );
                if(a!= null && a.Rows.Count>0)
                    w.Write((byte[])a.Rows[0]["File"]);
                file.Close();
                file.Dispose();
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.LogError(ex, ex.Message, "SaveDocuments");
            }
        }
        private static string GetKeyValue(DataRow drOld, string TableName)
        {
            DataTable m_dtPrimaryKeys = DBEngine.execReturnDataTable("sp_TableEditor_GetPrimaryKeys", "@Tablename", TableName);
            string retVal = "[";
            if(drOld.RowState != DataRowState.Added)
                foreach (DataRow dr in m_dtPrimaryKeys.Rows)
                {
                    retVal += drOld[dr[0].ToString(),DataRowVersion.Original] + " , ";
                }
            else
                foreach (DataRow dr in m_dtPrimaryKeys.Rows)
                {
                    retVal += drOld[dr[0].ToString()] + " , ";
                }
            return retVal.Substring(0, retVal.Length - 3) + "]";
        }
        private static string GetKeyName(string TableName)
        {
            if (TableName.Equals(string.Empty))
                return "";
            DataTable m_dtPrimaryKeys = DBEngine.execReturnDataTable("sp_TableEditor_GetPrimaryKeys", "@Tablename", TableName);
            string retVal = string.Empty;
            foreach (DataRow dr in m_dtPrimaryKeys.Rows)
            {
                retVal += dr[0] + " ; ";
            }
            return retVal.Substring(0, retVal.Length - 3);
        }
        private static void EZLog(string Action, string keyName, string oldValue, string newValue, string TableName, string ASSEMBLY_NAME, string formName, object userID, string strEmployeeID)
        {
            try
            {
                DBEngine.exec("sp_EZLogMasterData",
                    "@Action", Action,
                    "@KeyName", keyName,
                    "@EmployeeID",strEmployeeID,
                    "@OldValue", oldValue,
                    "@NewValue", newValue,
                    "@FunctionClassName", string.Format("{0}.{1}", ASSEMBLY_NAME, TableName),
                    "@ScreenName", formName,
                    "@LoginID", userID);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        public static void EZLog(DataRow drOld, DataRow dr, string tblN, string ASSEMBLY_NAME,string formName,object userID)
        {
            string keysValue = string.Empty;
            string keysName = string.Empty;
            string strEmployeeID = string.Empty;
            if (dr.Table.Columns.Contains("EmployeeID"))
                strEmployeeID = drOld["EmployeeID"].ToString();
            string columnName = string.Empty;
            try
            {
                if (tblN.Equals(string.Empty))
                    keysValue = "";
                else
                    keysValue = GetKeyValue(drOld, tblN);
                switch (dr.RowState)
                {
                    case DataRowState.Deleted:
                        //log delete data
                        keysName = GetKeyName(tblN);
                        EZLog("Delete", keysName, keysValue, "", tblN, ASSEMBLY_NAME, formName, userID, strEmployeeID);
                        break;
                    case DataRowState.Added:
                        keysName = GetKeyName(tblN);
                        EZLog("Add new", keysName, "", keysValue, tblN, ASSEMBLY_NAME, formName, userID, strEmployeeID);
                        break;
                    case DataRowState.Modified:
                        for (int i = 0; i < dr.Table.Columns.Count; i++)
                        {
                            if (!(dr[i].ToString().Equals(drOld[i].ToString())))
                            {
                                //Log modified
                                columnName = UIMessage.Get_Message(dr.Table.Columns[i].Caption);
                                keysName = String.Format("({0} , {1})", keysValue, columnName);
                                EZLog("Modified", keysName, drOld[i].ToString(), dr[i].ToString(), tblN, ASSEMBLY_NAME, formName, userID, strEmployeeID);
                            }
                        }
                        break;
                    default:
                        //log delete data
                        keysName = GetKeyName(tblN);
                        EZLog("Delete", keysName, keysValue, "", tblN, ASSEMBLY_NAME, formName, userID, strEmployeeID);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void EZLog(DataRow dr, string tblN, string ASSEMBLY_NAME, string formName, object userID)
        {
            string keysValue = string.Empty;
            string keysName = string.Empty;
            string strEmployeeID = string.Empty;
            if (dr.Table.Columns.Contains(CommonConst.EmployeeID) && dr.RowState != DataRowState.Added)
                strEmployeeID = dr[CommonConst.EmployeeID, DataRowVersion.Original].ToString();
            else if (dr.Table.Columns.Contains(CommonConst.EmployeeID))
                strEmployeeID = dr[CommonConst.EmployeeID].ToString();
            string columnName = string.Empty;
            try
            {
                if (tblN.Equals(string.Empty))
                    keysValue = "";
                else
                    keysValue = GetKeyValue(dr, tblN);
                switch (dr.RowState)
                {
                    case DataRowState.Deleted:
                        //log delete data
                        keysName = GetKeyName(tblN);
                        EZLog("Delete", keysName, keysValue, "", tblN, ASSEMBLY_NAME, formName, userID, strEmployeeID);
                        break;
                    case DataRowState.Added:
                        keysName = GetKeyName(tblN);
                        EZLog("Add new", keysName, "", keysValue, tblN, ASSEMBLY_NAME, formName, userID, strEmployeeID);
                        break;
                    case DataRowState.Modified:
                        for (int i = 0; i < dr.Table.Columns.Count; i++)
                        {
                            if (!(dr[i].ToString().Equals(dr[i,DataRowVersion.Original].ToString())))
                            {
                                //Log modified
                                columnName = UIMessage.Get_Message(dr.Table.Columns[i].Caption);
                                keysName = String.Format("({0} , {1})", keysValue, columnName);
                                EZLog("Modified", keysName, dr[i,DataRowVersion.Original].ToString(), dr[i].ToString(), tblN, ASSEMBLY_NAME, formName, userID, strEmployeeID);
                            }
                        }
                        break;
                    default:
                        //log delete data
                        keysName = GetKeyName(tblN);
                        EZLog("Delete", keysName, keysValue, "", tblN, ASSEMBLY_NAME, formName, userID, strEmployeeID);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		public static System.Windows.Forms.DialogResult ShowMessage(object objMessageID, System.Windows.Forms.MessageBoxButtons mbb, System.Windows.Forms.MessageBoxIcon mbi)
		{
			if ((DBEngine == null) ||
				(StoreProcName == null) ||
				(StoreProcParamMessageID == null) ||
				(StoreProcParamLanguage == null) ||
				(StoreProcParamOutName == null))
				throw new Exception("Database engine and related information has not initialized yet in UIMessage module");

			try
			{
				DBEngine.exec(StoreProcName, StoreProcParamMessageID, 
					objMessageID, StoreProcParamLanguage, UIMessage.languageID);
				object obj = DBEngine.getParamValue(StoreProcParamOutName);
				if (obj == null)
				{
					System.Windows.Forms.MessageBox.Show( objMessageID.ToString() , MessageBoxTitle, mbb, mbi);
					return System.Windows.Forms.DialogResult.None;
				}
                if (obj.ToString().Trim().Equals(string.Empty))
                    obj = string.Format("{0}: LangID = {1}",objMessageID,UIMessage.languageID);
				return System.Windows.Forms.MessageBox.Show(obj.ToString(), MessageBoxTitle, mbb, mbi);
			}
			catch (Exception e)
			{
                throw e;
				return System.Windows.Forms.DialogResult.None;
			}
		}

        //public static System.Windows.Forms.DialogResult ShowMessage(string strMessage, System.Windows.Forms.MessageBoxButtons mbb, System.Windows.Forms.MessageBoxIcon mbi)
        //{
        //    return System.Windows.Forms.MessageBox.Show(strMessage, MessageBoxTitle, mbb, mbi);
        //}
		public static System.Windows.Forms.DialogResult Alert(object objMessageID)
		{
			return ShowMessage(objMessageID, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
		}
        //public static System.Windows.Forms.DialogResult Alert(string strMessage)
        //{
        //    return ShowMessage(strMessage, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
        //}
		public static System.Windows.Forms.DialogResult Notify(object objMessageID)
		{
			return ShowMessage(objMessageID, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
		}
		public static System.Windows.Forms.DialogResult Notify(string strMessage)
		{
			return ShowMessage(strMessage, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
		}
		public static System.Windows.Forms.DialogResult Error(object objMessageID)
		{
			return ShowMessage(objMessageID, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
		}
		public static System.Windows.Forms.DialogResult Error(string strMessage)
		{
            return System.Windows.Forms.MessageBox.Show(strMessage,"Vietinsoft - Error", System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
		}
        /// <summary>
        /// get Display text of control from database
        /// </summary>
        /// <param name="ctrs"></param>
        public static void LoadLableName(ref System.Windows.Forms.Control.ControlCollection  ctrs)
        {
            const string LBL = "lbl";
            DevExpress.UserSkins.BonusSkins.Register();
            ((DevExpress.XtraEditors.XtraForm)ctrs[0].FindForm()).LookAndFeel.UseDefaultLookAndFeel = false;
            ((DevExpress.XtraEditors.XtraForm)ctrs[0].FindForm()).LookAndFeel.SkinName = SKIN;
            foreach (System.Windows.Forms.Control ctr in ctrs)
            {
                // Send tab key replace enter keys
                //if (UIMessage.ENTER_TO_TAB)
                //    if (!(ctr is System.Windows.Forms.Button || ctr is System.Windows.Forms.Label || ctr is DevExpress.XtraEditors.SimpleButton))
                //    {
                //        //register keypress event
                //        ctr.KeyDown -= new System.Windows.Forms.KeyEventHandler(ctr_KeyDown);
                //        ctr.KeyDown += new System.Windows.Forms.KeyEventHandler(ctr_KeyDown);

                //    }
                //Set date format as dd/MM/yyyy
                if (ctr is DevExpress.XtraEditors.DateEdit && ((DevExpress.XtraEditors.DateEdit)ctr).Properties.Mask.UseMaskAsDisplayFormat == false)
                {
                    ((DevExpress.XtraEditors.DateEdit)ctr).Properties.Mask.EditMask = DATE_FORMAT_PATTEN;
                    ((DevExpress.XtraEditors.DateEdit)ctr).Properties.Mask.UseMaskAsDisplayFormat = true;
                    ((DevExpress.XtraEditors.DateEdit)ctr).LookAndFeel.UseDefaultLookAndFeel = false;
                    ((DevExpress.XtraEditors.DateEdit)ctr).LookAndFeel.SkinName = SKIN;
                    ((DevExpress.XtraEditors.DateEdit)ctr).Properties.NullDate = DateTime.Now;
                   
                    continue;
                }
                // set theme
                if (ctr is DevExpress.XtraEditors.LookUpEdit)
                {
                    ((DevExpress.XtraEditors.LookUpEdit)ctr).LookAndFeel.UseDefaultLookAndFeel = false;
                    ((DevExpress.XtraEditors.LookUpEdit)ctr).LookAndFeel.SkinName = SKIN;
                    continue;
                }
                if (ctr is DevExpress.XtraEditors.SimpleButton)
                {
                    ((DevExpress.XtraEditors.SimpleButton)ctr).LookAndFeel.UseDefaultLookAndFeel = false;
                    ((DevExpress.XtraEditors.SimpleButton)ctr).LookAndFeel.SkinName =  SKIN;
                    
                }
                if (ctr is DevExpress.XtraTreeList.TreeList)
                {

                    ((DevExpress.XtraTreeList.TreeList)ctr).LookAndFeel.UseDefaultLookAndFeel = false;
                    ((DevExpress.XtraTreeList.TreeList)ctr).LookAndFeel.SkinName = SKIN;
                }
                if (ctr is DevExpress.XtraGrid.GridControl)
                {
                    ((DevExpress.XtraGrid.GridControl)ctr).FormsUseDefaultLookAndFeel = false;
                    ((DevExpress.XtraGrid.GridControl)ctr).LookAndFeel.UseDefaultLookAndFeel = false;
                    ((DevExpress.XtraGrid.GridControl)ctr).LookAndFeel.SkinName = SKIN_BLUE;
                    if (((DevExpress.XtraGrid.GridControl)ctr).MainView is DevExpress.XtraGrid.Views.Grid.GridView)
                    {
                        DevExpress.XtraGrid.Views.Grid.GridView grv = (DevExpress.XtraGrid.Views.Grid.GridView)((DevExpress.XtraGrid.GridControl)ctr).MainView;
                        grv.GroupPanelText = Get_Message("GroupPanelText");
                        foreach (DevExpress.XtraGrid.Columns.GridColumn grdCol in grv.Columns)
                        {
                            try
                            {
                                DBEngine.exec(StoreProcName, StoreProcParamMessageID,
                                    grdCol.Name, StoreProcParamLanguage, UIMessage.languageID);
                                object objGrdCol = DBEngine.getParamValue(StoreProcParamOutName);
                                if (objGrdCol.ToString().Trim().Equals(string.Empty))
                                {
                                    grdCol.Caption = String.Format("{0} {1}", grdCol.Name, UIMessage.languageID);
                                }
                                else
                                    grdCol.Caption = objGrdCol.ToString();
                            }

                            catch
                            {
                                grdCol.Caption = grdCol.Name + " " + UIMessage.languageID;
                            }
                        }
                    }
                    foreach (DevExpress.XtraEditors.Repository.RepositoryItem rpe in ((DevExpress.XtraGrid.GridControl)ctr).RepositoryItems)
                    {
                        if (rpe is DevExpress.XtraEditors.Repository.RepositoryItemDateEdit)
                        {
                            ((DevExpress.XtraEditors.Repository.RepositoryItemDateEdit)rpe).Mask.EditMask = DATE_FORMAT_PATTEN;
                            ((DevExpress.XtraEditors.Repository.RepositoryItemDateEdit)rpe).Mask.UseMaskAsDisplayFormat = true;
                        }
                    }
                    continue;
                }
                // set color for datagridview control
                if (ctr is System.Windows.Forms.DataGridView)
                {
                    ((System.Windows.Forms.DataGridView)ctr).AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
                    //regist common event
                    ((System.Windows.Forms.DataGridView)ctr).RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(UIMessage_RowPostPaint);
                    ((System.Windows.Forms.DataGridView)ctr).AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
                }
                
                if ((ctr is System.Windows.Forms.Label) || (ctr is System.Windows.Forms.Button) || (ctr is System.Windows.Forms.CheckBox) || (ctr is System.Windows.Forms.RadioButton)
                    || (ctr is DevExpress.XtraEditors.CheckEdit) || (ctr is System.Windows.Forms.GroupBox) || (ctr is DevExpress.XtraEditors.SimpleButton)
                    || (ctr is System.Windows.Forms.GroupBox) || (ctr is DevExpress.XtraTab.XtraTabPage) || (ctr is System.Windows.Forms.TabPage)
                    )
                {
                    try
                    {
                        if ((ctr is System.Windows.Forms.Label) && (!ctr.Name.Substring(0, 3).ToLower().Equals(LBL)))
                            continue;
                        if (!ctr.Text.Trim().Equals(string.Empty))
                        {
                            DBEngine.exec(StoreProcName, StoreProcParamMessageID,
                                ctr.Name, StoreProcParamLanguage, UIMessage.languageID);
                            object obj = DBEngine.getParamValue(StoreProcParamOutName);
                            if (obj.ToString().Trim().Equals(string.Empty))
                            {
                                ctr.Text = String.Format("{0} {1}", ctr.Name, UIMessage.languageID);
                            }
                            else
                                ctr.Text = obj.ToString();
                        }
                    }
                    catch
                    {
                        ctr.Text = String.Format("{0} {1}", ctr.Name, UIMessage.languageID);
                    }
                }
                
                if (ctr.Controls.Count > 0)
                {
                    System.Windows.Forms.Control.ControlCollection con = ctr.Controls;
                    LoadLableName(ref con);
                }
            }
        }
        //static void ctr_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        //{
        //    if (e.KeyCode == System.Windows.Forms.Keys.Enter)
        //    {
        //        e.Handled = true;
        //        System.Windows.Forms.SendKeys.Send("{TAB}");
        //    }
        //}
        public static string Get_InformInfo()
        {
            string strRetval = "";
            DataTable dtInfo = DBEngine.execReturnDataTable("sp_GetInformInfor");
            if (dtInfo.Rows.Count <= 0)
                return "";
            else
            {
                foreach (DataRow dr in dtInfo.Rows)
                {
                    strRetval += dr["Content"] + "\n\r";
                }
            }
            return strRetval;
        }
        public static void Save_InformInfo(string strContent)
        {
            try
            {
                DBEngine.exec("sp_InformInforInsert","@Content",strContent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void CheckLabourDue(Object loginID)
        {
            const string strContent = "Có một hoặc một số nhân viên tới hạn ký hợp đồng mới. Vui lòng kiểm tra thông tin hợp đồng nhân viên để biết chi tiết";
            try
            {
                DataTable dtLabourList = DBEngine.execReturnDataTable("sp_SignContractDueList", "@LoginID", loginID, "@ViewDate", DateTime.Now);
                if (dtLabourList.Rows.Count > 0)
                    Save_InformInfo(strContent);
                else
                    Delete_InformInfo(strContent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void Delete_InformInfo(string p)
        {
            DBEngine.exec(string.Format("Delete tblInform where Content = N'{0}'",p));
        }
        public static string Get_Message(object ID)
        {
            object obj;
            try
            {
                DBEngine.exec(StoreProcName, StoreProcParamMessageID,
                                    ID.ToString(), StoreProcParamLanguage, UIMessage.languageID);
                obj = DBEngine.getParamValue(StoreProcParamOutName);
                if (obj.ToString().Trim().Equals(string.Empty))
                    return string.Format("{0}: LangID = {1}", ID, UIMessage.languageID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.ToString();
        }
        static void UIMessage_RowPostPaint(object sender, System.Windows.Forms.DataGridViewRowPostPaintEventArgs e)
        {
            System.Windows.Forms.DataGridView grd = ((System.Windows.Forms.DataGridView)sender);
            using (System.Drawing.SolidBrush b = new System.Drawing.SolidBrush(grd.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 8, e.RowBounds.Location.Y + 4);
            }
        }
        public static void ChangeLableName(string CurrentName, string newName, int loginID)
        {
            try
            {
                DBEngine.exec("sp_ChangeLableName","@LoginID",loginID,
                    "@CurrentName", CurrentName, "@NewName", newName, "@LanguageID",UIMessage.languageID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void AddNewLableName(string messageID,string newName, int loginID)
        {
            try
            {
                DBEngine.exec("sp_AddNewLableName", "@LoginID", loginID,"@MessageID",messageID,
                    "@NewName", newName, "@LanguageID", UIMessage.languageID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		#endregion

		#region Property
		#endregion

		#region Variable
        public static HPA.Component.Framework.Base.IDatabaseEngine DBEngine = null;
		public static string MessageBoxTitle = null;			
		public static string StoreProcName = null;
		public static string StoreProcParamMessageID = null;
		public static string StoreProcParamLanguage = null;
        public static string StoreProcParamOutName = null;
        public static bool TA_LoadLogTimeWhenOpen = false;
        public const string DATE_FORMAT_PATTEN = "dd/MM/yyyy";
        public const string SKIN = "Liquid Sky";
        public const string SKIN_BLUE = "Blue";

        public const string ENCRIT_KEY = "1PARADISE_HNNCTT";
        public const string INIT_TEXT = "12345678";

        public static object userID = 0;
        public static object languageID;
        public static string EmployeeID;
        public static bool ENTER_TO_TAB;
        public static string WallpaperPath;
        public static string LoginWallpaper;
        
		#endregion

       
    }
}
