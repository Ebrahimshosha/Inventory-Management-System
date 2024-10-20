using Hangfire;
using Inventory_Management_System.VerticalSlicing.Common.Sevices.LowStockService;

namespace Inventory_Management_System;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddApplicationService(builder.Configuration);

        var app = builder.Build();

        #region Update-Database

        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        var LoggerFactory = services.GetRequiredService<ILoggerFactory>();

        try
        {
            var dbcontext = services.GetRequiredService<ApplicationDBContext>();
            await dbcontext.Database.MigrateAsync();

            await StoreContextseed.seedAsync(dbcontext);
        }
        catch (Exception ex)
        {
            var Logger = LoggerFactory.CreateLogger<Program>();
            Logger.LogError(ex, "An error occured during updating database");
        }

        #endregion

        MapperHandler.mapper = app.Services.GetService<IMapper>()!;
        TokenGenerator.options = app.Services.GetService<IOptions<JwtOptions>>()!.Value;

        app.UseMiddleware<TransactionMiddleware>();
        //app.TransactionMiddleware();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseStaticFiles();

        app.UseHttpsRedirection();

        app.UseHangfireDashboard("/jobs");

        var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

        //using var scope = scopeFactory.CreateScope();
        var notificationService = scope.ServiceProvider.GetRequiredService<ILowStockService>();

        RecurringJob.AddOrUpdate<ILowStockService>("Notify Low Stock", job => job.CheckAndNotifyLowStockAsync(), Cron.Daily);

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}