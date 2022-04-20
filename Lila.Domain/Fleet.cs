namespace Lila.Domain;

public class Fleet : BaseEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
    public double Square { get; set; }
    public int StarsQuantity { get; set; }
}