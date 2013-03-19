using System;
using DevExpress.XtraRichEdit;
using DevExpress.XtraSpellChecker;
using DevExpress.Xpf.Ribbon;
using DevExpress.Xpf.SpellChecker;

namespace Paradise5
{
    public partial class CreatAnnouncement : RichEditDemoModule
    {
        public CreatAnnouncement()
        {
            InitializeComponent();
        }

        void richEdit_SelectionChanged(object sender, EventArgs e)
        {
            bool isSelectionInFloatingObject = richEdit.IsFloatingObjectSelected;
            if (catPictureTools.IsVisible != isSelectionInFloatingObject)
            {
                catPictureTools.IsVisible = isSelectionInFloatingObject;
                if (isSelectionInFloatingObject)
                    ribbonControl.SelectedPage = pagePictureToolsFormat;
            }
        }
    }
}
