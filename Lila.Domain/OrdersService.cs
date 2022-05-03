using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lila.Domain.Interfaces;

namespace Lila.Domain;

[Table("OrdersServices")]
public class OrdersService : IBaseEntity
{
    [Key]
    public int Id { get; set; }
    public int ServiceId { get; set; } // FK
    public Service? Service { get; set; } // nav. property
    public int MyOrderId { get; set; } // FK
    public MyOrder? MyOrder { get; set; } // nav. property
    public double QuantityWeight { get; set; }
    public double QuantityRadius { get; set; }
    public string DestinationsAddress { get; set; } = "";
    public string DeparturesAddress { get; set; } = "";
    public double TotalCost { get; set; }
    public int BeginCityId { get; set; } // FK
    public City? BeginCity { get; set; } // nav. property
    public int EndCityId { get; set; } // FK
    public City? EndCity { get; set; } // nav. property
}