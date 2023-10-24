using Microsoft.EntityFrameworkCore;

namespace IcreCreamShop
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    }
}
