using RestSharp;
using Newtonsoft.Json;
using VatanSmsService.Nuget.Models;
using VatanSmsService.Nuget.Abstract;
using VatanSmsService.Nuget.Constants;

namespace VatanSmsService.Nuget.Concrete;

public class SmsService : ISmsService
{

    public SmsMessageResult SendTextMessage(CreateSmsModel createSmsModel)
    {
        var client = new RestClient(createSmsModel.api_url);
        var request = CreateRestRequest(createSmsModel.api_url);

        var body = JsonConvert.SerializeObject(createSmsModel);

        request.AddParameter(SmsServiceConstans.ApplicationJson, body, ParameterType.RequestBody);

        RestResponse response = client.Execute(request);

        return new SmsMessageResult
        {
            Success = IsSuccessful(response),
            ResponseContent = response.Content,
            ResponseStatusCode = response.ResponseStatus,
            ErrorException = response.ErrorException,
            StatusCode = response.StatusCode
        };
    }

    public bool SendTextMessageReturnBool(CreateSmsModel createSmsModel)
    {
        var client = new RestClient(createSmsModel.api_url);

        var request = CreateRestRequest(createSmsModel.api_url);

        var body = JsonConvert.SerializeObject(createSmsModel);

        request.AddParameter(SmsServiceConstans.ApplicationJson, body, ParameterType.RequestBody);

        RestResponse response = client.Execute(request);

        if (IsSuccessful(response))
        {
            return true;
        }

        return false;
    }

    public string SendTextMessageReturnString(CreateSmsModel createSmsModel)
    {

        var client = new RestClient(createSmsModel.api_url);

        var request = CreateRestRequest(createSmsModel.api_url);

        var body = JsonConvert.SerializeObject(createSmsModel);

        request.AddParameter(SmsServiceConstans.ApplicationJson, body, ParameterType.RequestBody);

        RestResponse response = client.Execute(request);

        return IsSuccessful(response) ? SmsServiceConstans.SuccessfulSmsMessage : SmsServiceConstans.NotSuccessfulSmsMessage;
    }

    public RestResponse SendTextMessageReturnResponse(CreateSmsModel createSmsModel)
    {
        var client = new RestClient(createSmsModel.api_url);

        var request = CreateRestRequest(createSmsModel.api_url);

        var body = JsonConvert.SerializeObject(createSmsModel);

        request.AddParameter(SmsServiceConstans.ApplicationJson, body, ParameterType.RequestBody);

        RestResponse response = client.Execute(request);

        return response;
    }

    // Helpers Methods
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
