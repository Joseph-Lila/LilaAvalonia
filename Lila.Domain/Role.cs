using Lila.Domain.Interfaces;

namespace Lila.Domain;

public class Role : IBaseEntity
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}