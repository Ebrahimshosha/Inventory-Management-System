using Inventory_Management_System.VerticalSlicing.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory_Management_System.VerticalSlicing.Data.Configuration;

public class InventoryTransactionConfig : IEntityTypeConfiguration<InventoryTransaction>
{
    public void Configure(EntityTypeBuilder<InventoryTransaction> builder)
    {
        builder.Property(o => o.TransactionType).HasConversion
           (
               status => status.ToString(),
               status => (TransactionType)Enum.Parse(typeof(TransactionType), status)
          );
    }
}