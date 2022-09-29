using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal sealed class Person
    {
        public Person(string name, string document, string phone)
        {
            Name = name;
            Document = document;
            Phone = phone;
        }

        public int Id { get; private set; }   
        public string Name { get; private set; }    
        public string Document { get; private set; }
        public string Phone {get; private set; }


    }
}
