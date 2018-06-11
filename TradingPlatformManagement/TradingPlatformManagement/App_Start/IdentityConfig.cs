//using BetInAction.Backend.Core.Identity.Stores;
//using BetInAction.Backend.Models.Identity;

//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;
//using Microsoft.Owin;
//using Microsoft.Owin.Security;

//using System;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace TradingPlatformManagement
//{

//    /// <summary>
//    /// Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
//    /// </summary>
//    public class ApplicationUserManager : UserManager<IdentityUser>
//    {
//        public ApplicationUserManager(IUserStore<IdentityUser> store)
//            : base(store)
//        {
//        }

//        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
//        {
//            var manager = new ApplicationUserManager(new UserStore(context.Get<ApplicationDbContext>()));
//            // Configure validation logic for usernames
//            manager.UserValidator = new UserValidator<IdentityUser>(manager)
//            {
//                AllowOnlyAlphanumericUserNames = false,
//                RequireUniqueEmail = true
//            };

//            // Configure validation logic for passwords
//            manager.PasswordValidator = new PasswordValidator
//            {
//                RequiredLength = 3,
//                RequireNonLetterOrDigit = false,
//                RequireDigit = false,
//                RequireLowercase = false,
//                RequireUppercase = false,
//            };

//            // Configure user lockout defaults
//            manager.UserLockoutEnabledByDefault = false;
//            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
//            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

//            return manager;
//        }
//    }


//    /// <summary>
//    /// Configure the application sign-in manager which is used in this application.
//    /// </summary>
//    public class ApplicationSignInManager : SignInManager<IdentityUser, string>
//    {
//        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
//            : base(userManager, authenticationManager)
//        {
//        }

//        public override Task<ClaimsIdentity> CreateUserIdentityAsync(IdentityUser user)
//        {
//            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
//        }

//        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
//        {
//            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
//        }
//    }
//}
