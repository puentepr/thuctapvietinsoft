using System;

namespace HPA.Component.Framework
{
	#region MESSAGE
    [Flags]
	public enum EFrameWorkMessage 
    {
		UNKNOWN_ERROR,	// unknown error
		SAVE_CONFIRM,	// Do you want to save changes?
		DELETE_CONFIRM,	// Do you really want to delete?
		CLOSE_CONFIRM,	// Do you want to close form?
		DISCARD_CONFIRM	// Do you want to discard changes?
	}
	#endregion
}
