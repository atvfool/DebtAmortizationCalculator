using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtAmortization.Classes
{
    public class Amortization
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public double APR { get; set; }
        public double MinPayment { get; set; }
        public double Payment { get; set; }
        
        public Amortization(string Name, double Amount, double APR, double Payment, double MinPayment = 0.0f)
        {
            this.Name = Name;
            this.Amount = Amount;
            this.APR = APR/100;
            this.Payment = Payment;
            this.MinPayment = MinPayment;
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

            double AmountRemaining = Amount;
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

            } while (AmountRemaining > 0.0f);

            return lst;
        }

        /// <summary>
        /// return interest cost for a given amount for 1 month
        /// </summary>
        /// <param name="Amount"></param>
        /// <returns></returns>
        public double getInterestCost(double Amount)
        {
            double cost = 0.0f;

            cost = Amount * APR / 12;

            return cost;
        }
    }
}
