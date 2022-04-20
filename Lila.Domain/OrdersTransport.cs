namespace Lila.Domain;

public class OrdersTransport : BaseEntity
{
    public int TransportId { get; set; }
    public int MyOrderId { get; set; }
}