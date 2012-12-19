using DevExpress.XtraBars.Docking2010.Views.MetroUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DelegateAction setWin8Theme = new DelegateAction(canApplyWin8Theme,ApplyWin8Theme);
            setWin8Theme.Type = ActionType.Context;
            setWin8Theme.Caption = "Set Win8 Theme";
            setWin8Theme.Behavior = ActionBehavior.HideBarOnClick;
            setWin8Theme.Edge = ActionEdge.Left;
            metroUIView1.ContentContainerActions.Add(setWin8Theme);

            DelegateAction setDefaultTheme = new DelegateAction(canApplyDefaultTheme,ApplyDefaultTheme);
            setWin8Theme.Type = ActionType.Context;
            setWin8Theme.Caption = "Set Default Theme";
            setWin8Theme.Behavior = ActionBehavior.HideBarOnClick;
            setWin8Theme.Edge = ActionEdge.Left;
            metroUIView1.ContentContainerActions.Add(setDefaultTheme);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private bool canApplyWin8Theme()
        {
            return DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName != "Metropolis";
        }

        private void ApplyWin8Theme()
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Metropolis");
        }
        private bool canApplyDefaultTheme()
        {
            return DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName != "DevExpress Style";
        }
        private void ApplyDefaultTheme()
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
        }

        private void metroUIView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            e.Control = new Control();
        }
    }
}
