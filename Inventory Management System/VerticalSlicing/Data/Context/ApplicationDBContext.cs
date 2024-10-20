using Inventory_Management_System.VerticalSlicing.Data.Entities;
using System.Reflection;

namespace FoodApp.Api.VerticalSlicing.Data.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<WarehouseProduct> WarehouseProducts { get; set; }
        public DbSet<StockTransfer> stockTransfers { get; set; }
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
    }
}
