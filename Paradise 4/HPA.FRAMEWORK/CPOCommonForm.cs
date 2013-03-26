using System;
using HPA.Component.Framework;

namespace HPA.Component.Framework
{
	public class CPOCommonForm : CCommonForm
	{
		private System.ComponentModel.IContainer components = null;

		public CPOCommonForm()
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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPOCommonForm));
            this.pnlFWCommand.SuspendLayout();
            this.pnlFWClose.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFWCommand
            // 
            resources.ApplyResources(this.pnlFWCommand, "pnlFWCommand");
            // 
            // btnFWDelete
            // 
            this.btnFWDelete.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnFWDelete.Appearance.Font")));
            this.btnFWDelete.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnFWDelete.Appearance.ForeColor")));
            this.btnFWDelete.Appearance.Options.UseFont = true;
            this.btnFWDelete.Appearance.Options.UseForeColor = true;
            this.btnFWDelete.LookAndFeel.SkinName = "Blue";
            this.btnFWDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            resources.ApplyResources(this.btnFWDelete, "btnFWDelete");
            // 
            // btnFWSave
            // 
            this.btnFWSave.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnFWSave.Appearance.Font")));
            this.btnFWSave.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnFWSave.Appearance.ForeColor")));
            this.btnFWSave.Appearance.Options.UseFont = true;
            this.btnFWSave.Appearance.Options.UseForeColor = true;
            this.btnFWSave.LookAndFeel.SkinName = "Blue";
            this.btnFWSave.LookAndFeel.UseDefaultLookAndFeel = false;
            resources.ApplyResources(this.btnFWSave, "btnFWSave");
            // 
            // btnFWAdd
            // 
            this.btnFWAdd.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnFWAdd.Appearance.Font")));
            this.btnFWAdd.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnFWAdd.Appearance.ForeColor")));
            this.btnFWAdd.Appearance.Options.UseFont = true;
            this.btnFWAdd.Appearance.Options.UseForeColor = true;
            this.btnFWAdd.LookAndFeel.SkinName = "Blue";
            this.btnFWAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            resources.ApplyResources(this.btnFWAdd, "btnFWAdd");
            // 
            // pnlFWClose
            // 
            resources.ApplyResources(this.pnlFWClose, "pnlFWClose");
            // 
            // btnFWClose
            // 
            this.btnFWClose.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnFWClose.Appearance.Font")));
            this.btnFWClose.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnFWClose.Appearance.ForeColor")));
            this.btnFWClose.Appearance.Options.UseFont = true;
            this.btnFWClose.Appearance.Options.UseForeColor = true;
            this.btnFWClose.LookAndFeel.SkinName = "Blue";
            this.btnFWClose.LookAndFeel.UseDefaultLookAndFeel = false;
            resources.ApplyResources(this.btnFWClose, "btnFWClose");
            // 
            // btnFWReset
            // 
            this.btnFWReset.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnFWReset.Appearance.Font")));
            this.btnFWReset.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnFWReset.Appearance.ForeColor")));
            this.btnFWReset.Appearance.Options.UseFont = true;
            this.btnFWReset.Appearance.Options.UseForeColor = true;
            this.btnFWReset.LookAndFeel.SkinName = "Blue";
            this.btnFWReset.LookAndFeel.UseDefaultLookAndFeel = false;
            resources.ApplyResources(this.btnFWReset, "btnFWReset");
            // 
            // btnExport
            // 
            this.btnExport.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnExport.Appearance.Font")));
            this.btnExport.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnExport.Appearance.ForeColor")));
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Appearance.Options.UseForeColor = true;
            this.btnExport.LookAndFeel.SkinName = "Blue";
            this.btnExport.LookAndFeel.UseDefaultLookAndFeel = false;
            resources.ApplyResources(this.btnExport, "btnExport");
            // 
            // CPOCommonForm
            // 
            this.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("CPOCommonForm.Appearance.BackColor")));
            this.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this, "$this");
            this.LookAndFeel.SkinName = "Office 2013";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "CPOCommonForm";
            this.pnlFWCommand.ResumeLayout(false);
            this.pnlFWClose.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
	}
}

