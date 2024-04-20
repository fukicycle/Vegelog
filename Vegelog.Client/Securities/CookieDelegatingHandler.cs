
using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace Vegelog.Client.Securities
{
    public sealed class CookieDelegatingHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            return base.SendAsync(request, cancellationToken);
        }
    }
}
