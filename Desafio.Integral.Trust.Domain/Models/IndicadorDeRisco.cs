using Desafio.Integral.Trust.Domain.Requests;

namespace Desafio.Integral.Trust.Domain.Models;

public class IndicadorDeRisco : Request
{
    public int Id { get; set; }

    public string? NomeIndicador { get; set; }

    public decimal ValorIndicador { get; set; }

    public DateTime DataReferencia { get; set; }
}
