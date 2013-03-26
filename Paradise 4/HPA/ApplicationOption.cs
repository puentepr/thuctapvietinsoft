using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HPA.Component;
using HPA.Common;

namespace HPA
{
    public partial class ApplicationOption : HPA.Component.Framework.CCommonForm
    {
        string strWallPaperPath = "Wallpaper.jpg";
        string strLoginWallpaper = "Wallpaper.jpg";
        DataTable dtLableNameList = null;
        public ApplicationOption(string strTitle)
        {
            InitializeComponent();
            // set lable
            Control.ControlCollection ctrls = this.Controls;
            UIMessage.LoadLableName(ref ctrls);
            this.Text = strTitle;
            ShowOptionValue();
        }

        private void ShowOptionValue()
        {
            try
            {
                txtLanguageID.Text = HPA.Properties.Settings.Default.LanguageID;
                txtInterval.EditValue = HPA.Properties.Settings.Default.LockProgramInterval;
                ckbEnter_to_tab.Checked = HPA.Properties.Settings.Default.EnterToTab;
                ckbUsedModenMenu.Checked = HPA.Properties.Settings.Default.UsedModenMenu;
                strWallPaperPath = HPA.Properties.Settings.Default.WallpaperPath;
                strLoginWallpaper = HPA.Properties.Settings.Default.LoginWallpaper;
                //Show Picture
                imgWallPaper.Image = System.Drawing.Image.FromFile(strWallPaperPath);
                imgLoginWallPaper.Image = System.Drawing.Image.FromFile(strLoginWallpaper);
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.LogError(ex, ex.Message, this.Text);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        public override bool InitializeData()
        {
            try
            {
                //Show option
                DBEngine = UIMessage.DBEngine;
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".InitializeData()", null);
                return false;
            }

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            HPA.Properties.Settings.Default.LanguageID = txtLanguageID.Text;
            HPA.Properties.Settings.Default.EnterToTab = ckbEnter_to_tab.Checked;
            HPA.Properties.Settings.Default.UsedModenMenu = ckbUsedModenMenu.Checked;
            HPA.Properties.Settings.Default.WallpaperPath = strWallPaperPath;
            HPA.Properties.Settings.Default.LoginWallpaper = strLoginWallpaper;
            HPA.Properties.Settings.Default.LockProgramInterval = Convert.ToInt32(txtInterval.EditValue);
            HPA.Properties.Settings.Default.Save();
            if (dtLableNameList == null)
                return;
            try
            {
                DataTable dtChanged = dtLableNameList.GetChanges();
                if (dtChanged == null || dtChanged.Rows.Count <= 0)
                    return;
                DBEngine.beginTransaction();
                foreach (DataRow dr in dtChanged.Rows)
                {
                    DBEngine.exec("sp_LableName_Language_Save", CommonConst.A_LoginID, UIMessage.userID,
                        "@LanguageID", txtLanguageID.Text, "@MessageID", dr["MessageID"], "@Content", dr["Content"]);
                }
                DBEngine.commit();
                dtLableNameList.AcceptChanges();
                UIMessage.ShowMessage(CommonConst.DATASAVED_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                // m_dtTableData.RejectChanges();
                DBEngine.rollback();
                throw (ex);
            }

            // restore cursor
            this.Cursor = Cursors.Default;


        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewName.Text.Trim().Equals("") || txtOldName.Text.Trim().Equals(""))
                    return;
                UIMessage.ChangeLableName(txtOldName.Text.Trim(), txtNewName.Text.Trim(), 3);
                UIMessage.ShowMessage(CommonConst.DATASAVED_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                UIMessage.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewNameA.Text.Trim().Equals(""))
                    return;
                UIMessage.AddNewLableName(txtMessageID.Text, txtNewNameA.Text, 3);
                UIMessage.ShowMessage(CommonConst.DATASAVED_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                UIMessage.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog imgPath = new OpenFileDialog() { Filter = "Jpeg files (*.jpg)|*.jpg|Bitmap files(*.bmp)|*.bmp|All file (*.*)|*.*", Title = "Vietinsoft" };
            if (imgPath.ShowDialog() == DialogResult.OK)
            {
                // display image if can
                try
                {
                    strWallPaperPath = imgPath.FileName;
                    imgWallPaper.Image = System.Drawing.Image.FromFile(strWallPaperPath);
                }
                catch (Exception ex)
                {
                    HPA.Common.Helper.ShowException(ex, this.Name, "btnBrowse_Click");
                }

            }
        }

        private void cbxLang_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxLang.Text == "Vietnamese")
                txtLanguageID.Text  = "VN";
            if (cbxLang.Text == "English")
                txtLanguageID.Text = "EN";
            if (cbxLang.Text == "Japanese")
                txtLanguageID.Text = "JP";
            if (cbxLang.Text == "Chinese")
                txtLanguageID.Text = "CN";

        }

        private void ApplicationOption_Load(object sender, EventArgs e)
        {
            if (txtLanguageID.Text == "VN")
                cbxLang.SelectedItem = "Vietnamese";
            if (txtLanguageID.Text == "EN")
                cbxLang.SelectedItem = "English";
            if (txtLanguageID.Text == "JP")
                cbxLang.SelectedItem = "Japanese";
            if (txtLanguageID.Text == "CN") 
                cbxLang.Text = "Chinese";
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                dtLableNameList = DBEngine.execReturnDataTable("sp_LableName_Language_List","@LanguageID", txtLanguageID.Text, CommonConst.A_LoginID,UIMessage.userID);
                grdLableNameList.DataSource = dtLableNameList;
                txtFind.Focus();
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "");
            }
        }

        private void txtFind_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string strFilter = string.Format(" MessageID like '%{0}%' or Content like '%{1}%'", txtFind.Text, txtFind.Text);
                dtLableNameList.DefaultView.RowFilter = strFilter;
            }
            catch (Exception ex)
            {
                btnLoad_Click(null, null);
            }
        }

        private void btnRestartApp_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnBrowseLoginImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog imgPath = new OpenFileDialog() { Filter = "Jpeg files (*.jpg)|*.jpg|Bitmap files(*.bmp)|*.bmp|All file (*.*)|*.*", Title = "Vietinsoft" };
            if (imgPath.ShowDialog() == DialogResult.OK)
            {
                // display image if can
                try
                {
                    strLoginWallpaper = imgPath.FileName;
                    imgLoginWallPaper.Image = System.Drawing.Image.FromFile(strLoginWallpaper);
                }
                catch (Exception ex)
                {
                    HPA.Common.Helper.ShowException(ex, this.Name, "btnBrowse_Click");
                }

            }
        }
    }
}