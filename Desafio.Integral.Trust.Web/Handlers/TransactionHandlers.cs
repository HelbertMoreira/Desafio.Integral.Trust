using Desafio.Integral.Trust.Domain.Handlers;
using Desafio.Integral.Trust.Domain.Models;
using Desafio.Integral.Trust.Domain.Responses;
using Dima.Core.Requests.Transactions;
using System.Net.Http.Json;

namespace Desafio.Integral.Trust.Web.Handlers;

public class TransactionHandlers(IHttpClientFactory httpClientFactory) : ITransactionsHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<Response<Transacao?>> CreateAsync(CreateTransactionRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/transacao", request);
        return await result.Content.ReadFromJsonAsync<Response<Transacao?>>()
               ?? new Response<Transacao?>(null, 400, "Falha ao criar a transação");
    }

    public async Task<Response<Transacao?>> DeleteAsync(DeleteTransactionRequest request)
    {
        var result = await _client.DeleteAsync($"v1/transacao/{request.Id}");
        return await result.Content.ReadFromJsonAsync<Response<Transacao?>>()
               ?? new Response<Transacao?>(null, 400, "Falha ao criar a transação");
    }

    public async Task<PagedResponse<List<Transacao>>> GetAllAsync(GetAllTransactionRequest request) 
        => await _client.GetFromJsonAsync<PagedResponse<List<Transacao>>>("v1/transacao")
           ?? new PagedResponse<List<Transacao>>(null, 400, "Não foi possível obter as categorias");

    public async Task<Response<Transacao?>> GetByIdAsync(GetTransactionByIdRequest request) 
        => await _client.GetFromJsonAsync<Response<Transacao?>>($"v1/transacao/{request.Id}")
           ?? new Response<Transacao?>(null, 400, "Não foi possível obter a categoria");

    public async Task<Response<Transacao?>> UpdateAsync(UpdateTransactionRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/transacao/{request.Id}", request);
        return await result.Content.ReadFromJsonAsync<Response<Transacao?>>()
               ?? new Response<Transacao?>(null, 400, "Falha ao criar a transação");
    }
}
