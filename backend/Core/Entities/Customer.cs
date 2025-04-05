using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("Customers")]
public class Customer : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }
    [Column("document")]
    public string Document { get; set; }
    [Column("document_type")]
    public int DocumentType { get; set; }
    [Column("birth_date")]
    public DateTime BirthDate { get; set; }
}
