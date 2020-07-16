using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DebtAmortization.Models;
using DebUtilities;
using DebtData;
using Remotion.Linq.Parsing.Structure.NodeTypeProviders;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System.Net;

namespace DebtAmortization.Controllers
{
    public class DebtController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Results(int ID)
        {
            DebtModel debtModel = new DebtModel();

            // Save code goes here
            Data data = new Data();
            Debt debt = data.connection.FirstOrDefault<Debt>("WHERE ID = @0", ID);

            if(debt != null)
            {
                Amortization amortization = new Amortization(debt);

                debtModel.Name = debt.Name;
                debtModel.Amount = debt.Amount;
                debtModel.APR = debt.Interest;
                debtModel.Payment = debt.MinPayment;
                debtModel.AmortizationSchedule = amortization;
            }
            

            return View(debtModel);
        }

        public IActionResult Edit(int ID)
        {
            DebtModel debtModel = new DebtModel();

            // Save code goes here
            Data data = new Data();
            Debt debt = data.connection.FirstOrDefault<Debt>("WHERE ID = @0", ID);

            if (debt != null)
            {
                debtModel.Name = debt.Name;
                debtModel.Amount = debt.Amount;
                debtModel.APR = debt.Interest;
                debtModel.Payment = debt.MinPayment;
            }


            return View(debtModel);
        }


        [HttpPost]
        public void Add(DebtModel debtModel)
        {
            string Name = debtModel.Name;
            decimal Amount = 0;
            decimal APR = 0;
            decimal Payment = 0;

            decimal.TryParse(debtModel.Amount.ToString(), out Amount);
            decimal.TryParse(debtModel.APR.ToString(), out APR);
            decimal.TryParse(debtModel.Payment.ToString(), out Payment);

            APR /= 100;

            // Save code goes here
            Data data = new Data();
            Debt debtToAdd = new Debt()
            {
                Name = Name,
                Amount = Amount,
                DueDay = 1,
                Interest = APR,
                MinPayment = Payment,
            };

            data.Insert(debtToAdd);


            Response.Redirect("/Debt/List");
        }

        public IActionResult List()
        {
            List<DebtModel> debtModels = new List<DebtModel>();

            Data data = new Data();
            List<Debt> debts = data.connection.Fetch<Debt>("SELECT * FROM Debt WHERE UserID = 1");

            debts.ForEach(x => debtModels.Add(new DebtModel
            {
                ID = x.ID,
                Name = x.Name,
                Amount = x.Amount,
                APR = x.Interest,
                Payment = x.MinPayment,
            }));

            return View(debtModels);
        }

        [HttpPost]
        public ActionResult DeleteAccount(string accountID)
        {
            ActionResult result;

            Data data = new Data();
            if(data.connection.Delete<Debt>("WHERE ID = @0", accountID) > 0)
            {
                result = Json(new {success =true, status = "success", message = "Deleted" });

                Response.StatusCode = (int)HttpStatusCode.OK;
            }
            else
            {
                result = Json(new {success=false, status = "error", message = "Error" });

                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            return result;
        }

        public ActionResult Add()
        {
            return View();
        }

    }
}