using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("Prices")]
public class Price : BaseEntity
{
    [Column("value")]
    public Decimal Value { get; set; }
    [Column("discount")]
    public Decimal Discount { get; set; }
    [Column("acceptDiscount")]
    public bool AcceptDiscount { get; set; }
}
