using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Database;

namespace Tarker.Booking.Application.DataBase.User.Queries.GetUserByUserNameAndPassword
{
    public class GetUserByUserNameAndPasswordQuery: IGetUserByUserNameAndPasswordQuery
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetUserByUserNameAndPasswordQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;


        }

        public async Task<GetUserByUserNameAndPasswordModel> Execute(string userName, string password)
        {
            var entity = await _dataBaseService.User.FirstOrDefaultAsync(x => x.UserName == userName && x.Password == password);
            return _mapper.Map<GetUserByUserNameAndPasswordModel>(entity);
        }

    }
}

