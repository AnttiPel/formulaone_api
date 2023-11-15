namespace FormulaOneAPI.Models.DTOs;

public class GrandPrixDto
{

    public required string Name { get; set; }
    public DateTime Date { get; set; }
    public required string Location { get; set; }
    public required List<ResultDto> Results { get; set; }
}
