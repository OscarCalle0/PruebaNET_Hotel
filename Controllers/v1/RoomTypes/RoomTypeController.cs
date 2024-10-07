using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Models;
using Hotel.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers.v1.Rooms
{
    [ApiController]
    [Route("api/v1/room_types")]
    public class RoomTypeController : ControllerBase
    {
        protected readonly IRoomTypeRepository service;

        public RoomTypeController(IRoomTypeRepository roomTypeService)
        {
            service = roomTypeService;
        }


    }
}
