using System.Windows;
using QuickDownloader.GUI.Utilities;

namespace QuickDownloader.GUI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            // Initialize helpers to register dynamic resources
            ColorHelper.Initialize();
            FontHelper.Initialize();
        }
    }
}
