using AD_Manager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AD_Manager.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return RedirectToAction("Admin", "User");
        }

        public IActionResult Technician()
        {
            return RedirectToAction("Technician", "User");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}