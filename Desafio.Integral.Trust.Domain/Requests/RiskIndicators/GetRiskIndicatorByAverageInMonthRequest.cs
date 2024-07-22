using System.Reflection.Metadata.Ecma335;

namespace Desafio.Integral.Trust.Domain.Requests.RiskIndicators;

public class GetRiskIndicatorByAverageInMonthRequest : Request
{
    public int Mes { get; set; }
}
