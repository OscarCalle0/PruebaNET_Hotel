using Hotel.DTOs.Response;
using Hotel.Models; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAll(); 
        Task<Room> GetById(int id); 
        Task<IEnumerable<Room>> GetAvailableRooms(); 
        Task<IEnumerable<Room>> GetOccupiedRooms(); 
        Task<RoomStatusDto> GetRoomStatus(); 
    }
}
