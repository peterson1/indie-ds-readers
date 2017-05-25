using Repo2.Core.ns11.Extensions.StringExtensions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace IDSR.CondorReader.Core.ns11.Converters
{
    public static class StringToBarCodeConverter
    {
        public static ulong ToBarCode(this string strCode, string recordLabel)
        {
            //var trimmed = strCode.Trim().TrimStart('0')
            //                            .TrimStart('W')
            //                            .TrimStart("1 ")
            //                            .TrimEnd  (".0")
            //                            .TrimEnd  ('A');

            //trimmed = Regex.Replace(trimmed, @"\s+", "");

            var trimmed = strCode.Trim();

            if (!ulong.TryParse(trimmed, out ulong barCode))
                throw new BarcodeParseException(strCode, recordLabel);

            if (barCode < 100000)
                throw new BarcodeParseException(strCode, recordLabel);

            return barCode;

            //throw new InvalidCastException("BarCode Parse Error" + L.F +
            //    $"Failed to process “{recordLabel}”" + L.F +
            //    $"Invalid barcode “{strCode}”.");

        }
    }


    public class BarcodeParseException : InvalidCastException
    {
        public BarcodeParseException(IEnumerable<string> badBarcodes, string dataSource) : base(ToMessage(badBarcodes, dataSource))
        {
        }


        private static string ToMessage(IEnumerable<string> badBarcodes, string dataSource)
            => $"Invalid barcodes from {dataSource}:" 
                    + L.F + string.Join(L.f, badBarcodes);


        public BarcodeParseException(string barcodeText, string recordTitle)
        {
            BarcodeText = barcodeText;
            RecordTitle = recordTitle;
        }

        public string   BarcodeText   { get; }
        public string   RecordTitle   { get; }
        public string   TableName     { get; set; }
    }
}
