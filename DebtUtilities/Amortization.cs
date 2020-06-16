using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebtUtilities;
using DebtData;

namespace DebUtilities
{
    public class Amortization
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal APR { get; set; }
        public decimal MinPayment { get; set; }
        public decimal Payment { get; set; }

        public Amortization(Debt debt)
        {
            this.Name = debt.Name;
            this.Amount = debt.Amount;
            this.APR = debt.Interest;
            this.Payment = debt.MinPayment;
            this.MinPayment = debt.MinPayment;
        }

        public Amortization()
        {

        }

        /// <summary>
        /// returns a list of payments over the life of the "loan"
        /// </summary>
        /// <returns></returns>
        public List<AmortizationEntry> getAmortization()
        {
            List<AmortizationEntry> lst = new List<AmortizationEntry>();

            decimal AmountRemaining = Amount;
            AmortizationEntry ae;
            do
            {
                ae = new AmortizationEntry();
                ae.Month = lst.Count;
                ae.InterestPaid = getInterestCost(AmountRemaining);
                ae.AmountRemaining = AmountRemaining - (Payment - ae.InterestPaid);
                ae.Payment = Payment;

                lst.Add(ae);
                AmountRemaining = ae.AmountRemaining;

            } while (AmountRemaining > 0);

            return lst;
        }

        /// <summary>
        /// return interest cost for a given amount for 1 month
        /// </summary>
        /// <param name="Amount"></param>
        /// <returns></returns>
        public decimal getInterestCost(decimal Amount)
        {
            decimal cost = 0;

            cost = Amount * APR / 12;

            return cost;
        }
    }
}
