using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SalesAPI.DbContextes
{
    public class ClientsContext : IdentityUserContext<IdentityUser>
    {
        public ClientsContext(DbContextOptions<ClientsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, Username = "Khaled", EmailAddress = "khaled@alkaalife.com", CompanyName = "Alkaalife", Password = "ughuwr@" },
                new Client { Id = 2, Username = "Ali", EmailAddress = "ali@alkaalife.com", CompanyName = "Alkaalife", Password = "lwergy4" },
                new Client { Id = 3, Username = "Escandar", EmailAddress = "escandar@aljazerr.com", CompanyName = "Aljazerr", Password = "3432edf" },
                new Client { Id = 4, Username = "Zaki", EmailAddress = "zaki@jubali.com", CompanyName = "Jubali", Password = "23452rfwfd" },
                new Client { Id = 5, Username = "Naif", EmailAddress = "naif@jubali.com", CompanyName = "Jubali", Password = "adadad4" }
            );
        }

  

        public DbSet<Client> Clients { get; set; }
       
    }
}
