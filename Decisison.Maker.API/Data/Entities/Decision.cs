namespace Decisison.Maker.API.Data.Entities;

public class Decision
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<Pro> Pros { get; set; } = new();
    public List<Con> Cons { get; set; } = new();
}
