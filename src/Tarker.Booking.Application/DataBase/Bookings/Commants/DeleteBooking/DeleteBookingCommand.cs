
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Database;

namespace Tarker.Booking.Application.DataBase.Bookings.Commants.DeleteBooking
{
    public class DeleteBookingCommand : IDeleteBookingCommand
    {
        private readonly IDataBaseService _databaseService;

        public DeleteBookingCommand(IDataBaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;

        }

        public async Task<bool> Execute(int BookingId)
        {
            var entity = await _databaseService.Booking
               .FirstOrDefaultAsync(x => x.BookingId == BookingId);

            if (entity == null)
                return false;

            _databaseService.Booking.Remove(entity);
            return await _databaseService.SaveAsync();
        }
    }
}
