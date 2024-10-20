
namespace Inventory_Management_System.VerticalSlicing.Features.Products.UpdateProduct.Commands;

public record UpdateProductCommand( int productId,
                                    string Name,
                                    string Description,
                                    decimal Price,
                                    int Quantity,
                                    int LowStockThreshold) : IRequest<Result<bool>>;

public class UpdateProductCommandHandler : BaseRequestHandler<UpdateProductCommand, Result<bool>>
{
    public UpdateProductCommandHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public override async Task<Result<bool>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var ProductResult = await _mediator.Send(new GetProductByIdQuery(request.productId), cancellationToken);
        if (!ProductResult.IsSuccess)
        {
            return Result.Failure<bool>(ProductErrors.ProductNotFound);
        }

        var product = request.Map(ProductResult.Data);

        _unitOfWork.Repository<Product>().Update(product);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success(true);
    }
}