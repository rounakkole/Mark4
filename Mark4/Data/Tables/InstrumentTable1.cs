using System.ComponentModel.DataAnnotations;

namespace Mark3.Data.Tables
{
    public class InstrumentTable1
    {
        public int Id { get; set; }
        public int ExchangeId { get; set; } // Required foreign key property
        public int? WatchlistId { get; set; } // Required foreign key property
        public string InSymbolName { get; set; }
        public string InSymbolDescription { get; set; }
        public string? InSector { get; set; }
        public string? InType { get; set; }
        public bool IsRisky { get; set; } = false;
        public bool IsInactive { get; set; } = false;
        public Decimal ClosePrice { get; set; }
        public int Mark3mIx { get; set; }
        public int Mark1yIx { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedDateTime { get; set; }
        [DataType(DataType.Date)]
        public DateOnly CreatedDate { get; set; }
        public int InMarketCap { get; set; }
        public string? InEventHeader { get; set; }
        public string? InEventLine { get; set; }

        public ExchangeTable1 ExchangeTable1 { get; set; } // Required reference navigation to principal
        public WatchlistTable1 WatchlistTable1 { get; set; } // Required reference navigation to principal
        public ICollection<PortfolioTable1> PortfolioTable1s { get; set; } // Collection navigation containing dependents
        public ICollection<FeedTable1> FeedTable1s { get; set; } // Collection navigation containing dependents
    }
}
