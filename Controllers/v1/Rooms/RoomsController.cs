using Hotel.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers.v1.Rooms
{
    [ApiController]
    [Route("api/v1/rooms")]
    public class RoomsController : ControllerBase
    {
        protected readonly IRoomRepository service;

        public RoomsController(IRoomRepository roomRepository)
        {
            service = roomRepository;
        }
    }
}