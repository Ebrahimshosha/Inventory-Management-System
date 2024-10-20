namespace Inventory_Management_System.VerticalSlicing.Features.Products.AddProduct.Queries;

public record GetProductByNameQuery(string Name) : IRequest<Result<Product>>;
public class GetProductByNameQueryHandler : BaseRequestHandler<GetProductByNameQuery, Result<Product>>
{
    public GetProductByNameQueryHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public override async Task<Result<Product>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
    {
        var product = (await _unitOfWork.Repository<Product>().GetAsync(c => c.Name == request.Name)).FirstOrDefault();
        if (product == null)
        {
            return Result.Failure<Product>(ProductErrors.ProductNotFound);
        }

        return Result.Success(product);
    }
}