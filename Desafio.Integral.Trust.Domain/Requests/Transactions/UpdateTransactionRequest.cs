using Desafio.Integral.Trust.Domain.Enums;
using Desafio.Integral.Trust.Domain.Requests;
using System.ComponentModel.DataAnnotations;

namespace Dima.Core.Requests.Transactions;

public class UpdateTransactionRequest : Request
{
    public long Id { get; set; }

    public DateTime DataReferencia { get; set; }

    public ETipoTransacao TipoTransacao { get; set; }

    public decimal Valor { get; set; }

    [Required(ErrorMessage = "Código da moeda inválido")]
    public int CodigoMoeda { get; set; }

    public string? Descricao { get; set; }
}