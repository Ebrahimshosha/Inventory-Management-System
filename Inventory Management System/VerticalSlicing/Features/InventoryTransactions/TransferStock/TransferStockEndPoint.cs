namespace Inventory_Management_System.VerticalSlicing.Features.InventoryTransactions.TransferStock;

public class TransferStockEndPoint : BaseController
{
    public TransferStockEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize]
    [HttpPut("Transfer-Stock")]
    public async Task<Result<bool>> TransferStock(TransferStockRequest request)
    {
        var command = request.Map<TransferStockCommand>();

        var response = await _mediator.Send(command);

        return response;
    }
}