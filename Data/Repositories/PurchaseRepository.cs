using Data.Context;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ContextDb _db;

        public PurchaseRepository(ContextDb context)
        {
            _db = context;
        }

        public async Task<Purchase> Create(Purchase purchase)
        {
            _db.Add(purchase);
            await _db.SaveChangesAsync();
            return purchase;
        }

        public async Task Delete(Purchase purchase)
        {
            _db.Remove(purchase);
            await _db.SaveChangesAsync();
        }

        public async Task Update(Purchase purchase)
        {
            _db.Update(purchase);
            await _db.SaveChangesAsync();
        }

        public async Task<Purchase> FindById(int id)
        {
            var purchase = await _db.Purchases
                            .Include(x => x.Product)
                            .Include(x => x.Person)
                            .FirstOrDefaultAsync(x => x.Id == id);

            return purchase;
        }

        public async Task<ICollection<Purchase>> FindByPersonId(int personId)
        {
            return await _db.Purchases
                            .Include(x => x.Product)
                            .Include(x => x.Person)
                            .Where(x => x.PersonId == personId).ToListAsync();

        }

        public async Task<ICollection<Purchase>> FindByProductId(int productId)
        {
            return await _db.Purchases
                            .Include(x => x.Product)
                            .Include(x => x.Person)
                            .Where(x => x.ProductId == productId).ToListAsync();


        }

        public async Task<ICollection<Purchase>> FindByAll()
        {
            return await _db.Purchases
                            .Include(x => x.Product)
                            .Include(x => x.Person)
                            .ToListAsync();
        }
    }
}
