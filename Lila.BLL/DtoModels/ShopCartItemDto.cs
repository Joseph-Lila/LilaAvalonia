using Lila.Domain;

namespace Lila.BLL.DtoModels;

public class ShopCartItemDto
{
    public int ShopCartId { get; set; }
    public OrdersService OrdersService { get; set; } = new();
    public int OrderDtoId { get; set; }
    public OrderDto? OrderDto { get; set; }
}