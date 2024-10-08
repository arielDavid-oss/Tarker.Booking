using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.DataBase.Customer.Commants.UpdateCustomer;

namespace Tarker.Booking.Application.Validators.Customer
{
    public class UpdateCustomerValidator: AbstractValidator<UpdateCustomerModel>
    {
        public UpdateCustomerValidator() {


            RuleFor(x => x.CustomerId)
                .NotNull()
                .NotEmpty()
                .WithMessage("El id del usuario es requerido")
                .GreaterThan(0);

            RuleFor(x => x.FullName)
                .NotNull()
                .NotEmpty()
                .WithMessage("El id del usuario es requerido")
                .MaximumLength(50);

            RuleFor(x => x.DocumentNumber)
               .NotNull()
               .NotEmpty()
               .WithMessage("El id del usuario es requerido")
               .MaximumLength(8);
        }
    }
}
