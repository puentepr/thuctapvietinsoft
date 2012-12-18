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
            //foreach (Form childForm in MdiChildren)
            //{
            //    childForm.Close();
            //}
            HPA.Setting.DynamicForm df = new Setting.DynamicForm();
            df.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            Application.Exit();
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
                toolStripStatusLabel.Text= string.Format("Login ID: {0}  |  Login Name: {1}  |",HPA.Common.StaticVars.LoginID, HPA.Common.StaticVars.UserName);
                ToolStripStatusLabel svrInfo = new ToolStripStatusLabel(string.Format("Server: {0}   |   Database: {1}", HPA.Common.StaticVars.ServerName,HPA.Common.StaticVars.DatabaseName));
                statusStrip.Items.Add(svrInfo);
                //statusStrip
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
