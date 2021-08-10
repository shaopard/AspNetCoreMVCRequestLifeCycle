using Microsoft.AspNetCore.Mvc;
using SampleMVCRequestLifeCycle.Models;
using System.Collections.Generic;

namespace SampleMVCRequestLifeCycle.Controllers
{
    public class OrderController : Controller
    {
        [HttpPost]
        public IActionResult Create(List<Order> orders)
        {
            return Content("Binding successful!");
        }
    }
}
