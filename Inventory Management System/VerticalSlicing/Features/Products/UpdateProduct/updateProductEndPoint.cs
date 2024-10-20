
namespace Inventory_Management_System.VerticalSlicing.Features.Products.UpdateProduct;

public class UpdateProductEndPoint : BaseController
{
    public UpdateProductEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [HttpPut("Update-Product/{productId}")]
    public async Task<Result<bool>> updateProduct(int productId,UpdateProductRequest request)
    {
        var command = request.Map<UpdateProductCommand>();

        var response = await _mediator.Send(command);

        return response;
    }
}