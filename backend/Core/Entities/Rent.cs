using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("Rent")]
    public class Rent : BaseEntity
    {
        [JsonIgnore]
        public Customer Customer { get; set; }  // Relación con Customer

        [Column("id_customer")]
        public int IdCustomer { get; set; }

        [JsonIgnore]
        public Car Car { get; set; }  // Relación con Car
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
}
