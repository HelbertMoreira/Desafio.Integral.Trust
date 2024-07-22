using Desafio.Integral.Trust.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Integral.Trust.Core.Data.Mapping
{
    public class TransactionMapping : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(
        EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("Transacao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.TipoTransacao)
                .IsRequired(true)
                .HasConversion<string>()
                .HasColumnType("VARCHAR")
                .HasMaxLength(10);

            builder.Property(x => x.UserId)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(160);

            builder.Property(x => x.DataReferencia)
                .IsRequired(true);

            builder.Property(x => x.Valor)
                .IsRequired(true)
                .HasColumnType("MONEY");

            builder.Property(x => x.CodigoMoeda)
                .IsRequired(true)
                .HasColumnType("SMALLINT");
        }
    }
}
