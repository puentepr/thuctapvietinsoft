using System;
using System.ComponentModel;
using System.Windows.Forms;
using HPA.Component.Framework.Base;
using HPA.Common;

namespace HPA.Component.Framework
{
	/// <summary>
	/// CCommonForm is based form of almost user-interactive forms.
	/// It implements ICommonForm interface to unify a way to communicate.
	/// Also, it creates a graphic user interface to make all user's behaviors to each form the same through the system.
	/// Accordingly, it provides some public mechanisms to help inherited forms perform their tasks conveniently.
	/// To do so, it defines several simple and strict rules which force all its children abiding by.
	/// Revision:
	///		2003-06-04	created by TRAN VIET HA
	///		2003-07-14	consolidate with new version of CBaseForm. TRAN VIET HA
	/// </summary>
	public class CCommonForm : CBaseForm, ICommonForm
	{
		#region CONSTRUCTOR & DESTRUCTOR
			public CCommonForm()
			{
				// This call is required by the Windows Form Designer.
				InitializeComponent();

				// TODO: Add any initialization after the InitializeComponent call
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

		#region STATIC & CONSTANT & ENUM
            private const int WM_NCHITTEST = 0x84;
            private const int HTCLIENT = 0x1;
            protected DevExpress.XtraEditors.SimpleButton btnDesignForm;
            private const int HTCAPTION = 0x2;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    if ((int)m.Result == HTCLIENT)
                        m.Result = (IntPtr)HTCAPTION;
                    return;
            }
            base.WndProc(ref m);
        }
        public enum ESaveForChangeResult
        {
            FAIL,
            SAVED,
            NOTSAVED,
            NOCHANGE
        }
		#endregion

		#region DELEGATES & EVENTS
		#endregion

		#region PROPERTIES
			/// <summary>
			/// Five following properties is used to determine 
			/// when someone can invoked this form to perform some special tasks.
			/// Revision:
			///		2002-06-04	created by TRAN VIET HA
			/// </summary>
			public virtual bool CanAdd
			{
				get {return (btnFWAdd.Enabled && btnFWAdd.Visible);}
			}

			public virtual bool CanSave
			{
				get {return (btnFWSave.Enabled && btnFWSave.Visible);}
			}

			public virtual bool CanDelete
			{
				get {return (btnFWDelete.Enabled && btnFWDelete.Visible);}
			}


			/// <summary>
			/// This property is to notify whether there are some unsaved changes.
			/// And also enable/disable SAVE button if needed
			/// TRUE = user has changed something
			/// FALSE = nothing changed from the last saved
			/// Revision:
			///		2003-06-03	created by TRAN VIET HA
			/// </summary>
			public virtual bool DirtyData
			{
				get {return m_bDirtyData;}
				set
				{
					if (this.DesignMode)
						return;

					m_bDirtyData = value;

					// Modified by HoangTV 2005/03/29 to support multi-rights:
					ESecurityRights nUserRights = ESecurityRights.NORIGHT;
					if (m_nUserRights != null)
					{
						nUserRights = (ESecurityRights)Convert.ToUInt64(m_nUserRights);
					}
					if (nUserRights == ESecurityRights.NORIGHT || nUserRights == ESecurityRights.VIEW)
					{
						foreach (Control ctrInternal in pnlFWCommand.Controls)
						{
							ctrInternal.Enabled = false;
						}
						//pnlFWCommand.Enabled = false;
                        btnExport.Enabled = true;
						pnlFWClose.Enabled = true;
					}
					else
					{
						// enable / disable SAVE button
						btnFWSave.Enabled = m_bDirtyData;
                        btnFWReset.Enabled = m_bDirtyData;
					}
				}
			}

