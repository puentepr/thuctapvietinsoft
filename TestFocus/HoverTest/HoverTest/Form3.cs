using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoverTest
{
    public partial class Form3 : Form
    {
        int count=0;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //txt1.GotFocus += txt1_GotFocus;
            BUS bu = new BUS();
            bu.LoadAddGotFocus(this);
            //colorPickEdit1.GotFocus += colorPickEdit1_GotFocus;
        }

        void colorPickEdit1_GotFocus(object sender, EventArgs e)
        {
            //label12.Text = colorPickEdit1.Location.ToString();
        }

        void txt1_GotFocus(object sender, EventArgs e)
        {
            Control ctrlChild = (Control)sender;
            Label lbltemp1 = new Label();
            Point p = ctrlChild.Location;
            lbltemp1.Text = "Focus";
            lbltemp1.AutoSize = true;
            lbltemp1.Visible = true;
            lbltemp1.Location = new Point((int)p.X + ctrlChild.Size.Width + 5, (int)p.Y);
            this.Controls.Add(lbltemp1);
        }
        private void labelControl5_Click(object sender, EventArgs e)
        {

        }
    }
}
