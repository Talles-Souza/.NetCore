using Data.Context;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextDb _db;
        private IDbContextTransaction _transaction;

        public UnitOfWork(ContextDb db)
        {
            _db = db;
        }

        public async Task BeginTransaction()
        {
            _transaction =  await _db.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }
        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
        }

       
    }
}
