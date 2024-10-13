using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Mark3.Data.Tables;
public class PortfolioList
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    [Ignore]
    public int Id { get; set; }
    [Column("UserId")]
    [MaxLength(20)]
    [Name("UserId")]
    public string? UserId { get; set; } // Required foreign key property 
    [Column("InstrumentId")]
    [Name("InstrumentId")]
    public int InstrumentId { get; set; } // Required foreign key property 
    [Column("Quantity", TypeName = "decimal(7, 2)")]
    [Name("Quantity")]
    public int? Quantity { get; set; }
    [Column("NewQuantity")]
    [Name("NewQuantity")]
    public int? NewQuantity { get; set; }



}
