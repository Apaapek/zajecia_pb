namespace Utils
{
    public static class BrowserRedirectMiddlewareExtensions
    {
        public static IApplicationBuilder UseBrowserRedirectMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<BrowserRedirectMiddleware>();
        }
    }
}
