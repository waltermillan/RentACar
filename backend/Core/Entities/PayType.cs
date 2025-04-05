using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("PayTypes")]
public class PayType : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }
    [Column("details")]
    public string Details { get; set; }
}
