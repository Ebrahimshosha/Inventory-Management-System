namespace Inventory_Management_System.VerticalSlicing.Features.InventoryTransactions.AddStock;

public class AddStockEndPoint : BaseController
{
    public AddStockEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize]
    [HttpPost("Add-Stock")]
    public async Task<Result<int>> AddStock(StocktRequest request)
    {
        var command = request.Map<AddStockCommand>();

        var response = await _mediator.Send(command);

        return response;
    }
}