using static System.Net.WebRequestMethods;

namespace VatanSmsService.Nuget.Models;

public class CreateSmsModel
{
    public string api_id { get; set; } 
    public string api_key { get; set; } 
    public string api_url { get; set; } 
    public string message { get; set; }
    public string message_type { get; set; }
    public string sender { get; set; }
    public string[] phones { get; set; }
}
