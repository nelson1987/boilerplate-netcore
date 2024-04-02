namespace Stargazer.WebApi.Middlewares
{
    public static class HttpsRedirection
    {
        public static void ConfigureHttpsRedirection(this IServiceCollection services)
        {
            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
                options.HttpsPort = 443;
            });
        }
    }
}
