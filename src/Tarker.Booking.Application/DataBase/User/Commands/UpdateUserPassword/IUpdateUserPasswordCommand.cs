using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword
{
    public interface IUpdateUserPasswordCommand
    {
        Task<bool> Execute(UpdateUserPasswordModel model);
    }
}
