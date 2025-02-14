using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("Price")]
    public class Price : BaseEntity
    {
        [Column("value")]
        public Decimal Value { get; set; }
        [Column("discount")]
        public Decimal Discount { get; set; }
        [Column("acceptDiscount")]
        public bool AcceptDiscount { get; set; }
    }
}
