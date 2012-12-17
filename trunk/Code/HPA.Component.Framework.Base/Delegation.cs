using System;

namespace HPA.Component.Framework.Base
{
	#region Delegation
		public delegate void ObjectClosedEventHandle(string strAssemblyName, string strClassName);	
		public delegate System.Windows.Forms.DialogResult OpenObjectFunction(string strAssemblyName, string strClassName, bool bIsModal, object objParamIn, out object objParamOut);

//		public delegate void FormOpeningEventHandler(System.Windows.Forms.Form frm);
//		public delegate System.Windows.Forms.DialogResult FormOpeningEventHandler(string strAssemblyName, string strFormName, bool bIsModal, object objParamIn, out object objParamOut);
		//public delegate System.Windows.Forms.DialogResult FormOpeningEventHandler(System.Windows.Forms.Form frm);

//		/// <summary>
//		/// ShowStatusDescriptionEventHandler creates a mechanism to make this form able to show a description on the status bar of the main frame.
//		/// Call this when you want to display something on the status bar.
//		/// </summary>
//		public delegate void ShowStatusDescriptionEventHandler(string strDescription);
//
//		/// <summary>
//		/// SubFormOpened is an event raised when this form wants to open another form (called sub-form) which is also derived from CBaseForm.
//		/// This event handler creates the mechanism to notify the framework of the such actions.
//		/// </summary>
//		public delegate System.Windows.Forms.DialogResult OpenSubFormEventHandler(IBaseForm frmSubForm, bool bShowModal);
//
//		/// <summary>
//		/// FormClosed is an event raised when this form is assumed to close.
//		/// It has responsibility for notifying the framework the such actions.
//		/// </summary>
//		public delegate void CloseFormEventHandler();
	#endregion
}
