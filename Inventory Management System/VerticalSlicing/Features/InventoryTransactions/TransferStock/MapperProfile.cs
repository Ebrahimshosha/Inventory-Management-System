namespace Inventory_Management_System.VerticalSlicing.Features.InventoryTransactions.TransferStock;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<TransferStockRequest, TransferStockCommand>();
    }
}
