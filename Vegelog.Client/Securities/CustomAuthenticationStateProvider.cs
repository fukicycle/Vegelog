using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Vegelog.Client.Securities
{
    public sealed class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {

        private readonly ILocalStorageService _localStorageService;
        private readonly AppSettings _appSettings;
        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService, AppSettings appSettings)
        {
            _localStorageService = localStorageService;
            _appSettings = appSettings;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string? code = await GetCodeAsync();
            if (code == null)
            {
                Claim[] guestClaims = {
                    new Claim(ClaimTypes.Role,nameof(UserRole.Guest))
                };
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(guestClaims, authenticationType: nameof(CustomAuthenticationStateProvider))));
            }
            Claim[] claims = {
                new Claim(ClaimTypes.NameIdentifier,code),
                new Claim(ClaimTypes.Name,code),
                new Claim(ClaimTypes.Role,nameof(UserRole.User))
            };
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, authenticationType: nameof(CustomAuthenticationStateProvider))));
        }

        public async Task SetCodeAsync(string code)
        {
            await _localStorageService.SetItemAsStringAsync(_appSettings.STORAGE_KEY, code);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task RemoveCodeAsync()
        {
            await _localStorageService.RemoveItemAsync(_appSettings.STORAGE_KEY);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task<string?> GetCodeAsync() => await _localStorageService.GetItemAsStringAsync(_appSettings.STORAGE_KEY);
    }
}
