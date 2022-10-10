using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interfaces
{
    public interface IPurchaseService
    {
        Task<ResultService<PurchaseDTO>> Create(PurchaseDTO purchasesDTO);
        Task<ResultService<PuchateDetailDTO>> FindByIdAsync(int id);
        Task<ResultService<ICollection<PuchateDetailDTO>>> FindByAllAsync();
        Task<ResultService<PurchaseDTO>> Update(PurchaseDTO purchaseDTO);
        Task <ResultService> Delete(int id);
    }
}
