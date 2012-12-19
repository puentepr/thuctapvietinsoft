using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HPA.CommonForm
{
    public partial class BaseForm : DevExpress.XtraEditors.XtraForm
    {
        bool kt = false;
        int Y, X;
        public EzSqlCollection.EzSql2 DBEngine = null;
        public BaseForm()
        {
            InitializeComponent();
            if (HPA.Common.StaticVars.ServerName == null)
                return;
            DBEngine = new EzSqlCollection.EzSql2(HPA.Common.StaticVars.ServerName, HPA.Common.StaticVars.DatabaseName, HPA.Common.StaticVars.UserID_sql, HPA.Common.StaticVars.Password);
            DBEngine.open();
        }
        

        

        private void BaseForm_MouseDown(object sender, MouseEventArgs e)
        {
            kt = true;
            Y = e.Y;
            X = e.X;
        }

        private void BaseForm_MouseUp(object sender, MouseEventArgs e)
        {
            kt = false;
        }

        private void BaseForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (kt)
            {
                this.Top += e.Y - Y;
                this.Left += e.X - X;
            }
        }

        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DBEngine.close();
        }
    }
}