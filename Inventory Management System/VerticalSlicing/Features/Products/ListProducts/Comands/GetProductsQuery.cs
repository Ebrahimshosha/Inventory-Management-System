namespace Inventory_Management_System.VerticalSlicing.Features.Products.ListProducts.Comands;

public record GetProductsQuery(SpecParams SpecParams) : IRequest<Result<IEnumerable<ProductResponse>>>;

public class GetProductsQueryHandler : BaseRequestHandler<GetProductsQuery, Result<IEnumerable<ProductResponse>>>
{
    public GetProductsQueryHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public override async Task<Result<IEnumerable<ProductResponse>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var spec = new ProductSpecification(request.SpecParams);
        var products = await _unitOfWork.Repository<Product>().GetAllWithSpecAsync(spec);

        if (products == null)
        {
            return Result.Failure<IEnumerable<ProductResponse>>(ProductErrors.ProductNotFound);
        }

        var response = products.Map<IEnumerable<ProductResponse>>();

        return Result.Success(response);
    }
}