using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DebtAmortization.Models
{
    public class DebtModel
    {
        public string Name { get; set;}
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Amount { get; set; }
        public double APR { get; set; }
        public double Payment { get; set; }
        public DebtAmortization.Classes.Amortization AmortizationSchedule { get; set; }
    }
}
