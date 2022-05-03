using Lila.BLL.DtoModels.Interfaces;

namespace Lila.BLL.DtoModels;

public class OrdersTransportDto : IBaseEntityDto
{
    public int Id { get; set; }
    public int TransportId { get; set; } // FK
    public TransportDto? Transport { get; set; } // nav. property
    public int MyOrderId { get; set; } // FK
    public MyOrderDto? MyOrder { get; set; } // nav. property
}