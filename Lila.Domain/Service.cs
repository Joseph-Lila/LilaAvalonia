using Lila.Domain.Interfaces;

namespace Lila.Domain;

public class Service : IBaseEntity
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public double CostWeight { get; set; }
    public double CostRadius { get; set; }
}