using System;
using System.IO;
using System.Data;

namespace HPA.Common
{
	/// <summary>
	/// Summary description for Helper.
	/// </summary>
	public class Helper
	{
		// =======================================================
		// NAME:	ShowException
		// TASK:	show information of an exception.
		//			this function is used to unify the way we notify an error to user.
		// PARAM:	- e is the exception shown
		//			- strLocation is where the exception is thrown
		//			- strOtherInformation is additional information to describe the error
		// RETURN:	NA
		// THROW:	
		// REV:	
		//	2003-05-02	created by TRAN VIET HA
		// =======================================================
		/// <summary>
		/// show information of an exception
		/// </summary>
		public static void ShowException(Exception e, string strLocation, string strOtherInformation)
		{
			System.Diagnostics.Trace.Assert(e != null);

			string str = e.Message;
			str += "\n\n"+e.StackTrace;

			if (strLocation != null)
				str += "\n\nThis error is throwed from " + strLocation;
			if (strOtherInformation != null)
				str += "\n\n" + strOtherInformation;

			UIMessage.Error(str);
            LogError(e, strLocation, strOtherInformation);
		}

		// =======================================================
		// NAME:	ShowMessage
		// TASK:	show a message stored in resource
		// PARAM:	resource name
		// RETURN:	NA
		// THROW:	
		// REV:	
		//	2003-06-06	created by TRAN VIET HA
		// =======================================================
		/// <summary>
		/// show a message stored in resource
		/// </summary>
		public static void ShowMessage(string strResourceContainer, string strResourceName)
		{
			UIMessage.Notify(GetString(strResourceContainer, strResourceName, System.Reflection.Assembly.GetCallingAssembly()));
		}

		// =======================================================
		// NAME:	GetString
		// TASK:	return a message stored in resource
		// PARAM:	resource name
		// RETURN:	NA
		// THROW:	
		// REV:	
		//	2003-06-06	created by TRAN VIET HA
		// =======================================================
		/// <summary>
		/// return a message stored in resource
		/// </summary>
		public static string GetString(string strResourceContainer, string strResourceName)
		{
			System.Reflection.Assembly asmContainer = System.Reflection.Assembly.GetCallingAssembly();
			
			return GetString(strResourceContainer, strResourceName, asmContainer);
		}
		public static string GetString(string strResourceContainer, string strResourceName, System.Reflection.Assembly asmContainer)
		{
			try
			{
				System.Resources.ResourceManager rm = new System.Resources.ResourceManager(asmContainer.GetName().Name + "." + strResourceContainer, asmContainer);
			
				return rm.GetString(strResourceName);
			}
			catch (Exception e)
			{
				ShowException(e, System.Reflection.Assembly.GetExecutingAssembly().FullName + ".GetString()", null);
				return String.Empty;
			}
		}

        public static void LogError(Exception e, string strLocation, string strOtherInformation)
        {
            System.Diagnostics.Trace.Assert(e != null);

            string str = e.Message;
            str += "\n\n" + e.StackTrace;

            if (strLocation != null)
                str += "\n\nThis error is throwed from " + strLocation;
            if (strOtherInformation != null)
                str += "\n\n" + strOtherInformation;

            StreamWriter sw = new StreamWriter("Error.txt", true);
            sw.WriteLine();
            sw.Write("______________________________________________\n\n");
            sw.WriteLine();
            sw.Write(str);
            sw.Close();
            sw.Dispose();
            //Send email to vietinsoft
            //try
            //{
            //    String Username = "Support@vietinsoft.com";
            //    String Password = "LuaThieng";
            //    String Smtp = "smtp.gmail.com";
            //    String Content = "";

            //    String Title = "Errors report";
            //    Content = str;
            //    Content += "<br/><br/><hr/> This email is sent from Humamn resource management software developed by Vietinsoft.com <br/> Regards.<br/> Vietinsoft Co., ltd.";

            //    Email.Sendmail(Username, Password, Smtp, "Support@vietinsoft.com", System.Windows.Forms.Application.CompanyName, Title, Content);
            //}
            //catch { }
        }
		public static object[] BuildParam(System.Data.DataRow dr, string strPrefix, params string[] strParam)
		{
			if (strParam == null)
				return null;

			object[] p = new object[strParam.Length * 2];

			int i = 0;
			foreach (string s in strParam)
			{
				p[i++] = strPrefix + s;
				p[i++] = dr[s];
			}

			return p;
		}
	}
}
