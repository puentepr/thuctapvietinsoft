using System;
using System.ComponentModel;
using System.Windows.Forms;
using HPA.Common;


namespace HPA.TEMS.CPOPrototype
{
	// =======================================================
	// DESC:
	// REV:
	//	2003-12-
	// =======================================================
	/// <summary>
	/// </summary>
	public class CPOPrototype : HPA.Component.Framework.CPOCommonForm
	{
		#region OVERRIDE
			// =======================================================
			// NAME:	InitializeData
			// TASK:	Override InitializeData() method to initialize data once loading form
			// PARAM:	
			// RETURN:	TRUE = successfully, FALSE = fail
			// THROW:	
			// REV:	
			//	2003-12-
			// =======================================================
			/// <summary>
			/// Initialize data once loading form
			/// </summary>
			public override bool InitializeData()
			{
				try
				{
					// TODO - add code here to initialize data once loading the form					
				}
				catch (Exception e)
				{
                    HPA.Common.Helper.ShowException(e, this.Name + ".InitializeData()", null);
					return false;
				}

				return true;
			}


			// =======================================================
			// NAME:	OnAdd
			// TASK:	Override OnAdd() method to do something when switching into ADD mode.
			// PARAM:	
			// RETURN:	TRUE = successfully, FALSE = fail
			// THROW:	
			// REV:	
			//	2003-12-
			// =======================================================
			/// <summary>
			/// Switch into ADD mode
			/// </summary>
			public override bool OnAdd()
			{
				if (!base.OnAdd())
					return false;

				try
				{
					// TODO - add code here to do adding new item action
				}
				catch (Exception e)
				{
                    HPA.Common.Helper.ShowException(e, this.Name + ".OnAdd()", null);
					return false;
				}				

				return true;
			}


			// =======================================================
			// NAME:	OnValidate
			// TASK:	Override OnValidate() method to validate data before saving
			// PARAM:	
			// RETURN:	TRUE = validate ok, FALSE = fail
			// THROW:	
			// REV:	
			//	2003-12-
			// =======================================================
			/// <summary>
			/// Validate data
			/// </summary>
			public override bool OnValidate()
			{
				try
				{
					// TODO - add code here to validate data before saving
				}
				catch (Exception e)
				{
                    HPA.Common.Helper.ShowException(e, this.Name + ".OnValidate()", null);
					return false;
				}

				// validate ok
				return true;
			}


			// =======================================================
			// NAME:	Commit
			// TASK:	Override Commit() method to save data
			// PARAM:	
			// RETURN:	TRUE = successfully, FALSE = fail
			// THROW:	
			// REV:	
			//	2003-12-
			// =======================================================
			/// <summary>
			/// Save data
			/// </summary>
			public override bool Commit()
			{
				// remember current Action State
				HPA.Component.Framework.Base.EActionState eOldActionState = ActionState;

				try
				{
					// switch to COMMITING state
					ActionState = HPA.Component.Framework.Base.EActionState.BUSY;

					// wait-cursor
					this.Cursor = Cursors.WaitCursor;					

					try
					{
						DBEngine.beginTransaction();

						// TODO - add code here to perform commiting tasks

						DBEngine.commit();
					}
					catch (Exception ex)
					{
						DBEngine.rollback();
						throw(ex);
					}

					// restore cursor
					this.Cursor = Cursors.Default;
					
					// restore action state
					ActionState = eOldActionState;
				}
				catch (Exception e)
				{
					// restore cursor
					this.Cursor = Cursors.Default;

					// show error
                    HPA.Common.Helper.ShowException(e, this.Name + ".Commit()", null);

					// restore action state
					ActionState = eOldActionState;

					// unable to commit
					return false;
				}

				// commit successfully
				return true;
			}

			
			// =======================================================
			// NAME:	OnDelete
			// TASK:	Override OnDelete() method to perform delete tasks.
			// PARAM:	
			// RETURN:	TRUE = successfully, FALSE = fail
			// THROW:	
			// REV:	
			//	2003-12-
			// =======================================================
			/// <summary>
			/// Perform delete tasks
			/// </summary>
			public override bool OnDelete()
			{
				if (!base.OnDelete())
					return false;

				// remember current Action State
				HPA.Component.Framework.Base.EActionState eOldActionState = ActionState;

				try
				{
					// switch to DELETING state
					ActionState = HPA.Component.Framework.Base.EActionState.BUSY;

					// wait-cursor
					this.Cursor = Cursors.WaitCursor;


					// TODO - add code here to perform delete tasks


					// restore cursor
					this.Cursor = Cursors.Default;
					
					// restore action state
					ActionState = eOldActionState;
				}
				catch (Exception e)
				{
					// restore cursor
					this.Cursor = Cursors.Default;

					// show error
                    HPA.Common.Helper.ShowException(e, this.Name + ".OnDelete()", null);

					// restore action state
					ActionState = eOldActionState;

					// unable to delete
					return false;
				}

				// delete successfully
				return true;
			}


