namespace Inventory_Management_System.VerticalSlicing.Features.Products.ViewProduct;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Product, ProductResponse>();
    }
}