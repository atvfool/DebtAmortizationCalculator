using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebtData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DebtAmortization.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login()
        {
            string username = Request.Form["txtLogin"];
            string password = Request.Form["txtPassword"];

            Data data = new Data();

            User user = data.connection.FirstOrDefault<User>("WHERE Username = @0", username);

            if(user!=null)
            {
                string hashResult = Classes.Hashes.ComputeHash(password, user.Salt);

                if (hashResult == user.Password)
                {
                    HttpContext.Session.SetString("IsAuthenticated", "true");
                    string redirect = "/";
                    if (Request.Form.Keys.Contains("txtRedirect") && Request.Form["txtRedirect"] != string.Empty)
                        redirect = Request.Form["txtRedirect"];

                    return Redirect(redirect);
                }
            }

            return Redirect("/Login");
        }
    }
}
