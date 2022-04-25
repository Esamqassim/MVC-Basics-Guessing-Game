using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppFirst.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()//index file
        {
            return View();
        }
        //added 
        public IActionResult GuessingGame()//About file that u do not have
        {
            //genrate random no.
            Random rnd = new Random();
            var numb = rnd.Next(1,100);
            // Creating and setting Session Int32 Number

            HttpContext.Session.SetInt32("rNumber",numb);
           
            return View();
        }

        [HttpPost]
        public IActionResult GuessingGame(string xNumber)//About file that u do not have
        {
           int intNumber= Int32.Parse(xNumber);
            //get random number session
            int rNumb = (int)HttpContext.Session.GetInt32("rNumber");
           // ViewBag.testMsg= rNumb;
            if ((intNumber% rNumb)==0)
            {
                ViewBag.Msg= "Congratulating you on your success";
                GuessingGame();//restart game to generate new random number

            }
             if(rNumb>intNumber){ ViewBag.Msg = "Your guess is too low! Try again"; }

             if (rNumb <intNumber) { ViewBag.Msg = "Your guess is too high! Try again"; }

            return View();
        }

    }
}
