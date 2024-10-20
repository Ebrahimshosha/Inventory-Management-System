namespace Inventory_Management_System.VerticalSlicing.Features.Products.AddProduct;

public class AddProductRequest
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int LowStockThreshold { get; set; }
}
