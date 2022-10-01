using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prime_Financial_Holdings.Data;
using Prime_Financial_Holdings.Models;
using System.Data;

namespace Prime_Financial_Holdings.Controllers
{
    public class HomeController : Controller
    {
        public static Account loggedInAccount { get; set; }
        private DbContextApplic _db;

        public HomeController(DbContextApplic db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult change(User obj)
        {

            User objLogin = _db.verifyUser(obj);
            if (objLogin == null)
            {
                TempData["Alert Message"] = null;
                return RedirectToAction("Index");
            }
            else
            {
                loggedInAccount = _db.getAccount((int)objLogin.AccountNumber);
                Console.WriteLine(loggedInAccount.Name);
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Index");
        }
    }
}
