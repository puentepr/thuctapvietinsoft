using HPA.Common;
using System;
using HPA.Component.Framework.Base;
namespace HPA.Common.Framework
{
	/// <summary>
	/// Summary description for CRunableObjectManager.
	/// </summary>
	public class CRunableObjectManager : IDatabase, ISecurity
	{
		#region CONSTRUCTOR & DESTRUCTOR
		#endregion
        //CuongVD
        #region CONST
        private const string TABLE_EDITOR = "HPA.MasterData.DataSetting";
        #endregion
        string strTableName = "";
        //EndCuongVD
		#region STATIC
		#endregion

		#region DELEGATES & EVENTS
		#endregion

		#region PROPERTIES
			public System.Windows.Forms.Form Parent
			{
				set {m_objParent = value;}
			}
		#endregion

		#region PUBLIC METHODS
            public virtual System.Windows.Forms.DialogResult OpenObject(string strAssemblyName, string strClassName, bool bIsModal, object objParamIn, out object objParamOut)
            {
                objParamOut = null;

                // standardize
                //strClassName = strClassName.ToUpper();
                //strAssemblyName = strAssemblyName.ToUpper();
                if ((strClassName.Length < strAssemblyName.Length) || (strClassName.Substring(0, strAssemblyName.Length).ToUpper() != strAssemblyName.ToUpper()))
                    strClassName = String.Format("{0}.{1}", strAssemblyName, strClassName);

                object objRight = DBEngine.execReturnValue("SC_USEROBJECTRIGHT_GET", "@p_FullClassName", strClassName, "@p_LoginID", this.UserID);
                if ((objRight == DBNull.Value) ||
                    (Convert.ToInt32(objRight) == 0))
                {
                    UIMessage.Alert(53);
                    return System.Windows.Forms.DialogResult.None;
                }
                m_nUserRights = objRight;

                // has the desired object runned already?
                foreach (IRunableObject ro in m_arrRunableObject)
                {
                    if ((ro.AssemblyName == strAssemblyName) && (ro.ClassName == strClassName) && (ro.ClassName != "HPA.TimeAttendance.ApprovalAttendanceData"))
                    {
                        // activate it
                        //ro.ActivateObject();
                        ro.Run(bIsModal);
                        return System.Windows.Forms.DialogResult.None;
                    }
                }

                // no desired object has runned before, so create new
                // activate to create new instance of the class in the target assembly
                try
                {
                    //CuongVD

                    if ("datasetting".Equals(strAssemblyName.ToLower()))
                    {
                        string[] strSPlit = strClassName.Split(new char[] { '.' });
                        if (strSPlit.Length > 0)
                            strTableName = strSPlit[strSPlit.Length - 1];
                        strAssemblyName = "HPA.MasterData";
                        strClassName = TABLE_EDITOR;
                    }
                    //End CuongVD
                    // create
                    System.Runtime.Remoting.ObjectHandle handle = Activator.CreateInstance(strAssemblyName, strClassName);
                    IRunableObject obj = (IRunableObject)(handle.Unwrap());

                    // open it
                    obj.AssemblyName = strAssemblyName;
                    obj.ClassName = strClassName;
                    return OpenObject(obj, bIsModal, objParamIn, out objParamOut);
                }
                catch (Exception e)
                {
                    Helper.ShowException(e, this.GetType().AssemblyQualifiedName, "OpenObject");
                    if (e.InnerException != null)
                        Helper.ShowException(e.InnerException, this.GetType().AssemblyQualifiedName, "OpenObject");

                    return System.Windows.Forms.DialogResult.None;
                }
            }

            public virtual System.Windows.Forms.DialogResult OpenObject(IRunableObject obj, bool bIsModal, object objParamIn, out object objParamOut)
            {
                // set up information
                if (!bIsModal)
                    obj.SetParent(m_objParent);

                obj.ObjectClosed += new ObjectClosedEventHandle(OnObjectClosed);
                obj.OpenObject = new OpenObjectFunction(this.OpenObject);
                obj.DBEngine = m_objDBEngine;
                obj.Permission = m_objPermission;
                obj.UserID = m_objUserID;
                //CuongVd
                if (TABLE_EDITOR.Equals(obj.ClassName))
                    obj.UserName = strTableName;
                else
                    obj.UserName = m_objUserName;
                obj.UserRights = m_nUserRights;
                //CuongVD
                // remmember & push this object at the top of the list
                m_arrRunableObject.Add(obj);

                // run the object
                obj.SetData(objParamIn);
                if ((!bIsModal) && (obj is System.Windows.Forms.Form))
                {
                    System.Windows.Forms.Form frm = (System.Windows.Forms.Form)obj;
                    frm.SizeChanged += new EventHandler(CRunableObjectManager_FormSizeChanged);
                    frm.MaximizeBox = false;
                    frm.MinimizeBox = false;
                    frm.ControlBox = false;
                }

                System.Windows.Forms.DialogResult dr = obj.Run(bIsModal);
                objParamOut = bIsModal ? obj.GetData() : null;
                return dr;
            }
		#endregion

		#region PROTECTED METHODS
		#endregion

		#region PRIVATE METHODS
		#endregion

		#region OVERRIDES
		#endregion

		#region VARIABLES
			protected System.Collections.ArrayList m_arrRunableObject = new System.Collections.ArrayList();
			protected System.Windows.Forms.Form m_objParent = null;
			protected object m_objUserID = null;
			protected object m_objUserName = null;
			protected object m_nUserRights = ESecurityRights.NORIGHT;

			protected IDatabaseEngine m_objDBEngine = null;

			protected IPermission m_objPermission = null;
		#endregion

		#region EVENT HANDLER
			private void OnObjectClosed(string strAssemblyName, string strClassName)
			{
				// standardize
				//strClassName = strClassName.ToUpper();
				//strAssemblyName = strAssemblyName.ToUpper();
                if ((strAssemblyName != null) && (strClassName != null))
                {
                    if ((strClassName.Length < strAssemblyName.Length) || (strClassName.Substring(0, strAssemblyName.Length).ToUpper() != strAssemblyName.ToUpper()))
                        strClassName = String.Format("{0}.{1}", strAssemblyName, strClassName);

                    // search & remove
                    foreach (IRunableObject ro in m_arrRunableObject)
                    {
                        if ((ro.AssemblyName == strAssemblyName) && (ro.ClassName == strClassName))
                        {
                            m_arrRunableObject.Remove(ro);
                            return;
                        }
                    }
                }
			}
		#endregion

		#region ISecurity Members
			public IPermission Permission
			{
				get {return m_objPermission;}
				set {m_objPermission = value;}
			}

			public object UserRights
			{
				get {return m_nUserRights;}
				set {m_nUserRights = value;}
			}

		#endregion

		#region ISecurityInfo Members
			public object UserName
			{
				get {return m_objUserName;}
				set {m_objUserName = value;}
			}

			public object UserID
			{
				get {return m_objUserID;}
				set {m_objUserID = value;}
			}

		#endregion

		#region IDatabase Members
			public IDatabaseEngine DBEngine
			{
				get {return m_objDBEngine;}
				set {m_objDBEngine = value;}
			}
		#endregion

		private void CRunableObjectManager_FormSizeChanged(object sender, EventArgs e)
		{
			((System.Windows.Forms.Form)sender).ControlBox = true;
		}
	}
}
