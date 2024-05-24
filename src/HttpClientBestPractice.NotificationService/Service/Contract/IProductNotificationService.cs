using HttpClientBestPractice.API.Dtos;

namespace HttpClientBestPractice.NotificationService.Service.Contract
{
    public interface IProductNotificationService
    {
        Task Send(NotificationDto productDto);
    }
}
