using HttpClientBestPractice.API.Integration.Models;
using System.Text.Json;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace HttpClientBestPractice.API.Integration.Wrapper;

public class ProductNotificationWrapper_TypedClient
{
    private readonly HttpClient _httpClient;

    public ProductNotificationWrapper_TypedClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        ///
        ///you can add configs from Program.cs file or this ctor.
        ///
        //_httpClient.BaseAddress = new Uri("https://api.github.com/");
        // using Microsoft.Net.Http.Headers;
        // The GitHub API requires two headers.
        //_httpClient.DefaultRequestHeaders.Add(
        //    HeaderNames.Accept, "application/vnd.github.v3+json");
        //_httpClient.DefaultRequestHeaders.Add(
        //    HeaderNames.UserAgent, "HttpRequestsSample");
    }

    public async Task Send(NotificationModel productDto)
    {
        using var todoItemJson = new StringContent(JsonSerializer.Serialize(productDto), Encoding.UTF8, Application.Json);

        await _httpClient.PostAsync("repos/dotnet/AspNetCore.Docs/branches", todoItemJson);
    }

}
