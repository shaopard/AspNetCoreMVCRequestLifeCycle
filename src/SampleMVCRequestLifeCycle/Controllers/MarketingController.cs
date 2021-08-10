﻿using Microsoft.AspNetCore.Mvc;
using SampleMVCRequestLifeCycle.Filters;

namespace SampleMVCRequestLifeCycle.Controllers
{
    public class MarketingController : Controller
    {
        [MobileRedirectActionFilter(Action = "NewSplash", Controller = "Marketing")]
        public IActionResult Splash()
        {
            return Content("The old splash page.");
        }

        public IActionResult NewSplash()
        {
            return Content("The new splash page.");
        }
    }
}
