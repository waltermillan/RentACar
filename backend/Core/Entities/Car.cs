using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("Car")]
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
}
