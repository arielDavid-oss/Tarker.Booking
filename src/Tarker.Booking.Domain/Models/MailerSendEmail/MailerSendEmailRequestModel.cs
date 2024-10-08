namespace Tarker.Booking.Domain.Models.MailerSendEmail
{
    public class MailerSendEmailRequestModel
    {
        public FromModel from { get; set; }
        public List<ToModel> to { get; set; }
        public string subject { get; set; }
        public string text { get; set; }
        public string html { get; set; }
    }
    public class FromModel
    {
        public string email { get; set; }
        public string name { get; set; }
    }

    public class ToModel
    {
        public string email { get; set; }
        public string name { get; set; }
    }


}
