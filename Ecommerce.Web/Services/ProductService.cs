using Ecommerce.Web.Models;
using Ecommerce.Web.Models.Dto;
using Ecommerce.Web.Services.IServices;
using Newtonsoft.Json.Linq;

namespace Ecommerce.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        //private readonly IProductService _productService;
        private readonly IHttpClientFactory _clientFactory;
        public ProductService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _clientFactory = httpClient;
        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.APIType.POST,
                Data = productDto,
                Url = StaticDetails.ProductAPIBase + "/api/products",
                AccessToken = token
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.APIType.DELETE,
                Url = StaticDetails.ProductAPIBase + "/api/products/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetAllProductsAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.APIType.GET,
                Url = StaticDetails.ProductAPIBase + "/api/products",
                AccessToken = token
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.APIType.GET,
                Url = StaticDetails.ProductAPIBase + "/api/products/" + id,
                AccessToken = token
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.APIType.PUT,
                Data = productDto,
                Url = StaticDetails.ProductAPIBase + "/api/products",
                AccessToken = token
            });
        }
    }
}
