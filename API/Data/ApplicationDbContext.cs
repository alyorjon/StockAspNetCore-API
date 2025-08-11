
using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Stock2> Stock2s { get; set; }
        public DbSet<Stock3> Stock3s { get; set; }
    }
}