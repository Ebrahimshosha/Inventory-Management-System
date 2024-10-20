
namespace Inventory_Management_System.VerticalSlicing.Features.Products.AddProduct.Commands;

public record CreateProductCommand(string Name,
                            string Description,
                            decimal Price,
                            int Quantity,
                            int LowStockThreshold) : IRequest<Result<int>>;

public class CreateProductCommandHandler : BaseRequestHandler<CreateProductCommand, Result<int>>
{
    public CreateProductCommandHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public override async Task<Result<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var existingCategory = await _mediator.Send(new GetProductByNameQuery(request.Name), cancellationToken);
        if (existingCategory.IsSuccess)
        {
            return Result.Failure<int>(ProductErrors.ProductAlreadyExists);
        }

        var product = request.Map<Product>();

        await _unitOfWork.Repository<Product>().AddAsync(product);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success(product.Id);
    }
}