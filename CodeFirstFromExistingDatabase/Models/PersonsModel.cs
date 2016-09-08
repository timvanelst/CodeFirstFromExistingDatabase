using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstFromExistingDatabase.Models
{
    public class PersonsModel
    {
        public PersonsModel()
        {
            Persons = new List<PersonModel>();
        }

        public List<PersonModel> Persons { get; set; }
    }

    public class PersonModel
    {
        public string Name { get; set; }
    }
}