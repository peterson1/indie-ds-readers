﻿using System.Windows.Controls;
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
