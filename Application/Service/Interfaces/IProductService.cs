using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interfaces
{
    public interface IProductService
    {
        Task<ResultService<ProductDTO>> Create(ProductDTO productDTO);
        Task<ResultService<ProductDTO>> FindById(int id);
        Task<ResultService<ICollection<ProductDTO>>> FindByAll();
        
    }
}
