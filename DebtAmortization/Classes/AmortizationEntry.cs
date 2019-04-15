using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtAmortization.Classes
{
    public class AmortizationEntry
    {
        public int Month { get; set; }
        public double AmountRemaining { get; set; }
        public double Payment { get; set; }
        public double InterestPaid { get; set; }
        public double ExtraPayment { get; set; }
    }
}
