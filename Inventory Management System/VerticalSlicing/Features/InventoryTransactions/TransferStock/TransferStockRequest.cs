namespace Inventory_Management_System.VerticalSlicing.Features.InventoryTransactions.TransferStock;

public record TransferStockRequest(int ProductId,
                                    int Quantity,
                                    int From,
                                    int To);