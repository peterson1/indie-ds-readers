using System.Windows;
using Autofac;
using Autofac.Core;
using IDSR.CondorReader.Lib.WPF.ComponentRegistry;
using IDSR.CondorReader.Lib.WPF.Viewer;
using Repo2.SDK.WPF45.Exceptions;
using Repo2.SDK.WPF45.Extensions.IOCExtensions;

namespace IDSR.CondorReader.Viewer.WPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var win = new MainWindow();
            try
            {
                using (var scope = CondorReaderIoC.BeginScope())
                {
                    var vm = scope.Resolve<ViewerMainWindowVM>();
                    win.DataContext = vm;
                }
                win.Show();
            }
            catch (DependencyResolutionException ex)
            {
                Alerter.ShowError("Resolver Error", ex.GetMessage());
                win.Close();
            }
        }
    }
}
