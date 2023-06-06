using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;


namespace Utils
{
    public class BrowserRedirectMiddleware
    {
        private readonly RequestDelegate _next;

        public BrowserRedirectMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var userAgent = context.Request.Headers[HeaderNames.UserAgent].ToString();

            if (userAgent.Contains("Edge") || userAgent.Contains("Edg") || userAgent.Contains("Trident"))
            {
                context.Response.Redirect("https://www.mozilla.org/pl/firefox/new/");
                return;
            }

            await _next(context);
        }
    }
}
