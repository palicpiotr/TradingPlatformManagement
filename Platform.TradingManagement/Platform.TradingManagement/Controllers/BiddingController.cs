using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Platform.TradingManagement.Controllers
{
    public class BiddingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}