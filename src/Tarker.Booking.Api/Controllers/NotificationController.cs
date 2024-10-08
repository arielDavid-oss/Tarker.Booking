using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.Exeptions;
using Tarker.Booking.Application.External.MailerSendEmail;
using Tarker.Booking.Application.Features;
using Tarker.Booking.Domain.Models.MailerSendEmail;
using Tarker.Booking.External.MailerSendEmail;

namespace Tarker.Booking.Api.Controllers
{
    [Route("api/v1/notification")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class NotificationController : ControllerBase
    {
        [HttpPost("create")]

        public async Task<IActionResult> Create(
            [FromBody] MailerSendEmailRequestModel model,
            [FromServices] IMailerSendEmailService mailerSendEmailService)
        {
      
            var data = await mailerSendEmailService.Execute(model);


            if(!data)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseApiService.Response(StatusCodes.Status500InternalServerError,
                    data, "Error al enviar el correo"));

            return StatusCode(StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data, "Correo enviado con exito"));
        }
    }
}
