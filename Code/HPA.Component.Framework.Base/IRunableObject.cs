using System;

namespace HPA.Component.Framework.Base
{
	#region IRunableObject - interface of IRunableObject
		public interface IRunableObject : IDatabase, ISecurity
		{
			#region Method
				/// <summary>
				/// Run this object (so-called runable-object)
				/// Revision:
				///		2003-12-30	created by TRAN VIET HA
				/// </summary>
				/// <param name="bIsModal">Show object in modal mode or not</param>
				/// <returns>Return value (in DialogResult format) of this object after stopped</returns>
				System.Windows.Forms.DialogResult Run(bool bIsModal);
				/// <summary>
				/// Stop this object forcely
				/// Revision:
				///		2003-12-30	created by TRAN VIET HA
				/// </summary>
				/// <returns>TRUE = successfully, otherwise FALSE</returns>
				bool Stop();
				/// <summary>
				/// Activate this object
				/// Revision:
				///		2003-12-30	created by TRAN VIET HA
				/// </summary>
				void ActivateObject();

				/// <summary>
				/// Revision:
				///		2003-12-30	created by TRAN VIET HA
				/// give start-up information to this object
				/// </summary>
				void SetData(object objParam);
				/// <summary>
				/// Revision:
				///		2003-12-30	created by TRAN VIET HA
				/// retrieve expected results
				/// </summary>
				/// <returns>expected results</returns>
				object GetData();

				/// <summary>
				/// Revision:
				///		2003-12-30	created by TRAN VIET HA
				/// Implement this method to allow or prevent stopping this object.
				/// </summary>
				/// <returns>TRUE = allow, otherwise = prevent</returns>
				bool CanClose();

				/// <summary>
				/// Set parent of this object in order to show a visible component
				/// Revision:
				///		2003-12-30	created by TRAN VIET HA
				/// </summary>
				/// <param name="objParent">Parent</param>
				/// <param name="bIsMDIChild">TRUE: set to MDIParent property, otherwise set to Parent property</param>
				void SetParent(System.Windows.Forms.Form objParent);
			#endregion

			#region Property
				/// <summary>
				/// AssemblyName & ClassName is self-described information of this runable object
				/// Revision:
				///		2003-12-30	created by TRAN VIET HA
				/// </summary>
				string AssemblyName {get;set;}
				string ClassName {get;set;}

				/// <summary>
				/// OpenObject is a delegation in order to help this object be able to open another
				/// The core engine is defined somewhere but this object can invoke it via this property.
				/// </summary>
				OpenObjectFunction OpenObject {set; get;}
			#endregion

			#region Event
				/// <summary>
				/// This runable object must call following event to notify others before closed (stopped).
				/// Revision:
				///		2003-12-30	created by TRAN VIET HA
				/// </summary>
				event ObjectClosedEventHandle ObjectClosed;
			#endregion
		}		
	#endregion

	#region CRunableObject - basic implementation of IRunableObject
		/// <summary>
		/// CRunableObject is basic class implementing IRunableObject.
		/// </summary>
		public abstract class CRunableObject : IRunableObject
		{
			#region IRunableObject Members
				public abstract System.Windows.Forms.DialogResult Run(bool bIsModal);

				public abstract bool Stop();

				public virtual void ActivateObject(){}

				public virtual void SetData(object objParam){}

				public virtual object GetData(){return null;}

				public virtual bool CanClose(){return true;}

				public abstract void SetParent(System.Windows.Forms.Form objParent);

				public string AssemblyName
				{
					get{return m_strAssemblyName;}
					set{m_strAssemblyName = value;}
				}

				public string ClassName
				{
					get{return m_strClassName;}
					set{m_strClassName = value;}
				}

				public HPA.Component.Framework.Base.OpenObjectFunction OpenObject
				{
					get{return m_fOpenObject;}
					set{m_fOpenObject = value;}
				}

				public event HPA.Component.Framework.Base.ObjectClosedEventHandle ObjectClosed;
			#endregion

			#region IDatabase Members
				public IDatabaseEngine DBEngine
				{
					get{return m_objDBEngine;}
					set{m_objDBEngine = value;}
				}
			#endregion

			#region ISecurity Members
				public object UserRights
				{
					get{return m_objUserRights;}
					set{m_objUserRights = value;}
				}

				public IPermission Permission
				{
					get{return m_objPermission;}
					set{m_objPermission = value;}
				}
			#endregion

			#region ISecurityInfo Members
				public object UserID
				{
					get{return m_objUserID;}
					set{m_objUserID = value;}
				}

				public object UserName
				{
					get{return m_objUserName;}
					set{m_objUserName = value;}
				}
			#endregion

			#region VARIABLE
				protected string m_strAssemblyName = null;
				protected string m_strClassName = null;
				protected HPA.Component.Framework.Base.OpenObjectFunction m_fOpenObject = null;
				protected IDatabaseEngine m_objDBEngine = null;
				protected object m_objUserRights = null;
				protected IPermission m_objPermission = null;
				protected object m_objUserID = null;
				protected object m_objUserName = null;
			#endregion
		}
	#endregion
}
