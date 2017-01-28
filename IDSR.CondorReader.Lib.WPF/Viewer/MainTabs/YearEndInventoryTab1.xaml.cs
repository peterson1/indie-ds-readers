using System.Windows.Controls;
using Repo2.SDK.WPF45.Extensions.DataGridExtensions;

namespace IDSR.CondorReader.Lib.WPF.Viewer.MainTabs
{
    public partial class YearEndInventoryTab1 : UserControl
    {
        public YearEndInventoryTab1()
        {
            InitializeComponent();
            Loaded += (a, b) =>
            {
                dg.EnableToggledColumns(DataGridLengthUnitType.Auto);
            };
        }
    }
}
