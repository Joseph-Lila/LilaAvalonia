using Lila.Domain.Interfaces;

namespace Lila.Domain;

public class Fleet : IBaseEntity
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
    public double Square { get; set; }
    public int StarsQuantity { get; set; }
}