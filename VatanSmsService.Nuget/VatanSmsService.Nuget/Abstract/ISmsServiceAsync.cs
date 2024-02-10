using RestSharp;
using VatanSmsService.Nuget.Models;

namespace VatanSmsService.Nuget.Abstract;

public interface ISmsServiceAsync
{
    Task<bool> SendTextMessageReturnBoolAsync(string message, List<string> numbers, string _apiUrl,CreateSmsModel createSmsModel);
    Task<SmsMessageResult> SendTextMessageAsync(string message, List<string> numbers, string _apiUrl, CreateSmsModel createSmsModel);
    Task<string> SendTextMessageReturnStringAsync(string message, List<string> numbers, string _apiUrl,CreateSmsModel createSmsModel);
    Task<RestResponse> SendTextMessageReturnResponseAsync(string message, List<string> numbers, string _apiUrl, CreateSmsModel createSmsModel);
}
