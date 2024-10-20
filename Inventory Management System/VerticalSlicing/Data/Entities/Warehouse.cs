namespace Inventory_Management_System.VerticalSlicing.Data.Entities;

public class Warehouse : BaseEntity
{
    public string Location { get; set; } = null!;
    public string Name { get; set; } = null!;

    public ICollection<WarehouseProduct> WarehouseProducts { get; set; } = new HashSet<WarehouseProduct>();
}
