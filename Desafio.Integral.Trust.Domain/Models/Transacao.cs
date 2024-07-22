using Desafio.Integral.Trust.Domain.Enums;

namespace Desafio.Integral.Trust.Domain.Models;

public class Transacao
{
    public int Id { get; set; } 

    public DateTime DataReferencia { get; set; }

    public ETipoTransacao TipoTransacao { get; set; }

    public decimal Valor { get; set; }

    public int CodigoMoeda { get; set; }

    public string? Descricao { get; set; }

    public string UserId { get; set; } = string.Empty;
}
