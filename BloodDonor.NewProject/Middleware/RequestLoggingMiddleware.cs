namespace BloodDonor.NewProject.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
           
        }
        public async Task InvokeAsync(HttpContext context)
        {
            // Log the request details
            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
            // Log the request before passing it to the next middleware
            await _next(context);
            // Log the response after the next middleware has processed the request
            Console.WriteLine($"Response: {context.Response.StatusCode}");
        }
    }
}
