using System;

namespace HPA.Component.Framework.Base
{
	///	<summary>
	///	Framework interface is to define all public methods & properties grouped into interfaces which are 
	///	crucial fundament of communicating together or between the framework of the system and other modules relying on.
	///	Most of interfaces in this namespace is used to make up a very important class: CBaseForm which is the base class of all form class in this system.
	///	Whenever a behavior relates with CBaseForm, please use, and only use, interfaces instead of CBaseForm.
	///	Revision	(yyyy-mm-dd)
	///		2002-11-14	created by Tran Viet Ha
	///		2002-12-12	upgrade ISecurity. Tran Viet Ha
	///		2003-12-30	redesigned by TRAN VIET HA. Promote IRunableObject to support not form only but other types also
	///	</summary>

	#region IFormID - Form Interface
		/// <summary>
		/// This inteface contains information to identify a form. It also provides some methods to make framework and the form understand mutually.
		///	Methods:
		///		CanClose:	return TRUE if the form can be closed, FALSE if otherwise to prevent the framework closing the form.
		///	Revision:
		///		2002-11-17	created by TRAN VIET HA
		///		2002-12-03	add method CanClose. TRAN VIET HA
		/// </summary>
		public interface IFormID
		{
			object ObjectID{get;}
		}
	#endregion

	#region IBaseForm - Form Interface
		/// <summary>
		/// This interface assembles all interfaces containing apart information of a base form in this system into a unique interface.
		/// This will be derived by class CBaseForm to expose all neccessary methods & properties.
		/// <br><br>
		/// Revision:<br>
		///		2002-11-14	created by Tran Viet Ha
		///		2002-12-16	add database support interface. Tran Viet Ha
		/// </summary>
		public interface IBaseForm : IRunableObject, IFormID
		{
			#region Event
			#endregion

			#region Method
			#endregion

			#region Property
			#endregion
		}
	#endregion	
}