        public virtual bool IsAdded
        {
            get { return m_bIsAdded; }
            set
            {
                if (this.DesignMode)
                    return;

                m_bIsAdded = value;

                // Modified by HoangTV 2005/03/29 to support multi-rights:
                ESecurityRights nUserRights = ESecurityRights.NORIGHT;
                if (m_nUserRights != null)
                {
                    nUserRights = (ESecurityRights)Convert.ToUInt64(m_nUserRights);
                }
                if (nUserRights == ESecurityRights.NORIGHT || nUserRights == ESecurityRights.VIEW)
                {
                    foreach (Control ctrInternal in pnlFWCommand.Controls)
                    {
                        ctrInternal.Enabled = false;
                    }
                   
                    pnlFWClose.Enabled = true;
                }
                else
                {
                    
                    btnFWAdd.Enabled = m_bIsAdded;
                    btnFWDelete.Enabled = m_bIsAdded;
                }
            }
        }
			/// <summary>
			/// Implementation of ActionState property of ICommonForm interface.
			/// If the state is not NORMAL, it will make this form disable.
			/// Revision:
			///		2003-06-09	created by TRAN VIET HA
			/// </summary>
			public virtual EActionState ActionState
			{
				get {return m_eActionState;}
				set 
				{
					m_eActionState = value;

					this.Enabled = (m_eActionState == EActionState.NORMAL);
				}
			}
		#endregion

		#region PUBLIC METHODS
			/// <summary>
			/// This method takes care of once initializing data for all controls placed on this form.
			/// Revision:
			///		2002-01-08	created by TRAN VIET HA
			/// </summary>
			/// <returns></returns>
			public virtual bool InitializeData()
			{
				return true;
			}


			/// <summary>
			/// This method has responsibility for adding something.
			/// This is the implementation for ICommonForm.
			/// Here we check user's rights to adding action.
			/// Revision:
			///		2003-06-04	created by TRAN VIET HA
			/// </summary>
			/// <returns>TRUE = switch successfully, FALSE = fail</returns>
			public virtual bool OnAdd()
			{
				// can we add?
				if (!CanAdd)
					return false;

//				// check security rights
//				if ((UserRights & (ulong)ESecurityRights.ADD) == 0)
//				{
//					UserMessages.Alert((int)HPA.GABLE.Data.EMessage.RIGHT_NO_ADD, null);
//					return false;
//				}

				return true;
			}


			/// <summary>
			///	This method checks data validation.
			/// Revision:
			///		2003-06-04	created by TRAN VIET HA
			/// </summary>
			/// <returns>TRUE = successfully, FALSE = fail</returns>
			public virtual bool OnValidate()
			{
				return true;
			}


			/// <summary>
			/// This method will save all changes if data is valid.
			/// Revision:
			///		2003-06-04	created by TRAN VIET HA
			/// </summary>
			/// <returns>TRUE = successfully, FALSE =fail</returns>
			public virtual bool OnSave()
			{
				try
				{
					// can we save?
					if (!CanSave)
						return false;

					// validate data
					if (!OnValidate())
						return false;

					// commit data to database
					if (!Commit())
						return false;
	                
					// save successfully, so no dirty data
					DirtyData = false;
				}
				catch (Exception e)
				{
					HPA.Common.Helper.ShowException(e, this.GetType().AssemblyQualifiedName + ".OnSave()", null);
					return false;
				}
				
				return true;
			}


			/// <summary>
			///	This method has responsibility for deleting something.
			///	This is the implementation for ICommonForm.
			/// Here we check user's rights to deleting action.
			/// Revision:
			///		2003-06-04	created by TRAN VIET HA
			/// </summary>
			/// <returns>TRUE = successfully, FALSE = fail</returns>
			public virtual bool OnDelete()
			{
				// can we delete
				if (!CanDelete)
					return false;

//				// check security rights
//				if ((UserRights & (ulong)ESecurityRights.DELETE) == 0)
//				{
//					UserMessages.Alert((int)HPA.GABLE.Data.EMessage.RIGHT_NO_DELETE, null);
//					return false;
//				}

				return true;
			}


			/// <summary>
			/// This "abstract" method has responsibility for commiting data into database.
			/// Derived class should override this method to:
			///		1. Make sure that it fulfils its responsibilities.
			///		2. Create an unique way to commit data.
			/// Revision:
			///		2003-06-04	created by TRAN VIET HA			
			/// </summary>
			/// <returns>TRUE = successfully, FALSE = fail</returns>
			public virtual bool Commit()
			{
				return true;
			}
            public virtual bool OnExport()
            {
                return true;
            }
            public virtual bool OnDesignForm()
            {

                return true;
            }
        
