namespace DataAccessWebApi.Middlewares
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionsMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(ex.ToString());
            }
        }
    }
}
