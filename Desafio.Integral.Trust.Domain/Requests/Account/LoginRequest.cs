﻿using System.ComponentModel.DataAnnotations;

namespace Desafio.Integral.Trust.Domain.Requests.Account;

public class LoginRequest
{
    [Required(ErrorMessage = "E-mail")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Senha Inválida")]
    public string Password { get; set; } = string.Empty;
}
