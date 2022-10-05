using Domain.Validations;

namespace Domain.Entities
{


    public class Purchases
    {

        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }
        public Person Person { get; set; }
        public Product Product { get; set; }


        public Purchases(int productId, int personId)
        {
            Validation(ProductId, PersonId);
        } public Purchases(int id ,int productId, int personId)
        {
            DomainValidationException.When(id < 0, "Id must be informed");
            Id = id;
            Validation(ProductId, PersonId);
        }


        private void Validation(int productId, int personId)
        {
            DomainValidationException.When(productId<0, "Product id must be informed");
            DomainValidationException.When(personId <0, "Person id must be informed");
            //DomainValidationException.When(!date.HasValue, "Purchase date must be informed");

           ProductId = productId;
            PersonId = personId;
            Date = DateTime.Now;
        }
    }
}
