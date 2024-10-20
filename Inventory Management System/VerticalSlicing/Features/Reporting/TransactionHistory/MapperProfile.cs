namespace Inventory_Management_System.VerticalSlicing.Features.Reporting.TransactionHistory;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<TransactionHistoryRequest,TransactionHistoryResponse>();
        CreateMap< InventoryTransaction,TransactionHistoryResponse >();
    }
}