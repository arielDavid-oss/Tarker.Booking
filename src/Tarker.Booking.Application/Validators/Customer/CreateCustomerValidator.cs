using FluentValidation;
using Tarker.Booking.Application.DataBase.Customer.Commants.CreateCustomer;

namespace Tarker.Booking.Application.Validators.Customer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerModel>
    {

        public CreateCustomerValidator() { 
        
            RuleFor(x=> x.FullName)
                .NotNull()
                .NotEmpty()
                .WithMessage("FullName is required")
                .MaximumLength(50);
            RuleFor(x => x.DocumentNumber)
               .NotNull()
               .NotEmpty()
               .WithMessage("DocumentNumber is required")
               .MaximumLength(8);


        }
    }
}
