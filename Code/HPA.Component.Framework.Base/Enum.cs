using System;

namespace HPA.Component.Framework.Base
{
	#region Security
		/// <summary>
		/// Enumeration of security rights
		/// </summary>
		public enum ESecurityRights : ulong
		{
			NORIGHT = 0,
			VIEW = 1,
			ADD = 2,
			MODIFY = 4,
			DELETE = 8,
			SHARERIGHT = 16,
			ADMIN = 32
		}
	#endregion

	#region EActionState
		/// <summary>
		/// State of current runable object
		/// </summary>
		public enum EActionState
		{
			NORMAL,
			BUSY
		}
	#endregion
}


