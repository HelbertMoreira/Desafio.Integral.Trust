using Desafio.Integral.Trust.Core.Data;
using Desafio.Integral.Trust.Domain.Handlers;
using Desafio.Integral.Trust.Domain.Models;
using Desafio.Integral.Trust.Domain.Responses;
using Dima.Core.Requests.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Integral.Trust.Core.Handlers
{
    public class TransactionHandler(AppDbContext context, IIndicadoresRiscoHandler indicador) : ITransactionsHandler
    {
        public async Task<Response<Transacao?>> CreateAsync(CreateTransactionRequest request)
        {
            try
            {
                var transacao = new Transacao
                {
                    Descricao = request.Descricao,
                    CodigoMoeda = request.CodigoMoeda,
                    TipoTransacao = request.TipoTransacao,
                    DataReferencia = request.Data_Referencia,
                    Valor = request.Valor,
                    UserId = request.UserId,
                };

                await context.Transacoes.AddAsync(transacao);
                await context.SaveChangesAsync();

                await indicador.CriarIndicadorDeRisco(transacao);

                return new Response<Transacao?>(transacao, 201, "Transação criada com sucesso!");
            }
            catch
            {
                return new Response<Transacao?>(null, 500, "Não foi possível regiistrar a transação");
            }
        }

        public async Task<Response<Transacao?>> DeleteAsync(DeleteTransactionRequest request)
        {
            try
            {
                var transacao = await context
                    .Transacoes
                    .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (transacao is null)
                    return new Response<Transacao?>(null, 404, "Transação não encontrada");

                context.Transacoes.Remove(transacao);
                await context.SaveChangesAsync();

                return new Response<Transacao?>(transacao, message: "Transação excluída com sucesso!");
            }
            catch
            {
                return new Response<Transacao?>(null, 500, "Não foi possível excluir a transação");
            }
        }

        public async Task<PagedResponse<List<Transacao>>> GetAllAsync(GetAllTransactionRequest request)
        {
            try
            {
                var query = context
                    .Transacoes
                    .AsNoTracking()
                    .Where(x => x.UserId == request.UserId)
                    .OrderBy(x => x.DataReferencia);

                var transacao = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<Transacao>>(
                    transacao,
                    count,
                    request.PageNumber,
                    request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Transacao>>(null, 500, "Não foi possível consultar as transações");
            }
        }

        public async Task<Response<Transacao?>> GetByIdAsync(GetTransactionByIdRequest request)
        {
            try
            {
                var transacao = await context
                    .Transacoes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                return transacao is null
                    ? new Response<Transacao?>(null, 404, "Transação não encontrada")
                    : new Response<Transacao?>(transacao);
            }
            catch
            {
                return new Response<Transacao?>(null, 500, "Não foi possível encontrar a transação");
            }
        }

        public async Task<Response<Transacao?>> UpdateAsync(UpdateTransactionRequest request)
        {
            try
            {
                var transacao = await context
                    .Transacoes
                    .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (transacao is null)
                    return new Response<Transacao?>(null, 404, "Transação não encontrada");

                transacao.TipoTransacao = request.TipoTransacao;
                transacao.Descricao = request.Descricao;
                transacao.DataReferencia = request.DataReferencia;
                transacao.Valor = request.Valor;
                transacao.CodigoMoeda = request.CodigoMoeda;

                context.Transacoes.Update(transacao);
                await context.SaveChangesAsync();

                return new Response<Transacao?>(transacao, message: "Transação atualizada com sucesso");
            }
            catch
            {
                return new Response<Transacao?>(null, 500, "Não foi possível alterar a transação");
            }
        }
    }
}
