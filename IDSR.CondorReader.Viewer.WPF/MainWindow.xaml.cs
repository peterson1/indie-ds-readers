using System.Windows;
using IDSR.CondorReader.Lib.WPF.Viewer;
using Repo2.SDK.WPF45.Extensions.WindowExtensions;

namespace IDSR.CondorReader.Viewer.WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (a, b) =>
            {
                VM.DbLoader.MasterDataLoaded += (c, d) =>
                {
                    this.FitToScreenHeight();
                    this.CenterVertically();
                    this.CenterHorizontally();
                };
            };
        }

        ViewerMainWindowVM VM => DataContext as ViewerMainWindowVM;
    }
}
