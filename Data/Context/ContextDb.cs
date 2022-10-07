using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Data.Context
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {}

        public DbSet<Person> People { get; set; } 
        public DbSet <Product> Product { get; set; }   
        public DbSet <Purchase> Purchases { get; set; }   


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ContextDb).Assembly);
        }

    }
}
