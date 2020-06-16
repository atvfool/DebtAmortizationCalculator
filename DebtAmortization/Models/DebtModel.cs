using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DebUtilities;

namespace DebtAmortization.Models
{
    public class DebtModel
    {
        public string Name { get; set;}
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Amount { get; set; }
        public decimal APR { get; set; }
        public decimal Payment { get; set; }
        public Amortization AmortizationSchedule { get; set; }
    }
}
