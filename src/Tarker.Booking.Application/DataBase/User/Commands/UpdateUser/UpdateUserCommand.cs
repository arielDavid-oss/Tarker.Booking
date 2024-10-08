using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Database;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.DataBase.User.Commands.UpdateUser
{
    public class UpdateUserCommand: IUpdateUserCommand
    {
        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;

        public  UpdateUserCommand(IDataBaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<UpdateUserModel> Execute(UpdateUserModel model)
        {
            var entity = _mapper.Map<UserEntity>(model); 
            _databaseService.User.Update(entity);
            await _databaseService.SaveAsync();
            return model;
        }
    }
}
