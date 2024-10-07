using System.Threading.Tasks;
using Hotel.Controllers.v1.Booking;
using Hotel.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers.v1.Bookings
{
    [ApiController]
    [Route("api/v1/bookings/delete")]
    [Tags("booking")]
    public class BookingDeleteController : BookingController
    {
        public BookingDeleteController(IBookingRepository bookingService) : base(bookingService)
        {
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _bookingService.DeleteBooking(id);
            return NoContent();
        }
    }
}
