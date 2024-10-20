using Inventory_Management_System.VerticalSlicing.Features.InventoryTransactions.AddStock;
using Inventory_Management_System.VerticalSlicing.Features.InventoryTransactions.RemoveStock.Commands;

namespace Inventory_Management_System.VerticalSlicing.Features.InventoryTransactions.RemoveStock;

public class RemoveStockEndPoint:BaseController
{
    public RemoveStockEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize]
    [HttpDelete("Remove-Stock")]
    public async Task<Result<bool>> RemoveStock( StocktRequest request)
    {
        var command = request.Map<RemoveStockCommand>();

        var response = await _mediator.Send(command);

        return response;
    }
}