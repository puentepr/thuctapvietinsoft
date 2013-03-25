using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HPA.Common
{
    public class SaveData
    {
          bool isNoUpdate = false;
            public SaveData(string scrName, EzSqlCollection.EzSql2 DBE)
            {
                DBEngine = DBE;
                screenName = scrName;
            }
            private EzSqlCollection.EzSql2 DBEngine = null;
            string screenName;
            public bool SaveDataTable(DataTable dtTable, string[] tableName)
            {
                if (dtTable == null)
                    return false;
                if (dtTable.Rows.Count <= 0)
                    return false;
                bool isDuplicate = false;
                DataRow drOld = null;
                DataRow dr = null;
                DataTable dtSave = dtTable.Copy();
                dtTable.RejectChanges();
                try
                {
                    if ((dtSave != null) && dtSave.Rows.Count > 0)
                    {
                        //foreach(DataRow dr in dtSave.Rows)
                        for (int i = 0; i < dtSave.Rows.Count; i++)
                        {
                            foreach (string tblN in tableName)
                            {
                                dr = dtSave.Rows[i];
                                if (IsEmptyRow(dr, tblN))
                                    continue;
                                if (dr.RowState == DataRowState.Added)
                                {

                                    //Check duplicate
                                    isDuplicate = IsDupplication(dr, dtSave, tblN);
                                    if (isDuplicate)
                                    {
                                        return !isDuplicate;
                                    }
                                    //Insert new record
                                    MakeInsertNewQuery(dr, dtSave, tblN);
                                    EZLog(dr, dr, tblN);
                                }
                                else if (dr.RowState == DataRowState.Modified)
                                {
                                    // Update existing record
                                    MakeUpdateQuery(dr, tblN);
                                    if (!isNoUpdate)
                                    {
                                        drOld = dtTable.Rows[i];
                                        EZLog(drOld, dr, tblN);
                                    }
                                }
                            }
                        }
                    }
                    if (!isDuplicate)
                    {
                        dtSave.AcceptChanges();
                        HPA.Common.Methods.ShowMessage(Common.CommonConst.DATASAVED_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex)
                {
                    // dtSave.RejectChanges();
                    throw (ex);
                }
                return true;
            }
            private void MakeUpdateQuery(DataRow dr, string TableName)
            {
                DataTable m_dtPrimaryKeys = DBEngine.execReturnDataTable("sp_TableEditor_GetPrimaryKeys", "@Tablename", TableName);
                SqlConnection CN = new SqlConnection(DBEngine.ConnectionString);
                string strRetVal = "";
                string query = string.Format("Update {0} set ", TableName);
                string strSet = "";
                string strWhere = " where ";
                bool isKeys = false;
                for (int i = 0; i < dr.Table.Columns.Count; i++)
                {
                    //Loai bo keys
                    foreach (DataRow drPri in m_dtPrimaryKeys.Rows)
                    {
                        if (drPri[0].ToString().Equals(dr.Table.Columns[i].Caption))
                        {
                            isKeys = true;
                            break;
                        }
                    }
                    if (isKeys)
                    {
                        isKeys = false;
                        continue;
                    }
                    //update only column belong to original table not belong to view
                    if (isColumnOfTable(dr.Table.Columns[i].Caption, TableName))
                    {
                        if (dr[dr.Table.Columns[i].Caption, DataRowVersion.Original].ToString() != dr[dr.Table.Columns[i].Caption].ToString())
                            strSet += String.Format("[{0}] = @{0},", dr.Table.Columns[i].Caption);
                    }
                }
                
                if (strSet.Length > 1)
                {
                    isNoUpdate = false;
                    strSet = strSet.Substring(0, strSet.Length - 1) + " ";
                }
                else
                {
                    isNoUpdate = true;
                    return;
                }
                // Where statement
                foreach (DataRow drPri in m_dtPrimaryKeys.Rows)
                {
                    strWhere += String.Format("[{0}] = @{0} and ", drPri[0]);
                }
                strWhere = strWhere.Substring(0, strWhere.Length - 4);
                strRetVal = query + strSet + strWhere;
                SqlCommand SqlCom = new SqlCommand(strRetVal, CN);
                for (int i = 0; i < dr.Table.Columns.Count; i++)
                {
                    if (isColumnOfTable(dr.Table.Columns[i].Caption, TableName))
                    {

                        if (dr[dr.Table.Columns[i].Caption, DataRowVersion.Original].ToString() != dr[dr.Table.Columns[i].Caption].ToString() || m_dtPrimaryKeys.Select(string.Format("Name = '{0}'", dr.Table.Columns[i].Caption)).Length > 0)
                        {
                            SqlParameter paramAdd = new SqlParameter("@" + dr.Table.Columns[i].Caption, dr[i]);
                            switch (dr.Table.Columns[i].DataType.Name.ToLower())
                            {
                                case "image":
                                case "byte[]":
                                    paramAdd.DbType = DbType.Binary;
                                    break;
                                default:
                                    break;

                            }
                            //strValues += "N'" + getValidValue(dr, i) + "',";//;dr[i].ToString()
                            SqlCom.Parameters.Add(paramAdd);
                        }
                    }
                }
                CN.Open();
                SqlCom.ExecuteNonQuery();
                CN.Close();
            }
            private void EZLog(DataRow drOld, DataRow dr, string tblN)
            {
                string keysValue = string.Empty;
                string keysName = string.Empty;
                string columnName = string.Empty;
                string strEmployeeID = string.Empty;
                try
                {
                    keysValue = GetKeyValue(drOld, tblN);
                    if (dr.Table.Columns.Contains(CommonConst.EmployeeID))
                        strEmployeeID = dr[CommonConst.EmployeeID].ToString();
                    switch (dr.RowState)
                    {
                        case DataRowState.Deleted:
                            //log delete data
                            keysName = GetKeyName(tblN);
                            EZLog("Delete", keysName, keysValue, "", tblN, strEmployeeID);
                            break;
                        case DataRowState.Added:
                            keysName = GetKeyName(tblN);
                            EZLog("Add new", keysName, "", keysValue, tblN, strEmployeeID);
                            break;
                        case DataRowState.Modified:
                            for (int i = 0; i < dr.Table.Columns.Count; i++)
                            {
                                if (!(dr[i].ToString().Equals(drOld[i].ToString())))
                                {
                                    //Log modified
                                    columnName = Methods.GetMessage(dr.Table.Columns[i].Caption);
                                    keysName = String.Format("({0} , {1})", keysValue, columnName);
                                    EZLog("Modified", keysName, drOld[i].ToString(), dr[i].ToString(), tblN, strEmployeeID);
                                }
                            }
                            break;
                        default:
                            //log delete data
                            keysName = GetKeyName(tblN);
                            EZLog("Delete", keysName, keysValue, "", tblN, strEmployeeID);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            private string GetKeyValue(DataRow drOld, string TableName)
            {
                DataTable m_dtPrimaryKeys = DBEngine.execReturnDataTable("sp_TableEditor_GetPrimaryKeys", "@Tablename", TableName);
                string retVal = "[";
                foreach (DataRow dr in m_dtPrimaryKeys.Rows)
                {
                    retVal += String.Format("{0} , ", drOld[dr[0].ToString()]);
                }
                return retVal.Substring(0, retVal.Length - 3) + "]";
            }
            private string GetKeyName(string TableName)
            {
                DataTable m_dtPrimaryKeys = DBEngine.execReturnDataTable("sp_TableEditor_GetPrimaryKeys", "@Tablename", TableName);
                string retVal = string.Empty;
                foreach (DataRow dr in m_dtPrimaryKeys.Rows)
                {
                    retVal += String.Format("{0} ; ", dr[0]);
                }
                return retVal.Substring(0, retVal.Length - 3);
            }
            private void EZLog(string Action, string keyName, string oldValue, string newValue, string TableName, string strEmpID)
            {
                try
                {
                    if (!strEmpID.Equals(string.Empty))
                        DBEngine.exec("sp_EZLogMasterData_2",
                       "@Action", Action,
                       "@KeyName", keyName,
                       "@EmployeeID", strEmpID,
                       "@OldValue", oldValue,
                       "@NewValue", newValue,
                       "@FunctionClassName", string.Format("{0}.{1}", StaticVars.FullClassName, TableName),
                       "@ScreenName", screenName,
                       "@LoginID", HPA.Common.StaticVars.LoginID);
                    else
                        DBEngine.exec("sp_EZLogMasterData",
                            "@Action", Action,
                            "@KeyName", keyName,
                            "@OldValue", oldValue,
                            "@NewValue", newValue,
                            "@FunctionClassName", string.Format("{0}.{1}", StaticVars.FullClassName, TableName),
                            "@ScreenName", screenName,
                            "@LoginID", HPA.Common.StaticVars.LoginID);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            private bool IsEmptyRow(DataRow dr, string TableName)
            {
                DataTable m_dtPrimaryKeys = DBEngine.execReturnDataTable("sp_TableEditor_GetPrimaryKeys", "@Tablename", TableName);
                foreach (DataRow drKey in m_dtPrimaryKeys.Rows)
                {
                    if (dr[drKey[0].ToString()].ToString().Equals("") && drKey[1].ToString().Equals("0"))
                    {
                        return true;
                    }
                }
                return false;
            }
            private void MakeInsertNewQuery(DataRow dr, DataTable m_dtTableData, string TableName)
            {
                string strRetVal = string.Empty;
                bool isIdentity = false;
                DataTable m_dtPrimaryKeys = DBEngine.execReturnDataTable("sp_TableEditor_GetPrimaryKeys", "@Tablename", TableName);
                SqlConnection CN = new SqlConnection(DBEngine.ConnectionString);
                foreach (DataRow drKey in m_dtPrimaryKeys.Rows)
                {
                    if (dr[drKey[0].ToString()].ToString().Equals("") && drKey[1].ToString().Equals("0"))
                        return;
                }
                //I am here right now
                string query = string.Format("Insert into {0} (", TableName);
                string strColumnsName = "";
                string strValues = " Values (";
                for (int i = 0; i < m_dtTableData.Columns.Count; i++)
                {
                    //Loai bo keys
                    foreach (DataRow drPri in m_dtPrimaryKeys.Rows)
                    {
                        if (drPri[0].ToString().Equals(m_dtTableData.Columns[i].Caption) && drPri[1].ToString().Equals("1"))
                        {
                            isIdentity = true;
                            break;
                        }
                    }
                    if (isIdentity)
                    {
                        isIdentity = false;
                        continue;
                    }
                    if (isColumnOfTable(m_dtTableData.Columns[i].Caption, TableName))
                    {
                        strColumnsName += String.Format("[{0}],", m_dtTableData.Columns[i].Caption);
                        strValues += String.Format("@{0},", m_dtTableData.Columns[i].Caption);
                        //strValues += "N'" + getValidValue(dr, i) + "',";//;dr[i].ToString()
                    }
                }
                strColumnsName = strColumnsName.Substring(0, strColumnsName.Length - 1) + ") ";
                strValues = strValues.Substring(0, strValues.Length - 1) + ")";
                strRetVal = query + strColumnsName + strValues;
                // add parameters
                SqlCommand SqlCom = new SqlCommand(strRetVal, CN);
                string strParamName = string.Empty;
                for (int i = 0; i < m_dtTableData.Columns.Count; i++)
                {
                    if (isColumnOfTable(m_dtTableData.Columns[i].Caption, TableName))
                    {
                        strParamName = "@" + m_dtTableData.Columns[i].Caption;

                        SqlParameter paramAdd = new SqlParameter(strParamName, dr[i]);
                        switch (m_dtTableData.Columns[i].DataType.Name.ToLower())
                        {
                            case "byte[]":
                                paramAdd.DbType = DbType.Binary;
                                break;
                            default:
                                break;

                        }
                        //strValues += "N'" + getValidValue(dr, i) + "',";//;dr[i].ToString()
                        SqlCom.Parameters.Add(paramAdd);
                    }
                }
                CN.Open();
                SqlCom.ExecuteNonQuery();
                CN.Close();
            }
            private bool isColumnOfTable(string p, string tblN)
            {
                DataTable m_dtColumnsName_Org = DBEngine.execReturnDataTable("sp_TableEditor_Columns", "@Tablename", tblN);
                foreach (DataRow dr in m_dtColumnsName_Org.Rows)
                {
                    if (dr[0].ToString().ToLower().Equals(p.ToLower()))
                        return true;
                }
                return false;
            }
            private bool IsDupplication(DataRow dr, DataTable m_dtTableData, string TableName)
            {
                string strFilter = "";
                DataTable m_dtPrimaryKeys = DBEngine.execReturnDataTable("sp_TableEditor_GetPrimaryKeys", "@Tablename", TableName);
                foreach (DataRow drKeys in m_dtPrimaryKeys.Rows)
                {
                    if (drKeys[0].ToString().Equals("1"))
                        strFilter += String.Format("[{0}] = '{1}' and", drKeys[0], dr[drKeys[0].ToString()]);
                    else
                        return false;
                }
                strFilter = strFilter.Substring(0, strFilter.Length - 4);
                if (m_dtTableData.Select(strFilter).Length > 1)
                    return true;
                else
                    return false;
            }
    }
}
