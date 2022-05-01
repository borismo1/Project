using BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEnd
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {   
        
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
