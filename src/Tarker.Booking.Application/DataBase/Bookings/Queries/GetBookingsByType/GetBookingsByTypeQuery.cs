using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Database;

namespace Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingsByType
{
    public class GetBookingsByTypeQuery : IGetBookingsByTypeQuery
    {

        public readonly IDataBaseService _dataBaseService;

        public GetBookingsByTypeQuery(IDataBaseService dataBaseService)
        {

            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetBookingsByTypeModel>> Execute(string type)
        {
            var result = await (from booking in _dataBaseService.Booking
                                join Customer in _dataBaseService.Customer
                                on booking.CustomerId equals Customer.CustomerId
                                where booking.Type == type

                                select new GetBookingsByTypeModel
                                {
                                    Code = booking.Code,
                                    RegisterDate = booking.RegisterDate,
                                    Type = booking.Type,
                                    CustomerFullName = Customer.FullName,
                                    CustomerDocumentNumber = Customer.DocumentNumber
                                }).ToListAsync();
            return result;

        }
    }
}
