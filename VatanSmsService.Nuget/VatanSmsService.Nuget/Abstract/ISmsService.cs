using RestSharp;
using VatanSmsService.Nuget.Models;

namespace VatanSmsService.Nuget.Abstract;

public interface ISmsService
{
    bool SendTextMessageReturnBool(CreateSmsModel createSmsModel);
    string SendTextMessageReturnString(CreateSmsModel createSmsModel);
    SmsMessageResult SendTextMessage(CreateSmsModel createSmsModel);
    RestResponse SendTextMessageReturnResponse(CreateSmsModel createSmsModel);
}
