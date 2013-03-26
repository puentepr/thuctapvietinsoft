using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using HPA.Common;
using DevExpress.XtraEditors;

namespace HPA.MasterData
{
    public partial class ShiftSetting : HPA.Component.Framework.CCommonForm
    {
        DataTable m_dtShiftSetting;
        DataTable dtShiftDetail;
        const string ShiftCode = "ShiftCode";
        const string ShiftName = "ShiftName";
        const string ShiftAllowance = "ShiftAllowance";
        const string HilightColorCode = "HilightColorCode";

        const string WorkStart1 = "WorkStart1";
        const string WorkEnd1 = "WorkEnd1";
        const string BreakStart1 = "BreakStart1";
        const string BreakEnd1 = "BreakEnd1";
        const string DayOff1 = "DayOff1";
        const string WorkStart2 = "WorkStart2";
        const string WorkEnd2 = "WorkEnd2";
        const string BreakStart2 = "BreakStart2";
        const string BreakEnd2 = "BreakEnd2";
        const string DayOff2 = "DayOff2";
        const string WorkStart3 = "WorkStart3";
        const string WorkEnd3 = "WorkEnd3";
        const string BreakStart3 = "BreakStart3";
        const string BreakEnd3 = "BreakEnd3";
        const string DayOff3 = "DayOff3";
        const string WorkStart4 = "WorkStart4";
        const string WorkEnd4 = "WorkEnd4";
        const string BreakStart4 = "BreakStart4";
        const string BreakEnd4 = "BreakEnd4";
        const string DayOff4 = "DayOff4";
        const string WorkStart5 = "WorkStart5";
        const string WorkEnd5 = "WorkEnd5";
        const string BreakStart5 = "BreakStart5";
        const string BreakEnd5 = "BreakEnd5";
        const string DayOff5 = "DayOff5";
        const string WorkStart6 = "WorkStart6";
        const string WorkEnd6 = "WorkEnd6";
        const string BreakStart6 = "BreakStart6";
        const string BreakEnd6 = "BreakEnd6";
        const string DayOff6 = "DayOff6";
        const string WorkStart7 = "WorkStart7";
        const string WorkEnd7 = "WorkEnd7";
        const string BreakStart7 = "BreakStart7";
        const string BreakEnd7 = "BreakEnd7";
        const string DayOff7 = "DayOff7";
        const string OTBeforeStart1 = "OTBeforeStart1";
        const string OTBeforeEnd1 = "OTBeforeEnd1";
        const string OTAfterStart1 = "OTAfterStart1";
        const string OTAfterEnd1 = "OTAfterEnd1";

        const string OTBeforeStart2 = "OTBeforeStart2";
        const string OTBeforeEnd2 = "OTBeforeEnd2";
        const string OTAfterStart2 = "OTAfterStart2";
        const string OTAfterEnd2 = "OTAfterEnd2";

        const string OTBeforeStart3 = "OTBeforeStart3";
        const string OTBeforeEnd3 = "OTBeforeEnd3";
        const string OTAfterStart3 = "OTAfterStart3";
        const string OTAfterEnd3 = "OTAfterEnd3";

        const string OTBeforeStart4 = "OTBeforeStart4";
        const string OTBeforeEnd4 = "OTBeforeEnd4";
        const string OTAfterStart4 = "OTAfterStart4";
        const string OTAfterEnd4 = "OTAfterEnd4";

        const string OTBeforeStart5 = "OTBeforeStart5";
        const string OTBeforeEnd5 = "OTBeforeEnd5";
        const string OTAfterStart5 = "OTAfterStart5";
        const string OTAfterEnd5 = "OTAfterEnd5";

        const string OTBeforeStart6 = "OTBeforeStart6";
        const string OTBeforeEnd6 = "OTBeforeEnd6";
        const string OTAfterStart6 = "OTAfterStart6";
        const string OTAfterEnd6 = "OTAfterEnd6";

        const string OTBeforeStart7 = "OTBeforeStart7";
        const string OTBeforeEnd7 = "OTBeforeEnd7";
        const string OTAfterStart7 = "OTAfterStart7";
        const string OTAfterEnd7 = "OTAfterEnd7";


        public ShiftSetting()
        {
            InitializeComponent();
            // set lable
            Control.ControlCollection ctrls = this.Controls;
            UIMessage.LoadLableName(ref ctrls);
            FocusControlsIndicator fc = new FocusControlsIndicator();
            fc.LoadAddGotFocus(this);
        }
        public override bool InitializeData()
        {
            try
            {
                // TODO - add code here to initialize data once loading the form
                myInit();
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".InitializeData()", null);
                return false;
            }

