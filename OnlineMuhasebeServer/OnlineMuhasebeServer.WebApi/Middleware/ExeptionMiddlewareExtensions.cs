namespace OnlineMuhasebeServer.WebApi.Middleware
{
    public static class ExeptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExeptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExeptionMiddleware>();
        }
    }
}
