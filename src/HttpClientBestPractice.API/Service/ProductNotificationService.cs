using HttpClientBestPractice.API.Dtos;
using HttpClientBestPractice.API.Integration.Models;
using HttpClientBestPractice.API.Integration.Models.Wrapper.Contract;
using HttpClientBestPractice.API.Integration.Wrapper;
using HttpClientBestPractice.API.Integration.Wrapper.Contract;
using HttpClientBestPractice.API.Service.Contract;

namespace HttpClientBestPractice.API.Service
{
    public class ProductNotificationService
        (
        IProductNotificationWrapper productNotificationWrapper,
        ProductNotificationWrapper_TypedClient productNotificationWrapper_TypedClient,
        IProductNotificationWrapper_GeneratedClient notificationWrapper_Use_Refit) 
        : IProductNotificationService
    {

        public async Task Send_BasicUsage(NotificationDto productDto)
        {
            var notificationModel = new NotificationModel(productDto.TrackerId, productDto.PhoneNumber, productDto.Message);

            await productNotificationWrapper.Send_BasicUsage(notificationModel);
        }

        public async Task Send_NamedClient(NotificationDto productDto)
        {
            var notificationModel = new NotificationModel(productDto.TrackerId, productDto.PhoneNumber, productDto.Message);

            await notificationWrapper_Use_Refit.Send_GeneratedClient(notificationModel);
        }

        public async Task Send_TypedClient(NotificationDto productDto)
        {
            var notificationModel = new NotificationModel(productDto.TrackerId, productDto.PhoneNumber, productDto.Message);

            await productNotificationWrapper_TypedClient.Send(notificationModel);
        }

        public async Task Send_GeneratedClient(NotificationDto productDto)
        {
            var notificationModel = new NotificationModel(productDto.TrackerId, productDto.PhoneNumber, productDto.Message);

            await productNotificationWrapper.Send_NamedClient(notificationModel);
        }

    }
}
