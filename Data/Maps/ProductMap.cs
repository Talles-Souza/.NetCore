using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id).HasColumnName("idproduct").UseIdentityColumn();  
            builder.Property(x => x.Name).HasColumnName("name");    
            builder.Property(x => x.Cod).HasColumnName("cod");    
            builder.Property(x => x.Price).HasColumnName("price");
            builder.HasMany(x => x.Purchases).WithOne(prop => prop.Product).HasForeignKey(x => x.ProductId);


        }
    }
}

