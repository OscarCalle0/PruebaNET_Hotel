using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Models;
using Hotel.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hotel.Services;

namespace Hotel.Controllers.v1.Guest
{
    [ApiController]
    [Route("api/v1/guests/post")]
    [Tags("guest")]
    public class GuestPostController(IGuestRepository guestService) : GuestController(guestService)
    {
       [HttpPost]
        public async Task<IActionResult> AddGuest([FromBody] Hotel.Models.Guest guest)
        {
            await _guestService.AddGuest(guest);
            return CreatedAtAction(
                actionName: "GetGuestById",  
                controllerName: "GuestGet",   
                routeValues: new { id = guest.Id }, 
                value: guest
            );
        }
    }
}
