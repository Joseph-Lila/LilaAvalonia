using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lila.Domain.Interfaces;

namespace Lila.Domain;

[Table("OrdersServices")]
public class OrdersService : IBaseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public double QuantityWeight { get; set; }
    [Required]
    public double QuantityRadius { get; set; }
    [Required]
    public string DestinationsAddress { get; set; } = "";
    [Required]
    public string DeparturesAddress { get; set; } = "";
    [Required]
    public double TotalCost { get; set; }
    // ---
    public int MyOrderId { get; set; }
    public MyOrder? MyOrder { get; set; }
    // ---
    public int ServiceId { get; set; }
    public Service? Service { get; set; }
    // ---
    public int BeginCityId { get; set; }
    public City? BeginCity { get; set; }
    // ---
    public int EndCityId { get; set; }
    public City? EndCity { get; set; }
}