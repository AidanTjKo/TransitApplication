using Microsoft.EntityFrameworkCore;
using TransitApplication.Models;

namespace TransitApplication.Data
{
    public class TransitApplicationContext : DbContext
    {
        public TransitApplicationContext(DbContextOptions<TransitApplicationContext> options) : base(options)
        {
            
        }

        public DbSet<TransitRoute> TransitRoutes {get; set;} = null!;
    }
}
