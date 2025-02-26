using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace SalesAPI.DbContextes
{
    public class ApplicationDbContext : IdentityUserContext<IdentityUser>
    {

     
        public DbSet<Item> Items => Set<Item>();
        public DbSet<Manufacturer> Manufacturers => Set<Manufacturer>();
       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // set one to many optional relationship
            // manufacturer to Items
            modelBuilder.Entity<Manufacturer>()
                .HasMany(e => e.Items)
                .WithOne(e => e.Manufacturer)
                .IsRequired(false);



            modelBuilder.Entity<Manufacturer>()
                .HasData(
                    new Manufacturer
                    {
                        Id = 1,
                        ManufacturerName = "Ford"
                    },
                    new Manufacturer
                    {
                        Id = 2,
                        ManufacturerName = "GM"
                    }
                       
                );



            modelBuilder.Entity<Item>()
                .HasData(
                    new Item
                    {
                        Id = 1,
                        ItemCode = "12626222",
                        ItemDescription = "Engine belt",
                        ManufacturerId = 2,

                    }

                );
            

        }

  
       
    }
}
