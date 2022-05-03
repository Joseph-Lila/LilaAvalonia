using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lila.Domain.Interfaces;

namespace Lila.Domain;

[Table("Fleets")]
public class Fleet : IBaseEntity
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Address { get; set; } = "";
    public double Square { get; set; }
    public int StarsQuantity { get; set; }
    public int CityId { get; set; } // FK
    public City? City { get; set; } // nav. property
}