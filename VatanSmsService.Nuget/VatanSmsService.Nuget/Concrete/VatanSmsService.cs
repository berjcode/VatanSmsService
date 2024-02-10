using Newtonsoft.Json;
using RestSharp;
using VatanSmsService.Nuget.Abstract;
using VatanSmsService.Nuget.Models;

namespace VatanSmsService.Nuget.Concrete;

public class VatanSmsService : IVatanSmsService
{
    private readonly string _apiUrl;

    public VatanSmsService(string apiUrl)
    {
        _apiUrl = apiUrl;
    }
    public SmsMessageResult SendTextMessage(string mesaj, List<string> numaralar)
    {
        SmsModel sms = CreateSmsModel(mesaj, numaralar, createSmsModel);


        var client = new RestClient(_apiUrl);
        var request = CreateRestRequest();


        var body = JsonConvert.SerializeObject(sms);

        request.AddParameter("application/json", body, ParameterType.RequestBody);

        RestResponse response = client.Execute(request);

        return new SmsMessageResult
        {
            Success = IsSuccessful(response),
            ErrorMessage = response.ErrorMessage,
            SentCount = numaralar.Count
        };
    }

    public bool SendTextMessageReturnBool(string mesaj, List<string> numaralar,CreateSmsModel createSmsModel)
    {
        SmsModel sms = CreateSmsModel(mesaj, numaralar, createSmsModel);


        var client = new RestClient(_apiUrl);
        var request = CreateRestRequest();


        var body = JsonConvert.SerializeObject(sms);

        request.AddParameter("application/json", body, ParameterType.RequestBody);

        RestResponse response = client.Execute(request);

        if (IsSuccessful(response))
        {
            return true;
        }

        return false;
    }

    public int SendTextMessageReturnInt(string mesaj, List<string> numaralar, CreateSmsModel createSmsModel)
    {
        SmsModel sms = CreateSmsModel(mesaj, numaralar, createSmsModel);

        var client = new RestClient(_apiUrl);
        var request = CreateRestRequest();

        var body = JsonConvert.SerializeObject(sms);
        request.AddParameter("application/json", body, ParameterType.RequestBody);

        RestResponse response = client.Execute(request);

        if (IsSuccessful(response))
        {
            
            return numaralar.Count;
        }
        else
        {
            return 0;
        }
    }

    public string SendTextMessageReturnString(string mesaj, List<string> numaralar, CreateSmsModel createSmsModel)
    {
        SmsModel sms = CreateSmsModel(mesaj, numaralar, createSmsModel);

        var client = new RestClient(_apiUrl);
        var request = CreateRestRequest();

        var body = JsonConvert.SerializeObject(sms);
        request.AddParameter("application/json", body, ParameterType.RequestBody);

        RestResponse response = client.Execute(request);

        if (IsSuccessful(response))
        {
            return "SMS başarıyla gönderildi.";
        }
        else
        {
            return "SMS gönderimi başarısız oldu.";
        }
    }

    public RestResponse SendTextMessageReturnResponse(string mesaj, List<string> numaralar, CreateSmsModel createSmsModel)
    {
        SmsModel sms = CreateSmsModel(mesaj, numaralar, createSmsModel);

        var client = new RestClient(_apiUrl);
        var request = CreateRestRequest();

        var body = JsonConvert.SerializeObject(sms);
        request.AddParameter("application/json", body, ParameterType.RequestBody);

        RestResponse response = client.Execute(request);

        return response;
    }

    public void SendTextMessageVoid(string mesaj, List<string> numaralar, CreateSmsModel createSmsModel)
    {
        throw new NotImplementedException();
    }

    // Helper Methods
    private RestRequest CreateRestRequest()
    {
        var request = new RestRequest(_apiUrl, Method.Post);
        request.AddHeader("Content-Type", "application/json");

        return request;
    }

    private bool IsSuccessful(RestResponse response)
    {
        return response.StatusCode >= System.Net.HttpStatusCode.OK && response.StatusCode < System.Net.HttpStatusCode.Ambiguous;
    }
    private SmsModel CreateSmsModel(string mesaj, List<string> numaralar, CreateSmsModel createSmsModel)
    {
        return new SmsModel
        {
            ApiId = createSmsModel.ApiId,
            ApiKey = createSmsModel.ApiKey,
            Message = createSmsModel.Message,
            MessageType = createSmsModel.MessageType,
            Sender = createSmsModel.Sender,
            Phones = numaralar.ToArray()
        };
    }
}
