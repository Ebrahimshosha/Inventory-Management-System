using Inventory_Management_System.VerticalSlicing.Features.InventoryTransactions.AddStock;
using Inventory_Management_System.VerticalSlicing.Features.InventoryTransactions.RemoveStock.Commands;

namespace Inventory_Management_System.VerticalSlicing.Features.InventoryTransactions.RemoveStock;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<StocktRequest, RemoveStockCommand>();
    }
}