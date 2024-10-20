namespace Inventory_Management_System.VerticalSlicing.Data.Entities;

public class InventoryTransaction : BaseEntity
{
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    public TransactionType TransactionType { get; set; }
    public int PerformedById { get; set; }
    public User PerformedBy { get; set; } = null!;
}
