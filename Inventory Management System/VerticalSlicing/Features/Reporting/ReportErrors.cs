namespace Inventory_Management_System.VerticalSlicing.Features.Reporting;

public class ReportErrors
{
    public static readonly Error NoLowStockItemsFound =
   new("No Low Stock Items Found", StatusCodes.Status404NotFound);
    
    public static readonly Error NoTransactionsFound =
   new("No Transactions Found", StatusCodes.Status404NotFound);
}
