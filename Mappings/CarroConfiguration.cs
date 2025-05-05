using LocadoraApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraApi.Mappings
{
    public class CarroConfiguration : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Modelo).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Marca).IsRequired();
            builder.Property(c => c.ValorDiaria).HasColumnType("decimal(10,2)");
        }
    }
}