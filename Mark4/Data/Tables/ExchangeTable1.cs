using Mark4.Data;
using System.ComponentModel.DataAnnotations;

namespace Mark3.Data.Tables
{
    public class ExchangeTable1
    {
        public int Id { get; set; }
        public string ExSymbolName { get; set; }
        public string ExSymbolDescription { get; set; }
        public string ExCountry { get; set; }
        public string ExCurrency { get; set; }
        public string ExDefaultIndex { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedDateTime { get; set; }
        [DataType(DataType.Date)]
        public DateOnly CreatedDate { get; set; }

        public ICollection<InstrumentTable1> InstrumentTable1s { get; set; } // Collection navigation containing dependents
        public ICollection<ApplicationUser> ApplicationUsers { get; set; } // Collection navigation containing dependents
    }
}
