using Microsoft.EntityFrameworkCore;
using EfCoreThree.Models;

namespace EfCoreThree.Data
{
    public class DataContext : DbContext 
    {
            public DataContext (DbContextOptions<DataContext> options) 
                : base (options) 
            { 
            }
            
            public DbSet<Product> Products { get; set; }
            public DbSet<Category> Categories { get; set; }
    }
}