using Desafio.Integral.Trust.Core.Common.Api;
using Desafio.Integral.Trust.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Desafio.Integral.Trust.Core.Endpoints.Identity;

public class LogoutEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app
            .MapPost("/logout", HandleAsync)
            .RequireAuthorization();

    private static async Task<IResult> HandleAsync(SignInManager<User> signInManager)
    {
        await signInManager.SignOutAsync();
        return Results.Ok();
    }
}
