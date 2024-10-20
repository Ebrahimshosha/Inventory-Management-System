namespace Inventory_Management_System.VerticalSlicing.Features.Common.Middlewares;

public class TransactionMiddleware
{
    RequestDelegate _next;
    ApplicationDBContext _context;

    public TransactionMiddleware(RequestDelegate next /*ApplicationDBContext context*/)
    {
        _next = next;
        //_context = context;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        var method = httpContext.Request.Method.ToUpper();
        if (method == "POST" || method == "PUT" || method == "DELETE")
        {
            var context = httpContext.RequestServices.GetService<ApplicationDBContext>();

            var transaction = context.Database.BeginTransaction();

            try
            {
                await _next(httpContext);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                throw;
            }
        }
        else
        {
            await _next(httpContext);
        }
    }
}
