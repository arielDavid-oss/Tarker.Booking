using AutoMapper;
using Tarker.Booking.Application.Database;
using Tarker.Booking.Domain.Entities.Booking;

namespace Tarker.Booking.Application.DataBase.Bookings.Commants.UpdateBooking
{
    public class UpdateBookingCommand: IUpdateBookingCommand
    {


        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;
        public UpdateBookingCommand(IDataBaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;

        }

        public async Task<UpdateBookingModel> Execute(UpdateBookingModel model)
        {

            var entity = _mapper.Map<BookingEntity>(model);
            _databaseService.Booking.Update(entity);
            await _databaseService.SaveAsync();
            return model;

        }
    }
}