			/// <summary>
			/// Reject all changes which have been made since the last commiting
			/// Revision
			///		2003-12-10	created by TRAN VIET HA
			/// </summary>
			/// <returns>TRUE = successfully, FALSE = fail</returns>
			public virtual bool OnReset()
			{
                DirtyData = false;
				return true;
			}
		#endregion

		#region PROTECTED METHODS
			/// <summary>
			/// Confirm and save "dirty data".
			/// Note that we will commit data both in database (via Commit() method) and datasource (via AcceptChanges() method)
			/// </summary>
			/// <returns>0 = fail	
			///			 1 = successfully and user's response is YES
			///			 2 = successfully and user's response is NO
			///			 3 = no "dirty data"
			///	</returns>
			protected virtual ESaveForChangeResult SaveForChange()
			{
				if (DirtyData)
				{
					try
					{
						// ask for changes					
                        DialogResult dr = UIMessage.ShowMessage(CommonConst.SAVE_CONFIRM, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

						if (dr == DialogResult.Cancel)
							return ESaveForChangeResult.FAIL;

						// save the changes
						if (dr == DialogResult.Yes)
						{
							// look for validation
							if (!OnValidate())
								return ESaveForChangeResult.FAIL;

							// save the changes to database
							if (!Commit())
								return ESaveForChangeResult.FAIL;

							// save successfully, so no dirty data any more
							DirtyData = false;

							return ESaveForChangeResult.SAVED;
						}

						// no need to save the changes, so no dirty data any more
						DirtyData = false;

						return ESaveForChangeResult.NOTSAVED;
					}
					catch (Exception e)
					{
                        HPA.Common.Helper.ShowException(e, String.Format("{0}.{1}.SaveForChange()!", System.Reflection.Assembly.GetExecutingAssembly().FullName, this.Name), null);
						return ESaveForChangeResult.FAIL;
					}
				}

				// we have no dirty data
				return ESaveForChangeResult.NOCHANGE;
			}
		#endregion

		#region PRIVATE METHODS
		#endregion

		#region OVERRIDES
			/// <summary>
			/// Override OnLoad method to:
			///		1. initialize components by using base method
			///		2. initialize data of all controls placed on this form using virtual method InitializeData()
			///	Revision:
			///		2003-06-04	created by TRAN VIET HA
			/// </summary>
			/// <param name="e"></param>
			protected override void OnLoad(EventArgs e)
			{
				// initialize all components
				base.OnLoad(e);
					
				if (!this.DesignMode)
				{
					// initialize data of all controls placed on this form.
					if (!InitializeData())
					{
						this.Close();
						return;
					}
                    if (UserID == null || (int)UserID != 3)
                        btnDesignForm.Visible = false;
					// Modified by HoangTV 2005/03/29 to support multi-rights:
					ESecurityRights nUserRights = ESecurityRights.NORIGHT;
					if (m_nUserRights != null)
					{
						nUserRights = (ESecurityRights)Convert.ToUInt64(m_nUserRights);
					}
					if (nUserRights == ESecurityRights.NORIGHT || nUserRights == ESecurityRights.VIEW)
					{
						foreach (Control ctrInternal in pnlFWCommand.Controls)
						{
							ctrInternal.Enabled = false;
						}
						//pnlFWCommand.Enabled = false;
						pnlFWClose.Enabled = true;
					}

					// no dirty data
					DirtyData = false;					
				}
			}


			protected override void OnClosing(CancelEventArgs e)
			{
				ESecurityRights nUserRights = ESecurityRights.NORIGHT;
				if (m_nUserRights != null)
				{
					nUserRights = (ESecurityRights)Convert.ToUInt64(m_nUserRights);
				}
				if (nUserRights == ESecurityRights.NORIGHT || nUserRights == ESecurityRights.VIEW)
				{
					// Nothing.
				}
				else if (SaveForChange() == ESaveForChangeResult.FAIL) // save fail?
				{
					e.Cancel = true;
					return;
				}

				// close normally
                this.Dispose(true);
                GC.SuppressFinalize(this);
				base.OnClosing(e);
			}
		#endregion

		#region VARIABLES
		    protected bool m_bDirtyData = false;
            protected bool m_bIsAdded = false;
			protected EActionState m_eActionState = EActionState.NORMAL;
		#endregion		

		#region Windows Auto-generated
			protected Panel pnlFWCommand;
			protected DevExpress.XtraEditors.SimpleButton btnFWDelete;
            protected DevExpress.XtraEditors.SimpleButton btnFWSave;
            protected DevExpress.XtraEditors.SimpleButton btnFWAdd;
			protected Panel pnlFWClose;
            protected DevExpress.XtraEditors.SimpleButton btnFWClose;
			protected Label lblFWDecorateingLine;
        protected DevExpress.XtraEditors.SimpleButton btnFWReset;
        protected DevExpress.XtraEditors.SimpleButton btnExport;
			private IContainer components = null;

		
			/// <summary>
			/// Required method for Designer support - do not modify
			/// the contents of this method with the code editor.
			/// </summary>
			private void InitializeComponent()
			{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CCommonForm));
            this.pnlFWCommand = new System.Windows.Forms.Panel();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnFWReset = new DevExpress.XtraEditors.SimpleButton();
            this.pnlFWClose = new System.Windows.Forms.Panel();
            this.btnDesignForm = new DevExpress.XtraEditors.SimpleButton();
            this.btnFWClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnFWDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnFWSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnFWAdd = new DevExpress.XtraEditors.SimpleButton();
            this.lblFWDecorateingLine = new System.Windows.Forms.Label();
            this.pnlFWCommand.SuspendLayout();
            this.pnlFWClose.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFWCommand
            // 
            this.pnlFWCommand.Controls.Add(this.btnExport);
            this.pnlFWCommand.Controls.Add(this.btnFWReset);
            this.pnlFWCommand.Controls.Add(this.pnlFWClose);
            this.pnlFWCommand.Controls.Add(this.btnFWDelete);
            this.pnlFWCommand.Controls.Add(this.btnFWSave);
            this.pnlFWCommand.Controls.Add(this.btnFWAdd);
            resources.ApplyResources(this.pnlFWCommand, "pnlFWCommand");
            this.pnlFWCommand.Name = "pnlFWCommand";
            // 
            // btnExport
            // 
            this.btnExport.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnExport.Appearance.Font")));
            this.btnExport.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnExport.Appearance.ForeColor")));
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Appearance.Options.UseForeColor = true;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            resources.ApplyResources(this.btnExport, "btnExport");
            this.btnExport.Name = "btnExport";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnFWReset
            // 
            this.btnFWReset.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnFWReset.Appearance.Font")));
            this.btnFWReset.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnFWReset.Appearance.ForeColor")));
            this.btnFWReset.Appearance.Options.UseFont = true;
            this.btnFWReset.Appearance.Options.UseForeColor = true;
            this.btnFWReset.Image = ((System.Drawing.Image)(resources.GetObject("btnFWReset.Image")));
            resources.ApplyResources(this.btnFWReset, "btnFWReset");
            this.btnFWReset.Name = "btnFWReset";
            this.btnFWReset.Click += new System.EventHandler(this.btnFWReset_Click);
            // 
            // pnlFWClose
            // 
            this.pnlFWClose.Controls.Add(this.btnDesignForm);
            this.pnlFWClose.Controls.Add(this.btnFWClose);
            resources.ApplyResources(this.pnlFWClose, "pnlFWClose");
            this.pnlFWClose.Name = "pnlFWClose";
            // 
            // btnDesignForm
            // 
            this.btnDesignForm.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnDesignForm.Appearance.Font")));
            this.btnDesignForm.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnDesignForm.Appearance.ForeColor")));
            this.btnDesignForm.Appearance.Options.UseFont = true;
            this.btnDesignForm.Appearance.Options.UseForeColor = true;
            this.btnDesignForm.Image = ((System.Drawing.Image)(resources.GetObject("btnDesignForm.Image")));
            resources.ApplyResources(this.btnDesignForm, "btnDesignForm");
            this.btnDesignForm.Name = "btnDesignForm";
            this.btnDesignForm.Click += new System.EventHandler(this.btnDesignForm_Click);
            // 
            // btnFWClose
            // 
            resources.ApplyResources(this.btnFWClose, "btnFWClose");
            this.btnFWClose.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnFWClose.Appearance.Font")));
            this.btnFWClose.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnFWClose.Appearance.ForeColor")));
            this.btnFWClose.Appearance.Options.UseFont = true;
            this.btnFWClose.Appearance.Options.UseForeColor = true;
            this.btnFWClose.Image = ((System.Drawing.Image)(resources.GetObject("btnFWClose.Image")));
            this.btnFWClose.Name = "btnFWClose";
            this.btnFWClose.Click += new System.EventHandler(this.btnFWClose_Click);
            // 
            // btnFWDelete
            // 
            this.btnFWDelete.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnFWDelete.Appearance.Font")));
            this.btnFWDelete.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnFWDelete.Appearance.ForeColor")));
            this.btnFWDelete.Appearance.Options.UseFont = true;
            this.btnFWDelete.Appearance.Options.UseForeColor = true;
            this.btnFWDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnFWDelete.Image")));
            resources.ApplyResources(this.btnFWDelete, "btnFWDelete");
            this.btnFWDelete.Name = "btnFWDelete";
            this.btnFWDelete.Click += new System.EventHandler(this.btnFWDelete_Click);
            // 
            // btnFWSave
            // 
            this.btnFWSave.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnFWSave.Appearance.Font")));
            this.btnFWSave.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnFWSave.Appearance.ForeColor")));
            this.btnFWSave.Appearance.Options.UseFont = true;
            this.btnFWSave.Appearance.Options.UseForeColor = true;
            resources.ApplyResources(this.btnFWSave, "btnFWSave");
            this.btnFWSave.Image = ((System.Drawing.Image)(resources.GetObject("btnFWSave.Image")));
            this.btnFWSave.Name = "btnFWSave";
            this.btnFWSave.EnabledChanged += new System.EventHandler(this.btnFWSave_EnabledChanged);
            this.btnFWSave.Click += new System.EventHandler(this.btnFWSave_Click);
            // 
            // btnFWAdd
            // 
            this.btnFWAdd.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnFWAdd.Appearance.Font")));
            this.btnFWAdd.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnFWAdd.Appearance.ForeColor")));
            this.btnFWAdd.Appearance.Options.UseFont = true;
            this.btnFWAdd.Appearance.Options.UseForeColor = true;
            this.btnFWAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnFWAdd.Image")));
            resources.ApplyResources(this.btnFWAdd, "btnFWAdd");
            this.btnFWAdd.Name = "btnFWAdd";
            this.btnFWAdd.Click += new System.EventHandler(this.btnFWAdd_Click);
            // 
            // lblFWDecorateingLine
            // 
            this.lblFWDecorateingLine.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblFWDecorateingLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.lblFWDecorateingLine, "lblFWDecorateingLine");
            this.lblFWDecorateingLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFWDecorateingLine.ForeColor = System.Drawing.Color.GhostWhite;
            this.lblFWDecorateingLine.Name = "lblFWDecorateingLine";
            // 
            // CCommonForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlFWCommand);
            this.Controls.Add(this.lblFWDecorateingLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CCommonForm";
            this.Resize += new System.EventHandler(this.CCommonForm_Resize);
            this.pnlFWCommand.ResumeLayout(false);
            this.pnlFWClose.ResumeLayout(false);
            this.ResumeLayout(false);

			}
		#endregion

		#region EVENT HANDLER
            private void btnFWAdd_Click(object sender, EventArgs e)
            {

                if (!OnAdd())
                {
                    this.IsAdded = false;
                }
            }

            private void btnFWClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void btnFWSave_Click(object sender, EventArgs e)
            {
                OnSave();
            }

            private void btnFWDelete_Click(object sender, EventArgs e)
            {
                OnDelete();
            }

            private void btnFWReset_Click(object sender, EventArgs e)
            {
                OnReset();
            }
        private void btnExport_Click(object sender, EventArgs e)
        {
            OnExport();
        }
        private void btnDesignForm_Click(object sender, EventArgs e)
        {
            OnDesignForm();
        }
        private void CCommonForm_Resize(object sender, EventArgs e)
        {
            if ((!this.DesignMode) && (this.MdiParent != null))
                this.ControlBox = false;
        }
		#endregion

      

        private void btnFWSave_EnabledChanged(object sender, EventArgs e)
        {
            btnFWAdd.Enabled = !btnFWSave.Enabled;
            btnFWDelete.Enabled = !btnFWSave.Enabled;
        }

       

        
	}
}