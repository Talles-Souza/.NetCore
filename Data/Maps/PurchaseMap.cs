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

            builder.Property(x => x.Id).HasColumnName("IdPuerchase").UseIdentityColumn();
            builder.Property(x => x.PersonId).HasColumnName("IdPerson");
            builder.Property(x => x.ProductId).HasColumnName("IdProduct");
            builder.Property(x => x.Date).HasColumnName("DataPurchase");
        }
    }
}
