using Desafio.Integral.Trust.Core.Common.Api;
using Desafio.Integral.Trust.Domain.Handlers;
using Desafio.Integral.Trust.Domain.Models;
using Desafio.Integral.Trust.Domain.Requests.RiskIndicators;
using Desafio.Integral.Trust.Domain.Responses;
using System.Security.Claims;

namespace Desafio.Integral.Trust.Core.Endpoints.IndicadoresDeRiscos;

public class RiskIndicatorByTypeTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/total", HandleAsync)
            .WithName("Indicadores: Total por tipo de transacao")
            .WithSummary("Relata Indicador: Total por tipo de transação")
            .WithDescription("Relata Indicador: Total por tipo de transação")
            .WithOrder(4)
            .Produces<Response<IndicadorDeRisco?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user, IIndicadoresRiscoHandler handler, GetRiskIndicatorByTypeOfTransactionRequest request)
    {
        request.UserId = user.Identity?.Name ?? string.Empty;
        var result = await handler.ValorTotalTransacoesPorTipoDeTransasao(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result}", result)
            : TypedResults.BadRequest(result.Data);
    }
}