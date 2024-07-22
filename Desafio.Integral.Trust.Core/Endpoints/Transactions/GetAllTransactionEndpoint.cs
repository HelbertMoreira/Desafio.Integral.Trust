using Desafio.Integral.Trust.Core.Common.Api;
using Desafio.Integral.Trust.Domain.Responses;
using Desafio.Integral.Trust.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Desafio.Integral.Trust.Domain.Models;
using Desafio.Integral.Trust.Domain.Handlers;
using Dima.Core.Requests.Transactions;

namespace Desafio.Integral.Trust.Core.Endpoints.Transactions
{
    public class GetAllTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/", HandleAsync)
                .WithName("Transacoes: Get All")
                .WithSummary("Recupera todas as transação")
                .WithDescription("Recupera todas as transação")
                .WithOrder(5)
                .Produces<PagedResponse<List<Transacao>?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ITransactionsHandler handler,
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllTransactionRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                PageNumber = pageNumber,
                PageSize = pageSize,
            };

            var result = await handler.GetAllAsync(request);
            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}