
namespace Inventory_Management_System.VerticalSlicing.Features.InventoryTransactions.AddStock;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<StocktRequest, AddStockCommand>();
    }
}