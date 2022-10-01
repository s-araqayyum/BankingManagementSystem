using Microsoft.AspNetCore.Mvc;
using Prime_Financial_Holdings.Data;
using Prime_Financial_Holdings.Models;

namespace Prime_Financial_Holdings.Controllers
{
    public class BillController : Controller
    {
        private DbContextApplic database;
        public BillController(DbContextApplic db)
        {
            database = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MakeBillPayment(Bill obj)
        {
            {
                if (HomeController.loggedInAccount != null)
                {
                    Bill bill = database.FindBill(obj);

                    if (bill != null)
                    {
                        if (bill.paidby == null)
                        {
                            if (HomeController.loggedInAccount.balance >= bill.billAmount)
                            {
                                TempData["Alert Message"] = "Looking good so far";
                                HomeController.loggedInAccount.balance -= bill.billAmount;
                                bill.Account = HomeController.loggedInAccount;
                                Transaction transaction = new Transaction();
                                transaction.accountNumber = HomeController.loggedInAccount.accountNumber;
                                transaction.amount = bill.billAmount;
                                database.updateBalance(HomeController.loggedInAccount.accountNumber, HomeController.loggedInAccount.balance);
                                transaction.beneficiaryAccount = HomeController.loggedInAccount.accountNumber;
                                database.SaveTransaction(transaction, "Bill Payment | " + obj.billReferenceNumber);
                                database.updateBill(bill.billReferenceNumber, HomeController.loggedInAccount.accountNumber);
                            }
                        }
                        else
                        {
                            TempData["Alert Message"] = null;
                        }
                    }
                }
                return RedirectToAction("Index");
            }
        }
    }
}