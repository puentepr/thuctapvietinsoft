using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Xml;



namespace EzSqlCollection
{
    public class EzSql2// : HPA.Component.Framework.Base.IDatabaseEngine
	{
		#region Version 1 support.
		/// ====================================================================
		/// This section maintain compatibility with version 1.
		/// ====================================================================
		#endregion
		#region Constructors.
		/// ====================================================================
		/// Constructors.
		/// ====================================================================
		public EzSql2()
		{
			setupSqlTypeMap();
		}
		
		public EzSql2
			(string server
			,string db
			,string user
			,string pwd)
		{
			setupSqlTypeMap();

			_server = server;
			_db = db;
			_user = user;
			_pwd = pwd;
		}
		public EzSql2(string DataSourceName, string User, string Password)
		{
			setupSqlTypeMap();

			_DataSourceName = DataSourceName;
			_user = User;
			_pwd = Password;						
		}
		#endregion
		#region Properties.
		/// Returns a reference to the internal connection object.
        public SqlConnection Connection { get { return _connection; } set { _connection = value; } }
		/// Returns a reference to the internal transaction object.
		public SqlTransaction Transaction{get{return _transaction;}}
		public string Server{get{return _server;} set{_server = value;}}
		public string Database{get{return _db;} set{_db = value;}}
		public string User{get{return _user;} set{_user = value;}}
		public string Password{get{return _pwd;} set{_pwd = value;}}
		public string ParamPrefix{get{return _op_param_prefix;} set{_op_param_prefix = value;}}
		public string StoreProcPrefix{get{return _op_sp_prefix;} set{_op_sp_prefix = value;}}
		public string ConnectionString
		{
			get{return _strConnection;}
			set{_strConnection = value;}
		}
		public string DataSourceName
		{
			get{return _DataSourceName;}
			//set{m_DataSourceName = value;}
		}
		#endregion
		#region Public methods.
		/// ====================================================================
		/// Public methods.
		/// ====================================================================
		/// Clear the internal cache.
		public void clearCache()
		{
			_dbTypes.Clear();
			_spParams.Clear();
		}
		/// Opens a new connection using the given parameters.
		/// This method throw an exception if it failed to open a new
		/// connection or the internal connection is already openned.
		public void open()
		{
			if (!isConnectionClosed()) _connection.Close();
            _strConnection = String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3}", _server, _db, _user, _pwd);
            //_strConnection = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\WINDOWS\Paradise_Free.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";

			
			_connection = new SqlConnection(_strConnection);
			_connection.Open();
			_transaction = null;
		}
		/// Closes the current connection.
		/// This method will throw an exception if the internal connection
		/// cannot be closed, due to database or driver failure.
		public void close()
		{
			if (!isConnectionClosed())
			{
				_connection.Close();
				_connection = null;
				_transaction = null;
			}
		}
		/// Begin a new transaction.
		/// This method will throw an exception in case of failure.
		public void beginTransaction()
		{
			if (!isConnectionOpen()) throwRequireConnection("beginTransacaction()");
			else _transaction = _connection.BeginTransaction();
		}
		/// Commit the current transaction.
		/// This method will throw an exception in case of failure.
		public void commit()
		{
			if (!isConnectionOpen()) throwRequireConnection("commit()");
			else if (!isWithinTransaction()) throwRequireTransaction("commit()");
			else
			{
				try
				{
					_transaction.Commit();
					_transaction = null;
				}
				catch (SqlException e)
				{
					// Mismatch number of transaction bounds?
					if (e.Number == 3902)
					{
						// Ignore!
						_transaction = null;
					}
					else
					{
						// Throw others.
						throw e;
					}
				}
			}
		}
		/// Rollback the current transaction.
		/// This method will throw an exception in case of failure.
		public void rollback()
		{
			if (!isConnectionOpen()) throwRequireConnection("rollback()");
			else if (!isWithinTransaction()) throwRequireTransaction("rollback()");
			else
			{
				try
				{
					_transaction.Rollback();
					_transaction = null;
				}
				catch (SqlException e)
				{
					// Mismatch number of transaction bounds?
					if (e.Number == 3903)
					{
						// Ignore!
						_transaction = null;
					}
					else
					{
						// Throw others.
						throw e;
					}
				}			
			}
		}
		/// Executes a SP, and returns nothing.
		/// This method will throw an exception if it failed to execute the given SP
		/// due to any reason.
		/// @sp: the SP name.
		/// @args: the parameters indicators array (see USAGE section).
		public void exec(string sp, params object[] args)
		{
			SqlCommand cmd = prepareSPCommand(sp, args);
			cmd.ExecuteNonQuery();
			storeParamsFromCmd(cmd);
		}
        public void exec(string strQuery)
        {
            SqlCommand cmd = new SqlCommand(strQuery, _connection, _transaction) { CommandType = CommandType.Text };
            cmd.ExecuteNonQuery();
            storeParamsFromCmd(cmd);
        }
		/// Executes a SP, and returns an arbitrary value.
		/// This method will throw an exception if it failed to execute the given SP
		/// due to any reason.
		/// @sp: the SP name.
		/// @args: the parameters indicators array (see USAGE section).
		public object execReturnValue(string sp, params object[] args)
		{
			SqlCommand cmd = prepareSPCommand(sp, args);
			cmd.ExecuteNonQuery();
			storeParamsFromCmd(cmd);
			return getReturnValue();
		}
		/// Executes a SP, and returns a SQL data reader.
		/// This method will throw an exception if it failed to execute the given SP
		/// due to any reason.
		/// @sp: the SP name (case-insensitive)
		/// @args: the parameters indicators array (see USAGE section).
		/// @returns a SqlDataReader object.
		public SqlDataReader execReturnDataReader(string sp, params object[] args)
		{
			SqlCommand cmd = prepareSPCommand(sp, args);
			SqlDataReader dr = cmd.ExecuteReader();
			storeParamsFromCmd(cmd);
			return dr;
		}
		/// Executes a SP, and returns a data table.
		/// This method will throw an exception if it failed to execute the given SP
		/// due to any reason.
		/// @sp: the SP name (case-insensitive)
		/// @args: the parameters indicators array (see USAGE section).
		/// @returns a DataTable object.
		public DataTable execReturnDataTable(string sp, params object[] args)
		{
			DataSet ds = execReturnDataSet(sp, args);
			if (ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}
        public DataTable execReturnDataTable(string query)
        {
            SqlCommand cmd = new SqlCommand(query, _connection, _transaction) { CommandType = CommandType.Text };
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }
		/// Executes a SP, and returns a data set.
		/// This method will throw an exception if it failed to execute the given SP
		/// due to any reason.
		/// @sp: the SP name (case-insensitive)
		/// @args: the parameters indicators array (see USAGE section).
		/// @returns a DataSet object.
		public DataSet execReturnDataSet(string sp, params object[] args)
		{
			SqlCommand cmd = prepareSPCommand(sp, args);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			storeParamsFromCmd(cmd);
			return ds;
		}
        /// <summary>
        /// da.MissingSchemaAction = MissingSchemaAction.AddWithKey; To get maxlength of DataColumn and some others properties
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public DataTable execReturnDataTable(bool actionWithKey,string sp,  params object[] args)
        {
            DataSet ds = execReturnDataSet(actionWithKey,sp, args);
            if (ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }
        /// <summary>
        /// da.MissingSchemaAction = MissingSchemaAction.AddWithKey; To get maxlength of DataColumn and some others properties
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="actionWithKey"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public DataSet execReturnDataSet(bool actionWithKey,string sp,  params object[] args)
        {
            SqlCommand cmd = prepareSPCommand(sp, args);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            if(actionWithKey)
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(ds);
            storeParamsFromCmd(cmd);
            return ds;
        }
		/// Get a parameter's value from the last execution.
		/// This method get a parameter's value from the last execution, thru the
		/// parameter's name.
		/// *** Note that the parameters information will be overwritten each time
		/// an execution takes place.
		/// @paramName: the parameter's name.
		/// @returns the parameter's value.
		public object getParamValue(string paramName)
		{
			paramName = _op_param_prefix + paramName;
			if (!_op_case_sensitive)
				paramName = paramName.ToLower();
			if (_outputParams.Contains(paramName))
				return _outputParams[paramName];
			else
                throw new Exception(String.Format("EzSql2.getParamValue() couldn't find any parameter named {0}.", paramName));
		}
		/// Get the return value from the last execution.
		/// This method get the return value from the last execution.
		/// *** Note that the parameters information will be overwritten each time
		/// an execution takes place.
		/// @returns the last execution return value.
		public object getReturnValue()
		{
			string retValParamName = "@RETURN_VALUE";
			
			if (!_op_case_sensitive)
				retValParamName = retValParamName.ToLower();
			if (_outputParams.Contains(retValParamName))
				return _outputParams[retValParamName];
			else
				throw new Exception("EzSql2.getParamValue() couldn't find any return value from the last command.");
		}
		#endregion
		#region Protected methods.
		/// ====================================================================
		/// Protected methods.
		/// ====================================================================
		/// Returns a SqlCommand object which uses the internal connection &
		/// transaction and will be used to execute a SP.
		/// @sp: the SP name.
		/// @args: the indicators.
		/// @returns the prepared SqlCommand object.
		protected SqlCommand prepareSPCommand(string sp, params object[] args)
		{
			if (!_op_case_sensitive)
				sp = sp.ToLower();
            SqlCommand cmd = new SqlCommand(_op_sp_prefix + sp, _connection, _transaction) { CommandType = CommandType.StoredProcedure, CommandTimeout = 7200 };
			setParamsToCmd(ref cmd, args);
			return cmd;
		}
		/// Set up a SqlCommand object with proper parameters.
		/// @cmd: a SqlCommand object.
		/// @args: an array of parameters indicators.
		/// @output cmd as a well syncronized SqlParameter objects array, which
		/// is ready to be fed into a SqlCommand object.
		protected void setParamsToCmd(ref SqlCommand cmd, params object[] args)
		{
			// Modified by Pham Manh Hung
			// Date: July 18 2006
			// Purpose: Toi loi
			// Clear the cmd's parameters collection.
			cmd.Parameters.Clear();
			// At least set the return parameter.
            SqlParameter retParam = new SqlParameter() { ParameterName = "@RETURN_VALUE", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.ReturnValue };
			cmd.Parameters.Add(retParam);
			// Then add manually indicated parameters.
			SqlParameter[] inds = getIndicators(cmd.CommandText, args);
			foreach (SqlParameter p in inds)
				cmd.Parameters.Add(p);
			// And at last, the missing parameters, if _op_auto_param is on.
			if (_op_auto_param)
			{
				Hashtable spParams = getSPParams(cmd.CommandText);
				foreach (string paramName in spParams.Keys)
				{
					if (!cmd.Parameters.Contains(paramName))
						cmd.Parameters.Add((SqlParameter)spParams[paramName]);
					else if (_op_correct_param)
					{
						cmd.Parameters[paramName].ParameterName = ((SqlParameter)spParams[paramName]).ParameterName;
					}
				}
			}
		}
		/// Retrieve the parameters from the given SqlCommand object and store
		/// them into internal structure. Only the output parameters are used.
		/// @cmd: the SqlCommand object.
		protected void storeParamsFromCmd(SqlCommand cmd)
		{
			_outputParams.Clear();
			foreach (SqlParameter p in cmd.Parameters)
			{
				if (p.Direction != ParameterDirection.Input)
				{
					if (!_op_case_sensitive)
						_outputParams[p.ParameterName.ToLower()] = p.Value;
					else
						_outputParams[p.ParameterName] = p.Value;
				}
			}
			cmd.Parameters.Clear();
		}
		/// Parse an indicator and return a structure with refined elements set.
		/// @sp: the SP name. If _op_auto_param is on, this method will check with
		/// the runtime parameters list.
		/// @ind: the indicator string.
		/// @paramValue: the intended parameter's value.
		/// 
		/// USAGE:
		///		An indicator consists of from 1 to 3 components: parameter name
		///	(required), data type (optional), parameter size (optional). These
		///	components are separated by whitespace(s).
		///		- Parameter name MUST not be prefixed by anything.
		///		- Parameter size MUST be prefixed by a '#' sign.
		///		- Parameter data type MUST be prefixed by a '%' sign.
		///		Data type must be an existing SQL Server data type, including
		///		user-defined if _op_auto_param is on. If _op_auto_param is off,
		///		then only builtin data types are allowed.
		///		
		///		Thus, a fully qualified indicator should look like this:
		///			"UserName %nvarchar #30"
		///		
		///		The order of these component are not restricted.
		protected SqlParameter parseIndicator(string sp, string ind, object paramValue)
		{
			// TODO: parse this indicator.
			string[] comps = ind.Split(null);
			string paramName = null;
			string paramType = null;
			string paramSize = null;
			SqlParameter p = null;

			for (int i = 0; i < comps.Length; i++)
			{
				if (comps[i] != null && comps[i].Length > 0)
				{
					switch (comps[i][0])
					{
						case '%':
							paramType = comps[i].Substring(1);
							break;
						case '#':
							paramSize = comps[i].Substring(1);
							break;
						default:
							paramName = comps[i];
							break;
					}
				}
			}

			if (paramName == null)
                throw new Exception(String.Format("EzSql2.parseIndicator() didn't find any parameter name from this indicator \"{0}\". Did you forget the '@' sign before the parameter name?", ind));

			// At least the parameter name was found. Create a new SqlParameter
			// object and assign its name and value.
			p = new SqlParameter();
			paramName = _op_param_prefix + paramName;
			if (!_op_case_sensitive)
				paramName = paramName.ToLower();
			p.ParameterName = paramName;
			// Automatically convert null value to DBNull.Value.
            p.Value = paramValue ?? DBNull.Value;
			
			// If _op_auto_param is on, then the parameter type and size will be set
			// automatically from database.
			if (_op_auto_param)
			{
				Hashtable spParams = getSPParams(sp);
				if (!_op_case_sensitive)
					paramName = paramName.ToLower();

				if (!spParams.Contains(paramName))
                    throw new Exception(String.Format("EzSql2.parseIndicator() found out that the parameter named {0} doesn't exist.", paramName));
				p.SqlDbType = ((SqlParameter)spParams[paramName]).SqlDbType;
				if (p.SqlDbType != SqlDbType.Image && p.SqlDbType != SqlDbType.Binary )
					p.Size = ((SqlParameter)spParams[paramName]).Size;
			}
			else
			{
				// _op_auto_param is off? Then parameter type is required.
				if (paramType == null)
                    throw new Exception(String.Format("EzSql2.parseIndicator() didn't find any parameter data type from this indicator \"{0}\".  Did you forget the '%' sign before the parameter type? Or you may turn _op_auto_param on to have EzSql automatically set parameter type for you.", ind));
				else
					p.SqlDbType = getSqlDbType(paramType);
				// The size is optional for some case, and is required for others.
				if (p.SqlDbType == SqlDbType.Binary
					|| p.SqlDbType == SqlDbType.NChar
					|| p.SqlDbType == SqlDbType.NText
					|| p.SqlDbType == SqlDbType.NVarChar
					|| p.SqlDbType == SqlDbType.VarBinary
					|| p.SqlDbType == SqlDbType.VarChar)
				{
					if (paramSize == null)
                        throw new Exception(String.Format("EzSql2.parseIndicator() didn't find any parameter data size from this indicator \"{0}\".  Did you forget the '#' sign before the parameter size?. Or you may turn _op_auto_param on to have EzSql automatically set parameter size for you.", ind));
					else
						p.Size = Convert.ToInt32(paramSize);
				}
			}

			return p;
		}
		/// Parse the given indicators and returns an array of refined
		/// SqlParameter structures.
		/// @sp: the SP name.
		/// @args: the indicators array.
		protected SqlParameter[] getIndicators(string sp, params object[] args)
		{
			// Lots of validations...
			if (args == null)
				return null;
			// args must have a length that is even.
			if (args.Length % 2 != 0)
				throw new Exception("EzSql2.getIndicators() requires an even number of arguments.");
			// Create an array of SqlParameter structures.
			SqlParameter[] inds = new SqlParameter[args.Length / 2];		
			for (int i = 0; i < args.Length; i += 2)
			{
				if (args[i] == null)
                    throw new Exception(String.Format("EzSql2.getInParams() expected an instructor string at postion {0} but null value was found.", i));
				if (!(args[i] is string))
                    throw new Exception(String.Format("EzSql2.getInParams() expected an instructor string at postion {0} but {1} was found.", i, args[i].GetType()));
				inds[i / 2] = parseIndicator(sp, args[i].ToString(), args[i + 1]);
			}
			return inds;
		}
		/// Returns the SqlDbType which maps to the given data type string.
		/// @typeName: the type name (case-insensitive).
		/// @returns a SqlDbType value.
		protected SqlDbType getSqlDbType(string typeName)
		{
			typeName = typeName.ToLower();

			if (_sqlTypeMap.Contains(typeName))
				return (SqlDbType)_sqlTypeMap[typeName];
			else if ((_op_cache_type) && _dbTypes.Contains(typeName))
				return (SqlDbType)_dbTypes[typeName];
			else
			{
				// Get the type from database.
				// Use sp_help SP to fetch information.
                SqlCommand cmd = new SqlCommand("sp_help", Connection, Transaction) { CommandType = CommandType.StoredProcedure };
				cmd.Parameters.AddWithValue("@objname", typeName);
				DataSet ds = new DataSet();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(ds);

				if (!ds.Tables[0].Columns.Contains("Type_name"))
                    throw new Exception(String.Format("EzSql2.getSqlDbType() discovered that {0} is not a data type name.", typeName));
				else
				{
					string physicalTypeName = ds.Tables[0].Rows[0]["Storage_type"].ToString().ToLower();
					SqlDbType foundType = (SqlDbType)_sqlTypeMap[physicalTypeName];
					if ((_op_cache_type) && (!_dbTypes.Contains(typeName)))
						_dbTypes[typeName] = foundType;
					return foundType;
				}
			}
		}
		/// Get SP parameters information from database.
		/// @sp: the SP name. See _op_case_sensitive.
		/// @returns an hash table of SqlParameter objects that correspondes to the
		/// SP parameters information. Keys of this table are the parameter name.
		/// These keys are case-sensitive or not depends on the _op_case_sensitive.
		protected Hashtable getSPParams(string sp)
		{
			// Use this SQL statement to retrieve a SP parameters information.
			// SELECT a.name, a.length, type_name(c.xtype) storage_type, a.isoutparam
			// FROM syscolumns a, sysobjects b, systypes c
			// WHERE (  a.id = b.id
			//			AND b.name = 'sp_name'
			//			AND b.type = 'P'
			//			AND a.xtype = c.xtype)
			if (_op_cache_param && _spParams.Contains(sp))
				return (Hashtable)_spParams[sp];

			SqlDataReader dr = null;
			
			// Check this SP existence.
			string sqlChkCmd;
			if (_op_case_sensitive)
                sqlChkCmd = String.Format("SELECT * FROM sysobjects WHERE name = '{0}' AND type = 'P'", sp);
			else
				// Since sp (the SP name) was lowered before getting to this point,
				// we only need to lower the name field.
                sqlChkCmd = String.Format("SELECT * FROM sysobjects WHERE LOWER(name) = '{0}' AND type = 'P'", sp);

			SqlCommand checkCmd = new SqlCommand(sqlChkCmd, Connection, Transaction);

			dr = checkCmd.ExecuteReader();
			bool exists = false;
			while (dr.Read())
			{
				exists = true;
			}
			dr.Close();

			if (!exists)
                throw new Exception(String.Format("EzSql2.getSPParams() found no stored procedure named {0}.", sp));


			// Now, get information from database.
			string sqlCmd;
			if (_op_case_sensitive)
                sqlCmd = String.Format("SELECT a.name, a.length, type_name(a.xtype) storage_type, a.isoutparam FROM syscolumns a, sysobjects b WHERE (	b.name = '{0}' AND b.type = 'P' AND a.id = b.id) ", sp);
			else
				// Since sp (the SP name) was lowered before getting to this point,
				// we only need to lower the name field.
                sqlCmd = String.Format("SELECT a.name, a.length, type_name(a.xtype) storage_type, a.isoutparam FROM syscolumns a, sysobjects b WHERE (LOWER(b.name) = '{0}' AND b.type = 'P' AND a.id = b.id) ", sp);

			SqlCommand cmd = new SqlCommand(sqlCmd, Connection, Transaction);
			try
			{
				dr = cmd.ExecuteReader();
				if (dr != null)
				{
					Hashtable spParams = new Hashtable();
					while (dr.Read())
					{
                        SqlParameter p = new SqlParameter() { ParameterName = Convert.ToString(dr["name"]), SqlDbType = getSqlDbType(Convert.ToString(dr["storage_type"])), Direction = Convert.ToInt32(dr["isoutparam"]) == 1 ? ParameterDirection.Output : ParameterDirection.Input, Size = Convert.ToInt32(dr["length"]) };

						if (!_op_case_sensitive)
							spParams[p.ParameterName.ToLower()] = p;
						else
							spParams[p.ParameterName] = p;

					}

					dr.Close();

					if (_op_cache_param)
						_spParams[sp] = spParams;

					return spParams;
				}
				else
					return null;
			}
			catch (Exception e)
			{
				if (dr != null) dr.Close();
                throw new Exception(String.Format("EzSql2.getSPParams() couldn't get parameters information for {0}.\r\n{1}", sp, e.Message));
			}
		}
		/// Set up built-in SQL Server data type map.
		/// NOTE that all keys are lower cased.
		private void setupSqlTypeMap()
		{
			_sqlTypeMap["bigint"] = SqlDbType.BigInt;
			_sqlTypeMap["binary"] = SqlDbType.Binary;
			_sqlTypeMap["bit"] = SqlDbType.Bit;
			_sqlTypeMap["char"] = SqlDbType.Char;
			_sqlTypeMap["datetime"] = SqlDbType.DateTime;
			_sqlTypeMap["decimal"] = SqlDbType.Decimal;
			_sqlTypeMap["float"] = SqlDbType.Float;
			_sqlTypeMap["image"] = SqlDbType.Image;
			_sqlTypeMap["int"] = SqlDbType.Int;
			_sqlTypeMap["money"] = SqlDbType.Money;
			_sqlTypeMap["nchar"] = SqlDbType.NChar;
			_sqlTypeMap["ntext"] = SqlDbType.NText;
			_sqlTypeMap["nvarchar"] = SqlDbType.NVarChar;
			_sqlTypeMap["real"] = SqlDbType.Real;
			_sqlTypeMap["smalldatetime"] = SqlDbType.SmallDateTime;
			_sqlTypeMap["smallint"] = SqlDbType.SmallInt;
			_sqlTypeMap["smallmoney"] = SqlDbType.SmallMoney;
			_sqlTypeMap["text"] = SqlDbType.Text;
			_sqlTypeMap["timestamp"] = SqlDbType.Timestamp;
			_sqlTypeMap["tinyint"] = SqlDbType.TinyInt;
			_sqlTypeMap["uniqueindentifier"] = SqlDbType.UniqueIdentifier;
			_sqlTypeMap["varbinary"] = SqlDbType.VarBinary;
			_sqlTypeMap["varchar"] = SqlDbType.VarChar;
			_sqlTypeMap["variant"] = SqlDbType.Variant;
		}
		#endregion
		#region Private methods.
		/// ====================================================================
		/// Private methods.
		/// ====================================================================
		/// Check if the internal connection is open.
		private bool isConnectionOpen()
		{
			if (_connection != null
				&& _connection.State == ConnectionState.Open)
				return true;
			else
				return false;
		}
		/// Check if the internal connection is closed.
		private bool isConnectionClosed()
		{
			if (_connection == null
				|| _connection.State == ConnectionState.Closed)
				return true;
			else
				return false;
		}
		/// Check if a running transaction is taking place.
		private bool isWithinTransaction(){return _transaction != null;}
		/// Throw an exception telling that the last code required an open
		/// connection which was not available.
		/// @src: the source name (normally a method name) which caused the
		/// exception.
		#endregion

        #region

        #endregion

        #region Exception throwers.
        /// ====================================================================
		/// Exception thrower.
		/// ====================================================================
		private void throwRequireConnection(string src)
		{
            throw new Exception(String.Format("EzSql2.{0} requires an open connection.", src));
		}
		/// Throw an exception telling that the last code required an closed
		/// or uninitalized connection which was not available.
		/// @src: the source name (normally a method name) which caused the
		/// exception.
		private void throwDenyConnection(string src)
		{
            throw new Exception(String.Format("EzSql2.{0} requires that the current internal connection must be null or closed.", src));
		}
		/// Throw an exception telling that the last code required a running
		/// transaction, which was not available.
		/// @src: the source name (normally a method name) which caused the
		/// exception.
		private void throwRequireTransaction(string src)
		{
            throw new Exception(String.Format("EzSql2.{0} requires a running transaction.", src));
		}
		/// Throw an exception telling that the last code required that no
		/// transaction exists at the time, which was not true.
		/// @src: the source name (normally a method name) which caused the
		/// exception.
		private void throwDenyTransaction(string src)
		{
            throw new Exception(String.Format("EzSql2.{0} requires that no running transaction exists at the time.", src));
		}
		#endregion
		#region Member structure.
		/// ====================================================================
		/// Member structure.
		/// ====================================================================
		#endregion
		#region Member data.
		/// ====================================================================
		/// Member data.
		/// ====================================================================
		// Connection parameters.
		private string _server;
		private string _db;
		private string _user;
		private string _pwd;
		private string _strConnection;
		private string _DataSourceName;
		// The connection object.
		private SqlConnection _connection;
		// The transaction object.
		private SqlTransaction _transaction;
		// The output parameters values (including the return value).
		private Hashtable _outputParams = new Hashtable();
		// The SQL Server to SqlDbType map table.
		private Hashtable _sqlTypeMap = new Hashtable();
		// The data type hash table.
		private Hashtable _dbTypes = new Hashtable();
		// The stored procedure parameter inforamtion hash table.
		private Hashtable _spParams = new Hashtable();
		#endregion
		#region Options.
		/// ====================================================================
		/// Instance options.
		/// ====================================================================
		private bool _op_case_sensitive = false;
		private bool _op_auto_param = true;
		private bool _op_cache_param = true;
		private bool _op_cache_type = true;
		private bool _op_correct_param = true;
		private string _op_param_prefix = "";
		private string _op_sp_prefix = "";	

		#endregion
	}
}
