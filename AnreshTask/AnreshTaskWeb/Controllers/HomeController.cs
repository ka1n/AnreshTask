using AnreshTaskWeb.Models;
using AnreshTaskWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnreshTaskWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly PersonRepository personRepository;

        public HomeController()
        {
            personRepository = new PersonRepository();
        }
        // GET: Person
        public ActionResult Index()
        {
            return View(personRepository.FindAll().ToList());
        }


        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(Person ind)
        {
            if (ModelState.IsValid)
            {
                personRepository.Add(ind);
                return RedirectToAction("Index");
            }
            return View(ind);
        }


        // GET:/Person/Delete/1
        public ActionResult Delete(int? id)
        {

            //if (id == null)
            //{
            //    return null();
            //}
            personRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }
    }
}