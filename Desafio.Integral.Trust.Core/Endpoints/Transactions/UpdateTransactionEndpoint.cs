using Desafio.Integral.Trust.Core.Common.Api;
using Desafio.Integral.Trust.Domain.Handlers;
using Desafio.Integral.Trust.Domain.Models;
using Desafio.Integral.Trust.Domain.Responses;
using Dima.Core.Requests.Transactions;
using System.Security.Claims;

namespace Desafio.Integral.Trust.Core.Endpoints.Transactions
{
    public class UpdateTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPut("/{id}", HandleAsync)
                .WithName("Transacoes: Update")
                .WithSummary("Atualiza uma transação")
                .WithDescription("Atualiza uma transação")
                .WithOrder(2)
                .Produces<Response<Transacao?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ITransactionsHandler handler,
            UpdateTransactionRequest request,
            long id)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            request.Id = id;

            var result = await handler.UpdateAsync(request);
            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
