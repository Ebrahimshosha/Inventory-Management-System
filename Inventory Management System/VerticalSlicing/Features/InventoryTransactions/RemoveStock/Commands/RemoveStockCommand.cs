using Inventory_Management_System.VerticalSlicing.Features.Products;

namespace Inventory_Management_System.VerticalSlicing.Features.InventoryTransactions.RemoveStock.Commands;

public record RemoveStockCommand(int ProductId,
                                 int Quantity) : IRequest<Result<bool>>;

public class RemoveStockCommandHandler : BaseRequestHandler<RemoveStockCommand, Result<bool>>
{
    public RemoveStockCommandHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public override async Task<Result<bool>> Handle(RemoveStockCommand request, CancellationToken cancellationToken)
    {
        var productResult = await _mediator.Send(new GetProductByIdQuery(request.ProductId), cancellationToken);
        if (!productResult.IsSuccess)
        {
            return Result.Failure<bool>(ProductErrors.ProductNotFound);
        }

        var product = productResult.Data;
        product.Quantity -= request.Quantity;

        var transaction = new InventoryTransaction
        {
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            TransactionType = TransactionType.RemoveStock,
            PerformedById = int.Parse(_userState.ID)
        };

        _unitOfWork.Repository<Product>().Update(product);
        await _unitOfWork.Repository<InventoryTransaction>().AddAsync(transaction);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success(true);
    }
}