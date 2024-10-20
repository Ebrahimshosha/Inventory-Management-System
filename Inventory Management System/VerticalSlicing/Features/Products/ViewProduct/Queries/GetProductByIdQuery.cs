namespace Inventory_Management_System.VerticalSlicing.Features.Products.ViewProduct.Queries;

public record GetProductByIdQuery(int ProductId) : IRequest<Result<Product>>;

public class GetCategoryByIdQueryHandler : BaseRequestHandler<GetProductByIdQuery, Result<Product>>
{
    public GetCategoryByIdQueryHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public override async Task<Result<Product>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Repository<Product>().GetByIdAsync(request.ProductId);
        if (product == null)
        {
            return Result.Failure<Product>(ProductErrors.ProductNotFound);
        }

        return Result.Success(product);
    }
}