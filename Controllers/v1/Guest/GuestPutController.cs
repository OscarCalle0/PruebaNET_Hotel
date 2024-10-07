using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Models;
using Hotel.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers.v1.Guest
{
    [ApiController]
    [Route("api/v1/guests/put")]
    [Tags("guest")]
    public class GuestPutController(IGuestRepository guestService) : GuestController(guestService)
    {
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateGuest(int id, [FromBody] Hotel.Models.Guest guest)
        {
            guest.Id = id;
            await _guestService.UpdateGuest(guest);
            return NoContent();
        }
    }
}
