using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace RestaurantMangementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Restaurant> Restaurants { get; set; } = null!;
    }
}
