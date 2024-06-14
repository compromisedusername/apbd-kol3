using System.Linq.Expressions;
using WebApplication4.Models;

namespace WebApplication4.Data;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    protected ApplicationContext()
    {
    }
    public ApplicationContext(DbContextOptions options) : base(options){}
    
    public DbSet<BoatStandard> BoatStandards { get; set; }
    public DbSet<Client> Client { get; set; }
    public DbSet<ClientCategory> ClientCategory { get; set; }
    public DbSet<Reservation> Reservation { get; set; }
    public DbSet<Sallboat> Sallboat { get; set; }


   
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

     
        
        modelBuilder.Entity<Client>().HasData(new List<Client>
        {
            new Client()
            {
                IdClient = 1,
                Name = "name",
                LastName = "lalsd",
                Birthday = DateTime.Now,
                Pesel = "asdASD233",
                Email = "asdasd",
                IdClientCategory = 1
            }
        });
        
        modelBuilder.Entity<ClientCategory>().HasData(new List<ClientCategory>
        {
            new ClientCategory()
            {
                IdClientCategory = 1,
                Name = "asdasd",
                DiscountPerc = 123123
            }
        });
        
        modelBuilder.Entity<Reservation>().HasData(new List<Reservation>
        {
            new Reservation()
            {
                IdReservation = 1,
                IdClient = 1,
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now,
                IdBoatStandard = 1,
                Capacity = 1,
                NumOfBoats = 1,
                Fulfilled = true,
                Price = 1123,
                CancelReason = "basd"
                
            }
        });modelBuilder.Entity<BoatStandard>().HasData(new List<BoatStandard>
        {
            new BoatStandard()
            {
                IdBoatStandard = 1,
                Name = "brak",
                Level = 1
            }
        });;modelBuilder.Entity<Sallboat>().HasData(new List<Sallboat>
        {
            new Sallboat()
            {
             IdSallboat   = 1,
             Name = "brak",
             Capacity = 1,
             Description = "asd",
             IdBoatStandard = 1,
             Price = 1
            }
        });
        
        
        
        
        
        
    }
}