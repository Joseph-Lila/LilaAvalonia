using Lila.BLL.DtoModels;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;

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
    
    public OrderManager(IRepository<Service> serviceRep, IRepository<OrdersService> ordersServiceRep, IRepository<MyOrder> myOrderRep, IRepository<City> cityRep, IRepository<User> userRep, IRepository<Status> statusRep, IRepository<Stage> stageRep)
    {
        _serviceRep = serviceRep;
        _ordersServiceRep = ordersServiceRep;
        _myOrderRep = myOrderRep;
        _cityRep = cityRep;
        _userRep = userRep;
        _statusRep = statusRep;
        _stageRep = stageRep;
        MainEntity = new OrderDto();
    }

    public OrderDto MainEntity { get; private set; }

    public void AddService(OrdersService ordersService)
    {
        int beginCityId = _cityRep.GetAll().Find(x => x.Title == ordersService.BeginCity!.Title)!.Id;
        int endCityId = _cityRep.GetAll().Find(x => x.Title == ordersService.EndCity!.Title)!.Id;
        ordersService.BeginCityId = beginCityId;
        ordersService.EndCityId = endCityId;
        if (MainEntity.Services != null)
            MainEntity.Services.Add(ordersService);
        else
        {
            MainEntity.Services = new List<OrdersService> {ordersService};
        }
    }

    public double ComputeTotalCost(OrdersService ordersService)
    {
        Service service = _serviceRep.GetById(ordersService.Id);
        return ordersService.QuantityRadius * service.CostRadius + ordersService.QuantityWeight * service.CostWeight;
    }
    
    public void RemoveService(OrdersService ordersService)
    {
        if (MainEntity.Services != null)
            MainEntity.Services.Remove(MainEntity.Services.Find(x => 
                Math.Abs(x.TotalCost - ordersService.TotalCost) < 1e-5 && ordersService.ServiceId == x.ServiceId
                && x.DestinationsAddress == ordersService.DestinationsAddress 
                && x.DeparturesAddress == ordersService.DeparturesAddress)!);
    }

    public void DoOrder(MyOrder orderItself, string usersLogin)
    {
        if (MainEntity.Services != null)
        {
            MainEntity.Commissions = orderItself.Commissions;
            MainEntity.Executions = orderItself.Executions;
            MainEntity.Stage = "На рассмотрении";
            MainEntity.Status = "Не оплачен";
            int userId = _userRep.GetAll().Find(x => x.Login == usersLogin)!.Id;
            int stageId = _stageRep.GetAll().Find(x => x.Title == MainEntity.Stage)!.Id;
            int statusId = _statusRep.GetAll().Find(x => x.Title == MainEntity.Status)!.Id;
            MainEntity.CustomerId = userId;
            _myOrderRep.Create(new MyOrder
            {
                Commissions = MainEntity.Commissions,
                Executions = MainEntity.Executions,
                CustomerId = MainEntity.CustomerId,
                StageId = stageId,
                StatusId = statusId,
            });
            int orderId = _myOrderRep.GetAll()
                .Find(x =>
                    x.Commissions == MainEntity.Commissions && x.Executions == MainEntity.Executions 
                                                            && x.CustomerId == MainEntity.CustomerId 
                                                            && x.StageId == stageId && x.StatusId == statusId)!.Id;
            foreach (var service in MainEntity.Services)
            {
                service.MyOrderId = orderId;
                _ordersServiceRep.Create(service);
            }
        }
        ClearMyself();
    }

    private void ClearMyself()
    {
        MainEntity = new OrderDto();
    }
}