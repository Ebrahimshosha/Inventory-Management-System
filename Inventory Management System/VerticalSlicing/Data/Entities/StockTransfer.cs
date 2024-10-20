namespace Inventory_Management_System.VerticalSlicing.Data.Entities;

public class StockTransfer : BaseEntity
{
    public int Quantity { get; set; }
    public DateTime TransferDate { get; set; } = DateTime.UtcNow;
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int FromWarehouseId { get; set; }
    public Warehouse FromWarehouse { get; set; } = null!;
    public int ToWarehouseId { get; set; }
    public Warehouse ToWarehouse { get; set; } = null!;
    public int PerformedById { get; set; }
    public User PerformedBy { get; set; } = null!;
}

