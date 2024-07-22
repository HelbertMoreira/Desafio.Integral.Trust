namespace Desafio.Integral.Trust.Domain.Requests.RiskIndicators;

public class GetRiskIndicatorByCoin : Request
{
    public int CodigoMoeda { get; set; }
}
