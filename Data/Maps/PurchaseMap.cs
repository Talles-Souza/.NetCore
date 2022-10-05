using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps
{

    public class PurchaseMap : IEntityTypeConfiguration<Purchases>
    {
    

        public void Configure(EntityTypeBuilder<Purchases> builder)
        {

            builder.ToTable("Purchases");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Idpuerchase").UseIdentityColumn();
            builder.Property(x => x.PersonId).HasColumnName("Idperson");
            builder.Property(x => x.ProductId).HasColumnName("Idproduct");
            builder.Property(x => x.Date).HasColumnName("Datapurchase");

            //como estamos na claase "compra" começamos pelos atributos que estao dentro
            builder.HasOne(x => x.Person).WithMany(x=>x.Purchases); 
            builder.HasOne(x => x.Product).WithMany(x=>x.Purchases); 
        }
    }
}
