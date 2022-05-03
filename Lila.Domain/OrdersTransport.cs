using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lila.Domain.Interfaces;

namespace Lila.Domain;

[Table("OrdersTransports")]
public class OrdersTransport : IBaseEntity
{
    [Key]
    public int Id { get; set; }
    public int TransportId { get; set; } // FK
    public Transport? Transport { get; set; } // nav. property
    public int MyOrderId { get; set; } // FK
    public MyOrder? MyOrder { get; set; } // nav. property
}