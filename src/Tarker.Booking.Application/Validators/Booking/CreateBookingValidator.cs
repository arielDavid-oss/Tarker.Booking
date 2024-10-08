using FluentValidation;
using Tarker.Booking.Application.DataBase.Bookings.Commants.CreateBooking;

namespace Tarker.Booking.Application.Validators.Booking
{
    public class CreateBookingValidator : AbstractValidator<CreateBookingModel>
    {

        public CreateBookingValidator()
        {
            RuleFor(x => x.Code).
                NotNull()
                .NotEmpty()
                .MaximumLength(8);   
            RuleFor(x => x.Type).
                NotNull()
                .NotEmpty()
                .MaximumLength(50);  
            
            RuleFor(x => x.CustomerId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.UserId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

        }

    }
}
