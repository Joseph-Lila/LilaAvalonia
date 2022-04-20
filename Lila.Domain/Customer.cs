namespace Lila.Domain;

public class Customer : BaseEntity
{
    public int UserId { get; set; }
    public string? Country { get; set; }
    public string? Street { get; set; }
    public int HomeNumber { get; set; }
    public int FlatNumber { get; set; }
    public string? LastName { get; set; }
    public string? Name { get; set; }
    public string? MiddleName { get; set; }
    
    public override string ToString()
    {
        return $"{Id}. ~~~ {UserId} ~~~ {Country} ~~~ {Street} ~~~ {HomeNumber} ~~~ {FlatNumber} ~~~ {LastName} ~~~ {Name} ~~~ {MiddleName}";
    }
}