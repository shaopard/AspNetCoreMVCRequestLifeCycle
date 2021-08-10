using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleMVCRequestLifeCycle.Filters;
using SampleMVCRequestLifeCycle.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMVCRequestLifeCycle.Controllers
{
    [TypeFilter(typeof(OutageAuthorizationFilter))]
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

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/contact-us", Name = "Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [Route("/contact-us", Name = "Contact")]
        public IActionResult Contact([FromForm] Contact info)
        {
            // Contact logic

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }

    public class Contact
    {
        public string Name { get; set; }
        public string Message { get; set; }

    }
}
