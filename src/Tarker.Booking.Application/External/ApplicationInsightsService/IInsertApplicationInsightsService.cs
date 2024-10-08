using Tarker.Booking.Domain.Models.ApplicationInsights;

namespace Tarker.Booking.Application.External.ApplicationInsightsService
{
    public interface IInsertApplicationInsightsService
    {
        bool Execute(InsertApplicationInsightsModel metric);
    }
}
