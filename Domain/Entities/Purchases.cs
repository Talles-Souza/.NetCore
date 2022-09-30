using Domain.Validations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities
{
    

   internal class Purchases
    {

        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }
        public Person Person { get; set; }
        public Product Product { get; set; }


        public Purchases(int productId, int personId, DateTime? date)
        {
            Validation(ProductId, PersonId, Date);
        } public Purchases(int id ,int productId, int personId, DateTime? date)
        {
            DomainValidationException.When(id < 0, "Id must be informed");
            Id = id;
            Validation(ProductId, PersonId, Date);
        }


        private void Validation(int productId, int personId, DateTime? date)
        {
            DomainValidationException.When(productId<0, "Product id must be informed");
            DomainValidationException.When(personId <0, "Person id must be informed");
            DomainValidationException.When(!date.HasValue, "Purchase date must be informed");

           ProductId = productId;
            PersonId = personId;
            Date = date.Value;
        }
    }
}
