using Desafio.Integral.Trust.Domain.Handlers;
using Dima.Core.Requests.Transactions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Desafio.Integral.Trust.Web.Pages.Transactions;

public partial class CreateTransactionPage : ComponentBase
{
    

    #region PROPRIEDADES
    public bool IsBusy { get; set; } = false;

    public CreateTransactionRequest InputModel { get; set; } = new();

    #endregion

    #region SERVIÇOS

    [Inject]
    public ITransactionsHandler Handler { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    #endregion

    #region MÉTODOS
    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            var result = await Handler.CreateAsync(InputModel);
            if (result.IsSuccess)
            {
                Snackbar.Add(result.Message, Severity.Success);
                NavigationManager.NavigateTo("/transactions");
            }
            else
                Snackbar.Add(result.Message, Severity.Error);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    #endregion
}
