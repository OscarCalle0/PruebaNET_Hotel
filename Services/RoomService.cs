using Microsoft.EntityFrameworkCore;
using Hotel.Data; // Asegúrate de que esta referencia esté correcta
using Hotel.Models;
using Hotel.Repositories;
using Hotel.DTOs.Response;

namespace Hotel.Services
{
    public class RoomService : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var room = await GetById(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Room>> GetAll()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room?> GetById(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task<IEnumerable<Room>> GetAvailableRooms()
        {
            return await _context.Rooms
                .Where(r => r.Availability) 
                .ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetOccupiedRooms()
        {
            return await _context.Rooms
                .Where(r => !r.Availability) 
                .ToListAsync();
        }

        public async Task<RoomStatusDto> GetRoomStatus()
        {
            var totalRooms = await _context.Rooms.CountAsync();
            var availableRooms = await _context.Rooms.CountAsync(r => r.Availability);
            var occupiedRooms = totalRooms - availableRooms; 

            return new RoomStatusDto
            {
                TotalRooms = totalRooms,
                AvailableRooms = availableRooms,
                OccupiedRooms = occupiedRooms
            };
        }

        internal static void AddScoped<T1, T2>()
        {
            throw new NotImplementedException();
        }
    }
}
