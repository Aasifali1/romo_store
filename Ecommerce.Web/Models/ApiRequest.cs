using static Ecommerce.Web.StaticDetails;
namespace Ecommerce.Web.Models
{
    public class ApiRequest
    {
        public APIType ApiType { get; set; } = APIType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
