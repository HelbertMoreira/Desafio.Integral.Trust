namespace Desafio.Integral.Trust.Domain.Requests.RiskIndicators;

public class CreateRiskIndicatorRequest : Request
{
    public string? NomeIndicador { get; set; }

    public decimal ValorIndicador { get; set; }

    public DateTime DataReferencia { get; set; }
}
