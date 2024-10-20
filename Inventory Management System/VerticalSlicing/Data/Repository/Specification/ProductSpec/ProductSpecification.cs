namespace Inventory_Management_System.VerticalSlicing.Data.Repository.Specification.ProductSpec;


public class ProductSpecification : BaseSpecification<Product>
{
    public ProductSpecification(int id)
        : base(r => r.Id == id)
    {
        Includes.Add(p => p.Include(p => p.WarehouseProducts));
    }
    public ProductSpecification(SpecParams spec)
    {
        Includes.Add(p => p.Include(p => p.WarehouseProducts));


        if (!string.IsNullOrEmpty(spec.Search))
        {
            Criteria = p => p.Name.ToLower().Contains(spec.Search.ToLower());
        }

        if (!string.IsNullOrEmpty(spec.Sort))
        {
            switch (spec.Sort.ToLower())
            {
                case "Name":
                    AddOrderBy(p => p.Name);
                    break;
                default:
                    AddOrderBy(p => p.Price);
                    break;
            }
        }

        ApplyPagination(spec.PageSize * (spec.PageIndex - 1), spec.PageSize);
    }
}