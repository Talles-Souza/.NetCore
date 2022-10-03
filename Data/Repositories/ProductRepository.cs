using Data.Context;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ContextDb _db;

        public ProductRepository(ContextDb db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<ICollection<Product>> FindByAll()
        {
            List<Product> people = await _db.Product.ToListAsync();
            return people;
        }
        public async Task<Product> FindById(int id)
        {
            Product product = await _db.Product.FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }
        public async Task<Product> Create(Product product)
        {
            _db.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }
        public async Task<Product> Update(Product product)
        {
            _db.Update(product);
            await _db.SaveChangesAsync();
            return product;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                Product product = await _db.Product.Where(p => p.Id == id)
                                    .FirstOrDefaultAsync();
                if (product == null) return false;
                _db.Product.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
       
    }
}
