using FluentValidation;

namespace OnlineMuhasebeServer.WebApi.Middleware
{
    public class ExeptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
                await next(context);
			}
			catch (Exception ex)
			{

				await HandleExeptionAsync(context, ex);
			}
        }

        private Task HandleExeptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)StatusCodes.Status500InternalServerError;

            if (ex.GetType()==typeof(ValidationException))
            {
                return context.Response.WriteAsync(new ValidationErrorDetails
                {
                    Errors=((ValidationException)ex ).Errors.Select(x=>x.PropertyName),
                    StatusCode=context.Response.StatusCode
                }.ToString());
            }

            return context.Response.WriteAsync(new ErrorResult
            {
                Message = ex.Message,
                StatusCode=context.Response.StatusCode
            }.ToString()) ;

        }
    }
}
