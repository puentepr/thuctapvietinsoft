using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace HPA.SQL
{
    /// <summary>
    /// EzSql is  a class that ease the ADO. NET coding with MS SQL database.
    /// Most of the calls to storedproc can be wrapped in a single-line
    /// invocation.
    /// Below is a simple code portion demonstrates how to use this class:
    /// </summary>
    public class EzSql
    {
        #region Constructors.
        public EzSql()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public EzSql(string connectionString)
        {
            m_connectionString = connectionString;
        }
        #endregion
        #region Properties.
        /// <summary>
        /// Get or set the connection string. If the connection string is to be
        /// set, the current running connection will be closed first.
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return m_connectionString;
            }
            set
            {
                // TODO: close the running connection first.
                m_connectionString = value;
            }
        }

        /// <summary>
        /// Get the current connection. Read only.
        /// </summary>
        public SqlConnection Connection
        {
            get
            {
                return m_connection;
            }
            set
            {
                m_connection = value;
            }
        }

        public string Server
        {
            get
            {
                return m_connection.DataSource;
            }
        }

        public string Database
        {
            get
            {
                return m_connection.Database;
            }
        }

        public string User
        {
            get
            {
                return m_user;
            }
            set
            {
                m_user = value;
            }
        }

        public string Password
        {
            get
            {
                return m_password;
            }
            set
            {
                m_password = value;
            }
        }
        #endregion
        #region Common methods.
        /// <summary>
        /// Try to open the internal connection.
        /// </summary>
        public void Open()
        {
            // TODO: implement variou error checking.
            m_connection = new SqlConnection(m_connectionString);
            m_connection.Open();
        }

        /// <summary>
        /// Try to close the running connection.
        /// </summary>
        public void Close()
        {
            // TODO: implement variou error checking.
            m_connection.Close();
        }
        #endregion
        #region Queryxxxx methods.
        #endregion
        #region Executexxx methods.
        /// <summary>
        /// Executes a stored proc and returns nothing. If there's any output
        /// or return value, they can be retrieved using the GetParameterValue()
        /// or GetReturnValue() methods.
        /// Example:
        /// Exec("Foo",
        /// "ID", 1);
        /// "ID" is the name and 1 is the value of the desired parameter.
        /// </summary>
        /// <param name="spName">The storedproc name</param>
        /// <param name="inParams">List of input parameters.</param>
        public int ExecuteNonQuery(string spName, params object[] inParams)
        {
            // TODO: check connection state.
            // Get the input parameters.
            SqlParameter[] inputParams = GetInputParameters(inParams);

            // Retrieve the parameter list using the given storedproc name and
            // the wonderful SqlParamCache.
            SqlParameter[] actualParams = SqlParamCache.GetSpParameterSet(
                                            m_connection, spName, true);

            // Now, check if the given input parameters is valid or not.
            CheckInputParameters(inputParams, actualParams);

            // Now the input-parameters-problem was checked and done.
            InitCommand();

            m_command.CommandText = spName;
            m_command.CommandType = CommandType.StoredProcedure;

            PrepareCommandParameters(m_command, inputParams, actualParams);

            return m_command.ExecuteNonQuery();
        }

        /// <summary>
        /// Execute a storedproc and return a data reader.
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="inParams"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string spName, params object[] inParams)
        {
            // TODO: check connection state.
            // Get the input parameters.
            SqlParameter[] inputParams = GetInputParameters(inParams);

            // Retrieve the parameter list using the given storedproc name and
            // the wonderful SqlParamCache.
            SqlParameter[] actualParams = SqlParamCache.GetSpParameterSet(
                m_connection,
                spName, true);

            // Now, check if the given input parameters is valid or not.
            CheckInputParameters(inputParams, actualParams);

            // Now the input-parameters-problem was checked and done.
            InitCommand();

            m_command.CommandText = spName;
            m_command.CommandType = CommandType.StoredProcedure;

            PrepareCommandParameters(m_command, inputParams, actualParams);

            return m_command.ExecuteReader();
        }
        /// <summary>
        /// Executes a storedproc and returns a dataset.
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="inParams"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string spName, params object[] inParams)
        {
            // TODO: check connection state.
            // Get the input parameters.
            SqlParameter[] inputParams = GetInputParameters(inParams);

            // Retrieve the parameter list using the given storedproc name and
            // the wonderful SqlParamCache.
            SqlParameter[] actualParams = SqlParamCache.GetSpParameterSet(
                m_connection,
                spName, true);

            // Now, check if the given input parameters is valid or not.
            CheckInputParameters(inputParams, actualParams);

            // Now the input-parameters-problem was checked and done.
            InitCommand();

            m_command.CommandText = spName;
            m_command.CommandType = CommandType.StoredProcedure;

            PrepareCommandParameters(m_command, inputParams, actualParams);

            // Create a new dataset.
            SqlDataAdapter da = new SqlDataAdapter(m_command);
            DataSet ds = new DataSet();

            //fill the DataSet using default values for DataTable names, etc.
            da.Fill(ds);

            return ds;
        }
        /// <summary>
        /// Execute a storedproc and return a data adapter.
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="inParams array"></param>
        /// <returns>
        /// SqlDataAdapter
        /// </returns>
        /// Created by : Truong Hoang Uyen
        /// Date : Jun 04, 2003
        public SqlDataAdapter ExecuteAdapter(string spName, params object[] inParams)
        {
            // TODO: check connection state.
            // Get the input parameters.
            SqlParameter[] inputParams = GetInputParameters(inParams);

            // Retrieve the parameter list using the given storedproc name and
            // the wonderful SqlParamCache.
            SqlParameter[] actualParams = SqlParamCache.GetSpParameterSet(
                m_connection,
                spName, true);

            // Now, check if the given input parameters is valid or not.
            CheckInputParameters(inputParams, actualParams);

            // Now the input-parameters-problem was checked and done.
            InitCommand();

            m_command.CommandText = spName;
            m_command.CommandType = CommandType.StoredProcedure;
            m_command.CommandTimeout = 7200;
            PrepareCommandParameters(m_command, inputParams, actualParams);

            SqlDataAdapter da = new SqlDataAdapter(m_command);

            return da;
        }

        /// <summary>
        /// Executes a storedproc and returns a SqlDataTable.
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="inParams"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string spName, params object[] inParams)
        {
            // TODO: check connection state.
            // Get the input parameters.
            SqlParameter[] inputParams = GetInputParameters(inParams);

            // Retrieve the parameter list using the given storedproc name and
            // the wonderful SqlParamCache.
            SqlParameter[] actualParams = SqlParamCache.GetSpParameterSet(
                m_connection,
                spName, true);

            // Now, check if the given input parameters is valid or not.
            CheckInputParameters(inputParams, actualParams);

            // Now the input-parameters-problem was checked and done.
            InitCommand();

            m_command.CommandText = spName;
            m_command.CommandType = CommandType.StoredProcedure;

            PrepareCommandParameters(m_command, inputParams, actualParams);

            // Create a new dataset.
            SqlDataAdapter da = new SqlDataAdapter(m_command);
            DataSet ds = new DataSet();

            //fill the DataSet using default values for DataTable names, etc.
            da.Fill(ds);

            return ds.Tables[0];
        }
        #endregion
        #region Getxxx method
        /// <summary>
        /// Get the parameter value from the current command.
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public object GetParameterValue(string paramName)
        {
            return m_command.Parameters["@" + paramName].Value;
        }
        /// <summary>
        /// Return the return value from the current command.
        /// </summary>
        /// <returns></returns>
        public object GetReturnValue()
        {
            return m_command.Parameters["@RETURN_VALUE"].Value;
        }
        #endregion
        #region Private methods.
        /// <summary>
        /// Examines the given raw input parameters, and returns a array of
        /// SqlParameter objects. If no input parameters was found, return null.
        /// If the given raw input parameters is invalid, raise an exception.
        /// </summary>
        /// <param name="inParams"></param>
        /// <returns></returns>
        private SqlParameter[] GetInputParameters(params object[] inParams)
        {
            // Check the number of raw parameters. If this number is not even, then it's
            // invalid, since an cooked, ready to use parameter must be the combination of
            // two raw parameters: one for parameter's name, and one is the value.
            int inParamsCount = inParams.Length;

            if (inParamsCount == 0)
                return null;
            else
                if (inParamsCount % 2 == 1)
                    throw new EzSqlException("The number of raw input parameters is not even");
                else
                {
                    // Now, I have the pairs. Try to build the actual input
                    // parameters from them.
                    int paramsCount = inParamsCount / 2;

                    // First, populate the array of parameters.
                    SqlParameter[] sqlParams = new SqlParameter[paramsCount];
                    for (int n = 0; n < paramsCount; n++)
                    {
                        // Check the name first.
                        object temp = inParams[2 * n];
                        if ((temp == null) ||
                        (!(temp is string)) ||
                        (((string)temp).Trim().Length == 0))
                            throw new EzSqlException(String.Format("Parameter {0}'s name must be a string, and cannot be null or empty", n));
                        else
                        {
                            string name = ((string)temp).Trim();
                            object val = inParams[2 * n + 1];

                            // The name is valid, now create the parameter.
                            sqlParams[n] = new SqlParameter();
                            sqlParams[n].Direction = ParameterDirection.Input;
                            sqlParams[n].Size = 4000;// Stupid but efficient.
                            sqlParams[n].Value = val;

                            // Now the critical point: since SQL database support
                            // some data type that is not easy to map to a data
                            // type in C#, I allow caller to manually specify the
                            // desired database type right after the parameter name,
                            // separated by whitespace(s).
                            // First, try to split the name into two parts.
                            string[] instructor = name.Split(null, 2);
                            if (instructor.Length == 1)
                            {
                                // There's only one part. I will assume, reasonably,
                                // it's the parameter name. Then, I will just keep
                                // the name variable *as is*.
                                sqlParams[n].ParameterName = "@" + name;
                                // Since the manual data type is not specified, I
                                // will do the auto-determination.
                                if (val == null)
                                {
                                    // If null value was specified, throw an
                                    // exception, since I cannot determine the
                                    // data type from a null value.
                                    throw new EzSqlException("You cannot specify null for input parameter without manually specify the data type");
                                }
                                else
                                    if (val is DBNull)
                                    {
                                        // If database null value was specified, throw an
                                        // exception, since I cannot determine the
                                        // data type from a null value.
                                        throw new EzSqlException("You cannot specify DBNull.Value for input parameter without manually specify the data type");
                                    }
                                    else
                                        if (val is string)
                                        {
                                            sqlParams[n].SqlDbType = SqlDbType.NVarChar;
                                        }
                                        else
                                            if (val is int)
                                            {
                                                sqlParams[n].SqlDbType = SqlDbType.Int;
                                            }
                                            else
                                                if (val is float)
                                                {
                                                    sqlParams[n].SqlDbType = SqlDbType.Real;
                                                }
                                                else
                                                    if (val is double)
                                                    {
                                                        sqlParams[n].SqlDbType = SqlDbType.Float;
                                                    }
                                                    else
                                                    {
                                                        // Unsupported type? Throw an exception.
                                                        throw new EzSqlException(String.Format("The given input parameter's data type \"{0}\" is not supported.", val.GetType()));
                                                    }
                            }
                            else
                            {
                                // There're two parts. I'll take the first part as
                                // the parameter name.
                                sqlParams[n].ParameterName = "@" + instructor[0];

                                // Now, set up the data type manually.
                                switch (instructor[1].ToUpper())
                                {
                                    case "BIGINT":
                                        sqlParams[n].SqlDbType = SqlDbType.BigInt;
                                        break;
                                    case "BINARY":
                                        sqlParams[n].SqlDbType = SqlDbType.Binary;
                                        break;
                                    case "BIT":
                                        sqlParams[n].SqlDbType = SqlDbType.Bit;
                                        break;
                                    case "CHAR":
                                        sqlParams[n].SqlDbType = SqlDbType.Char;
                                        break;
                                    case "DATETIME":
                                        sqlParams[n].SqlDbType = SqlDbType.DateTime;
                                        break;
                                    case "DECIMAL":
                                        sqlParams[n].SqlDbType = SqlDbType.Decimal;
                                        break;
                                    case "FLOAT":
                                        sqlParams[n].SqlDbType = SqlDbType.Float;
                                        break;
                                    case "IMAGE":
                                        sqlParams[n].SqlDbType = SqlDbType.Image;
                                        break;
                                    case "INT":
                                        sqlParams[n].SqlDbType = SqlDbType.Int;
                                        break;
                                    case "MONEY":
                                        sqlParams[n].SqlDbType = SqlDbType.Money;
                                        break;
                                    case "NCHAR":
                                        sqlParams[n].SqlDbType = SqlDbType.NChar;
                                        break;
                                    case "NTEXT":
                                        sqlParams[n].SqlDbType = SqlDbType.NText;
                                        break;
                                    case "NVARCHAR":
                                        sqlParams[n].SqlDbType = SqlDbType.NVarChar;
                                        break;
                                    case "REAL":
                                        sqlParams[n].SqlDbType = SqlDbType.Real;
                                        break;
                                    case "SMALLDATETIME":
                                        sqlParams[n].SqlDbType = SqlDbType.SmallDateTime;
                                        break;
                                    case "SMALLINT":
                                        sqlParams[n].SqlDbType = SqlDbType.SmallInt;
                                        break;
                                    case "SMALLMONEY":
                                        sqlParams[n].SqlDbType = SqlDbType.SmallMoney;
                                        break;
                                    case "TEXT":
                                        sqlParams[n].SqlDbType = SqlDbType.Text;
                                        break;
                                    case "TIMESTAMP":
                                        sqlParams[n].SqlDbType = SqlDbType.Timestamp;
                                        break;
                                    case "TINYINT":
                                        sqlParams[n].SqlDbType = SqlDbType.TinyInt;
                                        break;
                                    case "UNIQUEINDENTIFIER":
                                        sqlParams[n].SqlDbType = SqlDbType.UniqueIdentifier;
                                        break;
                                    case "VARBINARY":
                                        sqlParams[n].SqlDbType = SqlDbType.VarBinary;
                                        break;
                                    case "VARCHAR":
                                        sqlParams[n].SqlDbType = SqlDbType.VarChar;
                                        break;
                                    case "VARIANT":
                                        sqlParams[n].SqlDbType = SqlDbType.Variant;
                                        break;
                                    default:
                                        throw new EzSqlException(String.Format("The manually specified data type \"{0}\" is not supported.", instructor[1]));
                                }
                            }

                            // Now the new parameter was properly created
                        }
                    }

                    // After all parameters were created properly, return the whole collection.
                    return sqlParams;
                }
        }

        /// <summary>
        /// Check the given input parameters, both in name and type. If just
        /// one of them is invalid, an exception will be raised.
        /// </summary>
        /// <param name="inParams"></param>
        /// <param name="actualParams"></param>
        private void CheckInputParameters(
            SqlParameter[] inParams,
            SqlParameter[] actualParams)
        {
            // If there's no given input parameter, thing is easy. If there's
            // any actual input parameter, you've got an exception!
            if (inParams == null)
            {
                foreach (SqlParameter p in actualParams)
                {
                    if (p.Direction == ParameterDirection.Input)
                        throw new EzSqlException("No input parameter was specified.");
                }
            }
            else
            {

                // Create a hash table which contains name & datatype of the given
                // input parameters. Then I can use it to check against the actual
                // input parameters.
                Hashtable givenInputHash = new Hashtable();

                foreach (SqlParameter p in inParams)
                {
                    givenInputHash.Add(p.ParameterName, p.SqlDbType);
                }

                // Get the number of given input parameters.
                int givenInputCount = inParams.Length;

                // From actualParams array, get only the input ones and check them.
                int actualInputCount = 0;
                foreach (SqlParameter p in actualParams)
                {
                    if (p.Direction == ParameterDirection.Input)
                    {
                        actualInputCount++;
                        // If the number of actual input parameters is greater than
                        // the given ones, the raise an exception.
                        if (actualInputCount > givenInputCount)
                            throw new EzSqlException("The number of given input parameter is less than the actual one.");
                        else
                        {
                            // Next, check if this actual name exist in the given collection.
                            if (!givenInputHash.Contains(p.ParameterName))
                                throw new EzSqlException(String.Format("The actual input parameter name {0} doesn't exist in the given ones.", p.ParameterName));
                            else
                            {
                                // Finally, check the datatype.
                                if ((SqlDbType)givenInputHash[p.ParameterName] != p.SqlDbType)
                                    throw new EzSqlException(String.Format("The given input parameter {0} has a mismatch data type. The actual data type is {1}.", p.ParameterName, p.SqlDbType));
                            }
                        }
                    }
                }

                // Now all the actual input parameter were checked and passed, I'm
                // gonna do the last strike: check if the numbers of given ones is
                // greater than the actual ones.
                if (actualInputCount < givenInputCount)
                    throw new EzSqlException("The number of actual input parameters is less than the given ones.");
            }

            // If everything is OK, just do nothing.
        }

        /// <summary>
        /// Intialize the internal m_command object.
        /// </summary>
        private void InitCommand()
        {
            if (m_command == null)
                m_command = new SqlCommand();

            m_command.Connection = m_connection;
            m_command.Parameters.Clear();
        }

        /// <summary>
        /// Prepare a SqlCommand object with the given parameters list.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="inParams"></param>
        /// <param name="actualParams"></param>
        private void PrepareCommandParameters(
            SqlCommand command,
            SqlParameter[] inParams,
            SqlParameter[] actualParams)
        {
            // Create a hashtable contains name and value of the given input parameters.
            Hashtable inValues = new Hashtable();

            // Fill the hash with input values.
            if (inParams != null)
            {
                foreach (SqlParameter p in inParams)
                    inValues.Add(
                        m_parameterIsCaseSensitive ? p.ParameterName : p.ParameterName.ToUpper(),
                        p.Value);
            }

            foreach (SqlParameter p in actualParams)
            {
                // Set input value.
                if (inValues.Contains(m_parameterIsCaseSensitive ? p.ParameterName : p.ParameterName.ToUpper()))
                {
                    p.Value = inValues[m_parameterIsCaseSensitive ? p.ParameterName : p.ParameterName.ToUpper()];
                    if (p.Value == null)
                        p.Value = DBNull.Value;
                }
                else
                    if (p.Direction == ParameterDirection.InputOutput ||
                    p.Value == null)
                        p.Value = DBNull.Value;

                command.Parameters.Add(p);
            }
        }
        #endregion
        #region Private data.
        private string m_connectionString = null;
        private SqlConnection m_connection = null;
        private SqlCommand m_command = null;
        private string m_user;
        private string m_password;

        // Options
        private bool m_parameterIsCaseSensitive = false;
        #endregion
    }
}
