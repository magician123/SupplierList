using Microsoft.EntityFrameworkCore;

namespace Supplier.Web.Model
{
    public class SupplierDbContext : DbContext
    {
        public SupplierDbContext(DbContextOptions<SupplierDbContext> options) : base(options)
        {

        }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}
