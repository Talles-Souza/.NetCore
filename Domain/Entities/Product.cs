using Domain.Validations;

namespace Domain.Entities
{
    public sealed class  Product
    {
        public int Id { get; private  set; }
        public string Name { get; private   set; }
        public string Cod { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }


        public Product(string name, string cod, decimal price)
        {
            Purchases = new List<Purchase>();
            Validation(name, cod, price);
        }
        public Product(int id, string name, string cod, decimal price)
        {
            DomainValidationException.When(id <=0, "Id must be greater than zero");
            Id = id;
            Validation(name, cod, price);
            Purchases = new List<Purchase>();
        }


        private void Validation(string name, string cod, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Name must be entered correctly");
            DomainValidationException.When(string.IsNullOrEmpty(cod), "Cod must be correctly informed");
            DomainValidationException.When(price<0, "Price must be informed correctly");

            Name = name;
            Cod = cod;
            Price = price;
        }
    }
}
