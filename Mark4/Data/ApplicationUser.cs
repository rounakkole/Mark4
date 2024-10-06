using Mark3.Data.Tables;
using Microsoft.AspNetCore.Identity;

namespace Mark4.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        //learn.microsoft.com/en-us/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-8.0
        public int SetupId { get; set; } // Required foreign key property
        public int? ExchangeId { get; set; } // Required foreign key property

        public SetupTable1 SetupTable1 { get; set; } // Required reference navigation to principal
        public ExchangeTable1 ExchangeTable1 { get; set; } // Required reference navigation to principal

        public ICollection<PortfolioTable1> PortfolioTable1s { get; set; } // Collection navigation containing dependents
    }

}
