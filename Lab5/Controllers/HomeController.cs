using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Name"] = "Lab4";

            //Create instance variable of the current date and time.
            DateTime today = DateTime.Now;
            //DateTime today = new DateTime(2019, 12, 29, 0, 30, 0); 

            //Checks the current hour and passes apprpriate greeting.
            int currentHour = today.Hour;
            if (currentHour < 12)
            {
                ViewData["Greeting"] = "Good Morning!";
                
            }
            else if(currentHour < 18)
            {
                ViewData["Greeting"] = "Good Afternoon!";
            }
            else
            {
                ViewData["Greeting"] = "Good Evening!";
            }

            //Get the total of days left based on if this year was a leap year.
            int totalDays = DateTime.IsLeapYear(today.Year) ? 366 : 365;
            int daysLeft = totalDays - today.DayOfYear;

            //Pass the data along to the appropriate entries.
            ViewData["Time"] = today.ToShortTimeString();
            ViewData["Date"] = today.ToLongDateString();
            ViewData["Days"] = daysLeft;
            ViewData["Year"] = today.Year;
            return View();
        }

        public IActionResult Page2(int id)
        {
            string[] items = { "C#", "HTML5", "CSS3", "JavaScript", "Visual Basic" };
            ViewData["ID"] = id;
            return View(items);
        }
    }
}