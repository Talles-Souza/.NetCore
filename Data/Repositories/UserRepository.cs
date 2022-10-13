using Data.Context;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ContextDb db;

        public UserRepository(ContextDb db)
        {
            this.db = db;
        }

        public async Task<User> Login(string email, string password)
        {
            return await db.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }
    }
}
