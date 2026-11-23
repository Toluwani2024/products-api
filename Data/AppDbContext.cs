 using Microsoft.EntityFrameworkCore;
 using Product_Api.Models;
  namespace Product_Api.Data;
   public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }