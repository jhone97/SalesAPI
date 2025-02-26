using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace SalesAPI.DbContextes
{
    public class ApplicationDbContext : IdentityUserContext<IdentityUser>
    {

        public DbSet<Manufacturer> Manufacturers => Set<Manufacturer>();
        public DbSet<Item> Items => Set<Item>();



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    ItemName = "Item1",
                    ItemCode = "I001",
                    ItemDescription = "Item1 Description",
                    


                },
                new Item
                {
                    Id = 2,
                    ItemName = "Item2",
                    ItemCode = "I002",
                    ItemDescription = "Item2 Description",
                    

                },
                new Item
                {
                    Id = 3,
                    ItemName = "Item3",
                    ItemCode = "I003",
                    ItemDescription = "Item3 Description",
                    

                });

            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer
                {
                    Id = 1,
                    ManufacturerName = "Ford",
                    
                },
                new Manufacturer
                {
                    Id = 2,
                    ManufacturerName = "GM",
                    
                },
                new Manufacturer
                {
                    Id = 3,
                    ManufacturerName = "Nissan",
                   
                });


        }

  
       
    }
}
