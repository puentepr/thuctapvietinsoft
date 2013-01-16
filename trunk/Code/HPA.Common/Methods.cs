using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace HPA.Common
{
    public class Methods
    {
        public static DialogResult ShowMessage(string MessID)
        {
            return System.Windows.Forms.MessageBox.Show( GetMessage(MessID),HPA.Common.CommonConst.CPN_STD_NAME);
        }
        public static DialogResult ShowMessage(string MessID,System.Windows.Forms.MessageBoxButtons MessageButtons,System.Windows.Forms.MessageBoxIcon MessageIcons)
        {
            return System.Windows.Forms.MessageBox.Show(GetMessage(MessID), HPA.Common.CommonConst.CPN_STD_NAME, MessageButtons, MessageIcons);
        }
        public static void ShowError(Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message, HPA.Common.CommonConst.CPN_STD_NAME, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            WriteFile(ex.ToString(), HPA.Common.CommonConst.ERROR_LOG_FILE);
        }
        public static void ChangeLanguage(ref System.Windows.Forms.Control.ControlCollection ctrs)
        {
            const string LBL = "lbl";

            foreach (System.Windows.Forms.Control ctr in ctrs)
            {
               
                if (ctr is DevExpress.XtraGrid.GridControl)
                {
                    ((DevExpress.XtraGrid.GridControl)ctr).FormsUseDefaultLookAndFeel = false;
                    ((DevExpress.XtraGrid.GridControl)ctr).LookAndFeel.UseDefaultLookAndFeel = false;
                    ((DevExpress.XtraGrid.GridControl)ctr).LookAndFeel.SkinName = HPA.Common.CommonConst.SKIN_BLUE;
                    DevExpress.XtraGrid.Views.Grid.GridView grv = (DevExpress.XtraGrid.Views.Grid.GridView)((DevExpress.XtraGrid.GridControl)ctr).MainView;
                    grv.GroupPanelText = HPA.Common.Methods.GetMessage("GroupPanelText");
                    foreach (DevExpress.XtraGrid.Columns.GridColumn grdCol in grv.Columns)
                    {
                        try
                        {
                           
                            grdCol.Caption = HPA.Common.Methods.GetMessage(grdCol.Name);
                        }

                        catch
                        {
                            grdCol.Caption = String.Format("{0} {1}", grdCol.Name, HPA.Common.StaticVars.LanguageID);
                        }
                    }
                    foreach (DevExpress.XtraEditors.Repository.RepositoryItem rpe in ((DevExpress.XtraGrid.GridControl)ctr).RepositoryItems)
                    {
                        if (rpe is DevExpress.XtraEditors.Repository.RepositoryItemDateEdit)
                        {
                            ((DevExpress.XtraEditors.Repository.RepositoryItemDateEdit)rpe).Mask.EditMask = HPA.Common.CommonConst.DATE_FORMAT_PATTEN;
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

                //else
                //{
                if ((ctr is DevExpress.XtraEditors.LabelControl) || (ctr is System.Windows.Forms.Label) || (ctr is System.Windows.Forms.Button) || (ctr is System.Windows.Forms.CheckBox) || (ctr is System.Windows.Forms.RadioButton)
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
                            ctr.Text = HPA.Common.Methods.GetMessage(ctr.Name);
                        }
                    }
                    catch
                    {
                        ctr.Text = String.Format("{0} {1}", ctr.Name, HPA.Common.StaticVars.LanguageID);
                    }
                }

                if (ctr.Controls.Count > 0)
                {
                    System.Windows.Forms.Control.ControlCollection con = ctr.Controls;
                    ChangeLanguage (ref con);
                }
                //}
            }
        }
        static void UIMessage_RowPostPaint(object sender, System.Windows.Forms.DataGridViewRowPostPaintEventArgs e)
        {
            System.Windows.Forms.DataGridView grd = ((System.Windows.Forms.DataGridView)sender);
            using (System.Drawing.SolidBrush b = new System.Drawing.SolidBrush(grd.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 8, e.RowBounds.Location.Y + 4);
            }
        }
        public static bool HasAccessRight(string fullCalssName)
        {
            HPA.SQL.DataDaigramDataContext sqlcon = new SQL.DataDaigramDataContext();
            if (sqlcon.SC_USEROBJECTRIGHT_GET(fullCalssName, HPA.Common.StaticVars.LoginID) <= 0)
                return false;
            else
                return true;
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

        public static string ReadFile(string FILE_NAME)
        {
            string str = "";
            
            try
            {
                using (StreamReader sr = new StreamReader(HPA.Common.StaticVars.App_path + FILE_NAME))
                {
                    str = sr.ReadToEnd();
                    sr.Close();
                }
                return str;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static void WriteFile(string str)
        {
            using (StreamWriter outfile = new StreamWriter(HPA.Common.StaticVars.App_path + HPA.Common.CommonConst.PARADISE_INI))
            {
                outfile.Write(str);
                outfile.Close();
            }
            
        }
        public static void WriteFile(string str,string fileName)
        {
            using (StreamWriter outfile = new StreamWriter(HPA.Common.StaticVars.App_path + fileName))
            {
                outfile.Write(str);
                outfile.Close();
            }

        }
        public static bool Kiemtrchuoi(string s, System.Text.RegularExpressions.Regex r)
        {
            bool b = r.IsMatch(s);
            if (b)
            {
                return true;
            }
            else return false;
        }
    }
}
