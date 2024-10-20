namespace Inventory_Management_System.VerticalSlicing.Features.Products.AddProduct;

public class AddProductEndPoint : BaseController
{
    public AddProductEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [HttpPost("Add-Product")]
    public async Task<Result<int>> AddProduct(AddProductRequest request)
    {
        var command = request.Map<CreateProductCommand>();

        var response = await _mediator.Send(command);

        return response;
    }
}