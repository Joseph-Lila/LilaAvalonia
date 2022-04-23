using Lila.BLL.DtoModels.Interfaces;

namespace Lila.BLL.DtoModels;

public class OrdersTransportDto : IBaseEntityDto
{
    public int Id { get; set; }
    public int TransportId { get; set; }
    public int MyOrderId { get; set; }
}