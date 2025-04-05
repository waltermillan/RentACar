using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("Cars")]
public class Car : BaseEntity
{
    [Column("model")]
    public string Model { get; set; }
    [Column("brand")]
    public string Brand { get; set; }
    [Column("year")]
    public int Year { get; set; }
    [Column("rented")]
    public int Rented { get; set; }
    [Column("id_price")]
    public int IdPrice { get; set; }
}
