using System;



namespace HPA.SQL
{

    /// <summary>
    /// Summary description for EzSqlException.
    /// </summary>
    public class EzSqlException : ApplicationException
    {
        #region Constructors
        public EzSqlException()
        {
            m_message = "Unspecified exception";
        }

        public EzSqlException(string message)
        {
            m_message = message;
        }
        #endregion

        #region Public methods & properties.
        public override string Message
        {
            get
            {
                return m_message;
            }
        }
        #endregion
        #region Private data.
        private string m_message;
        #endregion
    }
}