namespace Vegelog.Server.Services
{
    public class CookieService
    {
        private readonly ILogger<CookieService> _logger;
        private readonly CookieOptions _options;
        public CookieService(ILogger<CookieService> logger)
        {
            _logger = logger;
            _options = new CookieOptions();
            _options.Secure = true;
            _options.HttpOnly = true;
            _options.SameSite = SameSiteMode.None;
        }

        public string? GetValue(HttpContext context, string key)
        {
            return context.Request.Cookies[key];
        }

        public void DeleteValue(HttpContext context, string key)
        {
            context.Response.Cookies.Delete(key);
        }

        public void SetValue(HttpContext context, string key, string value)
        {
            context.Response.Cookies.Append(key, value, _options);
        }

        public void SetValue(HttpContext context, string key, string value, TimeSpan expiresTime)
        {
            CookieOptions options = new CookieOptions();
            options.Secure = true;
            options.HttpOnly = true;
            options.Expires = DateTime.Now.Add(expiresTime);
            options.MaxAge = expiresTime;
            context.Response.Cookies.Append(key, value, options);
        }
    }
}
