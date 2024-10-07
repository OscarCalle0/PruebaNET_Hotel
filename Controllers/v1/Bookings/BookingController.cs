using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Models;
using Hotel.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers.v1.Booking
{
    [ApiController]
    [Route("api/v1/bookings")]
    [Tags("booking")]
     public class BookingController : ControllerBase
    {
        protected readonly IBookingRepository _bookingService;

        public BookingController(IBookingRepository bookingService)
        {
            _bookingService = bookingService;
        }
    }
}