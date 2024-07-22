using Desafio.Integral.Trust.Domain.Models;
using Desafio.Integral.Trust.Domain.Responses;
using Dima.Core.Requests.Transactions;

namespace Desafio.Integral.Trust.Domain.Handlers;

public interface ITransactionsHandler
{
    Task<Response<Transacao?>> CreateAsync(CreateTransactionRequest request);
    Task<Response<Transacao?>> UpdateAsync(UpdateTransactionRequest request);
    Task<Response<Transacao?>> DeleteAsync(DeleteTransactionRequest request);
    Task<Response<Transacao?>> GetByIdAsync(GetTransactionByIdRequest request);
    Task<PagedResponse<List<Transacao>>> GetAllAsync(GetAllTransactionRequest request);
}
