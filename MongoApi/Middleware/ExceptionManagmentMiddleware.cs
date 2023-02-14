using CustomException.Middleware;
namespace MongoApi.Middleware
{
    public class ExceptionManagmentMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionManagmentMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await ExceptionMiddleware.HandleExceptionAsync(context, exception);
            }
        }
    }
}
