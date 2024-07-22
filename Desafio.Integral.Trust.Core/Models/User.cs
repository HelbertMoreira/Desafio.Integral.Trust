using Microsoft.AspNetCore.Identity;

namespace Desafio.Integral.Trust.Core.Models;

public class User : IdentityUser<long>
{
    public List<IdentityRole<long>>? Roles { get; set; }
}
