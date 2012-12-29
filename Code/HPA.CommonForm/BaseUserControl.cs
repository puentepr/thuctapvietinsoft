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
    }
}
