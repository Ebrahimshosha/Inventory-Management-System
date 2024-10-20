using Inventory_Management_System.VerticalSlicing.Features.Products.DeleteProduct.Commands;

namespace Inventory_Management_System.VerticalSlicing.Features.Products.DeleteProduct;

public class DeleteProductEndPoint : BaseController
{
    public DeleteProductEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [HttpDelete("Delete-Product/{productId}")]
    public async Task<Result<bool>> AddProduct(int productId)
    {
        var command = new DeleteProductCommand(productId);

        var response = await _mediator.Send(command);

        return response;
    }
}