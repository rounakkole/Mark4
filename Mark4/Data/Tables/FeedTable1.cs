using System.ComponentModel.DataAnnotations;

namespace Mark3.Data.Tables
{
    public class FeedTable1
    {
        public int Id { get; set; }
        public int InstrumentId { get; set; } // Required foreign key property 
        public Decimal ClosePrice { get; set; } = 0;
        public int IntervalNum { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? FeedDateTime { get; set; }
        [DataType(DataType.DateTime)]

        public InstrumentTable1 InstrumentTable1 { get; set; } // Required reference navigation to principal
    }
}
