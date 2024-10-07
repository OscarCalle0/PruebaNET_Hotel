using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Seeders;
public static class RoomSeeder
{
    public static void SeedRooms(ModelBuilder modelBuilder)
    {
        int roomId = 1;
        for (int floor = 1; floor <= 5; floor++)
        {
            for (int roomNumber = 1; roomNumber <= 10; roomNumber++)
            {
                modelBuilder.Entity<Room>().HasData(
                    new Room
                    {
                        Id = roomId,
                        RoomNumber = $"{floor}0{roomNumber}", // Room format "101", "102"
                        RoomTypeId = AssignRoomType(roomId), // Assign room type
                        PricePerNight = GetRoomPrice(roomId),
                        Availability = true, // All rooms start available
                        MaxOccupancyPersons = GetRoomCapacity(roomId)
                    }
                );
                roomId++;
            }
        }
    }

    // Method to assign room types
    private static int AssignRoomType(int roomId)
    {
        // Room distribution
        if (roomId <= 10) return 1;  // Single Room (first floor)
        if (roomId <= 20) return 2;  // Double Room (second floor)
        if (roomId <= 30) return 3;  // Suite (third floor)
        if (roomId <= 50) return 4;  // Family Room (fourth and fifth floors)
        return 1;
    }

    // Method to handle room prices
    private static double GetRoomPrice(int roomId)
    {
        // Assign price according to room type
        if (roomId <= 10) return 50.0;  // Single Room
        if (roomId <= 20) return 80.0;  // Double Room
        if (roomId <= 30) return 150.0; // Suite
        return 200.0;                    // Family Room
    }

    // Method to handle room capacity
    private static int GetRoomCapacity(int roomId)
    {
        // Manage capacity according to room type
        if (roomId <= 10) return 1;  // Single Room
        if (roomId <= 20) return 2;  // Double Room
        if (roomId <= 30) return 2;  // Suite
        return 4;                    // Family Room
    }
}
