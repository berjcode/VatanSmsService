using RestSharp;
using Newtonsoft.Json;
using VatanSmsService.Nuget.Models;
using VatanSmsService.Nuget.Abstract;
using VatanSmsService.Nuget.Constants;

namespace VatanSmsService.Nuget.Concrete;

public class VatanSmsServiceAsync : IVatanSmsServiceAsync
{
    private readonly string _apiUrl;

    public VatanSmsServiceAsync(string apiUrl)
    {
        _apiUrl = apiUrl;
    }
    public async Task<SmsMessageResult> SendTextMessageAsync(string message, List<string> numbers, CreateSmsModel createSmsModel)
    {
        SmsModel sms = CreateSmsModel(message, numbers, createSmsModel);
        RestResponse response = await ExecuteSmsRequestAsync(sms);

        return new SmsMessageResult
        {
            Success = IsSuccessful(response),
            ErrorMessage = response.ErrorMessage
        };
    }

    public async Task<bool> SendTextMessageReturnBoolAsync(string message, List<string> numbers, CreateSmsModel createSmsModel)
    {
        SmsModel sms = CreateSmsModel(message, numbers, createSmsModel);
        RestResponse response = await ExecuteSmsRequestAsync(sms);

        return IsSuccessful(response);
    }

    public async Task<RestResponse> SendTextMessageReturnResponseAsync(string message, List<string> numbers, CreateSmsModel createSmsModel)
    {
        SmsModel sms = CreateSmsModel(message, numbers, createSmsModel);
        return await ExecuteSmsRequestAsync(sms);
    }

    public async Task<string> SendTextMessageReturnStringAsync(string message, List<string> numbers, CreateSmsModel createSmsModel)
    {
        SmsModel sms = CreateSmsModel(message, numbers, createSmsModel);
        RestResponse response = await ExecuteSmsRequestAsync(sms);

        return IsSuccessful(response) ? SmsServiceConstans.SuccessfulSmsMessage : SmsServiceConstans.NotSuccessfulSmsMessage;
    }

    // Helper Methods
    private async Task<RestResponse> ExecuteSmsRequestAsync(SmsModel sms)
    {
        var client = new RestClient(_apiUrl);
        var request = CreateRestRequest();

        var body = JsonConvert.SerializeObject(sms);
        request.AddParameter(SmsServiceConstans.ApplicationJson, body, ParameterType.RequestBody);

        return await client.ExecuteAsync(request);
    }

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
