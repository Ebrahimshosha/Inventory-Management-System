namespace Inventory_Management_System.VerticalSlicing.Common.Sevices.LowStockService;


public interface ILowStockService
{
    Task CheckAndNotifyLowStockAsync();
}

public class LowStockService : ILowStockService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly EmailSenderHelper _emailService;

    public LowStockService(IUnitOfWork unitOfWork, EmailSenderHelper emailService)
    {
        _unitOfWork = unitOfWork;
        _emailService = emailService;
    }

    public async Task CheckAndNotifyLowStockAsync()
    {
        var products = await _unitOfWork.Repository<Product>().GetAllAsync();

        foreach (var product in products)
        {
            if (product.Quantity < product.LowStockThreshold)
            {
                Console.WriteLine($"Product {product.Name} is below its low stock threshold.");

                var emailContent = $"Product {product.Name} is below its low stock threshold.";

                await _emailService.SendEmailAsync("ebrahimshosha66@gmail.com", "low-stock products ", emailContent);

            }
        }
    }
}
