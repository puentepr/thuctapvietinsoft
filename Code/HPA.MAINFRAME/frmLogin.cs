using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HPA.MAINFRAME
{
    public partial class frmLogin : HPA.CommonForm.BaseForm
    {
        public frmLogin()
        {
            InitializeComponent();
            Control.ControlCollection ctrl = this.Controls;
            HPA.Common.Methods.ChangeLanguage(ref ctrl);
            this.AcceptButton = login1.btnLogin;
            this.CancelButton = login1.btnCancel;
        }

        private void login1_VisibleChanged(object sender, EventArgs e)
        {
            if (login1.LoginSuccess)
            {
                this.Close();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void login1_Load(object sender, EventArgs e)
        {
            
        }
        

    }
}
