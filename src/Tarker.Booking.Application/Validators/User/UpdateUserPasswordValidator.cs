using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword;

namespace Tarker.Booking.Application.Validators.User
{
    public class UpdateUserPasswordValidator : AbstractValidator<UpdateUserPasswordModel>
    {
        public UpdateUserPasswordValidator() {

            RuleFor(x => x.UserId)
                .NotNull()
                .NotEmpty()
                .WithMessage("El id del usuario es requerido")
                .GreaterThan(0);

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("La contraseña es requerida")
                .MaximumLength(10);

            //RuleFor(x => x.NewPassword)
            //    .NotEmpty()
            //    .WithMessage("La nueva contraseña es requerida");

            //RuleFor(x => x.NewPassword)
            //    .MinimumLength(8)
            //    .WithMessage("La nueva contraseña debe tener al menos 8 caracteres");

            //RuleFor(x => x.NewPassword)
            //    .MaximumLength(20)
            //    .WithMessage("La nueva contraseña debe tener como maximo 20 caracteres");

            //RuleFor(x => x.NewPassword)
            //    .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,20}$")
            //    .WithMessage("La nueva contraseña debe tener al menos una letra mayuscula, una letra minuscula, un numero y un caracter especial");
        }


    }
}
