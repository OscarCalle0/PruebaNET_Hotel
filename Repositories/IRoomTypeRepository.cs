using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Models;

namespace Hotel.Repositories
{
    public interface IRoomTypeRepository
    {
        Task<IEnumerable<RoomType>> GetAllRoomTypes();
        Task<RoomType> GetRoomTypeById(int id);
    }
}
