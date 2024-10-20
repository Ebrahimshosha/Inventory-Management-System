using Inventory_Management_System.VerticalSlicing.Features.Products;

namespace Inventory_Management_System.VerticalSlicing.Features.InventoryTransactions.TransferStock.Commands;

public record TransferStockCommand(int ProductId,
                                    int Quantity,
                                    int From,
                                    int To) : IRequest<Result<bool>>;

public class TransferStockCommandHandler : BaseRequestHandler<TransferStockCommand, Result<bool>>
{
    public TransferStockCommandHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public override async Task<Result<bool>> Handle(TransferStockCommand request, CancellationToken cancellationToken)
    {
        var productResult = await _mediator.Send(new GetProductByIdQuery(request.ProductId), cancellationToken);
        if (!productResult.IsSuccess)
        {
            return Result.Failure<bool>(ProductErrors.ProductNotFound);
        }

        var product = productResult.Data;

        if (product.Quantity < request.Quantity)
        {
            return Result.Failure<bool>(ProductErrors.ProductIsNotEnough);
        }
        product.Quantity -= request.Quantity;

        var transaction = new InventoryTransaction
        {
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            TransactionType = TransactionType.Transfer,
            PerformedById = int.Parse(_userState.ID)
        };

        var transfer = new StockTransfer
        {
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            ToWarehouseId = request.To,
            FromWarehouseId = request.From,
            PerformedById = int.Parse(_userState.ID)
        };

        _unitOfWork.Repository<Product>().Update(product);
        await _unitOfWork.Repository<InventoryTransaction>().AddAsync(transaction);
        await _unitOfWork.Repository<StockTransfer>().AddAsync(transfer);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success(true);
    }
}