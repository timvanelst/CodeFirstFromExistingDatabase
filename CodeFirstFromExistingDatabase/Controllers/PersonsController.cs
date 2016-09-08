using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirstFromExistingDatabase.Models;
using DAL.Data;
using DAL.Repositories;

namespace CodeFirstFromExistingDatabase.Controllers
{
    public class PersonsController : Controller
    {
        private GenericRepository<Person> repo;
        
        public PersonsController()
        {
            var context = new SchoolContext();
            this.repo = new GenericRepository<Person>(context);
        }

        //
        // GET: /Person/
        public ActionResult Index()
        {
            //var context = new SchoolContext();
            //var personsDbSet = context.Set<Person>();
            //List<Person> persons = personsDbSet.ToList();

            List<Person> persons = repo.Get().ToList();

            var model = new PersonsModel
                {
                    Persons = persons.Select(p => new PersonModel 
                    { 
                        Name = p.FirstName + ((!string.IsNullOrWhiteSpace(p.Prefix)) ? " " + p.Prefix : string.Empty ) + " " + p.LastName
                    }).ToList()
                };
            return View(model);
        }
	}
}