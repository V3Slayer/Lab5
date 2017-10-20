using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab5.Models;

namespace Lab5.Controllers
{
    public class PersonController : Controller
    {
        private static List<Person> People = new List<Person>();

        public PersonController()
        {
        //    if (People.Count() == 0)
        //    {
        //        Person p = new Person
        //        {
        //            FirstName = "",
        //            LastName = "",
        //            BirthDate = DateTime.Now.ToShortDateString()
        //        };
        //        People.Add(p);
        //    }
        }

        public IActionResult Index(String id)
        {
            if (id == "Delete" && People.Count() > 0)
            {
                People.RemoveRange(0, People.Count());
            }
            if (People.Count() == 0)
                ViewData["NoPerson"] = "No person available";
            return View(People);
        }

        public IActionResult AddPerson(int? id)
        {
            Person p;
            if (id == null)
            {
                p = new Person
                {
                    FirstName = "Shaun",
                    LastName = "Carroll",
                    BirthDate = new DateTime(1995, 7, 14).ToShortDateString()
                };
            }
            else
            {
                p = People.Find(prod => prod.Age == id);
            }
            id = null;
            return View(p);
        }

        public IActionResult EnterPerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterPerson(Person p)
        {
            if (ModelState.IsValid)
            {
                People.Add(p);
                return View("AddPerson", p);
            }
            else
            {
                return View();
            }
        }
    }
}