using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace GeneratedControls
{
	/// <summary>
	/// Summary description for TestControl.
	/// </summary>
	public class TestControl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label mainLabel;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TestControl()
		{
			// This call is required by the Windows.Forms Form Designer.
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
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// mainLabel
			// 
			this.mainLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.mainLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.mainLabel.Location = new System.Drawing.Point(8, 8);
			this.mainLabel.Name = "mainLabel";
			this.mainLabel.Size = new System.Drawing.Size(312, 23);
			this.mainLabel.TabIndex = 0;
			this.mainLabel.Text = "[Text goes here]";
			// 
			// TestControl
			// 
			this.Controls.Add(this.mainLabel);
			this.Name = "TestControl";
			this.Size = new System.Drawing.Size(328, 200);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
