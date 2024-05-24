using HttpClientBestPractice.API.Integration.Models.Wrapper.Contract;
using Microsoft.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using System.Text;

namespace HttpClientBestPractice.API.Integration.Models.Wrapper;

public class ProductNotificationWrapper(IHttpClientFactory httpClientFactory) : IProductNotificationWrapper
{
    public async Task Send_BasicUsage(NotificationModel productDto)
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

    public async Task Send_NamedClient(NotificationModel productDto)
    {
        var httpClient = httpClientFactory.CreateClient("GitHub");

        using var todoItemJson = new StringContent(JsonSerializer.Serialize(productDto), Encoding.UTF8, Application.Json);

        var httpResponseMessage = await httpClient.PostAsync(
            "repos/dotnet/AspNetCore.Docs/branches", todoItemJson);

        if (!httpResponseMessage.IsSuccessStatusCode)
            throw new Exception();
    }
}
