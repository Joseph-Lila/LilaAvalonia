using Lila.Domain.Interfaces;

namespace Lila.Domain;

public class OrdersTransport : IBaseEntity
{
    public int Id { get; set; }
    public int TransportId { get; set; }
    public int MyOrderId { get; set; }
}