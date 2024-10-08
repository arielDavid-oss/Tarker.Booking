using FluentValidation;

namespace Tarker.Booking.Application.Validators.User
{
    public class IGetUserByUserNameAndPasswordValidator : AbstractValidator<(string, string)>
    {

        public IGetUserByUserNameAndPasswordValidator()
        {
            RuleFor(x => x.Item1).NotNull().NotEmpty().MaximumLength(50).WithMessage("El nombre de usuario es requerido");
            RuleFor(x => x.Item2).NotEmpty().MaximumLength(10).WithMessage("La contraseña es requerida");
        }
    }
}
