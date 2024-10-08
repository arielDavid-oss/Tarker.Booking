using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.External.GetTokenJwt
{
    public interface IGetTokenJwtService
    {
        string Execute(string id);
    }
}
