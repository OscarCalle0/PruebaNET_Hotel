using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Models;
using Hotel.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers.v1.Guest
{
    [ApiController]
    [Route("api/v1/guests/get")]
    [Tags("guest")]
    public class GuestGetController(IGuestRepository guestService) : GuestController(guestService)
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllGuests()
        {
            var guests = await _guestService.GetAllGuests();
            return Ok(guests);
        }

        [HttpGet("search/{keyword}")]
        [Authorize]
        public async Task<IActionResult> SearchGuests(string keyword)
        {
            var guests = await _guestService.SearchGuests(keyword);
            return Ok(guests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGuestById(int id)
        {
            var guest = await _guestService.GetGuestById(id);
            if (guest == null)
            {
                return NotFound();
            }
            return Ok(guest);
        }
    }
}
