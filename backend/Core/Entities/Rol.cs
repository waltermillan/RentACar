using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("Roles")]
public class Rol : BaseEntity
{
    [Column("description")]
    public string Description { get; set; }
}
