using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HPA.Common;

namespace HPA.CommonForm
{
    public partial class BaseUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        private object _UserRight;
        private string _Caption;
        public EzSqlCollection.EzSql2 DBEngine = null;
        public BaseUserControl()
        {
            InitializeComponent();
            if (this.DesignMode)
                return;
            if (HPA.Common.StaticVars.ServerName == null)
                return;
            try
            {  

                    DBEngine = new EzSqlCollection.EzSql2(HPA.Common.StaticVars.ServerName, HPA.Common.StaticVars.DatabaseName, HPA.Common.StaticVars.UserID_sql, HPA.Common.StaticVars.Password);
                    DBEngine.open();               
            }
            catch
            {
                //throw new Exception("Can not connect to server"); 
                if (MessageBox.Show("Ket noi lai ko?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    DBEngine = new EzSqlCollection.EzSql2(HPA.Common.StaticVars.ServerName, HPA.Common.StaticVars.DatabaseName, HPA.Common.StaticVars.UserID_sql, HPA.Common.StaticVars.Password);
                    DBEngine.open();
                    MessageBox.Show("ket noi thanh cong");
                }
            }
            if (StaticVars.FullClassName.Equals(string.Empty))
                return;
            object objRight = DBEngine.execReturnValue("SC_USEROBJECTRIGHT_GET", "@p_FullClassName", StaticVars.FullClassName, "@p_LoginID", StaticVars.LoginID);
            if ((objRight == DBNull.Value) || (Convert.ToInt32(objRight) == 0))
            {
                Methods.ShowMessage(CommonConst.NO_RIGHT_TO_ACCESS);
                return;
            }
            else
            {
                _UserRight = objRight;
            }
        }
        public string Caption
        {
            get
            {
                return _Caption;
            }
            set
            {
                _Caption = value;
            }
        }
        public object UserRight
        {
            get
            {
                return _UserRight;
            }
            set
            {
                _UserRight = value;
            }
        }
    }
}
