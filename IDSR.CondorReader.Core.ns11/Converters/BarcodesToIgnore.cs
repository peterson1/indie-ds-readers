using System.Collections.Generic;

namespace IDSR.CondorReader.Core.ns11.Converters
{
    public class BarcodesToIgnore
    {
        private static List<string> _ignoreList = new List<string>
        {
            "W195321",
            "TWIST",
        };


        public static bool Contains(string barcodeText)
            => _ignoreList.Contains(barcodeText);
    }
}
