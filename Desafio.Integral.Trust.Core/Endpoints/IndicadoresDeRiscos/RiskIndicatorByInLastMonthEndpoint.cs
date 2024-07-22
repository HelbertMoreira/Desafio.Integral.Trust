using Desafio.Integral.Trust.Core.Common.Api;
using Desafio.Integral.Trust.Domain.Handlers;
using Desafio.Integral.Trust.Domain.Models;
using Desafio.Integral.Trust.Domain.Requests.RiskIndicators;
using Desafio.Integral.Trust.Domain.Responses;
using System.Security.Claims;

namespace Desafio.Integral.Trust.Core.Endpoints.IndicadoresDeRiscos;

public class RiskIndicatorByInLastMonthEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/month", HandleAsync)
            .WithName("Indicadores: Total no mes")
            .WithSummary("Relata Indicador: Total no último mês")
            .WithDescription("Relata Indicador: Total no último mês")
            .WithOrder(2)
            .Produces<Response<IndicadorDeRisco?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user, IIndicadoresRiscoHandler handler, GetRiskIndicatorByAverageInMonthRequest request)
    {
        request.UserId = user.Identity?.Name ?? string.Empty;
        var result = await handler.MediaValoresTransacoesNoUltimoMes(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result}", result)
            : TypedResults.BadRequest(result.Data);
    }
}
