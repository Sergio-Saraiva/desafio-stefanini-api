using DesafioStefanini.Domain.Enitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioStefanini.Infra.Data.EntitiesConfiguration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>

    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Property(p => p.UF).IsRequired().HasMaxLength(2);
            builder.HasOne(e => e.Person).WithOne(e => e.City).HasForeignKey<Person>(e => e.CityId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())").ValueGeneratedOnAdd();
            builder.Property(p => p.UpdatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())").ValueGeneratedOnAddOrUpdate();
        }
    }
}
