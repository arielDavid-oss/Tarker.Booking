using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Database;

namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery: IGetCustomerByIdQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetCustomerByIdQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;


        }

        public async Task<GetCustomerByIdModel> Execute(int CustomerId)
        {
            var entity = await _dataBaseService.Customer
                .FirstOrDefaultAsync(x => x.CustomerId == CustomerId);
            return _mapper.Map<GetCustomerByIdModel>(entity);
        }
    }
}
