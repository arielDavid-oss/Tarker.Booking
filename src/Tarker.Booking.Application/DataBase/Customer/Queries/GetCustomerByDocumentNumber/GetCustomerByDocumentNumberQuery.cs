using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Database;

namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber
{
    public class GetCustomerByDocumentNumberQuery: IGetCustomerByDocumentNumberQuery
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetCustomerByDocumentNumberQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;

        }

        public async Task<GetCustomerByDocumentNumberModel> Execute(string DocumentNumber)
        {
            var customerEntity = await _dataBaseService.Customer
                .FirstOrDefaultAsync(x => x.DocumentNumber == DocumentNumber);
            return _mapper.Map<GetCustomerByDocumentNumberModel>(customerEntity);
        }
    }
}
