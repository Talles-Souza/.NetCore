using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id).HasColumnName("IdProduct").UseIdentityColumn();  
            builder.Property(x => x.Name).HasColumnName("Name");    
            builder.Property(x => x.Cod).HasColumnName("Cod");    
            builder.Property(x => x.Price).HasColumnName("Price");
            builder.HasMany(x => x.Purchases).WithOne(prop => prop.Product).HasForeignKey(x => x.ProductId);


        }
    }
}

