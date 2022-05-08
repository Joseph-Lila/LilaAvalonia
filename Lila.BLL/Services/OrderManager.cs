using Lila.BLL.DtoModels;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using System.Text.Json;

namespace Lila.BLL.Services;

public class OrderManager
{
    private readonly IRepository<Service> _serviceRep;
    private readonly IRepository<OrdersService> _ordersServiceRep;
    private readonly IRepository<MyOrder> _myOrderRep;
    private readonly IRepository<City> _cityRep;
    private readonly IRepository<User> _userRep;
    private readonly IRepository<Status> _statusRep;
    private readonly IRepository<Stage> _stageRep;
    
    public OrderDto Cart { get; set; }

    public OrderManager(IRepository<Service> serviceRep, IRepository<OrdersService> ordersServiceRep, IRepository<MyOrder> myOrderRep, IRepository<City> cityRep, IRepository<User> userRep, IRepository<Status> statusRep, IRepository<Stage> stageRep)
    {
        _serviceRep = serviceRep;
        _ordersServiceRep = ordersServiceRep;
        _myOrderRep = myOrderRep;
        _cityRep = cityRep;
        _userRep = userRep;
        _statusRep = statusRep;
        _stageRep = stageRep;
        Cart = new OrderDto();
    }

    public void AddOrdersService(OrdersService item)
    {
        ShopCartItemDto newItem = new ShopCartItemDto
            {OrderDto = null, OrderDtoId = Cart.Id, OrdersService = item, ShopCartId = GetNextServiceId()};
        Cart.ShopCartItems.Add(newItem);
    }

    private int GetNextServiceId()
    {
        if (Cart.ShopCartItems.Count == 0)
        {
            return 1;
        }
        return Cart.ShopCartItems.Max(x => x.ShopCartId) + 1;
    }
    
    public string CartJsonString()
    {
        return JsonSerializer.Serialize(Cart);
    }

    public void UpdateCartByJsonString(string jsonString)
    {
        Cart = JsonSerializer.Deserialize<OrderDto>(jsonString)!;
    }
}