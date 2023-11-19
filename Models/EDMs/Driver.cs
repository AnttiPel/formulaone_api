namespace FormulaOneAPI.Models.EDMs;

public partial class Driver
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Nationality { get; set; } = null!;

    public DateTime Updated { get; set; }

    public virtual ICollection<Point> Points { get; set; } = new List<Point>();

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
