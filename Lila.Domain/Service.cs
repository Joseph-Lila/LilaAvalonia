namespace Lila.Domain;

public class Service : BaseEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public double CostWeight { get; set; }
    public double CostRadius { get; set; }
}