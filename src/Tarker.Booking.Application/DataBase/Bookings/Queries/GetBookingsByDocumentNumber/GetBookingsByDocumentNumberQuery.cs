using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Database;

namespace Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingsByDocumentNumber
{
    public class GetBookingsByDocumentNumberQuery: IGetBookingsByDocumentNumberQuery
    {

        private readonly IDataBaseService databaseService;

        public GetBookingsByDocumentNumberQuery(IDataBaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        public async Task<List<GetBookingsByDocumentNumberModel>> Execute(string documentNumber)
        {
            var result = await (from booking in databaseService.Booking
                                join Customer in databaseService.Customer
                                on booking.CustomerId equals Customer.CustomerId

                                where Customer.DocumentNumber == documentNumber
                                select new GetBookingsByDocumentNumberModel
                                {
                                    Code = booking.Code,
                                    RegisterDate = booking.RegisterDate,
                                    Type = booking.Type
                                }).ToListAsync();
            return result;
        }
    }
}
