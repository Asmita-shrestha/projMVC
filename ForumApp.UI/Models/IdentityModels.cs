using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ForumApp.UI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<int, UserLogin, UserRole, UserClaim>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser,int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class UserRole : IdentityUserRole<int> { }
    public class UserLogin : IdentityUserLogin<int> { }
    public class UserClaim : IdentityUserClaim<int> { }
    public class MyRole : IdentityRole<int, UserRole> { }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, MyRole, int, UserLogin, UserRole, UserClaim>
    {
        public ApplicationDbContext()
            : base("forumdatabaseEntities")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}