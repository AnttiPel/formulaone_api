namespace FormulaOneAPI.Models.DTOs;

public class DriverDto
{
    public required string Name { get; set; }
    public required string Nationality { get; set; }
    public int TotalPoints { get; set; }
}
