using Desafio.Integral.Trust.Domain.Requests;

namespace Dima.Core.Requests.Transactions;

public class GetTransactionByIdRequest : Request
{
    public long Id { get; set; }
}