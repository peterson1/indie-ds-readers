using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDSR.CondorReader.Lib.WPF.Viewer
{
    public class ViewerMainWindowVM
    {
        public ViewerMainWindowVM(DbLoaderVM dbLoaderVM)
        {
            DbLoader = dbLoaderVM;
        }



        public DbLoaderVM DbLoader { get; }
    }
}
