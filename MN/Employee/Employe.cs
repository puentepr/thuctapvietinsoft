using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee
{
    public partial class Employe : UserControl
    {
        public DataTable datatable;

        public Employe()
        {
            InitializeComponent();
            const string sql = @"select * from tblEmployee";
            _GREmployee.DataSource= datatable.Select(sql);
            MessageBox.Show("henho......");
        }
    }
}
