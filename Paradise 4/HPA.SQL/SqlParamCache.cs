using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace HPA.SQL
{
    /// <summary> 
    /// SqlParamCache provides functions to leverage a static cache of procedure
    /// parameters, and the ability to discover parameters for stored procedures
    /// at run-time.
    /// This is the modified - by me - version of SqlHelperParameterCache class
    /// from the Microsoft Data Access Application Block for .NET.
    /// </summary>
    public sealed class SqlParamCache
    {
        #region private methods, variables, and constructors

        //Since this class provides only static methods, make the default constructor private to prevent 
        //instances from being created with "new SqlParamCache()".
        private SqlParamCache()
        {
        }

        private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// [Modified by Uzi]
        /// resolve at run time the appropriate set of SqlParameters for a stored procedure
        /// </summary>
        /// <param name="connection">a valid, openned connection</param>
        /// <param name="spName">the name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">whether or not to include their return value parameter</param>
        /// <returns></returns>
        private static SqlParameter[] DiscoverSpParameterSet(SqlConnection connection, string spName, bool includeReturnValueParameter)
        {
            using (SqlCommand cmd = new SqlCommand(spName, connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlCommandBuilder.DeriveParameters(cmd);

                if (!includeReturnValueParameter)
                {
                    cmd.Parameters.RemoveAt(0);
                }

                SqlParameter[] discoveredParameters = new SqlParameter[cmd.Parameters.Count];
                ;

                cmd.Parameters.CopyTo(discoveredParameters, 0);

                return discoveredParameters;
            }
        }

        //deep copy of cached SqlParameter array
        private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
        {
            SqlParameter[] clonedParameters = new SqlParameter[originalParameters.Length];

            for (int i = 0, j = originalParameters.Length; i < j; i++)
            {
                clonedParameters[i] = (SqlParameter)((ICloneable)originalParameters[i]).Clone();
            }

            return clonedParameters;
        }

        #endregion private methods, variables, and constructors

        #region caching functions
        /// <summary>
        /// [Modified by Uzi]
        /// add parameter array to the cache.
        /// </summary>
        /// <param name="connection">a valid, openned connection</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters to be cached</param>
        public static void CacheParameterSet(SqlConnection connection, string commandText, params SqlParameter[] commandParameters)
        {
            string hashKey = String.Format("{0}:{1}", connection.ConnectionString, commandText);

            paramCache[hashKey] = commandParameters;
        }

        /// <summary>
        /// [Modified by Uzi]
        /// retrieve a parameter array from the cache
        /// </summary>
        /// <param name="connection">a valid, opnened connection</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <returns>an array of SqlParamters</returns>
        public static SqlParameter[] GetCachedParameterSet(SqlConnection connection, string commandText)
        {
            string hashKey = String.Format("{0}:{1}", connection.ConnectionString, commandText);

            SqlParameter[] cachedParameters = (SqlParameter[])paramCache[hashKey];
            if (cachedParameters == null)
            {
                return null;
            }
            else
            {
                return CloneParameters(cachedParameters);
            }
        }

        #endregion caching functions

        #region Parameter Discovery Functions

        /// <summary>
        /// [Modified by Uzi]
        /// Retrieves the set of SqlParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connection">a valid, opened connection string for a SqlConnection</param>
        /// <param name="spName">the name of the stored procedure</param>
        /// <returns>an array of SqlParameters</returns>
        public static SqlParameter[] GetSpParameterSet(SqlConnection connection, string spName)
        {
            return GetSpParameterSet(connection, spName, false);
        }

        /// <summary>
        /// [Modified by Uzi]
        /// Retrieves the set of SqlParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connection">a valid, opended connection string for a SqlConnection</param>
        /// <param name="spName">the name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">a bool value indicating whether the return value parameter should be included in the results</param>
        /// <returns>an array of SqlParameters</returns>
        public static SqlParameter[] GetSpParameterSet(SqlConnection connection, string spName, bool includeReturnValueParameter)
        {
            string hashKey = String.Format("{0}:{1}{2}", connection.ConnectionString, spName, (includeReturnValueParameter ? ":include ReturnValue Parameter" : ""));

            SqlParameter[] cachedParameters = (SqlParameter[])paramCache[hashKey];

            if (cachedParameters == null)
            {
                cachedParameters = (SqlParameter[])(paramCache[hashKey] = DiscoverSpParameterSet(connection, spName, includeReturnValueParameter));
            }
            return CloneParameters(cachedParameters);
        }

        #endregion Parameter Discovery Functions

    }
}
