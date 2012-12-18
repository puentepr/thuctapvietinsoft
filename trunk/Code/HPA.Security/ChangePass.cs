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
            if (txtPass1 != txtPass2)
            {
                HPA.Common.Methods.ShowMessage(HPA.Common.Methods.GetMessage(HPA.Common.CommonConst.PASSNOTMATCH));
            }
            else
            {
                string pa = HPA.Common.Encryption.EncryptText(txtPass1.Text, true);
                HPA.SQL.SP.Changepassword cp = new SQL.SP.Changepassword();
                cp.Changepass(pa);
                HPA.Common.Methods.ShowMessage(HPA.Common.Methods.GetMessage(HPA.Common.CommonConst.PASS_CHANGED_SUCCESSFULL));
            }
        }
    }
}
