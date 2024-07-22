using Desafio.Integral.Trust.Domain.Models;
using Desafio.Integral.Trust.Domain.Requests.RiskIndicators;
using Desafio.Integral.Trust.Domain.Responses;
using Desafio.Integral.Trust.Domain.Responses.IndicadorDeRiscos;


namespace Desafio.Integral.Trust.Domain.Handlers;

public interface IIndicadoresRiscoHandler
{
    Task<Response<IndicadorDeRisco?>> CriarIndicadorDeRisco(Transacao transaction);
    Task<Response<IndicadorDeRiscoResponse?>> ValorTotalTransacoesPorTipoDeTransasao(GetRiskIndicatorByTypeOfTransactionRequest request);
    Task<Response<IndicadorDeRiscoResponse?>> MediaValoresTransacoesNoUltimoMes(GetRiskIndicatorByAverageInMonthRequest request);
    Task<Response<IndicadorDeRiscoResponse?>> TotalTransacoesNosUltimosSeteDias(GetRiskIndicatorByLastSevenDaysRequest request);
    Task<Response<IndicadorDeRiscoResponse?>> ValorTotalTransacoesPorMoeda(GetRiskIndicatorByCoin request);
}
