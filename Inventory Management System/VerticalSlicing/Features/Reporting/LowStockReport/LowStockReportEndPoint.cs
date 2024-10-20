namespace Inventory_Management_System.VerticalSlicing.Features.Reporting.LowStockReport;

public class LowStockReportEndPoint : BaseController
{
    public LowStockReportEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    //[Authorize]
    [HttpGet("Low-Stock-Report")]
    public async Task<Result<IEnumerable<ProductResponse>>> GetLowStockReport()
    {
        var query = new LowStockQuery();
        var response = await _mediator.Send(query);
        return response;
    }
}