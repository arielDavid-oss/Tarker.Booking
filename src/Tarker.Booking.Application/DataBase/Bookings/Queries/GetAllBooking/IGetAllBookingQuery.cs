namespace Tarker.Booking.Application.DataBase.Bookings.Queries.GetAllBooking
{
    public interface IGetAllBookingQuery
    {
        Task<List<GetAllBookingModel>> Execute();
    }
}
