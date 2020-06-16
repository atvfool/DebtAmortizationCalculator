using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DebtAmortization.Models;
using DebUtilities;
using DebtData;
using Remotion.Linq.Parsing.Structure.NodeTypeProviders;

namespace DebtAmortization.Controllers
{
    public class DebtController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Results()
        {
            DebtModel debtModel = new DebtModel();

            string Name = Request.Form["txtName"];
            decimal Amount = 0;
            decimal APR = 0;
            decimal Payment = 0;

            decimal.TryParse(Request.Form["numAmount"].ToString(), out Amount);
            decimal.TryParse(Request.Form["numAPR"].ToString(), out APR);
            decimal.TryParse(Request.Form["numPayment"].ToString(), out Payment);

            APR /= 100;

            // Save code goes here
            Data data = new Data();
            Debt debtToAdd = new Debt() {
                Name = Name,
                Amount = Amount,
                DueDay = 1,
                Interest = APR,
                MinPayment = Payment,
            };

            data.Insert(debtToAdd);

            Amortization amortization = new Amortization(debtToAdd);

            debtModel.Name = Name;
            debtModel.Amount = Amount;
            debtModel.APR = APR;
            debtModel.Payment = Payment;
            debtModel.AmortizationSchedule = amortization;

            return View(debtModel);
        }
    }
}