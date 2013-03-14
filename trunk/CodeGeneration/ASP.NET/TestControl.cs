using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace GeneratedControlsASP
{
	public class TestControl : System.Web.UI.WebControls.WebControl
	{
		public string Text
		{
			get { return _text ; }
			set { _text = value ; }
		}

		protected override void Render(HtmlTextWriter output)
		{
			output.Write(Text);
		}

		private string _text;
	}
}
