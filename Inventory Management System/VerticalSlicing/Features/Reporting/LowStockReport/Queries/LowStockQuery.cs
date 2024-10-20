using Inventory_Management_System.VerticalSlicing.Data.Entities;
using System.Collections.Generic;

namespace Inventory_Management_System.VerticalSlicing.Features.Reporting.LowStockReport.Queries;

public record LowStockQuery() : IRequest<Result<IEnumerable<ProductResponse>>>;

public class LowStockQueryHandler : BaseRequestHandler<LowStockQuery, Result<IEnumerable<ProductResponse>>>
{
    public LowStockQueryHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public override async Task<Result<IEnumerable<ProductResponse>>> Handle(LowStockQuery request, CancellationToken cancellationToken)
    {
        var lowStockProducts = await _unitOfWork.Repository<Product>()
            .GetAsync(p => p.Quantity < p.LowStockThreshold);

        if (!lowStockProducts.Any())
        {
            return Result.Failure<IEnumerable<ProductResponse>>(ReportErrors.NoLowStockItemsFound);
        }

        var lowStockProductResponse = lowStockProducts.Select(p => p.Map<ProductResponse>());

        return Result.Success(lowStockProductResponse);
    }
}