namespace Tarker.Booking.Application.DataBase.Bookings.Commants.CreateBooking
{
    public interface ICreateBookingCommand
    {
        Task<CreateBookingModel> Execute(CreateBookingModel model);
    }
}
