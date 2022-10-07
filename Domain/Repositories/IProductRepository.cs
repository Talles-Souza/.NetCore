using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> FindById(int id);
        Task<ICollection<Product>> FindByAll();
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<bool> Delete(int id);
        Task<int> FindByIdCod(string cod);


    }
}
