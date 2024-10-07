using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Data;
using Hotel.Models;
using Hotel.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Services
{
    public class BookingService : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetBookingsByGuestId(int guestId)
        {
            return await _context.Bookings
                .Where(b => b.GuestId == guestId)
                .ToListAsync();
        }

        public async Task<Booking> GetBookingById(int id)
        {
            return await _context.Bookings.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }
    }
}
