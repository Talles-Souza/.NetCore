using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PagedResponseDTO<T>
    {
        public int TotalRegister { get; private set; }
        public List<T> Data{ get; private set; }

        public PagedResponseDTO(int totalRegister, List<T> data)
        {
            TotalRegister = totalRegister;
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
