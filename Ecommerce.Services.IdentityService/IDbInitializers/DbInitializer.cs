using Ecommerce.Services.IdentityService.DbContext;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Ecommerce.Services.IdentityService.IDbInitializers
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public void Initialize()
        {
            if (_roleManager.FindByNameAsync(StaticDetails.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(StaticDetails.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(StaticDetails.Customer)).GetAwaiter().GetResult();
            }
            else { return; }

            ApplicationUser adminUser = new()
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "111111111111",
                PersonName = "Aasif",
                LastName= "Ali"
            };

            try
            {
                _userManager.CreateAsync(adminUser, "Admin@123").GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(adminUser, StaticDetails.Admin).GetAwaiter().GetResult();

                var claims1 = _userManager.AddClaimsAsync(adminUser, new Claim[] {
                new Claim("name" ,adminUser.PersonName),
                new Claim("role", StaticDetails.Admin)
                }).Result;

                ApplicationUser customerUser = new()
                {
                    UserName = "customer@gmail.com",
                    Email = "customer@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "111111111111",
                    PersonName = "customer",
                    LastName = "Ali"
                };

                _userManager.CreateAsync(customerUser, "Customer@123").GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(customerUser, StaticDetails.Customer).GetAwaiter().GetResult();

                var temp2 = _userManager.AddClaimsAsync(customerUser, new Claim[] {
                 new Claim("name" ,customerUser.PersonName),
                new Claim("role",StaticDetails.Customer),
            }).Result;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