			// =======================================================
			// NAME:	OnReset
			// TASK:	reject all changes
			// PARAM:	
			// RETURN:	
			// THROW:	
			// REV:	
			//	2003-06-
			// =======================================================
			/// <summary>
			/// reject all changes
			/// </summary>
			public override bool OnReset()
			{
				try
				{
				}
				catch (Exception e)
				{
                    HPA.Common.Helper.ShowException(e, this.Name + ".OnReset()", null);
					return false;
				}

				return true;
			}


			// =======================================================
			// NAME:	SetData
			// TASK:	get data from external invoker. This method is made because we should keep constructor as default.
			// PARAM:	objParam is an object containing given information.
			// RETURN:	
			// THROW:	
			// REV:	
			//	2003-06-
			// =======================================================
			/// <summary>
			/// get data from external invoker
			/// </summary>
			public override void SetData(object objParam)
			{
				try
				{
				}
				catch (Exception e)
				{
                    HPA.Common.Helper.ShowException(e, this.Name + ".SetData()", null);
					return;
				}
			}


			// =======================================================
			// NAME:	GetData
			// TASK:	retrieve data as expected results
			// PARAM:	
			// RETURN:	expected results
			// THROW:	
			// REV:	
			//	2003-06-
			// =======================================================
			/// <summary>
			/// retrieve data as expected results
			/// </summary>
			public override object GetData()
			{
				try
				{
					return null;
				}
				catch (Exception e)
				{
                    HPA.Common.Helper.ShowException(e, this.Name + ".GetData()", null);
					return null;
				}				
			}

		#endregion	

		#region CONSTRUCTOR & DESTRUCTOR
			public CPOPrototype()
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

		#region STATIC & CONSTANT
		#endregion

		#region EVENTS
		#endregion

		#region PROPERTIES
		#endregion

		#region PUBLIC METHODS
		#endregion

		#region PROTECTED METHODS
		#endregion

		#region PRIVATE METHODS
		#endregion

		#region VARIABLES
		#endregion		
		
		#region Designer generated code
			private IContainer components = null;

			/// <summary>
			/// Required method for Designer support - do not modify
			/// the contents of this method with the code editor.
			/// </summary>
			private void InitializeComponent()
			{
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPOPrototype));
                this.pnlFWCommand.SuspendLayout();
                this.pnlFWClose.SuspendLayout();
                this.SuspendLayout();
                // 
                // CPOPrototype
                // 
                resources.ApplyResources(this, "$this");
                this.BackColor = System.Drawing.SystemColors.Control;
                this.Name = "CPOPrototype";
                this.pnlFWCommand.ResumeLayout(false);
                this.pnlFWClose.ResumeLayout(false);
                this.ResumeLayout(false);

			}
		#endregion

		#region EVENT HANDLER
		#endregion
	}
}

