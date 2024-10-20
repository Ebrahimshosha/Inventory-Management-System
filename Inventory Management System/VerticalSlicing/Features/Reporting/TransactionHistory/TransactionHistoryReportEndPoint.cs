namespace Inventory_Management_System.VerticalSlicing.Features.Reporting.TransactionHistory;

public class TransactionHistoryReportEndPoint : BaseController
{
    public TransactionHistoryReportEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    //[Authorize]
    [HttpPost("Transaction-History")]
    public async Task<Result<IEnumerable<TransactionHistoryResponse>>> GetTransactionHistory([FromForm]TransactionHistoryRequest request)
    {
        var query = new TransactionHistoryQuery(request.ProductId,
                                                request.StartDate,
                                                request.EndDate,
                                                request.TransactionType);

        var response = await _mediator.Send(query);
        return response;
    }
}