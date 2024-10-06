using System.ComponentModel.DataAnnotations;

namespace Mark3.Data.Tables
{
    public class WatchlistTable1
    {
        public int Id { get; set; }
        public int InstrumentId { get; set; } // Required foreign key property 
        public int Mark3mIx { get; set; }
        public int Mark1yIx { get; set; }
        public int RandomNum { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedDateTime { get; set; }
        [DataType(DataType.Date)]
        public DateOnly CreatedDate { get; set; }

        public InstrumentTable1 InstrumentTable1 { get; set; } // Required reference navigation to principal
    }
}
