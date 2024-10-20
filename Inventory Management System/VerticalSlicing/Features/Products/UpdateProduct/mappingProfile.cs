using Inventory_Management_System.VerticalSlicing.Features.Products.UpdateProduct.Commands;

namespace Inventory_Management_System.VerticalSlicing.Features.Products.UpdateProduct;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<UpdateProductRequest, UpdateProductCommand>();

        CreateMap<UpdateProductCommand, Product>()
           .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now))
           .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
    }
}