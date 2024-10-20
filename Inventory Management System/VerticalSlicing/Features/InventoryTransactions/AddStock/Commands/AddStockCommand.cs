using FoodApp.Api.VerticalSlicing.Common;
using Inventory_Management_System.VerticalSlicing.Data.Entities;
using Inventory_Management_System.VerticalSlicing.Features.Products;

namespace Inventory_Management_System.VerticalSlicing.Features.InventoryTransactions.AddStock.Commands;

public record AddStockCommand(int ProductId,
                            int Quantity) : IRequest<Result<int>>;

public class AddStockCommandHandler : BaseRequestHandler<AddStockCommand, Result<int>>
{
    public AddStockCommandHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public override async Task<Result<int>> Handle(AddStockCommand request, CancellationToken cancellationToken)
    {
        var productResult = await _mediator.Send(new GetProductByIdQuery(request.ProductId), cancellationToken);
        if (!productResult.IsSuccess)
        {
            return Result.Failure<int>(ProductErrors.ProductNotFound);
        }

        var product = productResult.Data;
        product.Quantity += request.Quantity;

        var transaction = new InventoryTransaction
        {
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            TransactionType = TransactionType.AddStock,
            PerformedById = int.Parse(_userState.ID)
        };

        _unitOfWork.Repository<Product>().Update(product);
        await _unitOfWork.Repository<InventoryTransaction>().AddAsync(transaction);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success(transaction.Id);
    }
}