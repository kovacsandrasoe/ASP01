using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElsoOra.Controllers
{
    public class HomeController : Controller
    {
        Random r;

        public HomeController()
        {
            r = new Random();
        }

        public IActionResult Hitel()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sorsol()
        {
            int jegy = r.Next(1, 6);
            return View(jegy);
        }
    }
}
