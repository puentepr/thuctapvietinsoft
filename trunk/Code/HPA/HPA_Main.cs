using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HPA
{
    public partial class HPA_Main : Form
    {

        public HPA_Main()
        {
            InitializeComponent();
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //if (!ab.IsDisposed)
            //    ab.Show();
        }

        private void HPA_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void HPA_Main_Load(object sender, EventArgs e)
        {
            FormLogin lg = new FormLogin();
            lg.ShowDialog();
            if (HPA.Common.StaticVars.UserName!=null)
            {
                toolStripStatusLabel.Text= "Username: " + HPA.Common.StaticVars.UserName;
            }
            else
            {
                Application.Exit();
            }
        }
        private void LoadMenu()
        { 

        }
    }
}
