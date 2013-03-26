using System;
using System.Collections.Generic;
using System.Data;
using HPA.Common;

namespace HPA.TimeAttendance
{
    class zkConnection
    {
        private zkemkeeper.CZKEM _AttManager;
        private Component.Framework.Base.IDatabaseEngine _DBEngine;


        public Component.Framework.Base.IDatabaseEngine DBEngine
        {
            get { return _DBEngine; }
            set { _DBEngine = value; }
        }
        public zkemkeeper.CZKEM AttManager
        {
            get { return _AttManager; }
            set { _AttManager = value; }
        }
        private bool _IsRegisted;

        public bool IsRegisted
        {
            get { return _IsRegisted; }
            set { _IsRegisted = value; }
        }
        private string _MachineName;
        private string _SN;
        private string _IPAddress;
        private int _MachineNumber;
        private bool _Connected;
        private bool _Registed;

        public bool Registed
        {
            get { return _Registed; }
            set { _Registed = value; }
        }
        public string SN
        {
            get { return _SN; }
            set { _SN = value; }
        }
        public bool Connected
        {
            get { return _Connected; }
            set { _Connected = value; }
        }

        public int MachineNumber
        {
            get { return _MachineNumber; }
            set { _MachineNumber = value; }
        }
        private int _Port;

        public int Port
        {
            get { return _Port; }
            set { _Port = value; }
        }

        public string IPAddress
        {
            get { return _IPAddress; }
            set { _IPAddress = value; }
        }

        public string MachineName
        {
            get { return _MachineName; }
            set { _MachineName = value; }
        }

        public bool ConnectMachine()
        {
            bool retVal;
            _AttManager = new zkemkeeper.CZKEM();
            retVal = _AttManager.Connect_Net(IPAddress, Port);
            _AttManager.RegEvent(1, 65535);//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            _AttManager.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(AttManager_OnAttTransactionEx);
            _Connected = retVal;
            return retVal;
            
        }
        //public string CDKey(string sInputSN)
        //{
        //    // Multipli to 13 and remove 4th char
        //    int count = 0;
        //    string soNhan = "";
        //    string strRet = "";
        //    string chuc = "0"; string donvi = "0";
        //    char[] cSN = sInputSN.ToCharArray();
        //    string[] number = new string[sInputSN.Length + 2];
        //    string[] numberFinal = new string[sInputSN.Length + 2];
        //    for (int i = 0; i < number.Length; i++)
        //        number[i] = "0";
        //    for (int j = cSN.Length - 1; j >= 0; j--)
        //    {
        //        soNhan = Convert.ToString(Convert.ToInt32(chuc) + Convert.ToInt32(cSN[j].ToString()) * 3);
        //        if (soNhan.Length > 1)
        //        {
        //            chuc = soNhan.Substring(0, 1);
        //            donvi = soNhan.Substring(1, 1);
        //        }
        //        else
        //        {
        //            chuc = "0";
        //            donvi = soNhan.Substring(0, 1);

        //        }
        //        number[count++] = donvi;
        //    }
        //    number[count] = chuc;
        //    //Cong
        //    chuc = "0";
        //    for (int i = 0; i < number.Length - 1; i++)
        //    {
        //        if (i < number.Length)
        //            soNhan = Convert.ToString(Convert.ToInt32(chuc) + Convert.ToInt16(number[i]) + Convert.ToInt16(number[i + 1]));
        //        else
        //            soNhan = number[i];
        //        if (soNhan.Length > 1)
        //        {
        //            chuc = soNhan.Substring(0, 1);
        //            donvi = soNhan.Substring(1, 1);
        //        }
        //        else
        //        {
        //            chuc = "0";
        //            donvi = soNhan.Substring(0, 1);

        //        }
        //        numberFinal[i] = donvi;
        //    }
        //    numberFinal[numberFinal.Length - 1] = chuc;
        //    for (int j = numberFinal.Length - 1; j >= 0; j--)
        //    {
        //        strRet += numberFinal[j];
        //    }
        //    return strRet.Substring(0,4)+strRet.Substring(5,strRet.Length);
        //}
        public bool GetSysOption(out string sValue)
        {
            return _AttManager.GetSysOption(MachineNumber, "~ZKFPVersion",out sValue);
        }
        public bool GetFirmwareVersion(ref string sValue)
        {
            if (sValue == null)
                sValue = "0";
            return _AttManager.GetFirmwareVersion(MachineNumber,ref sValue);
        }
        
        public void DisConnectMachine()
        {
            _AttManager.Disconnect();
            _AttManager.OnAttTransactionEx -= new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(AttManager_OnAttTransactionEx);
        }
        void AttManager_OnAttTransactionEx(string EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
        {
            int iMachineNumber = MachineNumber;
            string strDateTime;
            DateTime logTime;
            string strQuery;
            try
            {

                //Show record
                DataRow drAdd = MachineManagement.dtLogList.NewRow();
                drAdd[CommonConst.USER_ID] = EnrollNumber;
                drAdd[CommonConst.VERIFY_MODE] = VerifyMethod;
                // get Log time
                strDateTime = string.Format("{0}-{1}-{2} {3}:{4}:{5}", Year, Month, Day, Hour, Minute, Second);
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
                drAdd[CommonConst.MACHINE_ALIAS] = MachineName;
                drAdd[CommonConst.NAME_ON_MACHINE] = dtUserInfo.Rows[0][CommonConst.NAME_ON_MACHINE];
                drAdd[CommonConst.FullName] = dtUserInfo.Rows[0][CommonConst.FullName];
                drAdd[CommonConst.EmployeeID] = dtUserInfo.Rows[0][CommonConst.EmployeeID];
                drAdd[CommonConst.PHOTO] = MachineManagement.dtUserList.Select(string.Format("Badgenumber = '{0}'", EnrollNumber))[0][CommonConst.PHOTO];
                MachineManagement.dtLogList.Rows.Add(drAdd);
                //MachineManagement.dtLogList = DBEngine.execReturnDataTable("zk_UserInfo", "@UserID", EnrollNumber);
                //drAdd
                drAdd[CommonConst.MACHINE_NUMBER] = iMachineNumber;
                //Save to DataBase
                DBEngine.exec("sp_Checkinout_Save", "@UserID", drAdd[CommonConst.USER_ID], "@ChectTime", strDateTime,
                                    "@MachineNumber", drAdd[CommonConst.MACHINE_NUMBER],
                                    "@AttState", AttState, "@VERIFYCODE", VerifyMethod, "@WorkCode", WorkCode);
            }
            catch(Exception ex)
            {
                Helper.LogError(ex, ex.Message, "AttManager_OnAttTransactionEx");
            }
        }
    }
}
