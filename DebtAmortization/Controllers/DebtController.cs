using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DebtAmortization.Models;
using DebtAmortization.Classes;

namespace DebtAmortization.Controllers
{
    public class DebtController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Index()
        {
            DebtModel debtModel = new DebtModel();

            string Name = Request.Form["txtName"];
            double Amount;
            double APR;
            double Payment;

            double.TryParse(Request.Form["numAmount"].ToString(), out Amount);
            double.TryParse(Request.Form["numAPR"].ToString(), out APR);
            double.TryParse(Request.Form["numPayment"].ToString(), out Payment);


            Amortization amortization = new Amortization(Name, Amount, APR, Payment);

            debtModel.Name = Name;
            debtModel.Amount = Amount;
            debtModel.APR = APR;
            debtModel.Payment = Payment;
            debtModel.AmortizationSchedule = amortization;

            return View(debtModel);
        }
    }
}