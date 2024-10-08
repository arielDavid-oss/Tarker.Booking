using AutoMapper;
using Tarker.Booking.Application.DataBase.Bookings.Commants.CreateBooking;
using Tarker.Booking.Application.DataBase.Bookings.Commants.UpdateBooking;
using Tarker.Booking.Application.DataBase.Customer.Commants.CreateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commants.UpdateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetAllCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;
using Tarker.Booking.Application.DataBase.User.Queries.GetAllUser;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserById;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using Tarker.Booking.Domain.Entities.Booking;
using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.Configuration
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        { 

            CreateMap<UserEntity, CreateUserModel>().ReverseMap();
            CreateMap<UserEntity, UpdateUserModel>().ReverseMap();

            CreateMap<UserEntity, GetAllUserModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByIdModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByUserNameAndPasswordModel>().ReverseMap();


            CreateMap<CustomerEntity, CreateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, UpdateCustomerModel>().ReverseMap();

            CreateMap<CustomerEntity, GetAllCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByIdModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByDocumentNumberModel>().ReverseMap();

            CreateMap<BookingEntity, CreateBookingModel>().ReverseMap();
            CreateMap<BookingEntity, UpdateBookingModel>().ReverseMap();

        
        }
    }
}
