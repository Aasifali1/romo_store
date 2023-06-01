using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Services.IdentityService
{
    public class ApplicationUser : IdentityUser
    {

        public string PersonName { get; set; }
        public string LastName { get; set; }
    }
}
