using Desafio.Integral.Trust.Core.Data;
using Desafio.Integral.Trust.Domain.Handlers;
using Desafio.Integral.Trust.Domain.Models;
using Desafio.Integral.Trust.Domain.Requests.RiskIndicators;
using Desafio.Integral.Trust.Domain.Responses;
using Desafio.Integral.Trust.Domain.Responses.IndicadorDeRiscos;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Integral.Trust.Core.Handlers
{
    public class IndicadoresRiscoHandler(AppDbContext context) : IIndicadoresRiscoHandler
    {
        public async Task<Response<IndicadorDeRisco?>> CriarIndicadorDeRisco(Transacao transaction)
        {
            try
            {
                var indicadorDeRisco = new IndicadorDeRisco()
                {
                    DataReferencia = transaction.DataReferencia,
                    UserId = transaction.UserId,
                    ValorIndicador = transaction.Valor,
                    NomeIndicador = string.IsNullOrEmpty(transaction.Descricao) ? "" : transaction.Descricao
                };

                await context.IndicadoresDeRiscos.AddAsync(indicadorDeRisco);
                await context.SaveChangesAsync();

                return new Response<IndicadorDeRisco?>(indicadorDeRisco, 201, "Indicador criado com sucesso !");
            }
            catch
            {
                return new Response<IndicadorDeRisco?>(null, 500, "Não foi possível regiistrar a transação");
            }
        }

        public async Task<Response<IndicadorDeRiscoResponse?>> MediaValoresTransacoesNoUltimoMes(GetRiskIndicatorByAverageInMonthRequest request)
        {
            try
            {
                var query = context
                    .IndicadoresDeRiscos
                    .AsNoTracking()
                    .Where(x => x.UserId == request.UserId && x.DataReferencia.Month == request.Mes);

                decimal result = query.Average(x => x.ValorIndicador);

                var indicador = new IndicadorDeRiscoResponse()
                {
                    NomeIndicador = $"Média dos valores das transações no último mês",
                    ValorIndicador = result
                };

                return new Response<IndicadorDeRiscoResponse?>(indicador);
            }
            catch
            {
                return new Response<IndicadorDeRiscoResponse?>(null, 500, "Não foi possível consultar as transações");
            }
        }

        public async Task<Response<IndicadorDeRiscoResponse?>> TotalTransacoesNosUltimosSeteDias(GetRiskIndicatorByLastSevenDaysRequest request)
        {
            try
            {
                var data = DateTime.Now.AddDays(-7);

                var query = context
                    .IndicadoresDeRiscos
                    .AsNoTracking()
                    .Where(x => x.UserId == request.UserId && x.DataReferencia >= data);
                    //.ToListAsync();

                decimal result = query.Sum(x => x.ValorIndicador);

                var indicador = new IndicadorDeRiscoResponse()
                {
                    NomeIndicador = $"Total de transações nos ultimos 7 dias. Data início = {data} e data final {DateTime.Now}",
                    ValorIndicador = result
                };

                return new Response<IndicadorDeRiscoResponse?>(indicador);
            }
            catch
            {
                return new Response<IndicadorDeRiscoResponse?>(null, 500, "Não foi possível consultar as transações");
            }
        }

        public async Task<Response<IndicadorDeRiscoResponse?>> ValorTotalTransacoesPorMoeda(GetRiskIndicatorByCoin request)
        {
            try
            {
                var query = context
                    .Transacoes
                    .AsNoTracking()
                    .Where(x => x.UserId == request.UserId && x.CodigoMoeda >= request.CodigoMoeda);

                decimal result = query.Sum(x => x.Valor);

                var indicador = new IndicadorDeRiscoResponse()
                {
                    NomeIndicador = "Valor total de transações por moeda",
                    ValorIndicador = result

                };
                return new Response<IndicadorDeRiscoResponse?>(indicador);
            }
            catch
            {
                return new Response<IndicadorDeRiscoResponse?>(null, 500, "Não foi possível consultar as transações por moeda");
            }
        }

        public async Task<Response<IndicadorDeRiscoResponse?>> ValorTotalTransacoesPorTipoDeTransasao(GetRiskIndicatorByTypeOfTransactionRequest request)
        {
            try
            {
                var query = context
                    .Transacoes
                    .AsNoTracking()
                    .Where(x => x.UserId == request.UserId && x.TipoTransacao >= request.TipoTransacao);

                decimal result = query.Sum(x => x.Valor);

                var indicador = new IndicadorDeRiscoResponse()
                {
                    NomeIndicador = "Valor total de transações por moeda",
                    ValorIndicador = result

                };
                return new Response<IndicadorDeRiscoResponse?>(indicador);
            }
            catch
            {
                return new Response<IndicadorDeRiscoResponse?>(null, 500, "Não foi possível consultar as transações por moeda");
            }
        }
    }
}
