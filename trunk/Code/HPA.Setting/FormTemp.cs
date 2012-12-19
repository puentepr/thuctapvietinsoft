using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HPA.Setting
{
    public partial class FormTemp : Form
    {
        public FormTemp()
        {
            InitializeComponent();
        }

        private void FormTemp_Load(object sender, EventArgs e)
        {

        }

        private void formCauTrucCongtyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCautrucCongty fct = new FormCautrucCongty();
            fct.Show();
        }
    }
}
