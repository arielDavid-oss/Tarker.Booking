using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Tarker.Booking.Application.External.ApplicationInsightsService;
using Tarker.Booking.Application.External.GetTokenJwt;
using Tarker.Booking.Application.External.MailerSendEmail;
using Tarker.Booking.External.ApplicationInsights;
using Tarker.Booking.External.GetTokenJwt;
using Tarker.Booking.External.MailerSendEmail;

namespace Tarker.Booking.External
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services,
            IConfiguration configuration)

        {

            services.AddSingleton<IMailerSendEmailService, MailerSendEmailService>();
            services.AddSingleton<IGetTokenJwtService, GetTokenJwtService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecretKeyJwt"] ?? string.Empty)),
                    ValidIssuer = configuration["IssuerJwt"],
                    ValidAudience = configuration["AudienceJwt"]

                };
            });

            services.AddApplicationInsightsTelemetry(new ApplicationInsightsServiceOptions
            {
                ConnectionString = configuration["ApplicationInsightsConnectionString"]
            });

            services.AddSingleton<IInsertApplicationInsightsService, InsertApplicationInsightsService>();

            return services;
        }
    }
}
