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

namespace GeneratedControlsASP
{
	/// <summary>
	/// Summary description for _default.
	/// </summary>
	public class _default : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Button generateIL;
		protected System.Web.UI.WebControls.Button generateCsharp;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.generateIL.Click += new System.EventHandler(this.generateIL_Click);
			this.generateCsharp.Click += new System.EventHandler(this.generateCsharp_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void generateIL_Click(object sender, System.EventArgs e)
		{
			this.Session["Caption"] = TextBox1.Text;
			this.Session["Generator"] = "IL" ;

			Response.Redirect ( "DisplayControl.aspx" ) ;
		}

		private void generateCsharp_Click(object sender, System.EventArgs e)
		{
			this.Session["Caption"] = TextBox1.Text;
			this.Session["Generator"] = "CS" ;

			Response.Redirect ( "DisplayControl.aspx" ) ;
		}
	}
}
