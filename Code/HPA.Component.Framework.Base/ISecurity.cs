using System;

namespace HPA.Component.Framework.Base
{
	#region Security Info - ISecurityInfo
		public interface ISecurityInfo
		{
			object UserID
			{
				get;
				set;
			}

			object UserName
			{
				get;
				set;
			}
		}
	#endregion

	#region Security Support Interface	-	ISecurity
		/// <summary>
		/// ISecurity is an interface to specify rules to restrict user's actions.
		/// Revision
		///		2002-11-17	created by TRAN VIET HA
		///		2002-12-12	add property Rights. TRAN VIET HA
		///		2003-07-22	add Permission engine. TRAN VIET HA
		/// </summary>
		public interface ISecurity : ISecurityInfo
		{
			/// <summary>
			/// Property to get/set rights of a user
			/// </summary>
			object UserRights
			{
				get;
				set;
			}

			IPermission Permission
			{
				get;
				set;
			}
		}
	#endregion

	#region Permission engine - IPermission
		public interface IPermission : ISecurityInfo, ISecurityRights, IDatabase
		{
			#region Method				
				bool CanAccess(object objTarget);
				bool IsAccessRight(object objRights);
				bool CheckRight(object objRights, ESecurityRights esr);
			#endregion
		}

		public interface ISecurityRights
		{
			object GetRights(object objTarget);
		}
	#endregion

	#region Login interface - ILogin
		public interface ILogin : IDatabase, ISecurityInfo
		{
			#region Method
				bool Login();
				bool Logoff(object objUserID);
			#endregion
		}
	#endregion

	#region CSecurity
		public class CSecurity : ISecurity
		{
			#region Property
				public virtual object UserID
				{
					get{return m_objUserID;}
					set{m_objUserID = value;}
				}

				public virtual object UserName
				{
					get{return m_objUserName;}
					set{m_objUserName = value;}
				}

				public virtual object UserRights
				{
					get{return m_objUserRights;}
					set{m_objUserRights = value;}
				}

				public virtual IPermission Permission
				{
					get{return m_objPermission;}
					set{m_objPermission = value;}
				}
			#endregion

			#region Variable
				protected object m_objUserID = null;
				protected object m_objUserName = null;
				protected object m_objUserRights = null;
				protected IPermission m_objPermission = null;
			#endregion
		}
	#endregion
}
