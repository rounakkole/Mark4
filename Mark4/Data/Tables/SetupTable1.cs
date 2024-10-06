using Mark4.Data;
using System.ComponentModel.DataAnnotations;

namespace Mark3.Data.Tables
{
    public class SetupTable1
    {
        public int Id { get; set; }
        public string UserId { get; set; } // Required foreign key property
        public int ReportExecutionNum { get; set; }
        public int WatchlistNum { get; set; }
        public int RandomNum { get; set; }
        public int IntervalNum { get; set; }
        public int PeriodNum { get; set; }
        public int OffsetNum { get; set; }
        public string UserRole { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedDateTime { get; set; }
        [DataType(DataType.Date)]
        public DateOnly CreatedDate { get; set; }

        public ApplicationUser ApplicationUser { get; set; } // Required reference navigation to principal
    }
}
