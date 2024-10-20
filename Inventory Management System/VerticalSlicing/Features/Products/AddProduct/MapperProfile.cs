namespace Inventory_Management_System.VerticalSlicing.Features.Products.AddProduct;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<AddProductRequest, CreateProductCommand>();
        CreateMap<CreateProductCommand, Product>();
        CreateMap<CreateProductCommand, Product>()
           .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
           .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
    }
}