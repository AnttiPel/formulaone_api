namespace FormulaOneAPI.Models.EDMs;

public partial class GrandPrix
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Date { get; set; }

    public string Location { get; set; } = null!;

    public DateTime Updated { get; set; }

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
