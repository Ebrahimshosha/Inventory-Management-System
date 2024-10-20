using Inventory_Management_System.VerticalSlicing.Features.Products;
using System.Collections.Generic;

namespace Inventory_Management_System.VerticalSlicing.Features.Reporting.TransactionHistory.Queries;

public record TransactionHistoryQuery(int ProductId,
                                      DateTime? StartDate = null,
                                      DateTime? EndDate = null,
                                      TransactionType? TransactionType = null) : IRequest<Result<IEnumerable<TransactionHistoryResponse>>>;

public class TransactionHistoryQueryHandler : BaseRequestHandler<TransactionHistoryQuery, Result<IEnumerable<TransactionHistoryResponse >>>
{
    public TransactionHistoryQueryHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public override async Task<Result<IEnumerable<TransactionHistoryResponse>>> Handle(TransactionHistoryQuery request, CancellationToken cancellationToken)
    {
        var productResult = await _mediator.Send(new GetProductByIdQuery(request.ProductId), cancellationToken);
        if (!productResult.IsSuccess)
        {
            return Result.Failure<IEnumerable<TransactionHistoryResponse>>(ProductErrors.ProductNotFound);
        }

        var transactions = await _unitOfWork.Repository<InventoryTransaction>().GetAsync(t =>
            (!request.TransactionType.HasValue || t.TransactionType == request.TransactionType) &&
            (!request.StartDate.HasValue || t.TransactionDate >= request.StartDate) &&
            (!request.EndDate.HasValue || t.TransactionDate <= request.EndDate));

        if (!transactions.Any())
        {
            return Result.Failure<IEnumerable<TransactionHistoryResponse>>(ReportErrors.NoTransactionsFound);
        }

        var response = transactions.Select(t => t.Map<TransactionHistoryResponse>());
        return Result.Success(response);
    }
}
