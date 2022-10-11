using Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; private set; } 
        public string Email { get; private set; }    
        public string Password { get;private  set; }

        public User(string email, string password)
        {
           Validation(email, password);
        }

        public User(int id, string email, string password)
        {
            DomainValidationException.When(id <= 0, "Id must be informed");
            Id = id;
            Validation(email, password);
        }

        private void Validation(string email,string password)
        {
            DomainValidationException.When(string.IsNullOrEmpty(email), "Email must be informed");
            DomainValidationException.When(string.IsNullOrEmpty(password), "Password must be informed");

            Email = email;
            Password = password;    
        }
    }
}
