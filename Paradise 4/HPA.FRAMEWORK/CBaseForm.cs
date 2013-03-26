using System;
using System.ComponentModel;
using System.Windows.Forms;
using HPA.Component.Framework.Base;



namespace HPA.Component.Framework
{
    public class CBaseForm : DevExpress.XtraEditors.XtraForm, IBaseForm
	{
		#region CONSTRUCTOR & DESTRUCTOR
        //private SkinEngine se;
			public CBaseForm()
			{
				// This call is required by the Windows Form Designer.
				InitializeComponent();

				// TODO: Add any initialization after the InitializeComponent call
                //se = new SkinEngine();
                //se.SerialNumber = "n7cKULtvGKV9Xvrwywp6jEjZtTJqexLVUVJm+5BfuNMgk1tYsIPRmw==";
                //se.BuiltIn = true;
                //se.SkinFile = "Vista.ssk";
                //se.SkinAllForm = true;
                //se.Active = true;
                
                //Change skin
                
			}

			/// <summary>
			/// Clean up any resources being used.
			/// </summary>
			protected override void Dispose( bool disposing )
			{
				if( disposing )
				{
					if (components != null) 
					{
						components.Dispose();
					}
				}
				base.Dispose( disposing );
			}
		#endregion

		#region STATIC
		#endregion

		#region DELEGATES & EVENTS
			public event ObjectClosedEventHandle ObjectClosed;
//			public event FormOpeningEventHandler FormOpening;
//			public event OpenSubFormEventHandler SubFormOpened;
//			public event CloseFormEventHandler FormClosed;
		#endregion

		#region PROPERTIES
			/// <summary>
			/// IRunableObject
			/// </summary>
			public string AssemblyName
			{
				get {return m_strAssemblyName;}
				set {m_strAssemblyName = value;}
			}
			public string ClassName
			{
				get {return m_strClassName;}
				set {m_strClassName = value;}
			}

			public OpenObjectFunction OpenObject
			{
				get {return m_fOpenObject;}
				set {m_fOpenObject = value;}
			}

			/// <summary>
			/// ISecurityInfo
			/// </summary>
			public object UserID
			{
				get {return m_objUserID;}
				set {m_objUserID = value;}
			}

			/// <summary>
			/// ISecurityInfo
			/// </summary>
			public object UserName
			{
				get {return m_objUserName;}
				set {m_objUserName = value;}
			}
			
			/// <summary>
			/// ISecurity
			/// </summary>
			public object UserRights
			{
				get {return m_nUserRights;}
				set {m_nUserRights = value;}
			}

			/// <summary>
			/// ISecurity
			/// </summary>
			public IPermission Permission
			{
				get {return m_objPermission;}
				set {m_objPermission = value;}
			}


			/// <summary>
			/// IFormID
			/// </summary>
			public object ObjectID
			{
				get	{return this.Name;}
			}


			/// <summary>
			/// IDatabase
			/// </summary>
			public IDatabaseEngine DBEngine
			{
				get 
				{
					return m_objDBEngine;
				}
				set 
				{
					m_objDBEngine = value;
				}
			}
		#endregion

		#region PUBLIC METHODS
			/// <summary>
			/// This method has responsibility for getting information from external entity
			/// </summary>
			/// <param name="objParam">information</param>
			public virtual void SetData(object objParam)
			{
			}


			/// <summary>
			/// This method has responsibility for returning expected results
			/// </summary>
			/// <returns>expected results</returns>
			public virtual object GetData()
			{
				return null;
			}


			/// <summary>
			///	IBaseForm
			///	Revision:
			///		2002-12-02	created by TRAN VIET HA
			/// </summary>
			public virtual bool CanClose()
			{
				return true;
			}


			/// <summary>
			/// IRunableObject
			/// </summary>
			/// <param name="IsShownModal"></param>
            public virtual DialogResult Run(bool IsShownModal)
            {
                if (IsShownModal)
                    return this.ShowDialog();
                else
                {

                    this.WindowState = FormWindowState.Maximized;
                    this.Show();
                    return System.Windows.Forms.DialogResult.None;
                }
            }


			/// <summary>
			/// IRunableObject
			/// </summary>
			/// <returns></returns>
			public virtual bool Stop()
			{
				if (!CanClose())
					return false;

				this.Close();
				return true;
			}


			/// <summary>
			/// IRunableObject
			/// </summary>
			public virtual void ActivateObject()
			{
				this.Activate();
			}


			/// <summary>
			/// IRunableObject
			/// </summary>
            public virtual void SetParent(Form objParent)
            {
                if (objParent.IsMdiContainer)
                    this.MdiParent = objParent;
                else
                    this.Parent = objParent;
            }
		#endregion

		#region PROTECTED METHODS
		#endregion

		#region PRIVATE METHODS
		#endregion

		#region OVERRIDES
            protected override void OnClosing(CancelEventArgs e)
            {
                e.Cancel = !CanClose();
                base.OnClosing(e);
            }

			protected override void OnClosed(EventArgs e)
			{
				base.OnClosed (e);
                if (AssemblyName == null || ClassName == null)
                    return;
				ObjectClosed(this.AssemblyName, this.ClassName);
			}
		#endregion

		#region VARIABLES
			protected OpenObjectFunction m_fOpenObject = null;
			protected string m_strAssemblyName = null;
			protected string m_strClassName = null;
			protected object m_objUserID = null;
			protected object m_objUserName = null;
			protected object m_nUserRights = ESecurityRights.NORIGHT;

			protected IDatabaseEngine m_objDBEngine = null;

			protected IPermission m_objPermission = null;
		#endregion

		#region EVENT HANDLER
		#endregion

		#region Windows Auto-generated
			private IContainer components = null;
		
			/// <summary>
			/// Required method for Designer support - do not modify
			/// the contents of this method with the code editor.
			/// </summary>
			private void InitializeComponent()
			{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CBaseForm));
            this.SuspendLayout();
            // 
            // CBaseForm
            // 
            resources.ApplyResources(this, "$this");
            this.LookAndFeel.SkinName = "Seven";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "CBaseForm";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

			}
		#endregion
	}
}

