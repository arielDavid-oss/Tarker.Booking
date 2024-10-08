using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.Customer.Commants.UpdateCustomer
{
    public interface IUpdateCustomerCommand
    {
        Task<UpdateCustomerModel> Execute(UpdateCustomerModel model);
    }
}
