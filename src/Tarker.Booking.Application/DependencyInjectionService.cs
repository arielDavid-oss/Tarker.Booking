using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Tarker.Booking.Application.Configuration;
using Tarker.Booking.Application.DataBase.Bookings.Commants.CreateBooking;
using Tarker.Booking.Application.DataBase.Bookings.Commants.DeleteBooking;
using Tarker.Booking.Application.DataBase.Bookings.Commants.UpdateBooking;
using Tarker.Booking.Application.DataBase.Bookings.Queries.GetAllBooking;
using Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingsByDocumentNumber;
using Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingsByType;
using Tarker.Booking.Application.DataBase.Customer.Commants.CreateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commants.DeleteCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commants.UpdateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetAllCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;
using Tarker.Booking.Application.DataBase.User.Commands.DeleteUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword;
using Tarker.Booking.Application.DataBase.User.Queries.GetAllUser;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserById;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using Tarker.Booking.Application.Validators.Booking;
using Tarker.Booking.Application.Validators.Customer;
using Tarker.Booking.Application.Validators.User;

namespace Tarker.Booking.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });
            
            services.AddSingleton(mapper.CreateMapper());

            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            services.AddTransient<IUpdateUserPasswordCommand, UpdateUserPasswordCommand>();

            services.AddTransient<IGetAllUserQuery, GetAllUserQuery>();
            services.AddTransient<IGetUserByIdQuery, GetUserByIdQuery>();
            services.AddTransient<IGetUserByUserNameAndPasswordQuery, GetUserByUserNameAndPasswordQuery>();
         
            services.AddTransient<ICreateCustomerCommand, CreateCustomerCommand>();
            services.AddTransient<IUpdateCustomerCommand, UpdateCustomerCommand>();
            services.AddTransient<IDeleteCustomerCommand, DeleteCustomerCommand>();

            services.AddTransient<IGetAllCustomerQuery, GetAllCustomerQuery>();
            services.AddTransient<IGetCustomerByIdQuery, GetCustomerByIdQuery>();
            services.AddTransient<IGetCustomerByDocumentNumberQuery, GetCustomerByDocumentNumberQuery>();
           
            
            services.AddTransient<ICreateBookingCommand, CreateBookingCommand>();
            services.AddTransient<IUpdateBookingCommand, UpdateBookingCommand>();
            services.AddTransient<IDeleteBookingCommand, DeleteBookingCommand>();
          
            services.AddTransient<IGetAllBookingQuery, GetAllBookingQuery>();
            services.AddTransient<IGetBookingsByDocumentNumberQuery, GetBookingsByDocumentNumberQuery>();
            services.AddTransient<IGetBookingsByTypeQuery, GetBookingsByTypeQuery>();

            services.AddScoped<IValidator<CreateUserModel>, CreateUserValidator >();
            services.AddScoped<IValidator<UpdateUserModel>, UpdateUserValidator >();
            services.AddScoped<IValidator<UpdateUserPasswordModel>, UpdateUserPasswordValidator >();
            services.AddScoped<IValidator<(string, string)>, IGetUserByUserNameAndPasswordValidator >();
           
            
            services.AddScoped<IValidator<CreateCustomerModel>, CreateCustomerValidator>();
            services.AddScoped<IValidator<UpdateCustomerModel>, UpdateCustomerValidator>();

            services.AddScoped<IValidator<CreateBookingModel>, CreateBookingValidator>();
            
            
            
            
            return services;
        }
    }
}
