using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace SalesAPI.DbContextes
{
    public class ApplicationDbContext : IdentityUserContext<IdentityUser>
    {


        public DbSet<Item> items => Set<Item>();
        public DbSet<Manufacturer> Manufacturers => Set<Manufacturer>();
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Manufacturer>()
              .HasMany(e => e.Items)
              .WithOne(e => e.Manufacturer)
              .HasForeignKey(e => e.ManufacturerId)
              .IsRequired();


            
        }

  
       
    }
}
