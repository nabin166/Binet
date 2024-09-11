using BinetWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BinetWebsite.Controllers
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
        public IActionResult Modalsection()
        {
            return PartialView();
        }
        public IActionResult Homesection()
        {
            return PartialView();
        }

        public IActionResult Navbar()
        {
            return PartialView();
        }
        public IActionResult Aboutus()
        {
            return PartialView();
        }
        public IActionResult Inhouseprojcet()
        {
            return PartialView();
        }
        public IActionResult Ourservice()
        {
            return PartialView();
        }
        public IActionResult Bepartoftech()
        {
            return PartialView();
        }
        public IActionResult Testimonial()
        {
            return PartialView();
        }
        public IActionResult Getintouch()
        {
            return PartialView();
        }
        public IActionResult Technologyused()
        {
            return PartialView();
        }
        public IActionResult Trustedby()
        {
            return PartialView();
        }
        public IActionResult Careerpage()
        {
            return View();
        }
        public IActionResult Applynow()
        {
            return View();
        }
        [HttpGet("Invest/{id}")]
        public IActionResult Invest(int id)
        {
            return View();
        }

        public IActionResult Footer()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult Activeint(int id)
        {
            ViewBag.id = id;
            return Json(id);
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
