using Desafio.Integral.Trust.Core.Common.Api;
using Desafio.Integral.Trust.Domain.Handlers;
using Desafio.Integral.Trust.Domain.Models;
using Desafio.Integral.Trust.Domain.Requests.RiskIndicators;
using Desafio.Integral.Trust.Domain.Responses;
using System.Security.Claims;

namespace Desafio.Integral.Trust.Core.Endpoints.IndicadoresDeRiscos;

public class RiskIndicatorByInLastSevenDaysEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/seven-days", HandleAsync)
            .WithName("Indicadores: Total nos ultimos sete dias")
            .WithSummary("Relata Indicador: Total nos últimos sete dias")
            .WithDescription("Relata Indicador: Total nos últimos sete dias")
            .WithOrder(3)
            .Produces<Response<IndicadorDeRisco?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user, IIndicadoresRiscoHandler handler, GetRiskIndicatorByLastSevenDaysRequest request)
    {
        request.UserId = user.Identity?.Name ?? string.Empty;
        var result = await handler.TotalTransacoesNosUltimosSeteDias(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result}", result)
            : TypedResults.BadRequest(result.Data);
    }
}
