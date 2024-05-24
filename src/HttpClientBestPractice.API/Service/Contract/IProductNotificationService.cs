using HttpClientBestPractice.API.Dtos;

namespace HttpClientBestPractice.API.Service.Contract;

public interface IProductNotificationService
{
    Task Send_BasicUsage(NotificationDto productDto);

    Task Send_NamedClient(NotificationDto productDto);

    Task Send_TypedClient(NotificationDto productDto);

    Task Send_GeneratedClient(NotificationDto productDto);

}
