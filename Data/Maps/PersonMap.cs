using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            //mapeado
            builder.ToTable("person");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).HasColumnName("idperson").UseIdentityColumn();
            builder.Property(x => x.Document).HasColumnName("document");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Phone).HasColumnName("phone");

            //tipo de relacionamento
            builder.HasMany(x => x.Purchases).WithOne(x => x.Person).HasForeignKey(x => x.PersonId);
        }
    }
}
