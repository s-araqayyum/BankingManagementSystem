using Microsoft.AspNetCore.Mvc;
using Prime_Financial_Holdings.Data;
using Prime_Financial_Holdings.Models;

namespace Prime_Financial_Holdings.Controllers
{
    public class TransferController : Controller
    {
        private DbContextApplic database;

        public TransferController(DbContextApplic db)
        {
            database = db;
        }

        public IActionResult Index(Transaction transaction)
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult makeTransfer(Transaction transaction)
        {

            Account beneficaryAccount = database.getAccount((int)transaction.beneficiaryAccount);
            Account selfAccount = database.getAccount((int)transaction.accountNumber);
            Console.WriteLine(beneficaryAccount.Name);
        
                if (HomeController.loggedInAccount != null)
                {
                    if (beneficaryAccount != null)
                    {
                        if (selfAccount.balance >= transaction.amount)
                        {
                        Console.WriteLine(selfAccount.balance+"----"+transaction.amount);
                        float balanceOwn = selfAccount.balance - transaction.amount;

                        float balanceSend = beneficaryAccount.balance + transaction.amount;

                        database.updateBalance(selfAccount.accountNumber,balanceOwn);
                        database.updateBalance(beneficaryAccount.accountNumber, balanceSend);
                        database.SaveTransaction(transaction,"Transfer Funds");
                    }
                    }
                }
            return RedirectToAction("Index");
        }
    }
}
