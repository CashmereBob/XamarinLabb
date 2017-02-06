using System;
using System.Linq;
using System.Collections.Generic;

namespace TestPCL
{
    public class PersonRepo
    {
        public List<Person> Persons { get; set; }
        public PersonRepo()
        {
            Persons = new List<Person>();
            Persons.Add(new TestPCL.Person("Magnus", 30, "Praktikant"));
            Persons.Add(new TestPCL.Person("Robin", 26, "Praktikant"));
            Persons.Add(new TestPCL.Person("Anders", 50, "Scrum Master"));

        }
        public List<Person> getPersons()
        {
            return Persons;
        }
        public Person GetByName(string name)
        {
            var person = Persons.FirstOrDefault(x => x.Name == name);

            return person;
        }
    }
}

