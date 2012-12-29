using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace HPA
{
    public partial class HPA_Main : Form
    {
       
        public HPA_Main()
        {
            InitializeComponent();
        }

        private void HPA_Main_Load(object sender, EventArgs e)
        {
            //string s = dt.Connection.ConnectionString.ToString();
            Form lg = new HPA.MAINFRAME.frmLogin();
            lg.ShowDialog();
            if (HPA.Common.StaticVars.UserName != null)
            {

            }
            else
            {
                Application.Exit();
            }
        }
        
    }
}
