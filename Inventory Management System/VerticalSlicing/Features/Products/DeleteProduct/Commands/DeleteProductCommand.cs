namespace Inventory_Management_System.VerticalSlicing.Features.Products.DeleteProduct.Commands;

public record DeleteProductCommand(int ProductId) : IRequest<Result<bool>>;

public class DeleteProductCommandHandler : BaseRequestHandler<DeleteProductCommand, Result<bool>>
{
    public DeleteProductCommandHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public override async Task<Result<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var ProductResult = await _mediator.Send(new GetProductByIdQuery(request.ProductId), cancellationToken);
        if (!ProductResult.IsSuccess)
        {
            return Result.Failure<bool>(ProductErrors.ProductNotFound);
        }

        var product = ProductResult.Data;

        _unitOfWork.Repository<Product>().Delete(product);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success(true);
    }
}

