namespace Decisison.Maker.API.Data.Entities;

public class Pro
{
    public Guid Id { get; set; }
    public string Description { get; set; } = null!;
    public Guid DecisionId { get; set; }
    public Decision Decision { get; set; } = null!;
}