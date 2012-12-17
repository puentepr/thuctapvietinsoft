using System;

namespace HPA.Component.Framework.Base
{
	#region ICommonForm - interface of CCommonForm
		/// <summary>
		/// ICommonForm is the inteface of CCommonForm.
		/// This interface create a unique way for communication.
		/// It defines some public methods covering the most common actions of an user-interactive form.
		/// That is:
		///		- Add something: masked by OnAdd() method
		///		- Delete something: masked by OnDelete() method
		///		- Save something: masked by OnSave() method
		///		- Validate before saving: masked by OnDelete() method
		///		- Initialize data once loading form: masked by InitializeData() method
		///		- Announce whether there are unsaved changes: masked by DirtyData() property
		///	Besides, it also provides some public flags to check permission to do something.
		///	Revision:
		///		2003-06-04	created by TRAN VIET HA
		/// </summary>	
		public interface ICommonForm : IBaseForm
		{
			#region Method
				/// <summary>
				/// InitializeData is where data of all necessary controls is initialized once loading form.
				/// </summary>
				/// <returns>TRUE if successfully, otherwise FALSE</returns>
				bool InitializeData();

				/// <summary>
				/// OnAdd is where we perform adding task.
				/// </summary>
				/// <returns>TRUE if successfully, otherwise FALSE</returns>
				bool OnAdd();

				/// <summary>
				/// Before saving, we need to validate data. OnValidate is to do so.
				/// </summary>
				/// <returns>TRUE if data is valid, otherwise FALSE</returns>
				bool OnValidate();

				/// <summary>
				/// OnSave is where we perform saving task
				/// </summary>
				/// <returns>TRUE if successfully, otherwise FALSE</returns>
				bool OnSave();

				/// <summary>
				/// OnDelete is where we perform deleting task
				/// </summary>
				/// <returns>TRUE if successfully, otherwise FALSE</returns>
				bool OnDelete();

				/// <summary>
				/// Reject all changes which have been made since the last commiting
				/// </summary>
				/// <returns>TRUE if successfully, otherwise FALSE</returns>
				bool OnReset();
			#endregion

			#region Property
				/// <summary>
				/// CanAdd gives a flag to determine whether someone is allowed to invoke OnAdd() method
				/// </summary>
				bool CanAdd
				{
					get;
				}


				/// <summary>
				/// CaSave gives a flag to determine whether someone is allowed to invoke OnSave() method
				/// </summary>
				bool CanSave
				{
					get;
				}


				/// <summary>
				/// CanDelete gives a flag to determine whether someone is allowed to invoke OnDelete() method
				/// </summary>
				bool CanDelete
				{
					get;
				}


				/// <summary>
				/// DirtyData is a flag to announce that whether we have unsaved changes or not
				/// </summary>
				bool DirtyData {get; set;}


				/// <summary>
				/// This property marks the state of the form
				/// </summary>
				EActionState ActionState {get; set;}
			#endregion
		}
	#endregion

	#region IMasterDetailForm - interface of CMasterDetailForm
		public interface IMasterDetailForm : ICommonForm
		{
			#region Property
				bool DirtyDetailData {get; set;}
			#endregion

			#region Method
				bool OnAddDetailData();
				bool OnValidateDetailData();
				bool OnSaveDetailData();
				bool OnDeleteDetailData();
			#endregion
		}
	#endregion
}
