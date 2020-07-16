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
        [Microsoft.AspNetCore.Mvc.HiddenInput]
        public int ID { get; set; }
        [Display(Name="Name")]
        [Required(ErrorMessage ="Debt Name is required.")]
        public string Name { get; set;}

        [Display(Name = "Amount")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Required(ErrorMessage = "Amount is required.")]
        public decimal Amount { get; set; }

        [Display(Name = "APR")]
        [Required(ErrorMessage = "Interest is required.")]
        public decimal APR { get; set; }

        [Display(Name = "Payment")]
        [Required(ErrorMessage = "Payment is required.")]
        public decimal Payment { get; set; }
        public Amortization AmortizationSchedule { get; set; }
    }
}
