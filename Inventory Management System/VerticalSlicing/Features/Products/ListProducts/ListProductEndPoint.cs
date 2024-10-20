
namespace Inventory_Management_System.VerticalSlicing.Features.Products.ListProducts;

public class ListProductEndPoint : BaseController
{
    public ListProductEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [HttpGet("ListProducts")]
    public async Task<Result<Pagination<ProductResponse>>> GetAllRecipes([FromQuery] SpecParams spec)
    {
        var result = await _mediator.Send(new GetProductsQuery(spec));
        if (!result.IsSuccess)
        {
            return Result.Failure<Pagination<ProductResponse>>(result.Error);
        }

        var ProductsCount = await _mediator.Send(new GetProductsCountQuery(spec));
        var paginationResult = new Pagination<ProductResponse>(spec.PageSize, spec.PageIndex, ProductsCount.Data, result.Data);

        return Result.Success(paginationResult);
    }
}