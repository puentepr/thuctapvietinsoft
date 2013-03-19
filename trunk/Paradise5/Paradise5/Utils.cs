using System;
using System.IO;
using System.Reflection;
using System.Windows;
using DevExpress.DemoData.Helpers;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.DemoBase;
using DevExpress.Xpf.DemoBase.Helpers;
using DevExpress.Xpf.RichEdit;
using DevExpress.XtraRichEdit;

namespace Paradise5 {
    public class DemoUtils {
        public static string GetRelativePath(string name) {
            return DemoHelper.GetPath("RichEditDemo.Data.", typeof(DemoUtils).Assembly) + name;
        }
        public static Stream GetDataStream(string fileName) {
            string path = DemoUtils.GetRelativePath(fileName);
            if (!String.IsNullOrEmpty(path))
                return Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            return null;
        }
        //public static void SetConnectionString(System.Data.OleDb.OleDbConnection oleDbConnection, string path) {
        //    oleDbConnection.ConnectionString = String.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;User ID=Admin;Data Source={0};Mode=Share Deny None;Extended Properties="""";Jet OLEDB:System database="""";Jet OLEDB:Registry Path="""";Jet OLEDB:Database Password="""";Jet OLEDB:Engine Type=5;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:New Database Password="""";Jet OLEDB:Create System Database=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False", path);
        //}
    }
    public class RtfLoadHelper {
        public static void Load(String fileName, RichEditControl richEditControl) {
            string path = DemoUtils.GetRelativePath(fileName);
            if (!String.IsNullOrEmpty(path)) {
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
                richEditControl.LoadDocument(stream, DocumentFormat.Rtf);
            }
        }
    }
    public class DocLoadHelper {
        public static void Load(String fileName, RichEditControl richEditControl) {
            string path = DemoUtils.GetRelativePath(fileName);
            if (!String.IsNullOrEmpty(path)) {
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
                richEditControl.LoadDocument(stream, DocumentFormat.Doc);
            }
        }
    }
    public class HtmlLoadHelper {
        public static void Load(String fileName, RichEditControl richEditControl) {
            string path = DemoUtils.GetRelativePath(fileName);
            if (!String.IsNullOrEmpty(path)) {
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
                richEditControl.LoadDocument(stream, DocumentFormat.Html);
            }
        }
    }
    public class OpenXmlLoadHelper {
        public static void Load(String fileName, RichEditControl richEditControl) {
            string path = DemoUtils.GetRelativePath(fileName);
            if (!String.IsNullOrEmpty(path)) {
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
                richEditControl.LoadDocument(stream, DocumentFormat.OpenXml);
            }
        }
    }
    public class PlainTextLoadHelper {
        public static void Load(String fileName, RichEditControl richEditControl) {
            string path = DemoUtils.GetRelativePath(fileName);
            if (!String.IsNullOrEmpty(path)) {
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
                richEditControl.LoadDocument(stream, DocumentFormat.PlainText);
            }
        }
    }
    public class CodeFileLoadHelper {
        public static void Load(string moduleName, RichEditControl richEditControl) {
            Stream stream = DemoHelper.GetCodeTextStream(typeof(CodeFileLoadHelper).Assembly, moduleName, DemoHelper.GetDemoLanguage(typeof(CodeFileLoadHelper).Assembly));
            if (stream != null)
                richEditControl.LoadDocument(stream, DocumentFormat.PlainText);
        }
        public static string GetCodeFileName(String moduleName) {
            return String.Format("{0}.xaml{1}", moduleName, DemoHelper.GetCodeSuffix(typeof(CodeFileLoadHelper).Assembly));
        }
    }
    public class RichEditDemoExceptionsHandler {
        readonly RichEditControl control;
        public RichEditDemoExceptionsHandler(RichEditControl control) {
            this.control = control;
        }
        public void Install() {
            if (control != null)
                control.UnhandledException += OnRichEditControlUnhandledException;
        }

        void OnRichEditControlUnhandledException(object sender, RichEditUnhandledExceptionEventArgs e) {
            try {
                if (e.Exception != null)
                    throw e.Exception;
            }
            catch (RichEditUnsupportedFormatException ex) {
                ShowMessage(ex.Message);
                e.Handled = true;
            }
            catch (System.Runtime.InteropServices.ExternalException ex) {
                ShowMessage(ex.Message);
                e.Handled = true;
            }
            catch (System.IO.IOException ex) {
                ShowMessage(ex.Message);
                e.Handled = true;
            }
            catch (System.InvalidOperationException ex) {
                if (ex.Message == DevExpress.XtraRichEdit.Localization.XtraRichEditLocalizer.GetString(DevExpress.XtraRichEdit.Localization.XtraRichEditStringId.Msg_MagicNumberNotFound) ||
                    ex.Message == DevExpress.XtraRichEdit.Localization.XtraRichEditLocalizer.GetString(DevExpress.XtraRichEdit.Localization.XtraRichEditStringId.Msg_UnsupportedDocVersion)) {
                    ShowMessage(ex.Message);
                    e.Handled = true;
                }
                else throw ex;
            }
            catch (SystemException ex) {
                ShowMessage(ex.Message);
                e.Handled = true;
            }
        }
        void ShowMessage(string message) {
            DXDialog dialog;
            dialog = new DXDialog("RichEdit Demo");
            dialog.Title = "RichEdit Demo";
            dialog.Buttons = DialogButtons.Ok;
            dialog.Content = message;
            dialog.IsSizable = false;
            dialog.Padding = new Thickness(20);
            dialog.ShowDialog();
        }
    }
    /*
    public class DocumentCapabilityToBooleanConverter : IValueConverter {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (targetType != typeof(bool))
                return value;

            DocumentCapability capability = (DocumentCapability)value;
            switch (capability) {
                case DocumentCapability.Default:
                    return true;
                case DocumentCapability.Disabled:
                    return false;
                case DocumentCapability.Enabled:
                    return true;
                case DocumentCapability.Hidden:
                    return false;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if (targetType != typeof(DocumentCapability))
                return value;

            bool val = (bool)value;
            if (val)
                return DocumentCapability.Enabled;
            else
                return DocumentCapability.Hidden;

        }

        #endregion
    }
    */
}
