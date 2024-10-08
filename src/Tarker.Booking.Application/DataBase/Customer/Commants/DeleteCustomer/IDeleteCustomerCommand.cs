using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.Customer.Commants.DeleteCustomer
{
    public interface IDeleteCustomerCommand
    {
        Task<bool> Execute(int CustomerId);
    }
}
