using System.Threading.Tasks;
using Hotel.Controllers.v1.Booking;
using Hotel.Models; // Asegúrate de tener el espacio de nombres correcto
using Hotel.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers.v1.Bookings
{
    [ApiController]
    [Route("api/v1/bookings/post")]
    [Tags("booking")]
    public class BookingPostController : BookingController
    {
        public BookingPostController(IBookingRepository bookingService) : base(bookingService)
        {
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddBooking([FromBody] Hotel.Models.Booking booking)
        {
           
            await _bookingService.AddBooking(booking);
            
            return CreatedAtRoute("GetBookingById", new { id = booking.Id
        }, booking);
        }
}
}
