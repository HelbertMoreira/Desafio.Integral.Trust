using Desafio.Integral.Trust.Domain.Requests.Account;
using Desafio.Integral.Trust.Domain.Responses;

namespace Desafio.Integral.Trust.Domain.Handlers;

public interface IAccountHandler
{
    Task<Response<string>> LoginAsync(LoginRequest request);
    Task<Response<string>> RegisterAsync(RegisterRequest request);
    Task LogoutAsync();
}
