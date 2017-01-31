using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Repo2.SDK.WPF45.Extensions.DataGridExtensions;

namespace IDSR.CondorReader.Lib.WPF.Viewer.DataGrids
{
    public partial class ReceivingLinesTable1 : UserControl
    {
        public ReceivingLinesTable1()
        {
            InitializeComponent();
            Loaded += (a, b) =>
            {
                dg.EnableToggledColumns();
            };
        }
    }
}
