using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lila.Domain.Interfaces;

namespace Lila.Domain;

[Table("Cities")]
public class City : IBaseEntity
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = "";
    // ---
    public List<Fleet> Fleets { get; set; } = new();
    public List<CustomersCity> CustomersCities { get; set; } = new();
    [InverseProperty("BeginCity")]
    public List<OrdersService> OrdersServiceBeginCities { get; set; } = new();
    [InverseProperty("EndCity")]
    public List<OrdersService> OrdersServiceEndCities { get; set; } = new();
}
