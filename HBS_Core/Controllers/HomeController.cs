using BOL;
using BOL.Data;
using HBS_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace HBS_Core.Controllers
{
    public class HomeController : Controller
    {
        private Istaff _istaff;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, Istaff istaff)
        {
            _logger = logger;
            _istaff = istaff;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var staf = _istaff.login(username, password);
                if (staf == null)
                {
                    ViewBag.error = "please verfiy Email or Password";
                }
                else
                {                    
                    return RedirectToAction("index", "Booking", new { id = staf.Id });
                }
            }
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            //render empty html form only
            return View();
        }
        [HttpPost]
        public IActionResult Register(staff staff)
        {
           
                var result = _istaff.Register(staff);

                if (result == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Please contact Adminstor";
                }
            
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}