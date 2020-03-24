using DataAdapter.Models;
using DataAdapter.Repository;
using Ninject;
using System.Linq;
using System.Web.Mvc;

namespace AnreshTaskWeb.Controllers
{
    public class PersonController : Controller
    {
        
        private IPersonRepository personRepository;
        
        public PersonController()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IPersonRepository>().To<PersonRepository>();
            personRepository = ninjectKernel.Get<IPersonRepository>();
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

        public ActionResult Create()
        {
            return View();
        }

        // GET: /Person/Edit/1
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Person obj = personRepository.FindByID(id.Value);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(obj);

        }
        // POST: /Person/Edit   
        [HttpPost]
        public ActionResult Edit(Person obj)
        {

            if (ModelState.IsValid)
            {
                personRepository.Update(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        // GET:/Person/Delete/1
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }
            personRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }
    }
}