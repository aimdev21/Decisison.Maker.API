namespace Decisison.Maker.API.Data.Entities;

public class UserSelection
{
    public Guid Id { get; set; }
    public Guid DecisionId { get; set; }
    public Decision Decision { get; set; } = null!;
    public Guid UserId { get; set; }
}
