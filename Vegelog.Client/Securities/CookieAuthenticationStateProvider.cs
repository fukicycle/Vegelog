using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Vegelog.Client.Securities
{
    public sealed class CookieAuthenticationStateProvider : AuthenticationStateProvider
    {

        private readonly AppSettings _appSettings;
        private readonly HttpClient _httpClient;
        private readonly ISessionStorageService _sessionStorageService;

        public CookieAuthenticationStateProvider(AppSettings appSettings, HttpClient httpClient, ISessionStorageService sessionStorageService)
        {
            _appSettings = appSettings;
            _httpClient = httpClient;
            _sessionStorageService = sessionStorageService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string code = await GetCodeAsync();
            if (code == "NaN")
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
            await _sessionStorageService.RemoveItemAsync("tmp");
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, authenticationType: nameof(CustomAuthenticationStateProvider))));
        }

        public async Task SetCodeAsync(string code)
        {
            await _sessionStorageService.SetItemAsync("tmp", code);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task<string> GetCodeAsync()
        {
            string code = await _sessionStorageService.GetItemAsync<string>("tmp");
            HttpResponseMessage res = await _httpClient.GetAsync($"/api/v1/groups/login?code={code}");
            return await res.Content.ReadAsStringAsync();
        }
    }
}
