using RestSharp;
using Newtonsoft.Json;
using VatanSmsService.Nuget.Models;
using VatanSmsService.Nuget.Abstract;
using VatanSmsService.Nuget.Constants;

namespace VatanSmsService.Nuget.Concrete;

public class SmsServiceAsync : ISmsServiceAsync
{
    public async Task<SmsMessageResult> SendTextMessageAsync(string message, List<string> numbers,string  _apiUrl,CreateSmsModel createSmsModel)
    {
        SmsModel sms = CreateSmsModel(message, numbers, createSmsModel);
        RestResponse response = await ExecuteSmsRequestAsync(sms, _apiUrl);

        return new SmsMessageResult
        {
            Success = IsSuccessful(response),
            ResponseContent = response.Content
        };
    }

    public async Task<bool> SendTextMessageReturnBoolAsync(string message, List<string> numbers, string _apiUrl, CreateSmsModel createSmsModel)
    {
        SmsModel sms = CreateSmsModel(message, numbers, createSmsModel);
        RestResponse response = await ExecuteSmsRequestAsync(sms, _apiUrl);

        return IsSuccessful(response);
    }

    public async Task<RestResponse> SendTextMessageReturnResponseAsync(string message, List<string> numbers, string _apiUrl, CreateSmsModel createSmsModel)
    {
        SmsModel sms = CreateSmsModel(message, numbers, createSmsModel);
        return await ExecuteSmsRequestAsync(sms, _apiUrl);
    }

    public async Task<string> SendTextMessageReturnStringAsync(string message, List<string> numbers, string _apiUrl, CreateSmsModel createSmsModel)
    {
        SmsModel sms = CreateSmsModel(message, numbers, createSmsModel);
        RestResponse response = await ExecuteSmsRequestAsync(sms, _apiUrl);

        return IsSuccessful(response) ? SmsServiceConstans.SuccessfulSmsMessage : SmsServiceConstans.NotSuccessfulSmsMessage;
    }

    // Helper Methods
    private async Task<RestResponse> ExecuteSmsRequestAsync(SmsModel sms, string _apiUrl)
    {
        var client = new RestClient(_apiUrl);
        var request = CreateRestRequest(_apiUrl);

        var body = JsonConvert.SerializeObject(sms);
        request.AddParameter(SmsServiceConstans.ApplicationJson, body, ParameterType.RequestBody);

        return await client.ExecuteAsync(request);
    }

    private RestRequest CreateRestRequest(string _apiUrl)
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
            ApiId = createSmsModel.api_id,
            ApiKey = createSmsModel.api_key,
            Message = createSmsModel.message_type,
            MessageType = createSmsModel.message_type,
            Sender = createSmsModel.sender,
            Phones = numaralar.ToArray()
        };
    }
}
