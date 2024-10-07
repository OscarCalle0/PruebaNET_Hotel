using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Models;
using Hotel.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers.v1.Guest
{
    [ApiController]
    [Route("api/v1/guests/delete")]
    [Tags("guest")]
    public class GuestDeleteController(IGuestRepository guestService) : GuestController(guestService)
    {
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            await _guestService.DeleteGuest(id);
            return NoContent();
        }
    }
}
