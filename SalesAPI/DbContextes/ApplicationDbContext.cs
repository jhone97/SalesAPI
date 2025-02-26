using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace SalesAPI.DbContextes
{
    public class ApplicationDbContext : IdentityUserContext<IdentityUser>
    {

        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<Manufacturer> Manufacturers => Set<Manufacturer>();
        public DbSet<Stock> Stocks => Set<Stock>();
        public DbSet<User> users => Set<User>();
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


         


        }

  
       
    }
}
