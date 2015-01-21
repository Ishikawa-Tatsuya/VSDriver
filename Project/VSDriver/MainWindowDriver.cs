using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using RM.Friendly.WPFStandardControls;

namespace VSDriver
{
    public class MainWindowDriver
    {
        public WindowControl Window { get; private set; }

        public WPFMenuBase MainMenu { get; private set; }

        public MainWindowDriver(WindowsAppFriend app)
        {
            Window = WindowControl.WaitForIdentifyFromTypeFullName(app, "Microsoft.VisualStudio.PlatformUI.MainWindow");
            MainMenu = new WPFMenuBase(Window.IdentifyFromTypeFullName("Microsoft.VisualStudio.PlatformUI.VsMenu"));
        }
    }
}
