using Microsoft.AspNetCore.Mvc;
using Prime_Financial_Holdings.Data;
using Prime_Financial_Holdings.Models;

namespace Prime_Financial_Holdings.Controllers
{
    public class AccountController : Controller
    {
        DbContextApplic deebee;

        public AccountController(DbContextApplic db)
        {
                deebee = db;
        }
        public IActionResult Loan()
        {
            return View();
        }

        public IActionResult Cheque()
        {
            if (HomeController.loggedInAccount.requestedCheckbook == false)
            {
                deebee.updateChequeStatus(true, HomeController.loggedInAccount.accountNumber);

            }
            else
            {

            }
            return View();
        }

        public IActionResult LoanApply(Loan obj)
        {
            TempData["Alert Message"] = "Looking good so far";
            Loan loan = deebee.searchLoan(obj.Type);
            if (loan!=null)
            {
                obj.LoanId = loan.LoanId;
              bool flag = deebee.applyForLoan(obj);
                if (!flag)
                {
                    TempData["Alert Message"] = null;
                }
                else
                {
                    TempData["Alert Message"] = "Looking good so far";
                }
            }
            else
            {
                TempData["Alert Message"] = null;
            }
            return View();
        }
    }
}