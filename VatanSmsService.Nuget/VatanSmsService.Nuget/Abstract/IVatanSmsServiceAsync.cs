using RestSharp;
using VatanSmsService.Nuget.Models;

namespace VatanSmsService.Nuget.Abstract;

public interface IVatanSmsServiceAsync
{
    Task<bool> SendTextMessageReturnBoolAsync(string message, List<string> numbers, CreateSmsModel createSmsModel);
    Task<SmsMessageResult> SendTextMessageAsync(string message, List<string> numbers, CreateSmsModel createSmsModel);
    Task<string> SendTextMessageReturnStringAsync(string message, List<string> numbers, CreateSmsModel createSmsModel);
    Task<RestResponse> SendTextMessageReturnResponseAsync(string message, List<string> numbers, CreateSmsModel createSmsModel);
}
