using Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Person
    {
        public int Id { get; private set; }   
        public string Name { get; private set; }    
        public string Document { get; private set; }
        public string Phone {get; private set; }
        public ICollection<Purchase> Purchases { get; set; }

        public Person(string name, string document, string phone)
        {
            Validation(name,document,phone);
            Purchases = new List<Purchase>();  
        }
        public Person(int id,string name, string document, string phone)
        {
            DomainValidationException.When(id < 0, "Id must be greater than zero");
            Id=id;
            Purchases = new List<Purchase>();
            Validation(name,document,phone);

        }

        private void Validation(string name, string document, string phone)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Name must be entered correctly");
            DomainValidationException.When(string.IsNullOrEmpty(document), "Document must be correctly informed");
            DomainValidationException.When(string.IsNullOrEmpty(phone), "Phone must be informed correctly");

            Name = name;
            Document = document;
            Phone = phone;  
        }

    }
}
