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

    public void MarkAsPaid(MyOrder order)
    {
        int statusId = _statusRep.GetAll().Find(x => x.Title == "Не оплачен")!.Id;
        int stageId = _stageRep.GetAll().Find(x => x.Title == "На рассмотрении")!.Id;
        order.StatusId = statusId;
        order.StageId = stageId;
        _myOrderRep.Update(order);
    }
    public List<MyOrder> GetMyOrders(string login)
    {
        int customerId = _userRep.GetAll().Find(x => x.Login == login)!.Id;
        return _myOrderRep.GetAll().FindAll(x => x.CustomerId == customerId);
    }
    public void AddFullOrder(string login, List<ShopCartItemDto> shopCartItems)
    {
        int customerId = _userRep.GetAll().Find(x => x.Login == login)!.Id;
        int myOrderId = AddMyOrder(customerId);
        MyOrder myOrder = _myOrderRep.GetById(myOrderId);
        foreach (var item in shopCartItems)
        {
            int id = _ordersServiceRep.Create(new OrdersService
            {
                MyOrderId = myOrderId,
                BeginCityId = item.OrdersService.BeginCityId,
                EndCityId = item.OrdersService.EndCityId,
                DeparturesAddress = item.OrdersService.DeparturesAddress,
                DestinationsAddress = item.OrdersService.DestinationsAddress,
                QuantityRadius = item.OrdersService.QuantityRadius,
                QuantityWeight = item.OrdersService.QuantityWeight,
                TotalCost = item.OrdersService.TotalCost,
                ServiceId = item.OrdersService.ServiceId
            });
            OrdersService newItem = _ordersServiceRep.GetById(id);
            myOrder.OrdersServices.Add(newItem);
        }
        Cart = new OrderDto();
    }
    
    private int AddMyOrder(int customerId)
    {
        int statusId = _statusRep.GetAll().Find(x => x.Title == "Не оплачен")!.Id;
        return _myOrderRep.Create(new MyOrder
        {
            Commissions = DateTime.Now,
            CustomerId = customerId,
            StatusId = statusId,
        });
    }
    public void AddOrdersServiceLocally(OrdersService item)
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