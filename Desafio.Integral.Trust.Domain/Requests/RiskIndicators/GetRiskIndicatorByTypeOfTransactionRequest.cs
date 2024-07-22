using Desafio.Integral.Trust.Domain.Enums;

namespace Desafio.Integral.Trust.Domain.Requests.RiskIndicators;

public class GetRiskIndicatorByTypeOfTransactionRequest : Request
{
    public ETipoTransacao TipoTransacao { get; set; }
}
