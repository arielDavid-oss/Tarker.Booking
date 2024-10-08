using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tarker.Booking.Application.External.ApplicationInsightsService;
using Tarker.Booking.Application.Features;
using Tarker.Booking.Common.Constants;
using Tarker.Booking.Domain.Models.ApplicationInsights;

namespace Tarker.Booking.Application.Exeptions
{
    public class ExceptionManager : IExceptionFilter
    {
        private readonly IInsertApplicationInsightsService _insertApplicationInsightsService;

        public ExceptionManager(IInsertApplicationInsightsService insertApplicationInsightsService)
        {
            _insertApplicationInsightsService = insertApplicationInsightsService;

        }
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(ResponseApiService.Response(
                StatusCodes.Status500InternalServerError, "Error interno del servidor",  context.Exception.Message));


            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        
            var metric =new  InsertApplicationInsightsModel(
                ApplicationInsightsConstants.METRIC_TYPE_ERROR,
                context.Exception.Message, 
                context.Exception.ToString());
            _insertApplicationInsightsService.Execute(metric);
        }
    }
}
