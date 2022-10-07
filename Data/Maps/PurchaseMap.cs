using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps
{

    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
    

        public void Configure(EntityTypeBuilder<Purchase> builder)
        {

            builder.ToTable("purchases");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("idpurchase").UseIdentityColumn();
            builder.Property(x => x.PersonId).HasColumnName("idperson");
            builder.Property(x => x.ProductId).HasColumnName("idproduct");
            builder.Property(x => x.Date).HasColumnType("date").HasColumnName("datepurchase");

            //como estamos na claase "compra" começamos pelos atributos que estao dentro
            builder.HasOne(x => x.Person).WithMany(x=>x.Purchases); 
            builder.HasOne(x => x.Product).WithMany(x=>x.Purchases); 
        }
    }
}
