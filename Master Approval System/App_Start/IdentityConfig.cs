using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using Master_Approval_System.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Master_Approval_System.Models;


namespace Master_Approval_System
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        public async Task<SignInStatus> PasswordSignInAsync(string userEmail, string password, string company, bool isPersistent, bool shouldLockout)
        {
            SignInStatus signInStatus = SignInStatus.Success;

            if (this.UserManager != null)
            {
                Task<ApplicationUser> userAwaiter = this.UserManager.FindByEmailAsync(userEmail);
                var passCheck = HashPassword(password);
                ApplicationUser tUser = await userAwaiter;
                if (tUser != null)
                {
                    var company_db = _context.Companies.SingleOrDefault(c => tUser.CompanyId == c.Id);
                    Task<bool> cultureAwaiter1 = this.UserManager.IsLockedOutAsync(tUser.Id);
                    if (!await cultureAwaiter1)
                    {
                        Task<bool> cultureAwaiter2 = this.UserManager.CheckPasswordAsync(tUser, passCheck);
                        if (!await cultureAwaiter2)
                        {
                            
                            if (company.Equals(company_db.Name))
                            {
                                signInStatus = SignInStatus.Success;
                                await base.PasswordSignInAsync(userEmail, password, isPersistent, shouldLockout: false);
                            }
                            else
                            {
                                signInStatus = SignInStatus.Failure;
                            }
                        }
                        else
                        {
                            if (shouldLockout)
                            {
                                Task<IdentityResult> cultureAwaiter3 = this.UserManager.AccessFailedAsync(tUser.Id);
                                await cultureAwaiter3;
                                Task<bool> cultureAwaiter4 = this.UserManager.IsLockedOutAsync(tUser.Id);
                                if (await cultureAwaiter4)
                                {
                                    signInStatus = SignInStatus.LockedOut;
                                    return signInStatus;
                                }
                            }
                            signInStatus = SignInStatus.Failure;
                        }
                    }
                    else
                    {
                        signInStatus = SignInStatus.LockedOut;
                    }
                }
                else
                {
                    signInStatus = SignInStatus.Failure;
                }
            }
            else
            {
                signInStatus = SignInStatus.Failure;
            }
            return signInStatus;
        }

        public override async Task<SignInStatus> PasswordSignInAsync(string userEmail, string password, bool isPersistent, bool shouldLockout)
        {
            SignInStatus signInStatus = SignInStatus.Success;
            if (this.UserManager != null)
            {
                /// changed to use email address instead of username
                Task<ApplicationUser> userAwaiter = this.UserManager.FindByEmailAsync(userEmail);

                ApplicationUser tUser = await userAwaiter;
                if (tUser != null)
                {
                    Task<bool> cultureAwaiter1 = this.UserManager.IsLockedOutAsync(tUser.Id);
                    if (!await cultureAwaiter1)
                    {
                        Task<bool> cultureAwaiter2 = this.UserManager.CheckPasswordAsync(tUser, password);
                        if (!await cultureAwaiter2)
                        {
                            if (shouldLockout)
                            {
                                Task<IdentityResult> cultureAwaiter3 = this.UserManager.AccessFailedAsync(tUser.Id);
                                await cultureAwaiter3;
                                Task<bool> cultureAwaiter4 = this.UserManager.IsLockedOutAsync(tUser.Id);
                                if (await cultureAwaiter4)
                                {
                                    signInStatus = SignInStatus.LockedOut;
                                    return signInStatus;
                                }
                            }
                            signInStatus = SignInStatus.Failure;
                        }
                    }
                    else
                    {
                        signInStatus = SignInStatus.LockedOut;
                    }
                }
                else
                {
                    signInStatus = SignInStatus.Failure;
                }
            }
            else
            {
                signInStatus = SignInStatus.Failure;
            }
            return signInStatus;
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
