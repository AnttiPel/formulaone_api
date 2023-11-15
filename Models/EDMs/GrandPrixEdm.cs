namespace FormulaOneAPI.Models.EDMs;

public class GrandPrixEdm
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime Date { get; set; }
    public required string Location { get; set; }
}
