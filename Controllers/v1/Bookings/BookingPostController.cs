using System.Threading.Tasks;
using Hotel.Controllers.v1.Booking;
using Hotel.DTOs.Requests; // Asegúrate de que este espacio de nombres esté correcto
using Hotel.DTOs.Response; // Para el BookingResponseDto
using Hotel.Models; 
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
        public async Task<IActionResult> AddBooking([FromBody] BookingRequestDto bookingRequestDto)
        {
            // Mapea BookingRequestDto a Booking
            var booking = new Hotel.Models.Booking
            {
                RoomId = bookingRequestDto.RoomId,
                GuestId = bookingRequestDto.GuestId,
                EmployeeId = bookingRequestDto.EmployeeId,
                StartDate = bookingRequestDto.StartDate,
                EndDate = bookingRequestDto.EndDate,
                TotalCost = bookingRequestDto.TotalCost
            };

            await _bookingService.AddBooking(booking);

            // Mapea de vuelta a BookingResponseDto para la respuesta
            var responseDto = new BookingResponseDto
            {
                Id = booking.Id,
                RoomId = booking.RoomId,
                GuestId = booking.GuestId,
                EmployeeId = booking.EmployeeId,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                TotalCost = booking.TotalCost
            };

            return CreatedAtRoute("GetBookingById", new { id = responseDto.Id }, responseDto);
        }
    }
}
