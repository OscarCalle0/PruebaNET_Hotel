using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Models;
using Hotel.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers.v1.Rooms
{
    [ApiController]
    [Route("api/v1/room_types")]
    [Tags("room_types")]
    public class RoomTypeGetController(IRoomTypeRepository roomTypeService) : RoomTypeController(roomTypeService)
    {
        [HttpGet("room_types")]
        public async Task<IActionResult> GetAllRoomTypes()
        {
            var roomTypes = await service.GetAllRoomTypes();
            return Ok(roomTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomTypeById(int id)
        {
            var roomType = await service.GetRoomTypeById(id);
            if (roomType == null)
                return NotFound();

            return Ok(roomType);
        }
    }
}
