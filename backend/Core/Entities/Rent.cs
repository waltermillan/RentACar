using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Entities;

[Table("Rents")]
public class Rent : BaseEntity
{
    [JsonIgnore]
    public Customer Customer { get; set; }  // Relation with Customer

    [Column("id_customer")]
    public int IdCustomer { get; set; }

    [JsonIgnore]
    public Car Car { get; set; }  // Relation with Car
    [Column("id_car")]
    public int IdCar { get; set; }

    [Column("day")]
    public DateTime Day { get; set; }

    [Column("day_remaining")]
    public DateTime DayRemaining { get; set; }

    [Column("pay_type_id")]
    public int PayTypeId { get; set; }

    [Column("price_id")]
    public int PriceId { get; set; }
}
