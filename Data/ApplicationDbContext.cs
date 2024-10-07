using Hotel.Models;
using Hotel.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Data;
public class ApplicationDbContext : DbContext
{
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomType> RoomTypes { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // call of the sedders
        RoomTypeSeeder.SeedRoomTypes(modelBuilder);
        RoomSeeder.SeedRooms(modelBuilder);
    }
}