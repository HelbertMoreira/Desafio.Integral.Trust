﻿using Microsoft.AspNetCore.Components.Authorization;

namespace Desafio.Integral.Trust.Front.Security;

public interface ICookieAuthenticationStateProvider
{
    Task<bool> CheckAuthenticatedAsync();
    Task<AuthenticationState> GetAuthenticationStateAsync();
    void NotifyAuthenticationStateChanged();
}
