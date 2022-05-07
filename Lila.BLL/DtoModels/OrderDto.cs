using Lila.Domain;

namespace Lila.BLL.DtoModels;

public class OrderDto
{
    public int Id { get; set; }
    public DateTime? Commissions { get; set; }
    public DateTime? Executions { get; set; }
    public int? CustomerId { get; set; }
    public int? OperatorId { get; set; }
    public int? CourierId { get; set; }
    public string Stage { get; set; } = "";
    public string Status { get; set; } = "";
    public List<ShopCartItemDto> ShopCartItems { get; set; } = new();
}