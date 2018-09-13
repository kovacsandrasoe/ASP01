using ElsoOra.ViewModels;
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

        [HttpPost]
        public IActionResult HitelSzamolo
            (string nev, double osszeg, double kamat, int futamido)
        {
            double[,] matrix = new double[futamido, 5];
            double torleszto = osszeg / futamido;
            double sum = 0;
            for (int i = 0; i < futamido; i++)
            {
                matrix[i, 0] = i + 1;
                matrix[i, 1] = osszeg;
                matrix[i, 2] = osszeg * (kamat / 100);
                matrix[i, 3] = torleszto;
                matrix[i, 4] = torleszto + (osszeg * (kamat / 100));

                sum += torleszto + (osszeg * (kamat / 100));

                osszeg -= torleszto;
            }

            HitelViewModel hvm = new HitelViewModel()
            {
                Nev = nev,
                Matrix = matrix,
                Osszesen = sum
            };

            return View(hvm);
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
