# Features

[![MIT License][license-shield]][license-url]

Merhaba;
VatanSmsService.Nuget paketi kullanarak hem senkron hem de asenkron yöntemlerle çok sayıda alıcıya toplu veya tekli sms gönderimi yüksek performansla yapılabilmektedir. 
Mesajlarınızın iletim raporlarını alabilir ve ileri tarihli mesajlar gönderebilirsiniz. 
Bu hizmeti kullanabilmek için VatanSMS.Net tarafından sağlanan hesabınız olmalıdır.

Hello;
By using VatanSmsService.Nuget package, bulk or single SMS sending can be done with high performance to many recipients with both synchronous and asynchronous methods.
You can get delivery reports of your messages and send future messages.
To use this service, you must have an account provided by VatanSMS.Net.

*Please note that you can send sms only to Turkish +90 country code mobile phone numbers.

Errors are corrected as a result of feedback.

You can easily send SMS using this package. First, add the 'VatanSmsService' class to your project and then send SMS using the following methods:
# VatanSmsService.Nuget 1.0.2
# Version
.net 7.0
# Install
```
  dotnet add package VatanSmsService.Nuget --version 1.0.2
```
# Use 
## Method Review
```
* `bool SendTextMessageReturnBool(CreateSmsModel createSmsModel);`
  - It sends an SMS and returns `true` if the sending is successful, otherwise `false`.

* `string SendTextMessageReturnString(CreateSmsModel createSmsModel);`
  - It sends an SMS and returns "Success" if the sending is successful, or "Failure" if not.

* `SmsMessageResult SendTextMessage(CreateSmsModel createSmsModel);`
  - Sends an SMS and returns the sending result as an `SmsMessageResult` object.

* `RestResponse SendTextMessageReturnResponse(CreateSmsModel createSmsModel);`
  - Sends SMS and returns API response as `RestResponse` object.
```
## SmsMessageResult Review
```
   public class SmsMessageResult
{
    public bool Success { get; set; }
    public string ResponseContent { get; set; }
    public ResponseStatus ResponseStatusCode { get; set; }
    public Exception ErrorException { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}

 return new SmsMessageResult
        {
            Success = IsSuccessful(response),
            ResponseContent = response.Content,
            ResponseStatusCode = response.ResponseStatus,
            ErrorException = response.ErrorException,
            StatusCode = response.StatusCode
        };

```
## CreateSmsModel Review
```
 public class CreateSmsModel
{
    public string api_id { get; set; } 
    public string api_key { get; set; } 
    public string api_url { get; set; } 
    public string message { get; set; }
    public string message_type { get; set; }
    public string sender { get; set; }
    public string[] phones { get; set; }
}
```
## Warning
   * Dependency  Packages
   ```
   Newtonsoft.Json 12.0.3
   RestSharp 110.2.0
   ```
  ## IVatanSmsServiceAsync Methods
   ```
    Task<bool> SendTextMessageReturnBoolAsync(CreateSmsModel createSmsModel);
    Task<SmsMessageResult> SendTextMessageAsync(CreateSmsModel createSmsModel);
    Task<string> SendTextMessageReturnStringAsync(CreateSmsModel createSmsModel);
    Task<RestResponse> SendTextMessageReturnResponseAsync(CreateSmsModel createSmsModel);
   ```
  ## IVatanSmsService
   ```
    bool SendTextMessageReturnBool(CreateSmsModel createSmsModel);
    string SendTextMessageReturnString(CreateSmsModel createSmsModel);
    SmsMessageResult SendTextMessage(CreateSmsModel createSmsModel);
    RestResponse SendTextMessageReturnResponse(CreateSmsModel createSmsModel);
   ```
   ## Use
    * First, register the service in program.cs.
   ```
   builder.Services.AddScoped<ISmsService, SmsService>();
   builder.Services.AddScoped<ISmsServiceAsync, SmsServiceAsync>();
   ```
    * Then you can call and use the methods in the service as follows. Synchronous and asynchronous methods are available.
    * There are 4 different types of returning methods. You can use it according to your needs.
    * You can carry out your transactions using the Createsms model. This model is available in the package.
    * You must enter your own ID and keys that you received from vatansms.
    # Index.html
   ```
   <form   asp-controller="Home" asp-action="Index" >
    <input type="text" #Message name="message" />
    <input type="text" #Numbers name="phones" />
    <button type="submit" class="btn btn-dark"> gönder</button>
  </form>
   ```
   # Controller
   ```
        private readonly ISmsService _smsService;
        private readonly ISmsServiceAsync _smsServiceAsync;

        public HomeController(
            ISmsService smsService
            ISmsServiceAsync smsServiceAsync)
        {
            _smsService = smsService;
            _smsServiceAsync = smsServiceAsync;
        }
    [HttpPost]
        public IActionResult Index(CreateSmsModel createSmsModel)
        {
            createSmsModel.api_url = "https://api.vatansms.net/api/v1/1toN";
            createSmsModel.api_id = "**************";
            createSmsModel.api_key = "*************";
            createSmsModel.message_type = "normal";
            createSmsModel.sender = "berjcode";

            var result =  _smsService.SendTextMessage(createSmsModel);
            return View(result);
        }
   ```
    # Service
   ```
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
            ResponseContent = response.Content
        };
    }
   ```
     # Example Send Multi Messages
   ```
     // If you send it directly as string array type it will be accepted. This is just an example.
     [HttpPost]
        public IActionResult Index(CreateSmsModel createSmsModel)
        {
            string[] phone = new string[] {"0543********", "053*******" };

            createSmsModel.api_url = "https://api.vatansms.net/api/v1/1toN";
            createSmsModel.api_id = "**************";
            createSmsModel.api_key = "*************";
            createSmsModel.message_type = "normal";
            createSmsModel.sender = "berjcode";
            createSmsModel.phones = phone;
            var result =  _smsService.SendTextMessage(createSmsModel);
            return View(result);
        }
        
   ```
[license-shield]: https://img.shields.io/github/license/othneildrew/Best-README-Template.svg?style=for-the-badge
[license-url]: https://github.com/berjcode/VatanSmsService/blob/main/LICENSE
                                                                                                                      
   ###    By Abdullah Balikci - berjcode

