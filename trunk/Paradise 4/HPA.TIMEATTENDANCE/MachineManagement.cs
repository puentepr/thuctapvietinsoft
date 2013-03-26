using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using HPA.Common;
using System.IO;
using UdiskData;
namespace HPA.TimeAttendance
{
    public partial class MachineManagement : HPA.Component.Framework.CCommonForm
    {
        string WorkingOnMachine;
        string downloading;
        string uploading;
        zkConnection[] zkConnectionList;
        DataTable dtImageIconList;
        private int irefValue = 0;
        private string strRefValue = "";
        DataTable dtMachineList = null;
        public static DataTable dtUserList = null;
        public static DataTable dtLogList = null;
        DataTable dtVerifyMode = null;
        public MachineManagement()
        {
            InitializeComponent();
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
        public override bool InitializeData()
        {
            try
            {
                //Show machine list
                ShowMachineList();
                dtImageIconList = DBEngine.execReturnDataTable("select * from tblTA_ConnectImageStatus");
                // set lable

                WorkingOnMachine = UIMessage.Get_Message(CommonConst.WORKING_ON_MACHINE);
                downloading = UIMessage.Get_Message(CommonConst.DOWNLOADING_DATA);
                uploading  = UIMessage.Get_Message(CommonConst.DOWNLOADING_DATA);
                Control.ControlCollection ctrls = this.Controls;
                UIMessage.LoadLableName(ref ctrls);
                dtpToDate.DateTime = dtpFromDate.DateTime = DateTime.Now.Date;
                //if (UIMessage.TA_LoadLogTimeWhenOpen)
                //{
                //    grvMachineList.SelectRows(0, grvMachineList.RowCount-1);
                //    btnConnect_Click(null, null);
                //    ckbLoadAll.Checked = true;
                //    btnDownloadAttLog_Click(null, null);
                //    UIMessage.TA_LoadLogTimeWhenOpen = false;
                //}
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".InitializeData()", null);
                return false;
            }

            return true;
        }
        private void ShowMachineList()
        {
            try
            {
                dtMachineList = DBEngine.execReturnDataTable("sp_MachineList");
                if (dtMachineList != null && dtMachineList.Rows.Count > 0)
                {
                    if (dtMachineList.Rows[0]["MachineKind"] == DBNull.Value)
                        colMachineKind.Visible = false;
                }
                dtLogList = DBEngine.execReturnDataTable("zk_UserInfo", "@UserID", 9999999);
                dtUserList = DBEngine.execReturnDataTable("sp_UserInfoList", CommonConst.A_LoginID, UserID);
                dtLogList.RowChanged += new DataRowChangeEventHandler(dtLogList_RowChanged);
                BindingLogInfo();
                dtVerifyMode = DBEngine.execReturnDataTable("zk_VerifyModeList", "@LanguageID", UIMessage.languageID);
                rpeVerifyMode.DataSource = dtVerifyMode;
                grdLogRecord.DataSource = dtLogList;
                grdMachineList.DataSource = dtMachineList;
                zkConnectionList = new zkConnection[dtMachineList.Rows.Count];
                grvMachineList.BestFitColumns();
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, tabMachineList.Name, this.Name);
            }
        }

