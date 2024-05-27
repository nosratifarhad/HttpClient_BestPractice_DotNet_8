namespace HttpClientBestPractice.API.Integration.Models.Wrapper.Contract;

public interface IProductNotificationWrapper
{
    Task Send_BasicUsage(NotificationModel productDto);

    Task Send_NamedClient(NotificationModel productDto);

}
