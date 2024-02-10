using RestSharp;
using Newtonsoft.Json;
using VatanSmsService.Nuget.Models;
using VatanSmsService.Nuget.Abstract;
using VatanSmsService.Nuget.Constants;

namespace VatanSmsService.Nuget.Concrete;

public class SmsServiceAsync : ISmsServiceAsync
{
    public async Task<SmsMessageResult> SendTextMessageAsync(CreateSmsModel createSmsModel)
    {
        RestResponse response = await ExecuteSmsRequestAsync(createSmsModel);

        return new SmsMessageResult
        {
            Success = IsSuccessful(response),
            ResponseContent = response.Content
        };
    }

    public async Task<bool> SendTextMessageReturnBoolAsync(CreateSmsModel createSmsModel)
    {
        RestResponse response = await ExecuteSmsRequestAsync(createSmsModel);

        return IsSuccessful(response);
    }

    public async Task<RestResponse> SendTextMessageReturnResponseAsync(CreateSmsModel createSmsModel)
    {
       
        return await ExecuteSmsRequestAsync(createSmsModel);
    }

    public async Task<string> SendTextMessageReturnStringAsync(CreateSmsModel createSmsModel)
    {
        RestResponse response = await ExecuteSmsRequestAsync(createSmsModel);

        return IsSuccessful(response) ? SmsServiceConstans.SuccessfulSmsMessage : SmsServiceConstans.NotSuccessfulSmsMessage;
    }

    // Helper Methods
    private async Task<RestResponse> ExecuteSmsRequestAsync(CreateSmsModel createSmsModel)
    {
        var client = new RestClient(createSmsModel.api_url);
        var request = CreateRestRequest(createSmsModel.api_url);

        var body = JsonConvert.SerializeObject(createSmsModel);
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

}
