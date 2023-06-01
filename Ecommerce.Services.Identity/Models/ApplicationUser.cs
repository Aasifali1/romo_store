using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Services.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        internal string FirstName;

        public string PersonName { get; set; }
        public string LastName { get; internal set; }
    }
}
