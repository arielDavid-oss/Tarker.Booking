using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Database;

namespace Tarker.Booking.Application.DataBase.User.Queries.GetAllUser
{
    public class GetAllUserQuery: IGetAllUserQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetAllUserQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;

        }

        public async Task<List<GetAllUserModel>> Execute()
        {
            var listEntity = await _dataBaseService.User.ToListAsync();
            return _mapper.Map<List<GetAllUserModel>>(listEntity);
        }

        public Task<List<GetAllUserModel>> Execute(int userId)
        {
            throw new NotImplementedException();
        }

     
    }
}
