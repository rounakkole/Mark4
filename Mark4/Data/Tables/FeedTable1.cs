using System.ComponentModel.DataAnnotations;

namespace Mark3.Data.Tables
{
    public class FeedTable1
    {
        public int Id { get; set; }
        public int InstrumentId { get; set; } // Required foreign key property 
        public Decimal ClosePrice { get; set; } = 0;

        //1min=1 5min=5 10min=10 1hr=60 1d=24 1w=7 1mon=30 1yr=12
        public int IntervalNum { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FeedDateTime { get; set; }
        [DataType(DataType.DateTime)]

        public InstrumentTable1 InstrumentTable1 { get; set; } // Required reference navigation to principal
    }
}
