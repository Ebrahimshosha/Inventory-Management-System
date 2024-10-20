namespace Inventory_Management_System.VerticalSlicing.Features.Products.ViewProduct;

public class ViewProductEndPoint : BaseController
{
    public ViewProductEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [HttpGet("ViewProduct/{ProductId}")]
    public async Task<Result<ProductResponse>> ViewProduct(int ProductId)
    {
        var Query = new GetProductByIdQuery(ProductId);
        var result = await _mediator.Send(Query);
        if (!result.IsSuccess)
        {
            return Result.Failure<ProductResponse>(ProductErrors.ProductNotFound);
        }
        var product = result.Data;

        var response = product.Map<ProductResponse>();

        return Result.Success(response);
    }
}