using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

// Base Entity pattern design:The Base Entity is a class or interface that contains common properties and methods that can be shared by all entities in the system.
// In this case the ID field is contained in all entities of the system.
public class BaseEntity
{
    [Column("id")]
    public int Id { get; set; }
}
