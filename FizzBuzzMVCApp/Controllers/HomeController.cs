using FizzBuzzMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FizzBuzzMVCApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
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

        [HttpGet]
        public IActionResult FizzBuzz()
        {
            FizzBuzz model = new()
            {
                FizzValue = 3,
                BuzzValue = 5
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FizzBuzz(FizzBuzz fizzBuzz)
        {
            bool fizz;
            bool buzz;
            List<string> fbItems = new();
            

            for (int i = 1; i <= 100; i++)
            {
                fizz = (i % fizzBuzz.FizzValue == 0);
                buzz = (i % fizzBuzz.BuzzValue == 0);

                if (fizz && buzz)
                {
                    fbItems.Add("FizzBuzz");
                }
                else if (fizz)
                {
                    fbItems.Add("Fizz");
                }
                else if (buzz)
                {
                    fbItems.Add("Buzz");
                }
                else
                {
                    fbItems.Add(i.ToString());
                }
            }

            fizzBuzz.Result = fbItems;


            return View(fizzBuzz);
        }
    }
}