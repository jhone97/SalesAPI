using Entities;
using Microsoft.EntityFrameworkCore;

namespace SalesAPI.DbContextes
{
    public class ClientsContext : DbContext
    {
        public ClientsContext(DbContextOptions<ClientsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, Name = "Khaled", EmailAddress = "khaled@alkaalife.com", CompanyName = "Alkaalife" },
                new Client { Id = 2, Name = "Ali", EmailAddress = "ali@alkaalife.com", CompanyName = "Alkaalife" },
                new Client { Id = 3, Name = "Escandar", EmailAddress = "escandar@aljazerr.com", CompanyName = "Aljazerr" },
                new Client { Id = 4, Name = "Zaki", EmailAddress = "zaki@jubali.com", CompanyName = "Jubali" },
                new Client { Id = 5, Name = "Naif", EmailAddress = "naif@jubali.com", CompanyName = "Jubali" }
            );


          
        }

  

        public DbSet<Client> Clients { get; set; }
       
    }
}
