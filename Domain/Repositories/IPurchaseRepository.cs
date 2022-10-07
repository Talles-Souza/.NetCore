using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPurchaseRepository
    {
        Task<Purchase> FindById(int id);
        Task<ICollection<Purchase>> FindByAll();
        Task<Purchase> Create(Purchase purchase);
        Task Update(Purchase purchase);
        Task Delete(Purchase purchase);
        Task<ICollection<Purchase>> FindByPersonId(int personId);
        Task<ICollection<Purchase>> FindByProductId(int productId);
    }
}
