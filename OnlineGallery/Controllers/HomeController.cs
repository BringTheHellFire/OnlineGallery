using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineGallery.Models;
using System.Diagnostics;
using System.Text.Json;

namespace OnlineGallery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            this.FillDropdownValues();
            return View();
        }
        [HttpPost]
        public IActionResult Contact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        private void FillDropdownValues()
        {
            var selectItems = new List<SelectListItem>();

            selectItems.Add(new SelectListItem("-choose one-", ""));
            selectItems.Add(new SelectListItem("Croatia", "0"));
            selectItems.Add(new SelectListItem("Germany", "1"));
            selectItems.Add(new SelectListItem("England", "2"));

            ViewBag.CountryItems = selectItems;
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}