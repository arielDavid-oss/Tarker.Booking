using Tarker.Booking.Domain.Models.MailerSendEmail;

namespace Tarker.Booking.Application.External.MailerSendEmail
{
    public interface IMailerSendEmailService
    {
        Task<bool> Execute(MailerSendEmailRequestModel model);
    }
}
