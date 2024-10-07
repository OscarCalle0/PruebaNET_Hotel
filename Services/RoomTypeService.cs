using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Data;
using Hotel.Models;
using Hotel.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Services
{
    public class RoomTypeService : IRoomTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomTypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoomType>> GetAllRoomTypes()
        {
            return await _context.RoomTypes.ToListAsync();
        }

        public async Task<RoomType> GetRoomTypeById(int id)
        {
            return await _context.RoomTypes.FirstOrDefaultAsync(roomType => roomType.Id == id);
        }
    }
}
