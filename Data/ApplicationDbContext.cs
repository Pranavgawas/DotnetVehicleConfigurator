using demo1.Models;
using Microsoft.EntityFrameworkCore;

namespace Vehicle.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Segment> Segments { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Vehicle_detail> Vehicle_Details { get; set; }
        public DbSet<Alternate_Component> Alternate_Components { get; set;}
        public DbSet<User> Users { get; set; }
    }
}

