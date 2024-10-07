using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Models;
using Hotel.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers.v1.Rooms
{

    [ApiController]
    [Route("api/v1/rooms")]
    [Tags("rooms")]
    public class RoomsGetController : RoomsController
    {
        // Constructor that injects the service
        public RoomsGetController(IRoomRepository roomService) : base(roomService) // Call the base constructor
        {
        }
        //2.GET /api/v1/rooms/available
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableRooms()
        {
            var availableRooms = await service.GetAvailableRooms(); // Use the inherited property from the base controller
            return Ok(availableRooms);
        }

        // 5. GET /api/v1/rooms/status
        [HttpGet("status")]
        public async Task<IActionResult> GetRoomStatus()
        {
            var status = await service.GetRoomStatus(); // Use the inherited property from the base controller
            return Ok(status);
        }

        [Authorize]
        // 10. GET /api/v1/rooms/occupied
        [HttpGet("occupied")]
        public async Task<IActionResult> GetOccupiedRooms()
        {
            var occupiedRooms = await service.GetOccupiedRooms(); // Use the inherited property from the base controller
            return Ok(occupiedRooms);
        }

        //5.GET /api/v1/rooms
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await service.GetAll(); // Use the inherited property from the base controller
            return Ok(rooms);
        }

        //6.GET /api/v1/rooms/{id}
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = await service.GetById(id); // Use the inherited property from the base controller
            if (room == null)
                return NotFound(); // Returns 404 if the room is not found

            return Ok(room); // Returns the details of the room
        }
    }
}
