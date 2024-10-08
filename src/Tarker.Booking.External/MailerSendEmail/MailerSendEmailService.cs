using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using Tarker.Booking.Application.External.MailerSendEmail;
using Tarker.Booking.Domain.Models.MailerSendEmail;

namespace Tarker.Booking.External.MailerSendEmail
{
    public class MailerSendEmailService: IMailerSendEmailService
    {
        private readonly IConfiguration _configuration;

        public MailerSendEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> Execute(MailerSendEmailRequestModel model)
        {
            string apiKey = _configuration["MailerSendKey"];
            string apiUrl = "https://api.mailersend.com/v1/email";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
            client.DefaultRequestHeaders.Add("Accept", $"application/json");

            string emailContent = JsonConvert.SerializeObject(model);
            var response = await client.PostAsync(apiUrl, new StringContent(emailContent, Encoding.UTF8, "application/json"));

            if(response.IsSuccessStatusCode)
                return true;
            var errorContent = await response.Content.ReadAsStringAsync();
            // Aquí puedes registrar el error para depurarlo
            Console.WriteLine($"Error al enviar correo: {errorContent}");

            return false;
        }
    }
}
