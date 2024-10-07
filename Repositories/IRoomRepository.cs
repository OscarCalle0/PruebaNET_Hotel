using Hotel.DTOs.Response;
using Hotel.Models; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAll(); // Método para obtener todas las habitaciones
        Task<Room> GetById(int id); // Método para obtener una habitación por ID
        Task<IEnumerable<Room>> GetAvailableRooms(); // Método para obtener habitaciones disponibles
        Task<IEnumerable<Room>> GetOccupiedRooms(); // Método para obtener habitaciones ocupadas
        Task<RoomStatusDto> GetRoomStatus(); // Método para obtener el estado de las habitaciones
    }
}