        private void GetUserList()
        {
            try
            {
                dtUserList = DBEngine.execReturnDataTable("sp_UserInfoList", CommonConst.A_LoginID, UserID);
                grdUserList.DataSource = dtUserList;
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "GetUserList");
            }
        }

        private void BindingLogInfo()
        {
            txtAcNo.DataBindings.Clear();
            txtEmployeeID.DataBindings.Clear();
            txtFullName.DataBindings.Clear();
            txtLogTime.DataBindings.Clear();
            txtNameOnMachine.DataBindings.Clear();
            imgEmployeeImage.DataBindings.Clear();

            txtAcNo.DataBindings.Add(CommonConst.EDIT_VALUE, dtLogList, CommonConst.USER_ID);
            txtEmployeeID.DataBindings.Add(CommonConst.EDIT_VALUE, dtLogList, CommonConst.EmployeeID);
            txtFullName.DataBindings.Add(CommonConst.EDIT_VALUE, dtLogList, CommonConst.FullName);
            txtLogTime.DataBindings.Add(CommonConst.EDIT_VALUE, dtLogList, CommonConst.LOG_TIME);
            txtNameOnMachine.DataBindings.Add(CommonConst.EDIT_VALUE, dtLogList, CommonConst.NAME_ON_MACHINE);
            imgEmployeeImage.DataBindings.Add(CommonConst.EDIT_VALUE, dtLogList, CommonConst.PHOTO);
        }

        void dtLogList_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            try
            {
                //select just added row
                grvLogRecord.ClearSelection();
                grvLogRecord.SelectRow(grvLogRecord.RowCount - 1);
                grvLogRecord.Focus();
                grvLogRecord.FocusedRowHandle = grvLogRecord.RowCount - 1;
                grvLogRecord.FocusedColumn = grvLogRecord.Columns[0];
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.LogError(ex, ex.Message, this.Text);
            }
        }
        public string CDKey(string sInputSN)
        {
            
            int count = 0;
            string soNhan = "";
            string strRet = "";
            string chuc = "0"; string donvi = "0";
            char[] cSN = sInputSN.ToCharArray();
            string[] number = new string[sInputSN.Length + 2];
            string[] numberFinal = new string[sInputSN.Length + 2];
            for (int i = 0; i < number.Length; i++)
                number[i] = "0";
            for (int j = cSN.Length - 1; j >= 0; j--)
            {
                soNhan = Convert.ToString(Convert.ToInt32(chuc) + Convert.ToInt32(cSN[j].ToString()) * 3);
                if (soNhan.Length > 1)
                {
                    chuc = soNhan.Substring(0, 1);
                    donvi = soNhan.Substring(1, 1);
                }
                else
                {
                    chuc = "0";
                    donvi = soNhan.Substring(0, 1);

                }
                number[count++] = donvi;
            }
            number[count] = chuc;
            //Cong
            chuc = "0";
            for (int i = 0; i < number.Length - 1; i++)
            {
                if (i < number.Length)
                    soNhan = Convert.ToString(Convert.ToInt32(chuc) + Convert.ToInt16(number[i]) + Convert.ToInt16(number[i + 1]));
                else
                    soNhan = number[i];
                if (soNhan.Length > 1)
                {
                    chuc = soNhan.Substring(0, 1);
                    donvi = soNhan.Substring(1, 1);
                }
                else
                {
                    chuc = "0";
                    donvi = soNhan.Substring(0, 1);

                }
                numberFinal[i] = donvi;
            }
            numberFinal[numberFinal.Length - 1] = chuc;
            for (int j = numberFinal.Length - 1; j >= 0; j--)
            {
                strRet += numberFinal[j];
            }
            if (strRet.Length > 5)
                return strRet.Substring(0, 4) + strRet.Substring(5, strRet.Length-5);
            else
                return strRet;
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //Get selectec machines
            DataRow drRowSelected = null;
            int[] i = grvMachineList.GetSelectedRows();

            //int iCount = 0;
            if (i.Length == 0) // haven't selected any rows
            {
                UIMessage.ShowMessage(CommonConst.SELECT_MACHINE_FIRST, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                foreach (int sel in i)
                {
                    drRowSelected = dtMachineList.Rows[sel];
                    drRowSelected[CommonConst.STATUS] = UIMessage.Get_Message(CommonConst.CONNECTING);
                    grvMachineList.RefreshData(); grvMachineList.RefreshRowCell(sel, colStatus);
                    this.Refresh();
                    System.Threading.Thread.Sleep(10);
                    int idwErrorCode = 0;
                    zkConnectionList[sel] = new zkConnection();
                    zkConnectionList[sel].DBEngine = DBEngine;
                    zkConnectionList[sel].IPAddress = drRowSelected[CommonConst.IP].ToString();
                    zkConnectionList[sel].Port = int.Parse(drRowSelected[CommonConst.PORT].ToString());
                    zkConnectionList[sel].MachineNumber = int.Parse(drRowSelected[CommonConst.MACHINE_NUMBER].ToString());
                    zkConnectionList[sel].MachineName = drRowSelected[CommonConst.MACHINE_ALIAS].ToString();
                    //zkConnectionList[sel].DisConnectMachine();
                    drRowSelected[CommonConst.IS_CONNECTED] = zkConnectionList[sel].ConnectMachine();
                    zkemkeeper.CZKEM zkInfo = zkConnectionList[sel].AttManager;
                    if (Convert.ToBoolean(drRowSelected[CommonConst.IS_CONNECTED]) == true)
                    {
                        drRowSelected[CommonConst.STATUS] = UIMessage.Get_Message(CommonConst.CONNECTED);
                        if(dtImageIconList != null)
                            drRowSelected[CommonConst.ImageIcon] = dtImageIconList.Select("ImgID = 1")[0][CommonConst.ImageIcon];

                        btnConnect.Refresh();
                        //zkConnectionList[sel].MachineNumber = 1;//In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
                        zkInfo.SetDeviceInfo(zkConnectionList[sel].MachineNumber, 2, zkConnectionList[sel].MachineNumber);// Update thong tin so may len MCC
                        //get device info
                        zkInfo.EnableDevice(zkConnectionList[sel].MachineNumber, false);//disable the device
                        if (zkInfo.GetDeviceStatus(zkConnectionList[sel].MachineNumber, 6, ref irefValue))
                            drRowSelected[CommonConst.LOG_ATT_COUNT] = irefValue;
                        if (zkInfo.GetDeviceStatus(zkConnectionList[sel].MachineNumber, 1, ref irefValue))
                            drRowSelected[CommonConst.MANAGER_COUNT] = irefValue;
                        if (zkInfo.GetDeviceStatus(zkConnectionList[sel].MachineNumber, 2, ref irefValue))
                            drRowSelected[CommonConst.USER_COUNT] = irefValue;
                        if (zkInfo.GetDeviceStatus(zkConnectionList[sel].MachineNumber, 3, ref irefValue))
                            drRowSelected[CommonConst.FINGER_COUNT] = irefValue;
                        if (zkInfo.GetDeviceStatus(zkConnectionList[sel].MachineNumber, 4, ref irefValue))
                            drRowSelected[CommonConst.PASSWORD_COUNT] = irefValue;
                        if (zkInfo.GetSerialNumber(zkConnectionList[sel].MachineNumber, out strRefValue))
                        {
                            drRowSelected[CommonConst.SERIAL_NUMBER] = zkConnectionList[sel].SN = strRefValue;
                            if (CDKey(drRowSelected[CommonConst.SERIAL_NUMBER].ToString()) == drRowSelected[CommonConst.CDKEY].ToString())
                                zkConnectionList[sel].IsRegisted = true;
                            else
                                zkConnectionList[sel].IsRegisted = false;                            
                        }
                        else
                            zkConnectionList[sel].IsRegisted = false;
                        if (zkInfo.GetFirmwareVersion(Convert.ToInt32(zkConnectionList[sel].MachineNumber), ref strRefValue))
                            DBEngine.exec(string.Format("UPDATE Machines SET managercount = '{0}', usercount = '{1}',fingercount = '{2}',sn = '{3}',FirmwareVersion = '{4}' WHERE ID = '{5}' ",
                                drRowSelected[CommonConst.MANAGER_COUNT], drRowSelected[CommonConst.USER_COUNT], drRowSelected[CommonConst.FINGER_COUNT],
                                drRowSelected[CommonConst.SERIAL_NUMBER], strRefValue,drRowSelected["ID"]
                                ));
                        //Lưu dữ liệu
                        zkInfo.EnableDevice(zkConnectionList[sel].MachineNumber, true);//disable the device
                    }
                    else
                    {
                        zkInfo.GetLastError(ref idwErrorCode);
                        drRowSelected[CommonConst.STATUS] = UIMessage.Get_Message(CommonConst.CONNECT_FAILURE);
                        if (dtImageIconList != null)
                            drRowSelected[CommonConst.ImageIcon] = dtImageIconList.Select("ImgID = 3")[0][CommonConst.ImageIcon];
                    }
                    Cursor = Cursors.Default;
                }
                grvMachineList.BestFitColumns();
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "btnConnect_Click");
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            //Get selectec machines
            DataRow drRowSelected = null;
            int[] i = grvMachineList.GetSelectedRows();
            if (i.Length == 0) // haven't selected any rows
            {
                UIMessage.ShowMessage(CommonConst.SELECT_MACHINE_FIRST, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                foreach (int sel in i)
                {
                    if (zkConnectionList[sel] == null)
                        continue;
                    drRowSelected = dtMachineList.Rows[sel];
                    Cursor = Cursors.WaitCursor;
                    zkConnectionList[sel].DisConnectMachine();
                    drRowSelected[CommonConst.STATUS] = UIMessage.Get_Message(CommonConst.DIS_CONNECT);
                    if (dtImageIconList != null)
                        drRowSelected[CommonConst.ImageIcon] = dtImageIconList.Select("ImgID = 2")[0][CommonConst.ImageIcon];
                    drRowSelected[CommonConst.IS_CONNECTED] = false;
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "btnDisconnect_Click");
            }
        }
        public override bool Commit()
        {
            try
            {
                // wait-cursor
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    
                    if ((dtUserList != null) && dtUserList.Rows.Count > 0)
                    {
                        if (dtUserList.GetChanges().Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtUserList.GetChanges().Rows)
                                DBEngine.exec("sp_UserSave",
                                    CommonConst.A_LoginID, UserID,
                                    "@Name", dr[CommonConst.NAME],
                                    "@Privilige", dr[CommonConst.privilege],
                                    "@BadgeNumber", dr[CommonConst.BADGE_NUMBER],
                                    "@Password", dr[CommonConst.Password],
                                    "@CardNo", dr[CommonConst.CARD_NO]);
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    // m_dtTableData.RejectChanges();
                    
                    throw (ex);
                }

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
            return true;
        }
        //private void grvMachineList_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        //{
        //    try
        //    {

        //        if (e.RowHandle != grvMachineList.FocusedRowHandle)
        //        {
        //            DataRow dr = grvMachineList.GetDataRow(e.RowHandle);
        //            if (dr == null) return;
        //            if (Convert.ToBoolean(dr[CommonConst.IS_CONNECTED]) == true)
        //            {
        //                e.Appearance.BackColor = Color.GreenYellow;
        //            }
        //            else
        //            {
        //                e.Appearance.BackColor = Color.White;
        //            }
        //        }
        //    }
        //    catch (Exception exc)
        //    {
        //        HPA.Common.Helper.ShowException(exc, this.Name + ".grvMachineList_RowStyle()", null);
        //    }
        //}

        private void btnDeleteEnrollData_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtMachineList.Select(string.Format("{0} = {1}", CommonConst.IS_CONNECTED, 1)).Length <= 0)
                {
                    UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (UIMessage.ShowMessage(CommonConst.DELETE_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                string sUserID;
                //Duyệt từng máy đang chọn và trạng thái là đang kết nối
                foreach (int i in grvMachineList.GetSelectedRows())//Lấy số thứ tự của máy
                {
                    if (zkConnectionList[i] == null || !zkConnectionList[i].Connected)
                    {
                        UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    Cursor = Cursors.WaitCursor;
                    lableInfor.Visible = true;
                    lableInfor.Text = string.Format(WorkingOnMachine, grvMachineList.GetDataRow(i)[CommonConst.MACHINE_ALIAS]); ;
                    this.Refresh();
                    System.Threading.Thread.Sleep(1);
                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, false);
                    //Duyệt từng user đã chọn và xóa
                    foreach (DataRow drDel in dtUserList.Select("Check = 1"))
                    {
                        sUserID = drDel[CommonConst.BADGE_NUMBER].ToString();
                        if (!zkConnectionList[i].AttManager.IsTFTMachine(Convert.ToInt32(zkConnectionList[i].MachineNumber)))
                        {
                            if (zkConnectionList[i].AttManager.DeleteEnrollData(zkConnectionList[i].MachineNumber, Convert.ToInt32(sUserID), 12, 0))
                            {
                                //zkConnectionList[i].AttManager.DeleteEnrollData(zkConnectionList[i].MachineNumber, Convert.ToInt32(sUserID), 12, 11);
                                //zkConnectionList[i].AttManager.DeleteEnrollData(zkConnectionList[i].MachineNumber, Convert.ToInt32(sUserID), 12, 12);
                                //zkConnectionList[i].AttManager.DeleteEnrollData(zkConnectionList[i].MachineNumber, Convert.ToInt32(sUserID), 12, 13);
                                //zkConnectionList[i].AttManager.DeleteEnrollData(zkConnectionList[i].MachineNumber, Convert.ToInt32(sUserID), 12, 1);
                            }
                        }
                        else
                            if (zkConnectionList[i].AttManager.SSR_DeleteEnrollData(zkConnectionList[i].MachineNumber, sUserID, 0))
                            {
                                //zkConnectionList[i].AttManager.SSR_DeleteEnrollData(zkConnectionList[i].MachineNumber, sUserID, 13);
                                //zkConnectionList[i].AttManager.SSR_DeleteEnrollData(zkConnectionList[i].MachineNumber, sUserID, 3);
                                //zkConnectionList[i].AttManager.SSR_DeleteEnrollData(zkConnectionList[i].MachineNumber, sUserID, 11);
                                //zkConnectionList[i].AttManager.SSR_DeleteEnrollData(zkConnectionList[i].MachineNumber, sUserID, 12);
                                //zkConnectionList[i].AttManager.SSR_DeleteEnrollData(zkConnectionList[i].MachineNumber, sUserID, 1);
                                //zkConnectionList[i].AttManager.SSR_DeleteEnrollData(zkConnectionList[i].MachineNumber, sUserID, 2);
                            }
                        lableInfor.Text = String.Format("{0}\r{1}[{2}] - {3}", string.Format(WorkingOnMachine, grvMachineList.GetDataRow(i)[CommonConst.MACHINE_ALIAS]), uploading, sUserID, drDel[CommonConst.NAME]);
                        this.Refresh();
                        System.Threading.Thread.Sleep(1);
                        zkConnectionList[i].AttManager.RefreshData(zkConnectionList[i].MachineNumber);//the data in the device should be refreshed

                    }

                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, true);
                }
                lableInfor.Visible = false;
                if (ckbDeleteOnSystem.Checked)
                {
                    foreach (DataRow drDel in dtUserList.Select("Check = 1"))
                        DBEngine.exec("Userinfo_Delete", CommonConst.A_LoginID, UserID,
                            "@Badgenumber", drDel[CommonConst.BADGE_NUMBER]);
                }
                UIMessage.ShowMessage(CommonConst.DELETE_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Nạp lại danh sách
                GetUserList();
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                HPA.Common.Helper.ShowException(ex, this.Name, "");
            }
        }

        private void tabMachineList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabMachineList.SelectedTab.Name)
            {
                case "UserManagement":
                    {
                        GetUserList();
                        btnFWSave.Visible = true;
                        cbYear.Text = DateTime.Now.Year.ToString();
                        cbMonth.Text = DateTime.Now.Month.ToString();
                        cbDay.Text = DateTime.Now.Day.ToString();
                        cbHour.Text = DateTime.Now.Hour.ToString();
                        cbMinute.Text = DateTime.Now.Minute.ToString();
                        cbSecond.Text = DateTime.Now.Second.ToString();
                    }
                    break;
                default:
                    btnFWSave.Visible = false;
                    break;
            }
        }

        private void btnClearDataTmps_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtMachineList.Select(string.Format("{0} = {1}", CommonConst.IS_CONNECTED, 1)).Length <= 0)
                {
                    UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (UIMessage.ShowMessage(CommonConst.DELETE_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                const int iDataFlag = 2;
                //Duyệt từng máy đang chọn và trạng thái là đang kết nối
                foreach (int i in grvMachineList.GetSelectedRows())//Lấy số thứ tự của máy
                {
                    if (zkConnectionList[i] == null || !zkConnectionList[i].Connected)
                    {
                        UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    Cursor = Cursors.WaitCursor;
                    lableInfor.Visible = true;
                    lableInfor.Text = string.Format(WorkingOnMachine, grvMachineList.GetDataRow(i)[CommonConst.MACHINE_ALIAS]); ;
                    this.Refresh();
                    System.Threading.Thread.Sleep(1);
                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, false);
                    if (zkConnectionList[i].AttManager.ClearData(zkConnectionList[i].MachineNumber, iDataFlag))
                    {
                        zkConnectionList[i].AttManager.RefreshData(zkConnectionList[i].MachineNumber);//the data in the device should be refreshed
                    }
                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, true);
                }

                lableInfor.Visible = false;
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                HPA.Common.Helper.ShowException(ex, this.Name, "");
            }
            UIMessage.ShowMessage(CommonConst.DELETE_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDownloadUserInfo_Click(object sender, EventArgs e)
        {
            bool isSave = true;
            string sdwEnrollNumber = "";
            int iEnrollNumber = 0;
            string sName = "";
            string sPassword = "";
            string sCardNo = "";
            int iPrivilege = 0;
            bool bEnabled = false;
            int idwFingerIndex;
            string sTmpData = "";
            int iTmpLength = 0;
            int iFlag = 0;
            try
            {
                if (dtMachineList.Select(string.Format("{0} = {1}", CommonConst.IS_CONNECTED, 1)).Length <= 0)
                {
                    UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //Duyệt từng máy đang chọn và trạng thái là đang kết nối
                foreach (int i in grvMachineList.GetSelectedRows())//Lấy số thứ tự của máy
                {
                    if (zkConnectionList[i] == null || !zkConnectionList[i].Connected)
                    {
                        UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    Cursor = Cursors.WaitCursor;
                    lableInfor.Visible = true;
                    lableInfor.Text = string.Format(WorkingOnMachine, grvMachineList.GetDataRow(i)[CommonConst.MACHINE_ALIAS]); ;
                    this.Refresh();
                    System.Threading.Thread.Sleep(1);
                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, false);
                    if (!zkConnectionList[i].AttManager.IsTFTMachine(Convert.ToInt32(zkConnectionList[i].MachineNumber)))
                    {
                        zkConnectionList[i].AttManager.BeginBatchUpdate(zkConnectionList[i].MachineNumber, 1);
                        zkConnectionList[i].AttManager.ReadAllUserID(zkConnectionList[i].MachineNumber);//read all the user information to the memory
                        zkConnectionList[i].AttManager.ReadAllTemplate(zkConnectionList[i].MachineNumber);//read all the users' fingerprint templates to the memory
                        while (zkConnectionList[i].AttManager.GetAllUserInfo(zkConnectionList[i].MachineNumber, ref iEnrollNumber, ref sName, ref sPassword, ref iPrivilege, ref bEnabled))//get all the users' information from the memory
                        {
                            //Save User info
                            zkConnectionList[i].AttManager.GetStrCardNumber(out sCardNo);
                            if (!CheckExistsUser(iEnrollNumber.ToString()))
                            {
                                //save into database
                                DBEngine.exec("sp_UserSave", CommonConst.A_LoginID, UserID, "@Name", sName, "@Privilige", iPrivilege, "@BadgeNumber", iEnrollNumber, "@Password", sPassword, "@CardNo", sCardNo);
                                isSave = true;
                                for (idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
                                {
                                    if (zkConnectionList[i].AttManager.GetUserTmpStr(zkConnectionList[i].MachineNumber, iEnrollNumber, idwFingerIndex, ref sTmpData, ref iTmpLength))//get the corresponding templates string and length from the memory
                                    {
                                        //Save finger infor
                                        DBEngine.exec("sp_TemplateSave", CommonConst.A_LoginID, UserID, "@UserID", iEnrollNumber, "@FINGERID", idwFingerIndex, "@TEMPLATE", sTmpData, "@Flag", iFlag);

                                    }
                                }
                            }
                        }
                        zkConnectionList[i].AttManager.BatchUpdate(zkConnectionList[i].MachineNumber);
                    }
                    else
                    {
                        zkConnectionList[i].AttManager.ReadAllUserID(zkConnectionList[i].MachineNumber);//read all the user information to the memory
                        zkConnectionList[i].AttManager.ReadAllTemplate(zkConnectionList[i].MachineNumber);//read all the users' fingerprint templates to the memory
                        while (zkConnectionList[i].AttManager.SSR_GetAllUserInfo(zkConnectionList[i].MachineNumber, out sdwEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))//get all the users' information from the memory
                        {
                            //Save User info
                            zkConnectionList[i].AttManager.GetStrCardNumber(out sCardNo);
                            if (!CheckExistsUser(sdwEnrollNumber))
                            {
                                //save into database
                                DBEngine.exec("sp_UserSave", CommonConst.A_LoginID, UserID, "@Name", sName, "@Privilige", iPrivilege, "@BadgeNumber", sdwEnrollNumber, "@Password", sPassword, "@CardNo", sCardNo);
                                isSave = true;
                                for (idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
                                {
                                    if (zkConnectionList[i].AttManager.GetUserTmpExStr(zkConnectionList[i].MachineNumber, sdwEnrollNumber, idwFingerIndex, out iFlag, out sTmpData, out iTmpLength))//get the corresponding templates string and length from the memory
                                    {
                                        if (sTmpData != null)
                                            if (!sTmpData.Trim().Equals(string.Empty))
                                                //Save finger infor
                                                DBEngine.exec("sp_TemplateSave", CommonConst.A_LoginID, UserID, "@UserID", sdwEnrollNumber, "@FINGERID", idwFingerIndex, "@TEMPLATE", sTmpData, "@Flag", iFlag);

                                    }
                                }
                            }
                        }
                    }
                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, true);
                    lableInfor.Visible = false;
                }
                if(isSave)
                    UIMessage.ShowMessage(CommonConst.DATASAVED_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Nạp lại danh sách
                GetUserList();
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                HPA.Common.Helper.ShowException(ex, this.Name, "");
            }
        }

        private bool CheckExistsUser(string EnrollNumber)
        {
            try
            {
                if (DBEngine.execReturnDataTable("sp_CheckExistsUser","@BadgeNumber",EnrollNumber).Rows.Count > 0)
                    return true;
            }
            catch
            { return false; }
            return false;
        }

        private void btnUploadUserInfo_Click(object sender, EventArgs e)
        {
            const int iUpdateFlag = 1;
            try
            {
                if (dtMachineList.Select(string.Format("{0} = {1}", CommonConst.IS_CONNECTED, 1)).Length <= 0)
                {
                    UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //Duyệt từng máy đang chọn và trạng thái là đang kết nối
                foreach (int i in grvMachineList.GetSelectedRows())//Lấy số thứ tự của máy
                {
                    if (zkConnectionList[i] == null || !zkConnectionList[i].Connected)
                    {
                        UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    Cursor = Cursors.WaitCursor;
                    lableInfor.Visible = true;
                    lableInfor.Text = string.Format(WorkingOnMachine, grvMachineList.GetDataRow(i)[CommonConst.MACHINE_ALIAS]); ;
                    this.Refresh();
                    System.Threading.Thread.Sleep(1);
                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, false);
                    //Duyệt từng user đã chọn và xóa
                    foreach (DataRow drUp in dtUserList.Select("Check = 1"))
                    {
                        if (!zkConnectionList[i].AttManager.IsTFTMachine(Convert.ToInt32(zkConnectionList[i].MachineNumber)))
                        {
                            if (zkConnectionList[i].AttManager.BeginBatchUpdate(zkConnectionList[i].MachineNumber, iUpdateFlag))//create memory space for batching data
                            {
                                int iLastEnrollNumber = 0;//the former enrollnumber you have upload(define original value as 0)
                                if (drUp[CommonConst.BADGE_NUMBER].ToString() != iLastEnrollNumber.ToString())//identify whether the user information(except fingerprint templates) has been uploaded
                                {
                                    //Upload CardNo if any
                                    if (ckbUpdateCardNo.Checked)
                                        zkConnectionList[i].AttManager.SetStrCardNumber(drUp[CommonConst.CARD_NO].ToString());
                                    if (zkConnectionList[i].AttManager.SetUserInfo(zkConnectionList[i].MachineNumber, Convert.ToInt32(drUp[CommonConst.BADGE_NUMBER]), drUp[CommonConst.NAME].ToString(), drUp[CommonConst.Password].ToString(), Convert.ToInt32(drUp[CommonConst.privilege].ToString()), true) && ckbUploadFingerPrint.Checked)//upload user information to the memory
                                    {
                                        //get template info to upload
                                        DataTable m_dtTemplate = DBEngine.execReturnDataTable(string.Format("select * from Template where UserID = {0}", drUp[CommonConst.USER_ID]));
                                        foreach (DataRow drTemp in m_dtTemplate.Rows)
                                        {
                                            zkConnectionList[i].AttManager.SetUserTmpStr(zkConnectionList[i].MachineNumber, Convert.ToInt32(drUp[CommonConst.BADGE_NUMBER]), Convert.ToInt32(drTemp[CommonConst.FINGERID].ToString()), drTemp[CommonConst.Template_Text].ToString());//upload templates information to the device
                                        }
                                    }
                                }
                                else if (ckbUploadFingerPrint.Checked)//the current fingerprint and the former one belongs the same user,that is ,one user has more than one template
                                {
                                    DataTable m_dtTemplate = DBEngine.execReturnDataTable(string.Format("select * from Template where UserID = {0}", drUp[CommonConst.USER_ID]));
                                    foreach (DataRow drTemp in m_dtTemplate.Rows)
                                    {
                                        zkConnectionList[i].AttManager.SetUserTmpStr(zkConnectionList[i].MachineNumber, Convert.ToInt32(drUp[CommonConst.BADGE_NUMBER]), Convert.ToInt32(drTemp[CommonConst.FINGERID].ToString()), drTemp[CommonConst.Template_Text].ToString());//upload templates information to the device
                                    }
                                }
                                iLastEnrollNumber = Convert.ToInt32(drUp[CommonConst.BADGE_NUMBER]);//change the value of iLastEnrollNumber dynamicly
                            }
                            zkConnectionList[i].AttManager.BatchUpdate(zkConnectionList[i].MachineNumber);
                        }
                        else
                        {
                            if (zkConnectionList[i].AttManager.BeginBatchUpdate(zkConnectionList[i].MachineNumber, iUpdateFlag))//create memory space for batching data
                            {
                                //Upload CardNo if any
                                if (ckbUpdateCardNo.Checked)
                                    zkConnectionList[i].AttManager.SetStrCardNumber(drUp[CommonConst.CARD_NO].ToString());
                                if (ckbUploadFingerPrint.Checked)
                                {
                                    string sLastEnrollNumber = "";//the former enrollnumber you have upload(define original value as 0)
                                    DataTable m_dtTemplate = DBEngine.execReturnDataTable(string.Format("select * from Template where UserID = {0}", drUp[CommonConst.USER_ID]));
                                    foreach (DataRow drTemp in m_dtTemplate.Rows)
                                    {
                                        if (drUp[CommonConst.BADGE_NUMBER].ToString() != sLastEnrollNumber)//identify whether the user information(except fingerprint templates) has been uploaded
                                        {
                                            if (zkConnectionList[i].AttManager.SSR_SetUserInfo(zkConnectionList[i].MachineNumber, drUp[CommonConst.BADGE_NUMBER].ToString(), drUp[CommonConst.NAME].ToString(), drUp[CommonConst.Password].ToString(), Convert.ToInt32(drUp[CommonConst.privilege].ToString()), true))//upload user information to the memory
                                            {
                                                zkConnectionList[i].AttManager.SetUserTmpExStr(zkConnectionList[i].MachineNumber, drUp[CommonConst.BADGE_NUMBER].ToString(), Convert.ToInt32(drTemp[CommonConst.FINGERID].ToString()), Convert.ToInt32(drTemp[CommonConst.Flag]), drTemp[CommonConst.Template_Text].ToString());//upload templates information to the memory
                                            }
                                        }
                                        else//the current fingerprint and the former one belongs the same user,that is ,one user has more than one template
                                        {
                                            zkConnectionList[i].AttManager.SetUserTmpExStr(zkConnectionList[i].MachineNumber, drUp[CommonConst.BADGE_NUMBER].ToString(), Convert.ToInt32(drTemp[CommonConst.FINGERID].ToString()), Convert.ToInt32(drTemp[CommonConst.Flag]), drTemp[CommonConst.Template_Text].ToString());//upload templates information to the memory
                                        }
                                        sLastEnrollNumber = drUp[CommonConst.BADGE_NUMBER].ToString();//change the value of iLastEnrollNumber dynamicly
                                    }
                                }
                                else { zkConnectionList[i].AttManager.SSR_SetUserInfo(zkConnectionList[i].MachineNumber, drUp[CommonConst.BADGE_NUMBER].ToString(), drUp[CommonConst.NAME].ToString(), drUp[CommonConst.Password].ToString(), Convert.ToInt32(drUp[CommonConst.privilege].ToString()), true); }
                            }
                            zkConnectionList[i].AttManager.BatchUpdate(zkConnectionList[i].MachineNumber);
                        }
                        lableInfor.Text = String.Format("{0}\r{1}[{2}] - {3}", string.Format(WorkingOnMachine, grvMachineList.GetDataRow(i)[CommonConst.MACHINE_ALIAS]), uploading, drUp[CommonConst.BADGE_NUMBER], drUp[CommonConst.NAME]);
                        this.Refresh();
                        System.Threading.Thread.Sleep(1);
                    }
                    zkConnectionList[i].AttManager.RefreshData(zkConnectionList[i].MachineNumber);
                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, true);
                }
                lableInfor.Visible = false;
                UIMessage.ShowMessage(CommonConst.UPDATE_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Nạp lại danh sách
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                HPA.Common.Helper.ShowException(ex, this.Name, "");
            }
        }

        private void ckbCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (dtUserList != null && dtUserList.Rows.Count > 0)
            {
                for (int i = 0; i < grvUserList.RowCount; i++)
                {
                    grvUserList.SetRowCellValue(i, colCheck, ckbCheckAll.Checked);
                }
            }
            grvUserList.Focus();
            grvUserList.SelectRow(0);
        }

        private void btnDownloadAttLog_Click(object sender, EventArgs e)
        {
            string strDateTime = "";
            int idwEnrollNumber = 0;
            bool isHaveData = false;
            bool isDownloadSuc = false;
            DateTime logTime;
            string strQuery;
            try
            {
                if (dtMachineList.Select(string.Format("{0} = {1}", CommonConst.IS_CONNECTED, 1)).Length <= 0)
                {
                    UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                lableInfor.Visible = true;
                Cursor = Cursors.WaitCursor;
                dtLogList.Clear();
                int idwInOutMode = 0;
                string EnrollNumber; int VerifyMethod = 0; int Year; int Month; int Day; int Hour;
                int Minute; int Second; int WorkCode = 0;
                //Duyệt từng máy đang chọn và trạng thái là đang kết nối
                foreach (int i in grvMachineList.GetSelectedRows())//Lấy số thứ tự của máy
                {
                    //Chua đăng ký thì ko tải về
                    if (!zkConnectionList[i].IsRegisted)
                    {
                        MessageBox.Show(string.Format("Máy chấm công {0} chưa được đăng ký. Vui lòng đăng ký thông tin sản phẩm trước! Bạn hãy liên hệ với cửa hàng bán sản phẩm họ sẽ cung cấp số đăng ký hoàn toàn miễn phí cho bạn.", grvMachineList.GetDataRow(i)[CommonConst.MACHINE_ALIAS]), UIMessage.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        continue;
                    }
                    lableInfor.Text = string.Format(WorkingOnMachine, grvMachineList.GetDataRow(i)[CommonConst.MACHINE_ALIAS]); 
                    this.Refresh();
                    System.Threading.Thread.Sleep(1);

                    lableInfor.Text = String.Format("{0}\r{1}", string.Format(WorkingOnMachine, grvMachineList.GetDataRow(i)[CommonConst.MACHINE_ALIAS]), UIMessage.Get_Message(CommonConst.READING_DATA));
                    this.Refresh();
                    System.Threading.Thread.Sleep(1);
                    if (!zkConnectionList[i].AttManager.IsTFTMachine(Convert.ToInt32(zkConnectionList[i].MachineNumber)))
                    {
                        zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, false);
                        isHaveData = zkConnectionList[i].AttManager.ReadGeneralLogData(zkConnectionList[i].MachineNumber);
                        zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, true);
                        if (isHaveData)//read the records to the memory
                        {
                            while (zkConnectionList[i].AttManager.GetGeneralLogDataStr(zkConnectionList[i].MachineNumber, ref idwEnrollNumber, ref VerifyMethod, ref idwInOutMode, ref strDateTime))//get the records from memory
                            {
                                //strDateTime = string.Format("{0}-{1}-{2} {3}:{4}:{5}", Year.ToString(), Month.ToString(), Day.ToString(), Hour.ToString(), Minute.ToString(), Second.ToString());
                                if (CheckExistsAttLog(strDateTime, idwEnrollNumber.ToString()))
                                    continue;
                                //Show record
                                DataRow drAdd = MachineManagement.dtLogList.NewRow();
                                drAdd[CommonConst.USER_ID] = idwEnrollNumber.ToString();
                                drAdd[CommonConst.VERIFY_MODE] = VerifyMethod;
                                // get Log time
                                logTime = Convert.ToDateTime(strDateTime);
                                drAdd[CommonConst.LOG_TIME] = logTime;
                                DataTable dtUserInfo = DBEngine.execReturnDataTable("zk_UserInfo", "@UserID", idwEnrollNumber.ToString());
                                if (dtUserInfo.Rows.Count <= 0)
                                {
                                    // get privilage of new user
                                    // normal is 0: user

                                    strQuery = string.Format("INSERT INTO userinfo (Name,badgenumber,Privilege,SSN) VALUES ('{0}','{1}',{2},'{3}')", idwEnrollNumber, idwEnrollNumber, 0, idwEnrollNumber);
                                    DBEngine.exec(strQuery);
                                    dtUserInfo = DBEngine.execReturnDataTable("zk_UserInfo", "@UserID", idwEnrollNumber);
                                }
                                drAdd[CommonConst.MACHINE_ALIAS] = zkConnectionList[i].MachineName;
                                drAdd[CommonConst.NAME_ON_MACHINE] = dtUserInfo.Rows[0][CommonConst.NAME_ON_MACHINE];
                                drAdd[CommonConst.FullName] = dtUserInfo.Rows[0][CommonConst.FullName];
                                drAdd[CommonConst.EmployeeID] = dtUserInfo.Rows[0][CommonConst.EmployeeID];
                                MachineManagement.dtLogList.Rows.Add(drAdd);
                                //drAdd
                                drAdd[CommonConst.MACHINE_NUMBER] = zkConnectionList[i].MachineNumber;
                                //Save to DataBase
                                DBEngine.exec("sp_Checkinout_Save", "@UserID", drAdd[CommonConst.USER_ID], "@ChectTime", strDateTime,
                                    "@MachineNumber", drAdd[CommonConst.MACHINE_NUMBER],
                                    "@AttState", idwInOutMode, "@VERIFYCODE", VerifyMethod, "@WorkCode", WorkCode);
                                isDownloadSuc = true;
                                lableInfor.Text = String.Format("{0}\r{1}[{2}] - {3}", string.Format(WorkingOnMachine, grvMachineList.GetDataRow(i)[CommonConst.MACHINE_ALIAS]), downloading, idwEnrollNumber, dtUserInfo.Rows[0][CommonConst.NAME_ON_MACHINE]);
                                this.Refresh();
                                System.Threading.Thread.Sleep(1);
                                grvLogRecord.RefreshData();
                                grdLogRecord.RefreshDataSource();
                            }
                        }
                    }
                    else
                    {
                        zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, false);
                        isHaveData =zkConnectionList[i].AttManager.ReadGeneralLogData(zkConnectionList[i].MachineNumber);
                        zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, true);

                        if (isHaveData)//read all the attendance records to the memory
                        {
                            while (zkConnectionList[i].AttManager.SSR_GetGeneralLogData(zkConnectionList[i].MachineNumber, out EnrollNumber, out VerifyMethod,
                                       out idwInOutMode, out Year, out Month, out Day, out Hour, out Minute, out Second, ref WorkCode))//get records from the memory
                            {
                                strDateTime = string.Format("{0}-{1}-{2} {3}:{4}:{5}", Year, Month, Day, Hour, Minute, Second);
                                if (CheckExistsAttLog(strDateTime, EnrollNumber))
                                    continue;
                                //Show record
                                DataRow drAdd = MachineManagement.dtLogList.NewRow();
                                drAdd[CommonConst.USER_ID] = EnrollNumber;
                                drAdd[CommonConst.VERIFY_MODE] = VerifyMethod;
                                logTime = Convert.ToDateTime(strDateTime);
                                drAdd[CommonConst.LOG_TIME] = logTime;
                                DataTable dtUserInfo = DBEngine.execReturnDataTable("zk_UserInfo", "@UserID", EnrollNumber);
                                if (dtUserInfo.Rows.Count <= 0)
                                {
                                    // get privilage of new user
                                    // normal is 0: user
                                    strQuery = string.Format("INSERT INTO userinfo (Name,badgenumber,Privilege,SSN) VALUES ('{0}','{1}',{2},'{3}')", EnrollNumber, EnrollNumber, 0, EnrollNumber);
                                    DBEngine.exec(strQuery);
                                    dtUserInfo = DBEngine.execReturnDataTable("zk_UserInfo", "@UserID", EnrollNumber);
                                }
                                drAdd[CommonConst.MACHINE_ALIAS] = zkConnectionList[i].MachineName;
                                drAdd[CommonConst.NAME_ON_MACHINE] = dtUserInfo.Rows[0][CommonConst.NAME_ON_MACHINE];
                                drAdd[CommonConst.FullName] = dtUserInfo.Rows[0][CommonConst.FullName];
                                drAdd[CommonConst.EmployeeID] = dtUserInfo.Rows[0][CommonConst.EmployeeID];
                                MachineManagement.dtLogList.Rows.Add(drAdd);
                                //drAdd
                                drAdd[CommonConst.MACHINE_NUMBER] = zkConnectionList[i].MachineNumber;
                                //Save to DataBase
                                DBEngine.exec("sp_Checkinout_Save", "@UserID", drAdd[CommonConst.USER_ID], "@ChectTime", strDateTime,
                                    "@MachineNumber", drAdd[CommonConst.MACHINE_NUMBER],
                                    "@AttState", idwInOutMode, "@VERIFYCODE", VerifyMethod, "@WorkCode", WorkCode);
                                lableInfor.Text = String.Format("{0}\r{1}[{2}] - {3}", string.Format(WorkingOnMachine, grvMachineList.GetDataRow(i)[CommonConst.MACHINE_ALIAS]), downloading, EnrollNumber, dtUserInfo.Rows[0][CommonConst.NAME_ON_MACHINE]);
                                isDownloadSuc = true;
                                this.Refresh();
                                System.Threading.Thread.Sleep(1);
                                grvLogRecord.RefreshData();
                                grdLogRecord.RefreshDataSource();
                            }
                        }
                    }
                    if (ckbClearAllLogAfterLoadSuccessfully.Checked)
                        zkConnectionList[i].AttManager.ClearGLog(zkConnectionList[i].MachineNumber);
                    zkConnectionList[i].AttManager.RefreshData(zkConnectionList[i].MachineNumber);
                }
                lableInfor.Visible = false;
                if(isDownloadSuc)
                    UIMessage.ShowMessage(CommonConst.DATADOWNLOAD_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                lableInfor.Visible = false;
                Cursor = Cursors.Default;
                HPA.Common.Helper.ShowException(ex, this.Name, "");
            }
        }
        private bool CheckExistsAttLog(string dt, string BagNum)
        {
            DateTime dtVal;
            try
            {
                if (dtpFromDate.Enabled) {
                    dtVal = Convert.ToDateTime(dt);
                    if (dtpFromDate.DateTime.Date > dtVal.Date || dtpToDate.DateTime.Date < dtVal.Date)
                        return true;
                }
                if (DBEngine.execReturnDataTable(string.Format("Select 1 from CheckInOut u INNER JOIN USERINFO i ON u.USERID = i.USERID WHERE i.BADGENUMBER = '{0}' AND u.CHECKTIME = '{1}'",BagNum, dt)).Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.LogError(ex, ex.Message, this.Text);
            }
            return false;
        }
        private void btnClearDataUserInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtMachineList.Select(string.Format("{0} = {1}", CommonConst.IS_CONNECTED, 1)).Length <= 0)
                {
                    UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (UIMessage.ShowMessage(CommonConst.DELETE_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                //Duyệt từng máy đang chọn và trạng thái là đang kết nối
                foreach (int i in grvMachineList.GetSelectedRows())//Lấy số thứ tự của máy
                {
                    if (zkConnectionList[i] == null || !zkConnectionList[i].Connected)
                    {
                        UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    Cursor = Cursors.WaitCursor;
                    lableInfor.Visible = true;
                    lableInfor.Text = string.Format(WorkingOnMachine, grvMachineList.GetDataRow(i)[CommonConst.MACHINE_ALIAS]); ;
                    this.Refresh();
                    System.Threading.Thread.Sleep(1);
                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, false);
                    if (zkConnectionList[i].AttManager.ClearData(zkConnectionList[i].MachineNumber, 5))
                    {
                        zkConnectionList[i].AttManager.RefreshData(zkConnectionList[i].MachineNumber);//the data in the device should be refreshed
                    }
                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, true);
                }
                lableInfor.Visible = false;
                if (ckbDeleteOnSystem.Checked)
                {
                    DBEngine.exec("Delete UserInfo");
                }
                UIMessage.ShowMessage(CommonConst.DELETE_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Nạp lại danh sách
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                HPA.Common.Helper.ShowException(ex, this.Name, "");
            }
        }

        private void btnClearAdministrators_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtMachineList.Select(string.Format("{0} = {1}", CommonConst.IS_CONNECTED, 1)).Length <= 0)
                {
                    UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (UIMessage.ShowMessage(CommonConst.DELETE_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                //Duyệt từng máy đang chọn và trạng thái là đang kết nối
                foreach (int i in grvMachineList.GetSelectedRows())//Lấy số thứ tự của máy
                {
                    if (zkConnectionList[i] == null || !zkConnectionList[i].Connected)
                    {
                        UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    Cursor = Cursors.WaitCursor;
                    lableInfor.Visible = true;
                    lableInfor.Text = string.Format(WorkingOnMachine, grvMachineList.GetDataRow(i)[CommonConst.MACHINE_ALIAS]); ;
                    this.Refresh();
                    System.Threading.Thread.Sleep(1);
                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, false);
                    if (zkConnectionList[i].AttManager.ClearAdministrators(zkConnectionList[i].MachineNumber))
                    {
                        zkConnectionList[i].AttManager.RefreshData(zkConnectionList[i].MachineNumber);//the data in the device should be refreshed
                    }
                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, true);
                }
                lableInfor.Visible = false;
                UIMessage.ShowMessage(CommonConst.DELETE_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Nạp lại danh sách
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                HPA.Common.Helper.ShowException(ex, this.Name, "");
            }
        }

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            string strFilter = string.Empty;
            for (int i = 0; i < dtUserList.Columns.Count; i++)
            {
                switch (dtUserList.Columns[i].DataType.Name.ToLower())
                {
                    case "string":
                    case "varchar":
                    case "nvarchar":
                    case "text":
                        strFilter = String.Format("{0}[{1}{2}", strFilter, dtUserList.Columns[i].Caption, string.Format("] like '%{0}%' or ", txtSearch.Text));

                        break;
                    default:
                        break;

                }
            }
            strFilter = strFilter.Substring(0, strFilter.Length - 3);
            dtUserList.DefaultView.RowFilter = strFilter;

        }

        private void btnSynDeviceTime_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtMachineList.Select(string.Format("{0} = {1}", CommonConst.IS_CONNECTED, 1)).Length <= 0)
                {
                    UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                
                //Duyệt từng máy đang chọn và trạng thái là đang kết nối
                foreach (int i in grvMachineList.GetSelectedRows())//Lấy số thứ tự của máy
                {
                    if (zkConnectionList[i] == null || !zkConnectionList[i].Connected)
                    {
                        UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    Cursor = Cursors.WaitCursor;
                    lableInfor.Visible = true;
                    lableInfor.Text = string.Format(WorkingOnMachine, grvMachineList.GetDataRow(i)[CommonConst.MACHINE_ALIAS]); ;
                    this.Refresh();
                    System.Threading.Thread.Sleep(1); 
                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, false);
                    if (zkConnectionList[i].AttManager.SetDeviceTime(zkConnectionList[i].MachineNumber))
                    {
                        zkConnectionList[i].AttManager.RefreshData(zkConnectionList[i].MachineNumber);
                    }
                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, true);
                }
                lableInfor.Visible = false;
                UIMessage.ShowMessage(CommonConst.UPDATE_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                HPA.Common.Helper.ShowException(ex, this.Name, "");
            }
        }

        private void btnGetDeviceTime_Click(object sender, EventArgs e)
        {
            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;
            try
            {
                if (dtMachineList.Select(string.Format("{0} = {1}", CommonConst.IS_CONNECTED, 1)).Length <= 0)
                {
                    UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                
                

                //Duyệt từng máy đang chọn và trạng thái là đang kết nối
                foreach (int i in grvMachineList.GetSelectedRows())//Lấy số thứ tự của máy
                {
                    if (zkConnectionList[i] == null || !zkConnectionList[i].Connected)
                    {
                        UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    Cursor = Cursors.WaitCursor;
                    lableInfor.Visible = true;
                    lableInfor.Text = string.Format(WorkingOnMachine, grvMachineList.GetDataRow(i)[CommonConst.MACHINE_ALIAS]); ;
                    this.Refresh();
                    System.Threading.Thread.Sleep(1); 
                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, false);
                    if (zkConnectionList[i].AttManager.GetDeviceTime(zkConnectionList[i].MachineNumber, ref idwYear, ref idwMonth, ref idwDay, ref idwHour, ref idwMinute, ref idwSecond))
                    {
                        txtGetDeviceTime.Text = String.Format("{0}-{1:00}-{2:00} {3:00}:{4:00}:{5:00}", idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond);
                    }
                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, true);
                }
                lableInfor.Visible = false;
                UIMessage.ShowMessage(CommonConst.UPDATE_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                HPA.Common.Helper.ShowException(ex, this.Name, "");
            }
        }

        private void btnSetDeviceTime2_Click(object sender, EventArgs e)
        {
            int idwYear = Convert.ToInt32(cbYear.Text.Trim());
            int idwMonth = Convert.ToInt32(cbMonth.Text.Trim());
            int idwDay = Convert.ToInt32(cbDay.Text.Trim());
            int idwHour = Convert.ToInt32(cbHour.Text.Trim());
            int idwMinute = Convert.ToInt32(cbMinute.Text.Trim());
            int idwSecond = Convert.ToInt32(cbSecond.Text.Trim());
            try
            {
                if (dtMachineList.Select(string.Format("{0} = {1}", CommonConst.IS_CONNECTED, 1)).Length <= 0)
                {
                    UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                //Duyệt từng máy đang chọn và trạng thái là đang kết nối
                foreach (int i in grvMachineList.GetSelectedRows())//Lấy số thứ tự của máy
                {
                    if (zkConnectionList[i] == null || !zkConnectionList[i].Connected)
                    {
                        UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    Cursor = Cursors.WaitCursor;
                    lableInfor.Visible = true;
                    lableInfor.Text = string.Format(WorkingOnMachine, grvMachineList.GetDataRow(i)[CommonConst.MACHINE_ALIAS]); ;
                    this.Refresh();
                    System.Threading.Thread.Sleep(1); 
                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, false);
                    if (zkConnectionList[i].AttManager.SetDeviceTime2(zkConnectionList[i].MachineNumber, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond))
                    {
                        zkConnectionList[i].AttManager.RefreshData(zkConnectionList[i].MachineNumber);//the data in the device should be refreshed
                    }
                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, true);
                }
                lableInfor.Visible = false;
                UIMessage.ShowMessage(CommonConst.UPDATE_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                HPA.Common.Helper.ShowException(ex, this.Name, "");
            }
        }

        private void btnRestartDevice_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtMachineList.Select(string.Format("{0} = {1}", CommonConst.IS_CONNECTED, 1)).Length <= 0)
                {
                    UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //Duyệt từng máy đang chọn và trạng thái là đang kết nối
                foreach (int i in grvMachineList.GetSelectedRows())//Lấy số thứ tự của máy
                {
                    if (zkConnectionList[i] == null || !zkConnectionList[i].Connected)
                    {
                        UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    Cursor = Cursors.WaitCursor;
                    lableInfor.Visible = true;
                    lableInfor.Text = string.Format(WorkingOnMachine, grvMachineList.GetDataRow(i)[CommonConst.MACHINE_ALIAS]); ;
                    this.Refresh();
                    System.Threading.Thread.Sleep(1); 
                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, false);
                    zkConnectionList[i].AttManager.RestartDevice(zkConnectionList[i].MachineNumber);
                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, true);
                }
                lableInfor.Visible = false;
                UIMessage.ShowMessage(CommonConst.RESTART_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                HPA.Common.Helper.ShowException(ex, this.Name, "");
            }
        }

        private void btnPowerOffDevice_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtMachineList.Select(string.Format("{0} = {1}", CommonConst.IS_CONNECTED, 1)).Length <= 0)
                {
                    UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //Duyệt từng máy đang chọn và trạng thái là đang kết nối
                foreach (int i in grvMachineList.GetSelectedRows())//Lấy số thứ tự của máy
                {
                    if (zkConnectionList[i] == null || !zkConnectionList[i].Connected)
                    {
                        UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    Cursor = Cursors.WaitCursor;
                    lableInfor.Visible = true;
                    lableInfor.Text = string.Format(WorkingOnMachine, grvMachineList.GetDataRow(i)[CommonConst.MACHINE_ALIAS]); ;
                    this.Refresh();
                    System.Threading.Thread.Sleep(1); 
                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, false);
                    zkConnectionList[i].AttManager.PowerOffDevice(zkConnectionList[i].MachineNumber);
                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, true);
                }
                lableInfor.Visible = false;
                UIMessage.ShowMessage(CommonConst.POWEROFF_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                HPA.Common.Helper.ShowException(ex, this.Name, "");
            }
        }

        private void btnUserRead_Click(object sender, EventArgs e)
        {
            UDisk udisk = new UDisk();

            byte[] byDataBuf = null;
            int iLength;
            int iCount;//count of users

            int iPIN = 0;
            int iPrivilege = 0;
            string sName = "";
            string sPassword = "";
            int iCard = 0;
            int iGroup = 0;
            int iTimeZones = 0;
            int iPIN2 = 0;

            lvUser.Items.Clear();
            openFileDialog1.Filter = "user(*.dat)|*.dat";
            openFileDialog1.FileName = "user.dat";
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream stream = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                    byDataBuf = File.ReadAllBytes(openFileDialog1.FileName);
                    iLength = Convert.ToInt32(stream.Length);

                    if (iLength % 28 != 0)
                    {
                        MessageBox.Show("Data Error!Please check whether you have chosen the right file!", "Error");
                        return;
                    }
                    iCount = iLength / 28;

                    for (int j = 0; j < iCount; j++)//loop to manage all the users
                    {
                        byte[] byUserInfo = new byte[28];
                        for (int i = 0; i < 28; i++)//loop to manage every user's information
                        {
                            byUserInfo[i] = byDataBuf[j * 28 + i];
                        }
                        udisk.GetUserInfoFromDat(byUserInfo, out iPIN, out iPrivilege, out sPassword, out sName, out iCard, out iGroup, out iTimeZones, out iPIN2);

                        ListViewItem list = new ListViewItem() { Text = iPIN2.ToString() };
                        list.SubItems.Add(sName);
                        list.SubItems.Add(iCard.ToString());
                        list.SubItems.Add(iPrivilege.ToString());
                        list.SubItems.Add(sPassword);
                        list.SubItems.Add(iGroup.ToString());
                        list.SubItems.Add(iTimeZones.ToString());
                        list.SubItems.Add(iPIN.ToString());
                        lvUser.Items.Add(list);
                        //SAVE DATA TO DATABASE
                        DBEngine.exec("sp_UserSave",
                            CommonConst.A_LoginID, UserID,
                            "@Name", sName,
                            "@Privilige", iPrivilege,
                            "@BadgeNumber", iPIN,
                            "@Password", sPassword,
                            "@CardNo", iCard);
                        byUserInfo = null;
                    }
                    stream.Close();
                }
                UIMessage.ShowMessage(CommonConst.DATASAVED_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "btnUserRead_Click");
            }
        }

        private void btnAttLogExtRead_Click(object sender, EventArgs e)
        {
            UDisk udisk = new UDisk();

            byte[] byDataBuf = null;
            int iLength;//length of the bytes to get from the data

            string sPIN = "";
            string sVerified = "";
            string sTime_second = "";
            string sDeviceID = "";
            string sStatus = "";
            string sWorkcode = "";

            openFileDialog1.Filter = "1_attlog(*.dat)|*.dat";
            openFileDialog1.FileName = "1_attlog.dat";
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream stream = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                    byDataBuf = File.ReadAllBytes(openFileDialog1.FileName);
                    iLength = Convert.ToInt32(stream.Length);

                    int iStart = 0;//the index of the last byte used to store the serial number(the value in this byte is Ascii code 10(the Escape character "\n"))
                    int iEnd = 0;//the index of the last byte used to store the extended attendence logs(the value in this byte is Ascii code 10(the Escape character "\n"))
                    int i = 0;

                    for (i = 0; i < iLength; i++)//to get the value of iStart
                    {
                        if (byDataBuf[i] == 10)
                        {
                            iStart = i;
                            break; ;
                        }
                    }
                    for (i = iLength - 2; i >= 0; i--)//to get the value of iEnd
                    {
                        if (byDataBuf[i] == 10)
                        {
                            iEnd = i;
                            break;
                        }
                    }

                    byte[] bySNBuf = new byte[iStart + 1];
                    Array.Copy(byDataBuf, 0, bySNBuf, 0, iStart + 1);

                    byte[] byCheckSumBuf = new byte[iLength - 1 - iEnd];
                    Array.Copy(byDataBuf, iEnd + 1, byCheckSumBuf, 0, iLength - 1 - iEnd);

                    lvAttLog.Items.Clear();
                    int iStartIndex = iStart + 1;
                    int iOneLogLength;//the length of one line of attendence log
                    for (i = iStartIndex; i < iEnd + 1; i++)//iEnd+1 means the bytes count of the data except the checksum
                    {
                        if (byDataBuf[i] == 13 && byDataBuf[i + 1] == 10)
                        {
                            iOneLogLength = (i + 1) + 1 - iStartIndex;
                            byte[] bySSRAttLog = new byte[iOneLogLength];
                            Array.Copy(byDataBuf, iStartIndex, bySSRAttLog, 0, iOneLogLength);

                            udisk.GetAttLogFromDat(bySSRAttLog, iOneLogLength, out sPIN, out sTime_second, out sDeviceID, out sStatus, out sVerified, out sWorkcode);

                            ListViewItem list = new ListViewItem() { Text = sPIN };
                            list.SubItems.Add(sTime_second);
                            list.SubItems.Add(sDeviceID);
                            list.SubItems.Add(sStatus);
                            list.SubItems.Add(sVerified);
                            list.SubItems.Add(sWorkcode);
                            lvAttLog.Items.Add(list);

                            bySSRAttLog = null;
                            iStartIndex += iOneLogLength;
                            iOneLogLength = 0;
                            // save to database
                            //Save to DataBase
                            DBEngine.exec("sp_Checkinout_Save", "@UserID", sPIN, "@ChectTime", sTime_second,
                                "@MachineNumber", sDeviceID,
                                "@AttState", sStatus, "@VERIFYCODE", sVerified, "@WorkCode", sWorkcode);
                        }
                    }
                    stream.Close();
                }
                UIMessage.ShowMessage(CommonConst.DATASAVED_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "btnUserRead_Click");
            }
        }

        private void btnTmpRead_Click(object sender, EventArgs e)
        {
            UDisk udisk = new UDisk();

            byte[] byDataBuf = null;
            int iLength;
            int iCount;

            int iSize = 0;
            int iPIN = 0;
            int iFingerID = 0;
            int iValid = 0;
            string sTemplate = "";

            lvTmp.Items.Clear();
            openFileDialog1.Filter = "template(*.dat)|*.dat";
            openFileDialog1.FileName = "template.dat";
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream stream = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                    byDataBuf = File.ReadAllBytes(openFileDialog1.FileName);

                    iLength = Convert.ToInt32(stream.Length);
                    if (iLength % 608 != 0)
                    {
                        MessageBox.Show("Data Error!", "Error", MessageBoxButtons.OK);
                        return;
                    }
                    iCount = iLength / 608;

                    for (int j = 0; j < iCount; j++)//loop to manage all the templates
                    {
                        byte[] byTmpInfo = new byte[608];
                        for (int i = 0; i < 608; i++)//loop to manage every template
                        {
                            byTmpInfo[i] = byDataBuf[j * 608 + i];
                        }
                        udisk.GetTemplateFromDat(byTmpInfo, out iSize, out iPIN, out iFingerID, out iValid, out sTemplate);

                        ListViewItem list = new ListViewItem() { Text = iSize.ToString() };
                        list.SubItems.Add(iPIN.ToString());
                        list.SubItems.Add(iFingerID.ToString());
                        list.SubItems.Add(iValid.ToString());
                        list.SubItems.Add(sTemplate);
                        lvTmp.Items.Add(list);
                        //save data into database
                        //Save finger infor
                        DBEngine.exec("sp_TemplateSave", 
                            CommonConst.A_LoginID, UserID,
                            "@UserID", iPIN,
                            "@FINGERID", iFingerID,
                            "@TEMPLATE", sTemplate, 
                            "@Flag", 1);
                        byTmpInfo = null;
                    }
                    stream.Close();
                }
                UIMessage.ShowMessage(CommonConst.DATASAVED_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "btnUserRead_Click");
            }
        }

        private void btnSSR_UserRead_Click(object sender, EventArgs e)
        {
            UDisk udisk = new UDisk();

            byte[] byDataBuf = null;
            int iLength;
            int iCount;//count of users

            int iPIN = 0;
            int iPrivilege = 0;
            string sName = "";
            string sPassword = "";
            int iCard = 0;
            int iGroup = 0;
            string sTimeZones = "";
            string sPIN2 = "";

            lvSSRUser.Items.Clear();
            openFileDialog1.Filter = "user(*.dat)|*.dat";
            openFileDialog1.FileName = "user.dat";
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream stream = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                    byDataBuf = File.ReadAllBytes(openFileDialog1.FileName);

                    iLength = Convert.ToInt32(stream.Length);
                    if (iLength % 72 != 0)
                    {
                        MessageBox.Show("Data Error!Please check whether you have chosen the right file!", "Error", MessageBoxButtons.OK);
                        return;
                    }
                    iCount = iLength / 72;

                    for (int j = 0; j < iCount; j++)//loop to deal with all the users
                    {
                        byte[] byUserInfo = new byte[72];
                        for (int i = 0; i < 72; i++)//loop to deal with every user's information
                        {
                            byUserInfo[i] = byDataBuf[j * 72 + i];
                        }
                        udisk.GetSSRUserInfoFromDat(byUserInfo, out iPIN, out iPrivilege, out sPassword, out sName, out iCard, out iGroup, out sTimeZones, out sPIN2);

                        ListViewItem list = new ListViewItem() { Text = sPIN2 };
                        list.SubItems.Add(sName);
                        list.SubItems.Add(iCard.ToString());
                        list.SubItems.Add(iPrivilege.ToString());
                        list.SubItems.Add(sPassword);
                        list.SubItems.Add(iGroup.ToString());
                        list.SubItems.Add(sTimeZones);
                        list.SubItems.Add(iPIN.ToString());
                        lvSSRUser.Items.Add(list);
                        //SAVE DATA TO DATABASE
                        DBEngine.exec("sp_UserSave",
                            CommonConst.A_LoginID, UserID,
                            "@Name", sName,
                            "@Privilige", iPrivilege,
                            "@BadgeNumber", iPIN,
                            "@Password", sPassword,
                            "@CardNo", iCard);
                        byUserInfo = null;
                    }
                    stream.Close();
                }
                UIMessage.ShowMessage(CommonConst.DATASAVED_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "btnUserRead_Click");
            }
            
        }

        private void btnSSRAttLogRead_Click(object sender, EventArgs e)
        {
            UDisk udisk = new UDisk();

            byte[] byDataBuf = null;
            int iLength;//length of the bytes to get from the data

            string sPIN2 = "";
            string sVerified = "";
            string sTime_second = "";
            string sDeviceID = "";
            string sStatus = "";
            string sWorkcode = "";

            openFileDialog1.Filter = "1_attlog(*.dat)|*.dat";
            openFileDialog1.FileName = "1_attlog.dat";//1 stands for one possible deviceid
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream stream = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                    byDataBuf = File.ReadAllBytes(openFileDialog1.FileName);
                    iLength = Convert.ToInt32(stream.Length);

                    lvSSRAttLog.Items.Clear();
                    int iStartIndex = 0;
                    int iOneLogLength;//the length of one line of attendence log
                    for (int i = iStartIndex; i < iLength - 2; i++)//modify by darcy on Dec.4 2009
                    {
                        if (byDataBuf[i] == 13 && byDataBuf[i + 1] == 10)
                        {
                            iOneLogLength = (i + 1) + 1 - iStartIndex;
                            byte[] bySSRAttLog = new byte[iOneLogLength];
                            Array.Copy(byDataBuf, iStartIndex, bySSRAttLog, 0, iOneLogLength);

                            udisk.GetAttLogFromDat(bySSRAttLog, iOneLogLength, out sPIN2, out sTime_second, out sDeviceID, out sStatus, out sVerified, out sWorkcode);

                            ListViewItem list = new ListViewItem() { Text = sPIN2 };
                            list.SubItems.Add(sTime_second);
                            list.SubItems.Add(sDeviceID);
                            list.SubItems.Add(sStatus);
                            list.SubItems.Add(sVerified);
                            list.SubItems.Add(sWorkcode);
                            lvSSRAttLog.Items.Add(list);
                            //Save to DataBase
                            DBEngine.exec("sp_Checkinout_Save", "@UserID", sPIN2, "@ChectTime", sTime_second,
                                "@MachineNumber", sDeviceID,
                                "@AttState", sStatus, "@VERIFYCODE", sVerified, "@WorkCode", sWorkcode);
                            bySSRAttLog = null;
                            iStartIndex += iOneLogLength;
                            iOneLogLength = 0;
                        }
                    }
                    stream.Close();
                }
                UIMessage.ShowMessage(CommonConst.DATASAVED_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "btnUserRead_Click");
            }
            
        }

        private void btnTemp9_TFT_Click(object sender, EventArgs e)
        {
            UDisk udisk = new UDisk();

            byte[] byDataBuf = null;
            int iLength;
            int iCount;

            int iSize = 0;
            int iPIN = 0;
            int iFingerID = 0;
            int iValid = 0;
            string sTemplate = "";

            lvTmp9.Items.Clear();
            openFileDialog1.Filter = "template(*.dat)|*.dat";
            openFileDialog1.FileName = "template.dat";
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream stream = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                    byDataBuf = File.ReadAllBytes(openFileDialog1.FileName);

                    iLength = Convert.ToInt32(stream.Length);
                    if (iLength % 608 != 0)
                    {
                        MessageBox.Show("Data Error!", "Error", MessageBoxButtons.OK);
                        return;
                    }
                    iCount = iLength / 608;

                    for (int j = 0; j < iCount; j++)//loop to deal with all the templates
                    {
                        byte[] byTmpInfo = new byte[608];
                        for (int i = 0; i < 608; i++)//loop to deal with every template
                        {
                            byTmpInfo[i] = byDataBuf[j * 608 + i];
                        }
                        udisk.GetTemplateFromDat(byTmpInfo, out iSize, out iPIN, out iFingerID, out iValid, out sTemplate);

                        ListViewItem list = new ListViewItem();
                        list.Text = iSize.ToString();
                        list.SubItems.Add(iPIN.ToString());
                        list.SubItems.Add(iFingerID.ToString());
                        list.SubItems.Add(iValid.ToString());
                        list.SubItems.Add(sTemplate);
                        lvTmp9.Items.Add(list);
                        DBEngine.exec("sp_TemplateSave",
                            CommonConst.A_LoginID, UserID,
                            "@UserID", iPIN,
                            "@FINGERID", iFingerID,
                            "@TEMPLATE", sTemplate,
                            "@Flag", iValid);
                        byTmpInfo = null;
                    }
                    stream.Close();
                }
                UIMessage.ShowMessage(CommonConst.DATASAVED_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "btnUserRead_Click");
            }
        }

        private void btnTmp10Read_Click(object sender, EventArgs e)
        {
            UDisk udisk = new UDisk();

            byte[] byDataBuf = null;
            int iLength;
            int iStartIndex;

            int iSize = 0;
            int iPIN = 0;
            int iFingerID = 0;
            int iValid = 0;
            string sTemplate = "";

            lvTmp10.Items.Clear();
            openFileDialog1.Filter = "template(*.fp10.1)|*.fp10.1";
            openFileDialog1.FileName = "template.fp10.1";
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream stream = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                    byDataBuf = File.ReadAllBytes(openFileDialog1.FileName);

                    iLength = Convert.ToInt32(stream.Length);

                    iStartIndex = 0;
                    for (int i = 0; i < iLength; i++)
                    {
                        iSize = byDataBuf[i] + byDataBuf[i + 1] * 256;//the variable length of the 10.0 arithmetic template
                        byte[] byTmpInfo = new byte[iSize];

                        Array.Copy(byDataBuf, iStartIndex, byTmpInfo, 0, iSize);

                        iStartIndex += iSize;
                        i = iStartIndex - 1;

                        udisk.GetTmp10FromFp10(byTmpInfo, iSize, out iPIN, out iFingerID, out iValid, out sTemplate);

                        ListViewItem list = new ListViewItem() { Text = iSize.ToString() };
                        list.SubItems.Add(iPIN.ToString());
                        list.SubItems.Add(iFingerID.ToString());
                        list.SubItems.Add(iValid.ToString());
                        list.SubItems.Add(sTemplate);
                        lvTmp10.Items.Add(list);
                        DBEngine.exec("sp_TemplateSave",
                            CommonConst.A_LoginID, UserID,
                            "@UserID", iPIN,
                            "@FINGERID", iFingerID,
                            "@TEMPLATE", sTemplate,
                            "@Flag", iValid);
                        byTmpInfo = null;
                    }
                    stream.Close();
                }
                UIMessage.ShowMessage(CommonConst.DATASAVED_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "btnUserRead_Click");
            }
        }

        private void btnDeleteAllData_Click(object sender, EventArgs e)
        {
            if (UIMessage.ShowMessage(CommonConst.DELETE_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            try
            {
                if (dtMachineList.Select(string.Format("{0} = {1}", CommonConst.IS_CONNECTED, 1)).Length <= 0)
                {
                    UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //Duyệt từng máy đang chọn và trạng thái là đang kết nối
                foreach (int i in grvMachineList.GetSelectedRows())//Lấy số thứ tự của máy
                {
                    if (zkConnectionList[i] == null || !zkConnectionList[i].Connected)
                    {
                        UIMessage.ShowMessage(CommonConst.CONNECT_TO_DIVICE_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    Cursor = Cursors.WaitCursor;
                    lableInfor.Visible = true;
                    lableInfor.Text = string.Format(WorkingOnMachine, grvMachineList.GetDataRow(i)[CommonConst.MACHINE_ALIAS]); ;
                    this.Refresh();
                    System.Threading.Thread.Sleep(1);
                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, false);
                    zkConnectionList[i].AttManager.ClearKeeperData(zkConnectionList[i].MachineNumber);
                    zkConnectionList[i].AttManager.EnableDevice(zkConnectionList[i].MachineNumber, true);
                }
                lableInfor.Visible = false;
                UIMessage.ShowMessage(CommonConst.DELETE_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                HPA.Common.Helper.ShowException(ex, this.Name, "");
            }
        }

        private void btnDelAllUserOnDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                if (UIMessage.ShowMessage(CommonConst.DELETE_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                foreach (DataRow drDel in dtUserList.Rows)
                {
                    DBEngine.exec("Userinfo_Delete", CommonConst.A_LoginID, UserID,
                            "@Badgenumber", drDel[CommonConst.BADGE_NUMBER]);
                }
                DBEngine.exec("delete UserInfo");
                UIMessage.ShowMessage(CommonConst.DELETE_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Nạp lại danh sách
                Cursor = Cursors.Default;
                GetUserList();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                HPA.Common.Helper.ShowException(ex, this.Name, "");
            }
        }

        private void MachineManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dtMachineList == null)
                return;
            // duyet tat ca cac may, may nao dang ket noi thi dong ket noi
            try
            {
                for (int sel = 0; sel < dtMachineList.Rows.Count; sel++)
                {
                    if (zkConnectionList[sel] == null)
                        continue;
                    zkConnectionList[sel].DisConnectMachine();
                }
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "btnDisconnect_Click");
            }
        }

        private void ckbLoadAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbLoadAll.Checked)
                dtpFromDate.Enabled = dtpToDate.Enabled = false;
            else
                dtpFromDate.Enabled = dtpToDate.Enabled = true;
        }

        private void grvUserList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name.ToLower().Equals("colname"))
                DirtyData = true;
        }
     }
}