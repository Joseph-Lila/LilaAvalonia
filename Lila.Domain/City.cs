namespace Lila.Domain;

public class City : BaseEntity
{
    public string? Title { get; set; }
    
    public override string ToString()
    {
        return $"{Id}. ~~~ {Title}";
    }
}
