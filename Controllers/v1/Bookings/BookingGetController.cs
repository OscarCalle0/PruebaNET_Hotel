using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Controllers.v1.Booking;
using Hotel.Models; // Asegúrate de que este espacio de nombres tenga el modelo Booking
using Hotel.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers.v1.Bookings
{
    [ApiController]
    [Route("api/v1/bookings")]
    [Tags("booking")]
    [Authorize] // Asegúrate de que este controlador requiere autenticación
    public class BookingGetController : BookingController
    {
        public BookingGetController(IBookingRepository bookingService) : base(bookingService)
        {
        }

        [HttpGet("{id}", Name = "GetBookingById")] // Asignando un nombre a la ruta
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpGet("search/{identification_number}")]
        public async Task<IActionResult> GetBookingsByIdentificationNumber(string identification_number)
        {
            var bookings = await _bookingService.GetBookingsByIdentificationNumber(identification_number);
            
            // Asegúrate de que 'bookings' sea una lista y no un grupo de métodos
            if (bookings == null || bookings.Count == 0)
            {
                return NotFound("No se encontraron reservas para el número de identificación proporcionado.");
            }

            return Ok(bookings);
        }
    }
}
