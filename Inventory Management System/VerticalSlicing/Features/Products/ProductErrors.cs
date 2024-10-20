namespace Inventory_Management_System.VerticalSlicing.Features.Products;

public class ProductErrors
{
    public static readonly Error ProductNotFound =
    new("Product is not found", StatusCodes.Status404NotFound);

    public static readonly Error ProductAlreadyExists =
        new("Product Already Exists", StatusCodes.Status409Conflict);

    public static readonly Error ProductIsNotEnough =
        new("Product Is Not Enough", StatusCodes.Status409Conflict);
}