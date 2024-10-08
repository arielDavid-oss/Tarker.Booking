namespace Tarker.Booking.Application.DataBase.Bookings.Commants.UpdateBooking
{
    public class UpdateBookingModel
    {
        public DateTime RegisterDate { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }

    }
}
