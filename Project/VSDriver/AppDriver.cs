using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System;
using System.Diagnostics;

namespace VSDriver
{
    public class AppDriver : IDisposable
    {
        public WindowsAppFriend App { get; private set; }

        public MainWindowDriver MainWindow { get; private set; }

        public AppDriver(Process process)
        {
            App = new WindowsAppFriend(process);
            MainWindow = new MainWindowDriver(App);
            WindowsAppExpander.LoadAssembly(App, GetType().Assembly);
        }

        ~AppDriver()
        {
            Dispose();
        }

        public OutputWindowDriver AttachOutputWindow()
        {
            return new OutputWindowDriver(App);
        }

        public void Dispose()
        {
            App.Dispose();
        }
    }
}