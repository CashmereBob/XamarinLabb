using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPCL
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public string Title { get; set; }

        public Person()
        {

        }
        public Person(string name, int age, string title)
        {
            this.Name = name;
            this.Age = age;
            this.Title = title;
        }
    }
}
