namespace Lila.Domain;

public class TransportsKind : BaseEntity
{
    public string? Description { get; set; }
    public string? Title { get; set; }
    public double LiftingCapacity { get; set; }
    public double Volume { get; set; }
}