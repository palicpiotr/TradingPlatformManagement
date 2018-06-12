using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TradingPlatformManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager) =>
                await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("AuthContext", throwIfV1Schema: false)
        { }

        public static ApplicationDbContext Create() => new ApplicationDbContext();

    }
}