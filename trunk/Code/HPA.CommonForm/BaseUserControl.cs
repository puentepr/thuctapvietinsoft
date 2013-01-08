using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HPA.CommonForm
{
    public partial class BaseUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public EzSqlCollection.EzSql2 DBEngine = null;
        public BaseUserControl()
        {
            InitializeComponent();
            if (HPA.Common.StaticVars.ServerName == null)
                return;
            DBEngine = new EzSqlCollection.EzSql2(HPA.Common.StaticVars.ServerName, HPA.Common.StaticVars.DatabaseName, HPA.Common.StaticVars.UserID_sql, HPA.Common.StaticVars.Password);
            DBEngine.open();
        }
        protected virtual void Test()
        {

        }
        protected virtual void Save()
        {

        }
        //Set su kien bam phim 
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F2)
            {
                this.Test();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.S))
            {
                this.Save();
                return true;
            }
            else if (keyData == Keys.F1)
            {
                Help.ShowHelp(this, "huongdan.chm");
                return true;
            }
            else return false;
        }

        private void BaseUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}
