﻿namespace Inventory_Management_System.VerticalSlicing.Data.Entities;

public class WarehouseProduct : BaseEntity
{
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; } = null!;

    public int Quantity { get; set; }
}
