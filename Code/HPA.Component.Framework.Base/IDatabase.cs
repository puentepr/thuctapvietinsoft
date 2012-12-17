using System;
using System.Data;

namespace HPA.Component.Framework.Base
{
	#region Database Support Interface - IDatabase
		public interface IDatabaseEngine
		{
			#region Method
				/// <summary>
				/// Open connection to database
				/// </summary>
				/// <param name="strConnectionstring">Connection string</param>
				void open();
				/// <summary>
				/// Close the existing connection
				/// </summary>
				void close();
				/// <summary>
				/// Begin transaction
				/// </summary>
				void beginTransaction();
				/// <summary>
				/// Rollback current transaction
				/// </summary>
				void rollback();
				/// <summary>
				/// Commit current transaction
				/// </summary>
				void commit();
				/// <summary>
				/// Execute a store procedure and return a value
				/// </summary>
				/// <param name="strStoreProcName">Store proc name</param>
				/// <param name="param">list of a pair of parameter name and value</param>
				/// <returns>returned value</returns>
                void exec(string strQuery);
                void exec(string StoredProcName, params object[] paramString);
				object execReturnValue(string StoredProcName, params object[] paramString);
				//OracleDataReader execReturnDataReader(string StoredProcName, params object[] paramString);
				DataTable execReturnDataTable(string StoredProcName, params object[] paramString);
                DataTable execReturnDataTable(string query);

                /// <summary>
                /// schema with key
                /// </summary>
                /// <param name="StoredProcName"></param>
                /// <param name="paramString"></param>
                /// <returns></returns>
                DataTable execReturnDataTable(bool withKey,string StoredProcName, params object[] paramString);
                
				DataSet execReturnDataSet(string StoredProcName, params object[] paramString);
            /// <summary>
            /// scheme with keys
            /// </summary>
            /// <param name="StoredProcName"></param>
            /// <param name="paramString"></param>
            /// <returns></returns>
            DataSet execReturnDataSet(bool withKey, string StoredProcName,params object[] paramString);
				object getParamValue(string strParamName);
				object getReturnValue();
			#endregion
			#region Property
				string StoreProcPrefix {set;}

				string ConnectionString {get;}				
				string DataSourceName {get;}
				string Server{get;}
				string Database {get;}
				string User {get;}
				string Password {get;}
			#endregion
		}
		public interface IDatabase
		{
			IDatabaseEngine DBEngine
			{
				set;
				get;
			}
		}
	#endregion

	#region CDatabase - basic implementation of IDatabase
		public class CDatabase : IDatabase
		{
			#region IDatabase Members
				public IDatabaseEngine DBEngine
				{
					get{return m_objDBEngine;}
					set{m_objDBEngine = value;}
				}
			#endregion

			#region Variable
				protected IDatabaseEngine m_objDBEngine = null;
			#endregion
		}
	#endregion
}
