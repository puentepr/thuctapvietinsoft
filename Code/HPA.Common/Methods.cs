using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPA.Common
{
    public class Methods
    {
        public static void ShowMessage(string MessID)
        {
            System.Windows.Forms.MessageBox.Show(HPA.Common.CommonConst.CPN_STD_NAME, GetMessage(MessID));
        }
        public static void ShowMessage(string MessID,System.Windows.Forms.MessageBoxButtons MessageButtons,System.Windows.Forms.MessageBoxIcon MessageIcons)
        {
            System.Windows.Forms.MessageBox.Show(HPA.Common.CommonConst.CPN_STD_NAME, GetMessage(MessID), MessageButtons, MessageIcons);
        }
        public static void ShowError(Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(HPA.Common.CommonConst.CPN_STD_NAME, ex.Message,System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
            
        }
        public static string GetMessage(string MessID)
        {
            string retVal = string.Empty;
            if (HPA.Common.StaticVars.LanguageID.Equals(string.Empty))
                HPA.Common.StaticVars.LanguageID = "VN";
            HPA.SQL.DataDaigramDataContext sqlcon = new SQL.DataDaigramDataContext();
            sqlcon.Get_Message(MessID, HPA.Common.StaticVars.LanguageID,ref retVal);
            if (retVal.Equals(string.Empty))
                retVal = string.Format("{0} {1}", MessID, HPA.Common.StaticVars.LanguageID);

            return retVal;
        }
    }
}
