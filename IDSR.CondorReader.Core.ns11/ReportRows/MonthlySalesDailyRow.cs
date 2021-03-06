﻿using System;
using System.Collections.Generic;
using System.Linq;
using IDSR.CondorReader.Core.ns11.DomainModels;

namespace IDSR.CondorReader.Core.ns11.ReportRows
{
    public class MonthlySalesDailyRow
    {
        public MonthlySalesDailyRow(IGrouping<DateTime, FinishedSale> grp)
        {
            Date      = grp.Key;
            Terminals = GroupByTerminal(grp);
        }


        public DateTime  Date { get; }
        public List<MonthlySalesTerminalRow> Terminals { get; }


        public double VatableSales => Terminals.Sum(x => x.VatableSales);
        public double OutputVat    => Terminals.Sum(x => x.OutputVat);
        public double DailyTotal   => Terminals.Sum(x => x.TerminalTotal);
        public double VatExempt    => Terminals.Sum(x => x.VatExempt);


        private List<MonthlySalesTerminalRow> GroupByTerminal(IGrouping<DateTime, FinishedSale> items)
            => items.GroupBy (x => x.TerminalNo)
                    .Select  (x => new MonthlySalesTerminalRow(x))
                    .OrderBy (x => x.Terminal)
                    .ToList  ();
    }
}
