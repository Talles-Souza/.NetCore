using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interfaces
{
    public interface IUserService
    {
        Task<ResultService<dynamic>> GenerateToken(UserDTO userDTO);
    }
}
