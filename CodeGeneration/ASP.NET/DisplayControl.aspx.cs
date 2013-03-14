using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Reflection;

namespace GeneratedControlsASP
{
	/// <summary>
	/// Summary description for DisplayControl.
	/// </summary>
	public class DisplayControl : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.PlaceHolder controlPlaceholder;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			string caption = this.Session["Caption"] as string;
			string gen = this.Session["Generator"] as string;

			Type t = null ;

			if ( gen.Equals ( "IL" ) ) 
				t = ControlGeneratorIL.GenerateControl ( ) ;
			else
				t = ControlGeneratorCS.GenerateControl ( ) ;

			Control ctrl = Activator.CreateInstance ( t ) as Control ;

			t.GetProperty("Text").SetValue ( ctrl, caption, new object[] { } ) ;

			this.controlPlaceholder.Controls.Add ( ctrl ) ;

		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
