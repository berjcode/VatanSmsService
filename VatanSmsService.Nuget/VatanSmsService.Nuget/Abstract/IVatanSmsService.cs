using RestSharp;
using VatanSmsService.Nuget.Models;

namespace VatanSmsService.Nuget.Abstract;

public interface IVatanSmsService
{
    bool SendTextMessageReturnBool(string message, List<string> numbers, CreateSmsModel createSmsModel);
    string SendTextMessageReturnString(string message, List<string> numbers, CreateSmsModel createSmsModel);
    SmsMessageResult SendTextMessage(string message, List<string> numbers, CreateSmsModel createSmsModel);
    RestResponse SendTextMessageReturnResponse(string message, List<string> numbers, CreateSmsModel createSmsModel);
}
