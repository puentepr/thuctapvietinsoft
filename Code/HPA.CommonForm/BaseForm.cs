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
        private string _fullClassName;

        public string FullClassName
        {
            get { return _fullClassName; }
            set { _fullClassName = value; }
        }
        public BaseForm()
        {
            if (!HasAccessRight())
            {
                HPA.Common.Methods.ShowMessage(HPA.Common.CommonConst.NO_RIGHT_TO_ACCESS);
                this.Dispose();
                this.Close();
            }
            InitializeComponent();
        }

        private bool HasAccessRight()
        {
            HPA.SQL.DataDaigramDataContext sqlcon = new SQL.DataDaigramDataContext();
            if (sqlcon.SC_USEROBJECTRIGHT_GET(FullClassName, HPA.Common.StaticVars.UserID) <= 0)
                return false;
            else
                return true;
        }
    }
}