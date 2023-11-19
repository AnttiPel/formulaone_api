namespace FormulaOneAPI.Models.EDMs;

public partial class Result
{
    public int Id { get; set; }

    public int GrandPrixId { get; set; }

    public int DriverId { get; set; }

    public int Position { get; set; }

    public int Points { get; set; }

    public DateTime Updated { get; set; }

    public virtual Driver Driver { get; set; } = null!;

    public virtual GrandPrix GrandPrix { get; set; } = null!;
}
