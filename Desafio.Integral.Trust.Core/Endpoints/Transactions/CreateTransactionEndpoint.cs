using Desafio.Integral.Trust.Core.Common.Api;
using Desafio.Integral.Trust.Domain.Handlers;
using Desafio.Integral.Trust.Domain.Models;
using Desafio.Integral.Trust.Domain.Responses;
using Dima.Core.Requests.Transactions;
using System.Security.Claims;

namespace Desafio.Integral.Trust.Core.Endpoints.Transactions
{
    public class CreateTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Transacoes: Create")
            .WithSummary("Cria uma nova transação")
            .WithDescription("Cria uma nova transação")
            .WithOrder(1)
            .Produces<Response<Transacao?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user, ITransactionsHandler handler, CreateTransactionRequest request)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            var result = await handler.CreateAsync(request);
            return result.IsSuccess
                ? TypedResults.Created($"/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result.Data);
        }
    }
}
