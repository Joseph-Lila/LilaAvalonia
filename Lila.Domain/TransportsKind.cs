using Lila.Domain.Interfaces;

namespace Lila.Domain;

public class TransportsKind : IBaseEntity
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public string? Title { get; set; }
    public double LiftingCapacity { get; set; }
    public double Volume { get; set; }
}