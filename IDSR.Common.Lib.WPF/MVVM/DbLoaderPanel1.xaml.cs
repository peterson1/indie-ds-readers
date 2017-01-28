using System;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IDSR.Common.Lib.WPF.MVVM
{
    public partial class DbLoaderPanel1 : UserControl
    {
        public DbLoaderPanel1()
        {
            InitializeComponent();
            Loaded += async (a, b) =>
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                VM.LoadMasterDataCmd.ExecuteIfItCan();
            };
        }


        DbLoaderVmBase VM => DataContext as DbLoaderVmBase;
    }
}
