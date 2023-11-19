namespace FormulaOneAPI.Models.EDMs;

public partial class Point
{
    public int Id { get; set; }

    public int DriverId { get; set; }

    public int TotalPoints { get; set; }

    public DateTime Updated { get; set; }

    public virtual Driver Driver { get; set; } = null!;
}
