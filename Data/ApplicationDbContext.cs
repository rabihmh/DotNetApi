using Microsoft.EntityFrameworkCore;

namespace DotNetApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }
        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Product>().ToTable("Products").HasKey("Id");
            modelBuilder.Entity<Product>().ToTable("Products");
        } 
    }
}
