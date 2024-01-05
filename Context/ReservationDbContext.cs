using Microsoft.EntityFrameworkCore ; 
using ReservationProject.Models.ORM ;


namespace ReservationProject.Context
{
    public class ReservationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connection string
            optionsBuilder.UseSqlServer("Server=DESKTOP-9D3D7OQ\\SQLEXPRESS;Database=ReservationDbContext;Trusted_Connection=True;");
        }

        public DbSet<Client> Clients { get; set; }
        
        public DbSet<Company> Companies { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Reservation> Reservations { get; set; }


        
    }
}

