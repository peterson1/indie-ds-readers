using Repo2.Core.ns11.Extensions.StringExtensions;
using System;

namespace IDSR.CondorReader.Core.ns11.Converters
{
    public static class StringToBarCodeConverter
    {
        public static ulong ToBarCode(this string strCode, string recordLabel)
        {
            var trimmed = strCode.Trim().TrimStart('0')
                                        .TrimEnd  ('A');

            if (ulong.TryParse(trimmed, out ulong barCode))
                return barCode;

            throw new InvalidCastException("BarCode Parse Error" + L.F +
                $"Failed to process “{recordLabel}”" + L.F +
                $"Invalid barcode “{strCode}”.");
        }
    }
}
