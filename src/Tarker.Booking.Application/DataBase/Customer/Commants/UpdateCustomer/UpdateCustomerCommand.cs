using AutoMapper;
using Tarker.Booking.Application.Database;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Application.DataBase.Customer.Commants.UpdateCustomer
{
    public class UpdateCustomerCommand: IUpdateCustomerCommand
    {

        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;
        public UpdateCustomerCommand(IDataBaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;

        }

        public async Task<UpdateCustomerModel> Execute(UpdateCustomerModel model)
        {
            var entity = _mapper.Map<CustomerEntity>(model);
            _databaseService.Customer.Update(entity);
            await _databaseService.SaveAsync();
            return model;
        }
    }
}
