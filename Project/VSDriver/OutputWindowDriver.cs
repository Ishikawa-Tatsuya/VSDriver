using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using RM.Friendly.WPFStandardControls;
using System;
using System.Diagnostics;
using System.Windows;

namespace VSDriver
{
    public class OutputWindowDriver
    {
        dynamic _outputWindow;
        dynamic _wpfTextView;

        public WPFComboBox ComboBoxSource { get; private set; }

        public OutputWindowDriver(WindowsAppFriend app)
        {
            _outputWindow = IdentifyOutputWindow(app);
            _wpfTextView = VisualTreeUtility.IdentifyDescendantByTypeFullName(_outputWindow, "Microsoft.VisualStudio.Text.Editor.Implementation.WpfTextView");
            ComboBoxSource = new WPFComboBox(IdentifyOutputComboBox(_outputWindow));
        }

        public string GetOutputText()
        {
            return _wpfTextView.TextSnapshot.GetText();
        }

        static dynamic IdentifyOutputComboBox(dynamic outputWindow)
        {
            var view = VisualTreeUtility.IdentifyAncestorByTypeFullName(outputWindow, "Microsoft.VisualStudio.PlatformUI.Shell.Controls.ViewPresenter");
            return VisualTreeUtility.IdentifyDescendantByTypeFullName(view, "Microsoft.VisualStudio.PlatformUI.VsComboBox");
        }

        static dynamic IdentifyOutputWindow(WindowsAppFriend app)
        {
            foreach (dynamic w in app.Type<Application>().Current.Windows)
            {
                var outputs = new WindowControl(w).GetFromTypeFullName("Microsoft.VisualStudio.PlatformUI.OutputWindow");
                if (outputs.Length != 0)
                {
                    return outputs[0];
                }
            }
            throw new NotSupportedException("Not found output.");
        }

    }
}
