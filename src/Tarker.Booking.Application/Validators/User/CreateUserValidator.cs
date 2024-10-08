using FluentValidation;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;

namespace Tarker.Booking.Application.Validators.User
{
    public class CreateUserValidator :AbstractValidator<CreateUserModel>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FirstName).NotNull().WithMessage("El campo no puede ser nulo").NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotNull().WithMessage("El campo no puede ser nulo").NotEmpty().MaximumLength(50);
            RuleFor(x => x.UserName).NotNull().WithMessage("El campo no puede ser nulo").NotEmpty().MaximumLength(50);
            RuleFor(x => x.Password).NotNull().WithMessage("El campo no puede ser nulo").NotEmpty().MaximumLength(10);

        }
    }
}
