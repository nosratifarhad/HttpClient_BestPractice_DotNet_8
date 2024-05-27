using HttpClientBestPractice.API.Integration.Models;
using Refit;

namespace HttpClientBestPractice.API.Integration.Wrapper.Contract
{
    public interface IProductNotificationWrapper_GeneratedClient
    {
        [Get("/repos/dotnet/AspNetCore.Docs/branches")]
        Task Send_GeneratedClient(NotificationModel productDto);
    }
}
