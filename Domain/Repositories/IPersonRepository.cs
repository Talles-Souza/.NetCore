using Domain.Entities;
using Domain.FiltersDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> FindById(int id);   
        Task<ICollection<Person>> FindByAll();
        Task<Person> Create(Person person);
        Task<Person> Update(Person person);
        Task<bool> Delete(int id);
        Task<int> FindByIdDocument(string document);
        Task<PagedBaseResponse<Person>> FindPage(PersonFilterDb request);


    }
}
