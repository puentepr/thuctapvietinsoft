using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Paradise5.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<tblSC_Login> Login();
        [OperationContract]
        int Checklogin(string Name, string Pass);
        [OperationContract]
        void SetSession(string UserName);
        [OperationContract]
        string GetSession();
        [OperationContract]
        void RemoveSession();
        [OperationContract]
        List<ViewMenu> ViewMN(string Langgue);
        [OperationContract]
        int GetID();
        [OperationContract]
        List<sp_EmployeeIDListResult> FindNV(int id);
        [OperationContract]
        List<tblDepartment> danhsachtheocagiolam();
        [OperationContract]
        List<tmpCheckTimeList> CheckTimeList(DateTime from, DateTime to, int depID, int secID, int groupId, string empID, bool nomal, bool noIn, bool noOut, bool noInNoOut, bool wordOnHolyday, bool leave, bool holyday, int logID);
        [OperationContract]
        List<tblDepartment> ColDepartmentCodelist();
        [OperationContract]
        List<tblSection> ColSectionCodelist();
        [OperationContract]
        List<tblGroup> ColGroupCodelist();
    }
}
