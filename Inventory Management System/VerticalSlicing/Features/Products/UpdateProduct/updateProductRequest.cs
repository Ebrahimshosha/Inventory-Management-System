namespace Inventory_Management_System.VerticalSlicing.Features.Products.UpdateProduct;

public record UpdateProductRequest(int productId,
                                    string Name,
                                    string Description,
                                    decimal Price,
                                    int Quantity,
                                    int LowStockThreshold);