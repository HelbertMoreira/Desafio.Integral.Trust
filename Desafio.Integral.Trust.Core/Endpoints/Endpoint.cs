using Desafio.Integral.Trust.Core.Common.Api;
using Desafio.Integral.Trust.Core.Endpoints.Identity;
using Desafio.Integral.Trust.Core.Endpoints.IndicadoresDeRiscos;
using Desafio.Integral.Trust.Core.Endpoints.Transactions;
using Desafio.Integral.Trust.Core.Models;

namespace Desafio.Integral.Trust.Core.Endpoints;

public static class Endpoint
{

    public static void MapEndpoints(this WebApplication app)
    {

        var endpoints = app
       .MapGroup("");

        endpoints.MapGroup("/")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "OK" });

        endpoints.MapGroup("v1/transacoes")
            .WithTags("Transacao")
            .RequireAuthorization()
            .MapEndpoint<CreateTransactionEndpoint>()
            .MapEndpoint<UpdateTransactionEndpoint>()
            .MapEndpoint<DeleteTransactionEndpoint>()
            .MapEndpoint<GetByIdTransactionEndpoint>()
            .MapEndpoint<GetAllTransactionEndpoint>();



        endpoints.MapGroup("v1/indicadores")
           .WithTags("Indicador")
           .RequireAuthorization()
           .MapEndpoint<RiskIndicatorByCoinEndpoint>()
           .MapEndpoint<RiskIndicatorByInLastMonthEndpoint>()
           .MapEndpoint<RiskIndicatorByInLastSevenDaysEndpoint>()
           .MapEndpoint<RiskIndicatorByTypeTransactionEndpoint>();



        endpoints.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapIdentityApi<User>();

        endpoints.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapEndpoint<LogoutEndpoint>()
            .MapEndpoint<GetRolesEndpoint>();

    }
    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
