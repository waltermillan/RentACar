namespace API.DTOs;

public class RentDTO
{
    public int Id { get; set; }                     //ID => Table: Rent Field: Id
    public int IdCustomer { get; set; }             //ID => Table: Customer Field: Id
    public string Name { get; set; }                //ID => Table: Customer Field: Name
    public int IdModel { get; set; }                //ID => Table: Car Field: Id
    public string Model { get; set; }               //ID => Table: Car Field: Model
    public string Brand { get; set; }               //ID => Table: Car Field: Brand
    public DateTime Day { get; set; }               //ID => Table: Rent Field: Day
    public DateTime DayRemaining { get; set; }      //ID => Table: Rent Field: DayRemaining
    public int IdPayTypeName { get; set; }          //ID => Table: PayType Field: Id
    public string PayTypeName { get; set; }         //ID => Table: PayType Field: Name
    public int IdPrice { get; set; }                //ID => Price: PayType Field: Id
    public decimal Price { get; set; }              //ID => Price: PayType Field: Value
}
