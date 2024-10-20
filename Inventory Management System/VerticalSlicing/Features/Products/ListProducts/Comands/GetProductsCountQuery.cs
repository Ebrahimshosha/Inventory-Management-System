namespace Inventory_Management_System.VerticalSlicing.Features.Products.ListProducts.Comands;

public record GetProductsCountQuery(SpecParams SpecParams) : IRequest<Result<int>>;

public class GetRecipesCountQueryHandler : IRequestHandler<GetProductsCountQuery, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRecipesCountQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<int>> Handle(GetProductsCountQuery request, CancellationToken cancellationToken)
    {
        var ProductSpec = new CountProductWithSpec(request.SpecParams);
        var count = await _unitOfWork.Repository<Product>().GetCountWithSpecAsync(ProductSpec);

        return Result.Success(count);
    }
}