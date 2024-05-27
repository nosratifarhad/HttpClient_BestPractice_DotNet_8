# HttpClient Best Practices Implementations

This repository contains implementations of HttpClient in 4 different ways:

1. Basic Usage
2. Named Clients
3. Typed Clients
4. Generated Clients

## Installation

No additional packages need to be installed for implementing Basic Usage, Named Clients, and Typed Clients.

## Usage

### Basic Usage

To implement Basic Usage, add the following service to your program file:

```csharp
#region Basic usage

builder.Services.AddHttpClient();

#endregion Basic usage
```

## You can use the HttpClient by following the method below:
```csharp
    public async Task Send(NotificationModel productDto)
    {
        var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Post,
            "https://api.github.com/repos/dotnet/AspNetCore.Docs/branches")
        {
            Headers =
            {
                { HeaderNames.Accept, "application/vnd.github.v3+json" },
                { HeaderNames.UserAgent, "HttpRequestsSample" }
            }
        };

        var httpClient = httpClientFactory.CreateClient();

        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        if (!httpResponseMessage.IsSuccessStatusCode)
            throw new Exception();
    }
```
## Named Clients

For Typed Clients, you can add the httpClient service as shown below and assign it a key or name. At usage time, simply call it by its name httpClient. In this section, you can add the used configurations as follows and at usage time, only call the external service.

You can use this service as follows:

```csharp
#region Named clients
builder.Services.AddHttpClient("GitHub", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api.github.com/");

    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.Accept, "application/vnd.github.v3+json");

    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.UserAgent, "HttpRequestsSample");

    // ...
});
#endregion Named clients
```

## You can use the HttpClient by following the method below:
Because you set base configes in program file , in method only used.

you must get servese from name "GitHub".
```csharp
    public async Task Send(NotificationModel productDto)
    {
        var httpClient = httpClientFactory.CreateClient("GitHub");

        using var todoItemJson = new StringContent(JsonSerializer.Serialize(productDto), Encoding.UTF8, Application.Json);

        var httpResponseMessage = await httpClient.PostAsync(
            "repos/dotnet/AspNetCore.Docs/branches", todoItemJson);

        if (!httpResponseMessage.IsSuccessStatusCode)
            throw new Exception();
    }
```

## Typed Clients

In the Typed Clients model, your class does not need an interface, and only one class is sufficient for implementation. You first need to add the httpClient service as shown below and introduce your wrapper class. Additionally, you can implement base configurations either in the configuration section or in the constructor of the wrapper class, as we have done in this part.

```csharp
#region Typed clients
builder.Services.AddHttpClient<ProductNotificationWrapper_TypedClient>(httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api.github.com/");

    httpClient.DefaultRequestHeaders.Add(
                HeaderNames.Accept, "application/vnd.github.v3+json");

    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.UserAgent, "HttpRequestsSample");

    // ...
});
#endregion Typed clients
```

## You can use the HttpClient by following the method below:

```csharp
public async Task Send(NotificationModel productDto)
{
    using var todoItemJson = 
    new StringContent(JsonSerializer.Serialize(productDto), Encoding.UTF8, Application.Json);

    await _httpClient.PostAsync("repos/dotnet/AspNetCore.Docs/branches", todoItemJson);
}
```

## Refit Integration

The next model you can use is the Refit package. First, you need to install the following 2 packages:

- Refit
- Refit.HttpClientFactory

After installing these packages, you need to add an interface where you define the required signatures. You can specify the address to be requested and the type of method in your signature using the GET attribute, as shown below:

```csharp
#region Generated clients
builder.Services.AddRefitClient<IProductNotificationWrapper_GeneratedClient>()
    .ConfigureHttpClient(httpClient =>
    {
        httpClient.BaseAddress = new Uri("https://api.github.com/");

        httpClient.DefaultRequestHeaders.Add(
            HeaderNames.Accept, "application/vnd.github.v3+json");

        httpClient.DefaultRequestHeaders.Add(
            HeaderNames.UserAgent, "HttpRequestsSample");

        // ...
    });
#endregion Generated clients
```
Now add your interface as the httpClient service as in the Typed Clients model, with the difference that in Typed Clients, you added a class to the service, but with Refit, it is sufficient to add the interface.

Now add additional information in the configuration:

```csharp
    public interface IProductNotificationWrapper_GeneratedClient
    {
        [Get("/repos/dotnet/AspNetCore.Docs/branches")]
        Task Send_GeneratedClient(NotificationModel productDto);
    }
```
reference : https://virgool.io/@farhadnosrati/ihttpclientfactory-aqkklgc8qpyk
