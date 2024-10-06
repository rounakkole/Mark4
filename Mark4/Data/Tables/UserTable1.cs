using Microsoft.AspNetCore.Identity;

namespace Mark3.Data.Tables
{
    public class UserTable1 : IdentityUser
    {
        public int SetupId { get; set; } // Required foreign key property
        public int ExchangeId { get; set; } // Required foreign key property

        public SetupTable1 SetupTable1 { get; set; } // Required reference navigation to principal
        public ExchangeTable1 ExchangeTable1 { get; set; } // Required reference navigation to principal

        public ICollection<PortfolioTable1> PortfolioTable1s { get; set; } // Collection navigation containing dependents
    }
}
