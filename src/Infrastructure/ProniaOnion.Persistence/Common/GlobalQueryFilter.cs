
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Common
{
    public static class GlobalQueryFilter
    {
        public static void ApplyQuery<T>(ModelBuilder builder) where T : BaseEntity, new()
        {
            builder.Entity<T>().HasQueryFilter(x => x.IsDeleted == false);
        }

        public static void ApplyQueryFilters(this ModelBuilder modelBuilder)
        {
            ApplyQuery<Category>(modelBuilder);
            ApplyQuery<Product>(modelBuilder);
            ApplyQuery<Color>(modelBuilder);
            ApplyQuery<ProductColor>(modelBuilder);
        }
    }
}
