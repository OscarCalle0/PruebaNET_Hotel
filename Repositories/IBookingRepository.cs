using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Models;

namespace Hotel.Repositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetBookingsByGuestId(int guestId);
        Task<Booking> GetBookingById(int id);
        Task AddBooking(Booking booking);
        Task DeleteBooking(int id);
    }
}
