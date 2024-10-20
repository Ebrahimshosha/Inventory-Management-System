namespace Inventory_Management_System.VerticalSlicing.Data.Repository.Specification.ProductSpec;

public class CountProductWithSpec : BaseSpecification<Product>
{
    public CountProductWithSpec(SpecParams specParams)
        : base(p => !p.IsDeleted)
    {

    }
}