using RestSharp;
using Newtonsoft.Json;
using VatanSmsService.Nuget.Models;
using VatanSmsService.Nuget.Abstract;
using VatanSmsService.Nuget.Constants;

namespace VatanSmsService.Nuget.Concrete;

public class VatanSmsService : IVatanSmsService
{
    private readonly string _apiUrl;

    public VatanSmsService(string apiUrl)
    {
        _apiUrl = apiUrl;
    }
    public SmsMessageResult SendTextMessage(string message, List<string> numbers, CreateSmsModel createSmsModel)
    {
        SmsModel sms = CreateSmsModel(message, numbers, createSmsModel);


        var client = new RestClient(_apiUrl);
        var request = CreateRestRequest();


        var body = JsonConvert.SerializeObject(sms);

        request.AddParameter(SmsServiceConstans.ApplicationJson, body, ParameterType.RequestBody);

        RestResponse response = client.Execute(request);

        return new SmsMessageResult
        {
            Success = IsSuccessful(response),
            ErrorMessage = response.ErrorMessage,
        };
    }

    public bool SendTextMessageReturnBool(string message, List<string> numbers,CreateSmsModel createSmsModel)
    {
        SmsModel sms = CreateSmsModel(message, numbers, createSmsModel);


        var client = new RestClient(_apiUrl);
        var request = CreateRestRequest();


        var body = JsonConvert.SerializeObject(sms);

        request.AddParameter(SmsServiceConstans.ApplicationJson, body, ParameterType.RequestBody);

        RestResponse response = client.Execute(request);

        if (IsSuccessful(response))
        {
            return true;
        }

        return false;
    }

    public string SendTextMessageReturnString(string message, List<string> numbers, CreateSmsModel createSmsModel)
    {
        SmsModel sms = CreateSmsModel(message, numbers, createSmsModel);

        var client = new RestClient(_apiUrl);
        var request = CreateRestRequest();

        var body = JsonConvert.SerializeObject(sms);
        request.AddParameter(SmsServiceConstans.ApplicationJson, body, ParameterType.RequestBody);

        RestResponse response = client.Execute(request);

        if (IsSuccessful(response))
        {
            return SmsServiceConstans.SuccessfulSmsMessage;
        }
        else
        {
            return SmsServiceConstans.NotSuccessfulSmsMessage;
        }
    }

    public RestResponse SendTextMessageReturnResponse(string message, List<string> numbers, CreateSmsModel createSmsModel)
    {
        SmsModel sms = CreateSmsModel(message, numbers, createSmsModel);

        var client = new RestClient(_apiUrl);
        var request = CreateRestRequest();

        var body = JsonConvert.SerializeObject(sms);
        request.AddParameter(SmsServiceConstans.ApplicationJson, body, ParameterType.RequestBody);

        RestResponse response = client.Execute(request);

        return response;
    }

    // Helper Methods
    private RestRequest CreateRestRequest()
    {
        var request = new RestRequest(_apiUrl, Method.Post);
        request.AddHeader(SmsServiceConstans.ContentTypeExpression, SmsServiceConstans.ApplicationJson);

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
