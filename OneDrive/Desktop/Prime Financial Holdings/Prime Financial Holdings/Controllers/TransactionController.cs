using Microsoft.AspNetCore.Mvc;
using Prime_Financial_Holdings.Data;
using Prime_Financial_Holdings.Models;

namespace Prime_Financial_Holdings.Controllers
{
    public class TransactionController : Controller
    {

        private readonly DbContextApplic _db;

        public TransactionController(DbContextApplic db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Transaction> obj = _db.FetchTransactions(HomeController.loggedInAccount);
            return View(obj);
        }

      
    }
}
