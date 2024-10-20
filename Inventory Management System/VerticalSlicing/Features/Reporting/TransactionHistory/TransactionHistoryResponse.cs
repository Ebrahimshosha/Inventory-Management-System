namespace Inventory_Management_System.VerticalSlicing.Features.Reporting.TransactionHistory;

public class TransactionHistoryResponse
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime TransactionDate { get; set; }
    public TransactionType TransactionType { get; set; }
    public int PerformedById { get; set; }
}