using Microsoft.AspNetCore.Mvc;
using Prime_Financial_Holdings.Data;
using Prime_Financial_Holdings.Models;
using System.Web;

namespace Prime_Financial_Holdings.Controllers
{
    public class FeedbackController : Controller
    {
        private DbContextApplic dataBase;

        public FeedbackController(DbContextApplic db)
        {
            dataBase = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Feedback()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Feedback feedback)
        {

            if (feedback.feedbackMessage == null || feedback.userName == null)
            {
                TempData["Alert Message"] = null;
            }

            else
            {
                if (dataBase.SaveFeedback(feedback) == false)
                {
                    TempData["Alert Message"] = null;
                }
                else {
                    TempData["Alert Message"] = "T";
                }
            }
            return RedirectToAction("Feedback");
        }
    }
}
