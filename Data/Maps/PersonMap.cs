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
            builder.ToTable("Person");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).HasColumnName("IdPerson").UseIdentityColumn();
            builder.Property(x => x.Document).HasColumnName("Document");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Phone).HasColumnName("Phone");

            //tipo de relacionamento
            builder.HasMany(x => x.Purchases).WithOne(x => x.Person).HasForeignKey(x => x.PersonId);
        }
    }
}
