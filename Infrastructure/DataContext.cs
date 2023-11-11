using BarberShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Infrastructure
{
    public class DataContext : IdentityDbContext<BarberUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<BarberUser> BarberUsers { get; set; }

        public DbSet<BarberStock> BarberStocks { get; set; }

        public DbSet<BarberService> BarberServices { get; set; }

    }
}
