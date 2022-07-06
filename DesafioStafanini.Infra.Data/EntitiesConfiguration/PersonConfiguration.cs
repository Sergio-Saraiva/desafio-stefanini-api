using DesafioStefanini.Domain.Enitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioStefanini.Infra.Data.EntitiesConfiguration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasMaxLength(300).IsRequired();
            builder.Property(p => p.Cpf).HasMaxLength(11).IsRequired();
            builder.Property(p => p.Age).IsRequired();
            builder.HasOne(e => e.City).WithOne(x => x.Person).HasForeignKey<Person>(e => e.CityId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())").ValueGeneratedOnAdd();
            builder.Property(p => p.UpdatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())").ValueGeneratedOnAddOrUpdate();
        }
    }
}
