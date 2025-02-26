namespace API.DTOs;

public class CustomerDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public DateTime Day { get; set; }
    public DateTime DayRemaining { get; set; }
    public string PayTypeName { get; set; }
    public decimal Value { get; set; }
}
