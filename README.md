# Features

[![MIT License][license-shield]][license-url]

Hello! This package includes message sending methods for those using the VatanSms API and similar APIs.

Errors are corrected as a result of feedback.

You can easily send SMS using this package. First, add the 'VatanSmsService' class to your project and then send SMS using the following methods:
# VatanSmsService.Nuget 1.0.0
# Version
.net 7.0
# Install
```
  dotnet add package VatanSmsService.Nuget --version 1.0.0
```
# Use 
## Method Review
```
* `bool SendTextMessageReturnBool(string message, List<string> numbers, CreateSmsModel createSmsModel);`
  - It sends an SMS and returns `true` if the sending is successful, otherwise `false`.

* `string SendTextMessageReturnString(string message, List<string> numbers, CreateSmsModel createSmsModel);`
  - It sends an SMS and returns "Success" if the sending is successful, or "Failure" if not.

* `SmsMessageResult SendTextMessage(string message, List<string> numbers, CreateSmsModel createSmsModel);`
  - SMS gönderir ve gönderim sonucunu `SmsMessageResult` nesnesi olarak döndürür.

* `RestResponse SendTextMessageReturnResponse(string message, List<string> numbers, CreateSmsModel createSmsModel);`
  - SMS gönderir ve `RestResponse` nesnesi olarak API yanıtını döndürür.

```
## SmsMessageResult Review
```
   public class SmsMessageResult
{
    public bool Success { get; set; }
    public string ErrorMessage { get; set; }
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
    Task<bool> SendTextMessageReturnBoolAsync(string message, List<string> numbers, CreateSmsModel createSmsModel);
    Task<SmsMessageResult> SendTextMessageAsync(string message, List<string> numbers, CreateSmsModel createSmsModel);
    Task<string> SendTextMessageReturnStringAsync(string message, List<string> numbers, CreateSmsModel createSmsModel);
    Task<RestResponse> SendTextMessageReturnResponseAsync(string message, List<string> numbers, CreateSmsModel createSmsModel);
   ```

  ## IVatanSmsService

   ```
    bool SendTextMessageReturnBool(string message, List<string> numbers, CreateSmsModel createSmsModel);
    string SendTextMessageReturnString(string message, List<string> numbers, CreateSmsModel createSmsModel);
    SmsMessageResult SendTextMessage(string message, List<string> numbers, CreateSmsModel createSmsModel);
    RestResponse SendTextMessageReturnResponse(string message, List<string> numbers, CreateSmsModel createSmsModel);
   ```

[license-shield]: https://img.shields.io/github/license/othneildrew/Best-README-Template.svg?style=for-the-badge
[license-url]: https://github.com/berjcode/VatanSmsService/blob/main/LICENSE
                                                                                                                      
   ###    By Abdullah Balikci - berjcode

