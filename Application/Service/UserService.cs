using Application.DTOs;
using Application.Service.Interfaces;
using Domain.Authentication;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _user;
        private readonly ITokenGenerator tokenGenerator;

        public UserService(IUserRepository user, ITokenGenerator tokenGenerator)
        {
            _user = user;
            this.tokenGenerator = tokenGenerator;
        }

        public async Task<ResultService<dynamic>> GenerateToken(UserDTO userDTO)
        {
            if (userDTO == null) return ResultService.Fail<dynamic>("Object not found");

            var validator = new UserDTOValidator().Validate(userDTO);
            if (!validator.IsValid) return ResultService.RequestError<dynamic>(" Validation problems", validator);

            var user = await _user.Login(userDTO.Email, userDTO.Password);
            if (user == null) return ResultService.Fail<dynamic>("Username or password not found");

            return ResultService.Ok(tokenGenerator.Generator(user));

        }
    }
}
