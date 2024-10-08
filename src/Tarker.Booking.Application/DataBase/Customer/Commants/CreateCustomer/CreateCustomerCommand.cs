using AutoMapper;
using Tarker.Booking.Application.Database;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Application.DataBase.Customer.Commants.CreateCustomer
{
    public class CreateCustomerCommand: ICreateCustomerCommand
    {

        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;
        public CreateCustomerCommand(IDataBaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;

        }

        public async Task<CreateCustomerModel> Execute(CreateCustomerModel model)
        {
            var entity = _mapper.Map<CustomerEntity>(model);
            await _databaseService.Customer.AddAsync(entity);
            await _databaseService.SaveAsync();
            return model;
        }
    }
}
