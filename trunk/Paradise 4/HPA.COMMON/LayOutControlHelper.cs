using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using HPA.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HPA.Common
{
    public class LayOutControlHelper
    {
        public static DXValidationProvider dxValidationProvider1 = new DXValidationProvider();
        public static void SetForeColor(ref Control ctr, DataRow dr)
        {
            try
            {
                string[] colorArr = dr[CommonConst.ForeColor].ToString().Split(',');
                if (colorArr.Length >= 4)
                    ctr.ForeColor = Color.FromArgb(Convert.ToInt32(colorArr[0]), Convert.ToInt32(colorArr[1]), Convert.ToInt32(colorArr[2]), Convert.ToInt32(colorArr[3]));
            }
            catch (Exception ex)
            {
                Helper.LogError(ex, ex.Message, "SetForeColor");
            }
        }
        public static void SetFontStyle(ref Control ctr, DataRow dr)
        {
            try
            {
                if (dr[CommonConst.FontBold] != DBNull.Value)
                {
                    if (dr[CommonConst.FontStrikeout] != DBNull.Value && dr[CommonConst.FontUnderline] != DBNull.Value)
                        if (ctr is DevExpress.XtraEditors.LabelControl)
                        {
                            ((DevExpress.XtraEditors.LabelControl)ctr).Appearance.Font = new Font(dr[CommonConst.FontName].ToString(), (float)Convert.ToDouble(dr[CommonConst.FontSize]), ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | FontStyle.Strikeout | FontStyle.Underline)), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            return;
                        }
                    if (dr[CommonConst.FontStrikeout] != DBNull.Value)
                        if (ctr is DevExpress.XtraEditors.LabelControl)
                        {
                            ((DevExpress.XtraEditors.LabelControl)ctr).Appearance.Font = new Font(dr[CommonConst.FontName].ToString(), (float)Convert.ToDouble(dr[CommonConst.FontSize]), ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | FontStyle.Strikeout)), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            return;
                        }
                    if (dr[CommonConst.FontUnderline] != DBNull.Value)
                        if (ctr is DevExpress.XtraEditors.LabelControl)
                        {
                            ((DevExpress.XtraEditors.LabelControl)ctr).Appearance.Font = new Font(dr[CommonConst.FontName].ToString(), (float)Convert.ToDouble(dr[CommonConst.FontSize]), ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | FontStyle.Underline)), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            return;
                        }
                    if (ctr is DevExpress.XtraEditors.LabelControl)
                    {
                        ((DevExpress.XtraEditors.LabelControl)ctr).Appearance.Font = new Font(dr[CommonConst.FontName].ToString(), (float)Convert.ToDouble(dr[CommonConst.FontSize]), ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold)), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }
                }
                if (dr[CommonConst.FontItalic] != DBNull.Value)
                {
                    if (dr[CommonConst.FontStrikeout] != DBNull.Value && dr[CommonConst.FontUnderline] != DBNull.Value)
                        if (ctr is DevExpress.XtraEditors.LabelControl)
                        {
                            ((DevExpress.XtraEditors.LabelControl)ctr).Appearance.Font = new Font(dr[CommonConst.FontName].ToString(), (float)Convert.ToDouble(dr[CommonConst.FontSize]), ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Italic | FontStyle.Strikeout | FontStyle.Underline)), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            return;
                        }
                    if (dr[CommonConst.FontStrikeout] != DBNull.Value)
                        if (ctr is DevExpress.XtraEditors.LabelControl)
                        {
                            ((DevExpress.XtraEditors.LabelControl)ctr).Appearance.Font = new Font(dr[CommonConst.FontName].ToString(), (float)Convert.ToDouble(dr[CommonConst.FontSize]), ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Italic | FontStyle.Strikeout)), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            return;
                        }
                    if (dr[CommonConst.FontUnderline] != DBNull.Value)
                        if (ctr is DevExpress.XtraEditors.LabelControl)
                        {
                            ((DevExpress.XtraEditors.LabelControl)ctr).Appearance.Font = new Font(dr[CommonConst.FontName].ToString(), (float)Convert.ToDouble(dr[CommonConst.FontSize]), ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Italic | FontStyle.Underline)), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            return;
                        }
                    if (ctr is DevExpress.XtraEditors.LabelControl)
                    {
                        ((DevExpress.XtraEditors.LabelControl)ctr).Appearance.Font = new Font(dr[CommonConst.FontName].ToString(), (float)Convert.ToDouble(dr[CommonConst.FontSize]), ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }
                }
                if (dr[CommonConst.FontItalic] == DBNull.Value && dr[CommonConst.FontBold] == DBNull.Value)
                {
                    if (dr[CommonConst.FontStrikeout] != DBNull.Value && dr[CommonConst.FontUnderline] != DBNull.Value)
                        if (ctr is DevExpress.XtraEditors.LabelControl)
                        {
                            ((DevExpress.XtraEditors.LabelControl)ctr).Appearance.Font = new Font(dr[CommonConst.FontName].ToString(), (float)Convert.ToDouble(dr[CommonConst.FontSize]), ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular | FontStyle.Strikeout | FontStyle.Underline)), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            return;
                        }
                    if (dr[CommonConst.FontStrikeout] != DBNull.Value)
                        if (ctr is DevExpress.XtraEditors.LabelControl)
                        {
                            ((DevExpress.XtraEditors.LabelControl)ctr).Appearance.Font = new Font(dr[CommonConst.FontName].ToString(), (float)Convert.ToDouble(dr[CommonConst.FontSize]), ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular | FontStyle.Strikeout)), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            return;
                        }
                    if (dr[CommonConst.FontUnderline] != DBNull.Value)
                        if (ctr is DevExpress.XtraEditors.LabelControl)
                        {
                            ((DevExpress.XtraEditors.LabelControl)ctr).Appearance.Font = new Font(dr[CommonConst.FontName].ToString(), (float)Convert.ToDouble(dr[CommonConst.FontSize]), ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular | FontStyle.Underline)), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            return;
                        }
                    if (ctr is DevExpress.XtraEditors.LabelControl)
                    {
                        ((DevExpress.XtraEditors.LabelControl)ctr).Appearance.Font = new Font(dr[CommonConst.FontName].ToString(), (float)Convert.ToDouble(dr[CommonConst.FontSize]), ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex, ex.Message, "SetFontStyle");
            }
        }
        public static void LoadControlsLayOut(ref System.Windows.Forms.SplitContainer ctrs, string formName)
        {
            int height = 0;
            const int width = 250;
            const int heightBox = 32;
            Control ctlParent = ctrs.Panel1;
            try
            {
                string ControlName = string.Empty;
                DataTable dt = UIMessage.DBEngine.execReturnDataTable(string.Format("select * from tblFormLayout where FormName = '{0}' and (IsLayout is null or IsLayout =0)", formName));
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ControlName = dr["ControlName"].ToString();
                        if (ctlParent.Controls.Find(ControlName, true).Length <= 0)
                        {
                            DevExpress.XtraEditors.LabelControl lbl = new DevExpress.XtraEditors.LabelControl() { Name = string.Format("lbl{0}", ControlName), Text = UIMessage.Get_Message(string.Format("lbl{0}", ControlName)), Location = new Point(10, height) };
                            ctlParent.Controls.Add(lbl);
                            switch (dr["SystemType"].ToString())
                            {
                                case "ComboBox":
                                    DevExpress.XtraEditors.LookUpEdit led = new DevExpress.XtraEditors.LookUpEdit() { Name = string.Format("cbx{0}", ControlName), Location = new Point(130, height), Width = width, Height = heightBox };
                                    ctlParent.Controls.Add(led);
                                    break;
                                case "Datetime":
                                case "Date":
                                    if (!ControlName.ToLower().Contains("time"))
                                    {
                                        DevExpress.XtraEditors.DateEdit dtp = new DevExpress.XtraEditors.DateEdit() { Name = string.Format("dtp{0}", ControlName), Location = new Point(130, height), Width = width, Height = heightBox };
                                        ctlParent.Controls.Add(dtp);
                                    }
                                    else
                                    {
                                        DevExpress.XtraEditors.TimeEdit tid = new DevExpress.XtraEditors.TimeEdit() { Name = string.Format("tid{0}", ControlName), Location = new Point(130, height), Width = width, Height = heightBox };
                                        ctlParent.Controls.Add(tid);
                                    }
                                    break;
                                case "Time":
                                    DevExpress.XtraEditors.TimeEdit tid1 = new DevExpress.XtraEditors.TimeEdit() { Name = string.Format("tid{0}", ControlName), Location = new Point(130, height), Width = width, Height = heightBox };
                                    ctlParent.Controls.Add(tid1);
                                    break;
                                case "CheckEdit":
                                    DevExpress.XtraEditors.CheckEdit ckb = new DevExpress.XtraEditors.CheckEdit() { Name = string.Format("ckb{0}", ControlName), Location = new Point(130, height), Width = width, Height = heightBox };
                                    ctlParent.Controls.Add(ckb);
                                    break;
                                case "PictureEdit":
                                    DevExpress.XtraEditors.PictureEdit pic = new DevExpress.XtraEditors.PictureEdit() { Name = string.Format("ckb{0}", ControlName), Location = new Point(130, height), Width = width, Height = heightBox };
                                    ctlParent.Controls.Add(pic);
                                    break;
                                default:
                                    DevExpress.XtraEditors.TextEdit txt = new DevExpress.XtraEditors.TextEdit() { Name = string.Format("txt{0}", ControlName), Location = new Point(130, height), Width = width, Height = heightBox };
                                    ctlParent.Controls.Add(txt);
                                    break;
                            }
                            height += 25;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex, ex.Message, "LoadControlsLayOut()");
            }
            LoadDesignedControls(ctrs, formName);
        }
        private static IComponent CreateComponent(Type componentClass, string name)
        {
            IComponent newComponent = Activator.CreateInstance(componentClass) as IComponent;
            return newComponent;
        }
        private static IComponent CreateComponent(string systemType, string name)
        {
            Type type = Type.GetType(systemType);
            if (type == null)
                throw new Exception() { HelpLink = systemType };
            return CreateComponent(type, name);
        }

        private static void LoadDesignedControls(SplitContainer ctrs, string formName)
        {
            try
            {
                Control ctlParent = ctrs.Panel1;
                string ControlName = string.Empty;
                DataTable dtControlsList = UIMessage.DBEngine.execReturnDataTable(string.Format("select * from tblFormLayout where FormName = '{0}' and (IsLayout = 1)", formName));
                if (dtControlsList != null && dtControlsList.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtControlsList.Rows)
                    {
                        if (dr[CommonConst.ControlName] != DBNull.Value && !dr[CommonConst.ControlName].ToString().Trim().Equals(string.Empty) && !dr[CommonConst.ControlName].ToString().Equals(formName))
                        {
                            Control ctr = (Control)CreateComponent(dr[CommonConst.SystemType].ToString(), dr[CommonConst.ControlName].ToString());
                            ctr.Name = dr[CommonConst.ControlName].ToString();
                            ctr.Location = new Point((int)dr[CommonConst.LocationX], (int)dr[CommonConst.LocationY]);
                            if (ctr is DevExpress.XtraEditors.LabelControl)
                                ctr.Text = HPA.Common.UIMessage.Get_Message(ctr.Name);
                            ctr.Size = new Size((int)dr[CommonConst.Width], (int)dr[CommonConst.Height]);
                            ctr.Visible = Convert.ToBoolean(dr[CommonConst.Visible]);
                            ctr.Enabled = Convert.ToBoolean(dr[CommonConst.Enabled]);
                            if (dr[CommonConst.TabIndex] != DBNull.Value)
                                ctr.TabIndex = Convert.ToInt32(dr[CommonConst.TabIndex]);
                            if (dr[CommonConst.FontName] != DBNull.Value)
                                SetFontStyle(ref ctr, dr);
                            if (dr[CommonConst.ForeColor] != DBNull.Value)
                                SetForeColor(ref ctr, dr);
                            if (ctr is PictureBox)
                            {
                                if (dr[CommonConst.Image] != DBNull.Value)
                                ((PictureBox)ctr).Image = CImageUtility.byteArrayToImage((byte[])dr[CommonConst.Image]);
                            }
                            if (dr[CommonConst.Validation] != DBNull.Value)
                                SetValidationToControl(ref ctr, dr);
                            if (dr[CommonConst.MaskType] != DBNull.Value)
                                SetMastToControl(ref ctr, dr);
                            ctlParent.Controls.Add(ctr);
                        }
                        else if (dr[CommonConst.ControlName].ToString().Equals(formName))
                        {
                            ctlParent.Size = new Size((int)dr[CommonConst.Width], (int)dr[CommonConst.Height]);
                            ctlParent.Name = dr[CommonConst.FormName].ToString();
                        }
                    }
                    foreach (DataRow dr in dtControlsList.Rows)
                    {
                        if (dr[CommonConst.ParentControl] == DBNull.Value)
                            continue;
                        string PrentCtrName = dr[CommonConst.ParentControl].ToString();
                        if (!PrentCtrName.Equals(ctlParent.Name) && !dr[CommonConst.ControlName].ToString().Trim().Equals(string.Empty))
                        {
                            if (ctlParent.Controls.Find(PrentCtrName, true).Length > 0 && ctlParent.Controls.Find(dr[CommonConst.ControlName].ToString(), true).Length > 0)
                                ctlParent.Controls.Find(PrentCtrName, true)[0].Controls.Add(ctlParent.Controls.Find(dr[CommonConst.ControlName].ToString(), true)[0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex, ex.Message, "LoadDesignedControls()");
            }
        }


        private static void SetMastToControl(ref Control ctr, DataRow dr)
        {
            try
            {
                if (ctr is DevExpress.XtraEditors.TextEdit || ctr is DevExpress.XtraEditors.DateEdit)
                {
                    switch (dr[CommonConst.MaskType].ToString())
                    {
                        case "None":
                            ((DevExpress.XtraEditors.TextEdit)ctr).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
                            break;
                        case "DateTime":
                            ((DevExpress.XtraEditors.TextEdit)ctr).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                            break;
                        case "Numeric":
                            ((DevExpress.XtraEditors.TextEdit)ctr).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                            break;
                        case "Simple":
                            ((DevExpress.XtraEditors.TextEdit)ctr).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
                            break;
                        case "RegEx":
                            ((DevExpress.XtraEditors.TextEdit)ctr).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                            break;
                    }
                    ((DevExpress.XtraEditors.TextEdit)ctr).Properties.Mask.EditMask = dr[CommonConst.EditMask].ToString();
                    ((DevExpress.XtraEditors.TextEdit)ctr).Properties.Mask.UseMaskAsDisplayFormat = true;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex, ex.Message, "SetMastToControl");
            }
        }

        private static void SetValidationToControl(ref Control ctr, DataRow dr)
        {
            try
            {
                if (ctr is DevExpress.XtraEditors.LookUpEdit)
                {
                    DevExpress.XtraEditors.LookUpEdit led = ctr as DevExpress.XtraEditors.LookUpEdit;
                    AddDataSource(ref led, UIMessage.DBEngine.execReturnDataTable(dr[CommonConst.Validation].ToString(), CommonConst.A_LoginID, UIMessage.userID));
                }
                else
                {
                    //Devexpress valiation rules
                    string[] strSpl = dr[CommonConst.Validation].ToString().Split(':');
                    if (strSpl[0].Contains("ConditionValidationRule"))
                    {
                        ConditionValidationRule cvr = new ConditionValidationRule();
                        switch (strSpl[1])
                        {
                            case "IsNotBlank":
                                cvr.ConditionOperator = ConditionOperator.IsNotBlank;
                                cvr.ErrorText = UIMessage.Get_Message(dr[CommonConst.ValidationMessID].ToString());
                                break;
                            case "Between":
                                cvr.ConditionOperator = ConditionOperator.Between;
                                cvr.Value1 = Convert.ToInt64(strSpl[2]);
                                cvr.Value2 = Convert.ToInt64(strSpl[3]);
                                cvr.ErrorText = string.Format(UIMessage.Get_Message(dr[CommonConst.ValidationMessID].ToString()), cvr.Value1, cvr.Value2);
                                break;
                            case "Contains":
                                cvr.ConditionOperator = ConditionOperator.Contains;
                                cvr.Value1 = Convert.ToInt64(strSpl[2]);
                                cvr.ErrorText = string.Format(UIMessage.Get_Message(dr[CommonConst.ValidationMessID].ToString()), cvr.Value1);
                                break;
                            case "NotAnyOf":
                                cvr.ConditionOperator = ConditionOperator.NotAnyOf;
                                cvr.Value1 = Convert.ToInt64(strSpl[2]);
                                cvr.ErrorText = string.Format(UIMessage.Get_Message(dr[CommonConst.ValidationMessID].ToString()), cvr.Value1);
                                break;
                        }
                        cvr.ErrorType = ErrorType.Default;
                        dxValidationProvider1.SetValidationRule(ctr, cvr);
                        dxValidationProvider1.ValidationMode = ValidationMode.Auto;
                    }

                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex, ex.Message, "SetValidationToControl");
            }
        }
        public static void SaveDesignForm(System.Windows.Forms.Control.ControlCollection ctrs)
        {
            foreach (System.Windows.Forms.Control ctr in ctrs)
            {
                if (ctr is System.Windows.Forms.PictureBox)
                {
                    System.Windows.Forms.PictureBox pic = (System.Windows.Forms.PictureBox)ctr;
                    //resize image and convert to byte
                    //byte[] imgb = CImageUtility.ImageToByte(pic.Image.GetThumbnailImage(pic.Size.Width, pic.Size.Height, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero));
                    byte[] imgb = CImageUtility.ImageToByte(CImageUtility.ResizeImage(pic.Image, pic.Size.Width, pic.Size.Height));
                    UIMessage.DBEngine.exec("FormLayout_Save",
                               "@FormName", ctr.FindForm().Name,
                               "@ControlName", ctr.Name,
                               "@Image", imgb,
                               "@SizeMode", pic.SizeMode.ToString(),
                               "@ParentControl", ctr.Parent.Name,
                               "@SystemType", string.Format("{0},{1}", ctr.GetType().FullName, ctr.GetType().Namespace),
                               "@LocationX", ctr.Location.X,
                               "@LocationY", ctr.Location.Y,
                               "@Height", ctr.Size.Height,
                               "@Visible", ctr.Visible,
                               "@Enabled", ctr.Enabled,
                               "@Width", ctr.Size.Width);
                }
                else
                    UIMessage.DBEngine.exec("FormLayout_Save",
                                   "@FormName", ctr.FindForm().Name,
                                   "@ControlName", ctr.Name,
                                   "@ParentControl", ctr.Parent.Name,
                                   "@SystemType", string.Format("{0},{1}", ctr.GetType().FullName, ctr.GetType().Namespace),
                                   "@TabIndex", ctr.TabIndex,
                                   "@LocationX", ctr.Location.X,
                                   "@LocationY", ctr.Location.Y,
                                   "@Height", ctr.Size.Height,
                                   "@Visible", ctr.Visible,
                                   "@Enabled", ctr.Enabled,
                                   "@Width", ctr.Size.Width,
                                   "@FontName", ctr.Font.FontFamily.GetName(0),
                                   "@FontSize", ctr.Font.Size,
                                   "@FontBold", ctr.Font.Bold,
                                   "@FontItalic", ctr.Font.Italic,
                                   "@FontStrikeout", ctr.Font.Strikeout,
                                   "@FontUnderline", ctr.Font.Underline,
                                   "@ForeColor",string.Format("{0},{1},{2},{3}",ctr.ForeColor.A.ToString(),ctr.ForeColor.R.ToString(),ctr.ForeColor.G.ToString(),ctr.ForeColor.B.ToString())
                                   );
                if (ctr.Controls.Count > 0 && !ctr.GetType().FullName.Equals("DevExpress.XtraGrid.GridControl") && !ctr.GetType().FullName.Contains("DevExpress.XtraEditors."))
                    SaveDesignForm(ctr.Controls);
            }
            UIMessage.DBEngine.exec(string.Format("delete tblFormLayout where (IsLayout is null or IsLayout = 0) and FormName = '{0}'", ctrs[0].FindForm().Name));
        }
        public static void SaveDesignForm(System.Windows.Forms.Form ctr)
        {
            UIMessage.DBEngine.exec("FormLayout_Save",
                           "@FormName", ctr.FindForm().Name,
                           "@ControlName", ctr.Name,
                           "@SystemType", string.Format("{0},{1}", ctr.GetType().FullName, ctr.GetType().Namespace),
                           "@LocationX", ctr.Location.X,
                           "@LocationY", ctr.Location.Y,
                           "@Height", ctr.Size.Height,
                           "@Width", ctr.Size.Width);
        }
        public static void SaveDesignForm(System.Windows.Forms.SplitterPanel ctr)
        {
            UIMessage.DBEngine.exec("FormLayout_Save",
                           "@FormName", ctr.FindForm().Name,
                           "@ControlName", ctr.Name,
                           "@SystemType", string.Format("{0},{1}", ctr.GetType().FullName, ctr.GetType().Namespace),
                           "@LocationX", ctr.Location.X,
                           "@LocationY", ctr.Location.Y,
                           "@Height", ctr.Size.Height,
                           "@Width", ctr.Size.Width);
        }
        private static void AddDataSource(ref DevExpress.XtraEditors.LookUpEdit le, System.Data.DataTable dt)
        {
            le.Properties.Columns.Clear();
            le.Properties.DataSource = dt;
            const Int32 width = 125;
            int i = 0;
            foreach (DataColumn dc in dt.Columns)
            {
                if (++i > 2)
                    break;
                LookUpColumnInfo luColumnInfo = new LookUpColumnInfo(dc.Caption, width);
                le.Properties.Columns.Add(luColumnInfo);
            }
            if (dt.Columns.Count >= 2)
            {
                le.Properties.ValueMember = dt.Columns[0].Caption;
                le.Properties.DisplayMember = dt.Columns[1].Caption;
                // get the first rows
                le.EditValue = dt.Rows[0][0].ToString();
            }
            else
            {
                le.Properties.ValueMember = dt.Columns[0].Caption;
                le.Properties.DisplayMember = dt.Columns[0].Caption;
                // get the first rows
                le.EditValue = dt.Rows[0][0].ToString();//DataBindings.Add("EditValue", dt,dt.Columns[0].Caption);
            }

        }
    }
}
