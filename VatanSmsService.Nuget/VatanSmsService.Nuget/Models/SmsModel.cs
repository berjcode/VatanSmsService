namespace VatanSmsService.Nuget.Models;

public class SmsModel
{
    public string ApiId { get; set; }
    public string ApiKey { get; set; }
    public string Message { get; set; }
    public string MessageType { get; set; }
    public string Sender { get; set; }

    public string[] Phones { get; set; }
}
