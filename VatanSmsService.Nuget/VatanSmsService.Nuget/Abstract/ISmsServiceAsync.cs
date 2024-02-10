using RestSharp;
using VatanSmsService.Nuget.Models;

namespace VatanSmsService.Nuget.Abstract;

public interface ISmsServiceAsync
{
    Task<bool> SendTextMessageReturnBoolAsync(CreateSmsModel createSmsModel);
    Task<SmsMessageResult> SendTextMessageAsync(CreateSmsModel createSmsModel);
    Task<string> SendTextMessageReturnStringAsync(CreateSmsModel createSmsModel);
    Task<RestResponse> SendTextMessageReturnResponseAsync(CreateSmsModel createSmsModel);
}
