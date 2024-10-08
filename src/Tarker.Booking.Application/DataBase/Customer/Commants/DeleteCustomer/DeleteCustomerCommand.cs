

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Database;

namespace Tarker.Booking.Application.DataBase.Customer.Commants.DeleteCustomer
{
    public class DeleteCustomerCommand: IDeleteCustomerCommand
    {

        private readonly IDataBaseService _databaseService;
       
        public DeleteCustomerCommand(IDataBaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
           

        }

        public async Task<bool> Execute(int CustomerId)
        {
            var entity = await _databaseService.Customer
                .FirstOrDefaultAsync(x => x.CustomerId == CustomerId);

            if (entity == null)
                return false;

            _databaseService.Customer.Remove(entity);
            return await _databaseService.SaveAsync();
        }
    }
}
