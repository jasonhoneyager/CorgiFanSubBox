using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CorgiFanSubBox.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

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
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<SubscriptionModel> Subscription { get; set; }
        public DbSet<BoxModel> Box { get; set; }
        public DbSet<SurveyQuestionsModel> SurveyQuestionModels { get; set; }
        public DbSet<SurveyAnswersModel> SurveyAnswerModels { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<ResponsesModel> Responses { get; set; }
        public DbSet<CombinedQAModel> CombinedQAModels { get; set; }

        public System.Data.Entity.DbSet<CorgiFanSubBox.Models.CustomerModel> CustomerModels { get; set; }
    }
}