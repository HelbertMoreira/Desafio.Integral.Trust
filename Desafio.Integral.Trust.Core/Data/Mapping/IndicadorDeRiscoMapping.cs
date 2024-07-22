using Desafio.Integral.Trust.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Integral.Trust.Core.Data.Mapping;

public class IndicadorDeRiscoMapping : IEntityTypeConfiguration<IndicadorDeRisco>
{
    public void Configure(
        EntityTypeBuilder<IndicadorDeRisco> builder)
    {
        builder.ToTable("IndicadoresRisco");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.NomeIndicador)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(255);

        builder.Property(x => x.UserId)
            .IsRequired(true)
            .HasColumnType("VARCHAR")
            .HasMaxLength(160);

        builder.Property(x => x.DataReferencia)
            .IsRequired(true);

        builder.Property(x => x.ValorIndicador)
            .IsRequired(true)
            .HasColumnType("MONEY");
    }
}
