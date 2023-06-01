using Ecommerce.Web.Models;
using Ecommerce.Web.Models.Dto;

namespace Ecommerce.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
