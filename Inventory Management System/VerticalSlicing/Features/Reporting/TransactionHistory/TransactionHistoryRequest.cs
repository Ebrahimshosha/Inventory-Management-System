namespace Inventory_Management_System.VerticalSlicing.Features.Reporting.TransactionHistory;

public class TransactionHistoryRequest
{
    public int ProductId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public TransactionType TransactionType { get; set; }
}