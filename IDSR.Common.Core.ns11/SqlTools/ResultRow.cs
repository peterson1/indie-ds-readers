using System;
using System.Collections.Generic;
using System.Linq;
using Repo2.Core.ns11.Exceptions;

namespace IDSR.Common.Core.ns11.SqlTools
{
    public class ResultRow : Dictionary<string, object>
    {

        public string AsStr(int columnIndex)
            => Values.ToArray()[columnIndex].ToString();

        public string AsStr(string columnName)
            => Val(columnName).ToString();


        public char AsChar(int columnIndex, int charIndex = 0)
            => AsStr(columnIndex)[charIndex];


        public DateTime AsDate(int columnIndex)
            => DateTime.Parse(AsStr(columnIndex));


        public decimal GetDec(int columnIndex)
            => ToDec(AsStr(columnIndex));

        public decimal GetDec(string columnName)
            => ToDec(Val(columnName).ToString());


        public decimal? AsDec_(int columnIndex)
        {
            decimal d;
            return decimal.TryParse(AsStr(columnIndex), out d)
                    ? d : (decimal?)null;
        }

        public decimal? AsDec_(string columnName)
        {
            decimal d;
            return decimal.TryParse(AsStr(columnName), out d)
                    ? d : (decimal?)null;
        }


        public int AsInt(int columnIndex)
            => ToInt(AsStr(columnIndex));

        public int AsInt(string columnName)
            => ToInt(Val(columnName).ToString());

        public int? AsInt_(string columnName)
        {
            int val;
            return int.TryParse(AsStr(columnName), out val)
                ? val : (int?)null;
        }

        private object Val(string key)
        {
            object o;
            if (TryGetValue(key, out o)) return o;
            throw Fault.NoMember(key);
        }



        private static decimal ToDec(string text, decimal multiplier = 1.00M)
        {
            decimal val; var ok = decimal.TryParse(text, out val);
            if (ok) return val * multiplier;
            throw new FormatException($"Non-convertible to Decimal: “{text}”.");
        }


        private static int ToInt(string text)
        {
            int val; var ok = int.TryParse(text, out val);
            if (ok) return val;
            throw new FormatException($"Non-convertible to Int32: “{text}”.");
        }
    }
}
