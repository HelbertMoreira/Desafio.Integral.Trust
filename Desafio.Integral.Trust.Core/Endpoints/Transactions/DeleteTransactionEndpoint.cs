using Desafio.Integral.Trust.Core.Common.Api;
using Desafio.Integral.Trust.Domain.Handlers;
using Desafio.Integral.Trust.Domain.Models;
using Desafio.Integral.Trust.Domain.Responses;
using Dima.Core.Requests.Transactions;
using System.Security.Claims;

namespace Desafio.Integral.Trust.Core.Endpoints.Transactions
{
    public class DeleteTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id}", HandleAsync)
                .WithName("Transacoes: Delete")
                .WithSummary("Exclui uma transacao")
                .WithDescription("Exclui uma transacao")
                .WithOrder(3)
                .Produces<Response<Transacao?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ITransactionsHandler handler,
            long id)
        {
            var request = new DeleteTransactionRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                Id = id
            };

            var result = await handler.DeleteAsync(request);
            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
