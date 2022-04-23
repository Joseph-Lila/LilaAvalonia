using Lila.Domain.Interfaces;

namespace Lila.Domain;

public class City : IBaseEntity
{
    public int Id { get; set; }
    public string? Title { get; set; }
}
