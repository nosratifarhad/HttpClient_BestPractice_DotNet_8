using HttpClientBestPractice.API.Dtos;
using HttpClientBestPractice.NotificationService.Models;
using HttpClientBestPractice.NotificationService.Service.Contract;
using HttpClientBestPractice.NotificationService.Wrapper.Contract;

namespace HttpClientBestPractice.NotificationService.Service
{
    public class ProductNotificationService : IProductNotificationService
    {
        private readonly IProductNotificationWrapper _productWrapper;

        public ProductNotificationService(IProductNotificationWrapper productWrapper)
        {
            this._productWrapper = productWrapper;
        }

        public async Task Send(NotificationDto productDto)
        {
            var productItemModel = new NotificationModel(productDto.ProductId, productDto.ProductName, productDto.Price);

            await _productWrapper.Send(productItemModel);
        }
    }
}
