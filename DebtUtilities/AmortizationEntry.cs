using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtUtilities
{
    public class AmortizationEntry
    {
        public int Month { get; set; }
        public decimal AmountRemaining { get; set; }
        public decimal Payment { get; set; }
        public decimal InterestPaid { get; set; }
        public decimal ExtraPayment { get; set; }
    }
}
