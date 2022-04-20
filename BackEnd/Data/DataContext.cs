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

    }
}
