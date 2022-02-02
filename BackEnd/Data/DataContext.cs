using BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEnd
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) 
        {
        
        
        }


        public DbSet<IUser> MyProperty { get; set; }


    }
}
