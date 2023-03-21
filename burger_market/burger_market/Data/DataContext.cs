using Microsoft.EntityFrameworkCore;
using burger_market.Models;

namespace burger_market.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Burger> Burgers { get; set; } 
    }
}
