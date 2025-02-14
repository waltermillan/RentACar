using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("Customer")]
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
}
