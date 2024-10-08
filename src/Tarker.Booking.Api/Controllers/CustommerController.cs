using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.DataBase.Customer.Commants.CreateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commants.DeleteCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commants.UpdateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetAllCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using Tarker.Booking.Application.Exeptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
    [Route("api/v1/customer")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class CustommerController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateCustomerModel model,
            [FromServices] ICreateCustomerCommand createUserCommand,
            [FromServices] IValidator<CreateCustomerModel> validator)
        {
            var result = validator.Validate(model);

            if (!result.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, result.Errors, "Error de validacion"));


            var data = await createUserCommand.Execute(model);

            return StatusCode(StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data, "Insertado con exito"));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateCustomerModel model,
            [FromServices] IUpdateCustomerCommand updateUserCommand,
            [FromServices] IValidator<UpdateCustomerModel> validator)
        {
            var result = validator.Validate(model);

            if (!result.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, result.Errors, "Error de validacion"));

            var data = await updateUserCommand.Execute(model);

            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Actualizado con exito"));
        }


        [HttpDelete("delete/{CustomerId}")]
        public async Task<IActionResult> Delete(
            int CustomerId,
            [FromServices] IDeleteCustomerCommand deleteUserCommand)
        {
            if (CustomerId == 0)
                return StatusCode(StatusCodes.Status400BadRequest,
                   ResponseApiService.Response(StatusCodes.Status400BadRequest, "No se elimino"));

            var data = await deleteUserCommand.Execute(CustomerId);

            if (!data)
                return StatusCode(StatusCodes.Status404NotFound,
                ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No se encontro"));
            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Eliminado con exito"));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllCustomerQuery getAllCustomerQuery)
        {
            var data = await getAllCustomerQuery.Execute();

            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Consulta exitosa"));
        }

        [HttpGet("get-by-id/{CustomerId}")]
        public async Task<IActionResult> GetById(
            int CustomerId,
            [FromServices] IGetCustomerByIdQuery getCustomerByIdQuery)
        {
            if (CustomerId == 0)
                return StatusCode(StatusCodes.Status400BadRequest,
                   ResponseApiService.Response(StatusCodes.Status400BadRequest, "No se elimino"));

            var data = await getCustomerByIdQuery.Execute(CustomerId);

            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound,
                ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No se encontro"));

            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Consulta exitosa"));
        }

        [HttpGet("get-by-documentnumber/{DocumentNumber}")]
        public async Task<IActionResult> GetByDocumentNumber(
            string DocumentNumber,
            [FromServices] IGetCustomerByDocumentNumberQuery getCustomerByDocumentNumberQuery)
        {
            if (string.IsNullOrEmpty(DocumentNumber))
                return StatusCode(StatusCodes.Status400BadRequest,
                   ResponseApiService.Response(StatusCodes.Status400BadRequest, "No se elimino"));

            var data = await getCustomerByDocumentNumberQuery.Execute(DocumentNumber);

            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound,
                ResponseApiService.Response(StatusCodes.Status404NotFound, data, "No se encontro"));

            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Consulta exitosa"));
        }
    }
}
