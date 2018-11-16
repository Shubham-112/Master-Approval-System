using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Master_Approval_System.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public Company Company { get; set; }
        public int? CompanyId { get; set; }

        public string Address { get; set; }

        public string Post { get; set; }

        public string salary { get; set; }

        public SalaryProcessRequest SalaryProcessRequest { get; set; }
        public int? SalaryProcessRequestId { get; set; }

        public SalaryMasterRequest SalaryMasterRequest { get; set; }
        public int? SalaryMasterRequestId { get; set; }

        public ProfileUpdateRequest ProfileUpdateRequest { get; set; }
        public int? ProfileUpdateRequestId { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<SalaryMasterRequest> SalaryMasterRequests { get; set; }
        public DbSet<SalaryProcessRequest> SalaryProcessRequests { get; set; }
        public DbSet<ProfileUpdateRequest> ProfileUpdateRequests { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        }
    }
}