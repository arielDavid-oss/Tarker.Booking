namespace Tarker.Booking.Application.DataBase.Bookings.Commants.DeleteBooking
{
    public interface IDeleteBookingCommand
    {
        Task<bool> Execute(int BookingId);
    }
}
