using Microsoft.EntityFrameworkCore;
using milesmorales_mvc.Models;


namespace milesmorales_mvc
{
    public class MilesmoralesDBContextcs : DbContext
    {
        public MilesmoralesDBContextcs() : base()
        {
        }
        public MilesmoralesDBContextcs(DbContextOptions<MilesmoralesDBContextcs> contextOptions) : base(contextOptions)
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Color>().ToTable("Color");

            modelBuilder.Entity<Brand>().ToTable("Brand");
        }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
