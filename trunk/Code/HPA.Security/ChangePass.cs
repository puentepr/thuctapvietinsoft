using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HPA.Security
{
    public partial class ChangePass : Form
    {
        public ChangePass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPass1.Text != txtPass2.Text)
            {
                HPA.Common.Methods.ShowMessage(HPA.Common.Methods.GetMessage(HPA.Common.CommonConst.PASSNOTMATCH));
            }
            else
            {
                string mkc = HPA.Common.Encryption.EncryptText(txtMKcu.Text, true);
                string pa = HPA.Common.Encryption.EncryptText(txtPass1.Text, true);
                HPA.SQL.SP.Changepassword cp = new SQL.SP.Changepassword();
                string s = cp.Changepass(36, mkc, pa);
                if(s=="1")
                {
                    HPA.Common.Methods.ShowMessage(HPA.Common.Methods.GetMessage(HPA.Common.CommonConst.PASS_WRONG));
                }
                else if (s == "2")
                {
                    HPA.Common.Methods.ShowMessage(HPA.Common.Methods.GetMessage(HPA.Common.CommonConst.PASS_CHANGED_SUCCESSFULL));
                }
            }
        }
    }
}
