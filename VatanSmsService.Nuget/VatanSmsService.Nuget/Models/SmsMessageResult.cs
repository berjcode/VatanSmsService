using RestSharp;
using System.Net;

namespace VatanSmsService.Nuget.Models;

public class SmsMessageResult
{
    public bool Success { get; set; }
    public string ResponseContent { get; set; }
    public ResponseStatus ResponseStatusCode { get; set; }
    public Exception ErrorException { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}
