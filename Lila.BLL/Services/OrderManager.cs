using Lila.DAL.Repository.Interfaces;
using Lila.Domain;

namespace Lila.BLL.Services;

public class OrderManager
{
    private readonly IRepository<Service> _serviceRep;
    private readonly IRepository<OrdersService> _ordersServiceRep;
    private readonly IRepository<MyOrder> _myOrderRep;
    private readonly IRepository<City> _cityRep;

    public OrderManager(IRepository<Service> serviceRep, IRepository<OrdersService> ordersServiceRep, IRepository<MyOrder> myOrderRep, IRepository<City> cityRep)
    {
        _serviceRep = serviceRep;
        _ordersServiceRep = ordersServiceRep;
        _myOrderRep = myOrderRep;
        _cityRep = cityRep;
    }
}