using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.DataBase.Bookings.Commants.CreateBooking;
using Tarker.Booking.Application.DataBase.Bookings.Commants.UpdateBooking;
using Tarker.Booking.Application.DataBase.Bookings.Queries.GetAllBooking;
using Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingsByDocumentNumber;
using Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingsByType;
using Tarker.Booking.Application.Exeptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
    [Route("api/v1/booking")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class BookingController : ControllerBase
    {

        [HttpPost("create")]
        public async Task<IActionResult> Create(

            [FromBody] CreateBookingModel model,
            [FromServices] ICreateBookingCommand createBookingCommand,
            [FromServices] IValidator<CreateBookingModel> validator)
        {
            var validate = validator.ValidateAsync(model);
            var data = await createBookingCommand.Execute(model);

            if (!validate.Result.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Result.Errors, "Error de validacion"));
            return StatusCode(StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data, "Insertado con exito"));
        }

        //[HttpPut("Update")]
        //public async Task<IActionResult> Update(
        //    [FromBody] UpdateBookingModel model,
        //    [FromServices] IUpdateBookingCommand updateBookingCommand)
        //{
        //    var data = await updateBookingCommand.Execute(model);

        //    return StatusCode(StatusCodes.Status200OK,
        //        ResponseApiService.Response(StatusCodes.Status200OK, data, "Actualizado con exito"));
        //}

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllBookingQuery getAllBookingQuery)
        {
            var data = await getAllBookingQuery.Execute();

            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Consulta exitosa"));
        }


        [HttpGet("get-by-documentnumber")]
        public async Task<IActionResult> GetById(
            [FromQuery] string documentnumber,
            [FromServices] IGetBookingsByDocumentNumberQuery getBookingByIdQuery)
        {
            if (string.IsNullOrEmpty(documentnumber))
                return StatusCode(StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, "No se encontro"));
            var data = await getBookingByIdQuery.Execute(documentnumber);

            if (data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No se encontro"));

            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Consulta exitosa"));


        }
        [HttpGet("get-by-TypeQuery")]
        public async Task<IActionResult> GetById(
            [FromQuery] string TypeQuery,
            [FromServices] IGetBookingsByTypeQuery getBookingByIdQuery)
        {

                if(string.IsNullOrEmpty(TypeQuery))
                return StatusCode(StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, "No se encontro"));
            var data = await getBookingByIdQuery.Execute(TypeQuery);

            if (data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound,
                    ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No se encontro"));

            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Consulta exitosa"));
        }
    }
}
