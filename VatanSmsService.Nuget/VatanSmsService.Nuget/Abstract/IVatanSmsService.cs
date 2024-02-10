using RestSharp;
using VatanSmsService.Nuget.Models;

namespace VatanSmsService.Nuget.Abstract;

public interface IVatanSmsService
{
    bool SendTextMessageReturnBool(string mesaj, List<string> numaralar, CreateSmsModel createSmsModel);
    string SendTextMessageReturnString(string mesaj, List<string> numaralar, CreateSmsModel createSmsModel);
    int SendTextMessageReturnInt(string mesaj, List<string> numaralar, CreateSmsModel createSmsModel);
    void SendTextMessageVoid(string mesaj, List<string> numaralar, CreateSmsModel createSmsModel);
    SmsMessageResult SendTextMessage(string mesaj, List<string> numaralar, CreateSmsModel createSmsModel);
    RestResponse SendTextMessageReturnResponse(string mesaj, List<string> numaralar, CreateSmsModel createSmsModel);
}
