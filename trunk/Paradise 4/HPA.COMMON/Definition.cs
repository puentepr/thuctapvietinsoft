using System;
using System.IO;
using System.Data;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid ;
using HPA.Component;

using System.Security.Permissions;
using System.Security.Cryptography; 
using Microsoft.Win32;
using HPA.SQL;

namespace HPA.Common
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	/// 
	#region Reports
	public class SReport
	{
		public enum EAction
		{
			PREVIEW,
			PRINT,
            SAVE_TO_DISK
		}
        public string SaveToFileName;
		public string ReportName;
		public object[] Parameters;
		//public object[] Formulas;
		public EAction Action = EAction.PREVIEW;
	}
	#endregion
	#region SQL code
	public enum ESQLErrorCode : int
	{
		UNIQUE_CONSTRAINT_VIOLATED = 00001, // 00001 unique constraint (string.string) violated
		CANNOT_INSERT_NULL_INTO = 01400, // 01400 cannot insert NULL into (string)
		INSERTED_VALUE_TOO_LARGE_FOR_COLUMN = 01401, // 01401 inserted value too large for column
		NO_DATA_FOUND = 01403, // 01403 no data found
		CANNOT_UPDATE_TO_NULL = 01407, // 01407 cannot update (string) to NULL
		INTEGRITY_CONSTRAINT_VIOLATED_PARENT_KEY_NOT_FOUND = 02291, // 02291 integrity constraint (string.string) violated - parent key not found
		INTEGRITY_CONSTRAINT_VIOLATED_CHILD_RECORD_FOUND = 02292, // 02292 integrity constraint (string.string) violated - child record found
		// 06512 at stringline string

		// My error code:
		GOOD = 00000,

		BUSINESS_CONSTRAINT = 99990,
		BUSINESS_CONSTRAINT1 = 99991,
		BUSINESS_CONSTRAINT2 = 99992,
		BUSINESS_CONSTRAINT3 = 99993,

		CANNOT_DELETE_CURRENT_RECORD = 99995,
	}
	#endregion

	#region WINDOWS MESSAGES
	public enum WIN32_MESSAGES : int
	{
		// Key board messages :
		WM_KEYDOWN = 0x100,
		WM_SYSKEYDOWN = 0x104
	}
	#endregion

	#region CRowUtility
	public class CRowUtility
	{
		public static bool checkUniqueConstraint(DataTable dt, out DataRow drViolation, params string[] arrstrKeyName)
		{
			drViolation = null;
			bool bNotUnique = false;
			if (dt == null || arrstrKeyName.Length == 0)
				return true;

			int n = dt.Rows.Count;
			int i = 0, j = 0, k = 0;
			DataRow dri = null, drj = null;
			bool bTemp = false;

			for (i=0; i<n; i++)
			{
				dri = dt.Rows[i];
				if (dri.RowState == DataRowState.Deleted) continue;

				for (j=i+1; j<n; j++)
				{
					drj = dt.Rows[j];
					if (drj.RowState == DataRowState.Deleted) continue;

					bNotUnique = true;
					for (k=0; k<arrstrKeyName.Length; k++)
					{
						bTemp = IsDifferentString(dri[arrstrKeyName[k]], drj[arrstrKeyName[k]]);
						if (bTemp)
						{
							bNotUnique = false;
							break;
						}
					}

					if (bNotUnique)
					{
						drViolation = drj;
						return false;
					}
				} // for j
			} // for i

			return true;
		}
		public static bool IsDifferentString(object oVariable, object oValue)
		{
			try
			{
				if (oValue == DBNull.Value)
				{
					if (oVariable != DBNull.Value)
						return true;
					else
						return false;
				}
				else
				{
					if (oVariable == DBNull.Value)
						return true;
					else if (oValue.ToString() != oVariable.ToString())
						return true;
					else
						return false;
				}
			}
			catch (Exception)
			{
				return false;
			}			
		}

		public static bool updateDataRow(GridView  xgv)
		{
			if (xgv == null) return false;
			xgv.CloseEditor();
			xgv.UpdateCurrentRow();
			return true;
		}
		public static bool addNewRow(DataTable dt,params object[] arrFields )
		{
			if(dt == null) return false;
			try
			{
				DataRow dr = dt.NewRow();
				int i=0;
				while(i<arrFields.Length)
				{
					dr[arrFields[i].ToString()] = arrFields[i+1];
					i+=2;
				}				
				dt.Rows.Add(dr);				
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return true;
		}
		public static bool deleteSelectedRow(DevExpress.XtraGrid.GridControl xgc,DevExpress.XtraGrid.Views.Grid.GridView xgv, object objMessageID)
		{
			if (xgv == null) return false;

			DataRow dr=null;
			try
			{
				dr = (DataRow)xgv.GetDataRow(xgv.FocusedRowHandle);
				if (dr != null)
				{				
					dr.Delete();					
				}
				else
				{
					UIMessage.ShowMessage(objMessageID ,System.Windows.Forms.MessageBoxButtons.OK,
						System.Windows.Forms.MessageBoxIcon.Exclamation );
					xgc.Focus();
				}				
			}
			catch(Exception e)
			{
				throw new Exception(e.Message );
			}
			return true;
		}
		public static bool deleteSelectedRow(DevExpress.XtraGrid.Views.Grid.GridView xgv, int nRowHandle)
		{
			if (xgv == null || nRowHandle < 0)
				return false;
			DataRow drDeleteRow = xgv.GetDataRow(nRowHandle);
			if (drDeleteRow == null)
				return false;
			// delete row:
			drDeleteRow.Delete();
			return true;
		}
		public static bool deleteSelectedRows(DevExpress.XtraGrid.Views.Grid.GridView xgv)
		{
			if (xgv == null)
				return false;
			int[] nSelectedRows = xgv.GetSelectedRows();
			if (nSelectedRows.Length == 0)
				return false;
			try
			{
				DataRow drRow = null;
				foreach(int nRowHandle in nSelectedRows)
				{
					drRow = xgv.GetDataRow(nRowHandle);
					if (drRow != null)
						drRow.Delete();
				}
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			return true;
		}
		public static int getMaxID(DataTable dt, string sKeyField)
		{
			int iMaxID =-1;
			if(dt == null)
				return iMaxID;
			foreach(DataRow dr in dt.Rows)
			{
				if (dr.RowState == DataRowState.Deleted ) continue;

				if(iMaxID < Convert.ToInt32(dr[sKeyField]))
					iMaxID = Convert.ToInt32(dr[sKeyField]);
			}
			return iMaxID;
		}
		public static bool moveTargetRow(DevExpress.XtraGrid.GridControl xgc,DataRow drTarget, string sKeyField) 
		{
			try
			{
				DataView dv = null;
				if (xgc.DataSource is DataTable)
				{
					dv = ((DataTable)xgc.DataSource).DefaultView ;
				}
				else
					dv = (DataView)xgc.DataSource;
				DevExpress.XtraGrid.Views.Grid.GridView xgv = (DevExpress.XtraGrid.Views.Grid.GridView)xgc.DefaultView;
				int nRowHandle;
				for (nRowHandle = 0; nRowHandle < dv.Count; nRowHandle++)
				{
					DataRow drTemp = xgv.GetDataRow(nRowHandle);
					if (drTemp != null)
					{
						if ( drTarget[sKeyField].Equals(drTemp[sKeyField]))
						{
							xgc.Focus();
							xgv.ClearSelection();
							xgv.FocusedRowHandle = nRowHandle;
							xgv.SelectRow(nRowHandle);
							return true;
						}
					}
				}
				return false;
			}
			catch (Exception)
			{				
				return false;
			}
		}
		public static bool moveNextTargetRow(DevExpress.XtraGrid.GridControl xgc,DataRow drTarget, string sKeyField) 
		{
			try
			{
				DataView dv = null;
				if (xgc.DataSource is DataTable)
				{
					dv = ((DataTable)xgc.DataSource).DefaultView ;
				}
				else
					dv = (DataView)xgc.DataSource;
				DevExpress.XtraGrid.Views.Grid.GridView xgv = (DevExpress.XtraGrid.Views.Grid.GridView)xgc.DefaultView;
				int nRowHandle;
				for (nRowHandle = 0; nRowHandle < dv.Count; nRowHandle++)
				{
					DataRow drTemp = xgv.GetDataRow(nRowHandle);
					if (drTemp != null)
					{
						if ( drTarget[sKeyField].Equals(drTemp[sKeyField]))
						{
							xgc.Focus();
							xgv.FocusedRowHandle = ++nRowHandle;
							return true;
						}
					}
				}
				return false;
			}
			catch (Exception)
			{				
				return false;
			}
		}
        //public static bool moveTargetGroup(DevExpress.XtraGrid.GridControl xgc,DataRow drTarget, string sKeyField) 
        //{
        //    try
        //    {
        //        DataView dv = null;
        //        if (xgc.DataSource is DataTable)
        //        {
        //            dv = ((DataTable)xgc.DataSource).DefaultView ;
        //        }
        //        else
        //            dv = (DataView)xgc.DataSource;
        //        DevExpress.XtraGrid.Views.Grid.GridView xgv = (DevExpress.XtraGrid.Views.Grid.GridView)xgc.DefaultView;
        //        int nRowHandle = 0;
        //        // for (nRowHandle = 0; nRowHandle < dv.Count; nRowHandle++)
        //        while (nRowHandle < dv.Count)
        //        {					
        //            if (!xgv.IsGroupRow(nRowHandle))
        //            {
        //                // get parent's row :
        //                int nParentRowHandle = xgv.GetParentRowHandle(nRowHandle);
        //                // get the number of child rows:
        //                int nChildRows = xgv.GetChildRowCount(nParentRowHandle);

        //                // get dislay value of group row :
        //                string sGroupDisplayValue = xgv.GetRowGroupDisplayText(nParentRowHandle);
        //                int nTokenPos = sGroupDisplayValue.IndexOf(":");
        //                sGroupDisplayValue = sGroupDisplayValue.Substring(nTokenPos+1,sGroupDisplayValue.Length - nTokenPos - 1).Trim();
        //                // compare :
        //                if (drTarget[sKeyField].ToString() == sGroupDisplayValue)
        //                {
        //                    xgc.Focus();
        //                    xgv.ClearSelection();
        //                    xgv.FocusedRowHandle = nParentRowHandle;
        //                    xgv.SelectRow(nParentRowHandle);
        //                    // expand all child rows :
        //                    xgv.SetRowExpanded(nParentRowHandle,true);
        //                    return true;
        //                }
        //                // move to child row of next group :
        //                nRowHandle = nRowHandle + nChildRows;
        //            }
					
        //        }
        //        return false;
        //    }
        //    catch (Exception)
        //    {				
        //        return false;
        //    }
        //}
		public static void focusRowHandle(DevExpress.XtraGrid.GridControl xgc, int iFocusedRowHandle)
		{
			xgc.Focus();			
			DevExpress.XtraGrid.Views.Grid.GridView xgv = (DevExpress.XtraGrid.Views.Grid.GridView)xgc.DefaultView;

			// clear old selection
			xgv.ClearSelection();
			// set focused:
			xgv.SelectRow(iFocusedRowHandle);
			xgv.FocusedRowHandle = iFocusedRowHandle;
		}

	}
	#endregion
	#region CDateTime:
	public class CDateTime
	{
		#region DateTimeEnum:
		public enum ETime: int
		{
			EShortTime = 0,
			ELongTime = 1,
			EUniversalTime = 2
		}
		#endregion
		public CDateTime()
		{
		}
		public static bool parseTime(string sTimeIn,out string sTimeOut,ETime et )
		{
			/*DateTime dt = DateTime.Parse(sTimeIn);
			if ( != null)
			{
				switch (et)
				{
					case ETime.EShortTime:
						sTimeOut = DateTime.Parse(sTimeIn).ToShortTimeString();
						break;
					case ETime.ELongTime :
						sTimeOut = DateTime.Parse(sTimeIn).ToLongTimeString();
						break;					
				}				
			}*/
			sTimeOut = "a";
			return true;
		}
        public static int CountDate(DateTime ValueFrom, DateTime ValueTo)
        {
            int retVal = 1;
            TimeSpan ts = ValueTo - ValueFrom;
            retVal = Convert.ToInt32(ts.TotalDays);
            return retVal;
        }
		public bool canConvertToDateTime(string strDateTime)
		{
			try
			{
				DateTime d=Convert.ToDateTime(strDateTime);
				return true;
			}
			catch(Exception)
			{
				return false;
			}
		}
	}
	#endregion
	#region CDayType:
	public class CDayType
	{
		private int m_iDayType;
		private string m_sDayTypeName;
		public CDayType(int iDayType,string sDayTypeName)
		{
			this.m_iDayType = iDayType;
			this.m_sDayTypeName = sDayTypeName;
		}
		public CDayType()
		{
			this.m_iDayType = 0;
			this.m_sDayTypeName = "";
		}
		public string DayTypeName
		{
			get{return m_sDayTypeName; }
			set{m_sDayTypeName =value;}
		}
		public int DayType
		{
			get{return m_iDayType; }
			set{m_iDayType = value;}
		}
	}
	#endregion
	#region CClass:
	public class CClass
	{
		private int m_iClass;
		private string m_sClassName;
		public CClass(int iClass,string sClassName)
		{
			this.m_iClass = iClass;
			this.m_sClassName = sClassName;
		}
		public CClass()
		{
			this.m_iClass = 0;
			this.m_sClassName = "";
		}
		public string ClassName
		{
			get{return m_sClassName; }
			set{m_sClassName =value;}
		}
		public int Class
		{
			get{return m_iClass; }
			set{m_iClass = value;}
		}
	}
	#endregion

	#region  ParseXMLFile
	public class XMLParser
	{
		private const Int32 MAX_EMAIL_ACCOUNTS = 30;

		public static void ParseXMLFile(String file,System.Windows.Forms.ComboBox cb , String[] server)
		{
			Int32 index = 0;
			
			StringBuilder sb = new StringBuilder();
			sb.Append(Application.StartupPath + @"\" + file);

			XmlDocument document = new XmlDocument();

			try
			{
				document.Load(sb.ToString());
				XmlNodeReader reader = new XmlNodeReader(document);				
				while (reader.Read() && index <= MAX_EMAIL_ACCOUNTS)
				{	
					if (reader.LocalName.Equals("email"))
					{						
						String s = reader.ReadString().Trim().Replace('"', ' ');
						cb.Items.Add(s);
					}
					if (reader.LocalName.Equals("smtpserver"))
					{
						String s = reader.ReadString().Trim().Replace('"', ' ');
						server[index++] = s;
					}
				} 
			}
			catch (System.IO.FileNotFoundException)
			{
				// MessageBox.Show("The XML file must be in the Start Application Directory", "Ez-Manage", MessageBoxButtons.OK, MessageBoxIcon.Error);
				throw new System.IO.FileNotFoundException();
			}	
			// default email address 
			cb.Text = cb.Items[0].ToString();
		}
		public static void LoadXMLEmailContent(String file,out string sSubjectOut, out string sBodyOut) 
		{
			String sSubject = null, sBody = null;
			StringBuilder sb = new StringBuilder();
			XmlTextReader reader = null;

			sb.Append(Application.StartupPath + @"\" + file);

			XmlDocument document = new XmlDocument();

			try
			{
				reader = new XmlTextReader(new FileStream(sb.ToString(), FileMode.Open));
				document.Load(reader);
				XmlNode docElement = document.DocumentElement;

				foreach (XmlNode node1 in docElement.ChildNodes)
				{
					if (node1.Name == "subject")
					{
						sSubject = node1.InnerText ;
					}
					else if (node1.Name == "body")
					{
						sBody = node1.InnerText;
						sBody = sBody.Replace("\t","");
					}					
				}				
			}
			catch (System.IO.FileNotFoundException)
			{				
				throw new System.IO.FileNotFoundException(); 
			}	
			finally
			{
				if (reader != null)
					reader.Close();
			}
			sSubjectOut = sSubject;
			sBodyOut = sBody ;
		}	
	}
	#endregion

	#region CNumeric:
	public class CNumericKeyPress
	{
		private KeyPressEventArgs m_event;
		public CNumericKeyPress(KeyPressEventArgs e)
		{
			this.m_event=e;
		}
		public bool IsNumberKeyPress()
		{
			char[] myNum = {'0','1','2','3','4','5','6','7','8','9','.',','};
			bool bEqual;
			bEqual =false;
			foreach (char myN in myNum)
			{
				if ((m_event.KeyChar.ToString() == myN.ToString())|| (m_event.KeyChar==Convert.ToChar(8)))
				{
					bEqual =true;
					break;
				}
			}
			return bEqual;
			/*
			if (!(bEqual))
			{
				return true;
			}
			else
			{
				return false;
			}
			*/
		}
	}

	public class CNumeric
	{
		public CNumeric()
		{
		}
		public static bool canConvertToInt32(string strDateTime)
		{
			try
			{
				int d = Convert.ToInt32(strDateTime);
				return true;
			}
			catch(Exception)
			{
				return false;
			}
		}

	}
	#endregion

    //# region CUtilityExcel
    //public class CUtilityExcel
    //{
    //    *********************************************************************************
    //     Name		: CUtilityExcel Class
    //     Author	: [unknow]
    //     Desc		: Import/Export functions
    //     Created	: [unknow]
    //     Modified : 30/05/2005
    //    *********************************************************************************

    //    #region Constants:
    //    public const int iPRINT_SHOWSCREEN = 0;
    //    public const int iPRINT_PRINTPREVIEW = 1;
    //    public const int iPRINT_PRINTIMMEDIATELY = 2;
    //    #endregion

    //    static public bool OpenDialogExcelFile(string strTitle, out string strFileNameOut)
    //    {
    //        strFileNameOut = "";
    //        try
    //        {
    //            OpenFileDialog ofd = new OpenFileDialog();
    //            ofd.Title = strTitle;
    //            ofd.Filter = "Excel file (*.xls)|*.xls";
    //            if (ofd.ShowDialog() != DialogResult.OK)
    //                return false;

    //            strFileNameOut = ofd.FileName;

    //             Return Good:
    //            return true;
    //        }
    //        catch (Exception exc)
    //        {
    //            string strExceptionMsg = exc.Message;
    //            UIMessage.Error(strExceptionMsg + "\r\nException from: CUtilityExcel.MyCheckAndGetTemplateFileName()");
    //            return false;
    //        }
    //    }


    //    static public bool OpenExcelFile(string strFileName, out NamespaceExcel.ApplicationClass excelapp, out NamespaceExcel.WorkbookClass excelwb)
    //    {
    //        excelapp = null;
    //        excelwb = null;
    //        try
    //        {
    //             Init excel application:
    //            excelapp = new NamespaceExcel.ApplicationClass();

    //             Open workbook:
    //            excelwb = (NamespaceExcel.WorkbookClass)excelapp.Workbooks.Open(
    //                strFileName
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                );

    //             Return Good:
    //            return true;
    //        }
    //        catch (Exception exc)
    //        {
				
    //            string strExceptionMsg = exc.Message;
    //            UIMessage.Error(strExceptionMsg + "\r\nException from: CUtilityExcel.MyOpenFile()");
    //            return false;
    //        }
    //    }

    //    static public bool MyOpenFileAndSaveAsResultFile(string strFileNameSource, string strFileNameResult, out NamespaceExcel.ApplicationClass excelapp, out NamespaceExcel.WorkbookClass excelwb)
    //    {
    //        excelapp = null;
    //        excelwb = null;
    //        try
    //        {
    //             Init:
    //            if (!OpenExcelFile(strFileNameSource, out excelapp, out excelwb)) return false;

    //             Create the result directory before save:
    //            string strDirectory = null;
    //            strDirectory = Path.GetDirectoryName(strFileNameResult);
    //            DirectoryInfo dirinfo = Directory.CreateDirectory(strDirectory);
    //            if (dirinfo == null) return false;

    //             Save:
    //            excelwb.SaveCopyAs(strFileNameResult);
    //            excelwb.Close(false, Type.Missing, Type.Missing);

    //             Reopen:
    //            excelwb = (NamespaceExcel.WorkbookClass)excelapp.Workbooks.Open(
    //                strFileNameResult
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                );

    //             Return Good:
    //            return true;
    //        }
    //        catch (Exception exc)
    //        {
    //            string strExceptionMsg = exc.Message;
    //            UIMessage.Error(strExceptionMsg + "\r\nException from: CUtilityExcel.MyOpenFileAndSaveAsResultFile()");
    //            return false;
    //        }
    //    }


    //    static public bool MySaveAndShowResultFile(NamespaceExcel.ApplicationClass excelapp, NamespaceExcel.WorkbookClass excelwb, int iPrintStyle)
    //    {
    //        try
    //        {
    //             Check and Save:
    //            if (excelapp == null || excelwb == null) return false;
    //            excelwb.Save();

    //            #region Show:
    //            if (iPrintStyle == iPRINT_SHOWSCREEN) // Show Excel screen:
    //            {
    //                excelapp.Visible = true;
    //            }
    //            else if (iPrintStyle == iPRINT_PRINTPREVIEW) // Show Printpreview:
    //            {
    //                excelwb.PrintOut(
    //                    Type.Missing //print from page
    //                    , Type.Missing //print to page
    //                    , 1 //number of copies
    //                    , 1 //preview?
    //                    , 1 //active printer?
    //                    , 0 //print to file?
    //                    , 0 //collate?
    //                    , Type.Missing //file name to print to
    //                    );
    //            }
    //            else if (iPrintStyle == iPRINT_PRINTIMMEDIATELY) // Print immediately:
    //            {
    //                excelwb.PrintOut(
    //                    Type.Missing //print from page
    //                    , Type.Missing //print to page
    //                    , 1 //number of copies
    //                    , 0 //preview?
    //                    , 1 //active printer?
    //                    , 0 //print to file?
    //                    , 0 //collate?
    //                    , Type.Missing //file name to print to
    //                    );
    //            }
    //            else
    //            {
    //                return false;
    //            }

    //            #endregion

    //             Return Good:
    //            return true;
    //        }
    //        catch (Exception exc)
    //        {
    //            string strExceptionMsg = exc.Message;
    //            UIMessage.Error(strExceptionMsg + "\r\nException from: CUtilityExcel.MyShowResultFile()");
    //            return false;
    //        }
    //    }

		
    //    static public bool MySaveAndShowResultFile(string strFileNameResult, NamespaceExcel.ApplicationClass excelapp, NamespaceExcel.WorkbookClass excelwb, int iPrintStyle)
    //    {
    //        try
    //        {
    //             Create the result directory before save:
    //            string strDirectory = null;
    //            strDirectory = Path.GetDirectoryName(strFileNameResult);
    //            DirectoryInfo dirinfo = Directory.CreateDirectory(strDirectory);
    //            if (dirinfo == null) return false;

    //             Save:
    //            excelwb.SaveCopyAs(strFileNameResult);
    //            excelwb.Close(false, Type.Missing, Type.Missing);

    //             Open:
    //            excelwb = (NamespaceExcel.WorkbookClass)excelapp.Workbooks.Open(
    //                strFileNameResult
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                , Type.Missing
    //                );

    //             Show:
    //            if (!MySaveAndShowResultFile(excelapp, excelwb, iPrintStyle)) return false;

    //             Return Good:
    //            return true;
    //        }
    //        catch (Exception exc)
    //        {
    //            string strExceptionMsg = exc.Message;
    //            UIMessage.Error(strExceptionMsg + "\r\nException from: CUtilityExcel.MySaveAndShowResultFile()");
    //            return false;
    //        }
    //    }

    //    static public bool MySaveAndShowResultFile(string strFileNameResult, NamespaceExcel.ApplicationClass excelapp, NamespaceExcel.WorkbookClass excelwb)
    //    {
    //        return MySaveAndShowResultFile(strFileNameResult, excelapp, excelwb, iPRINT_SHOWSCREEN);
    //    }


    //    static public bool MyFreeApplication(ref NamespaceExcel.ApplicationClass excelapp)
    //    {
    //        try
    //        {
    //            if (excelapp != null)
    //            {
    //                excelapp.Quit();
    //                excelapp = null;
    //            }

    //             Return Good:
    //            return true;
    //        }
    //        catch (Exception exc)
    //        {
    //            string strExceptionMsg = exc.Message;
    //            UIMessage.Error(strExceptionMsg + "\r\nException from: CUtilityExcel.MyFreeApplication()");
    //            return false;
    //        }
    //    }

    //    static public DateTime ExcelSerialDateToDMY(int nSerialDate)
    //    {
    //        int nDay;
    //        int nMonth;
    //        int nYear;
    //         Excel have a bug with 29-02-1900. 1900 is not a
    //         leap year, but Excel think it is...
    //        if (nSerialDate == 60)
    //        {
    //            nDay    = 29;
    //            nMonth    = 2;
    //            nYear    = 1900;
    //            DateTime dte1 = new DateTime(nYear,nMonth,nDay);
    //            return dte1;
    //        }
    //        else if (nSerialDate < 60)
    //        {
    //             Because of the 29-02-1900 bug, any serial date 
    //             under 60 is one off... Compensate.
    //            nSerialDate++;
    //        }

    //         Modified Julian to DMY calculation with an addition of 2415019
    //        int l = nSerialDate + 68569 + 2415019;
    //        int n = (int)(( 4 * l ) / 146097);
    //        l = l - (int)(( 146097 * n + 3 ) / 4);
    //        int i = (int)(( 4000 * ( l + 1 ) ) / 1461001);
    //        l = l - (int)(( 1461 * i ) / 4) + 31;
    //        int j = (int)(( 80 * l ) / 2447);
    //        nDay = l - (int)(( 2447 * j ) / 80);
    //        l = (int)(j / 11);
    //        nMonth = j + 2 - ( 12 * l );
    //        nYear = 100 * ( n - 49 ) + i + l;
    //        DateTime dte2 = new DateTime(nYear,nMonth,nDay);
    //        return dte2;
    //    }
    //}
    //#endregion

	//[HONDA] AnhNT added 13/06/2005
	#region CConnection
	public class ConnectionString
	{
		private const string REG_SERVER = @"ServerName";
		private const string REG_DATABASE = @"DatabaseName";
		private const string REG_USER = @"UserName";
		private const string REG_PASSWORD = @"Password";
		private const string REG_ENCRYPTED = @"Encrypted";
		
		private const string REG_UNINSTALL = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
		private const string REG_DISPLAY_NAME = @"DisplayName";
		private const string PARADISE_NAME = @"Paradise";
		private const string ENCRYPT_KEY = @"Paradise";
		public const string ENCRYPTED = @"1";
		public const string NONE_ENCRYPT = @"0";

		private string m_strServer, m_strDatabase, m_strUser, m_strPassword, m_strEncrypted;

		public ConnectionString()
		{
			m_strServer = "";
			m_strDatabase = "";
			m_strUser = "";
			m_strPassword = "";
			m_strEncrypted = NONE_ENCRYPT;
		}

		public ConnectionString(string strServer, string strDatabase, string strUser, string strPassword, string strEncrypted)
		{
			m_strServer = strServer;
			m_strDatabase = strDatabase;
			m_strUser = strUser;
			m_strPassword = strPassword;
			m_strEncrypted = strEncrypted;
		}

		public ConnectionString(string strServer, string strDatabase, string strUser, string strPassword)
		{
			m_strServer = strServer;
			m_strDatabase = strDatabase;
			m_strUser = strUser;
			m_strPassword = strPassword;
		}


		public void GetParam(out string strServer, out string strDatabase, out string strUser, out string strPassword, out string strEncrypted)
		{
			strServer = m_strServer;
			strDatabase = m_strDatabase ;
			strUser = m_strUser;
			strPassword = m_strPassword;
			strEncrypted = m_strEncrypted;
		}

		public void GetParam(out string strServer, out string strDatabase, out string strUser, out string strPassword)
		{
			strServer = m_strServer;
			strDatabase = m_strDatabase ;
			strUser = m_strUser;
			strPassword = m_strPassword;
		}


		public bool GetConnectParam()
		{
			RegistryKey RegEz = null;
			try
			{
				RegEz = Registry.LocalMachine.OpenSubKey(REG_UNINSTALL,true);
				foreach (string strSubKey in RegEz.GetSubKeyNames())
				{
					using (RegistryKey tempKey = RegEz.OpenSubKey(strSubKey, true))
					{
						foreach (string strSubValue in tempKey.GetValueNames())
						{
							if (strSubValue == REG_DISPLAY_NAME)
								if (tempKey.GetValue(REG_DISPLAY_NAME).ToString() == PARADISE_NAME)
								{
									if (CheckExistRegValue(tempKey, REG_SERVER) == true)
										m_strServer = tempKey.GetValue(REG_SERVER).ToString();
									if (CheckExistRegValue(tempKey, REG_DATABASE) == true)
										m_strDatabase = tempKey.GetValue(REG_DATABASE).ToString();
									if (CheckExistRegValue(tempKey, REG_USER) == true)
										m_strUser = tempKey.GetValue(REG_USER).ToString();
									if (CheckExistRegValue(tempKey, REG_PASSWORD) == true)
										m_strPassword = tempKey.GetValue(REG_PASSWORD).ToString();
									if (CheckExistRegValue(tempKey, REG_ENCRYPTED) == true)
										m_strEncrypted = tempKey.GetValue(REG_ENCRYPTED).ToString();
									goto SUCCESS;
								}
						}
					}
				}

			SUCCESS:
				if (m_strEncrypted.Trim() == ConnectionString.ENCRYPTED)
					m_strPassword = EncDec.Decrypt(m_strPassword, ENCRYPT_KEY);
				RegEz.Close();
				return true;
			}
			catch (Exception)
			{
				RegEz.Close();
				return false;
			}
		}

		public bool SaveConnectionParam()
		{
			RegistryKey RegEz = null;
			try
			{
				RegEz = Registry.LocalMachine.OpenSubKey(REG_UNINSTALL, true);
				foreach (string strSubKey in RegEz.GetSubKeyNames())
				{
					using (RegistryKey tempKey = RegEz.OpenSubKey(strSubKey, true))
					{
						foreach (string strSubValue in tempKey.GetValueNames())
						{
							if (strSubValue == REG_DISPLAY_NAME)
							{
								if (tempKey.GetValue(REG_DISPLAY_NAME).ToString() == PARADISE_NAME)
								{
									tempKey.SetValue(REG_SERVER, m_strServer);
									tempKey.SetValue(REG_DATABASE, m_strDatabase);
									tempKey.SetValue(REG_USER, m_strUser);
									if (m_strEncrypted == ConnectionString.ENCRYPTED) 
										tempKey.SetValue(REG_PASSWORD, EncDec.Encrypt(m_strPassword,ENCRYPT_KEY));
									else
										tempKey.SetValue(REG_PASSWORD, m_strPassword);
									tempKey.SetValue(REG_ENCRYPTED, m_strEncrypted);

									goto SUCCESS;
								}
							}
						}
					}
				}
			SUCCESS:
				RegEz.Close();
				return true;
			}
			catch
			{
				RegEz.Close();
				return false;
			}
		}

		public bool TestConnection()
		{
			//HPA.Component.Framework.CRunableObjectManager objManager = new HPA.Component.Framework.CRunableObjectManager();
			EzSql2 EzSQL = null;
			try
			{
				EzSQL = new EzSql2(m_strServer, m_strDatabase, m_strUser, m_strPassword);
				EzSQL.open();

				EzSQL.close();
				return true;
			}
			catch 
			{
				EzSQL.close();
				return false;
			}
		}

		private bool CheckExistRegValue(RegistryKey RegKey, string strKeyValue)
		{
			try
			{
				bool bFind = false;
				foreach (string strTemp in RegKey.GetValueNames())
				{
					if (strTemp == strKeyValue)
					{
						bFind = true;
						break;
					}
				}
				//Create Key Value if not exist
				if (bFind == false)
					RegKey.SetValue(strKeyValue,"");
				
				return true;
			}
			catch 
			{
				return false;
			}
		}

	}

	public class DBConnection
	{
		#region CONSTRUCTORS & DESCTRUCTORS
		public DBConnection()
		{
			m_strServer = "";
			m_strDatabase = "";
			m_strUser = "";
			m_strPassword = "";
			m_strEncrypted = NO_ENCRYPTED;
		}	
		public DBConnection(string strServer, string strDatabase, string strUser, string strPassword, string strEncrypted)
		{			
			m_strServer = strServer;
			m_strDatabase = strDatabase;
			m_strUser = strUser;
			m_strPassword = strPassword;
			m_strEncrypted = strEncrypted;
		}	
		public DBConnection(string strServer, string strDatabase, string strUser, string strPassword)
		{
			m_strServer = strServer;
			m_strDatabase = strDatabase;
			m_strUser = strUser;
			m_strPassword = strPassword;
		}
		#endregion

		#region STATIC & CONSTANT
		private const byte DELTA_KEY = 71;
		private const string FILE_NAME = "Paradise.ini";
		private const string SEPARATE_CHAR = ";";
		public const string ENCRYPTED = @"1";
		public const string  NO_ENCRYPTED = @"0";
		#endregion

		#region VARIABLES
		private string m_strServer;
		private string m_strDatabase;
		private string m_strUser;
		private string m_strPassword;
		private string m_strEncrypted;
		#endregion

		#region PUBLIC METHODS
        public static int CountDate(DateTime ValueFrom, DateTime ValueTo)
        {
            int retVal = 1;
            TimeSpan ts = ValueTo - ValueFrom;
            retVal = Convert.ToInt32(ts.TotalDays);
            return retVal;
        }
		public bool getDBConnectionInfo(out string strServer, out string strDatabase, out string strUserName, out string strPassword, out string strEncrypted)
		{
			FileStream buf = null;
			try
			{
				// open file
                buf = new FileStream(String.Format("{0}\\{1}", Application.StartupPath, FILE_NAME), FileMode.Open);

				string str = "";
				int d = buf.ReadByte();
				while (d != -1)
				{
					// shifted decoding
					d -= DELTA_KEY;
					if (d < 0)
						d += 256;

					str += (char)d;

					d = buf.ReadByte();
				}

				// close file
				buf.Close();

				// parse
				string[] arrStr = str.Split(SEPARATE_CHAR.ToCharArray(), 5);

				// return info
				strServer = arrStr[0];
				strDatabase = arrStr[1];
				strUserName = arrStr[2];
				strPassword = arrStr[3];
				strEncrypted = arrStr[4];

				m_strServer = strServer;
				m_strDatabase = strDatabase;
				m_strUser = strUserName;
				m_strPassword = strPassword;
				m_strEncrypted = strEncrypted;
				// successfully
				return true;
			}
			catch (Exception exc)
			{
				if (buf != null)
				{
					buf.Close();
					buf = null;
				}

				// we have some proplems when trying to get connection info from file
				// to resolve, ask user that information
				strServer = "";
				strDatabase = "";
				strUserName = "";
				strPassword = "";
				strEncrypted = NO_ENCRYPTED;

				m_strServer = strServer;
				m_strDatabase = strDatabase; 
				m_strUser = strUserName;
				m_strPassword = strPassword;
				m_strEncrypted = strEncrypted;

				throw(exc);
			}			
		}	
		public bool getDBConnectionInfo(out string strServer, out string strDatabase, out string strUserName, out string strPassword)
		{			
			string strEncrypted;
			return getDBConnectionInfo(out strServer, out strDatabase, out strUserName, out strPassword, out strEncrypted);
		}
		public bool checkConnectionInfo()
		{
			return checkConnectionInfo(m_strServer,m_strDatabase,m_strUser,m_strPassword);
		}
		public bool checkConnectionInfo(string strServer, string strDatabase, string strUserName, string strPassword)
		{
			EzSql2 EzSQL = null;
			try
			{
				EzSQL = new EzSql2(strServer, strDatabase, strUserName, strPassword);
				EzSQL.open();

				EzSQL.close();
				return true;
			}
			catch 
			{
				EzSQL.close();
				return false;
			}
		}
		public bool saveConnectionInfo()
		{
			return saveConnectionInfo(m_strServer,m_strDatabase,m_strUser,m_strPassword,NO_ENCRYPTED);
		}
		public bool saveConnectionInfo(string strServer, string strDatabase, string strUserName, string strPassword, string strEncrypted)
		{
			if ((strServer == "") ||
				(strDatabase == "") ||
				(strUserName == ""))
			{
				MessageBox.Show("Invalid data!","Paradise", MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return false;
			}
			System.IO.FileStream buf = null;
			try
			{
				string str = strServer + SEPARATE_CHAR + strDatabase + SEPARATE_CHAR + strUserName + SEPARATE_CHAR + strPassword + SEPARATE_CHAR + strEncrypted ;

				// create file
                buf = new System.IO.FileStream(String.Format("{0}\\{1}", Application.StartupPath, FILE_NAME), System.IO.FileMode.Create);				

				// shifted encoding
				if (strEncrypted == ENCRYPTED)
				{
					for (int i = 0; i < str.Length; i++)
					{
						buf.WriteByte((byte)(((byte)str[i] + DELTA_KEY) % 256));
					}
				}

				// flush to data file
				buf.Flush();

				// close file
				buf.Close();
				
				// return Good :
				return true;
			}
			catch (Exception ex)
			{
				if (buf != null)
					buf.Close();
				buf = null;
				throw(ex);				
			}
		}
		#endregion
	}
	#endregion

	#region ENCRYPTION
	/*========================================================================
	 * Purpose	: Encrypt or Decrypt string, file, ...
	 * Created	: 20/06/2005	
	 * Author	: AnhNT
	 * Desc		: [None]
	=========================================================================*/	
	public class EncDec
	{
		public static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV) 
		{ 
			// Create a MemoryStream to accept the encrypted bytes 
			MemoryStream ms = new MemoryStream(); 

			// Create a symmetric algorithm. 
			Rijndael alg = Rijndael.Create(); 

			// Now set the key and the IV. 
			alg.Key = Key; 
			alg.IV = IV; 

			// Create a CryptoStream through which we are going to be
			CryptoStream cs = new CryptoStream(ms, 
				alg.CreateEncryptor(), CryptoStreamMode.Write); 

			// Write the data and make it do the encryption 
			cs.Write(clearData, 0, clearData.Length); 

			// Close the crypto stream (or do FlushFinalBlock). 
			cs.Close(); 

			// Now get the encrypted data from the MemoryStream.
			byte[] encryptedData = ms.ToArray();

			return encryptedData; 
		} 

		// Encrypt a string into a string using a password 
		//    Uses Encrypt(byte[], byte[], byte[]) 

		public static string Encrypt(string clearText, string Password) 
		{ 
			// First we need to turn the input string into a byte array. 
			byte[] clearBytes = 
				System.Text.Encoding.Unicode.GetBytes(clearText); 

			PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, 
				new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 
							   0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76}); 

			byte[] encryptedData = Encrypt(clearBytes, 
				pdb.GetBytes(32), pdb.GetBytes(16)); 

			return Convert.ToBase64String(encryptedData); 

		}
    
		// Encrypt bytes into bytes using a password 
		//    Uses Encrypt(byte[], byte[], byte[]) 

		public static byte[] Encrypt(byte[] clearData, string Password) 
		{ 
			PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, 
				new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 
							   0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76}); 

			return Encrypt(clearData, pdb.GetBytes(32), pdb.GetBytes(16)); 

		}

		// Encrypt a file into another file using a password 
		public static void Encrypt(string fileIn, 
			string fileOut, string Password) 
		{ 

			// First we are going to open the file streams 
			FileStream fsIn = new FileStream(fileIn, 
				FileMode.Open, FileAccess.Read); 
			FileStream fsOut = new FileStream(fileOut, 
				FileMode.OpenOrCreate, FileAccess.Write); 

			// Then we are going to derive a Key and an IV from the
			// Password and create an algorithm 
			PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, 
				new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 
							   0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76}); 

			Rijndael alg = Rijndael.Create(); 
			alg.Key = pdb.GetBytes(32); 
			alg.IV = pdb.GetBytes(16); 

			CryptoStream cs = new CryptoStream(fsOut, 
				alg.CreateEncryptor(), CryptoStreamMode.Write); 

			int bufferLen = 4096; 
			byte[] buffer = new byte[bufferLen]; 
			int bytesRead; 

			do 
			{ 
				// read a chunk of data from the input file 
				bytesRead = fsIn.Read(buffer, 0, bufferLen); 

				// encrypt it 
				cs.Write(buffer, 0, bytesRead); 
			} while(bytesRead != 0); 

			// close everything 

			// this will also close the unrelying fsOut stream
			cs.Close(); 
			fsIn.Close();     
		} 

		// Decrypt a byte array into a byte array using a key and an IV 
		public static byte[] Decrypt(byte[] cipherData, 
			byte[] Key, byte[] IV) 
		{ 
			// Create a MemoryStream that is going to accept the
			// decrypted bytes 
			MemoryStream ms = new MemoryStream(); 

			Rijndael alg = Rijndael.Create(); 

			alg.Key = Key; 
			alg.IV = IV; 

			CryptoStream cs = new CryptoStream(ms, 
				alg.CreateDecryptor(), CryptoStreamMode.Write); 

			// Write the data and make it do the decryption 
			cs.Write(cipherData, 0, cipherData.Length); 

			cs.Close(); 

			byte[] decryptedData = ms.ToArray(); 

			return decryptedData; 
		}

		// Decrypt a string into a string using a password 
		//    Uses Decrypt(byte[], byte[], byte[]) 

		public static string Decrypt(string cipherText, string Password) 
		{ 
			// First we need to turn the input string into a byte array. 
			// We presume that Base64 encoding was used 
			byte[] cipherBytes = Convert.FromBase64String(cipherText); 

			PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, 
				new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 
							   0x64, 0x76, 0x65, 0x64, 0x65, 0x76}); 

			byte[] decryptedData = Decrypt(cipherBytes, 
				pdb.GetBytes(32), pdb.GetBytes(16)); 

			return System.Text.Encoding.Unicode.GetString(decryptedData); 
		}

		// Decrypt bytes into bytes using a password 
		//    Uses Decrypt(byte[], byte[], byte[]) 

		public static byte[] Decrypt(byte[] cipherData, string Password) 
		{ 
			// turn the password into Key and IV. 
			PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, 
				new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 
							   0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76}); 

			// get the key/IV and do the Decryption using the 
			return Decrypt(cipherData, pdb.GetBytes(32), pdb.GetBytes(16)); 
		}

		// Decrypt a file into another file using a password 
		public static void Decrypt(string fileIn, 
			string fileOut, string Password) 
		{ 
    
			// First we are going to open the file streams 
			FileStream fsIn = new FileStream(fileIn,
				FileMode.Open, FileAccess.Read); 
			FileStream fsOut = new FileStream(fileOut,
				FileMode.OpenOrCreate, FileAccess.Write); 
  
			// Then we are going to derive a Key and an IV from
			// the Password and create an algorithm 
			PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, 
				new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 
							   0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76}); 
			Rijndael alg = Rijndael.Create(); 

			alg.Key = pdb.GetBytes(32); 
			alg.IV = pdb.GetBytes(16); 

			CryptoStream cs = new CryptoStream(fsOut, 
				alg.CreateDecryptor(), CryptoStreamMode.Write); 
  
			// initialize a buffer 
			int bufferLen = 4096; 
			byte[] buffer = new byte[bufferLen]; 
			int bytesRead; 

			do 
			{ 
				// read a chunk of data from the input file 
				bytesRead = fsIn.Read(buffer, 0, bufferLen); 

				// Decrypt it 
				cs.Write(buffer, 0, bytesRead); 

			} while(bytesRead != 0); 

			// close everything 
			cs.Close(); // this will also close the unrelying fsOut stream 
			fsIn.Close();     
		}
	}
	#endregion
}
