namespace Inventory_Management_System.VerticalSlicing.Data.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int LowStockThreshold { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; }
    public ICollection<WarehouseProduct> WarehouseProducts { get; set; } = new HashSet<WarehouseProduct>();

}
