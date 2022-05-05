using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lila.Domain.Interfaces;

namespace Lila.Domain;

[Table("OrdersTransports")]
public class OrdersTransport : IBaseEntity
{
    [Key]
    public int Id { get; set; }
    // ---
    public int TransportId { get; set; }
    public Transport? Transport { get; set; }
    // ---
    public int MyOrderId { get; set; }
    public MyOrder? MyOrder { get; set; }
}