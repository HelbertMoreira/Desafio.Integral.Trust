using Desafio.Integral.Trust.Core.Common.Api;
using Desafio.Integral.Trust.Domain.Handlers;
using Desafio.Integral.Trust.Domain.Models;
using Desafio.Integral.Trust.Domain.Responses;
using Dima.Core.Requests.Transactions;
using System.Security.Claims;

namespace Desafio.Integral.Trust.Core.Endpoints.Transactions
{
    public class GetByIdTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/{id}", HandleAsync)
                .WithName("Transacoes: Get By Id")
                .WithSummary("Recupera uma transação")
                .WithDescription("Recupera uma transação")
                .WithOrder(4)
                .Produces<Response<Transacao?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ITransactionsHandler handler,
            long id)
        {
            var request = new GetTransactionByIdRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                Id = id
            };

            var result = await handler.GetByIdAsync(request);
            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
