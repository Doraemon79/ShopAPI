using Microsoft.EntityFrameworkCore;

namespace ShopApi
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Orders> TodoItems => Set<Orders>();
    }
}
