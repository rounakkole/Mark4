using Mark4.Data;
using System.ComponentModel.DataAnnotations;

namespace Mark3.Data.Tables
{
    public class PortfolioTable1
    {
        public int Id { get; set; }
        public string UserId { get; set; } // Required foreign key property
        public int InstrumentId { get; set; } // Required foreign key property 
        public Decimal AveragePrice { get; set; }
        public int Quantity { get; set; } = 0;
        public int NewQuantity { get; set; } = 0;
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedDateTime { get; set; }
        [DataType(DataType.Date)]
        public DateOnly CreatedDate { get; set; }

        public ApplicationUser ApplicationUser { get; set; } // Required reference navigation to principal
        public InstrumentTable1 InstrumentTable1 { get; set; } // Required reference navigation to principal
    }
}
