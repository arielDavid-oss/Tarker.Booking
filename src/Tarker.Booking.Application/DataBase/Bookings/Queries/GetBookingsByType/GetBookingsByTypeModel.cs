namespace Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingsByType
{
    public class GetBookingsByTypeModel
    {

        public DateTime RegisterDate { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }

        public string CustomerFullName { get; set; }
        public string CustomerDocumentNumber { get; set; }
    }
}