            return true;
        }
        public override void SetData(object objParam)
        {
            try
            {
                this.Text = objParam.ToString();
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".SetData()", null);
                return;
            }
        }
        public override bool OnAdd()
        {
            if (!base.OnAdd())
                return false;

            try
            {
                // TODO - add code here to do adding new item action
                
                grvShiftSetting.CloseEditor();
                grvShiftSetting.UpdateCurrentRow();
                grvShiftSetting.BeginUpdate();

                DataRow dr = m_dtShiftSetting.NewRow();
                m_dtShiftSetting.Rows.Add(dr);
                grvShiftSetting.EndUpdate();

                // Focus
                grvShiftSetting.Focus();
                grvShiftSetting.FocusedColumn = grvShiftSetting.Columns[0];
                grvShiftSetting.FocusedRowHandle = grvShiftSetting.RowCount - 1;
                grvShiftSetting.SelectRow(grvShiftSetting.FocusedRowHandle);
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".OnAdd()", null);
                return false;
            }

            return true;
        }


        // =======================================================
        // NAME:	OnValidate
        // TASK:	Override OnValidate() method to validate data before saving
        // PARAM:	
        // RETURN:	TRUE = validate ok, FALSE = fail
        // THROW:	
        // REV:	
        //	2003-12-
        // =======================================================
        /// <summary>
        /// Validate data
        /// </summary>
        public override bool OnValidate()
        {
            try
            {
                if (txtShiftCode.Text.Equals(""))
                {
                    UIMessage.ShowMessage(CommonConst.SHIFT_CODE_NULL_ERROR,MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtShiftCode.Focus();
                    return false;
                }
                if (txtShiftName.Text.Equals(""))
                {
                    UIMessage.ShowMessage(CommonConst.SHIFT_NAME_NULL_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtShiftName.Focus();
                    return false;
                }
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".OnValidate()", null);
                return false;
            }

            // validate ok
            return true;
        }


        // =======================================================
        // NAME:	Commit
        // TASK:	Override Commit() method to save data
        // PARAM:	
        // RETURN:	TRUE = successfully, FALSE = fail
        // THROW:	
        // REV:	
        //	2003-12-
        // =======================================================
        /// <summary>
        /// Save data
        /// </summary>
        public override bool Commit()
        {
            try
            {

                // wait-cursor
                this.Cursor = Cursors.WaitCursor;
                
                try
                {
                    DBEngine.beginTransaction();
                    DBEngine.exec("MD_WorkingShift_Update",
                        "@ShiftCode", txtShiftCode.Text,
                        "@ShiftName", txtShiftName.Text,
                        "@ShiftAllowance", txtShiftAllowance.EditValue,
                        "@HilightColorCode", txtHilightColorCode.EditValue,
                        "@WorkStart1", tedWorkStart1.EditValue,
                        "@WorkEnd1", tedWorkEnd1.EditValue,
                        "@BreakStart1", tedBreakStart1.EditValue,
                        "@BreakEnd1", tedBreakEnd1.EditValue,
                        "@DayOff1", ckbDayoff1.EditValue,
                        "@WorkStart2", tedWorkStart2.EditValue,
                        "@WorkEnd2", tedWorkEnd2.EditValue,
                        "@BreakStart2", tedBreakStart2.EditValue,
                        "@BreakEnd2", tedBreakEnd2.EditValue,
                        "@DayOff2", ckbDayoff2.EditValue,
                        "@WorkStart3", tedWorkStart3.EditValue,
                        "@WorkEnd3", tedWorkEnd3.EditValue,
                        "@BreakStart3", tedBreakStart3.EditValue,
                        "@BreakEnd3", tedBreakEnd3.EditValue,
                        "@DayOff3", ckbDayoff3.EditValue,
                        "@WorkStart4", tedWorkStart4.EditValue,
                        "@WorkEnd4", tedWorkEnd4.EditValue,
                        "@BreakStart4", tedBreakStart4.EditValue,
                        "@BreakEnd4", tedBreakEnd4.EditValue,
                        "@DayOff4", ckbDayoff4.EditValue,
                        "@WorkStart5", tedWorkStart5.EditValue,
                        "@WorkEnd5", tedWorkEnd5.EditValue,
                        "@BreakStart5", tedBreakStart5.EditValue,
                        "@BreakEnd5", tedBreakEnd5.EditValue,
                        "@DayOff5", ckbDayoff5.EditValue,
                        "@WorkStart6", tedWorkStart6.EditValue,
                        "@WorkEnd6", tedWorkEnd6.EditValue,
                        "@BreakStart6", tedBreakStart6.EditValue,
                        "@BreakEnd6", tedBreakEnd6.EditValue,
                        "@DayOff6", ckbDayoff6.EditValue,
                        "@WorkStart7", tedWorkStart7.EditValue,
                        "@WorkEnd7", tedWorkEnd7.EditValue,
                        "@BreakStart7", tedBreakStart7.EditValue,
                        "@BreakEnd7", tedBreakEnd7.EditValue,

                        "@OTBeforeStart1", tedOTBeforeStart1.EditValue,
                        "@OTBeforeStart2", tedOTBeforeStart2.EditValue,
                        "@OTBeforeStart3", tedOTBeforeStart3.EditValue,
                        "@OTBeforeStart4", tedOTBeforeStart4.EditValue,
                        "@OTBeforeStart5", tedOTBeforeStart5.EditValue,
                        "@OTBeforeStart6", tedOTBeforeStart6.EditValue,
                        "@OTBeforeStart7", tedOTBeforeStart7.EditValue,

                        "@OTBeforeEnd1", tedOTBeforeEnd1.EditValue,
                        "@OTBeforeEnd2", tedOTBeforeEnd2.EditValue,
                        "@OTBeforeEnd3", tedOTBeforeEnd3.EditValue,
                        "@OTBeforeEnd4", tedOTBeforeEnd4.EditValue,
                        "@OTBeforeEnd5", tedOTBeforeEnd5.EditValue,
                        "@OTBeforeEnd6", tedOTBeforeEnd6.EditValue,
                        "@OTBeforeEnd7", tedOTBeforeEnd7.EditValue,

                        "@OTAfterStart1", tedOTAfterStart1.EditValue,
                        "@OTAfterStart2", tedOTAfterStart2.EditValue,
                        "@OTAfterStart3", tedOTAfterStart3.EditValue,
                        "@OTAfterStart4", tedOTAfterStart4.EditValue,
                        "@OTAfterStart5", tedOTAfterStart5.EditValue,
                        "@OTAfterStart6", tedOTAfterStart6.EditValue,
                        "@OTAfterStart7", tedOTAfterStart7.EditValue,

                        "@OTAfterEnd1", tedOTAfterEnd1.EditValue,
                        "@OTAfterEnd2", tedOTAfterEnd2.EditValue,
                        "@OTAfterEnd3", tedOTAfterEnd3.EditValue,
                        "@OTAfterEnd4", tedOTAfterEnd4.EditValue,
                        "@OTAfterEnd5", tedOTAfterEnd5.EditValue,
                        "@OTAfterEnd6", tedOTAfterEnd6.EditValue,
                        "@OTAfterEnd7", tedOTAfterEnd7.EditValue,

                        "@DayOff7", ckbDayoff7.EditValue,
                        CommonConst.A_LoginID, this.UserID);

                    

                    DBEngine.commit();
                }
                catch (Exception ex)
                {
                    DBEngine.rollback();
                    throw (ex);
                }
                m_dtShiftSetting.AcceptChanges();
                // restore cursor
                this.Cursor = Cursors.Default;

            }
            catch (Exception e)
            {
                // restore cursor
                this.Cursor = Cursors.Default;

                // show error
                HPA.Common.Helper.ShowException(e, this.Name + ".Commit()", null);


                // unable to commit
                return false;
            }
           
            UIMessage.ShowMessage(CommonConst.DATASAVED_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DirtyData = false;
            // commit successfully
            return true;
        }


        // =======================================================
        // NAME:	OnDelete
        // TASK:	Override OnDelete() method to perform delete tasks.
        // PARAM:	
        // RETURN:	TRUE = successfully, FALSE = fail
        // THROW:	
        // REV:	
        //	2003-12-
        // =======================================================
        /// <summary>
        /// Perform delete tasks
        /// </summary>
        public override bool OnDelete()
        {
            if (!base.OnDelete())
                return false;


            try
            {

                // wait-cursor
                this.Cursor = Cursors.WaitCursor;

                DataRow dr = grvShiftSetting.GetDataRow(grvShiftSetting.FocusedRowHandle);
                if (dr == null)
                {
                    UIMessage.ShowMessage(1992, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                    return false;
                }

                grvShiftSetting.CloseEditor();
                grvShiftSetting.UpdateCurrentRow();
                grvShiftSetting.BeginUpdate();

                if (UIMessage.ShowMessage(3, System.Windows.Forms.MessageBoxButtons.YesNo,
                    System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    DBEngine.beginTransaction();
                    try
                    {
                        DBEngine.exec("MD_WorkingShift_Delete",
                             "@ShiftCode", dr[ShiftCode, DataRowVersion.Original],
                             CommonConst.A_LoginID, this.UserID);
                    }
                    catch (Exception ex)
                    {
                        DBEngine.rollback();
                        HPA.Common.Helper.ShowException(ex, this.Name, "OnDelete");
                    }
                    DBEngine.commit();
                    UIMessage.ShowMessage(CommonConst.DELETE_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    myInit();
                }

                grvShiftSetting.EndUpdate();

                // TODO - add code here to perform delete tasks


                // restore cursor
                this.Cursor = Cursors.Default;

            }
            catch (Exception e)
            {
                // restore cursor
                this.Cursor = Cursors.Default;

                // show error
                HPA.Common.Helper.ShowException(e, this.Name + ".OnDelete()", null);


                // unable to delete
                return false;
            }

            // delete successfully
            return true;
        }


        // =======================================================
        // NAME:	OnReset
        // TASK:	reject all changes
        // PARAM:	
        // RETURN:	
        // THROW:	
        // REV:	
        //	2003-06-
        // =======================================================
        /// <summary>
        /// reject all changes
        /// </summary>
        public override bool OnReset()
        {
            if (!DirtyData)
                return true;

            try
            {
                if (UIMessage.ShowMessage(5, System.Windows.Forms.MessageBoxButtons.OKCancel,
                    System.Windows.Forms.MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    // Shift setting
                    grvShiftSetting.CloseEditor();
                    grvShiftSetting.BeginUpdate();
                    m_dtShiftSetting.RejectChanges();
                    grvShiftSetting_Click(null, null);
                    DirtyData = false;
                    grvShiftSetting.EndUpdate();
                }
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".OnReset()", null);
                return false;
            }

            return true;
        }

        private void myInit()
        {
            loadDataTables();
            bindingData();
            registerEvent();
            grvShiftSetting_Click(null, null);
            //			grvShiftSetting.FocusedRowHandle = 1;
            //			grvShiftSetting.FocusedRowHandle = 0;
        }
        private void loadDataTables()
        {
            m_dtShiftSetting = DBEngine.execReturnDataTable("MD_WorkingShift_List");
            if (m_dtShiftSetting != null && m_dtShiftSetting.Rows.Count <= 0)
                CRowUtility.addNewRow(m_dtShiftSetting, ShiftCode, "");
           // maxShiftID = CRowUtility.getMaxID(m_dtShiftSetting, "ShiftID");

        }
        private void bindingData()
        {
            grdShiftSetting.DataSource = m_dtShiftSetting;
            txtShiftCode.DataBindings.Clear();
            txtShiftName.DataBindings.Clear();
            txtShiftAllowance.DataBindings.Clear();
            txtHilightColorCode.DataBindings.Clear();

            txtShiftCode.DataBindings.Add(CommonConst.EDIT_VALUE, m_dtShiftSetting, ShiftCode);
            txtShiftName.DataBindings.Add(CommonConst.EDIT_VALUE, m_dtShiftSetting, ShiftName);
            txtShiftAllowance.DataBindings.Add(CommonConst.EDIT_VALUE, m_dtShiftSetting, ShiftAllowance);
            txtHilightColorCode.DataBindings.Add(CommonConst.EDIT_VALUE, m_dtShiftSetting, HilightColorCode);
        }
        private void registerEvent()
        {
            m_dtShiftSetting.RowChanged += new DataRowChangeEventHandler(m_dtShiftSetting_RowChanged);
            m_dtShiftSetting.ColumnChanged += new DataColumnChangeEventHandler(m_dtShiftSetting_ColumnChanged);
        }
        private void m_dtShiftSetting_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DirtyData = true;
        }

        private void m_dtShiftSetting_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            DirtyData = true;
        }

        private void ckbDayoff2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime resetVal = DateTime.Now.Date;
                CheckEdit ckb = (CheckEdit)sender;
                if (ckb.Checked)
                {
                    tedBreakEnd2.EditValue = resetVal;
                    tedWorkEnd2.EditValue = resetVal;
                    tedWorkStart2.EditValue = resetVal;
                    tedBreakStart2.EditValue = resetVal;

                    tedBreakEnd2.Enabled = false;
                    tedWorkEnd2.Enabled = false;
                    tedWorkStart2.Enabled = false;
                    tedBreakStart2.Enabled = false;
                }
                else
                {
                    tedBreakEnd2.Enabled = true;
                    tedWorkEnd2.Enabled = true;
                    tedWorkStart2.Enabled = true;
                    tedBreakStart2.Enabled = true ;
                }
                DirtyData = true;
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "ckbDayoff2_CheckedChanged");
            }
        }

        private void ckbDayoff1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime resetVal = DateTime.Now.Date;
                CheckEdit ckb = (CheckEdit)sender;
                if (ckb.Checked)
                {
                    tedBreakEnd1.EditValue = resetVal;
                    tedWorkEnd1.EditValue = resetVal;
                    tedWorkStart1.EditValue = resetVal;
                    tedBreakStart1.EditValue = resetVal;

                    tedBreakEnd1.Enabled = false;
                    tedWorkEnd1.Enabled = false;
                    tedWorkStart1.Enabled = false;
                    tedBreakStart1.Enabled = false;
                }
                else
                {
                    tedBreakEnd1.Enabled = true;
                    tedWorkEnd1.Enabled = true;
                    tedWorkStart1.Enabled = true;
                    tedBreakStart1.Enabled = true;
                }
                DirtyData = true;
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "ckbDayoff1_CheckedChanged");
            }
        }


        private void btnApplyAll_Click(object sender, EventArgs e)
        {
            try
            {
                tedBreakEnd3.EditValue = tedBreakEnd4.EditValue = tedBreakEnd5.EditValue = tedBreakEnd6.EditValue = tedBreakEnd7.EditValue = tedBreakEnd1.EditValue = tedBreakEnd2.EditValue;
                tedBreakStart3.EditValue = tedBreakStart4.EditValue = tedBreakStart5.EditValue = tedBreakStart6.EditValue = tedBreakStart7.EditValue = tedBreakStart1.EditValue = tedBreakStart2.EditValue;
                tedWorkStart3.EditValue = tedWorkStart4.EditValue = tedWorkStart5.EditValue = tedWorkStart6.EditValue = tedWorkStart7.EditValue = tedWorkStart1.EditValue = tedWorkStart2.EditValue;
                tedWorkEnd3.EditValue = tedWorkEnd4.EditValue = tedWorkEnd5.EditValue = tedWorkEnd6.EditValue = tedWorkEnd7.EditValue = tedWorkEnd1.EditValue = tedWorkEnd2.EditValue;
                tedOTBeforeStart7.EditValue = tedOTBeforeStart6.EditValue = tedOTBeforeStart5.EditValue = tedOTBeforeStart4.EditValue = tedOTBeforeStart3.EditValue = tedOTBeforeStart1.EditValue = tedOTBeforeStart2.EditValue;
                tedOTBeforeEnd7.EditValue = tedOTBeforeEnd6.EditValue = tedOTBeforeEnd5.EditValue = tedOTBeforeEnd4.EditValue = tedOTBeforeEnd3.EditValue = tedOTBeforeEnd1.EditValue = tedOTBeforeEnd2.EditValue;
                tedOTAfterStart7.EditValue = tedOTAfterStart6.EditValue = tedOTAfterStart5.EditValue = tedOTAfterStart4.EditValue = tedOTAfterStart3.EditValue = tedOTAfterStart1.EditValue = tedOTAfterStart2.EditValue;
                tedOTAfterEnd7.EditValue = tedOTAfterEnd6.EditValue = tedOTAfterEnd5.EditValue = tedOTAfterEnd4.EditValue = tedOTAfterEnd3.EditValue = tedOTAfterEnd1.EditValue = tedOTAfterEnd2.EditValue;
                
                if (ckbDayoff2.EditValue.ToString().Equals(""))
                    ckbDayoff2.EditValue = false;
                ckbDayoff1.EditValue = ckbDayoff3.EditValue = ckbDayoff4.EditValue = ckbDayoff5.EditValue = ckbDayoff6.EditValue = ckbDayoff7.EditValue = ckbDayoff1.EditValue = ckbDayoff2.EditValue;
                DirtyData = true;
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "btnApplyAll_Click");
            }
        }

        private void ckbDayoff3_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime resetVal = DateTime.Now.Date;
                CheckEdit ckb = (CheckEdit)sender;
                if (ckb.Checked)
                {
                    tedBreakEnd3.EditValue = resetVal;
                    tedWorkEnd3.EditValue = resetVal;
                    tedWorkStart3.EditValue = resetVal;
                    tedBreakStart3.EditValue = resetVal;

                    tedBreakEnd3.Enabled = false;
                    tedWorkEnd3.Enabled = false;
                    tedWorkStart3.Enabled = false;
                    tedBreakStart3.Enabled = false;
                }
                else
                {
                    tedBreakEnd3.Enabled = true;
                    tedWorkEnd3.Enabled = true;
                    tedWorkStart3.Enabled = true;
                    tedBreakStart3.Enabled = true;
                }
                DirtyData = true;
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "ckbDayoff3_CheckedChanged");
            }
        }

        private void ckbDayoff4_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime resetVal = DateTime.Now.Date;
                CheckEdit ckb = (CheckEdit)sender;
                if (ckb.Checked)
                {
                    tedBreakEnd4.EditValue = resetVal;
                    tedWorkEnd4.EditValue = resetVal;
                    tedWorkStart4.EditValue = resetVal;
                    tedBreakStart4.EditValue = resetVal;

                    tedBreakEnd4.Enabled = false;
                    tedWorkEnd4.Enabled = false;
                    tedWorkStart4.Enabled = false;
                    tedBreakStart4.Enabled = false;
                }
                else
                {
                    tedBreakEnd4.Enabled = true;
                    tedWorkEnd4.Enabled = true;
                    tedWorkStart4.Enabled = true;
                    tedBreakStart4.Enabled = true;
                }
                DirtyData = true;
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "ckbDayoff4_CheckedChanged");
            }
        }

        private void ckbDayoff5_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime resetVal = DateTime.Now.Date;
                CheckEdit ckb = (CheckEdit)sender;
                if (ckb.Checked)
                {
                    tedBreakEnd5.EditValue = resetVal;
                    tedWorkEnd5.EditValue = resetVal;
                    tedWorkStart5.EditValue = resetVal;
                    tedBreakStart5.EditValue = resetVal;

                    tedBreakEnd5.Enabled = false;
                    tedWorkEnd5.Enabled = false;
                    tedWorkStart5.Enabled = false;
                    tedBreakStart5.Enabled = false;
                }
                else
                {
                    tedBreakEnd5.Enabled = true;
                    tedWorkEnd5.Enabled = true;
                    tedWorkStart5.Enabled = true;
                    tedBreakStart5.Enabled = true;
                }
                DirtyData = true;
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "ckbDayoff5_CheckedChanged");
            }
        }

        private void ckbDayoff6_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime resetVal = DateTime.Now.Date;
                CheckEdit ckb = (CheckEdit)sender;
                if (ckb.Checked)
                {
                    tedBreakEnd6.EditValue = resetVal;
                    tedWorkEnd6.EditValue = resetVal;
                    tedWorkStart6.EditValue = resetVal;
                    tedBreakStart6.EditValue = resetVal;

                    tedBreakEnd6.Enabled = false;
                    tedWorkEnd6.Enabled = false;
                    tedWorkStart6.Enabled = false;
                    tedBreakStart6.Enabled = false;
                }
                else
                {
                    tedBreakEnd6.Enabled = true;
                    tedWorkEnd6.Enabled = true;
                    tedWorkStart6.Enabled = true;
                    tedBreakStart6.Enabled = true;
                }
                DirtyData = true;
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "ckbDayoff6_CheckedChanged");
            }
        }

        private void ckbDayoff7_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime resetVal = DateTime.Now.Date;
                CheckEdit ckb = (CheckEdit)sender;
                if (ckb.Checked)
                {
                    tedBreakEnd7.EditValue = resetVal;
                    tedWorkEnd7.EditValue = resetVal;
                    tedWorkStart7.EditValue = resetVal;
                    tedBreakStart7.EditValue = resetVal;

                    tedBreakEnd7.Enabled = false;
                    tedWorkEnd7.Enabled = false;
                    tedWorkStart7.Enabled = false;
                    tedBreakStart7.Enabled = false;
                }
                else
                {
                    tedBreakEnd7.Enabled = true;
                    tedWorkEnd7.Enabled = true;
                    tedWorkStart7.Enabled = true;
                    tedBreakStart7.Enabled = true;
                }
                DirtyData = true;
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "ckbDayoff7_CheckedChanged");
            }
        }

        private void grvShiftSetting_Click(object sender, EventArgs e)
        {
            string strShiftCode = "";
            strShiftCode = grvShiftSetting.GetDataRow(grvShiftSetting.FocusedRowHandle)[ShiftCode].ToString();
            // Load Detail shift info
            dtShiftDetail = DBEngine.execReturnDataTable("sp_Shift_ListDetail", "@ShiftCode", strShiftCode);
            if (dtShiftDetail != null && dtShiftDetail.Rows.Count <= 0)
            {
                CRowUtility.addNewRow(dtShiftDetail, DayOff1, 0);
            }
            BidingShiftDetail();
            DirtyData = false;
            txtShiftCode.Focus();
            txtShiftCode.SelectAll();
        }

        private void BidingShiftDetail()
        {
            tedBreakEnd1.DataBindings.Clear();
            tedBreakEnd2.DataBindings.Clear();
            tedBreakEnd3.DataBindings.Clear();
            tedBreakEnd4.DataBindings.Clear();
            tedBreakEnd5.DataBindings.Clear();
            tedBreakEnd6.DataBindings.Clear();
            tedBreakEnd7.DataBindings.Clear();
            tedWorkEnd1.DataBindings.Clear();
            tedWorkEnd2.DataBindings.Clear();
            tedWorkEnd3.DataBindings.Clear();
            tedWorkEnd4.DataBindings.Clear();
            tedWorkEnd5.DataBindings.Clear();
            tedWorkEnd6.DataBindings.Clear();
            tedWorkEnd7.DataBindings.Clear();
            tedWorkStart1.DataBindings.Clear();
            tedWorkStart2.DataBindings.Clear();
            tedWorkStart3.DataBindings.Clear();
            tedWorkStart4.DataBindings.Clear();
            tedWorkStart5.DataBindings.Clear();
            tedWorkStart6.DataBindings.Clear();
            tedWorkStart7.DataBindings.Clear();
            tedBreakStart1.DataBindings.Clear();
            tedBreakStart2.DataBindings.Clear();
            tedBreakStart3.DataBindings.Clear();
            tedBreakStart4.DataBindings.Clear();
            tedBreakStart5.DataBindings.Clear();
            tedBreakStart6.DataBindings.Clear();
            tedBreakStart7.DataBindings.Clear();
            ckbDayoff1.DataBindings.Clear();
            ckbDayoff2.DataBindings.Clear();
            ckbDayoff3.DataBindings.Clear();
            ckbDayoff4.DataBindings.Clear();
            ckbDayoff5.DataBindings.Clear();
            ckbDayoff6.DataBindings.Clear();
            ckbDayoff7.DataBindings.Clear();

            tedOTAfterEnd1.DataBindings.Clear();
            tedOTAfterEnd2.DataBindings.Clear();
            tedOTAfterEnd3.DataBindings.Clear();
            tedOTAfterEnd4.DataBindings.Clear();
            tedOTAfterEnd5.DataBindings.Clear();
            tedOTAfterEnd6.DataBindings.Clear();
            tedOTAfterEnd7.DataBindings.Clear();
            tedOTAfterStart1.DataBindings.Clear();
            tedOTAfterStart2.DataBindings.Clear();
            tedOTAfterStart3.DataBindings.Clear();
            tedOTAfterStart4.DataBindings.Clear();
            tedOTAfterStart5.DataBindings.Clear();
            tedOTAfterStart6.DataBindings.Clear();
            tedOTAfterStart7.DataBindings.Clear();
            tedOTBeforeEnd1.DataBindings.Clear();
            tedOTBeforeEnd2.DataBindings.Clear();
            tedOTBeforeEnd3.DataBindings.Clear();
            tedOTBeforeEnd4.DataBindings.Clear();
            tedOTBeforeEnd5.DataBindings.Clear();
            tedOTBeforeEnd6.DataBindings.Clear();
            tedOTBeforeEnd7.DataBindings.Clear();
            tedOTBeforeStart1.DataBindings.Clear();
            tedOTBeforeStart2.DataBindings.Clear();
            tedOTBeforeStart3.DataBindings.Clear();
            tedOTBeforeStart4.DataBindings.Clear();
            tedOTBeforeStart5.DataBindings.Clear();
            tedOTBeforeStart6.DataBindings.Clear();
            tedOTBeforeStart7.DataBindings.Clear();


            ckbDayoff1.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, DayOff1);
            ckbDayoff2.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, DayOff2);
            ckbDayoff3.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, DayOff3);
            ckbDayoff4.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, DayOff4);
            ckbDayoff5.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, DayOff5);
            ckbDayoff6.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, DayOff6);
            ckbDayoff7.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, DayOff7);
            tedBreakEnd1.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, BreakEnd1);
            tedBreakEnd2.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, BreakEnd2);
            tedBreakEnd3.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, BreakEnd3);
            tedBreakEnd4.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, BreakEnd4);
            tedBreakEnd5.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, BreakEnd5);
            tedBreakEnd6.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, BreakEnd6);
            tedBreakEnd7.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, BreakEnd7);
            tedWorkEnd1.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, WorkEnd1);
            tedWorkEnd2.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, WorkEnd2);
            tedWorkEnd3.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, WorkEnd3);
            tedWorkEnd4.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, WorkEnd4);
            tedWorkEnd5.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, WorkEnd5);
            tedWorkEnd6.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, WorkEnd6);
            tedWorkEnd7.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, WorkEnd7);
            tedWorkStart1.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, WorkStart1);
            tedWorkStart2.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, WorkStart2);
            tedWorkStart3.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, WorkStart3);
            tedWorkStart4.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, WorkStart4);
            tedWorkStart5.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, WorkStart5);
            tedWorkStart6.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, WorkStart6);
            tedWorkStart7.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, WorkStart7);
            tedBreakStart1.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, BreakStart1);
            tedBreakStart2.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, BreakStart2);
            tedBreakStart3.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, BreakStart3);
            tedBreakStart4.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, BreakStart4);
            tedBreakStart5.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, BreakStart5);
            tedBreakStart6.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, BreakStart6);
            tedBreakStart7.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, BreakStart7);

            tedOTBeforeStart1.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTBeforeStart1);
            tedOTBeforeStart2.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTBeforeStart2);
            tedOTBeforeStart3.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTBeforeStart3);
            tedOTBeforeStart4.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTBeforeStart4);
            tedOTBeforeStart5.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTBeforeStart5);
            tedOTBeforeStart6.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTBeforeStart6);
            tedOTBeforeStart7.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTBeforeStart7);

            tedOTBeforeEnd1.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTBeforeEnd1);
            tedOTBeforeEnd2.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTBeforeEnd2);
            tedOTBeforeEnd3.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTBeforeEnd3);
            tedOTBeforeEnd4.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTBeforeEnd4);
            tedOTBeforeEnd5.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTBeforeEnd5);
            tedOTBeforeEnd6.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTBeforeEnd6);
            tedOTBeforeEnd7.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTBeforeEnd7);

            tedOTAfterStart1.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTAfterStart1);
            tedOTAfterStart2.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTAfterStart2);
            tedOTAfterStart3.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTAfterStart3);
            tedOTAfterStart4.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTAfterStart4);
            tedOTAfterStart5.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTAfterStart5);
            tedOTAfterStart6.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTAfterStart6);
            tedOTAfterStart7.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTAfterStart7);

            tedOTAfterEnd1.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTAfterEnd1);
            tedOTAfterEnd2.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTAfterEnd2);
            tedOTAfterEnd3.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTAfterEnd3);
            tedOTAfterEnd4.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTAfterEnd4);
            tedOTAfterEnd5.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTAfterEnd5);
            tedOTAfterEnd6.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTAfterEnd6);
            tedOTAfterEnd7.DataBindings.Add(CommonConst.EDIT_VALUE, dtShiftDetail, OTAfterEnd7);

            dtShiftDetail.RowChanged += new DataRowChangeEventHandler(dtShiftDetail_RowChanged);
            dtShiftDetail.ColumnChanged += new DataColumnChangeEventHandler(dtShiftDetail_ColumnChanged);
        }

        void dtShiftDetail_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            DirtyData = true;
        }

        void dtShiftDetail_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DirtyData = true;
        }

        private void grvShiftSetting_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            grvShiftSetting_Click(null, null);
        }

        private void txtHilightColorCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if(!txtHilightColorCode.Text.Trim().Equals(string.Empty))
                Sample.BackColor = System.Drawing.ColorTranslator.FromHtml(string.Format("#{0}",txtHilightColorCode.Text));
            }
            catch (Exception ex) {
                HPA.Common.Helper.ShowException(ex, ex.Message, this.Text);
            }
        }
        public override bool OnDesignForm()
        {
            try
            {
                HPA.Common.LayOutControlHelper.SaveDesignForm(this);
                HPA.Common.LayOutControlHelper.SaveDesignForm(this.Controls);
                //Open design form
                object o;
                m_fOpenObject("HPA.FORMDESIGNER", "FormDesigner", false,this.Name, out o);
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".OnDesignForm()", null);
                return false;
            }
            return true;


        }
        private void grvShiftSetting_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                // hien thị màu nghỉ
                DataRow dr = grvShiftSetting.GetDataRow(e.RowHandle);
                if (dr == null) return;
                if (dr != null && dr[HilightColorCode] != DBNull.Value)
                {
                    e.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#" + dr[HilightColorCode]);
                }
            }
            catch (Exception ex) {
                HPA.Common.Helper.ShowException(ex, ex.Message, this.Text);
            }
        }


    }
}