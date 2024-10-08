using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Database;

namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetAllCustomer
{
    public class GetAllCustomerQuery: IGetAllCustomerQuery
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetAllCustomerQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;

        }

        public async Task<List<GetAllCustomerModel>> Execute()
        {
            var listEntity = await _dataBaseService.Customer.ToListAsync();
            return _mapper.Map<List<GetAllCustomerModel>>(listEntity);
        }
    }
}
