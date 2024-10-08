namespace Tarker.Booking.Application.DataBase.Bookings.Commants.UpdateBooking
{
    public interface IUpdateBookingCommand
    {
        Task<UpdateBookingModel> Execute(UpdateBookingModel model);
    }
}
