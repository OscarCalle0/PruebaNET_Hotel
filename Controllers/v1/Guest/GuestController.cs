using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Models;
using Hotel.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers.v1.Guest
{
    [ApiController]
    [Route("api/v1/guests")]
    public class GuestController : ControllerBase
    {
        protected readonly IGuestRepository _guestService;

        public GuestController(IGuestRepository guestService)
        {
            _guestService = guestService;
        }
    }
}
