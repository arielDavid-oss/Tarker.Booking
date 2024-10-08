using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using Tarker.Booking.Application.External.ApplicationInsightsService;
using Tarker.Booking.Domain.Models.ApplicationInsights;

namespace Tarker.Booking.External.ApplicationInsights
{
    public class InsertApplicationInsightsService: IInsertApplicationInsightsService
    {
        private readonly IConfiguration _configuration;
        public InsertApplicationInsightsService(IConfiguration configuration)
        {
            _configuration = configuration;

        }

       public bool Execute(InsertApplicationInsightsModel metric)
        {

            if(metric == null)
            {
               throw new ArgumentNullException(nameof(metric));
            }

            TelemetryConfiguration config = new TelemetryConfiguration();
            config.ConnectionString = _configuration["ApplicationInsightsConnectionString"];

            var _telemetricClient = new TelemetryClient(config);
            var properties = new Dictionary<string, string>
            {
                { "Id", metric.Id },
                { "Content", metric.Content },
                { "Detail", metric.Detail }

            };

            _telemetricClient.TrackTrace(metric.Type, SeverityLevel.Information, properties);
            return true;
        }
}
}
