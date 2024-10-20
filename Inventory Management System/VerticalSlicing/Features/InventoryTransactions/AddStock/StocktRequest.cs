namespace Inventory_Management_System.VerticalSlicing.Features.InventoryTransactions.AddStock;

public record StocktRequest(int ProductId,
                            int Quantity);